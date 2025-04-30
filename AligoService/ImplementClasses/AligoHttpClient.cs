using AligoService.Interface;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AligoService.ImplementClasses
{
    /// <summary>
    /// HTTP 클라이언트 구현
    /// </summary>
    public class AligoHttpClient : IHttpClient
    {
        private readonly HttpClient _httpClient;

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="httpClient">HTTP 클라이언트</param>
        public AligoHttpClient(HttpClient httpClient = null)
        {
            _httpClient = httpClient ?? new HttpClient();
        }

        /// <summary>
        /// POST 요청을 비동기적으로 보냅니다
        /// </summary>
        /// <param name="url">요청 URL</param>
        /// <param name="content">전송할 콘텐츠</param>
        /// <returns>응답 문자열</returns>
        public async Task<string> PostAsync(string url, HttpContent content)
        {
            var response = await _httpClient.PostAsync(url, content);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
