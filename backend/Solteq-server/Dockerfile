FROM mcr.microsoft.com/dotnet/sdk:8.0 AS base
WORKDIR /backend

# ENV variables
# ENV ASPNETCORE_ENVIRONMENT=Development
# ENV ASPNETCORE_HTTP_PORTS= 
# ENV ASPNETCORE_ENVIRONMENT=Production
# ENV DOTNET_ENVIRONMENT=Production
COPY . .

RUN apt-get update && apt-get -y install sudo

RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"

FROM base AS build
WORKDIR /src
COPY ["Solteq-server.csproj", "./"]
RUN dotnet restore
COPY . .
WORKDIR "/src/."
RUN dotnet build "Solteq-server.csproj" -c Release -o /backend/build

FROM build AS publish
RUN dotnet publish -c Release -o /backend/publish /p:UseAppHost=false


FROM base AS final

WORKDIR /backend
COPY --from=publish /backend/publish .
ENTRYPOINT dotnet run