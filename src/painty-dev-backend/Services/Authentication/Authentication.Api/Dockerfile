#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Services/Authentication/Authentication.Api/Authentication.Api.csproj", "Services/Authentication/Authentication.Api/"]
COPY ["Services/Authentication/Authentication.BusinessLayer/Authentication.BusinessLayer.csproj", "Services/Authentication/Authentication.BusinessLayer/"]
COPY ["Libs/CustomResponse/CustomResponseLib.csproj", "Libs/CustomResponse/"]
COPY ["Services/Communication/Communication.DomainLayer/Communication.DomainLayer.csproj", "Services/Communication/Communication.DomainLayer/"]
COPY ["Libs/Cryptography/Cryptography.csproj", "Libs/Cryptography/"]
COPY ["Services/EventBus/EventBus/EventBus.csproj", "Services/EventBus/EventBus/"]
COPY ["Services/Authentication/Authentication.DomainLayer/Authentication.DomainLayer.csproj", "Services/Authentication/Authentication.DomainLayer/"]
RUN dotnet restore "Services/Authentication/Authentication.Api/Authentication.Api.csproj"
COPY . .
WORKDIR "/src/Services/Authentication/Authentication.Api"
RUN dotnet build "Authentication.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Authentication.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Authentication.Api.dll"]