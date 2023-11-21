# Proyecto Garden.

## Creacion de proyecto.
Utilizamos el metodo .bat el cual nos crea el proyecto con todas las carpetas, referencias, soluciones, entre otras..

## Creacion Entities y DbContext con DbFirts.
## Codigo que se debe usar para la creacion de entidades, configuraciones y Context del proyecto.
Con el DbFirts tambien podemos crear desde consola el archivo de 

´´´´
dotnet ef dbcontext scaffold "server=localhost;user=root;password=Helpsystem2020*;database=jardineria;" Pomelo.EntityFrameworkCore.MySqql -s GardenApi -p Persistence --context GardenContext --context-dir Data --output-dir Entities
´´´
