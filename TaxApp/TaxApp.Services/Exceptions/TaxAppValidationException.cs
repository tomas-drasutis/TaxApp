using System;

namespace TaxApp.Services.Exceptions
{
    public class TaxAppValidationException : Exception
    {
        public TaxAppValidationException(string message) : base(message)
        {
        }
    }
}
