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
        public Task<List<Dresess>> GetDressesAsync();
        public Task<Dresess> GetByIdAsync(int id);
        public Task UpdateAsync(Dresess dress,int id);
        public Task AddAsync(Dresess newDress);
    }
}
