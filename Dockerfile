FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app    
EXPOSE 80

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /src
COPY ["Catalog.csproj", "./"]
RUN dotnet restore "Cataog.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Catalog.csproj" -c Release -o /app/build