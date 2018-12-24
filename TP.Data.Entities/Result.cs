using System;
using System.Collections.Generic;
using System.Text;

namespace TP.Data.Entities
{
    public class Result
    {

        public Result()
        {
            IsSuccess = true;
        }

        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public string Content { get; set; }
    }

    public class Result<T> : Result
    {
        public T Data { get; set; }
    }
}
