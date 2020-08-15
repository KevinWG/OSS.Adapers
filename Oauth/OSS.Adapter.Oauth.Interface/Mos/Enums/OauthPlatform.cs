#region Copyright (C) 2020 Kevin (OSS开源实验室) 公众号：osscore

/***************************************************************************
*　　	文件功能描述：Oauth 平台枚举值
*
*　　	创建人： Kevin
*       创建人Email：1985088337@qq.com
*    	创建日期：20120-8-14
*       
*****************************************************************************/

#endregion


namespace OSS.Adapter.Oauth.Interface.Mos.Enums
{
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
