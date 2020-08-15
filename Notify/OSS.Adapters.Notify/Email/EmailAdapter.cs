#region Copyright (C) 2019 Kevin (OSS开源实验室) 公众号：osscore

/***************************************************************************
*　　	文件功能描述：OSSCore 邮件发送适配器
*
*　　	创建人： Kevin
*       创建人Email：1985088337@qq.com
*    	创建日期：2019-12-11
*       
*****************************************************************************/

#endregion

using System.Linq;
using System.Threading.Tasks;
using OSS.Adapters.Notify.Email.Mos;
using OSS.Adapters.Notify.Reqs;
using OSS.Common.BasicMos.Resp;

namespace OSS.Adapters.Notify.Email
{
    /// <summary>
    ///  邮件帮助类
    /// </summary>
    public class EmailAdapter : INotifyAdapter
    {
        private readonly EmailSmtpConfig _config;

        public EmailAdapter(EmailSmtpConfig config)
        {
            _config = config;
        }

        public async Task<NotifyResp> Send(TemplateMo template, NotifyReq msg)
        {
            var body = msg.body_paras.Aggregate(template.content, (current, p) => current.Replace(string.Concat("{", p.Key, "}"), p.Value));

            var emailMsg = new EmailMsgMo
            {
                body      = body,
                is_html   = template.is_html,
                subject   = string.IsNullOrEmpty(msg.msg_title) ? template.title : msg.msg_title,
                to_emails = msg.targets
            };

            var eRes       = await EmailHelper.SendAsync(_config, emailMsg);
            var notifyResp = new NotifyResp().WithResp(eRes);

            notifyResp.msg_biz_id = msg.msg_Id;

            return notifyResp;
        }



    }
}