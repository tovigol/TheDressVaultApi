using Dresses.Core.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dresses.Core.Services
{
    public interface IRentalsService
    {
  
        public Task <List<Rentals>> GetRentalsAsync();
        public Task<Rentals> GetByIdAsync(int id);
        public Task UpdateAsync(Rentals rental, int rental_id);
        public Task AddAsync(Rentals newRental);
    }
}
