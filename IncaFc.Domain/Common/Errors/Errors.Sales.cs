using ErrorOr;

namespace IncaFc.Domain.Common.Errors;

public static partial class Errors
{
    public static class CreateSale
    {
        public static Error EmptySaleDetailProduct =>
            Error.NotFound(
                code: "CreateSale.EmptySaleDetailProduct",
                description: "No existe ese producto"
            );
        public static Error OutOfStock =>
            Error.NotFound(
                code: "CreateSale.OutOfStock",
                description: "El producto no cuenta con stock"
            );
    }

    public static class UpdateSale
    {
        public static Error UpdateSaleCancellation =>
            Error.NotFound(
                code: "UpdateSale.Cancellation",
                description: "No se encontro Venta que modificar"
            );
    }

    public static class DeleteSale
    {
        public static Error DeleteSaleComplete =>
            Error.NotFound(
                code: "DeleteSale.Complete",
                description: "No se encontro Venta que eliminar"
            );
    }

    public static class GetSale
    {
        public static Error GetSaleOne =>
            Error.NotFound(code: "GetSale.On", description: "No se encontro venta realizada");
    }
}
