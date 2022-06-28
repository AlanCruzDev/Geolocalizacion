FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS base
WORKDIR /app
EXPOSE 90

ENV ASPNETCORE_URLS=http://+:90

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /src
COPY ["src/MicroserverAdminCuestomers/Api/apicuestomers/apicuestomers.csproj", "src/MicroserverAdminCuestomers/Api/apicuestomers/"]
RUN dotnet restore "src/MicroserverAdminCuestomers/Api/apicuestomers/apicuestomers.csproj"
COPY . .
WORKDIR "/src/src/MicroserverAdminCuestomers/Api/apicuestomers"
RUN dotnet build "apicuestomers.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "apicuestomers.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "apicuestomers.dll"]
