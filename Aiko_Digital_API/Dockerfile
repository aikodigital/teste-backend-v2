FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
#COPY *.csproj ./
COPY . ./

RUN dotnet restore

# Copy everything else and build
#COPY . ./
RUN dotnet publish API/API.csproj -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build-env /app/out .
RUN mkdir /app/Uploads
ENTRYPOINT ["dotnet", "API.dll"]