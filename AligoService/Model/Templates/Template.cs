using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AligoService.Model.Templates
{
    /// <summary>
    /// 템플릿 정보
    /// </summary>
    public class Template
    {
        /// <summary>
        /// 템플릿 내용
        /// </summary>
        [JsonProperty("templtContent")]
        public string Content { get; set; }

        /// <summary>
        /// 템플릿 이름
        /// </summary>
        [JsonProperty("templtName")]
        public string Name { get; set; }

        /// <summary>
        /// 템플릿 상태
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// 검수 상태
        /// </summary>
        [JsonProperty("inspStatus")]
        public string InspectionStatus { get; set; }

        /// <summary>
        /// 발신 프로필 키
        /// </summary>
        [JsonProperty("senderKey")]
        public string SenderKey { get; set; }

        /// <summary>
        /// 버튼 목록
        /// </summary>
        [JsonProperty("buttons")]
        public List<TemplateButton> Buttons { get; set; } = new List<TemplateButton>();

        /// <summary>
        /// 생성 일시
        /// </summary>
        [JsonProperty("cdate")]
        public string CreatedDate { get; set; }

        /// <summary>
        /// 템플릿 코드
        /// </summary>
        [JsonProperty("templtCode")]
        public string Code { get; set; }

        /// <summary>
        /// 코멘트 목록
        /// </summary>
        [JsonProperty("comments")]
        public List<string> Comments { get; set; } = new List<string>();
    }
}
