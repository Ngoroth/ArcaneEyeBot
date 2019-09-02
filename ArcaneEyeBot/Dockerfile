FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["ArcaneEyeBot/ArcaneEyeBot.csproj", "ArcaneEyeBot/"]
COPY ["ArcaneEyeBot.Core/ArcaneEyeBot.Core.csproj", "ArcaneEyeBot.Core/"]
RUN dotnet restore "ArcaneEyeBot/ArcaneEyeBot.csproj"
COPY . .
WORKDIR "/src/ArcaneEyeBot"
RUN dotnet build "ArcaneEyeBot.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ArcaneEyeBot.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ArcaneEyeBot.dll"]