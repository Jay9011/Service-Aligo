using AligoService.Model.Profiles;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AligoService.Model.ApiResults
{
    /// <summary>
    /// 프로필 목록 결과
    /// </summary>
    public class ProfileListResult : ApiResult
    {
        /// <summary>
        /// 프로필 목록
        /// </summary>
        [JsonProperty("list")]
        public List<Profile> Profiles { get; set; } = new List<Profile>();
    }
}
