# AttributeModel

> Attribute Programming Model for IOC Container libraries.

이 프로젝트는 Attribute 기반으로 IoC 컨테이너 등록을 자동화하기 위해 만든 프로젝트입니다. `.NET`의 IoC 컨테이너 라이브러리는 모두 수기로 혹은 낮은 수준의 배치 등록을 통해 자동화 할 수 있었지만 아래와 같은 제약사항 있었습니다.

1. 신뢰할 수 없습니다. 네임스페이스 기반의 비교를 통한 클래스 등록은 구조적인 리팩토링에 제약을 가집니다.
1. 클래스의 배치 등록시 정확한 라이프스타일을 지정하기 어렵습니다. 리모트 API 레파지토리, 데이터베이스, 캐시 스토어 모두 제각기 다른 라이프스타일을 지정할 수 있어야하며 이는 클래스 종속적인 **속성**입니다.
1. 번거롭습니다. 2번 항목때문에 모든 코드를 작성할 떄마다 등록 코드를 재 작성해야함은 유지보수성이 떨어지며 런타임시 검증할 방법이 없으며 에러를 내포하고 있습니다.

따라서 `AttributeModel` 라이브러리는 이러한 내용을 공통된 방법으로 주요한 IoC 컨테이너 라이브러리 확장을 제공함으로써 편리하게 사용하실 수 있도록 만들어졌습니다.


## Getting Start

빠르게 시작하실 수 있도록 아래와 같은 가이드를 제공합니다.

### Requirements

`AttributeModel`은 `.netstandard 2.0`을 기반으로 제공됩니다. `.NET Framework 4.6.1` 혹은 `.NET Core 2.0`이상에서 동작이 가능합니다.

### Installation

Powershell Package Manger에서 아래와 같이 설치할 수 있습니다.

```powershell
Install-Package AttributeModel.Core.SimpleInjector -Version 1.0.0-rc002
```

또는 .NET CLI로 설치 할 수 있습니다.

```sh
dotnet add package AttributeModel.Core.SimpleInjector --version 1.0.0-rc002
```


### Run and test

적용 방법은 굉장히 간단합니다.

```csharp
var conatiner = new Container();

container.Regist(); // Just do it!

// If you want to regist specific assembly, do it.
container.Regist(typeof(ISomeService).Assembly);
```

그리고 만약 `Service`나 `Repository`를 정의하고 싶을 때는 아래와 같이 Attribute로 설정해주시면 됩니다.

```csharp
[Service]
public class UserService : IUserService
{
    private IUserRepository UserRepository { get; set; }

    constructor(IUserRepository userRepository)
    {
        UserRepository = userRepository;
    }
}

[Repository]
public class UserRepository : IUserRepository
{
    // code...
}
```

만약 어떤 컴포넌트 혹은 서비스에 대해서 특정한 라이프사이클을 지정하고 싶을 땐 아래와 같이 작성해주시면 됩니다.

```csharp
[Component(Lifestyle.SingleTon)]
public class UserService : IUserService
{
    // code...
}
```

위와 같은 설정이 끝나셨다면 더 이상 등록할 필요 없이 DI를 즐기시면 됩니다!

## Extensions

- [x] [SimpleInjector](https://github.com/simpleinjector/SimpleInjector) (Recommend)
- [ ] [AutoFac](https://github.com/autofac/Autofac)
- [ ] [Ninject](https://github.com/ninject/Ninject)
- [ ] ASP.NET Core IoC Container
- [ ] ASP.NET Core Extension
- [ ] ASP.NET Web Mvc Extension

## Lisence

MIT
