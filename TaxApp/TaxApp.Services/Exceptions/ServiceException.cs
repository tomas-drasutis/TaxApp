using System;

namespace TaxApp.Services.Exceptions
{
    public class ServiceException : Exception
    {
        public ServiceExceptionType Type { get; }

        public ServiceException(ServiceExceptionType type)
        {
            Type = type;
        }

        public ServiceException(ServiceExceptionType type, string message) : base(message)
        {
            Type = type;
        }
    }
}
