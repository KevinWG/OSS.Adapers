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
using OSS.Common.BasicImpls;
using OSS.Common.BasicMos;
using OSS.Common.BasicMos.Resp;

namespace OSS.Adapter.Oauth.WX
{
    /// <summary>
    ///     微信授权处理类
    /// </summary>
    public class WXOauthAdapter : WXOauthApi, IOauthAdapter
    {
        /// <inheritdoc />
        public WXOauthAdapter() : base(null)
        {

        }

        /// <inheritdoc />
        public WXOauthAdapter(IMetaProvider<AppConfig> configProvider )
            : base(configProvider)
        {

        }

        /// <inheritdoc />
        public Task<StrResp> GetOauthUrl(string redirectUrl, string state,
            OauthClientType type)
        {
            return GetAuthorizeUrl(redirectUrl, state,(AuthClientType)type);
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