# Inca Fc API .NET 8

- [Inca Fc API .NET 8](#inca-fc-api-net-8)
  - [Autenticacion](#autenticacion)
    - [Register](#register)
      - [Register Request](#register-request)
      - [Register Response](#register-response)
    - [Login](#login)
      - [Login Request](#login-request)
      - [Login Response](#login-response)

## Autenticacion

### Register

```js
POST {{host}}/auth/register
```

#### Register Request

```json
{
    "firstName": "Carlos",
    "lastName": "Rodriguez",
    "email": "carmanuel1997@gmail.com",
    "password": "Carlos123!"
}
```

#### Register Response

```js
200 OK
```

```json
{
    "id": "d89c2d9a-eb3e-407595ff-b920b55aa104",
    "firstName": "Carlos",
    "lastName": "Rodriguez",
    "email": "carmanuel1997@gmail.com",
    "token": "eyJhb..hbbQ"
}
```

### Login

```js
POST {{host}}/auth/login
```

#### Login Request

```json
{
    "email": "carmanuel1997@gmail.com",
    "password": "Carlos123!"
}
```

#### Login Response

```js
200 OK
```

```json
{
    "id": "d89c2d9a-eb3e-407595ff-b920b55aa104",
    "firstName": "Carlos",
    "lastName": "Rodriguez",
    "email": "carmanuel1997@gmail.com",
    "token": "eyJhb..hbbQ"
}
```
