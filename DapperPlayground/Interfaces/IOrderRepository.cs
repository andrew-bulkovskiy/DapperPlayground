using DapperPlayground.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DapperPlayground.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> Get(int id);
        Task<IEnumerable<Order>> All();
        Task Add(Order entity);
        Task Delete(int id);
        Task Update(Order entity);
    }
}
