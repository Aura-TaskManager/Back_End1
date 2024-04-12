# Use the ASP.NET Core runtime image as the base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Use the ASP.NET Core SDK image for building the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the project file and restore dependencies
#COPY ["Back_End1_Aura/Back_End1_Aura.csproj", "Back_End1_Aura/"]
RUN dotnet restore "Back_End1_Aura/Back_End1_Aura.csproj"

# Copy the remaining source code
COPY . .

# Build the application
WORKDIR "/src/Back_End1_Aura"
RUN dotnet build "Back_End1_Aura.csproj" -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "Back_End1_Aura.csproj" -c Release -o /app/publish

# Set up the final runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Back_End1_Aura.dll"]