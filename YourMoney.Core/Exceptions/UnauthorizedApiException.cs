using System;
using System.Net;

namespace YourMoney.Core.Exceptions
{
    public class UnauthorizedApiException : ApiException
    {
        private new const string Message = "Unauthorized";

        public UnauthorizedApiException(Exception ex)
            : base(ex, HttpStatusCode.Forbidden, Message)
        {
        }

        public UnauthorizedApiException()
            : base(HttpStatusCode.Forbidden, Message)
        {
        }
    }
}