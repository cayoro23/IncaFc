# Inca Fc API .NET 8

- [Inca Fc API .NET 8](#inca-fc-api-net-8)
  - [Auth](#auth)
    - [Register](#register)
      - [Register Request](#register-request)
      - [Register Response](#register-response)
    - [Login Response](#login-response)

## Auth

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

### Login Response

```json
{
    "id": "d89c2d9a-eb3e-407595ff-b920b55aa104",
    "firstName": "Carlos",
    "lastName": "Rodriguez",
    "email": "carmanuel1997@gmail.com",
    "token": "eyJhb..hbbQ"
}
```
