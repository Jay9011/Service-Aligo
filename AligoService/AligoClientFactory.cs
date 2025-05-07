using AligoService.ImplementClasses;
using AligoService.Interface;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace AligoService
{
    /// <summary>
    /// 알리고 클라이언트 팩토리
    /// </summary>
    public static class AligoClientFactory
    {
        /// <summary>
        /// 알리고 클라이언트를 생성합니다
        /// </summary>
        /// <param name="apiKey">API 키</param>
        /// <param name="userId">사용자 아이디</param>
        /// <param name="senderKey">발신프로필 키 (선택적)</param>
        /// <param name="defaultSender">기본 발신자 전화번호 (선택적)</param>
        /// <param name="httpClient">HTTP 클라이언트 (선택적)</param>
        /// <returns>알리고 클라이언트</returns>
        public static IAligoClient Create(
            string apiKey,
            string userId,
            string senderKey = null,
            string defaultSender = null,
            HttpClient httpClient = null)
        {
            var configuration = new AligoConfiguration(apiKey, userId, senderKey, defaultSender);
            var httpClientWrapper = new AligoHttpClient(httpClient);
            return new AligoClient(httpClientWrapper, configuration);
        }

        /// <summary>
        /// 알리고 클라이언트를 Configuration을 사용해 생성합니다
        /// </summary>
        /// <param name="configuration">알리고 계정 설정</param>
        /// <param name="httpClient">HTTP 클라이언트 (선택적)</param>
        /// <returns>알리고 클라이언트</returns>
        /// <exception cref="ArgumentNullException">설정이 잘못 됨</exception>
        public static IAligoClient Create(IAligoConfiguration configuration, HttpClient httpClient = null)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }
            var httpClientWrapper = new AligoHttpClient(httpClient);
            return new AligoClient(httpClientWrapper, configuration);
        }
    }
}
