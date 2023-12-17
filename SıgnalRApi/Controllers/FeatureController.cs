using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SıgnalR.BussinessLayer.Abstract;
using SıgnalR.EntityLayer.Entities;
using SignalR.DtoLayer.DiscountDto;
using SignalR.DtoLayer.FeatureDto;

namespace SıgnalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FeatureController : ControllerBase
	{
		private readonly IFeatureService _featureService;
		private readonly IMapper _mapper;

		public FeatureController(IFeatureService featureService, IMapper mapper)
		{
			_featureService = featureService;
			_mapper = mapper;
		}
		[HttpGet]
		public IActionResult FeatureList()
		{
			var values = _mapper.Map<List<ResultFeatureDto>>(_featureService.TGetListAll());
			return Ok(values);
		}
		[HttpPost]
		public IActionResult CreateFeature(CreateFeatureDto model)
		{
			_featureService.TAdd(new Feature()
			{
				Description1 = model.Description1,
				Description2 = model.Description2,
				Description3 = model.Description3,
				Title1 = model.Title1,
				Title2 = model.Title2,
				Title3 = model.Title3,
			});
			return Ok("Başarıyla Eklendi");
		}
		[HttpDelete]
		public IActionResult DeleteFeature(int id)
		{
			_featureService.TDelete(_featureService.TGetById(id));
			return Ok("Başarıyla Silindi");
		}
		[HttpPut]
		public IActionResult UpdateFeature(UpdateFeatureDto model)
		{
			Feature contact = new Feature()
			{
				FeatureID = model.FeatureID,
				Description1 = model.Description1,
				Description2 = model.Description2,
				Description3 = model.Description3,
				Title1 = model.Title1,
				Title2 = model.Title2,
				Title3 = model.Title3,
			};
			_featureService.TUpdate(contact);
			return Ok("Başarıyla Güncellendi");
		}
		[HttpGet("GetFeature")]
		public IActionResult GetFeature(int id)
		{
			return Ok(_featureService.TGetById(id));
		}
	}
}
