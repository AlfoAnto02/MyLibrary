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

        public UserController(IUserService userRepository) {
            _userService = userRepository;
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
                var userResponse = new EntityResponse<UserDTO>(){
                    Result = new UserDTO(user)
                };
                return Ok(ResponseFactory.WithSuccess(userResponse));
            }
            catch (Exception e) {
                return BadRequest(ResponseFactory.WithError(e));
            }
        }
    }
}
