using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions {
    public class SameUserException : Exception {
        public SameUserException(string email) : base($"The user with the email {email} is already registered") { }
    }
}
