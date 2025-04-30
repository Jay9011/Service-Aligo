using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AligoService.Model.ApiResults;

namespace AligoService.Interface
{
    /// <summary>
    /// 토큰 관련 작업을 처리하는 인터페이스
    /// </summary>
    public interface ITokenService
    {
        /// <summary>
        /// 토큰을 생성합니다
        /// </summary>
        /// <param name="expiryValue">만료 값</param>
        /// <param name="expiryUnit">만료 단위 (s: 초, m: 분, h: 시간, d: 일)</param>
        /// <returns>토큰 생성 결과</returns>
        Task<TokenResult> CreateTokenAsync(int expiryValue = 30, string expiryUnit = "s");
    }
}
