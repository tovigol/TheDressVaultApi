using Dresses.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dresses.Core.Repositories
{
    public interface IRentalsRepositories
    {

        Task<IEnumerable<Rentals>> GetRentalsByDressIdAsync(int dressId);
        public Task<List<Rentals>> GetRentalsAsync();
        public Task<Rentals> GetByIdAsync(int id);
        public Task UpdateAsync(Rentals rental, int rental_id);
        public Task<Rentals> AddAsync(Rentals newRental);
       public Task<bool> CheckOverlapExistsAsync(int dressId, DateTime start, DateTime end);
    }
}
