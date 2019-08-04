using SalesWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SalesWebMVC.Services
{
    public class SalesRecordService
    {
        private readonly SWContext _context;

        public SalesRecordService(SWContext context)
        {
            _context = context;
        }

        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var query = _context.SalesRecord.Select(x=> x);

            if(minDate.HasValue)
            {
                query = query.Where(x => x.Date >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                query = query.Where(x => x.Date <= maxDate.Value);
            }

            return await query.Include(x=> x.Seller).Include(x=> x.Seller.Department).OrderByDescending(x=> x.Date).ToListAsync();
        }
    }
}
