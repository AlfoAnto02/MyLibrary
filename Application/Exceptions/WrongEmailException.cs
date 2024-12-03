using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions {
    public class WrongEmailException : Exception {
        public WrongEmailException(string email) : base($"Email {email} is not registered") { }
    }
}
