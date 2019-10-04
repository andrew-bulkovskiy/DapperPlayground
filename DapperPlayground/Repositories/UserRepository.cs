using Dapper;
using DapperPlayground.Entities;
using DapperPlayground.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace DapperPlayground.Repositories
{
    class UserRepository : RepositoryBase, IUserRepository
    {
        public UserRepository(IConnectionFactory connectionFactory) : base(connectionFactory) { }

        public async Task<User> GetAsync(int id)
        {
            using (IDbConnection conn = connectionFactory.GetOpenConnection())
            {
                var sql = "SELECT * FROM Users WHERE UserID = @UserID";
                var param = new { UserID = id };
                var transaction = conn.BeginTransaction();
                return await conn.QueryFirstOrDefaultAsync<User>(sql, param, transaction);
            }
        }

        public async Task<IEnumerable<User>> AllAsync()
        {
            using (IDbConnection conn = connectionFactory.GetOpenConnection())
            {
                var sql = "SELECT * FROM Users";
                var transaction = conn.BeginTransaction();
                return await conn.QueryAsync<User>(sql, transaction: transaction);
            }
        }

        public async Task AddAsync(User entity)
        {
            using (IDbConnection conn = connectionFactory.GetOpenConnection())
            {
                var sql = "INSERT INTO Users(Username, Email) VALUES (@Username, @Email)";
                var param = new { Username = entity.Username, Email = entity.Email };
                var transaction = conn.BeginTransaction();
                await conn.ExecuteAsync(sql, param, transaction);
                transaction.Commit();
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (IDbConnection conn = connectionFactory.GetOpenConnection())
            {
                var sql = "DELETE FROM Users WHERE UserID = @UserID";
                var param = new { UserID = id };
                var transaction = conn.BeginTransaction();
                await conn.ExecuteAsync(sql, param);
                transaction.Commit();
            }
        }

        public async Task UpdateAsync(User entity)
        {
            using (IDbConnection conn = connectionFactory.GetOpenConnection())
            {
                var sql = "UPDATE Users SET Username = @Username, Email = @Email  WHERE UserID = @UserID";
                var param = new { UserID = entity.UserID, Username = entity.Username, Email = entity.Email };
                var transaction = conn.BeginTransaction();
                await conn.ExecuteAsync(sql, param, transaction);
                transaction.Commit();
            }
        }
    }
}
