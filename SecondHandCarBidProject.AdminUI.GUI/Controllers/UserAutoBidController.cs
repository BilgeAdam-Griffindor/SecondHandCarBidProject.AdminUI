using Microsoft.AspNetCore.Mvc;
using FluentValidation;
using FluentValidation.Results;
using SecondHandCarBidProject.AdminUI.DAL;
using SecondHandCarBidProject.AdminUI.DTO.BidDtos;
using SecondHandCarBidProject.AdminUI.DTO.UserDtos;
using Microsoft.AspNetCore.Mvc.Rendering;
using SecondHandCarBidProject.AdminUI.DAL.Concrete;
using SecondHandCarBidProject.AdminUI.DAL.Interfaces;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class UserAutoBidController : Controller
    {
        private IBaseDAL _baseDAL;
        private IValidator<UserAutoBidAddDto> _validator1;
        private IValidator<UserAutoBidUpdateDto> _validator2;
        public UserAutoBidController(IBaseDAL baseDAL, IValidator<UserAutoBidAddDto> validator1, IValidator<UserAutoBidUpdateDto> validator2)
        {
            _baseDAL = baseDAL;
            _validator1 = validator1;
            _validator2 = validator2;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var data = await _baseDAL.ListAll<UserAutoBidDto>(null, null);
            if (data.IsSuccess)
            {
                return View(data.Data);
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            UserAutoBidAddDto userAutoBidAddDto = new UserAutoBidAddDto(null, null, null, null);
            var userList = await _baseDAL.ListAll<BaseUserSelectDTO>(null,null);
            var bidList = await _baseDAL.ListAll<BidSelectDTO>(null,null);
            userAutoBidAddDto.BaseUserItemList = userList.Data.Select(x => new SelectListItem() { Text = x.Name + " " + x.Surname, Value = x.Id.ToString() }).ToList();
            userAutoBidAddDto.BidItemList = bidList.Data.Select(x => new SelectListItem() { Text=x.BidName,Value=x.Id.ToString()}).ToList();
            return View(userAutoBidAddDto);
        }
        [HttpPost]
        public async Task<IActionResult> Add(UserAutoBidAddDto userAutoBidAddDto)
        {
            ValidationResult result = await _validator1.ValidateAsync(userAutoBidAddDto);
            if (result.IsValid)
            {
                var data = await _baseDAL.SaveAsync<UserAutoBidAddDto, bool>(userAutoBidAddDto, null, null);
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
            var data = await _baseDAL.GetByIdAsync<UserAutoBidUpdateDto>(id, null, null);
            if (data.IsSuccess)
            {
                return View(data.Data);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Update(UserAutoBidUpdateDto userAutoBidUpdateDto)
        {
            ValidationResult result = await _validator2.ValidateAsync(userAutoBidUpdateDto);
            if (result.IsValid)
            {
                var data = await _baseDAL.UpdateAsync<UserAutoBidUpdateDto, bool>(userAutoBidUpdateDto, null, null);
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
