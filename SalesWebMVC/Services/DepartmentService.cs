using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace SalesWebMVC.Services
{
    public class DepartmentService
    {
        private readonly SWContext _context;

        public DepartmentService(SWContext context)
        {
            _context = context;
        }

        //import System.Threading.Tasks;
        //add property "async" and trade type to return a Task<>
        //add "await" before the command line
        //trade return to a async method (ToListAsync, FindByIdAsync... etc)
        public async Task<List<Department>> FindAllAsync()
        {
            return await _context.Department.OrderBy(x => x.Nome).ToListAsync();
        }
    }
}
