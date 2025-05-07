using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AligoService.Model.Templates
{
    /// <summary>
    /// 알림톡 템플릿 확장 메서드 (변수 처리 등...)
    /// </summary>
    public static class TemplateExtensions
    {
        /// <summary>
        /// 템플릿 텍스트의 변수를 치환합니다.
        /// </summary>
        /// <param name="template">변수가 포함된 템플릿 문자열(템플릿 컨텐츠)</param>
        /// <param name="variables">변수명과 값을 담은 딕셔너리</param>
        /// <returns>변수가 치환된 문자열</returns>
        public static string ReplaceVariables(this string template, Dictionary<string, string> variables)
        {
            if (string.IsNullOrEmpty(template))
                return template;

            if (variables == null || variables.Count == 0)
                return template;

            string result = template;
            foreach (var variable in variables)
            {
                result = result.Replace($"#{{{variable.Key}}}", variable.Value);
            }

            return result;
        }

        /// <summary>
        /// 템플릿 텍스트에서 변수 목록을 추출합니다.
        /// </summary>
        /// <param name="template">변수가 포함된 템플릿 문자열</param>
        /// <returns>추출된 변수명 목록</returns>
        public static List<string> ExtractVariables(this string template)
        {
            if (string.IsNullOrEmpty(template))
                return new List<string>();

            var variables = new List<string>();
            var regex = new Regex(@"#\{([^}]+)\}");
            var matches = regex.Matches(template);

            foreach (Match match in matches)
            {
                if (match.Groups.Count > 1)
                {
                    string variableName = match.Groups[1].Value;
                    if (!variables.Contains(variableName))
                    {
                        variables.Add(variableName);
                    }
                }
            }

            return variables;
        }

        /// <summary>
        /// 템플릿 변수가 모두 치환되었는지 확인합니다.
        /// </summary>
        /// <param name="text">검사할 문자열</param>
        /// <returns>모든 변수가 치환되었으면 true, 그렇지 않으면 false</returns>
        public static bool AllVariablesReplaced(this string text)
        {
            if (string.IsNullOrEmpty(text))
                return true;

            var regex = new Regex(@"#\{([^}]+)\}");
            return !regex.IsMatch(text);
        }
    }
}
