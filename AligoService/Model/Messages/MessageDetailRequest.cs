using System;
using System.Collections.Generic;
using System.Text;

namespace AligoService.Model.Messages
{
    /// <summary>
    /// 메시지 상세 내역 요청
    /// </summary>
    public class MessageDetailRequest : MessageHistoryRequest
    {
        /// <summary>
        /// 메시지 ID
        /// </summary>
        public string MessageId { get; set; }
    }
}
