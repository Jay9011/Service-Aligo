using AligoService.Interface;
using AligoService.Model.ApiResults;
using AligoService.Model.Profiles;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AligoService.Services
{
    /// <summary>
    /// 발신프로필 서비스 구현
    /// </summary>
    public class ProfileService : ApiServiceBase, IProfileService
    {
        private const string PROFILE_AUTH_URL = "https://kakaoapi.aligo.in/akv10/profile/auth/";
        private const string PROFILE_ADD_URL = "https://kakaoapi.aligo.in/akv10/profile/add/";
        private const string PROFILE_LIST_URL = "https://kakaoapi.aligo.in/akv10/profile/list/";
        private const string CATEGORY_URL = "https://kakaoapi.aligo.in/akv10/category/";

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="httpClient">HTTP 클라이언트</param>
        /// <param name="configuration">알리고 설정</param>
        /// <param name="tokenService">토큰 서비스</param>
        public ProfileService(IHttpClient httpClient, IAligoConfiguration configuration, ITokenService tokenService)
            : base(httpClient, configuration, tokenService)
        {
        }

        /// <summary>
        /// 발신프로필 인증을 요청합니다
        /// </summary>
        /// <param name="request">발신프로필 인증 요청</param>
        /// <returns>발신프로필 인증 결과</returns>
        public async Task<ApiResult> AuthenticateProfileAsync(AuthenticateProfileRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (string.IsNullOrEmpty(request.PlusId))
            {
                throw new ArgumentException("PlusId is required", nameof(request));
            }

            if (string.IsNullOrEmpty(request.PhoneNumber))
            {
                throw new ArgumentException("PhoneNumber is required", nameof(request));
            }

            var parameters = await CreateBaseParametersAsync();
            parameters["plusid"] = request.PlusId;
            parameters["phonenumber"] = request.PhoneNumber;

            return await SendRequestAsync<ApiResult>(PROFILE_AUTH_URL, parameters);
        }

        /// <summary>
        /// 발신프로필을 등록합니다
        /// </summary>
        /// <param name="request">발신프로필 등록 요청</param>
        /// <returns>발신프로필 등록 결과</returns>
        public async Task<ProfileResult> AddProfileAsync(AddProfileRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (string.IsNullOrEmpty(request.PlusId))
            {
                throw new ArgumentException("PlusId is required", nameof(request));
            }

            if (string.IsNullOrEmpty(request.PhoneNumber))
            {
                throw new ArgumentException("PhoneNumber is required", nameof(request));
            }

            if (string.IsNullOrEmpty(request.AuthNumber))
            {
                throw new ArgumentException("AuthNumber is required", nameof(request));
            }

            if (string.IsNullOrEmpty(request.CategoryCode))
            {
                throw new ArgumentException("CategoryCode is required", nameof(request));
            }

            var parameters = await CreateBaseParametersAsync();
            parameters["plusid"] = request.PlusId;
            parameters["phonenumber"] = request.PhoneNumber;
            parameters["authnum"] = request.AuthNumber;
            parameters["categorycode"] = request.CategoryCode;

            return await SendRequestAsync<ProfileResult>(PROFILE_ADD_URL, parameters);
        }

        /// <summary>
        /// 발신프로필 목록을 가져옵니다
        /// </summary>
        /// <param name="plusId">플러스친구 아이디 (선택적)</param>
        /// <returns>발신프로필 목록 결과</returns>
        public async Task<ProfileListResult> GetProfilesAsync(string plusId = null)
        {
            var parameters = await CreateBaseParametersAsync();

            if (!string.IsNullOrEmpty(plusId))
            {
                parameters["plusid"] = plusId;
            }

            if (!string.IsNullOrEmpty(Configuration.SenderKey))
            {
                parameters["senderkey"] = Configuration.SenderKey;
            }

            return await SendRequestAsync<ProfileListResult>(PROFILE_LIST_URL, parameters);
        }

        /// <summary>
        /// 카테고리 목록을 가져옵니다
        /// </summary>
        /// <returns>카테고리 목록 결과</returns>
        public async Task<CategoryResult> GetCategoriesAsync()
        {
            var parameters = await CreateBaseParametersAsync();
            return await SendRequestAsync<CategoryResult>(CATEGORY_URL, parameters);
        }
    }
}
