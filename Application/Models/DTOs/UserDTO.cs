using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.DTOs {
    public class UserDTO {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public UserDTO(User user) {
            Id = user.Id;
            Name = user.Name;
            Surname = user.Surname;
            Email = user.Email;
            Password = user.Password;
        }
    }
}
