using PrestigePathway.DataAccessLayer.Models;
using System.Threading.Tasks;

namespace PrestigePathway.DataAccessLayer.Abstractions.RepositoryAbstractions
{
    public interface IUserRepository
    {
        Task<User> GetUserByUsernameAsync(string username);
        Task AddUserAsync(User user);
    }
}