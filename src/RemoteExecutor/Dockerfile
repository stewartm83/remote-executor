FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY RemoteExecutor/RemoteExecutor.csproj RemoteExecutor/
RUN dotnet restore "RemoteExecutor/RemoteExecutor.csproj"
COPY . .
WORKDIR "/src/RemoteExecutor"
RUN dotnet build "RemoteExecutor.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "RemoteExecutor.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "RemoteExecutor.dll"]
