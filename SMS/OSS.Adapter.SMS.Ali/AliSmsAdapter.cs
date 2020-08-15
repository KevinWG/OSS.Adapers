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

using System.Threading.Tasks;
using OSS.Adapter.SMS.Interface;
using OSS.Adapter.SMS.Interface.Mos;
using OSS.Clients.SMS.Ali;
using OSS.Clients.SMS.Ali.Reqs;
using OSS.Common.BasicMos.Resp;

namespace OSS.Adapter.SMS.Ali
{
    public class AliSmsAdapter :AliSmsClient, ISmsAdapter
    {
        public AliSmsAdapter(AliSmsConfig config)//:base(config)
        {
        }

        public async Task<SendSmsResp> Send(SendSmsReq sendMsg)
        {
            return (await base.Send(sendMsg.ToAliSmsReq())).ToSmsResp();
        }
    }

    public static class SendSmsReqMaps
    {
        public static SendAliSmsReq ToAliSmsReq(this SendSmsReq req)
        {
            var aliReq = new SendAliSmsReq
            {
                PhoneNums     = req.PhoneNums,
                body_paras    = req.body_paras,
                sign_name     = req.sign_name,
                template_code = req.template_code
            };

            return aliReq;
        }


        public static SendSmsResp ToSmsResp(this  SendAliSmsResp aResp)
        {
            var resp=new SendSmsResp();

            resp.WithResp(aResp);
            resp.plat_msg_id = aResp.BizId;
            return resp;
        }
    }

}
