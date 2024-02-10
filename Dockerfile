FROM mcr.microsoft.com/dotnet/aspnet:8.0 as base
WORKDIR /restaurant
#Define PORT for HTTP & HTTPS
EXPOSE 80
EXPOSE 81
# Build runtime image
FROM mcr.microsoft.com/dotnet/sdk:8.0 as build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["restaurant/restaurant.csproj", "restaurant/"]
COPY ["restaurant-test/restaurant-test.csproj", "restaurant-test/"]

# Restore as distinct layers
RUN dotnet restore "restaurant/restaurant.csproj"

COPY . .
WORKDIR /src/restaurant
RUN dotnet build "restaurant.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish 
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "restaurant.csproj" -c $BUILD_CONFIGURATION -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT [ "dotnet", "restaurant.dll" ]


#OLD
#RUN dotnet publish -c Release -o out
#WORKDIR /restaurant
#COPY --from=build-env /restaurant/out .
#ENTRYPOINT ["dotnet", "restaurant.dll","--urls=http://+:5001"]