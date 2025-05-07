using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;

namespace AligoService.Model.ApiResults
{
    /// <summary>
    /// 전송 결과
    /// </summary>
    public class SendResult : ApiResult
    {
        /// <summary>
        /// 전송 정보
        /// </summary>
        [JsonProperty("info")]
        public JObject Info { get; set; } = new JObject();

        [JsonIgnore]
        public SendInfo SendInfo
        {
            get
            {
                if (Info == null) return null;

                return new SendInfo
                {
                    Type = Info["type"]?.Value<string>(),
                    MessageId = Info["mid"]?.Value<string>(),
                    Current = Info["current"]?.Value<int>() ?? 0,
                    Unit = Info["unit"]?.Value<int>() ?? 0,
                    Total = Info["total"]?.Value<int>() ?? 0,
                    SuccessCount = Info["scnt"]?.Value<int>() ?? 0,
                    FailCount = Info["fcnt"]?.Value<int>() ?? 0
                };
            }
        }
    }
}
