using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Validation
{
    internal class DomainValidationExeption : Exception
    {
        public DomainValidationExeption(string error): base(error)
        {

        }

        public static void When(bool hasError, string message)
        {
            if(hasError) 
                   throw new DomainValidationExeption(message);   
        }
    }
}
