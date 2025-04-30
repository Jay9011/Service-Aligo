using AligoService.Interface;
using AligoService.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace AligoService.ImplementClasses
{
    /// <summary>
    /// 알리고 클라이언트 구현
    /// </summary>
    public class AligoClient : IAligoClient
    {
        /// <summary>
        /// 토큰 서비스
        /// </summary>
        public ITokenService TokenService { get; }

        /// <summary>
        /// 템플릿 서비스
        /// </summary>
        public ITemplateService TemplateService { get; }

        /// <summary>
        /// 발신프로필 서비스
        /// </summary>
        public IProfileService ProfileService { get; }

        /// <summary>
        /// 메시지 서비스
        /// </summary>
        public IMessageService MessageService { get; }

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="httpClient">HTTP 클라이언트</param>
        /// <param name="configuration">알리고 설정</param>
        public AligoClient(IHttpClient httpClient, IAligoConfiguration configuration)
        {
            if (httpClient == null)
            {
                throw new ArgumentNullException(nameof(httpClient));
            }

            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            TokenService = new TokenService(httpClient, configuration);
            TemplateService = new TemplateService(httpClient, configuration, TokenService);
            ProfileService = new ProfileService(httpClient, configuration, TokenService);
            MessageService = new MessageService(httpClient, configuration, TokenService);
        }
    }
}
