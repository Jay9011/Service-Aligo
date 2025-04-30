using System;
using System.Collections.Generic;
using System.Text;

namespace AligoService.Interface
{
    /// <summary>
    /// 알리고 서비스의 API 설정을 관리하는 인터페이스
    /// </summary>
    public interface IAligoConfiguration
    {
        /// <summary>
        /// API 키
        /// </summary>
        string ApiKey { get; }

        /// <summary>
        /// 사용자 아이디
        /// </summary>
        string UserId { get; }

        /// <summary>
        /// 발신프로필 키
        /// </summary>
        string SenderKey { get; }

        /// <summary>
        /// 기본 발신자 전화번호
        /// </summary>
        string DefaultSender { get; }
    }
}
