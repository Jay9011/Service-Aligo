using AligoService.Interface;
using AligoService.Model.ApiResults;
using AligoService.Model.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AligoService.Services
{
    /// <summary>
    /// 메시지 서비스 구현
    /// </summary>
    public class MessageService : ApiServiceBase, IMessageService
    {
        private const string SEND_MESSAGE_URL = "https://kakaoapi.aligo.in/akv10/alimtalk/send/";
        private const string MESSAGE_HISTORY_URL = "https://kakaoapi.aligo.in/akv10/history/list/";
        private const string MESSAGE_DETAIL_URL = "https://kakaoapi.aligo.in/akv10/history/detail/";
        private const string CANCEL_MESSAGE_URL = "https://kakaoapi.aligo.in/akv10/cancel/";
        private const string BALANCE_URL = "https://kakaoapi.aligo.in/akv10/heartinfo/";

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="httpClient">HTTP 클라이언트</param>
        /// <param name="configuration">알리고 설정</param>
        /// <param name="tokenService">토큰 서비스</param>
        public MessageService(IHttpClient httpClient, IAligoConfiguration configuration, ITokenService tokenService)
            : base(httpClient, configuration, tokenService)
        {
        }

        /// <summary>
        /// 알림톡 메시지를 전송합니다
        /// </summary>
        /// <param name="request">알림톡 전송 요청</param>
        /// <returns>알림톡 전송 결과</returns>
        public async Task<SendResult> SendMessageAsync(SendMessageRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (string.IsNullOrEmpty(request.TemplateCode))
            {
                throw new ArgumentException("TemplateCode is required", nameof(request));
            }

            if (request.Messages.Count == 0)
            {
                throw new ArgumentException("At least one message is required", nameof(request));
            }

            var parameters = await CreateBaseParametersAsync();

            if (string.IsNullOrEmpty(Configuration.SenderKey))
            {
                throw new InvalidOperationException("SenderKey is required for sending messages");
            }

            parameters["senderkey"] = Configuration.SenderKey;
            parameters["tpl_code"] = request.TemplateCode;

            var sender = request.Sender ?? Configuration.DefaultSender;
            if (string.IsNullOrEmpty(sender))
            {
                throw new InvalidOperationException("Sender is required for sending messages");
            }

            parameters["sender"] = sender;

            if (!string.IsNullOrEmpty(request.SendDate))
            {
                parameters["senddate"] = request.SendDate;
            }

            if (!string.IsNullOrEmpty(request.Failover))
            {
                parameters["failover"] = request.Failover;
            }

            for (int i = 0; i < request.Messages.Count; i++)
            {
                var index = i + 1;
                var message = request.Messages[i];

                if (string.IsNullOrEmpty(message.Receiver))
                {
                    throw new ArgumentException($"Receiver is required for message at index {i}", nameof(request));
                }

                if (string.IsNullOrEmpty(message.Message))
                {
                    throw new ArgumentException($"Message is required for message at index {i}", nameof(request));
                }

                parameters[$"receiver_{index}"] = message.Receiver;

                if (!string.IsNullOrEmpty(message.ReceiverName))
                {
                    parameters[$"recvname_{index}"] = message.ReceiverName;
                }

                if (!string.IsNullOrEmpty(message.Subject))
                {
                    parameters[$"subject_{index}"] = message.Subject;
                }

                parameters[$"message_{index}"] = message.Message;

                if (!string.IsNullOrEmpty(message.ButtonJson))
                {
                    parameters[$"button_{index}"] = message.ButtonJson;
                }

                if (!string.IsNullOrEmpty(message.FailoverSubject))
                {
                    parameters[$"fsubject_{index}"] = message.FailoverSubject;
                }

                if (!string.IsNullOrEmpty(message.FailoverMessage))
                {
                    parameters[$"fmessage_{index}"] = message.FailoverMessage;
                }
            }

            return await SendRequestAsync<SendResult>(SEND_MESSAGE_URL, parameters);
        }

        /// <summary>
        /// 전송 내역을 조회합니다
        /// </summary>
        /// <param name="request">전송 내역 조회 요청</param>
        /// <returns>전송 내역 조회 결과</returns>
        public async Task<MessageHistoryResult> GetMessageHistoryAsync(MessageHistoryRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var parameters = await CreateBaseParametersAsync();
            parameters["page"] = request.Page.ToString();
            parameters["limit"] = request.Limit.ToString();

            if (!string.IsNullOrEmpty(request.StartDate))
            {
                parameters["startdate"] = request.StartDate;
            }

            if (!string.IsNullOrEmpty(request.EndDate))
            {
                parameters["enddate"] = request.EndDate;
            }

            return await SendRequestAsync<MessageHistoryResult>(MESSAGE_HISTORY_URL, parameters);
        }

        /// <summary>
        /// 전송 상세 내역을 조회합니다
        /// </summary>
        /// <param name="request">전송 상세 내역 조회 요청</param>
        /// <returns>전송 상세 내역 조회 결과</returns>
        public async Task<MessageDetailResult> GetMessageDetailAsync(MessageDetailRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (string.IsNullOrEmpty(request.MessageId))
            {
                throw new ArgumentException("MessageId is required", nameof(request));
            }

            var parameters = await CreateBaseParametersAsync();
            parameters["mid"] = request.MessageId;
            parameters["page"] = request.Page.ToString();
            parameters["limit"] = request.Limit.ToString();

            if (!string.IsNullOrEmpty(request.StartDate))
            {
                parameters["startdate"] = request.StartDate;
            }

            if (!string.IsNullOrEmpty(request.EndDate))
            {
                parameters["enddate"] = request.EndDate;
            }

            return await SendRequestAsync<MessageDetailResult>(MESSAGE_DETAIL_URL, parameters);
        }

        /// <summary>
        /// 예약된 메시지를 취소합니다
        /// </summary>
        /// <param name="messageId">메시지 고유 ID</param>
        /// <returns>메시지 취소 결과</returns>
        public async Task<ApiResult> CancelMessageAsync(string messageId)
        {
            if (string.IsNullOrEmpty(messageId))
            {
                throw new ArgumentException("MessageId is required", nameof(messageId));
            }

            var parameters = await CreateBaseParametersAsync();
            parameters["mid"] = messageId;

            return await SendRequestAsync<ApiResult>(CANCEL_MESSAGE_URL, parameters);
        }

        /// <summary>
        /// 발송 가능 건수를 조회합니다
        /// </summary>
        /// <returns>발송 가능 건수 조회 결과</returns>
        public async Task<BalanceResult> GetBalanceAsync()
        {
            var parameters = await CreateBaseParametersAsync();
            return await SendRequestAsync<BalanceResult>(BALANCE_URL, parameters);
        }
    }
}
