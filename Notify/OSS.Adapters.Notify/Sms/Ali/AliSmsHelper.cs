using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OSS.Adapters.Notify.Reqs;
using OSS.Adapters.Notify.Sms.Ali.Mos;
using OSS.Common.BasicMos.Resp;
using OSS.Common.Encrypt;
using OSS.Common.Extention;
using OSS.Tools.Http.Extention;
using OSS.Tools.Http.Mos;

namespace OSS.Adapters.Notify.Sms.Ali
{

    /// <summary>
    ///  阿里云的短信实现
    /// </summary>
    public static class AliSmsHelper
    {
        public static async Task<NotifyResp> Send(AliSmsConfig apiConfig, TemplateMo template, NotifyReq msg)
        {
            var dirs = new SortedDictionary<string, string>(StringComparer.Ordinal)
            {
                {"Action", "SendSms"},
                {"Version", apiConfig.Version},
                {"RegionId", apiConfig.RegionId},
                {"PhoneNumbers", string.Join(",", msg.targets)},
                {"SignName", template.sign_name},
                {"TemplateCode", msg.t_code}
            };

            if (msg.body_paras != null && msg.body_paras.Count > 0)
            {
                var temparas = JsonConvert.SerializeObject(msg.body_paras);
                dirs.Add("TemplateParam", temparas);
            }

            FillApiPara(apiConfig, dirs);

            var req = new OssHttpRequest
            {
                AddressUrl = string.Concat("http://dysmsapi.aliyuncs.com?", GeneratePostData(apiConfig, dirs)),
                HttpMethod = HttpMethod.Get
            };

            using (var resp = await req.RestSend())
            {

                var content = await resp.Content.ReadAsStringAsync();
                var aliRes = JsonConvert.DeserializeObject<SendAliSmsResp>(content);

                return aliRes.ConvertToResp();

            }
        }

        #region 辅助方法

        private static string GeneratePostData(AliSmsConfig config, SortedDictionary<string, string> paras)
        {
            var content = string.Join("&",
                paras.Select(k =>
                    string.Concat(SpecicalUrlEncode(k.Key), "=", SpecicalUrlEncode(k.Value))));

            var preEncryStr = string.Concat("GET&", SpecicalUrlEncode("/"), "&", SpecicalUrlEncode(content));
            var sign = HMACSHA.EncryptBase64(preEncryStr, string.Concat(config.AppSecret, "&"));

            return string.Concat("Signature=", SpecicalUrlEncode(sign), "&", content);
        }

        private static void FillApiPara(AliSmsConfig config, IDictionary<string, string> sortDic)
        {
            var dateTime = DateTime.Now.ToUniversalTime()
                .ToString("yyyy-MM-ddTHH:mm:ssZ", CultureInfo.CreateSpecificCulture("en-US"));

            sortDic.Add("AccessKeyId", config.AppId);
            sortDic.Add("Timestamp", dateTime);
            sortDic.Add("Format", "JSON");
            sortDic.Add("SignatureMethod", "HMAC-SHA1");

            sortDic.Add("SignatureVersion", "1.0");
            sortDic.Add("SignatureNonce", Guid.NewGuid().ToString());
        }

        private static string SpecicalUrlEncode(string data)
        {
            return data.UrlEncode().Replace("+", "%20").Replace("*", "%2A").Replace("%7E", "~");
        }

        #endregion
    }

    public class SendAliSmsResp : Resp
    {
        /// <summary>
        ///  状态码-返回OK代表请求成功,其他错误码详见错误码列表
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        ///	状态码的描述
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        ///  发送回执ID,可根据该ID查询具体的发送状态
        /// </summary>
        public string BizId { get; set; }

        /// <summary>
        ///  请求ID
        /// </summary>
        public string RequestId { get; set; }
    }

    public static class SendAliSmsRespExtention
    {
        public static NotifyResp ConvertToResp(this SendAliSmsResp aliResp)
        {
            var res = new NotifyResp
            {
                msg_biz_id = aliResp.BizId,
                msg = aliResp.Message
            };

            if (aliResp.Code == "OK")
                return res;

            res.ret = -1;
            return res;
        }
    }
}
