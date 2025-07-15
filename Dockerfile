# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

COPY *.sln .
COPY SocialMediaApi/*.csproj ./SocialMediaApi/
RUN dotnet restore

COPY . .
WORKDIR /app/SocialMediaApi
RUN dotnet publish -c Release -o out

# Stage 2: Run
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app/SocialMediaApi/out ./

ENTRYPOINT ["dotnet", "SocialMediaApi.dll"]
