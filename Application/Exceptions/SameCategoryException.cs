using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions {
    public class SameCategoryException : Exception {
        public SameCategoryException(string name, int id) : base($"Category with name {name} already exists with id {id}") {
        }
    }
}
