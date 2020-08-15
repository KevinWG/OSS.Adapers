#region Copyright (C) 2017 Kevin (OSS开源实验室) 公众号：osscore

/***************************************************************************
*　　	文件功能描述：OSSCore服务层 —— 微信授权处理类
*
*　　	创建人： Kevin
*       创建人Email：1985088337@qq.com
*    	创建日期：2017-10-14
*       
*****************************************************************************/

#endregion

using System.Threading.Tasks;
using OSS.Adapter.Oauth.Interface;
using OSS.Adapter.Oauth.Interface.Mos;
using OSS.Adapter.Oauth.Interface.Mos.Enums;
using OSS.Adapter.Oauth.WX.Extention;
using OSS.Clients.Oauth.WX;
using OSS.Clients.Oauth.WX.Mos;
using OSS.Common.BasicMos;
using OSS.Common.BasicMos.Resp;

namespace OSS.Adapter.Oauth.WX
{
    /// <summary>
    ///     微信授权处理类
    /// </summary>
    public class WXOauthAdapter : WXOauthApi, IOauthAdapter
    {
        public WXOauthAdapter(): base(null) { }
        public WXOauthAdapter(AppConfig config ):base(config) {}

        /// <inheritdoc />
        public Resp<string> GetOauthUrl(string redirectUrl, string state,
            OauthClientType type)
        {
            var url = GetAuthorizeUrl(redirectUrl, state,(AuthClientType)type);
            return new Resp<string>(url);
        }

      
        /// <inheritdoc />
        public async Task<Resp<OauthAccessTokenMo>> GetOauthTokenAsync(string code, string state)
        {
            return (await GetOauthAccessTokenAsync(code)).ConvertToComMo();
        }
        
        /// <inheritdoc />
        public async Task<Resp<OauthUser>> GetOauthUserAsync(string accessToken, string appUserId)
        {
            return (await GetWXOauthUserInfoAsync(accessToken, appUserId)).ConvertToComMo();
        }
    }
}