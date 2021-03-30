#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["StoreServices.Api.Author/StoreServices.Api.Author.csproj", "StoreServices.Api.Author/"]
RUN dotnet restore "StoreServices.Api.Author/StoreServices.Api.Author.csproj"
COPY . .
WORKDIR "/src/StoreServices.Api.Author"
RUN dotnet build "StoreServices.Api.Author.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StoreServices.Api.Author.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StoreServices.Api.Author.dll"]
