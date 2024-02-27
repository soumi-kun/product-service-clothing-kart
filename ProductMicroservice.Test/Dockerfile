#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /app

COPY ["ProductMicroservice.Test/ProductMicroservice.Test.csproj", "ProductMicroservice.Test/"]
RUN dotnet restore "ProductMicroservice.Test/ProductMicroservice.Test.csproj"
COPY . .

CMD ["dotnet", "test"]

