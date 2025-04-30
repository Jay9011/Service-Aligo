using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

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
        public List<SendInfo> Info { get; set; } = new List<SendInfo>();
    }
}
