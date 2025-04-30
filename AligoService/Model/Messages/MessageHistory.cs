using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AligoService.Model.Messages
{
    /// <summary>
    /// 메시지 내역
    /// </summary>
    public class MessageHistory
    {
        /// <summary>
        /// 메시지 ID
        /// </summary>
        [JsonProperty("mid")]
        public string MessageId { get; set; }

        /// <summary>
        /// 메시지 타입
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// 발신자 번호
        /// </summary>
        [JsonProperty("sender")]
        public string Sender { get; set; }

        /// <summary>
        /// 메시지 개수
        /// </summary>
        [JsonProperty("msg_count")]
        public string MessageCount { get; set; }

        /// <summary>
        /// 예약 일시
        /// </summary>
        [JsonProperty("reserve_date")]
        public string ReserveDate { get; set; }

        /// <summary>
        /// 예약 상태
        /// </summary>
        [JsonProperty("reserve_state")]
        public string ReserveState { get; set; }

        /// <summary>
        /// 메시지 본문
        /// </summary>
        [JsonProperty("mbody")]
        public string MessageBody { get; set; }

        /// <summary>
        /// 등록 일시
        /// </summary>
        [JsonProperty("reg_date")]
        public string RegisterDate { get; set; }
    }
}
