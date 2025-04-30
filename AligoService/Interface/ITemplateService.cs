using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AligoService.Model.ApiResults;
using AligoService.Model.Templates;

namespace AligoService.Interface
{
    /// <summary>
    /// 템플릿 관련 작업을 처리하는 인터페이스
    /// </summary>
    public interface ITemplateService
    {
        /// <summary>
        /// 템플릿 목록을 가져옵니다
        /// </summary>
        /// <param name="templateCode">특정 템플릿 코드 (선택적)</param>
        /// <returns>템플릿 목록 결과</returns>
        Task<TemplateListResult> GetTemplatesAsync(string templateCode = null);

        /// <summary>
        /// 템플릿을 추가합니다
        /// </summary>
        /// <param name="request">템플릿 추가 요청</param>
        /// <returns>템플릿 추가 결과</returns>
        Task<TemplateResult> AddTemplateAsync(AddTemplateRequest request);

        /// <summary>
        /// 템플릿을 수정합니다
        /// </summary>
        /// <param name="request">템플릿 수정 요청</param>
        /// <returns>템플릿 수정 결과</returns>
        Task<TemplateResult> ModifyTemplateAsync(ModifyTemplateRequest request);

        /// <summary>
        /// 템플릿을 삭제합니다
        /// </summary>
        /// <param name="templateCode">템플릿 코드</param>
        /// <returns>템플릿 삭제 결과</returns>
        Task<ApiResult> DeleteTemplateAsync(string templateCode);

        /// <summary>
        /// 템플릿 검수를 요청합니다
        /// </summary>
        /// <param name="templateCode">템플릿 코드</param>
        /// <returns>템플릿 검수 요청 결과</returns>
        Task<ApiResult> RequestTemplateReviewAsync(string templateCode);
    }
}
