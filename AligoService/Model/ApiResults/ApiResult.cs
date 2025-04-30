using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace AligoService.Model.ApiResults
{
    /// <summary>
    /// API 응답 기본 결과
    /// </summary>
    public class ApiResult
    {
        /// <summary>
        /// 결과 코드 (0: 성공)
        /// </summary>
        [JsonProperty("code")]
        public int Code { get; set; }

        /// <summary>
        /// 결과 메시지
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// 요청 성공 여부
        /// </summary>
        [JsonIgnore]
        public bool Success => Code == 0;
    }
}
