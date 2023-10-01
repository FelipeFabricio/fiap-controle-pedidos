FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Interface.WebApi/Interface.WebApi.csproj", "src/Interface.WebApi/"]
RUN dotnet restore "src/Interface.WebApi/Interface.WebApi.csproj"
COPY . .
WORKDIR "/src/src/Interface.WebApi"
RUN dotnet build "Interface.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Interface.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Interface.WebApi.dll"]
