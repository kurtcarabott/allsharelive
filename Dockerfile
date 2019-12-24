FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY AllShareLiveAPI/AllShareLiveAPI.csproj AllShareLiveAPI/
RUN dotnet restore "AllShareLiveAPI/AllShareLiveAPI.csproj"
COPY . .
WORKDIR "/src/AllShareLiveAPI"
RUN dotnet build "AllShareLiveAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AllShareLiveAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AllShareLiveAPI.dll"]
