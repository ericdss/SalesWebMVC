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

        public async Task<List<Seller>> FindAllAsync()
        {
            return await _context.Seller.ToListAsync();
        }

        public async Task InsertAsync(Seller seller)
        {
            _context.Seller.Add(seller);
            await _context.SaveChangesAsync();
        }

        public async Task<Seller> FindByIdAsync(int id)
        {
            return await _context.Seller.Include(x=> x.Department).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            //var seller = _context.Seller.Where(x => x.Id == id).SingleOrDefault();
            var seller = await _context.Seller.SingleOrDefaultAsync(x => x.Id == id);
            _context.Seller.Remove(seller);
            await _context.SaveChangesAsync();  
        }
        
        public async Task UpdateAsync(Seller obj)
        {
            bool hasAny = await _context.Seller.AnyAsync(x => x.Id == obj.Id);
            if (hasAny)
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
                    await _context.SaveChangesAsync();
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
