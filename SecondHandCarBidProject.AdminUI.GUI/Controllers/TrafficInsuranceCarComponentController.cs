using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using SecondHandCarBidProject.AdminUI.DAL;
using SecondHandCarBidProject.AdminUI.DAL.Interfaces;
using SecondHandCarBidProject.AdminUI.DTO.TrafficInsuranceDto;


namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class TrafficInsuranceCarComponentController : Controller
    {
        private IBaseDAL _baseDAL; 
        
        private IValidator<TrafficInsuranceCarComponentAddDto> _validator1;
        private IValidator<TrafficInsuranceCarComponentUpdateDto> _validator2;
        public TrafficInsuranceCarComponentController(IBaseDAL baseDAL, IValidator<TrafficInsuranceCarComponentAddDto> validator1, IValidator<TrafficInsuranceCarComponentUpdateDto> validator2)
        {
            _baseDAL = baseDAL;
            _validator1 = validator1;
            _validator2 = validator2;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var data = await _baseDAL.ListAll<TrafficInsuranceCarComponentListDto>(null, null);
            if (data.IsSuccess)
            {
                return View(data.Data);
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(TrafficInsuranceCarComponentAddDto trafficInsuranceCarComponentAddDto)
        {
            ValidationResult result = await _validator1.ValidateAsync(trafficInsuranceCarComponentAddDto);
            if (result.IsValid)
            {
                var data = await _baseDAL.SaveAsync<TrafficInsuranceCarComponentAddDto, bool>(trafficInsuranceCarComponentAddDto,null,null);
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
            var data = await _baseDAL.GetByIdAsync<TrafficInsuranceCarComponentUpdateDto>(id, null, null);
            if (data.IsSuccess)
            {
                return View(data.Data);
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(TrafficInsuranceCarComponentUpdateDto trafficInsuranceCarComponentUpdateDto)
        {
            ValidationResult result = await _validator2.ValidateAsync(trafficInsuranceCarComponentUpdateDto);
            if (result.IsValid)
            {
                var data = await _baseDAL.UpdateAsync<TrafficInsuranceCarComponentUpdateDto, bool>(trafficInsuranceCarComponentUpdateDto, null, null);
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
