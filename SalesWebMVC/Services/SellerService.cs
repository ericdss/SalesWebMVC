using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMVC.Models;
using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Services.Exceptions;

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

        public void Insert(Seller seller)
        {
            _context.Seller.Add(seller);
            _context.SaveChanges();
        }

        public Seller FindById(int id)
        {
            return _context.Seller.Include(x=> x.Department).FirstOrDefault(x => x.Id == id);
        }

        public void Remove(int id)
        {
            //var seller = _context.Seller.Where(x => x.Id == id).SingleOrDefault();
            var seller = _context.Seller.SingleOrDefault(x => x.Id == id);
            _context.Seller.Remove(seller);
            _context.SaveChanges();
        }
        
        public void Update(Seller obj)
        {
            if (_context.Seller.Any(x=> x.Id == obj.Id))
            {
                try
                {
                    //var seller = _context.Seller.First(x => x.Id == obj.Id);
                    //seller.Name = obj.Name;
                    //seller.Email = obj.Email;
                    //seller.BirthDate = obj.BirthDate;
                    //seller.BaseSalary = obj.BaseSalary;
                    //seller.Department = obj.Department;
                    _context.Update(obj);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException e)
                {
                    throw new DbConcurrencyExeption(e.Message);
                }
            }
            else
            { 
                throw new NotFoundExeption("Id do vendedor não encontrado não encontrado");
            }
        }
    }
}
