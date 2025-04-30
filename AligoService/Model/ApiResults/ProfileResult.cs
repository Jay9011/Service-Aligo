using AligoService.Model.Profiles;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AligoService.Model.ApiResults
{
    /// <summary>
    /// 프로필 결과
    /// </summary>
    public class ProfileResult : ApiResult
    {
        /// <summary>
        /// 프로필 데이터
        /// </summary>
        [JsonProperty("data")]
        public List<Profile> Profiles { get; set; } = new List<Profile>();
    }
}
