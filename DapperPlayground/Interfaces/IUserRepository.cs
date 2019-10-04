using DapperPlayground.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DapperPlayground.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetAsync(int id);
        Task<IEnumerable<User>> AllAsync();
        Task AddAsync(User entity);
        Task DeleteAsync(int id);
        Task UpdateAsync(User entity);
    }
}
