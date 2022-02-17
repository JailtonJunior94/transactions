FROM mcr.microsoft.com/dotnet/runtime:6.0-alpine AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build
WORKDIR /src

COPY ["src/Transactions.Core/Transactions.Core.csproj", "src/Transactions.Core/"]
COPY ["src/Transactions.Worker/Transactions.Worker.csproj", "src/Transactions.Worker/"]
RUN dotnet restore "src/Transactions.Worker/Transactions.Worker.csproj"

COPY . .
WORKDIR "/src/src/Transactions.Worker"
RUN dotnet build "Transactions.Worker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Transactions.Worker.csproj" -c Release -o /app/publish

FROM base AS final

RUN apk --no-cache add tzdata
ENV TZ=America/Sao_Paulo

WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Transactions.Worker.dll"]