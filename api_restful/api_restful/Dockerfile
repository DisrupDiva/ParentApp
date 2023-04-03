FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["api_restful/api_restful.csproj", "api_restful/"]
RUN dotnet restore "api_restful/api_restful.csproj"
COPY . .
WORKDIR "/src/api_restful"
RUN dotnet build "api_restful.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "api_restful.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "api_restful.dll"]
