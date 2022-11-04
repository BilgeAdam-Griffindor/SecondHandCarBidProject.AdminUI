using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using SecondHandCarBidProject.AdminUI.DAL.Interfaces;
using SecondHandCarBidProject.AdminUI.DTO.UserDtos;
using SecondHandCarBidProject.ApiService.Extensions;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class AdminAuthenticationController : Controller
    {
        private IValidator<TokenUserRequestDTO> _validatorAdd;
        private IBaseDAL _baseDAL;
        public AdminAuthenticationController(IValidator<TokenUserRequestDTO> validator, IBaseDAL baseDAL)
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
            TokenUserRequestDTO userLogin = new TokenUserRequestDTO("", "");
            return View(userLogin);
        }
        [HttpPost]
        public async Task<IActionResult> LogIn(TokenUserRequestDTO user)
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
                var response = await _baseDAL.LoginAsync<UserResponseDTO, TokenUserRequestDTO>("Login/LoginUser", user);
                if (response.Errors == null)
                {
                    HttpContext.Session.Set<BaseUserDTO>("user", response.Data.User);
                    HttpContext.Session.Set<string>("accessToken", response.Data.Token.AccessToken);
                    HttpContext.Session.Set<string>("RefreshToken", response.Data.Token.RefreshToken);
                    return RedirectToAction("Index", "Base");//todo:should go dashboard
                }
                else
                {
                    return View(user);
                }

            }

        }
        [HttpGet]
        public IActionResult ResetPassword()
        {
            return View();
        }
    }
}
