#region Copyright (C) 2017 Kevin (OSS开源实验室) 公众号：osscore

/***************************************************************************
*　　	文件功能描述：OSSCore基础层 ——  短信插件实体
*
*　　	创建人： Kevin
*       创建人Email：1985088337@qq.com
*    	创建日期：2017-5-7
*       
*****************************************************************************/

#endregion

using System.Collections.Generic;
using OSS.Common.BasicMos.Resp;

namespace OSS.Adapter.SMS.Interface.Mos
{
    public class SendSmsReq
    {
        /// <summary>
        ///  模板编号
        /// </summary>
        public string template_code { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public IList<string> PhoneNums { get; set; }

        /// <summary>
        ///  短信签名
        /// </summary>
        public string sign_name { get; set; }

        /// <summary>
        ///  内容数据
        /// </summary>
        public Dictionary<string, string> body_paras { get; set; }
    }

    public class SendSmsResp : Resp
    {
        /// <summary>
        ///  消息处理业务Id
        /// </summary>
        public string plat_msg_id { get; set; }
    }

}
