﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Responses {
    public class CreateTokenResponse {
        public string Token { get; set; }
        public CreateTokenResponse(string token) {
            Token = token;
        }
    }
}
