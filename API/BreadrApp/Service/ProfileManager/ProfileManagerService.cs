using AutoMapper;
using Breadr.Service.Gate.Models;
using Breadr.Service.ProfileManager.Models;
using DataAccess.DBContext;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Intrinsics.Arm;
using Breadr.Service.ProfileManager.Dtos;
using Breadr.Service.Gate.Dtos;
using DataAccess.Models;
using System.Security.Cryptography.X509Certificates;

namespace Breadr.Service.ProfileManager
{
    public class ProfileManagerService : IProfileManagerService
    {

        private readonly BreadrDbContext _context;
        private readonly IMapper _mapper;

        public ProfileManagerService(BreadrDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<UserLoginResponse> UserLogin(UserLoginRequest request)
        {
            UserLoginResponse response = new UserLoginResponse()
            {
                Request = request
            };

            string salt = await _context.Users.Where(x => x.Username.Equals(request.Username))
                .Select(x => x.Salt).FirstOrDefaultAsync();
            if(salt == null)
            {
                response.Message = "User not exist";
                return response;
            }
            string password = salt + request.Password;
            string hashPassword;
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashValue = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                hashPassword = BitConverter.ToString(hashValue).Replace("-", "");
                hashPassword = hashPassword.ToLower();
            }
            string pass = await _context.Users.Where(x => x.Username.Equals(request.Username))
                .Select(x => x.Password).FirstOrDefaultAsync();
            if (hashPassword.Equals(pass))
            {
                UserDto userDto = await _context.Users.Where(x => x.Username.Equals(request.Username))
                    .Select(x => new UserDto
                    {
                        Name = x.Username,
                        Surname = x.Surname,
                        Username = x.Username,
                        Email = x.Email,
                        RoleId = x.RoleId
                    }).FirstOrDefaultAsync();

                response.User = userDto;
                response.Success = true;

                return response;

            }
            else
            {
                response.Message = "Wrong password";
                return response;
            }

        }

        public async Task<UserRegisterResponse> UserRegister(UserRegisterRequest request)
        {
            UserRegisterResponse response = new UserRegisterResponse()
            {
                Request = request
            };

            string usernameExists = await _context.Users.Where(x => x.Username.Equals(request.Username))
                .Select(x=>x.Username).FirstOrDefaultAsync();
            if (usernameExists != null)
            {
                response.Message = "Username exists";
                return response;

            }

            string salt = GenerateRandomNumber().ToString();
            string password = salt + request.Password;
            string hashPassword;
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashValue = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                hashPassword = BitConverter.ToString(hashValue).Replace("-", "");
                hashPassword = hashPassword.ToLower();
            }


            User user = new()
            {
                Username = request.Username,
                Active = 1,
                Email = request.Email,
                Surname = request.Surname,
                Name = request.Username,
                Password = hashPassword,
                RoleId = 2,
                Salt = salt,


            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            User addedUser = await _context.Users.Where(x => x.UserId == user.UserId).FirstOrDefaultAsync();
            UserDto userDto = _mapper.Map<User, UserDto>(addedUser);

            response.User = userDto;
            response.Success = true;

            return response;

        }

        public int GenerateRandomNumber()
        {
            int _min = 1000;
            int _max = 9999;
            Random _rdm = new Random();
            return _rdm.Next(_min, _max);
        }
    }
}
