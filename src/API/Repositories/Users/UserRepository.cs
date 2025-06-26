using API.Data;
using API.Interfaces.Repositories;
using API.Models;
using Microsoft.EntityFrameworkCore;
using API.Utils;

namespace API.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetByEmailAndPasswordAsync(string email, string passwordHash)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.email == email && u.password == passwordHash);
        }

    }
}
