using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AligoService.Model.ApiResults;
using AligoService.Model.Messages;

namespace AligoService.Interface
{
    /// <summary>
    /// 알림톡 메시지 전송 관련 작업을 처리하는 인터페이스
    /// </summary>
    public interface IMessageService
    {
        /// <summary>
        /// 알림톡 메시지를 전송합니다
        /// </summary>
        /// <param name="request">알림톡 전송 요청</param>
        /// <returns>알림톡 전송 결과</returns>
        Task<SendResult> SendMessageAsync(SendMessageRequest request);

        /// <summary>
        /// 전송 내역을 조회합니다
        /// </summary>
        /// <param name="request">전송 내역 조회 요청</param>
        /// <returns>전송 내역 조회 결과</returns>
        Task<MessageHistoryResult> GetMessageHistoryAsync(MessageHistoryRequest request);

        /// <summary>
        /// 전송 상세 내역을 조회합니다
        /// </summary>
        /// <param name="request">전송 상세 내역 조회 요청</param>
        /// <returns>전송 상세 내역 조회 결과</returns>
        Task<MessageDetailResult> GetMessageDetailAsync(MessageDetailRequest request);

        /// <summary>
        /// 예약된 메시지를 취소합니다
        /// </summary>
        /// <param name="messageId">메시지 고유 ID</param>
        /// <returns>메시지 취소 결과</returns>
        Task<ApiResult> CancelMessageAsync(string messageId);

        /// <summary>
        /// 발송 가능 건수를 조회합니다
        /// </summary>
        /// <returns>발송 가능 건수 조회 결과</returns>
        Task<BalanceResult> GetBalanceAsync();
    }
}
