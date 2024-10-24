using HappyCompanyWarehouse.Domain;
using HappyCompanyWarehouse.Domain.Interfaces;
using HappyCompanyWarehouse.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace HappyCompanyWarehouse.DAL.Repositories
{
    public class UsersRepository : GenericRepository<User>, IUsersRepository
    {
        public UsersRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<User> GetUserWithRole(int userId)
        {
            var user = await base._context.Users.Where(u => u.Id == userId).Include(u => u.Role).FirstOrDefaultAsync();
            return user;
        }
    }
}
