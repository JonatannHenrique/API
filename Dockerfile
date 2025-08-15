FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# copiar o csproj da subpasta
COPY Pizzaria/Pizzaria.csproj ./ 
RUN dotnet restore

# copiar todo o código da subpasta
COPY Pizzaria/. ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app/out .
EXPOSE 10000
ENTRYPOINT ["dotnet", "Pizzaria.dll"]
