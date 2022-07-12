#region Copyright (C) 2017 Kevin (OSS开源实验室) 公众号：osscore

/***************************************************************************
*　　	文件功能描述：OSSCore服务层 —— 授权处理接口
*
*　　	创建人： Kevin
*       创建人Email：1985088337@qq.com
*    	创建日期：2017-10-14
*       
*****************************************************************************/

#endregion

using System.Threading.Tasks;
using OSS.Adapter.Oauth.Interface.Mos;
using OSS.Adapter.Oauth.Interface.Mos.Enums;
using OSS.Common.Resp;

namespace OSS.Adapter.Oauth.Interface
{
    /// <summary>
    ///     授权处理接口
    /// </summary>
    public class NoneOauthAdapter : IOauthAdapter
    {
        private readonly Resp _errResp;

        public NoneOauthAdapter()
        {
            _errResp=new Resp().WithResp(SysRespCodes.NotImplement, "未知Oauth应用平台！");
        }
        public NoneOauthAdapter(Resp errResp)
        {
            _errResp = errResp;
        }

        /// <summary>
        ///     获取授权地址
        /// </summary>
        /// <param name="redirectUrl"></param>
        /// <param name="state"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public virtual Task<StrResp> GetOauthUrl(string redirectUrl, string state,
            OauthClientType type)
        {
            return Task.FromResult(new StrResp().WithResp(_errResp));
        }


        /// <summary>
        ///     通过授权回调code 获取授权用户信息
        /// </summary>
        /// <param name="code"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public virtual  Task<Resp<OauthAccessTokenMo>> GetOauthTokenAsync(string code, string state)
        {
            return Task.FromResult(new Resp<OauthAccessTokenMo>().WithResp(_errResp));
        }


        /// <summary>
        ///     通过授权Token 获取授权用户信息
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="appUserId"></param>
        /// <returns></returns>
        public virtual Task<Resp<OauthUser>> GetOauthUserAsync(string accessToken, string appUserId)
        {
            return Task.FromResult( new Resp<OauthUser>().WithResp(_errResp));
        }
    }
}