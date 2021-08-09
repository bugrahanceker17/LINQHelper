FROM mcr.microsoft.com/dotnet/core/runtime:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["LINQHelper/LINQHelper.csproj", "LINQHelper/"]
RUN dotnet restore "LINQHelper/LINQHelper.csproj"
COPY . .
WORKDIR "/src/LINQHelper"
RUN dotnet build "LINQHelper.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LINQHelper.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LINQHelper.dll"]
