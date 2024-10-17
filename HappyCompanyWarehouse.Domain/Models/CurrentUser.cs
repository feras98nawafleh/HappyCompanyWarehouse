using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HappyCompanyWarehouse.Domain.Models
{
    public class CurrentUser
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public string Id => _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier).Value ?? null;
    }
}
