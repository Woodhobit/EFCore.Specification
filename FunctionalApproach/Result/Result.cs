using System;
using System.Linq;

namespace FunctionalApproach.Result
{
    public class Result
    {
        public string Error { get; }
        public bool Success => Error == null;
        public bool Failure => !Success;

        protected Result(string error)
        {
            if (string.IsNullOrEmpty(error))
                throw new ArgumentException();

            this.Error = error;
        }

        public static Result Fail(string message)
        {
            return new Result(message);
        }

        public static Result Ok()
        {
            return new Result(null);
        }

        public static Result Combine(params Result[] results)
        {
            var failed = results.FirstOrDefault(x => x.Failure);
            if (failed != null)
                return failed;

            return Ok();
        }
    }

    public class Result<T> : Result
    {
        public T Value { get; }

        protected Result(T value, string error) : base(error)
        {
            this.Value = value;
        }

        public static Result<T> Ok<T>(T value) => new Result<T>(value, null);

        public static Result<T> Fail<T>(string error) => new Result<T>(default(T), error);
    }
}
