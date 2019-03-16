FROM mcr.microsoft.com/dotnet/core/sdk:2.2.105-nanoserver-1809 AS build

COPY . /app
WORKDIR /app

RUN dotnet restore
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2.3-nanoserver-1809 AS runtime

WORKDIR /app
COPY --from=build /app/CRMSystemCoreWeb/out ./

ENTRYPOINT ["dotnet", "CRMSystemCoreWeb.dll"]
