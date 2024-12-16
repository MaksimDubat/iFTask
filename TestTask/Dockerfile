
# This step is used when starting from VS in fast mode (default for debug configuration).
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This step is used to build the service project.
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["TestTask/TestTask.csproj", "TestTask/"]
RUN dotnet restore "./TestTask/TestTask.csproj"
COPY . .
WORKDIR "/src/TestTask"
RUN dotnet build "./TestTask.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This step is used to publish the service project that will be copied to the last step.
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./TestTask.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This step is used in the working environment or when starting from VS in normal mode (default when debugging configuration is not used).
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestTask.dll"]