using Dresses.Core.Entities;
using Dresses.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dresses.Data
{
    public class UserRepository : IUserRepositories
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        // ודאי שהשם כאן זהה בדיוק למה שכתוב ב-IUserRepositories
        public async Task<List<Users>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<Users> GetByIdAsync(int id)
        {
            // שימוש ב-user_id כפי שמוגדר ב-Entity שלך
            return await _context.Users.FirstOrDefaultAsync(u => u.user_id == id);
        }

        public async Task UpdateAsync(Users users, int id)
        {
            var existingUser = await _context.Users.FindAsync(id);
            if (existingUser != null)
            {
                existingUser.username = users.username;
                existingUser.email = users.email;
                existingUser.password_hash = users.password_hash;

                // תיקון השורה הקטועה:
                existingUser.phone_number = users.phone_number;

                await _context.SaveChangesAsync();
            }
        }

        public async Task AddAsync(Users newUsers)
        {
            _context.Users.Add(newUsers);
            await _context.SaveChangesAsync();
        }
    }
}