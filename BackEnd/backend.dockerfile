FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Restaurar los archivos de proyecto de las bibliotecas de clases
COPY TaskManagement.Application/*.csproj ./TaskManagement.Application/
COPY TaskManagement.Domain/*.csproj ./TaskManagement.Domain/
COPY TaskManagement.Infraestructure/*.csproj ./TaskManagement.Infraestructure/

# Restaurar los archivos de proyecto de la API
COPY TaskManagement.Api/*.csproj ./TaskManagement.Api/

# Restaurar las dependencias de los proyectos
RUN dotnet restore ./TaskManagement.Api/*.csproj

# Copiar el resto de los archivos del proyecto
COPY . .

# Compilar y publicar la API
RUN dotnet publish -c Release -o out ./TaskManagement.Api/*.csproj

# Configurar la imagen de producción
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app/out .
EXPOSE 5000
ENTRYPOINT ["dotnet", "TaskManagement.Api.dll"]
