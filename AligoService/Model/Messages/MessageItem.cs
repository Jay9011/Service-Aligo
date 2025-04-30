using System;
using System.Collections.Generic;
using System.Text;

namespace AligoService.Model.Messages
{
    /// <summary>
    /// 메시지 아이템
    /// </summary>
    public class MessageItem
    {
        /// <summary>
        /// 수신자 번호
        /// </summary>
        public string Receiver { get; set; }

        /// <summary>
        /// 수신자 이름
        /// </summary>
        public string ReceiverName { get; set; }

        /// <summary>
        /// 메시지 제목
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// 메시지 내용
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 버튼 정보 (JSON 문자열)
        /// </summary>
        public string ButtonJson { get; set; }

        /// <summary>
        /// 실패시 문자 제목
        /// </summary>
        public string FailoverSubject { get; set; }

        /// <summary>
        /// 실패시 문자 내용
        /// </summary>
        public string FailoverMessage { get; set; }
    }
}
