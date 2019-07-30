using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMVC.Models;


namespace SalesWebMVC.Services
{
    public class SellerService
    {
        private readonly SWContext _context;

        public SellerService(SWContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }
    }
}
