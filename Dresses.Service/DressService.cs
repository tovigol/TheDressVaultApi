using Dresses.Core.Entities;
using Dresses.Core.Repositories;
using Dresses.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dresses.Service
{
    public class DressService : IDressService
    {
        private readonly IDressRepository _dressRepository;
        public DressService(IDressRepository dressRepository)
        {
            _dressRepository = dressRepository;
        }
        public async Task<List<Dress>> GetDressesAsync()
        {

            return await _dressRepository.GetDressesAsync();
        }
        public async Task<Dress> GetByIdAsync(int id)
        {

            return await _dressRepository.GetByIdAsync(id);
        }
     
        public async Task UpdateAsync(Dress dress, int id)
        {

           await _dressRepository.UpdateAsync(dress,id);
        }
        public async Task AddAsync(Dress newDress)
        {
             await _dressRepository.AddAsync(newDress);

        }
        public async Task<IEnumerable<Dress>> GetByBusinessIdAsync(int businessId)
        {
            
            var allDresses = await _dressRepository.GetDressesAsync();
            return allDresses.Where(d => d.businessId == businessId);
        }
    }
}
