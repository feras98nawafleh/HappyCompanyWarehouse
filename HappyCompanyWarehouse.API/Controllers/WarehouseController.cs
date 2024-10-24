using HappyCompanyWarehouse.Domain.DTOs;
using HappyCompanyWarehouse.Domain.Models;
using HappyCompanyWarehouse.Domain.Models.Response;
using HappyCompanyWarehouse.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HappyCompanyWarehouse.API.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    public class WarehouseController : ControllerBase
    {
        private WareHouseService _wareHouseService;
        public WarehouseController(WareHouseService wareHouseService)
        {
            _wareHouseService = wareHouseService;
        }

        [HttpGet("GetWarehouse")]
        public async Task<ActionResult<ResponseEnvelop<Warehouse>>> GetWarehouse(int warehouseId)
        {
            var data = await _wareHouseService.GetWarehouse(warehouseId);
            var response = new ResponseEnvelop<Warehouse>()
                .SetSuccess(true)
                .SetResult(data)
                .SetResultMessage("Success")
                .SetStatusCode(System.Net.HttpStatusCode.OK)
                .Build();

            return Ok(response);
        }

        [HttpGet("GetWarehouses")]
        public async Task<ActionResult<ResponseEnvelop<List<WarehouseDTO>>>> GetWarehouses()
        {
            var data = await _wareHouseService.GetWarehouses();
            var response = new ResponseEnvelop<List<WarehouseDTO>>()
                .SetSuccess(true)
                .SetResult(data)
                .SetResultMessage("Success")
                .SetStatusCode(System.Net.HttpStatusCode.OK)
                .Build();

            return Ok(response);
        }

        [HttpPost("AddWarehouse")]
        public async Task<ActionResult<ResponseEnvelop<WarehouseDTO>>> AddWarehouse(WarehouseDTO warehouse)
        {
            var data = await _wareHouseService.AddWareHouse(warehouse);
            var response = new ResponseEnvelop<WarehouseDTO>()
                .SetSuccess(true)
                .SetResult(data)
                .SetResultMessage("Success")
                .SetStatusCode(System.Net.HttpStatusCode.OK)
                .Build();

            return Ok(response);
        }

    }
}
