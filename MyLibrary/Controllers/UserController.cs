using Application.Abstractions.Services;
using Application.Factories;
using Application.Models.DTOs;
using Application.Models.Request;
using Application.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace MyLibrary.Controllers {
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase {

        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;
        
        public UserController(IUserService userRepository, ITokenService tokenService) {
            _userService = userRepository;
            _tokenService = tokenService;
        }

        /* [HttpGet("get")]
         public async Task<IActionResult> GetUsersAsync() {
             var usersDTOs = new List<UserDTO>();
             foreach(var user in await _userService.GetAllAsync()) {
                 usersDTOs.Add(new UserDTO(user));
             }
             var userResponse = new GetEntitiesResponse<UserDTO>() {
                 Entities = usersDTOs
             };

             return Ok(ResponseFactory.WithSuccess(userResponse));
         }

            [HttpGet("get/{id}")]
         public async Task<IActionResult> GetUserAsync(int id) {
             try {
                 var user = await _userService.GetAsync(id);
                 var userResponse = new EntityResponse<UserDTO>() {
                     Result = new UserDTO(user)
                 };

                 return Ok(ResponseFactory.WithSuccess(userResponse));
             } catch (Exception e) {
                 return NotFound(ResponseFactory.WithError(e));
             }
         }*/

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] AddUserRequest userRequest) {
            try {
                var user = userRequest.ToEntity();
                await _userService.AddAsync(user);
                return Ok(ResponseFactory.WithSuccess("User Registered!"));
            }
            catch (Exception e) {
                return BadRequest(ResponseFactory.WithError(e));
            }
        }
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequest loginRequest) {
            try {
                var user = await _userService.VerifyUserAsync(loginRequest);
                var tokenRequest = new CreateTokenRequest
                {
                    userId = user.Id.ToString(),
                    userName = user.Name,
                    surname = user.Surname,
                    email = user.Email
                };
                var token = await _tokenService.CreateToken(tokenRequest);
                var userResponse = new UserResponse(){
                    User = new UserDTO(user),
                    Token= token
                };
                return Ok(ResponseFactory.WithSuccess(userResponse));
            }
            catch (Exception e) {
                return BadRequest(ResponseFactory.WithError(e));
            }
        }
    }
}
