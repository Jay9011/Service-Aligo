using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using AligoService.Model.Messages;

namespace AligoService.Model.ApiResults
{
    /// <summary>
    /// 메시지 상세 결과
    /// </summary>
    public class MessageDetailResult : ApiResult
    {
        /// <summary>
        /// 메시지 상세 목록
        /// </summary>
        [JsonProperty("list")]
        public List<MessageDetail> Details { get; set; } = new List<MessageDetail>();

        /// <summary>
        /// 현재 페이지
        /// </summary>
        [JsonProperty("currentPage")]
        public string CurrentPage { get; set; }

        /// <summary>
        /// 총 페이지
        /// </summary>
        [JsonProperty("totalPage")]
        public string TotalPage { get; set; }

        /// <summary>
        /// 총 건수
        /// </summary>
        [JsonProperty("totalCount")]
        public string TotalCount { get; set; }
    }
}
