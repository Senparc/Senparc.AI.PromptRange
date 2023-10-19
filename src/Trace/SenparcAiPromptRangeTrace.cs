﻿#region Apache License Version 2.0
/*----------------------------------------------------------------

Copyright 2023 Jeffrey Su & Suzhou Senparc Network Technology Co.,Ltd.

Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file
except in compliance with the License. You may obtain a copy of the License at

http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software distributed under the
License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
either express or implied. See the License for the specific language governing permissions
and limitations under the License.

Detail: https://github.com/JeffreySu/WeiXinMPSDK/blob/master/license.md

----------------------------------------------------------------*/
#endregion Apache License Version 2.0

/*----------------------------------------------------------------
    Copyright (C) 2023 Senparc
    
    文件名：SenparcAiTrace.cs
    文件功能描述：跟踪日志相关
    
----------------------------------------------------------------*/

using Senparc.AI.PromptRange.Exceptions;
using Senparc.AI.Trace;
using Senparc.CO2NET.Extensions;
using Senparc.CO2NET.Trace;
using System;
using System.IO;

namespace Senparc.AI.PromptRange.Trace
{
    /// <summary>
    /// 微信日志跟踪
    /// </summary>
    public class SenparcAiPromptRangeTrace : SenparcAiTrace
    {
        /// <summary>
        /// 记录WeixinException日志时需要执行的任务
        /// </summary>
        public static Action<SenparcAiPromptRangeException> OnSenparcAiExceptionFunc;

        /// <summary>
        /// 记录系统日志
        /// </summary>
        /// <param name="messageFormat"></param>
        /// <param name="param"></param>
        public static void Log(string messageFormat, params object[] param)
        {
            SenparcTrace.Log(messageFormat.FormatWith(param));
        }

        /// <summary>
        /// API请求日志（接收结果）
        /// </summary>
        /// <param name="url"></param>
        /// <param name="stream"></param>
        public static void SendApiLog(string url, Stream stream)
        {
            stream.Seek(0, SeekOrigin.Begin);
            using (var sr = new StreamReader(stream))
            {
                SenparcTrace.SendApiLog(url, sr.ReadToEnd());
            }
        }

        #region SenparcAiException 相关日志

        /// <summary>
        /// SenparcAiException 日志
        /// </summary>
        /// <param name="ex"></param>
        public static void PromptRangeExceptionLog(SenparcAiPromptRangeException ex)
        {
            SenparcAiTrace.SenparcAiExceptionLog(ex);
        }

        #endregion
    }
}
