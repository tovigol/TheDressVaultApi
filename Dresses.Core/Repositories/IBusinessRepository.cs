using Dresses.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dresses.Core.Repositories
{
    public interface IBusinessRepository
    {
        public Task<List<Business>> GetBusinessAsync();
        public Task<Business> GetBusinessByIdAsync(int id);
        public Task UpdateBusinessAsync(Business business, int id);
        public Task AddBusinessAsync(Business newBusiness);
    }
}
