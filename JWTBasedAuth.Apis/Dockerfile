#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["JWTBasedAuth.Apis/JWTBasedAuth.Apis.csproj", "JWTBasedAuth.Apis/"]
RUN dotnet restore "JWTBasedAuth.Apis/JWTBasedAuth.Apis.csproj"
COPY . .
WORKDIR "/src/JWTBasedAuth.Apis"
RUN dotnet build "JWTBasedAuth.Apis.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "JWTBasedAuth.Apis.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "JWTBasedAuth.Apis.dll"]