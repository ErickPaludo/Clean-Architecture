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
        public int Idbank { get; private set; }
        public bool IsSuccess { get; private set; }
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
        public static Result<T> Success(int idbank, T value)
        {
            return new Result<T>(idbank,true, value, null);
        }
        public static Result<T> Failure(int idbank,List<string> errors)
        {
            return new Result<T>(idbank, false, default, errors);
        } 
        public static Result<T> Failure(int idbank,string errors)
        {
            return new Result<T>(idbank,false, default, new List<string> { errors });
        }
    }
}
