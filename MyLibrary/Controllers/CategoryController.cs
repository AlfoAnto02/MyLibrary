using Application.Abstractions.Services;
using Application.Factories;
using Application.Models.DTOs;
using Application.Models.Request;
using Application.Models.Responses;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyLibrary.Controllers {
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CategoryController : ControllerBase {

        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService) {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategoriesAsync() {
            var categoriesDtos = new List<CategoryDTO>();
            foreach (var category in await _categoryService.GetAllAsync()) {
                categoriesDtos.Add(new CategoryDTO(category));
            }
            var categoryResponse = new GetEntitiesResponse<CategoryDTO>() {
                Entities = categoriesDtos
            };

            return Ok(ResponseFactory.WithSuccess(categoryResponse));
        }

        /*[HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryAsync(int id) {
            try {
                var category = await _categoryService.GetAsync(id);
                var getSingleCategoryResponse = new EntityResponse<CategoryDTO>() {
                    Result = new CategoryDTO(category)
                };
                return Ok(ResponseFactory.WithSuccess(getSingleCategoryResponse));
            }catch (Exception e) {
                return NotFound(ResponseFactory.WithError(e));
            }
        }*/

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddCategoryAsync([FromBody] AddCategoryRequest categoryRequest) {
            try {
                var category = categoryRequest.ToEntity();
                await _categoryService.AddAsync(category);
                var entityResponse = new EntityResponse<CategoryDTO>() {
                    Result = new CategoryDTO(category)
                };
                return Ok(ResponseFactory.WithSuccess(entityResponse));
            }
            catch (Exception e) {
                return BadRequest(ResponseFactory.WithError(e));
            }
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteCategoryAsync(int id) {
            try {
                var category = await _categoryService.DeleteCategoryAsync(id);
                var categoryResponse = new EntityResponse<CategoryDTO>() {
                    Result = new CategoryDTO(category)
                };
                var response = ResponseFactory.WithSuccess(categoryResponse);
                return Ok(response);
            }
            catch (Exception e) {
                return BadRequest(ResponseFactory.WithError(e));
            }
        }
    }
}
