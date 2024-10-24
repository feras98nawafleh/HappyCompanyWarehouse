using HappyCompanyWarehouse.Domain.DTOs;
using HappyCompanyWarehouse.Domain.Interfaces;
using HappyCompanyWarehouse.Domain.Models;
using HappyCompanyWarehouse.Services;

namespace HappyCompanyWarehouse.Services
{
    public class WareHouseService
    {
        private IUnitOfWork _unitOfWork;
        private CurrentUser _currentUser;

        public WareHouseService(IUnitOfWork unitOfWork, CurrentUser currentUser)
        {
            _unitOfWork = unitOfWork;
            _currentUser = currentUser;
        }

        public async Task<WarehouseDTO> AddWareHouse(WarehouseDTO warehouseDTO)
        {
            var warehouse = new Warehouse()
            {
                Address = warehouseDTO.Address,
                City = warehouseDTO.City,
                Name = warehouseDTO.Name,
                CountryId = warehouseDTO.CountryId
            };
            await _unitOfWork.WareHouses.Add(warehouse);
            return warehouseDTO;
        }

        public async Task<Warehouse> GetWarehouse(int warehouseId)
        {
            return await _unitOfWork.WareHouses.GetById(warehouseId);
        }

        public async Task<List<WarehouseDTO>> GetWarehouses()
        {
            var warehousesList = new List<WarehouseDTO>();
            var warehouses = await _unitOfWork.WareHouses.GetAll();

            foreach(var warehouse in warehouses)
            {
                warehousesList.Add(new WarehouseDTO()
                {
                    Id = warehouse.Id,
                    Name = warehouse.Name,
                    Address = warehouse.Address,
                    City = warehouse.City,
                    CountryId = warehouse.CountryId
                });
            }

            return warehousesList;
        }
    }
}