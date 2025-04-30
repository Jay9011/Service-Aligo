using AligoService.Model.Templates;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AligoService.Model.ApiResults
{
    /// <summary>
    /// 템플릿 목록 조회 결과
    /// </summary>
    public class TemplateListResult : ApiResult
    {
        /// <summary>
        /// 템플릿 목록
        /// </summary>
        [JsonProperty("list")]
        public List<Template> Templates { get; set; } = new List<Template>();

        /// <summary>
        /// 템플릿 통계 정보
        /// </summary>
        [JsonProperty("info")]
        public TemplateStats Stats { get; set; }
    }
}
