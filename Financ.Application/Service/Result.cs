using Microsoft.AspNetCore.Identity;
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
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Idbank { get; private set; }
        public bool IsSuccess { get; private set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public T? Valeu { get; private set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<string>? Errors { get; private set; }

        private Result(int idbank, bool isSuccess, T? value, List<string>? errors)
        {
            Idbank = idbank;
            IsSuccess = isSuccess;
            Valeu = value;
            Errors = isSuccess ? null : errors ?? new List<string>();
        }
        private Result(bool isSuccess, T? value, List<string>? errors)
        {
            IsSuccess = isSuccess;
            Valeu = value;
            Errors = isSuccess ? null : errors ?? new List<string>();
        }
        private Result(bool isSuccess, List<string>? errors)
        {
            IsSuccess = isSuccess;
            Errors = isSuccess ? null : errors ?? new List<string>();
        }
        private Result(IEnumerable<IdentityError>? errors)
        {
            IsSuccess = false;
            Errors = errors?
           .Select(e => e.Description) 
           .ToList()
           ?? new List<string>();
        }
        public static Result<T> Success(int idbank, T value)
        {
            return new Result<T>(idbank, true, value, null);
        }
        public static Result<T> Success(T value)
        {
            return new Result<T>(true, value, null);
        }
        public static Result<T> Failure(int idbank, List<string> errors)
        {
            return new Result<T>(idbank, false, default, errors);
        }
        public static Result<T> Failure(IEnumerable<IdentityError> errors)
        {
            return new Result<T>(errors);
        }
        public static Result<T> Failure(string errors)
        {
            return new Result<T>(false, new List<string> { errors });
        }
        public static Result<T> Failure(int idbank, string errors)
        {
            return new Result<T>(idbank, false, default, new List<string> { errors });
        }
    }
}
