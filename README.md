
## Refactorización y Reorganización del Proyecto

Se implementó una reestructuración completa del proyecto con el objetivo de mejorar la modularidad, la mantenibilidad y la claridad del código base. La arquitectura fue segmentada en directorios específicos según responsabilidad:

- `DB/` contiene la lógica relacionada con el acceso y manipulación de la base de datos.
- `CLI/` agrupa componentes destinados a la interacción por línea de comandos.
- `Class/` almacena las clases principales del dominio.
- `Interface/` define las interfaces esenciales para la abstracción de comportamientos.

Como parte de esta refactorización, se incorporaron dos interfaces clave para garantizar el cumplimiento de los principios SOLID:

`INormalizer` establece el contrato para la normalización de datos previos a su inserción en la base de datos. Su implementación se encargará de limpiar, formatear y asegurar la consistencia de los datos de entrada.

`IValidator` define los métodos necesarios para verificar si los datos están duplicados, ya existen en el sistema o violan alguna regla de validación definida.

Estas interfaces permiten desacoplar la lógica de validación y transformación de datos, promoviendo una arquitectura limpia y flexible.

A partir de esta versión, todo nuevo componente deberá seguir esta estructura para asegurar coherencia en el crecimiento del sistema.

