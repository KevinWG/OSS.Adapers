#region Copyright (C) 2017 Kevin (OSS开源实验室) 公众号：osscore

/***************************************************************************
*　　	文件功能描述：OSSCore插件 —— 阿里云 短信实现
*
*　　	创建人： Kevin
*       创建人Email：1985088337@qq.com
*    	创建日期：2017-10-22
*       
*****************************************************************************/

#endregion

using System.Threading.Tasks;
using OSS.Adapters.Notify.Reqs;
using OSS.Adapters.Notify.Sms.Ali.Mos;

namespace OSS.Adapters.Notify.Sms.Ali
{
    public class AliSmsAdapter : INotifyAdapter
    {
        private readonly AliSmsConfig _config;

        public AliSmsAdapter(AliSmsConfig config)
        {
            _config = config;
        }

        public Task<NotifyResp> Send(TemplateMo template, NotifyReq msg)
        {
            return AliSmsHelper.Send(_config, template, msg);
        }
    }
}
