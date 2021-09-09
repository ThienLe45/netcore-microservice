from mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim as base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:5.0-sdk AS build
WORKDIR /src
COPY ["Shopping.Client/Shopping.Client.csproj", "Shopping.Client/"]
RUN dotnet restore "Shopping.Client/Shopping.Client.csproj"
COPY . .
WORKDIR "/src/Shopping.Client"
RUN dotnet build "Shopping.Client.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Shopping.Client.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Shopping.Client.dll"]