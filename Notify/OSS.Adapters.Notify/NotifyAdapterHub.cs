using OSS.Adapters.Notify.Email;
using OSS.Adapters.Notify.Email.Mos;
using OSS.Adapters.Notify.Reqs;
using OSS.Adapters.Notify.Sms.Ali;
using OSS.Adapters.Notify.Sms.Ali.Mos;

namespace OSS.Adapters.Notify
{
    public static class NotifyAdapterHub
    {
        //public static INotifyAdapter GetAdapter(NotifyPlatform msg)
        //{
        //    // todo  完善配置处理
        //    switch (msg)
        //    {
        //        case NotifyPlatform.SMS:
        //            return new AliSmsAdapter();
        //        case NotifyPlatform.Email:
        //            return new EmailAdapter();
        //    }

        //    return null;
        //}


        public static INotifyAdapter GetAliSmsAdapter(AliSmsConfig config)
        {
            var handler = new AliSmsAdapter(config);
            return handler;
        }
        public static INotifyAdapter GetEmailAdapter(EmailSmtpConfig config)
        {
             return new EmailAdapter(config);
        }
    }
}
