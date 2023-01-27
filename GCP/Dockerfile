#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["GCP/GCP.csproj", "GCP/"]
COPY ["GCP.BLL/GCP.BLL.csproj", "GCP.BLL/"]
COPY ["GCP.Common/GCP.Common.csproj", "GCP.Common/"]
COPY ["GCP.Repositories/GCP.DAL.csproj", "GCP.Repositories/"]
RUN dotnet restore "GCP/GCP.csproj"
COPY . .
WORKDIR "/src/GCP"
RUN dotnet build "GCP.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GCP.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GCP.dll"]