#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SecondHandCarBidProject.AdminUI.GUI/SecondHandCarBidProject.AdminUI.GUI.csproj", "SecondHandCarBidProject.AdminUI.GUI/"]
COPY ["SecondHandCarBidProject.ApiService/SecondHandCarBidProject.ApiService.csproj", "SecondHandCarBidProject.ApiService/"]
COPY ["SecondHandCarBidProject.AdminUI.DTO/SecondHandCarBidProject.AdminUI.DTO.csproj", "SecondHandCarBidProject.AdminUI.DTO/"]
RUN dotnet restore "SecondHandCarBidProject.AdminUI.GUI/SecondHandCarBidProject.AdminUI.GUI.csproj"
COPY . .
WORKDIR "/src/SecondHandCarBidProject.AdminUI.GUI"
RUN dotnet build "SecondHandCarBidProject.AdminUI.GUI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SecondHandCarBidProject.AdminUI.GUI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SecondHandCarBidProject.AdminUI.GUI.dll"]