FROM mcr.microsoft.com/dotnet/core/sdk:2.1 AS build
WORKDIR /app
# copy csproj and restore as distinct layers
COPY *.sln .
COPY NewsPortal/*.csproj ./NewsPortal/
COPY NewsPortal.Domain/*.csproj ./NewsPortal.Domain/
COPY NewsPortal.Data/*.csproj ./NewsPortal.Data/
COPY NewsPortal.Logging/*.csproj ./NewsPortal.Logging/
COPY NewsPortal.Models/*.csproj ./NewsPortal.Models/
RUN dotnet restore

# copy everything else and build app
COPY NewsPortal/ ./NewsPortal/
COPY NewsPortal.Domain/ ./NewsPortal.Domain/
COPY NewsPortal.Data/ ./NewsPortal.Data/
COPY NewsPortal.Logging/ ./NewsPortal.Logging/
COPY NewsPortal.Models/ ./NewsPortal.Models/
RUN dotnet publish -c release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:2.1 AS runtime
# WORKDIR /app
COPY --from=build /app/NewsPortal/out ./
CMD ASPNETCORE_URLS=http://*:$PORT dotnet NewsPortal.dll
