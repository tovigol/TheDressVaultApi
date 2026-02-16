using Dresses.Core.Entities;
using Dresses.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dresses.Data
{
    public class BusinessRepository : IBusinessRepository
    {
        private readonly DataContext _context;
        public BusinessRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Business>> GetBusinessAsync() {
            return await _context.Business.ToListAsync();
        }
        public async Task<Business> GetBusinessByIdAsync(int id) {
            return await _context.Business.FirstOrDefaultAsync(d => d.business_id == id);
        }
        public async Task UpdateBusinessAsync(Business business, int id) {
            var existingBusiness = await _context.Business.FindAsync(id);
            existingBusiness.business_id = business.business_id;
            existingBusiness.nameBusiness = business.nameBusiness;
            await _context.SaveChangesAsync();
        }
        public async Task AddBusinessAsync(Business newBusiness) {
            _context.Business.Add(newBusiness);
            await _context.SaveChangesAsync();
        }







    }
}
