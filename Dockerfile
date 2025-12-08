# 1. Bygg stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Kopiera csproj och restore
COPY *.csproj ./
RUN dotnet restore

# Kopiera resten av projektet
COPY . ./
RUN dotnet publish -c Release -o /out

# 2. Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /out .

EXPOSE 8080

ENTRYPOINT ["dotnet", "CryptoApi.dll"]
