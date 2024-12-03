using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Responses {
    public class GetEntitiesResponse<T> {
        public List<T> Entities { get; set; } = new List<T>();
    }
}
