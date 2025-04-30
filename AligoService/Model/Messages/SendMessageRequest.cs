using System;
using System.Collections.Generic;
using System.Text;

namespace AligoService.Model.Messages
{
    /// <summary>
    /// 알림톡 전송 요청
    /// </summary>
    public class SendMessageRequest
    {
        /// <summary>
        /// 템플릿 코드
        /// </summary>
        public string TemplateCode { get; set; }

        /// <summary>
        /// 발신자 번호
        /// </summary>
        public string Sender { get; set; }

        /// <summary>
        /// 예약 발송 일시 (yyyyMMddHHmmss)
        /// </summary>
        public string SendDate { get; set; }

        /// <summary>
        /// 메시지 아이템 목록
        /// </summary>
        public List<MessageItem> Messages { get; set; } = new List<MessageItem>();

        /// <summary>
        /// 실패시 문자 대체 발송 여부 (Y/N)
        /// </summary>
        public string Failover { get; set; } = "Y";
    }
}
