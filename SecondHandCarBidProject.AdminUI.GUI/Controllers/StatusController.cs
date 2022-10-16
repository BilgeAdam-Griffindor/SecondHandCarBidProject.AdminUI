using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SecondHandCarBidProject.AdminUI.DAL;
using SecondHandCarBidProject.AdminUI.DAL.Interfaces;
using SecondHandCarBidProject.AdminUI.DTO.StatusDtos;
using System.Web;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class StatusController : Controller
    {
        private IBaseDAL _baseDAL;
        private IValidator<StatusTypeAddDto> _validator1;
        private IValidator<StatusTypeUpdate> _validator2;
        private IValidator<StatusValueAddDto> _validator3;
        private IValidator<StatusValueUpdateDto> _validator4;

        public StatusController(IBaseDAL baseDAL, IValidator<StatusTypeAddDto> validator1, IValidator<StatusTypeUpdate> validator2, IValidator<StatusValueAddDto> validator3, IValidator<StatusValueUpdateDto> validator4)
        {
            _baseDAL = baseDAL;
            _validator1 = validator1;
            _validator2 = validator2;
            _validator3 = validator3;
            _validator4 = validator4;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Type()
        {
            var data = await _baseDAL.ListAll<StatusTypeDto>(null, null);
            if (data.IsSuccess)
            {
                return View(data.Data);
            }
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Type(string id)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> TypeAdd()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> TypeAdd(StatusTypeAddDto statusTypeAddDto)
        {
            ValidationResult result = await _validator1.ValidateAsync(statusTypeAddDto);
            if (result.IsValid)
            {
                var data = await _baseDAL.SaveAsync<StatusTypeAddDto, bool>(statusTypeAddDto, null, null);
                if (data.Data)
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
        public async Task<IActionResult> TypeUpdate(int id)
        {
            var data = await _baseDAL.GetByIdAsync<StatusTypeUpdate>(id, null, null);
            if (data.IsSuccess)
            {
                return View(data.Data);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> TypeUpdate(StatusTypeUpdate statusTypeUpdate)
        {
            ValidationResult result = await _validator2.ValidateAsync(statusTypeUpdate);
            if (result.IsValid)
            {
                var data = await _baseDAL.UpdateAsync<StatusTypeUpdate, bool>(statusTypeUpdate, null, null);
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
        public async Task<IActionResult> Value()
        {
            var data = await _baseDAL.ListAll<StatusValueDto>(null, null);
            if (data.IsSuccess)
            {
                return View(data.Data);
            }
            return View();        
        }
        [HttpGet]
        public async Task<IActionResult> ValueAdd()
        {
            var statusTypeList = await _baseDAL.ListAll<StatusTypeDto>(null, null);
            StatusValueAddDto statusValueAddDto = new StatusValueAddDto(null, null);
            statusValueAddDto.StatusTypeItemList = statusTypeList.Data.Select(x => new SelectListItem() { Text = x.StatusTypeName, Value = x.StatusTypeId.ToString() }).ToList();
            return View(statusValueAddDto);
        }
        [HttpPost]
        public async Task<IActionResult> ValueAdd(StatusValueAddDto statusValueAddDto)
        {
            ValidationResult result = await _validator3.ValidateAsync(statusValueAddDto);
            if (result.IsValid)
            {
                var data = await _baseDAL.SaveAsync<StatusValueAddDto, bool>(statusValueAddDto, null, null);
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
        public async Task<IActionResult> ValueUpdate(string id)
        {
            var data = await _baseDAL.GetByIdAsync<StatusValueUpdateDto>(id, null, null);
            var statusTypeList = await _baseDAL.ListAll<StatusTypeDto>(null, null);
            
            if (data.IsSuccess && statusTypeList.IsSuccess)
            {
                data.Data.StatusTypeItemList = statusTypeList.Data.Select(x => new SelectListItem() { Text = x.StatusTypeName, Value = x.StatusTypeId.ToString() }).ToList();
                return View(data.Data);
            }
            return View();
            
        }
        [HttpPost]
        public async Task<IActionResult> ValueUpdate(StatusValueUpdateDto statusValueUpdateDto)
        {
            ValidationResult result = await _validator4.ValidateAsync(statusValueUpdateDto);
            if (result.IsValid)
            {
                var data = await _baseDAL.UpdateAsync<StatusValueUpdateDto, bool>(statusValueUpdateDto, null, null);
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
