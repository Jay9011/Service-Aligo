using System;
using System.Collections.Generic;
using System.Text;

namespace AligoService.Model.Templates
{
    /// <summary>
    /// 템플릿 추가 요청
    /// </summary>
    public class AddTemplateRequest
    {
        /// <summary>
        /// 템플릿 이름
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 템플릿 내용
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 버튼 정보 (JSON 문자열)
        /// </summary>
        public string ButtonJson { get; set; }
    }
}
