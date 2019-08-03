using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVC.Services.Exceptions
{
    public class DbConcurrencyExeption : ApplicationException
    {
        public DbConcurrencyExeption(string message) : base(message)
        {
        }
    }
}
