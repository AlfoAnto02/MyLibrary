using Application.Abstractions.Services;
using Application.Factories;
using Application.Models.Request;
using Application.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace MyLibrary.Controllers {
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TokenController : Controller {
        private readonly ITokenService _tokenService;
        public TokenController(ITokenService tokenService) {
            _tokenService = tokenService;
        }

        [HttpPost]
        [Route("authenticate")]
        public async Task<IActionResult> GenerateToken([FromBody] CreateTokenRequest createTokenRequest) {
            try {
                var token = await _tokenService.CreateToken(createTokenRequest);
                return Ok(ResponseFactory.WithSuccess(new CreateTokenResponse(token)));
            }
            catch (Exception ex) {
                return BadRequest(ResponseFactory.WithError(ex));
            }
        }
    }
}
