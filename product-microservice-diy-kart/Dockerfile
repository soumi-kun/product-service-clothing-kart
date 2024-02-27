#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
# Use the .NET Core 3.1 runtime image as the base image
FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
# Set the working directory in the container
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
# Copy csproj and restore as distinct layers
COPY ["product-microservice-diy-kart/product-microservice-diy-kart.csproj", "product-microservice-diy-kart/"]
RUN dotnet restore "product-microservice-diy-kart/product-microservice-diy-kart.csproj"
# Copy the remaining source code
COPY . .
WORKDIR "/src/product-microservice-diy-kart"
# Build the application
RUN dotnet build "product-microservice-diy-kart.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "product-microservice-diy-kart.csproj" -c Release -o /app/publish

# Build runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "product-microservice-diy-kart.dll"]