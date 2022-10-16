using Microsoft.AspNetCore.Mvc;
using FluentValidation;
using FluentValidation.Results;
using SecondHandCarBidProject.AdminUI.DTO.TrafficInsuranceDto;
using SecondHandCarBidProject.AdminUI.DAL;
using SecondHandCarBidProject.AdminUI.DTO.StatusDtos;
using Microsoft.AspNetCore.Mvc.Rendering;
using SecondHandCarBidProject.AdminUI.DAL.Interfaces;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class TrafficInsuranceTrafficInsuranceCarComponentController : Controller
    {
        private IBaseDAL _baseDAL;
        public TrafficInsuranceTrafficInsuranceCarComponentController(IBaseDAL baseDAL)
        {
            _baseDAL = baseDAL;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //TrafficInsuranceTrafficInsuranceCarComponentDto
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            TrafficInsuranceTrafficInsuranceCarComponentAddDto trafficInsuranceTrafficInsuranceCarComponentAddDto = new TrafficInsuranceTrafficInsuranceCarComponentAddDto(null,null,null);
            var trafficInsuranceList = await _baseDAL.ListAll<TrafficInsuranceListDto>(null, null);
            var trafficInsuranceCarComponentList = await _baseDAL.ListAll<TrafficInsuranceCarComponentListDto>(null, null);
            var statusValueList = await _baseDAL.ListAll<StatusValueDto>(null, null);
            trafficInsuranceTrafficInsuranceCarComponentAddDto.TrafficInsuranceItemList = trafficInsuranceList.Data.Select(x => new SelectListItem() { Text = x.Id.ToString(), Value = x.Id.ToString() }).ToList();

            trafficInsuranceTrafficInsuranceCarComponentAddDto.TrafficInsuranceCarComponentItemList = trafficInsuranceCarComponentList.Data.Select(x => new SelectListItem() { Text = x.ComponentName.ToString(), Value = x.Id.ToString() }).ToList();

            trafficInsuranceTrafficInsuranceCarComponentAddDto.TrafficInsuranceItemList = statusValueList.Data.Select(x => new SelectListItem() { Text = x.StatusName.ToString(), Value = x.Id.ToString() }).ToList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(TrafficInsuranceTrafficInsuranceCarComponentAddDto trafficInsuranceTrafficInsuranceCarComponentAddDto)
        {
            var data = await _baseDAL.SaveAsync<TrafficInsuranceTrafficInsuranceCarComponentAddDto, bool>(trafficInsuranceTrafficInsuranceCarComponentAddDto, null, null);
            if (data.IsSuccess)
            {
                return View();
            }
            return View();
        }

    }
}
