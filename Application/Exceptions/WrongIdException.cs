using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions {
    public class WrongIdException : Exception {

        public WrongIdException(int id) : base($"The id: {id} is not valid") { }
    }
}
