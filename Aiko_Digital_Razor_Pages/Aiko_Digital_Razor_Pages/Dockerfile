FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Aiko_Digital_Razor_Pages/Aiko_Digital_Razor_Pages.csproj", "Aiko_Digital_Razor_Pages/"]
RUN dotnet restore "Aiko_Digital_Razor_Pages/Aiko_Digital_Razor_Pages.csproj"
COPY . .
WORKDIR "/src/Aiko_Digital_Razor_Pages"
RUN dotnet build "Aiko_Digital_Razor_Pages.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Aiko_Digital_Razor_Pages.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Aiko_Digital_Razor_Pages.dll"]
