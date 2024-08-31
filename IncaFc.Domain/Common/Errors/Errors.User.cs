using ErrorOr;

namespace IncaFc.Domain.Common.Errors;

public static partial class Errors
{
    public static class User
    {
        public static Error DuplicateEmail => Error.Conflict(
            code: "User.DuuplicateEmail",
            description: "El correo electrónico ya esta en uso."
        );
    }
}