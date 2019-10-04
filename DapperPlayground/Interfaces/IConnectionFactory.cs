using System.Data;

namespace DapperPlayground.Interfaces
{
    public interface IConnectionFactory
    {
        IDbConnection GetOpenConnection();
    }
}
