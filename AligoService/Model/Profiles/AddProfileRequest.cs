using System;
using System.Collections.Generic;
using System.Text;

namespace AligoService.Model.Profiles
{
    /// <summary>
    /// 발신프로필 등록 요청
    /// </summary>
    public class AddProfileRequest : AuthenticateProfileRequest
    {
        /// <summary>
        /// 인증번호
        /// </summary>
        public string AuthNumber { get; set; }

        /// <summary>
        /// 카테고리 코드
        /// </summary>
        public string CategoryCode { get; set; }
    }
}
