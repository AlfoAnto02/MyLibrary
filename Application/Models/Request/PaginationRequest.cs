using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Application.Models.Request {
    public class PaginationRequest {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        [JsonIgnore]
        public int totalNum { get; set; } = 0;
    }
}
