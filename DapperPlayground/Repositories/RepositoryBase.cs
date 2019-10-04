using DapperPlayground.Interfaces;

namespace DapperPlayground.Repositories
{
    public abstract class RepositoryBase
    {
        protected readonly IConnectionFactory connectionFactory;
        public RepositoryBase(IConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }
    }
}
