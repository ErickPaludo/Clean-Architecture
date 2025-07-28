using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Financ.Application.Service
{
    public class Result<T> where T : class
    {
        public bool IsSuccess { get; private set; }
        public T? Valeu { get; private set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<string>? Errors { get; private set; }

        private Result(bool isSuccess, T? value, List<string>? errors)
        {
            IsSuccess = isSuccess;
            Valeu = value;
            Errors = isSuccess ? null : errors ?? new List<string>();
        }
        public static Result<T> Success(T value)
        {
            return new Result<T>(true, value, null);
        }
        public static Result<T> Failure(List<string> errors)
        {
            return new Result<T>(false, default, errors);
        } 
        public static Result<T> Failure(string errors)
        {
            return new Result<T>(false, default, new List<string> { errors });
        }
    }
}
