FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build

WORKDIR /src
COPY ["./InitialCore.WebRESTfulApi/InitialCore.WebRESTfulApi.csproj","./"]
RUN dotnet restore "InitialCore.WebRESTfulApi.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "./InitialCore.WebRESTfulApi/InitialCore.WebRESTfulApi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "./InitialCore.WebRESTfulApi/InitialCore.WebRESTfulApi.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app . 
ENTRYPOINT ["dotnet", "InitialCore.WebRESTfulApi.dll"]
