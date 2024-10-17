using HappyCompanyWarehouse.Domain;
using HappyCompanyWarehouse.Domain.Interfaces;
using HappyCompanyWarehouse.Domain.Models;

namespace HappyCompanyWarehouse.DAL.Repositories
{
    public class CountriesRepository : GenericRepository<Country>, ICountriesRepository
    {
        public CountriesRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
