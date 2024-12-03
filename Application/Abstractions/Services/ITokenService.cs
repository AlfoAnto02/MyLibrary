﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models.Request;

namespace Application.Abstractions.Services {
    public interface ITokenService {
        Task<string> CreateToken(CreateTokenRequest createTokenRequest);
    }
}
