using System;
using System.Collections.Generic;
using System.Text;

namespace AligoService.Model.Profiles
{
    /// <summary>
    /// 발신프로필 인증 요청
    /// </summary>
    public class AuthenticateProfileRequest
    {
        /// <summary>
        /// 플러스친구 아이디 (@포함)
        /// </summary>
        public string PlusId { get; set; }

        /// <summary>
        /// 관리자 전화번호
        /// </summary>
        public string PhoneNumber { get; set; }
    }
}
