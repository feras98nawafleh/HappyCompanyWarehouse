using HappyCompanyWarehouse.Domain;
using HappyCompanyWarehouse.Domain.Interfaces;
using HappyCompanyWarehouse.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace HappyCompanyWarehouse.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private bool disposedValue;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            WareHouses = new WarehousesRepository(_context);
            WareHouseItems = new WarehouseItemsRepository(_context);
            Users = new UsersRepository(_context);
            Roles = new RolesRepository(_context);
            Countries = new CountriesRepository(_context);

        }

        public IWareHousesRepository WareHouses { get; private set; }

        public IWareHouseItemsRepository WareHouseItems { get; private set; }

        public IUsersRepository Users { get; private set; }

        public IRolesRepository Roles { get; private set; }

        public ICountriesRepository Countries { get; private set; }

        public async Task<int> Commit()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
