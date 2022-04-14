FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Transactions.API/Transactions.API.csproj", "src/Transactions.API/"]
RUN dotnet restore "src/Transactions.API/Transactions.API.csproj"
COPY . .
WORKDIR "/src/src/Transactions.API"
RUN dotnet build "Transactions.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Transactions.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Transactions.API.dll"]