#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/runtime-deps:3.1.0-alpine3.10 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1.100 AS build
WORKDIR /src
COPY ["SIGO.IndustrialProcess.API/SIGO.IndustrialProcess.API.csproj", "SIGO.IndustrialProcess.API/"]
RUN dotnet restore "SIGO.IndustrialProcess.API/SIGO.IndustrialProcess.API.csproj"
COPY . .
WORKDIR "/src/SIGO.IndustrialProcess.API"
RUN dotnet build "SIGO.IndustrialProcess.API.csproj" -c Release -o /app/build -r alpine-x64

FROM build AS publish
RUN dotnet publish "SIGO.IndustrialProcess.API.csproj" -c Release -o /app/publish -r alpine-x64

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-alpine
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SIGO.IndustrialProcess.API.dll"]