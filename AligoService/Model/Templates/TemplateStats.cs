using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AligoService.Model.Templates
{
    /// <summary>
    /// 템플릿 통계 정보
    /// </summary>
    public class TemplateStats
    {
        /// <summary>
        /// 등록 상태 템플릿 수
        /// </summary>
        [JsonProperty("REG")]
        public int Registered { get; set; }

        /// <summary>
        /// 검수요청 상태 템플릿 수
        /// </summary>
        [JsonProperty("REQ")]
        public int Requested { get; set; }

        /// <summary>
        /// 승인 상태 템플릿 수
        /// </summary>
        [JsonProperty("APR")]
        public int Approved { get; set; }

        /// <summary>
        /// 거부 상태 템플릿 수
        /// </summary>
        [JsonProperty("REJ")]
        public int Rejected { get; set; }
    }
}
