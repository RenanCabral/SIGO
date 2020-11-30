#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/runtime-deps:3.1.0-alpine3.10 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1.100 AS build
WORKDIR /src
COPY ["/SIGO.RegulatoryNorms.API/SIGO.RegulatoryNorms.API.csproj", "SIGO.RegulatoryNorms.API/"]
RUN dotnet restore "SIGO.RegulatoryNorms.API/SIGO.RegulatoryNorms.API.csproj"
COPY . .
WORKDIR "/src/SIGO.RegulatoryNorms.API"
RUN dotnet build "SIGO.RegulatoryNorms.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SIGO.RegulatoryNorms.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SIGO.RegulatoryNorms.API.dll"]