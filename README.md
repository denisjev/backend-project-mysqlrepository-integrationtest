# Ejercicio 7 (Pruebas de integración sobre el ejercicio 6)

En este proyecto se han creado pruebas de integración con xUnit y FluentAssertions para probar el ejercicio 6.

## Test a realizar

1. Probar el método GetAll del repositorio.
2. Probar el GetById del repositorio.
3. Probar el método Add del repositorio.

## Ejecución del contenedor MySQL con la base de datos

La ejecución del contenedor se hace desde un archivo docker-compose.yml. Para ello debemos abrir una terminal y ubicarnos en la carpeta Api/Data/ de la solución y desde ahí ejecutar el siguiente comando:

```
docker-compose up
```

## Ejecución de los tests

Para probar la aplicación se deberá ejecutar el siguiente comandos desde la terminal, hubicados dentro de la carpeta IntegrationTest de la solución.

```
dotnet test
```
