using System;
using System.Collections.Generic;
using System.Text;

namespace AligoService.Model.Templates
{
    /// <summary>
    /// 템플릿 수정 요청
    /// </summary>
    public class ModifyTemplateRequest : AddTemplateRequest
    {
        /// <summary>
        /// 템플릿 코드
        /// </summary>
        public string TemplateCode { get; set; }
    }
}
