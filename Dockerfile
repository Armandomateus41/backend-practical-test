FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copia todos os arquivos
COPY . ./

# Restaura o projeto da raiz
RUN dotnet restore BackendPracticalTest.csproj

# Publica o projeto usando o caminho correto
RUN dotnet publish BackendPracticalTest.csproj -c Release -o /app/publish

# Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 80
ENTRYPOINT ["dotnet", "BackendPracticalTest.dll"]
