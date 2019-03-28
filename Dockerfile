FROM mcr.microsoft.com/dotnet/core/aspnet:2.2

WORKDIR /app

COPY ./CRMSystemCoreWeb/outputs ./

ENTRYPOINT ["dotnet", "CRMSystemCoreWeb.dll"]
