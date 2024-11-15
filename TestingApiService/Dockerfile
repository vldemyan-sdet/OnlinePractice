FROM mcr.microsoft.com/dotnet/sdk:8.0

WORKDIR /app

COPY . ./
RUN dotnet build
RUN dotnet publish ./TestingApiService.sln -o ./publish

ENTRYPOINT ["dotnet", "publish/TestingApiService.dll"]
