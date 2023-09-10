
# Web Api Rest 

- Es una Api Rest que usa los protocolos HTTP para obtener, modificar, eliminar y actualizar distintos tipos de Yerba Mate.
- Se implento:
    - Entity Framework.
    - Inyeccion de Dependencia tanto para la conexion de base de datos y servicios.
    
    

## Authors

- [@Marcos](https://github.com/Marcos-E-cabrera)


## API Reference

### Obtener todos los elementos

#### Descripción:
Este endpoint se utiliza para obtener una lista de todos los elementos de Yerba Mate.

#### URL del Endpoint:
```http
  GET /api/Yerba/Get
```
#### Parámetros:

| Parametros | Tipo     | Descripción                |
| :-------- | :------- | :------------------------- |
| - | `string` | - |


#### Respuesta:
- 200 OK: La solicitud se completó con éxito. Se devuelve una lista de elementos de Yerba Mate.
- 404 Not Found: No se encontraron elementos de Yerba Mate.

---

### Obtener elemento por ID

#### Descripción:
Este endpoint se utiliza para obtener un elemento de Yerba Mate específico por su ID.

#### URL del Endpoint:

```http
  GET /api/Yerba/GetById/{id}
```

#### Parámetros:
| Parametros | Tipo     | Descripción                |
| :-------- | :------- | :------------------------- |
| `id`      | `int` | **Requiere** ID del item a buscar|

#### Respuesta:
- 200 OK: Se devuelve cuando se encuentra y se incluye el elemento solicitado.
- 404 Not Found: Se devuelve cuando el elemento no se encuentra.
---
### Actualizar elemento

#### Descripción:
Este endpoint se utiliza para actualizar un elemento de Yerba Mate existente por su ID.

#### URL del Endpoint:
```http
  PUT /api/Yerba/Put
```
#### Parámetros:
| Parameter | Type   | Description               |
| :-------- | :----- | :------------------------ |
| `Id`   | `int` | **Requiere** ID el item a actualizar |
| `Yerba`   | `json` | **Requiere** Yerba data |

#### Respuesta:
- 200 OK: Se devuelve cuando la actualización se completa con éxito.
- 400 BadRequest: Muestra cual fue el error.

#### Ejemplo de Cuerpo de Solicitud (Request Body)
```Json
  {
    "id": "1"
    "nombre": "xxxxx",
    "cantidad": 10
  }
```
---
### Agregar elemento

#### Descripción:
Este endpoint se utiliza para agregar un nuevo elemento de Yerba Mate.

#### URL del Endpoint:

```http
  POST /api/Yerba/Post
```
#### Parámetros:

| Parametros | Tipo     | Descripción                |
| :-------- | :------- | :------------------------- |
| `Yerba`   | `json` | **Requiere** Yerba data |

#### Response:
- 200 OK: Se devuelve cuando la adición se completa con éxito.
- 400 BadRequest: Muestra cual fue el error.

#### Ejemplo de Cuerpo de Solicitud (Request Body)
```Json
  {
    "nombre": "xxxxx",
    "cantidad": 12
  }
```

---
### Delete Yerba

#### Descripción:
Este endpoint se utiliza para eliminar un elemento de Yerba Mate existente por su ID.

#### URL del Endpoint:
```http
  DELETE /api/Yerba/Delete/{id}
```
#### Parámetros:
| Parametros | Tipo     | Descripción                |
| :-------- | :------- | :------------------------- |
| `id`      | `int` | **Requiere** ID del item a buscar|

#### Response:

- 200 OK: Se devuelve cuando la eliminación se completa con éxito.
- 400 BadRequest: Muestra cual fue el error.


