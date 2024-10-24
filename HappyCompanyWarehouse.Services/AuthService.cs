using HappyCompanyWarehouse.Domain.DTOs;
using HappyCompanyWarehouse.Domain.Interfaces;
using HappyCompanyWarehouse.Domain.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HappyCompanyWarehouse.Services
{
    public interface IAuthService
    {
        Task<string> Login(LoginDTO loginDTO);
        string Generate(User user);
        Task<string> Refresh();
    }
    public class AuthService : IAuthService
    {
        private IUnitOfWork _unitOfWork;
        private CurrentUser _currentUser;
        public AuthService(IUnitOfWork unitOfWork, CurrentUser currentUser)
        {
            _unitOfWork = unitOfWork;
            _currentUser = currentUser;
        }

        public async Task<string> Login(LoginDTO loginDTO)
        {
            var user = await _unitOfWork.Users.Find(u =>
                u.Username == loginDTO.username &&
                u.HashedPassword == MethodHelper.ComputeSHA512Hash(loginDTO.password));

            if (user is null)
            {
                return null;
            }

            return Generate(user);
        }

        public string Generate(User user)
        {
            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new(ClaimTypes.UserData, user.FullName)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Constants.TOKEN_KEY));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var now = DateTime.Now;

            var tokenDescriptor = new JwtSecurityToken(
                "HappyWareHouse-Company",
                "HappyWareHouse-Users",
                claims,
                now,
                now.AddMinutes(Constants.TOKEN_EXPIRATION_IN_MINUTES),
                credentials
            );

            var token = tokenHandler.WriteToken(tokenDescriptor);
            return token;
        }

        public async Task<string> Refresh()
        {
            var user = await _unitOfWork.Users.GetById(Int32.Parse(_currentUser.Id));
            return Generate(user);
        }
    }
}
