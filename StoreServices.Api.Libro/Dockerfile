#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["StoreServices.Api.Libro/StoreServices.Api.Libro.csproj", "StoreServices.Api.Libro/"]
RUN dotnet restore "StoreServices.Api.Libro/StoreServices.Api.Libro.csproj"
COPY . .
WORKDIR "/src/StoreServices.Api.Libro"
RUN dotnet build "StoreServices.Api.Libro.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StoreServices.Api.Libro.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StoreServices.Api.Libro.dll"]
