# Usar la imagen base de .NET 8
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5126
EXPOSE 7126

# Construcción de la aplicación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar archivos de solución y restaurar dependencias
COPY ["EmployeeApi/EmployeeApi.csproj", "EmployeeApi/"]
COPY ["Employee.Presentation/Employee.Presentation.csproj", "Employee.Presentation/"]
RUN dotnet restore "EmployeeApi/EmployeeApi.csproj"

# Copiar y publicar la aplicación
COPY . .
WORKDIR "/src/EmployeeApi"
RUN dotnet build -c Release -o /app/build
RUN dotnet publish -c Release -o /app/publish

# Configurar la imagen final
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "EmployeeApi.dll"]