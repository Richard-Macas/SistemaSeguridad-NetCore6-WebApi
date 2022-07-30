using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaSeguridad.Entities.Response
{
    public class ResponseData<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Result { get; set; }

        public ResponseData(bool success, string message, T result)
        {
            Success = success;
            Message = message;
            Result = result;
        }

    }
}
