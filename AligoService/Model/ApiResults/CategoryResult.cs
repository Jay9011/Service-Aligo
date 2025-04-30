using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using AligoService.Model.Categories;

namespace AligoService.Model.ApiResults
{
    /// <summary>
    /// 카테고리 결과
    /// </summary>
    public class CategoryResult : ApiResult
    {
        /// <summary>
        /// 카테고리 데이터
        /// </summary>
        [JsonProperty("data")]
        public CategoryData Data { get; set; }
    }
}
