using Dresses.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dresses.Core.Repositories
{
    public interface IUserRepositories
    {
        public Task<List<Users>> GetUsersAsync();
        public Task<Users> GetByIdAsync(int id);
        public Task UpdateAsync(Users user, int id);
        public Task AddAsync(Users newuser);
      
    }
}
