#region Copyright (C) 2017 Kevin (OSS开源实验室) 公众号：osscore

/***************************************************************************
*　　	文件功能描述：OSSCore服务层 —— 授权实体扩展转化方法实体
*
*　　	创建人： Kevin
*       创建人Email：1985088337@qq.com
*    	创建日期：2017-10-14
*       
*****************************************************************************/

#endregion


using System;
using OSS.Adapter.Oauth.Interface.Mos;
using OSS.Adapter.Oauth.Interface.Mos.Enums;
using OSS.Clients.Oauth.WX.Mos;
using OSS.Common.BasicMos.Resp;
using OSS.Common.Extention;

namespace OSS.Adapter.Oauth.WX.Extention
{
    /// <summary>
    ///     微信sdk授权信息实体的 扩展方法
    /// </summary>
    public static class WXOauthAccessTokenExtention
    {
        /// <summary>
        ///     转化微信的授权token实体到通用实体
        /// </summary>
        /// <param name="wxMo"></param>
        /// <returns></returns>
        public static Resp<OauthAccessTokenMo> ConvertToComMo(this WXGetOauthAccessTokenResp wxMo)
        {
            if (!wxMo.IsSuccess())
                return new Resp<OauthAccessTokenMo>().WithResp(wxMo);// wxMo.ConvertToResult<OauthAccessTokenMo>();

            var nowTimestamp = DateTime.Now.ToUtcSeconds();

            var comMo = new OauthAccessTokenMo
            {
                access_token = wxMo.access_token,
                expire_date = nowTimestamp + wxMo.expires_in,
                refresh_token = wxMo.refresh_token,
                app_user_id = wxMo.openid
            };
            return new Resp<OauthAccessTokenMo>(comMo);
        }


        /// <summary>
        ///     转化到授权实体
        /// </summary>
        /// <param name="wxMo"></param>
        /// <returns></returns>
        public static Resp<OauthUser> ConvertToComMo(this WXGetOauthUserResp wxMo)
        {
            if (!wxMo.IsSuccess())
                return new Resp<OauthUser>().WithResp(wxMo);

            var comMo = new OauthUser
            {
                app_user_id = wxMo.openid,
                app_union_id = wxMo.unionid,
                sex = (OauthSexType) wxMo.sex,
                nick_name = wxMo.nickname,
                social_plat = OauthPlatform.WeChat,

                head_img = wxMo.headimgurl
            };
            return new Resp<OauthUser>(comMo);
        }
    }
}