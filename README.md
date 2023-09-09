
# Web Api Rest 

- Es una Api Rest que usa los protocolos HTTP para obtener, modificar, eliminar y actualizar distintos tipos de Yerba Mate.
- Se implento:
    - Entity Framework.
    - Inyección de dependencias tanto para la conexion de base de datos y servicios.
    

## Authors

- [@Marcos](https://github.com/Marcos-E-cabrera)


## API Reference

### Get all elements

```http
  GET /api/Yerba/Get

  Request body:
  {
    "id": 1,
    "nombre": "Playadito",
    "cantidad": 10
  }
```

| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| - | `string` | - |

#### Description:

Este endpoint se utiliza para obtener todos los elementos de Yerba Mate.

#### Response:

- 200 OK: Se devuelve cuando la solicitud se completa con éxito y se incluyen los datos solicitados.
- 404 Not Found: Se devuelve cuando no se encuentran datos correspondientes a la solicitud.


### Get Yerba

```http
  GET /api/Yerba/GetById/{id}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `int` | **Required**. Id of item to fetch |

#### Description:

Este endpoint se utiliza para obtener un elemento de Yerba Mate específico por su ID.

#### Response:

- 200 OK: Se devuelve cuando se encuentra y se incluye el elemento solicitado.
- 404 Not Found: Se devuelve cuando el elemento no se encuentra.

### Update Yerba

```http
  PUT /api/Yerba/Put/{id}

  Request body:
  {
    "nombre": "",
    "cantidad": 0
  }
```

| Parameter | Type   | Description               |
| :-------- | :----- | :------------------------ |
| `Id`   | `int` | **Required**. Id of item to update |
| `Yerba`   | `json` | **Required**. Yerba data |

#### Description:

Este endpoint se utiliza para actualizar un elemento de Yerba Mate existente por su ID.

#### Response:

- 200 OK: Se devuelve cuando la actualización se completa con éxito.
- 200 (false): Se devuelve cuando el elemento a actualizar no se encuentra.

### Add Yerba

```http
  POST /api/Yerba/Post

  Request body:
  {
    "nombre": "",
    "cantidad": 0
  }
```

| Parameter | Type   | Description               |
| :-------- | :----- | :------------------------ |
| `Yerba`   | `json` | **Required**. Yerba data |

#### Description:

Este endpoint se utiliza para agregar un nuevo elemento de Yerba Mate.

#### Response:

- 200 OK:  Se devuelve cuando la adición se completa con éxito.

### Delete Yerba

```http
  DELETE /api/Yerba/Delete/{id}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `int` | **Required**. Id of item to fetch |

#### Description:

Este endpoint se utiliza para eliminar un elemento de Yerba Mate existente por su ID.


#### Response:

- 200 OK: Se devuelve cuando la eliminación se completa con éxito.
- 200 (false): Se devuelve cuando el elemento a eliminar no se encuentra.


