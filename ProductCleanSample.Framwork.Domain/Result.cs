using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCleanSample.Framwork.Domain
{
    public class Result
    {
        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public Error Error { get; }

        public Result(bool isSuccess, Error error)
        {
            if (isSuccess && error != Error.None || !isSuccess && error == Error.None)
            {
                throw new ArgumentException("Invalid Result", nameof(error));
            }

            IsSuccess = isSuccess;
            Error = error;
        }

        public static Result Success() => new(true, Error.None);

        public static Result<TValue> Success<TValue>(TValue value) => new(value, true, Error.None);

        public static Result Failure(Error error) => new(false, error);

        public static Result<TValue> Failure<TValue>(Error error) => new(default, false, error);
    }

    public class Result<TValue> : Result
    {
        private readonly TValue? _value;

        public Result(TValue? value, bool isSuccess, Error error)
            : base(isSuccess, error) => _value = value;

        public TValue Value =>
            IsSuccess ? _value! : throw new InvalidOperationException("Result is null");

        public static implicit operator Result<TValue>(TValue? value) =>
            value is not null ? Success(value) : Failure<TValue>(Error.NullValue);
    }


}
