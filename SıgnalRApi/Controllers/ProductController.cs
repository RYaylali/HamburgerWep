using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SıgnalR.BussinessLayer.Abstract;
using SıgnalR.EntityLayer.Entities;
using SignalR.DtoLayer.DiscountDto;
using SignalR.DtoLayer.ProductDto;

namespace SıgnalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IProductService _productService;
		private readonly IMapper _mapper;

		public ProductController(IProductService productService, IMapper mapper)
		{
			_productService = productService;
			_mapper = mapper;
		}
		[HttpGet]
		public IActionResult ProductList()
		{
			var values = _mapper.Map<List<ResultProductDto>>(_productService.TGetListAll());
			return Ok(values);
		}
		[HttpPost]
		public IActionResult CreateProduct(CreateProductDto model)
		{
			_productService.TAdd(new Product()
			{
				Description = model.Description,
				ImageUrl = model.ImageUrl,
				Price = model.Price,
				ProductName = model.ProductName,
				ProductStatus = true
			});
			return Ok("Başarıyla Eklendi");
		}
		[HttpDelete]
		public IActionResult DeleteProduct(int id)
		{
			_productService.TDelete(_productService.TGetById(id));
			return Ok("Başarıyla Silindi");
		}
		[HttpPut]
		public IActionResult UpdateProduct(UpdateProductDto model)
		{
			Product contact = new Product()
			{
				Description = model.Description,
				ImageUrl = model.ImageUrl,
				Price = model.Price,
				ProductID = model.ProductID,
				ProductName = model.ProductName,
				ProductStatus = model.ProductStatus
			};
			_productService.TUpdate(contact);
			return Ok("Başarıyla Güncellendi");
		}
		[HttpGet("GetProduct")]
		public IActionResult GetProduct(int id)
		{
			return Ok(_productService.TGetById(id));
		}
	}
}
