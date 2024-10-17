using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HappyCompanyWarehouse.Domain.Models
{
    public class User
    {
        [Key] public int Id { get; set; }
        public string FullName{ get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string HashedPassword { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public bool Active { get; set; } = true;

        public static User CreateAdmin()
        {
            return new User
            {
                Id = 1,
                FullName = Constants.ADMIN,
                Username = Constants.USERNAME_DEFAULT,
                Email = Constants.EMAIL_DEFAULT,
                HashedPassword = MethodHelper.ComputeSHA512Hash(Constants.PASSWORD_DEFAULT),
                Role = Constants.ROLE_ADMIN
            };
        }
    }

    public static class MethodHelper
    {
        public static string ComputeSHA512Hash(string input)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = SHA512.HashData(inputBytes);

            var sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
