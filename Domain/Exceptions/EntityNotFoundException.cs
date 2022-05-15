using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(object? value = null) =>
            Value = value;

        public int StatusCode { get;}
        public object? Value { get;}

    }
}
