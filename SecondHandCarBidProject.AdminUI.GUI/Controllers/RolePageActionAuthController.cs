using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SecondHandCarBidProject.AdminUI.DAL;
using SecondHandCarBidProject.AdminUI.DTO.AuthorizationDtos;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class RolePageActionAuthController : Controller
    {
        //RolePageActionAuthAddValidator
        private IValidator<RolePageActionAuthAddDto> _validator;
        private BaseDAL _baseDAL;
        public RolePageActionAuthController(BaseDAL baseDAL, IValidator<RolePageActionAuthAddDto> validator)
        {
            _baseDAL = baseDAL;
            _validator = validator;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var data = await _baseDAL.ListAll<RolePageActionAuthDto>(null, null);
            if (data.IsSuccess)
            {
                return View(data.Data);
            }
            else
            {
                return View();
            }
            
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            RolePageActionAuthAddDto rpaa = new RolePageActionAuthAddDto(null, null, null);
            var roleTypeList = await _baseDAL.ListAll<RoleTypeDto>(null, null);
            var pageAuthTypeList = await _baseDAL.ListAll<PageAuthTypeDto>(null, null);
            //TODO burada actionauthtype için de selectlist döndür
            rpaa.RoleTypeItemList = roleTypeList.Data.Select(x => new SelectListItem() { Text = x.RoleName, Value = x.Id.ToString() }).ToList();
            rpaa.PageAuthTypeItemList = pageAuthTypeList.Data.Select(x => new SelectListItem() { Text = x.AuthorizationName, Value = x.Id.ToString() }).ToList();

            //var actionAuthTypeList = await _baseDAL.ListAll<>
            return View(rpaa);
        }
        [HttpPost]
        public async Task<IActionResult> Add(RolePageActionAuthAddDto rolePageActionAuthAddDto)
        {
            ValidationResult result = await _validator.ValidateAsync(rolePageActionAuthAddDto);
            if (result.IsValid)
            {
                var data = await _baseDAL.SaveAsync<RolePageActionAuthAddDto, bool>(rolePageActionAuthAddDto,null,null);
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
        //Identity Id yok update kaldırıldı
        //[HttpGet]
        //public async Task<IActionResult> Update()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public async Task<IActionResult> Update()
        //{
        //    return View();
        //}
    }
}
