using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManager.Application.Common.Exceptions;

public class UnauthorizedException : Exception
{
    public UnauthorizedException()
    { }
    public UnauthorizedException(string message) 
        : base(message)
    { }

    public UnauthorizedException(string message, Exception innerException) 
        : base(message, innerException)
    { }

    public UnauthorizedException(string message, object key)
        : base($"User :{message} with {key} is not authorized")
    { }
}
