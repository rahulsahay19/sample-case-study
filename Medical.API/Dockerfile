#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Medical.API.csproj", ""]
RUN dotnet restore "./Medical.API.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Medical.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Medical.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Medical.API.dll"]