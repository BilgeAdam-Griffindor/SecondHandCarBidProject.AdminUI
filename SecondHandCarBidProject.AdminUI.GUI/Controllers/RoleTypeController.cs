using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using SecondHandCarBidProject.AdminUI.DAL;
using SecondHandCarBidProject.AdminUI.DTO.AuthorizationDtos;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class RoleTypeController : Controller
    {
        private BaseDAL _baseDAL;
        private IValidator<RoleTypeAddDto> _validator;
        private IValidator<RoleTypeUpdateDto> _validator2;
        public RoleTypeController(BaseDAL baseDAL, IValidator<RoleTypeAddDto> validator, IValidator<RoleTypeUpdateDto> validator2)
        {
            _baseDAL = baseDAL;
            _validator = validator;
            _validator2 = validator2;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var data = await _baseDAL.ListAll<RoleTypeDto>(null, null);
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
        public async Task<IActionResult> Add(RoleTypeAddDto roleTypeAddDto)
        {
            ValidationResult result = await _validator.ValidateAsync(roleTypeAddDto);
            if (result.IsValid)
            {
                var data = await _baseDAL.SaveAsync<RoleTypeAddDto, bool>(roleTypeAddDto, null, null);
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
        public async Task<IActionResult> Update(Int16 id)
        {
            var data = await _baseDAL.GetByIdAsync<RoleTypeUpdateDto>(id, null, null);
            if (data.IsSuccess)
            {
                return View(data.Data);
            }
            return View();
        
        }
        [HttpPost]
        public async Task<IActionResult> Update(RoleTypeUpdateDto roleTypeUpdateDto)
        {
            ValidationResult result = await _validator2.ValidateAsync(roleTypeUpdateDto);
            if (result.IsValid)
            {
                var data = await _baseDAL.UpdateAsync<RoleTypeUpdateDto, bool>(roleTypeUpdateDto, null, null);
                if (data.IsSuccess)
                {
                    return View();
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
    }
}
