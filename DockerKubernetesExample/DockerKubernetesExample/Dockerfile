#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-bionic AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-bionic AS build
WORKDIR /src
COPY ["DockerKubernetesExample/DockerKubernetesExample.csproj", "DockerKubernetesExample/"]
RUN dotnet restore "DockerKubernetesExample/DockerKubernetesExample.csproj"
COPY . .
WORKDIR "/src/DockerKubernetesExample"
RUN dotnet build "DockerKubernetesExample.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DockerKubernetesExample.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DockerKubernetesExample.dll"]
