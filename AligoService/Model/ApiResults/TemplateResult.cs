using AligoService.Model.Templates;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AligoService.Model.ApiResults
{
    /// <summary>
    /// 템플릿 결과
    /// </summary>
    public class TemplateResult : ApiResult
    {
        /// <summary>
        /// 템플릿 데이터
        /// </summary>
        [JsonProperty("data")]
        public Template Template { get; set; }
    }
}
