using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AligoService.Model.ApiResults
{
    /// <summary>
    /// 토큰 생성 결과
    /// </summary>
    public class TokenResult : ApiResult
    {
        /// <summary>
        /// 토큰 문자열
        /// </summary>
        [JsonProperty("token")]
        public string Token { get; set; }

        /// <summary>
        /// URL 인코딩된 토큰 문자열
        /// </summary>
        [JsonProperty("urlencode")]
        public string UrlEncodedToken { get; set; }
    }
}
