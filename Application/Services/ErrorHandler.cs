
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ElementNotFoundException : Exception
    {
        public ElementNotFoundException(string message) : base(message) { }
    }

    public class ListEmptyException : Exception
    {
        public ListEmptyException(string message) : base(message) { }
    }

    public class InvalidDateFormatException : Exception
    {
        public InvalidDateFormatException(string message) : base(message) { }
    }

    public class InvalidTimeFormatException : Exception
    {
        public InvalidTimeFormatException(string message) : base(message) { }
    }

    public class ElementDoesNotExistException : Exception
    {
        public ElementDoesNotExistException(string message) : base(message) { }
    }

    public class ParseFailedException : Exception
    {
        public ParseFailedException(string message) : base(message) { }
    }
}
