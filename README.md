# Proyecto .NET

## Descripción
Este proyecto es una aplicación desarrollada en .NET utilizando Entity Framework Core para la gestión de base de datos.

## Requisitos
- .NET SDK instalado
- Base de datos configurada (SQL Server, PostgreSQL, etc.)
- Entity Framework Core instalado

## Instalación
1. Clona este repositorio:
   ```sh
   git clone https://github.com/vortechpe/backendEmployee.git
   cd proyecto-dotnet
   ```

2. Restaura las dependencias:
   ```sh
   dotnet restore
   ```

3. Configura la cadena de conexión en `appsettings.json`.

4. Aplica las migraciones de base de datos:
   ```sh
   dotnet ef database update
   ```

## Comandos útiles
- Crear una nueva migración:
  ```sh
  dotnet ef migrations add NombreDeLaMigracion
  ```

- Aplicar migraciones a la base de datos:
  ```sh
  dotnet ef database update
  ```

- Ejecutar el proyecto:
  ```sh
  dotnet run
  ``
