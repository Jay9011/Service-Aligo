using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AligoService.Model.ApiResults
{
    /// <summary>
    /// 발송 가능 건수 결과
    /// </summary>
    public class BalanceResult : ApiResult
    {
        /// <summary>
        /// 발송 가능 건수 데이터
        /// </summary>
        [JsonProperty("list")]
        public BalanceData Data { get; set; }
    }
}
