using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Request {
    public class UpdateBookRequest {
        public int bookToUpdateId { get; set; }
        public AddBookRequest Book { get; set; } = new AddBookRequest();
    }
}
