using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Request {
    public class SearchRequest {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string CategoryName { get; set; } = string.Empty;
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string BookName { get; set; } = string.Empty;
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Author { get; set; } = string.Empty;
        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public DateTime PublicationDate { get; set; }
        public PaginationRequest Pagination { get; set; }
    }
}
