# runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080

# build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "./Mukhametshin_Test_Aviakod.csproj"
RUN dotnet publish "./Mukhametshin_Test_Aviakod.csproj" -c Release -o /app/publish /p:UseAppHost=false

# final
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_URLS=http://+:8080
ENTRYPOINT ["dotnet", "Mukhametshin_Test_Aviakod.dll"]
