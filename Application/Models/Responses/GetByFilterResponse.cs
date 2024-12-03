using Application.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Responses {
    public class GetByFilterResponse {
        public List<BookDTO> Books { get; set; }
        public int pageSize { get; set; }
    }
}
