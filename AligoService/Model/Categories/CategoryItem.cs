using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AligoService.Model.Categories
{
    /// <summary>
    /// 카테고리 항목
    /// </summary>
    public class CategoryItem
    {
        /// <summary>
        /// 부모 코드
        /// </summary>
        [JsonProperty("parentCode")]
        public string ParentCode { get; set; }

        /// <summary>
        /// 코드
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <summary>
        /// 이름
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
