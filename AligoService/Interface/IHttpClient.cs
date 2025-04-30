using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AligoService.Interface
{
    /// <summary>
    /// HTTP 요청과 응답 처리를 위한 인터페이스
    /// </summary>
    public interface IHttpClient
    {
        /// <summary>
        /// POST 요청을 비동기적으로 보냅니다
        /// </summary>
        /// <param name="url">요청 URL</param>
        /// <param name="content">전송할 콘텐츠</param>
        /// <returns>응답 문자열</returns>
        Task<string> PostAsync(string url, HttpContent content);
    }
}
