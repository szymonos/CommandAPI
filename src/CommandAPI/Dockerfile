FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/CommandAPI/CommandAPI.csproj", "src/CommandAPI/"]
RUN dotnet restore "src/CommandAPI/CommandAPI.csproj"
COPY . .
WORKDIR "/src/src/CommandAPI"
RUN dotnet build "CommandAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CommandAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CommandAPI.dll"]
