using Microsoft.EntityFrameworkCore;
using PrestigePathway.DataAccessLayer.Abstractions.RepositoryAbstractions;
using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.DataAccessLayer.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SocialServicesDbContext _context;

        public UserRepository(SocialServicesDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}