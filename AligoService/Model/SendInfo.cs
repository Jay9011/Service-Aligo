using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AligoService.Model
{
    /// <summary>
    /// 전송 정보
    /// </summary>
    public class SendInfo
    {
        /// <summary>
        /// 메시지 타입
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// 메시지 ID
        /// </summary>
        [JsonProperty("mid")]
        public string MessageId { get; set; }

        /// <summary>
        /// 현재 값
        /// </summary>
        [JsonProperty("current")]
        public int Current { get; set; }

        /// <summary>
        /// 단위 값
        /// </summary>
        [JsonProperty("unit")]
        public int Unit { get; set; }

        /// <summary>
        /// 총 값
        /// </summary>
        [JsonProperty("total")]
        public int Total { get; set; }

        /// <summary>
        /// 성공 건수
        /// </summary>
        [JsonProperty("scnt")]
        public int SuccessCount { get; set; }

        /// <summary>
        /// 실패 건수
        /// </summary>
        [JsonProperty("fcnt")]
        public int FailCount { get; set; }
    }
}
