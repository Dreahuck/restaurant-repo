FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /restaurant

# Copy everything
COPY . ./

ENV ASPNETCORE_URLS http://*:5000
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /restaurant
COPY --from=build-env /restaurant/out .
ENTRYPOINT ["dotnet", "restaurant.dll"]