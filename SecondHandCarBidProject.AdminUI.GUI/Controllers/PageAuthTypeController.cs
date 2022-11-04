using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using SecondHandCarBidProject.AdminUI.DAL;
using SecondHandCarBidProject.AdminUI.DAL.Interfaces;
using SecondHandCarBidProject.AdminUI.DAL.Concrete;
using SecondHandCarBidProject.AdminUI.DTO.AuthorizationDtos;
using SecondHandCarBidProject.ApiService.ApServicesInterfaces;
using SecondHandCarBidProject.AdminUI.GUI.ViewModels.PageAuthType;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class PageAuthTypeController : Controller
    {
        private IValidator<PageAuthTypeAdd> _validator;
        private IValidator<PageAuthTypeUpdate> _validator2;
        private IBaseDAL _baseDAL;
        public PageAuthTypeController(IValidator<PageAuthTypeAdd> validator, IBaseDAL baseDAL, IValidator<PageAuthTypeUpdate> validator2)
        {
            _validator = validator;           
            _baseDAL = baseDAL;
            _validator2 = validator2;
        }
        
        [HttpGet]
        
        public async Task<IActionResult> Index(string SearchPageAuth, int page = 1, int itemPerPage = 10)
        {
            ViewData["SearchPageAuth"] = SearchPageAuth;
            ViewData["page"] = page;
            ViewData["itemPerPage"] = itemPerPage;
            string queryString = "page=" + page + "&itemPerPage=" + itemPerPage;
            try
            {
                var data = await _baseDAL.GetByFilter<PageAuthTypeClassListDto>("PageAuthType/List", "asdasdad", queryString);
                if (data.IsSuccess)
                {
                    //PageAuthTypeClassListDto pageAuthTypeViewModel = new PageAuthTypeClassListDto();
                    //pageAuthTypeViewModel.pageAuthTypeDtos = data.Data.;
                    //pageAuthTypeViewModel.maxPages = data.Data.maxPages;

                    return View(data.Data);


                }
                else
                {
                    throw new Exception("Başarısız işlem. Car/Index Kod: ");
                }
            }
            catch (Exception)
            {

                throw;
            }

            
            
           

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
                var data = await _baseDAL.SaveAsync<PageAuthTypeAdd, bool>(pageAuthTypeAdd, null, null);
                if (data.Data)
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
        public async Task<IActionResult> Update(Int16 id)
        {
            var data = await _baseDAL.GetByIdAsync<PageAuthTypeUpdate>(id, null, null);
            if (data.IsSuccess)
            {
                return View(data.Data);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Update(PageAuthTypeUpdate pageAuthTypeUpdate)
        {
            ValidationResult result = await _validator2.ValidateAsync(pageAuthTypeUpdate);
            if (result.IsValid)
            {
                var data = await _baseDAL.UpdateAsync<PageAuthTypeUpdate, bool>(pageAuthTypeUpdate, null, null);
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
