using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AligoService.Model.Profiles
{
    /// <summary>
    /// 발신프로필 정보
    /// </summary>
    public class Profile
    {
        /// <summary>
        /// 발신 프로필 키
        /// </summary>
        [JsonProperty("senderKey")]
        public string SenderKey { get; set; }

        /// <summary>
        /// 라이센스 URL
        /// </summary>
        [JsonProperty("license")]
        public string License { get; set; }

        /// <summary>
        /// 카테고리 코드
        /// </summary>
        [JsonProperty("catCode")]
        public string CategoryCode { get; set; }

        /// <summary>
        /// 알림톡 사용 여부
        /// </summary>
        [JsonProperty("alimUseYn")]
        public bool AlimUseYn { get; set; }

        /// <summary>
        /// 생성 일시
        /// </summary>
        [JsonProperty("cdate")]
        public string CreatedDate { get; set; }

        /// <summary>
        /// 이름
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 프로필 상태
        /// </summary>
        [JsonProperty("profileStat")]
        public string ProfileStatus { get; set; }

        /// <summary>
        /// 라이센스 번호
        /// </summary>
        [JsonProperty("licenseNum")]
        public string LicenseNumber { get; set; }

        /// <summary>
        /// 수정 일시
        /// </summary>
        [JsonProperty("udate")]
        public string UpdatedDate { get; set; }

        /// <summary>
        /// UUID
        /// </summary>
        [JsonProperty("uuid")]
        public string Uuid { get; set; }

        /// <summary>
        /// 상태
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
