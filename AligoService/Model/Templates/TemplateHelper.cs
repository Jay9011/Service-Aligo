using AligoService.Model.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace AligoService.Model.Templates
{
    public class TemplateHelper
    {
        /// <summary>
        /// 간편하게 변수 딕셔너리를 생성합니다.
        /// </summary>
        /// <param name="variablePairs">변수명과 값의 쌍. 변수명1, 값1, 변수명2, 값2, ... 형식으로 입력</param>
        /// <returns>변수 딕셔너리</returns>
        public static Dictionary<string, string> Variables(params string[] variablePairs)
        {
            if (variablePairs == null || variablePairs.Length % 2 != 0)
                throw new ArgumentException("변수명과 값의 쌍이 올바르지 않습니다. 변수명과 값이 짝을 이루어야 합니다.");

            var variables = new Dictionary<string, string>();
            for (int i = 0; i < variablePairs.Length; i += 2)
            {
                variables[variablePairs[i]] = variablePairs[i + 1];
            }

            return variables;
        }

        /// <summary>
        /// 템플릿 메시지에 변수를 적용하여 SendMessageRequest를 생성합니다.
        /// </summary>
        /// <param name="templateCode">템플릿 코드</param>
        /// <param name="sender">발신자 번호</param>
        /// <param name="receiverList">수신자 정보 목록</param>
        /// <param name="buttonJson">버튼 정보 (옵션)</param>
        /// <param name="sendDate">예약 발송 일시 (옵션)</param>
        /// <param name="failover">실패시 문자 대체 발송 여부 (기본값: Y)</param>
        /// <returns>생성된 SendMessageRequest</returns>
        public static SendMessageRequest CreateSendRequest(
            string templateCode,
            string sender,
            List<ReceiverInfo> receiverList,
            string buttonJson = null,
            string sendDate = null,
            string failover = "Y")
        {
            var request = new SendMessageRequest
            {
                TemplateCode = templateCode,
                Sender = sender,
                SendDate = sendDate,
                Failover = failover,
                Messages = new List<MessageItem>()
            };

            foreach (var receiver in receiverList)
            {
                var messageItem = new MessageItem
                {
                    Receiver = receiver.Phone,
                    ReceiverName = receiver.Name,
                    Subject = receiver.Subject,
                    Message = receiver.TemplateContent.ReplaceVariables(receiver.Variables).ReplaceQueryString(receiver.QueryVariables),
                    FailoverSubject = receiver.FailoverSubject,
                    FailoverMessage = receiver.FailoverMessage ?? receiver.TemplateContent.ReplaceVariables(receiver.Variables)
                };

                if (!string.IsNullOrEmpty(buttonJson))
                {
                    string processedButtonJson = buttonJson;
                    // 버튼 JSON에도 변수 치환 적용
                    if (receiver.Variables != null && receiver.Variables.Count > 0)
                    {
                        processedButtonJson = buttonJson.ReplaceVariables(receiver.Variables);
                    }
                    messageItem.ButtonJson = processedButtonJson;
                }

                request.Messages.Add(messageItem);
            }

            return request;
        }
    }
}
