#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:5001
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["MagnetronAPI/MagnetronAPI.csproj", "MagnetronAPI/"]
RUN dotnet restore "MagnetronAPI/MagnetronAPI.csproj"
COPY . .
WORKDIR "/src/MagnetronAPI"
RUN dotnet build "MagnetronAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MagnetronAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MagnetronAPI.dll"]