using Dresses.Core.Entities;
using Dresses.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dresses.Data
{
    public class DressRepository : IDressRepository
    {
        private readonly DataContext _context;
        public DressRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Dresess>> GetDressesAsync()

        {
            return await _context.Dresses.ToListAsync();
        }
        public async Task<Dresess> GetByIdAsync(int id)
        {
            // דוגמה ליישום באמצעות ה-Repository
            return await _context.Dresses.FirstOrDefaultAsync(d => d.dress_id == id);
        }

        public async Task UpdateAsync(Dresess dress, int id)
        {
            var existingDress = await _context.Dresses.FindAsync(id); 
            existingDress.description = dress.description;
            existingDress.name = dress.name;
            existingDress.dress_id = id;
            existingDress.size = dress.size;
            existingDress.rental_price = dress.rental_price;
            await _context.SaveChangesAsync();
        }
        public async Task AddAsync(Dresess newDress)
        {
            _context.Dresses.Add(newDress);
            await _context.SaveChangesAsync();
        }


    }
}


