using Microsoft.EntityFrameworkCore;
using Models.Context;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repositories {
    public class UserRepository : GenericRepository<User> {
        public UserRepository(MyDBContext context) : base(context) {
        }

        public async Task<User> GetByEmail(string email) {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower());
        }

        public async Task<User> GetByEmailAndPassword(string email, string password) {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower() && u.Password == password);
        }
    }
}
