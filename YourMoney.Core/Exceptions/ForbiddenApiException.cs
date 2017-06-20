using System;
using System.Net;

namespace YourMoney.Core.Exceptions
{
    public class ForbiddenApiException : ApiException
    {
        private new const string Message = "Access to resource is forbidden";

        public ForbiddenApiException(Exception ex)
            : base(ex, HttpStatusCode.Forbidden, Message)
        {
        }

        public ForbiddenApiException()
            : base(HttpStatusCode.Forbidden, Message)
        {
        }
    }
}