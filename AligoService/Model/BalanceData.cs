using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AligoService.Model
{
    /// <summary>
    /// 발송 가능 건수 데이터
    /// </summary>
    public class BalanceData
    {
        /// <summary>
        /// SMS 발송 가능 건수
        /// </summary>
        [JsonProperty("SMS_CNT")]
        public int SmsCount { get; set; }

        /// <summary>
        /// LMS 발송 가능 건수
        /// </summary>
        [JsonProperty("LMS_CNT")]
        public int LmsCount { get; set; }

        /// <summary>
        /// MMS 발송 가능 건수
        /// </summary>
        [JsonProperty("MMS_CNT")]
        public int MmsCount { get; set; }

        /// <summary>
        /// 알림톡 발송 가능 건수
        /// </summary>
        [JsonProperty("ALT_CNT")]
        public int AltCount { get; set; }
    }
}
