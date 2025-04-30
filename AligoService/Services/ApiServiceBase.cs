using AligoService.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AligoService.Services
{
    /// <summary>
    /// API 서비스의 기본 구현을 제공하는 추상 클래스
    /// </summary>
    public abstract class ApiServiceBase
    {
        /// <summary>
        /// HTTP 클라이언트
        /// </summary>
        protected readonly IHttpClient HttpClient;

        /// <summary>
        /// 알리고 설정
        /// </summary>
        protected readonly IAligoConfiguration Configuration;

        /// <summary>
        /// 토큰 서비스
        /// </summary>
        protected readonly ITokenService TokenService;

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="httpClient">HTTP 클라이언트</param>
        /// <param name="configuration">알리고 설정</param>
        /// <param name="tokenService">토큰 서비스 (토큰 서비스 자신이 아닌 경우)</param>
        protected ApiServiceBase(IHttpClient httpClient, IAligoConfiguration configuration, ITokenService tokenService = null)
        {
            HttpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            TokenService = tokenService;
        }

        /// <summary>
        /// 폼 콘텐츠를 생성합니다
        /// </summary>
        /// <param name="parameters">파라미터 사전</param>
        /// <returns>폼 콘텐츠</returns>
        protected FormUrlEncodedContent CreateFormContent(Dictionary<string, string> parameters)
        {
            return new FormUrlEncodedContent(parameters);
        }

        /// <summary>
        /// API 요청을 비동기적으로 보냅니다
        /// </summary>
        /// <typeparam name="T">응답 타입</typeparam>
        /// <param name="url">요청 URL</param>
        /// <param name="parameters">요청 파라미터</param>
        /// <returns>응답 객체</returns>
        protected async Task<T> SendRequestAsync<T>(string url, Dictionary<string, string> parameters) where T : class
        {
            var content = CreateFormContent(parameters);
            var response = await HttpClient.PostAsync(url, content);
            return JsonConvert.DeserializeObject<T>(response);
        }

        /// <summary>
        /// 토큰을 가져옵니다
        /// </summary>
        /// <returns>토큰 문자열</returns>
        protected async Task<string> GetTokenAsync()
        {
            if (TokenService == null)
            {
                throw new InvalidOperationException("TokenService is not available");
            }

            var tokenResult = await TokenService.CreateTokenAsync();
            if (!tokenResult.Success)
            {
                throw new Exception($"Failed to create token: {tokenResult.Message}");
            }

            return tokenResult.UrlEncodedToken;
        }

        /// <summary>
        /// 기본 파라미터를 생성합니다
        /// </summary>
        /// <param name="token">토큰 (null인 경우 동적으로 가져옴)</param>
        /// <returns>파라미터 사전</returns>
        protected async Task<Dictionary<string, string>> CreateBaseParametersAsync(string token = null)
        {
            var parameters = new Dictionary<string, string>
            {
                ["apikey"] = Configuration.ApiKey,
                ["userid"] = Configuration.UserId
            };

            if (token == null && TokenService != null)
            {
                token = await GetTokenAsync();
            }

            if (!string.IsNullOrEmpty(token))
            {
                parameters["token"] = token;
            }

            return parameters;
        }
    }
}
