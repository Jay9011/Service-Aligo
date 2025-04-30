using System;
using System.Collections.Generic;
using System.Text;

namespace AligoService.Model.Messages
{
    /// <summary>
    /// 메시지 내역 요청
    /// </summary>
    public class MessageHistoryRequest
    {
        /// <summary>
        /// 페이지 번호
        /// </summary>
        public int Page { get; set; } = 1;

        /// <summary>
        /// 페이지당 출력 갯수
        /// </summary>
        public int Limit { get; set; } = 20;

        /// <summary>
        /// 조회 시작 일자 (yyyyMMdd)
        /// </summary>
        public string StartDate { get; set; }

        /// <summary>
        /// 조회 종료 일자 (yyyyMMdd)
        /// </summary>
        public string EndDate { get; set; }
    }
}
