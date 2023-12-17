using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SıgnalR.BussinessLayer.Abstract;
using SıgnalR.EntityLayer.Entities;
using SignalR.DtoLayer.BookingDto;
using SignalR.DtoLayer.CategoryDto;
using AutoMapper;

namespace SıgnalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		private readonly ICategoryService _categoryService;
		private readonly IMapper _mapper;

		public CategoryController(ICategoryService categoryService, IMapper mapper)
		{
			_categoryService = categoryService;
			_mapper = mapper;
		}
		[HttpGet]
		public IActionResult CategoryList()
		{
			var values = _mapper.Map<List<ResultCategoryDto>>(_categoryService.TGetListAll());
			return Ok(values);
		}
		[HttpPost]
		public IActionResult CreateCategory(CreateCategoryDto model)
		{
			_categoryService.TAdd(new Category()
			{
				Name = model.Name,
				Status = true
			});
			return Ok("Başarıyla Eklendi");
		}
		[HttpDelete]
		public IActionResult DeleteCategory(int id)
		{
			_categoryService.TDelete(_categoryService.TGetById(id));
			return Ok("Başarıyla Silindi");
		}
		[HttpPut]
		public IActionResult UpdateCategory(UpdateCategoryDto model)
		{
			Category booking = new Category()
			{
				CategoryID = model.CategoryID,
				Name = model.Name,
				Status = model.Status
			};
			_categoryService.TUpdate(booking);
			return Ok("Başarıyla Güncellendi");
		}
		[HttpGet("GetCategory")]
		public IActionResult GetCategory(int id)
		{
			return Ok(_categoryService.TGetById(id));
		}
	}
}
