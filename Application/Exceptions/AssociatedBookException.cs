using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions {
    public class AssociatedBookException : Exception {
        public AssociatedBookException(string message) : base($"Category is associated with this list of Books: {message}") {

        }

    }
}
