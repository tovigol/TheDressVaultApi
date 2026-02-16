using Dresses.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dresses.Core.Repositories
{
    public interface IDressRepository
    {
        public Task<List<Dress>> GetDressesAsync();
        public Task<Dress> GetByIdAsync(int id);
        public Task UpdateAsync(Dress dress,int id);
        public Task AddAsync(Dress newDress);
   
    }
}
