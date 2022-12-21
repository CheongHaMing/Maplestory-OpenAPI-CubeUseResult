# Maplestory-OpenAPI-CubeUseResult
메이플스토리의 큐브 사용 결과를 얻어올 수 있는 소스 코드입니다.

### 개발 환경
Language: .NET 5.0\
IDE: VS Code

### 참고 사항
Exception 처리 일부러 안 함.

## 예제
아래는 본 소스 코드를 사용하는 방법을 설명합니다. 자세한 정보를 얻고 싶다면 본 Repository의 DTO/XXXDTO.cs 파일들을 참조하세요.
### 날짜 정보를 이용해 큐브 결과를 얻어오는 방법
```C#
// using MaplestoryOpenAPI
string apiKey = "넥슨 개발자 센터에서 발급 받은 키를 여기 입력하세요.";
int resultPerPage = 10; // 한 번에 가져올 큐브 사용 결과 갯수, 10~1000 사이
int year = 2022; // 2022년
int month = 12; // 12월
int day = 20; // 20일
CubeUseResultRequest request = new CubeUseResultRequest(); // 새로운 요청 생성
CubeHistoryResponseDTO dto1 = request.GetDataByDate(apiKey, resultPerPage, year, month, day);
string userName = dto1.cube_histories[0].character_name;
Console.WriteLine(userName);
```
### 커서 정보를 이용해 큐브 결과를 얻어오는 방법
```C#
// using MaplestoryOpenAPI
string apiKey = "넥슨 개발자 센터에서 발급 받은 키를 여기 입력하세요.";
int resultPerPage = 10; // 한 번에 가져올 큐브 사용 결과 갯수, 10~1000 사이
int year = 2022; // 2022년
int month = 12; // 12월
int day = 20; // 20일
CubeUseResultRequest request = new CubeUseResultRequest(); // 새로운 요청 생성
CubeHistoryResponseDTO dto1 = request.GetDataByDate(apiKey, resultPerPage, year, month, day);
string nextCursor = dto1.next_cursor; // dto1에서 얻은 결과의 다음 resultPerPage개의 큐브 사용 결과를 얻어오기 위해 필요한 커서
CubeHistoryResponseDTO dto2 = request.GetDataByCursor(apiKey, nextCursor);
string userName = dto2.cube_histories[0].character_name;
Console.WriteLine(userName);
```
