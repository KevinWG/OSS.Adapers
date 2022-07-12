#region Copyright (C) 2020 Kevin (OSS开源系列) 公众号：osscore

/***************************************************************************
*　　	文件功能描述：阿里云的短信发送统一适配
*
*　　	创建人： Kevin
*       创建人Email：1985088337@qq.com       
*    	创建日期： 2020-08-14
*       
*****************************************************************************/

#endregion

using OSS.Clients.SMS.Ali;
using OSS.Common.Resp;
using System.Threading.Tasks;

namespace OSS.Adapter.SMS.Ali
{
    /// <summary>
    /// 阿里短信发送适配
    /// </summary>
    public class AliSmsAdapter : AliSmsClient, ISmsAdapter
    {
        /// <summary>
        /// 发送方法
        /// </summary>
        /// <param name="sendMsg"></param>
        /// <returns></returns>
        public async Task<SendSmsResp> SendAsync(SendSmsReq sendMsg)
        {
            return (await base.SendAsync(sendMsg.ToAliSmsReq())).ToSmsResp();
        }
    }
    
    /// <summary>
    ///   请求数据映射
    /// </summary>
    public static class SendSmsReqMaps
    {
        /// <summary>
        ///  转化成阿里云端发送请求
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public static AliSendSmsReq ToAliSmsReq(this SendSmsReq req)
        {
            var aliReq = new AliSendSmsReq
            {
                phone_nums    = req.PhoneNums,
                body_paras    = req.body_paras,
                sign_name     = req.sign_name,
                template_code = req.template_code
            };
            return aliReq;
        }

        /// <summary>
        ///  转化成通用统一响应
        /// </summary>
        /// <param name="aResp"></param>
        /// <returns></returns>
        public static SendSmsResp ToSmsResp(this  AliSendSmsResp aResp)
        {
            var resp=new SendSmsResp();

            if (aResp.Code.ToUpper()!= "OK")
            {
                resp.WithResp(RespCodes.OperateFailed, aResp.Message);
            }

            resp.plat_msg_id = aResp.BizId;
            return resp;
        }
    }

}
