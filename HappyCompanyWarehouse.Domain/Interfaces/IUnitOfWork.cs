using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyCompanyWarehouse.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IWareHousesRepository WareHouses { get; }
        IWareHouseItemsRepository WareHouseItems { get; }
        IUsersRepository Users { get; }
        IRolesRepository Roles { get; }
        ICountriesRepository Countries { get; }
        Task<int> Commit();
    }
}
