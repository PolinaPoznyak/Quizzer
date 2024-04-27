FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Quizzer/Quizzer.Api/Quizzer.Api.csproj", "Quizzer.Api/"]
COPY ["Quizzer/Quizzer.Data/Quizzer.Data.csproj", "Quizzer.Data/"]
COPY ["Quizzer/Quizzer.Entities/Quizzer.Entities.csproj", "Quizzer.Entities/"]
COPY ["Quizzer/Quizzer.Dtos/Quizzer.Dtos.csproj", "Quizzer.Dtos/"]
COPY ["Quizzer/Quizzer.Services/Quizzer.Services.csproj", "Quizzer.Services/"]
RUN dotnet restore "Quizzer.Api/Quizzer.Api.csproj"
COPY . .
WORKDIR "/src/Quizzer/Quizzer.Api"
RUN dotnet build "Quizzer.Api.csproj" -c Release -o ло/app/build

FROM build AS publish
RUN dotnet publish "Quizzer.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Quizzer.Api.dll"]