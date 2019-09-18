FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Chat.SignalR/Chat.SignalR.csproj", "Chat.SignalR/"]
RUN dotnet restore "Chat.SignalR/Chat.SignalR.csproj"
COPY . .
WORKDIR "/src/Chat.SignalR"
RUN dotnet build "Chat.SignalR.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Chat.SignalR.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Chat.SignalR.dll"]