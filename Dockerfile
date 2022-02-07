#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app

EXPOSE 5332


FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["planeja-odonto-api/planeja-odonto-api.csproj", "planeja-odonto-api/"]
RUN dotnet restore "planeja-odonto-api/planeja-odonto-api.csproj"
COPY . .
WORKDIR "/src/planeja-odonto-api"
RUN dotnet build "planeja-odonto-api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "planeja-odonto-api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "planeja-odonto-api.dll"]