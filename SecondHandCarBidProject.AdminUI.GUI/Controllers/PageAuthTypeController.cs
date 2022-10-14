using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using SecondHandCarBidProject.AdminUI.DAL;
using SecondHandCarBidProject.AdminUI.DTO.AuthorizationDtos;
using SecondHandCarBidProject.ApiService.ApServicesInterfaces;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class PageAuthTypeController : Controller
    {
        private IValidator<PageAuthTypeAdd> _validator;
        
        private BaseDAL _baseDAL;
        public PageAuthTypeController(IValidator<PageAuthTypeAdd> validator,  BaseDAL baseDAL)
        {
            _validator = validator;           
            _baseDAL = baseDAL;
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
                var data = _baseDAL.SaveAsync<PageAuthTypeAdd, bool>(pageAuthTypeAdd, null, null);
                if (data.Result.IsSuccess)
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
