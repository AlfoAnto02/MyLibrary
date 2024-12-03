using Application.Abstractions.Services;
using Application.Exceptions;
using Models.Entities;
using Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using Application.Models.Request;
using Application.Options;
using Castle.Core.Configuration;
using Microsoft.Extensions.Options;

namespace Application.Services {
    public class UserService : IUserService {

        public readonly UserRepository _userRepository;
        public readonly IOptions<HashingSettings> _settingsOptions; 

        public UserService(UserRepository userRepository, IOptions<HashingSettings> _settingsOptions) {
            this._userRepository = userRepository;
            this._settingsOptions = _settingsOptions;
        }

        public async Task AddAsync(User entity) {
            entity.Password = BCrypt.Net.BCrypt.HashPassword(entity.Password+_settingsOptions.Value.SecretKey);
            _userRepository.Add(entity);
            await _userRepository.SaveChangesAsync();
        }

        public async Task<User> GetAsync(int id) {
            var user = await _userRepository.GetAsync(id);
            if (user == null) {
                throw new WrongIdException(id);
            }
            return user;
        }


        public async Task<User> VerifyUserAsync(LoginRequest loginRequest)
        {
            var user = await GetByEmail(loginRequest.Email);
            if (IsPasswordValid(loginRequest.Password, user.Password))
            {
                return user;
            }
            throw new InvalidCredentialException();
        }

        public async Task<User> GetByEmail(string Email) {
            var user = await _userRepository.GetByEmail(Email);
            if (user == null) {
                throw new WrongEmailException(Email);
            }
            return user;
        }
        
        public bool IsPasswordValid(string password, string hashedPassword) {
            return BCrypt.Net.BCrypt.Verify(password+_settingsOptions.Value.SecretKey, hashedPassword);
        }

        public async Task<IEnumerable<User>> GetAllAsync() {
            return await _userRepository.GetAllAsync();
        }
    }
}
