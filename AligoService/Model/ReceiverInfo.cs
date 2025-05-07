using System;
using System.Collections.Generic;
using System.Text;

namespace AligoService.Model
{
    /// <summary>
    /// 알림톡 수신자 정보
    /// </summary>
    public class ReceiverInfo
    {
        /// <summary>
        /// 수신자 전화번호
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 수신자 이름
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 메시지 제목
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// 템플릿 내용 (변수 포함)
        /// </summary>
        public string TemplateContent { get; set; }

        /// <summary>
        /// 변수 값 딕셔너리
        /// </summary>
        public Dictionary<string, string> Variables { get; set; } = new Dictionary<string, string>();

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
