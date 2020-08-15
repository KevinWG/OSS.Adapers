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

using OSS.Adapter.Oauth.Interface.Mos.Enums;

namespace OSS.Adapter.Oauth.Interface.Mos
{
    /// <summary>
    ///  用户授权Token信息
    /// </summary>
    public class OauthAccessTokenMo 
    {
        /// <summary>
        ///  应用的用户Id
        /// </summary>
        public string app_user_id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string access_token { get; set; }

        /// <summary>
        /// 刷新token
        /// </summary>
        public string refresh_token { get; set; }

        /// <summary>
        /// 过期时间
        /// </summary>
        public long expire_date { get; set; }
    }

    /// <summary>
    ///  第三方授权用户基础信息
    /// </summary>
    public class OauthUser : OauthAccessTokenMo
    {
        /// <summary>
        /// 性别
        /// </summary>
        public OauthSexType sex { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string nick_name { get; set; }

        /// <summary>
        ///  平台下统一用户Id
        /// </summary>
        public string app_union_id { get; set; }

        /// <summary>
        ///  头像
        /// </summary>
        public string head_img { get; set; }

        /// <summary>
        /// 外部平台
        /// </summary>
        public OauthPlatform social_plat { get; set; }
    }


    public static class OauthUserMaps
    {
        /// <summary>
        /// 设置token相关的信息
        /// </summary>
        /// <param name="target"></param>
        /// <param name="source"></param>
        public static void SetTokenInfo(this OauthUser target, OauthAccessTokenMo source)
        {
            target.access_token = source.access_token;
            target.expire_date = source.expire_date;
            target.refresh_token = source.refresh_token;
        }
    }
}
