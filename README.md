## API produtos/categorias

Api criada para cadastrar produtos e categorias, onde cada produto pode ter uma categoria e diversos produtos podem ter a mesma categoria.

## Como usar:

Clonando o repositório e rodando a aplicação localmente a api já vai estar pronta pra uso.

## exemplos de algumas rotas sus corpos e retornos:

### /categoria


GET (sem corpo)

status 200
```
  {
    "id": 0,
    "nome": "string",
    "descricao": "string"
  }
```

POST

corpo:

```
{
  "id": 0,
  "nome": "string",
  "descricao": "string"
}
```

status 200

### /categoria/{id}

GET

```
{
"id": 0,
}
```

retorno (status 200)

```
[
  {
    "id": 0,
    "nome": "string",
    "descricao": "string"
  }
]
```

### /produto

GET (sem corpo)

status 200
```
{
    "id": 0,
    "nome": "string",
    "descricao": "string",
    "categoriaId": 0,
    "categoria": {
      "id": 0,
      "nome": "string",
      "descricao": "string"
    }
  }
```
POST

corpo:

```
{
  "id": 0,
  "nome": "string",
  "descricao": "string"
  "categoriaId": 0,
}
```

retorno:

```
{
    "id": 0,
    "nome": "string",
    "descricao": "string",
    "categoriaId": 0,
    "categoria": {
      "id": 0,
      "nome": "string",
      "descricao": "string"
    }
  }
```
