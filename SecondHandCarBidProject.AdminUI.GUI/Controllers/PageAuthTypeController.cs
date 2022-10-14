using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using SecondHandCarBidProject.AdminUI.DTO.AuthorizationDtos;
using SecondHandCarBidProject.ApiService.ApServicesInterfaces;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class PageAuthTypeController : Controller
    {
        private IValidator<PageAuthTypeAdd> _validator;
        private IBaseServices _baseServices;
        public PageAuthTypeController(IValidator<PageAuthTypeAdd> validator, IBaseServices baseServices)
        {
            _validator = validator;
            _baseServices = baseServices;
        }
        
        [HttpGet]
        public IActionResult Index(string id)
        {
            return View();
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(PageAuthTypeAdd pageAuthTypeAdd)
        {
            ValidationResult result =  await _validator.ValidateAsync(pageAuthTypeAdd);
            if (result.IsValid)
            {
                //var data = 
                //if (data.Result.IsSuccess)
                //{
                //    return View();
                //}
                //else
                //{
                //    return View();
                //}
                return View();
            }
            else
            {
                //Textbox üstüne yaz
                return View();
            }
            
        }
        [HttpGet]
        public IActionResult Update(string id)
        {
            return View();
        }
    }
}
