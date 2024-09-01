# Domain Models

## Productos > Product

- **Producto ID** => `ProductId`: Identificador unico del producto.
- **Nombre** => `Name`: Nombre del producto.
- **Descripcion** => `Description`: Descripciin del producto.
- **Categoria ID** (FK) => `CategoryId`: Clave forinea de la categoria.
- **MarcaID** (FK) => `BrandId`: Clave foranea de la marca.

```csharp
public class Product
{
    public Guid ProductId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid CategoryId { get; set; }
    public Guid BrandId { get; set; }
}
```

## Categorias > Category

- **Categoria ID** > `CategoryId`: Identificador unico de la categoria.
- **Nombre** > `Name`: Nombre de la categoria.

```csharp
public class Category
{
    public Guid CategoryId { get; set; }
    public string Name { get; set; }
}
```

## Marcas > Brand

- **Marca ID** > `BrandId`: Identificador unico de la marca.
- **Nombre** > `Name`: Nombre de la marca.

```csharp
public class Brand
{
    public Guid BrandId { get; set; }
    public string Name { get; set; }
}
```

## Precios > Price

- **Precio ID** => `PriceId`: Identificador unico del precio.
- **Producto ID (FK)** => `ProductId`: Clave foranea del producto.
- **Precio** => `PriceAmount`: Precio del producto.
- **UnidadMedida** => `Unit`: Unidad de medida del precio.

```csharp
public class Price
{
    public Guid PriceId { get; set; }
    public Guid ProductId { get; set; }
    public decimal PriceAmount { get; set; }
    public UnitOfMeasure Unit { get; set; }
}
```

## Ubicaciones > Location

- **Ubicacion ID** => `LocationId`: Identificador unico de la ubicaci�n.
- **Direccion** => `Address`: Direccion de la ubicacion.
- **ProductoID (FK)** => `ProductId`: Clave foranea del producto.
- **Stock** => `Stock`: Cantidad de stock disponible en la ubicacion.

```csharp
public class Location
{
    public Guid LocationId { get; set; }
    public string Address { get; set; }
    public Guid ProductId { get; set; }
    public int Stock { get; set; }
}
```

## Clientes > Client

- **Cliente ID** => `ClientId`: Identificador unico del cliente.
- **Nombre** => `Name`: Nombre del cliente.
- **TipoCliente** => `Type`: Tipo de cliente (Individual o Empresa).
- **Contacto (opcional)** => `Contact`: Contacto del cliente, aplicable solo si es una empresa.

```csharp
public class Client
{
    public Guid ClientId { get; set; }
    public string Name { get; set; }
    public ClientType Type { get; set; }
    public string Contact { get; set; }
}
```

## Ventas > Sales

- **Venta ID** => `SaleId`: Identificador unico de la venta.
- **Cliente ID (FK)** => `ClientId`: Clave foranea del cliente.
- **Fecha** => `Date`: Fecha de la venta.
- **Estado** => `State`: Estado de la venta (Activa o Anulada).

```csharp
public class Sale
{
    public Guid SaleId { get; set; }
    public Guid ClientId { get; set; }
    public DateTime Date { get; set; }
    public SaleState State { get; set; }
}
```

## Detalle de Ventas SaleDetail

- **DetalleVenta ID** => `aleDetailId`: Identificador unico del detalle de venta.
- **VentaID (FK)** => `SaleId`: Clave foranea de la venta.
- **Producto ID (FK)** => `ProductId`: Clave foranea del producto.
- **Cantidad** => `Quantity`: Cantidad del producto vendido.
- **PrecioUnitario** => `UnitPrice`: Precio unitario del producto.
- **BaseImponible** => `TaxableBase`: Base imponible del detalle.
- **IGV** => `IGV`: Impuesto General a las Ventas aplicado.
- **Total** => `Total`: Total del detalle de venta.

```csharp
public class SaleDetail
{
    public Guid SaleDetailId { get; set; }
    public Guid SaleId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TaxableBase { get; set; }
    public decimal IGV { get; set; }
    public decimal Total { get; set; }
}
```

## Anulaciones > Cancellation

- **Anulacion ID** => `CancellationId`: Identificador unico de la anulacion.
- **Venta ID (FK)** => `SaleId`: Clave foranea de la venta anulada.
- **Motivo** => `Reason`: Motivo de la anulacion.
- **FechaAnulacion** => `CancellationDate`: Fecha de la anulacion.

```csharp
public class Cancellation
{
    public Guid CancellationId { get; set; }
    public Guid SaleId { get; set; }
    public string Reason { get; set; }
    public DateTime CancellationDate { get; set; }
}
```

## Usuario > User

- **Usuario ID** => `UserId`: Identificador unico del usuario.
- **Nombre** => `FirstName`: Nombre del usuario.
- **Apellido** => `LastName`: Apellido del usuario.
- **Correo** => `Email`: Correo del usuario.
- **Contraseña** => `Password`: Contraseña del usuario.

```csharp
public class User
{
    public Guid UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}
```

> Nota: Las contraseñas no deberían estar tiradas por ahi
