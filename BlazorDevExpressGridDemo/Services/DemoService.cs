using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BlazorDevExpressGridDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorDevExpressGridDemo.Services
{
    public class DemoService
    {
        private readonly MyDbContext _dbContext;

        public DemoService(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Role>> GetRolesAsync(CancellationToken token)
        {
            return await _dbContext.Roles.ToListAsync(token);
        }

        public async Task<IEnumerable<Department>> GetDepartmentsAsync(CancellationToken token)
        {
            return await _dbContext.Departments.ToListAsync(token);
        }
    }
}
