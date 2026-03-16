
using Dresses.Core.Entities;
using Dresses.Core.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dresses.Service
{
    public class UserService
    {
        private readonly IUserRepositories _UserRepository;

        public UserService(IUserRepositories UserRepository)
        {
            _UserRepository = UserRepository;
        }

        public async Task<List<Users>> GetUsersAsync()
        {
           
            return await _UserRepository.GetUsersAsync();
        }

        public async Task<Users> GetByIdAsync(int id)
        {
          
            return await _UserRepository.GetByIdAsync(id);
        }
        public async Task AddAsync(Users newuser)
        {
            await _UserRepository.AddAsync(newuser);
        }
        public async Task UpdateAsync(Users value, int id)
        {
            await _UserRepository.UpdateAsync(value, id);
        }
    }
}