using Dresses.Core.Entities;
using Dresses.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dresses.Service
{
   public class RentalService
    {
        private readonly IRentalsRepositories _rentalRepository;
        public RentalService(IRentalsRepositories RentalRepository)
        {
            _rentalRepository = RentalRepository;
        }

        public IRentalsRepositories Get_rentalRepository()
        {
            return _rentalRepository;
        }

        public async Task<List<Rentals>> GetRentalAsync(IRentalsRepositories _rentalRepository)
        {
            return await _rentalRepository.GetRentalsAsync();
        }
        public async Task<Rentals> GetByIdAsync(int id)
        {
            return await _rentalRepository.GetByIdAsync(id);
        }
        public async Task UpdateAsync(Rentals rental, int rental_id)
        {

            await _rentalRepository.UpdateAsync(rental, rental_id);
        }
        public async Task AddAsync(Rentals newRental)
        {
            await _rentalRepository.AddAsync(newRental);

        }

    }
}
