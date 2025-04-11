using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCleanSample.Framwork.Domain
{
    public class Error
    {
        public static readonly Error None = new(string.Empty, string.Empty, ErrorType.Failure);
        public static readonly Error NullValue =
            new("Error:NullValue", "Result value us null", ErrorType.Failure);

        public string Code { get; }
        public string Description { get; }
        public ErrorType Type { get; }

        private const string Separator = ":";

        public Error(string code, string description, ErrorType type)
        {
            Code = code;
            Description = description;
            Type = type;
        }

        public override string ToString() => $"{Type}{Separator}{Code}{Separator}{Description}";

        public static Error Failure(string code, string description) =>
            new(code, description, ErrorType.Failure);

        public static Error Validation(string code, string description) =>
            new(code, description, ErrorType.Validation);

        public static Error Problem(string code, string description) =>
            new(code, description, ErrorType.Problem);

        public static Error NotFound(string code, string description) =>
            new(code, description, ErrorType.NotFound);

        public static Error Conflict(string code, string description) =>
            new(code, description, ErrorType.Conflict);
    }
}
