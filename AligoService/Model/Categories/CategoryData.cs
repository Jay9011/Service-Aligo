using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AligoService.Model.Categories
{
    /// <summary>
    /// 카테고리 데이터
    /// </summary>
    public class CategoryData
    {
        /// <summary>
        /// 1차 비즈니스 타입
        /// </summary>
        [JsonProperty("firstBusinessType")]
        public List<CategoryItem> FirstBusinessType { get; set; } = new List<CategoryItem>();

        /// <summary>
        /// 2차 비즈니스 타입
        /// </summary>
        [JsonProperty("secondBusinessType")]
        public List<CategoryItem> SecondBusinessType { get; set; } = new List<CategoryItem>();

        /// <summary>
        /// 3차 비즈니스 타입
        /// </summary>
        [JsonProperty("thirdBusinessType")]
        public List<CategoryItem> ThirdBusinessType { get; set; } = new List<CategoryItem>();
    }
}
