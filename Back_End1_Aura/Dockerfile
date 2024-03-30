FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Back_End1_Aura/Back_End1_Aura.csproj", "Back_End1_Aura/"]
RUN dotnet restore "Back_End1_Aura/Back_End1_Aura.csproj"
COPY . .
WORKDIR "/src/Back_End1_Aura"
RUN dotnet build "Back_End1_Aura.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Back_End1_Aura.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Back_End1_Aura.dll"]
