FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["AtualizarEstoqueAutomatico/AtualizarEstoqueAutomatico.csproj", "AtualizarEstoqueAutomatico/"]
RUN dotnet restore "AtualizarEstoqueAutomatico/AtualizarEstoqueAutomatico.csproj"
COPY . .
WORKDIR "/src/AtualizarEstoqueAutomatico"
RUN dotnet build "AtualizarEstoqueAutomatico.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AtualizarEstoqueAutomatico.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AtualizarEstoqueAutomatico.dll"]