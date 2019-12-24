FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY AllShareLive.API/AllShareLive.API.csproj AllShareLive.API/
RUN dotnet restore "AllShareLive.API/AllShareLive.API.csproj"
COPY . .
WORKDIR "/src/AllShareLive.API"
RUN dotnet build "AllShareLive.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AllShareLive.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AllShareLive.API.dll"]
