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
        public Dresess GetByIdAsync(int id);
        void Update(Dresess user);
        public void AddAsync(Dresess newuser);
        void UpdateAsync(Dresess value, int id);
    }
}
