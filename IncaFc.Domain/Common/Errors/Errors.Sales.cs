using ErrorOr;

namespace IncaFc.Domain.Common.Errors;

public static partial class Errors
{
    public static class SaleDetailProduct
    {
        public static Error EmptySaleDetailProduct => Error.NotFound(
            code: "SaleDetailProduct.EmptySaleDetailProduct",
            description: "Datos vacios de productos"
        );
    }

    public static class SaleUpdate
    {
        public static Error UpdateSale => Error.NotFound(
            code: "SaleUpdate.EmptySale",
            description: "No se encontro Venta que modificar"
        );
    }

    public static class SaleDelete
    {
        public static Error DeleteSale => Error.NotFound(
            code: "SaleDelete.EmptySale",
            description: "No se encontro Venta que eliminar"
        );
    }

    public static class SaleGet
    {
        public static Error GetSale => Error.NotFound(
            code: "SaleDelete.EmptySale",
            description: "No se encontro Venta que eliminar"
        );
    }
}