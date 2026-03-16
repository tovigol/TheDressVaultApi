using Dresses.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dresses.Core.Services
{
    public interface IUserService
    {
        public Task <List<Users>> GetUsersAsync();
        public Task<Users> GetByIdAsync(int id);
        public Task  Update(Users user);
        public Task AddAsync(Users newuser);
        public Task UpdateAsync(Users value, int id);
    }
}
