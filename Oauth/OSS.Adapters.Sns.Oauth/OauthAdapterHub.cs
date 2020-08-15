using System;
using OSS.Adapters.Sns.Oauth.Mos.Enums;
using OSS.Adapters.Sns.Oauth.WX;
using OSS.Common.BasicImpls;
using OSS.Common.BasicMos;

namespace OSS.Adapters.Sns.Oauth
{
    /// <summary>
    ///  Oauth 对接适配中心
    ///     todo 待扩展其他平台
    /// </summary>
    public static class OauthAdapterHub
    {
        /// <summary>
        ///     获取处理Adapter
        /// </summary>
        /// <param name="plat">平台类型</param>
        /// <param name="config">对应配置</param>
        /// <returns></returns>
        public static IOauthAdapter GetAdapter(OauthPlatform plat,AppConfig config=null)
        {
            switch (plat)
            {
                case OauthPlatform.WeChat:
                    return GetWeChatAdapter(config);
            }
            throw new ArgumentException("未实现的Oauth授权平台");
        }

        public static IOauthAdapter GetWeChatAdapter(AppConfig config=null)
        {
            var wxAdapter = SingleInstance<WXOauthAdapter>.Instance;
            if (config != null)
            {
                wxAdapter.SetContextConfig(config);
            }
            return wxAdapter;
        }





    }
}
