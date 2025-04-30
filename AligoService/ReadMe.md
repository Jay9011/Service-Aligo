# AligoService 라이브러리

AligoService는 알리고 API를 사용하여 SMS, LMS, MMS 및 알림톡을 전송하는 기능을 제공하는 C# 라이브러리입니다. 이 라이브러리는 Aligo API의 다양한 기능을 쉽게 사용할 수 있도록 도와줍니다.

구현 버전: .NET Standard 2.0

## 특징

- 모든 API 호출에 대한 비동기 지원 (`async/await`)
- 인터페이스 기반 설계로 모듈화 및 테스트 용이성 증대
- 강력한 타입 안전성 및 예외 처리
- NuGet으로 간편한 설치
- 상세한 API 문서화
- 의존성 주입을 통한 유연한 확장성

## 시작하기

### 클라이언트 초기화

```csharp
using Aligo.Standard;

// 간단한 초기화
var aligoClient = AligoClientFactory.Create(
    apiKey: "your-api-key",
    userId: "your-user-id",
    senderKey: "your-sender-key",
    defaultSender: "your-default-sender"
);

// 또는 의존성 주입 사용 시
services.AddSingleton<IAligoConfiguration>(new AligoConfiguration(
    apiKey: "your-api-key",
    userId: "your-user-id",
    senderKey: "your-sender-key",
    defaultSender: "your-default-sender"
));
services.AddSingleton<IHttpClient, AligoHttpClient>();
services.AddSingleton<ITokenService, TokenService>();
services.AddSingleton<ITemplateService, TemplateService>();
services.AddSingleton<IProfileService, ProfileService>();
services.AddSingleton<IMessageService, MessageService>();
services.AddSingleton<IAligoClient, AligoClient>();
```

## 주요 기능

### 토큰 관리 (TokenService)

- 토큰 생성 및 관리

### 템플릿 관리 (TemplateService)

- 템플릿 목록 조회
- 템플릿 추가
- 템플릿 수정
- 템플릿 삭제
- 템플릿 검수 요청

### 발신프로필 관리 (ProfileService)

- 발신프로필 인증 요청
- 발신프로필 등록
- 발신프로필 목록 조회
- 카테고리 목록 조회

### 메시지 관리 (MessageService)

- 알림톡 메시지 전송
- 전송 내역 조회
- 전송 상세 내역 조회
- 예약 메시지 취소
- 발송 가능 건수 조회

## 상세 사용 예제

### 발신프로필 인증 요청

```csharp
var authRequest = new AuthenticateProfileRequest
{
    PlusId = "@your-plus-id",
    PhoneNumber = "01012345678"
};

var authResult = await aligoClient.ProfileService.AuthenticateProfileAsync(authRequest);
if (authResult.Success)
{
    Console.WriteLine("발신프로필 인증 요청 성공!");
}
```

### 발신프로필 등록

```csharp
var addProfileRequest = new AddProfileRequest
{
    PlusId = "@your-plus-id",
    PhoneNumber = "01012345678",
    AuthNumber = "123456",    // 인증번호
    CategoryCode = "00100010001"
};

var profileResult = await aligoClient.ProfileService.AddProfileAsync(addProfileRequest);
if (profileResult.Success)
{
    Console.WriteLine($"발신프로필 등록 성공: {profileResult.Profiles[0].SenderKey}");
}
```

### 템플릿 등록

```csharp
var addTemplateRequest = new AddTemplateRequest
{
    Name = "회원가입 환영",
    Content = "안녕하세요 #{이름}님, #{회사명}에 가입해주셔서 감사합니다.",
    ButtonJson = "{\"button\":[{\"name\":\"홈페이지 바로가기\",\"linkType\":\"WL\",\"linkMo\":\"https://example.com\",\"linkPc\":\"https://example.com\"}]}"
};

var templateResult = await aligoClient.TemplateService.AddTemplateAsync(addTemplateRequest);
if (templateResult.Success)
{
    Console.WriteLine($"템플릿 등록 성공: {templateResult.Template.Code}");
}
```

### 발송 가능 건수 조회

```csharp
var balanceResult = await aligoClient.MessageService.GetBalanceAsync();
if (balanceResult.Success)
{
    Console.WriteLine($"SMS: {balanceResult.Data.SmsCount}건");
    Console.WriteLine($"LMS: {balanceResult.Data.LmsCount}건");
    Console.WriteLine($"MMS: {balanceResult.Data.MmsCount}건");
    Console.WriteLine($"알림톡: {balanceResult.Data.AltCount}건");
}
```

## 알림톡 템플릿 작성 가이드

알림톡 템플릿 작성 시 다음 사항을 유의해야 합니다:

- 치환자 변수는 #{변수명} 형식으로 작성
- 버튼 타입:
  - WL: 웹링크
  - AL: 앱링크
  - DS: 배송조회
  - BK: 봇키워드
  - MD: 메시지 전달

### 버튼 JSON 예시

```json
// 웹링크 버튼
{
  "button": [
    {
      "name": "버튼명",
      "linkType": "WL",
      "linkMo": "https://m.example.com",
      "linkPc": "https://example.com" 
    }
  ]
}

// 앱링크 버튼
{
  "button": [
    {
      "name": "앱열기",
      "linkType": "AL",
      "linkIos": "exampleapp://",
      "linkAnd": "exampleapp://" 
    }
  ]
}

// 배송조회 버튼
{
  "button": [
    {
      "name": "배송조회",
      "linkType": "DS"
    }
  ]
}

// 복수 버튼
{
  "button": [
    {
      "name": "웹사이트",
      "linkType": "WL",
      "linkMo": "https://m.example.com"
    },
    {
      "name": "배송조회",
      "linkType": "DS"
    }
  ]
}
```

## 사용 예제
```csharp
namespace AligoExample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // 설정 정보
            string apiKey = "your-api-key";
            string userId = "your-user-id";
            string senderKey = "your-sender-key";
            string defaultSender = "your-default-sender";
            
            try
            {
                // 클라이언트 생성
                var aligoClient = AligoClientFactory.Create(apiKey, userId, senderKey, defaultSender);
                
                // 토큰 생성 예제
                Console.WriteLine("===== 토큰 생성 =====");
                var tokenResult = await aligoClient.TokenService.CreateTokenAsync();
                if (tokenResult.Success)
                {
                    Console.WriteLine($"토큰 생성 성공: {tokenResult.UrlEncodedToken}");
                }
                else
                {
                    Console.WriteLine($"토큰 생성 실패: {tokenResult.Message}");
                }
                
                // 템플릿 목록 조회 예제
                Console.WriteLine("\n===== 템플릿 목록 조회 =====");
                var templatesResult = await aligoClient.TemplateService.GetTemplatesAsync();
                if (templatesResult.Success)
                {
                    Console.WriteLine($"템플릿 목록 조회 성공: {templatesResult.Templates.Count}개 템플릿");
                    foreach (var template in templatesResult.Templates)
                    {
                        Console.WriteLine($"- {template.Name} ({template.Code}): {template.Content}");
                    }
                }
                else
                {
                    Console.WriteLine($"템플릿 목록 조회 실패: {templatesResult.Message}");
                }
                
                // 메시지 전송 예제
                Console.WriteLine("\n===== 알림톡 전송 =====");
                var sendRequest = new SendMessageRequest
                {
                    TemplateCode = "your-template-code",
                    Messages = new System.Collections.Generic.List<MessageItem>
                    {
                        new MessageItem
                        {
                            Receiver = "01012345678",
                            ReceiverName = "홍길동",
                            Subject = "알림톡 테스트",
                            Message = "안녕하세요 #{이름}님, 알림톡 테스트입니다.".Replace("#{이름}", "홍길동"),
                            ButtonJson = "{\"button\":[{\"name\":\"자세히보기\",\"linkType\":\"WL\",\"linkMo\":\"https://example.com\",\"linkPc\":\"https://example.com\"}]}"
                        }
                    }
                };
                
                var sendResult = await aligoClient.MessageService.SendMessageAsync(sendRequest);
                if (sendResult.Success)
                {
                    Console.WriteLine($"알림톡 전송 성공: {sendResult.Info[0].MessageId}");
                }
                else
                {
                    Console.WriteLine($"알림톡 전송 실패: {sendResult.Message}");
                }
                
                // 발송 가능 건수 조회 예제
                Console.WriteLine("\n===== 발송 가능 건수 조회 =====");
                var balanceResult = await aligoClient.MessageService.GetBalanceAsync();
                if (balanceResult.Success)
                {
                    Console.WriteLine($"SMS: {balanceResult.Data.SmsCount}건");
                    Console.WriteLine($"LMS: {balanceResult.Data.LmsCount}건");
                    Console.WriteLine($"MMS: {balanceResult.Data.MmsCount}건");
                    Console.WriteLine($"알림톡: {balanceResult.Data.AltCount}건");
                }
                else
                {
                    Console.WriteLine($"발송 가능 건수 조회 실패: {balanceResult.Message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"오류 발생: {ex.Message}");
            }
            
            Console.WriteLine("\n프로그램이 완료되었습니다. 아무 키나 누르세요...");
            Console.ReadKey();
        }
    }
}
```
