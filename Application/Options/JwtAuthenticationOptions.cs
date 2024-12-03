using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Options {
    public class JwtAuthenticationOption {
        public string Key { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
    }
}
