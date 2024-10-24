using HappyCompanyWarehouse.DAL.Repositories;
using HappyCompanyWarehouse.Domain.DTOs;
using HappyCompanyWarehouse.Domain.Interfaces;
using HappyCompanyWarehouse.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyCompanyWarehouse.Services
{
    public class UserService
    {
        private IUnitOfWork _unitOfWork;
        private IAuthService _authService;
        private CurrentUser _currentUser;
        public UserService(IUnitOfWork unitOfWork, IAuthService authService, CurrentUser currentUser)
        {
            _unitOfWork = unitOfWork;
            _currentUser = currentUser;
            _authService = authService;
        }

        public async Task<UserDTO> AddUser(UserDTO userDTO)
        {
            var exists = await _unitOfWork.Users.Find(u => u.Username == userDTO.Username || u.Email == userDTO.Email);
            if(exists is not null)
            {
                return null;
            }
            var user = new User()
            {
                Username = userDTO.Username,
                FullName = userDTO.FullName,
                Email = userDTO.Email,
                HashedPassword = MethodHelper.ComputeSHA512Hash(userDTO.Password),
                Active = true,
                RoleId = userDTO.RoleId,
            };

            await _unitOfWork.Users.Add(user);
            return userDTO;
        }

        public async Task<UserDTO> GetUser(int userId)
        {
            var user = await _unitOfWork.Users.GetById(userId);
            var userDTO = new UserDTO()
            {
                Id = user.Id,
                FullName = user.FullName,
                Username = user.Username,
                Email = user.Email,
                RoleId = user.RoleId
            };
            return userDTO;
        }

        public async Task<List<UserDTO>> GetUsers()
        {
            var usersList = new List<UserDTO>();
            var users = await _unitOfWork.Users.GetAll();
            foreach (var user in users)
            {
                usersList.Add(new UserDTO()
                {
                    Id = user.Id,
                    FullName = user.FullName,
                    Username = user.Username,
                    Email = user.Email,
                    RoleId = user.RoleId
                });
            }

            return usersList;
        }

        public async Task<UserDTO> UpdateUser(UserDTO userDTO)
        {
            var user = await _unitOfWork.Users.GetById(userDTO.Id);
            
            user.FullName = userDTO.FullName;
            user.RoleId = userDTO.RoleId;
            user.Username = userDTO.Username;
            user.Email = userDTO.Email;
            await _unitOfWork.Commit();

            return userDTO;
        }
    }
}
