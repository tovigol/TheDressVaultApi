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
    public class RentalRepository:IRentalsRepositories
    {
        private readonly DataContext _context;
        public RentalRepository(DataContext context)
        {
            _context = context;
        }

       public async Task<List<Rentals>> GetRentalsAsync()
        {
            return await _context.Rentals.ToListAsync();
        }
        public async Task<Rentals> GetByIdAsync(int id) {
            return await _context.Rentals.FirstOrDefaultAsync(d => d.rental_id == id);
        }
        public async Task<Rentals> AddAsync(Rentals newRental)
        {
                await _context.Rentals.AddAsync(newRental);
                await _context.SaveChangesAsync();
                return newRental;     
        }
        public async Task UpdateAsync(Rentals rental, int rental_id)
        {
            var existingRental = await _context.Rentals.FindAsync(rental_id);
            existingRental.start_date=rental.start_date;
            existingRental.end_date=rental.end_date;
            existingRental.total_price=rental.total_price;
            existingRental.User = rental.User;
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Rentals>> GetRentalsByDressIdAsync(int dressId)
        {
            return await _context.Rentals
                .Where(r => r.dress_id == dressId)
                .ToListAsync();
        }

    }
}
