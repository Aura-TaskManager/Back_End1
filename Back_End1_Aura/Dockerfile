FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . .

RUN dotnet publish -c Release -o out

# Verify the DLL is present in the build stage
RUN ls -la /app/out

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./

# Verify the DLL is present in the runtime stage
RUN ls -la /app

EXPOSE 80

ENTRYPOINT ["dotnet", "Back_end1_Aura.dll"]