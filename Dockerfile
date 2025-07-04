FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Dr Majdoline Aldee.csproj", "."]
RUN dotnet restore "Dr Majdoline Aldee.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "./Dr Majdoline Aldee.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Dr Majdoline Aldee.csproj" -c $BUILD_CONFIGURATION -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS=http://*:$PORT
EXPOSE $PORT
ENTRYPOINT ["dotnet", "Dr Majdoline Aldee.dll"]