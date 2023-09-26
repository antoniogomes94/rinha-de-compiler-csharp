FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY ["src/RinhaInterpreter/RinhaInterpreter/RinhaInterpreter.csproj", "./"]

RUN dotnet restore "RinhaInterpreter.csproj"

COPY ./src/ ./

COPY ./files/ ./files/

WORKDIR "/src/"

RUN dotnet build "RinhaInterpreter/RinhaInterpreter/RinhaInterpreter.csproj" -c Release -o /app/build


FROM build AS publish
RUN dotnet publish "RinhaInterpreter/RinhaInterpreter/RinhaInterpreter.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY --from=build ./src/files ./files
CMD ["dotnet", "RinhaInterpreter.dll", "/var/rinha/source.rinha.json"]