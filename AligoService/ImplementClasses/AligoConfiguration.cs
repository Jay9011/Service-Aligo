using AligoService.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace AligoService.ImplementClasses
{
    /// <summary>
    /// 알리고 서비스의 API 설정을 관리하는 구현 클래스
    /// </summary>
    public class AligoConfiguration : IAligoConfiguration
    {
        /// <summary>
        /// API 키
        /// </summary>
        public string ApiKey { get; }

        /// <summary>
        /// 사용자 아이디
        /// </summary>
        public string UserId { get; }

        /// <summary>
        /// 발신프로필 키
        /// </summary>
        public string SenderKey { get; }

        /// <summary>
        /// 기본 발신자 전화번호
        /// </summary>
        public string DefaultSender { get; }

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="apiKey">API 키</param>
        /// <param name="userId">사용자 아이디</param>
        /// <param name="senderKey">발신프로필 키</param>
        /// <param name="defaultSender">기본 발신자 전화번호</param>
        public AligoConfiguration(string apiKey, string userId, string senderKey = null, string defaultSender = null)
        {
            ApiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey));
            UserId = userId ?? throw new ArgumentNullException(nameof(userId));
            SenderKey = senderKey;
            DefaultSender = defaultSender;
        }
    }
}
