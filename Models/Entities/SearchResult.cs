using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities {
    public class SearchResult<T> {
        public List<T> Result { get; set; }
        public int TotalNum { get; set; }

        public SearchResult(List<T> result, int totalNum) {
            this.Result = result;
            this.TotalNum = totalNum;
        }
    }
}
