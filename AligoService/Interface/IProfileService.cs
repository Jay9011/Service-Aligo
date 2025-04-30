using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AligoService.Model.ApiResults;
using AligoService.Model.Profiles;

namespace AligoService.Interface
{
    /// <summary>
    /// 발신프로필 관련 작업을 처리하는 인터페이스
    /// </summary>
    public interface IProfileService
    {
        /// <summary>
        /// 발신프로필 인증을 요청합니다
        /// </summary>
        /// <param name="request">발신프로필 인증 요청</param>
        /// <returns>발신프로필 인증 결과</returns>
        Task<ApiResult> AuthenticateProfileAsync(AuthenticateProfileRequest request);

        /// <summary>
        /// 발신프로필을 등록합니다
        /// </summary>
        /// <param name="request">발신프로필 등록 요청</param>
        /// <returns>발신프로필 등록 결과</returns>
        Task<ProfileResult> AddProfileAsync(AddProfileRequest request);

        /// <summary>
        /// 발신프로필 목록을 가져옵니다
        /// </summary>
        /// <param name="plusId">플러스친구 아이디 (선택적)</param>
        /// <returns>발신프로필 목록 결과</returns>
        Task<ProfileListResult> GetProfilesAsync(string plusId = null);

        /// <summary>
        /// 카테고리 목록을 가져옵니다
        /// </summary>
        /// <returns>카테고리 목록 결과</returns>
        Task<CategoryResult> GetCategoriesAsync();
    }
}
