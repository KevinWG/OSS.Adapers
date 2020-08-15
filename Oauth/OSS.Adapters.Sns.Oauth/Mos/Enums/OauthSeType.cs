using System;
using System.Collections.Generic;
using System.Text;

namespace OSS.Adapters.Sns.Oauth.Mos.Enums
{
    public enum OauthSexType
    {
        UnKnow = 0,
        Male   = 1,
        Female = 2
    }

    public enum OauthPlatform
    {
        /// <summary>
        ///     微信公众号
        /// </summary>
        WeChat = 10,

        /// <summary>
        /// 微信小程序
        /// </summary>
        WeChatApp = 11,

        /// <summary>
        ///     支付宝
        /// </summary>
        AliPay = 20,

        /// <summary>
        ///     新浪
        /// </summary>
        Sina = 30
    }
}
