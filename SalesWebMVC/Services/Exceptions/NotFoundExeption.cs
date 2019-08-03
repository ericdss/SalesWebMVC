using System;

namespace SalesWebMVC.Services.Exceptions
{
    public class NotFoundExeption : ApplicationException
    {
        public NotFoundExeption(string e) : base(e)
        {
        }
    }
}
