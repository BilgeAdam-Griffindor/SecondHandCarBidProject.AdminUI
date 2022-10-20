using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using SecondHandCarBidProject.AdminUI.DAL.Interfaces;
using SecondHandCarBidProject.AdminUI.DTO;
using SecondHandCarBidProject.AdminUI.DTO.UserDtos;
using SecondHandCarBidProject.ApiService.Extensions;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class AdminAuthenticationController : Controller
    {
        private IValidator<UserLoginAddDTO> _validatorAdd;
        private IBaseDAL _baseDAL;
        public AdminAuthenticationController(IValidator<UserLoginAddDTO> validator, IBaseDAL baseDAL)
        {
            _validatorAdd = validator;
            _baseDAL = baseDAL;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult LogIn()
        {
            UserLoginAddDTO userLogin = new UserLoginAddDTO("", "");
            return View(userLogin);
        }
        [HttpPost]
        public async Task<IActionResult> LogIn(UserLoginAddDTO user)
        {
            ValidationResult result = await _validatorAdd.ValidateAsync(user);
            if (!result.IsValid)
            {
                //If not valid print errors
                List<ValidationFailure> errors = result.Errors;
                foreach (var error in errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }

                return View(user);
            }
            else
            {
                var response = _baseDAL.LoginAsync<UserResponseDTO, UserLoginAddDTO>("Login/GetLogin", user);
                HttpContext.Session.Set<ExampleDTO>("user", response.Result.Data.User);
                HttpContext.Session.Set<TokenDTO>("token", response.Result.Data.Token);
                return RedirectToAction();
            }

        }
        [HttpGet]
        public IActionResult ResetPassword()
        {
            return View();
        }
    }
}
