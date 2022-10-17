using Microsoft.AspNetCore.Mvc;
using FluentValidation;
using FluentValidation.Results;
using SecondHandCarBidProject.AdminUI.DAL;
using SecondHandCarBidProject.AdminUI.DTO.TrafficInsuranceDto;
using SecondHandCarBidProject.AdminUI.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;
using SecondHandCarBidProject.AdminUI.DAL.Interfaces;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class TrafficInsuranceController : Controller
    {
        private IBaseDAL _baseDAL;
        private IValidator<TrafficInsuranceAddDto> _validator1;
        private IValidator<TrafficInsuranceUpdateDto> _validator2;
        public TrafficInsuranceController(IBaseDAL baseDAL, IValidator<TrafficInsuranceAddDto> validator1, IValidator<TrafficInsuranceUpdateDto> validator2)
        {
            _baseDAL = baseDAL;
            _validator1 = validator1;
            _validator2 = validator2;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var carList = await _baseDAL.ListAll<CarDetailUpdatePageDTO>(null,null);
            TrafficInsuranceAddDto trafficInsuranceAddDto = new TrafficInsuranceAddDto(null,null);
            if (carList.IsSuccess)
            {
                trafficInsuranceAddDto.CarItemList = carList.Data.Select(x => new SelectListItem() { Text=x.Id.ToString(),Value=x.Id.ToString() }).ToList();
                return View(trafficInsuranceAddDto);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(TrafficInsuranceAddDto trafficInsuranceAddDto)
        {
            ValidationResult result = await _validator1.ValidateAsync(trafficInsuranceAddDto);
            if (result.IsValid)
            {
                var data = await _baseDAL.SaveAsync<TrafficInsuranceAddDto, bool>(trafficInsuranceAddDto, null, null);
                if (data.IsSuccess)
                {
                    return View();
                }
                else
                {
                    return View();
                }
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            var data = await _baseDAL.GetByIdAsync<TrafficInsuranceUpdateDto>(id,null,null);
            var carList = await _baseDAL.ListAll<CarDetailUpdatePageDTO>(null, null);
            TrafficInsuranceAddDto trafficInsuranceAddDto = new TrafficInsuranceAddDto(null, null);
            if (carList.IsSuccess && data.IsSuccess)
            {

                data.Data.CarItemList = carList.Data.Select(x => new SelectListItem() { Text = x.Id.ToString(), Value = x.Id.ToString() }).ToList();
                return View(trafficInsuranceAddDto);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Update(TrafficInsuranceUpdateDto trafficInsuranceUpdateDto)
        {
            ValidationResult result = await _validator2.ValidateAsync(trafficInsuranceUpdateDto);
            if (result.IsValid)
            {
                var data = await _baseDAL.SaveAsync<TrafficInsuranceUpdateDto, bool>(trafficInsuranceUpdateDto, null, null);
                if (data.IsSuccess)
                {
                    return View();
                }
                else
                {
                    return View();
                }
            }
            return View();
        }
    }
}
