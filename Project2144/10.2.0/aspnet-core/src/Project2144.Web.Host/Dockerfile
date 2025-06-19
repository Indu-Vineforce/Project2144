FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src
COPY ["src/Project2144.Web.Host/Project2144.Web.Host.csproj", "src/Project2144.Web.Host/"]
COPY ["src/Project2144.Web.Core/Project2144.Web.Core.csproj", "src/Project2144.Web.Core/"]
COPY ["src/Project2144.Application/Project2144.Application.csproj", "src/Project2144.Application/"]
COPY ["src/Project2144.Core/Project2144.Core.csproj", "src/Project2144.Core/"]
COPY ["src/Project2144.EntityFrameworkCore/Project2144.EntityFrameworkCore.csproj", "src/Project2144.EntityFrameworkCore/"]
WORKDIR "/src/src/Project2144.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/Project2144.Web.Host", "src/Project2144.Web.Host"]
COPY ["src/Project2144.Web.Core", "src/Project2144.Web.Core"]
COPY ["src/Project2144.Application", "src/Project2144.Application"]
COPY ["src/Project2144.Core", "src/Project2144.Core"]
COPY ["src/Project2144.EntityFrameworkCore", "src/Project2144.EntityFrameworkCore"]
WORKDIR "/src/src/Project2144.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "Project2144.Web.Host.dll"]
