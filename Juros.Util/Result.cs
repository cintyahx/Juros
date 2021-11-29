using FluentValidation.Results;
using System.Collections.Generic;

namespace Juros.Util
{
    public class Result<T>
    {
        public T Data { get; set; }
        public bool Error { get; set; }
        public List<ValidationFailure> Errors { get; set; } = new List<ValidationFailure>();

        public Result(T data)
        {
            Data = data;
        }

        public Result(List<ValidationFailure> errors)
        {
            Error = true;
            Errors = errors;
        }

        public Result()
        {

        }
    }
}
