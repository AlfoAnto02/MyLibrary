using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Request {
    public class AddUserRequest {
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public User ToEntity() {
            return new User {
                Name = Name,
                Surname = Surname,
                Email = Email,
                Password = Password
            };
        }
    }
}
