using ErrorOr;

namespace IncaFc.Domain.Common.Errors;

public static partial class Errors
{
    public static class Authentication
    {
        public static Error InvalidCredentials => Error.Validation(
            code: "Auth.InvalidCred",
            description: "Las credenciales son invalidas."
        );
    }
}