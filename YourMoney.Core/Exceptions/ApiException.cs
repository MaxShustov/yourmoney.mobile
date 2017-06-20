using System;
using System.Net;

namespace YourMoney.Core.Exceptions
{
    public class ApiException : Exception
    {
        private new const string Message = "API error";

        public HttpStatusCode StatusCode { get; private set; }

        public ApiException(Exception ex, HttpStatusCode statusCode, string message = Message)
            : base(message, ex)
        {
            StatusCode = statusCode;
        }

        public ApiException(HttpStatusCode statusCode, string message = Message)
            : base(message)
        {
            StatusCode = statusCode;
        }
    }
}