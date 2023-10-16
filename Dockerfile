FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /egen

COPY *.csproj ./

RUN dotnet restore

COPY . ./

RUN dotnet publish -c Release -o out --self-contained

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /egen
COPY --from=build /egen/out ./

