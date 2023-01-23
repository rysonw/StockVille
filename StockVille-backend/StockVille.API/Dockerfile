#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["StockVille/StockVille-backend/StockVille-backend.csproj", "StockVille/StockVille-backend/"]
RUN dotnet restore "StockVille/StockVille-backend/StockVille-backend.csproj"
COPY . .
WORKDIR "/src/StockVille/StockVille-backend"
RUN dotnet build "StockVille-backend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StockVille-backend.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StockVille-backend.dll"]