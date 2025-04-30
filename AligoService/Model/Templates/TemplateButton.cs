using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AligoService.Model.Templates
{
    /// <summary>
    /// 템플릿 버튼 정보
    /// </summary>
    public class TemplateButton
    {
        /// <summary>
        /// 버튼 순서
        /// </summary>
        [JsonProperty("ordering")]
        public string Ordering { get; set; }

        /// <summary>
        /// 버튼 이름
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 링크 타입
        /// </summary>
        [JsonProperty("linkType")]
        public string LinkType { get; set; }

        /// <summary>
        /// 링크 타입 이름
        /// </summary>
        [JsonProperty("linkTypeName")]
        public string LinkTypeName { get; set; }

        /// <summary>
        /// 모바일 링크
        /// </summary>
        [JsonProperty("linkMo")]
        public string MobileLink { get; set; }

        /// <summary>
        /// PC 링크
        /// </summary>
        [JsonProperty("linkPc")]
        public string PcLink { get; set; }

        /// <summary>
        /// iOS 링크
        /// </summary>
        [JsonProperty("linkIos")]
        public string IosLink { get; set; }

        /// <summary>
        /// Android 링크
        /// </summary>
        [JsonProperty("linkAnd")]
        public string AndroidLink { get; set; }
    }
}
