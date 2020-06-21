FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine AS build-env
WORKDIR /app
ENV PATH="${PATH}:/root/.dotnet/tools"
RUN dotnet tool install --global dotnet-ef

# Copy csproj and restore as distinct layers
COPY ./UrbanFiesta.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o /out

RUN dotnet ef database update
# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-alpine
WORKDIR /app
COPY --from=build-env /out .
ENTRYPOINT ["dotnet", "UrbanFiesta.dll"]
