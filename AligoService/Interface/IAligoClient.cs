using System;
using System.Collections.Generic;
using System.Text;

namespace AligoService.Interface
{
    /// <summary>
    /// 알리고 알림톡 서비스 클라이언트 인터페이스
    /// </summary>
    public interface IAligoClient
    {
        /// <summary>
        /// 토큰 서비스
        /// </summary>
        ITokenService TokenService { get; }

        /// <summary>
        /// 템플릿 서비스
        /// </summary>
        ITemplateService TemplateService { get; }

        /// <summary>
        /// 발신프로필 서비스
        /// </summary>
        IProfileService ProfileService { get; }

        /// <summary>
        /// 메시지 서비스
        /// </summary>
        IMessageService MessageService { get; }
    }
}
