using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManager.Application.Common.Exceptions
{
    public class AlreadyExistsException : Exception
    {
        public AlreadyExistsException()
            : base() { }

        public AlreadyExistsException(string name, string key)
            : base($"Entity \"{name}\" ({key}) already exists") { }
    }
}
