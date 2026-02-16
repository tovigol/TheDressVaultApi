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
        public List<Users> GetUsersAsync();
        public Dress GetByIdAsync(int id);
        void Update(Dress user);
        public void AddAsync(Dress newuser);
        void UpdateAsync(Dress value, int id);
    }
}
