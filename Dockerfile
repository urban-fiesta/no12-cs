FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out
RUN dotnet tool install --global dotnet-ef
RUN export PATH="/root/.dotnet/tools:$PATH"
RUN dotnet ef database update
ENTRYPOINT ["dotnet", "UrbanFiesta.dll"]
# Build runtime image
# FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-alpine
# WORKDIR /app
# COPY --from=build-env /out .
