using Dresses.Core.Entities;
using Dresses.Core.Repositories;
using Dresses.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dresses.Service
{
    public class RentalService : IRentalsService
    {
        private readonly IRentalsRepositories _rentalRepository;

        public RentalService(IRentalsRepositories rentalRepository)
        {
            _rentalRepository = rentalRepository;
        }

        public async Task<List<Rentals>> GetRentalsAsync()
        {
            return await _rentalRepository.GetRentalsAsync();
        }

        public async Task<Rentals> GetByIdAsync(int id)
        {
            return await _rentalRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Rentals rental, int rentalId)
        {
          
            await _rentalRepository.UpdateAsync(rental, rentalId);
        }

        public async Task AddAsync(Rentals newRental)
        {
            await CreateRentalAsync(newRental);
        }
        public async Task<bool> IsDressAvailableAsync(int dressId, DateTime startDate, DateTime endDate)
        {
   
            if (startDate >= endDate) return false;

            bool hasOverlap = await _rentalRepository.CheckOverlapExistsAsync(dressId, startDate, endDate);

            return !hasOverlap;
        }

        public async Task<Rentals> CreateRentalAsync(Rentals rental)
        {

            if (!await IsDressAvailableAsync(rental.dress_id, rental.start_date, rental.end_date))
            {
                throw new Exception("אופס... השמלה כבר תפוסה בתאריכים האלו.");
            }


            return await _rentalRepository.AddAsync(rental);
        }


    }
}