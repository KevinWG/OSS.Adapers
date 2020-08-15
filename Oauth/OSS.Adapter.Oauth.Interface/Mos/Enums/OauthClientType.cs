#region Copyright (C) 2020 Kevin (OSS开源实验室) 公众号：osscore

/***************************************************************************
*　　	文件功能描述：Oauth token实体
*
*　　	创建人： Kevin
*       创建人Email：1985088337@qq.com
*    	创建日期：20120-8-14
*       
*****************************************************************************/

#endregion

namespace OSS.Adapter.Oauth.Interface.Mos.Enums
{
    public enum OauthClientType
    {
        /// <summary>
        ///  纯网页授权
        /// </summary>
        Web = 1,

        /// <summary>
        ///  应用内部网页授权
        /// </summary>
        InnerWeb = 2,

        /// <summary>
        ///  应用内网页静默授权
        /// </summary>
        InnerSilence = 4,
    }
}
