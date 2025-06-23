using API.Models;

namespace API.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAndPasswordAsync(string email, string password);
    }
}
