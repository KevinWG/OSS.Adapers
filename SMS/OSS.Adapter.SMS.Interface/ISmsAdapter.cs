#region Copyright (C) 2016 Kevin (OSS开源系列) 公众号：osscore

/***************************************************************************
*　　	文件功能描述：基础类库 - 短信插件接口
*
*　　	创建人： Kevin
*       创建人Email：1985088337@qq.com       
*    	创建日期： 2017-5-31
*       
*****************************************************************************/

#endregion

using System.Threading.Tasks;
using OSS.Adapter.SMS.Interface.Mos;

namespace OSS.Adapter.SMS.Interface
{
    /// <summary>
    ///     短信插件接口
    /// </summary>
    public interface ISmsAdapter
    {
        /// <summary>
        ///  发送短信消息
        /// </summary>
        /// <param name="sendMsg">消息实体</param>
        /// <returns></returns>
        Task<SendSmsResp> Send(SendSmsReq sendMsg);
    }
}
