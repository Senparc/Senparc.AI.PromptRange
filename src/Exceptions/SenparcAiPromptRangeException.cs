using Senparc.AI.Exceptions;
using Senparc.AI.PromptRange.Trace;
using Senparc.CO2NET.Exceptions;
using Senparc.CO2NET.Trace;
using System;
using System.Collections.Generic;
using System.Text;

namespace Senparc.AI.PromptRange.Exceptions
{
    /// <summary>
    /// SenparcAI 异常
    /// </summary>
    public class SenparcAiPromptRangeException : SenparcAiException
    {
        public string ModelName { get; set; }
        public string EndpointUrl { get; set; }

        public SenparcAiPromptRangeException(string message, bool logged = false) : base(message, logged)
        {
        }

        /// <summary>
        /// WeixinException
        /// </summary>
        /// <param name="message">异常消息</param>
        /// <param name="inner">内部异常信息</param>
        /// <param name="logged">是否已经使用Trace记录日志，如果没有，WeixinException会进行概要记录</param>
        public SenparcAiPromptRangeException(string message, Exception inner, bool logged = false)
            : base(message, inner, true/* 标记为日志已记录 */)
        {
            if (!logged)
            {
                SenparcAiPromptRangeTrace.PromptRangeExceptionLog(this);
            }
        }
    }
}
