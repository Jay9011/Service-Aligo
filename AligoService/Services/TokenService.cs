using AligoService.Interface;
using AligoService.Model.ApiResults;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AligoService.Services
{
    /// <summary>
    /// 토큰 서비스 구현
    /// </summary>
    public class TokenService : ApiServiceBase, ITokenService
    {
        private const string TOKEN_CREATE_URL = "https://kakaoapi.aligo.in/akv10/token/create/{0}/{1}/";

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="httpClient">HTTP 클라이언트</param>
        /// <param name="configuration">알리고 설정</param>
        public TokenService(IHttpClient httpClient, IAligoConfiguration configuration)
            : base(httpClient, configuration)
        {
        }

        /// <summary>
        /// 토큰을 생성합니다
        /// </summary>
        /// <param name="expiryValue">만료 값</param>
        /// <param name="expiryUnit">만료 단위 (s: 초, m: 분, h: 시간, d: 일)</param>
        /// <returns>토큰 생성 결과</returns>
        public async Task<TokenResult> CreateTokenAsync(int expiryValue = 30, string expiryUnit = "s")
        {
            var url = string.Format(TOKEN_CREATE_URL, expiryValue, expiryUnit);
            var parameters = new Dictionary<string, string>
            {
                ["apikey"] = Configuration.ApiKey,
                ["userid"] = Configuration.UserId
            };

            return await SendRequestAsync<TokenResult>(url, parameters);
        }
    }
}
