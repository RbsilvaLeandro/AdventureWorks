#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["AdventureWorks.API/AdventureWorks.API.csproj", "AdventureWorks.API/"]
COPY ["AdventureWorks.CrossCutting/AdventureWorks.CrossCutting.csproj", "AdventureWorks.CrossCutting/"]
COPY ["AdventureWorks.Application/AdventureWorks.Application.csproj", "AdventureWorks.Application/"]
COPY ["AdventureWorks.Domain.Core/AdventureWorks.Domain.Core.csproj", "AdventureWorks.Domain.Core/"]
COPY ["AdventureWorks.Domain/AdventureWorks.Domain.csproj", "AdventureWorks.Domain/"]
COPY ["AdventureWorks.Data/AdventureWorks.Data.csproj", "AdventureWorks.Data/"]
COPY ["AdventureWorks.Domain.Services/AdventureWorks.Domain.Services.csproj", "AdventureWorks.Domain.Services/"]
RUN dotnet restore "AdventureWorks.API/AdventureWorks.API.csproj"
COPY . .
WORKDIR "/src/AdventureWorks.API"
RUN dotnet build "AdventureWorks.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AdventureWorks.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AdventureWorks.API.dll"]