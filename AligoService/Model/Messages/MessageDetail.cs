using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AligoService.Model.Messages
{
    /// <summary>
    /// 메시지 상세
    /// </summary>
    public class MessageDetail
    {
        /// <summary>
        /// 메시지 ID
        /// </summary>
        [JsonProperty("msgid")]
        public string MessageId { get; set; }

        /// <summary>
        /// 메시지 타입
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// 발신자 번호
        /// </summary>
        [JsonProperty("sender")]
        public string Sender { get; set; }

        /// <summary>
        /// 수신자 번호
        /// </summary>
        [JsonProperty("phone")]
        public string Phone { get; set; }

        /// <summary>
        /// 상태 코드
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// 요청 일시
        /// </summary>
        [JsonProperty("reqdate")]
        public string RequestDate { get; set; }

        /// <summary>
        /// 발송 일시
        /// </summary>
        [JsonProperty("sentdate")]
        public string SentDate { get; set; }

        /// <summary>
        /// 결과 일시
        /// </summary>
        [JsonProperty("rsltdate")]
        public string ResultDate { get; set; }

        /// <summary>
        /// 리포트 일시
        /// </summary>
        [JsonProperty("reportdate")]
        public string ReportDate { get; set; }

        /// <summary>
        /// 결과 코드
        /// </summary>
        [JsonProperty("rslt")]
        public string Result { get; set; }

        /// <summary>
        /// 결과 메시지
        /// </summary>
        [JsonProperty("rslt_message")]
        public string ResultMessage { get; set; }

        /// <summary>
        /// 메시지 내용
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// 버튼 JSON
        /// </summary>
        [JsonProperty("button_json")]
        public string ButtonJson { get; set; }

        /// <summary>
        /// 템플릿 코드
        /// </summary>
        [JsonProperty("tpl_code")]
        public string TemplateCode { get; set; }

        /// <summary>
        /// 발신 프로필 키
        /// </summary>
        [JsonProperty("senderKey")]
        public string SenderKey { get; set; }

        /// <summary>
        /// SMID
        /// </summary>
        [JsonProperty("smid")]
        public string Smid { get; set; }
    }
}
