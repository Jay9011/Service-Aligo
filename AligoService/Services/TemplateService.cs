using AligoService.Interface;
using AligoService.Model.ApiResults;
using AligoService.Model.Templates;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AligoService.Services
{
    /// <summary>
    /// 템플릿 서비스 구현
    /// </summary>
    public class TemplateService : ApiServiceBase, ITemplateService
    {
        private const string TEMPLATE_LIST_URL = "https://kakaoapi.aligo.in/akv10/template/list/";
        private const string TEMPLATE_ADD_URL = "https://kakaoapi.aligo.in/akv10/template/add/";
        private const string TEMPLATE_MODIFY_URL = "https://kakaoapi.aligo.in/akv10/template/modify/";
        private const string TEMPLATE_DELETE_URL = "https://kakaoapi.aligo.in/akv10/template/del/";
        private const string TEMPLATE_REQUEST_URL = "https://kakaoapi.aligo.in/akv10/template/request/";

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="httpClient">HTTP 클라이언트</param>
        /// <param name="configuration">알리고 설정</param>
        /// <param name="tokenService">토큰 서비스</param>
        public TemplateService(IHttpClient httpClient, IAligoConfiguration configuration, ITokenService tokenService)
            : base(httpClient, configuration, tokenService)
        {
        }

        /// <summary>
        /// 템플릿 목록을 가져옵니다
        /// </summary>
        /// <param name="templateCode">특정 템플릿 코드 (선택적)</param>
        /// <returns>템플릿 목록 결과</returns>
        public async Task<TemplateListResult> GetTemplatesAsync(string templateCode = null)
        {
            var parameters = await CreateBaseParametersAsync();

            if (!string.IsNullOrEmpty(Configuration.SenderKey))
            {
                parameters["senderkey"] = Configuration.SenderKey;
            }

            if (!string.IsNullOrEmpty(templateCode))
            {
                parameters["tpl_code"] = templateCode;
            }

            return await SendRequestAsync<TemplateListResult>(TEMPLATE_LIST_URL, parameters);
        }

        /// <summary>
        /// 템플릿을 추가합니다
        /// </summary>
        /// <param name="request">템플릿 추가 요청</param>
        /// <returns>템플릿 추가 결과</returns>
        public async Task<TemplateResult> AddTemplateAsync(AddTemplateRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var parameters = await CreateBaseParametersAsync();

            if (string.IsNullOrEmpty(Configuration.SenderKey))
            {
                throw new InvalidOperationException("SenderKey is required for adding a template");
            }

            parameters["senderkey"] = Configuration.SenderKey;
            parameters["tpl_name"] = request.Name;
            parameters["tpl_content"] = request.Content;

            if (!string.IsNullOrEmpty(request.ButtonJson))
            {
                parameters["tpl_button"] = request.ButtonJson;
            }

            return await SendRequestAsync<TemplateResult>(TEMPLATE_ADD_URL, parameters);
        }

        /// <summary>
        /// 템플릿을 수정합니다
        /// </summary>
        /// <param name="request">템플릿 수정 요청</param>
        /// <returns>템플릿 수정 결과</returns>
        public async Task<TemplateResult> ModifyTemplateAsync(ModifyTemplateRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (string.IsNullOrEmpty(request.TemplateCode))
            {
                throw new ArgumentException("TemplateCode is required", nameof(request));
            }

            var parameters = await CreateBaseParametersAsync();

            if (string.IsNullOrEmpty(Configuration.SenderKey))
            {
                throw new InvalidOperationException("SenderKey is required for modifying a template");
            }

            parameters["senderkey"] = Configuration.SenderKey;
            parameters["tpl_code"] = request.TemplateCode;
            parameters["tpl_name"] = request.Name;
            parameters["tpl_content"] = request.Content;

            if (!string.IsNullOrEmpty(request.ButtonJson))
            {
                parameters["tpl_button"] = request.ButtonJson;
            }

            return await SendRequestAsync<TemplateResult>(TEMPLATE_MODIFY_URL, parameters);
        }

        /// <summary>
        /// 템플릿을 삭제합니다
        /// </summary>
        /// <param name="templateCode">템플릿 코드</param>
        /// <returns>템플릿 삭제 결과</returns>
        public async Task<ApiResult> DeleteTemplateAsync(string templateCode)
        {
            if (string.IsNullOrEmpty(templateCode))
            {
                throw new ArgumentException("Template code is required", nameof(templateCode));
            }

            var parameters = await CreateBaseParametersAsync();

            if (string.IsNullOrEmpty(Configuration.SenderKey))
            {
                throw new InvalidOperationException("SenderKey is required for deleting a template");
            }

            parameters["senderkey"] = Configuration.SenderKey;
            parameters["tpl_code"] = templateCode;

            return await SendRequestAsync<ApiResult>(TEMPLATE_DELETE_URL, parameters);
        }

        /// <summary>
        /// 템플릿 검수를 요청합니다
        /// </summary>
        /// <param name="templateCode">템플릿 코드</param>
        /// <returns>템플릿 검수 요청 결과</returns>
        public async Task<ApiResult> RequestTemplateReviewAsync(string templateCode)
        {
            if (string.IsNullOrEmpty(templateCode))
            {
                throw new ArgumentException("Template code is required", nameof(templateCode));
            }

            var parameters = await CreateBaseParametersAsync();

            if (string.IsNullOrEmpty(Configuration.SenderKey))
            {
                throw new InvalidOperationException("SenderKey is required for requesting template review");
            }

            parameters["senderkey"] = Configuration.SenderKey;
            parameters["tpl_code"] = templateCode;

            return await SendRequestAsync<ApiResult>(TEMPLATE_REQUEST_URL, parameters);
        }
    }
}
