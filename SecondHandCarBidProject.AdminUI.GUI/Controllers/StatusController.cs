using Microsoft.AspNetCore.Mvc;
using SecondHandCarBidProject.AdminUI.DTO.StatusDtos;
using System.Web;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class StatusController : Controller
    {
        
        List<StatusTypeDto>  statusTypeDtos = new List<StatusTypeDto>();
        public StatusController()
        {
            statusTypeDtos.Add(new StatusTypeDto(1,"Deneme1",true));
            statusTypeDtos.Add(new StatusTypeDto(2, "Deneme6", true));
            statusTypeDtos.Add(new StatusTypeDto(3, "Deneme7", false));
            statusTypeDtos.Add(new StatusTypeDto(4, "Deneme7", false));
            statusTypeDtos.Add(new StatusTypeDto(5, "Deneme2", true));
            statusTypeDtos.Add(new StatusTypeDto(6, "Deneme7", false));
            statusTypeDtos.Add(new StatusTypeDto(7, "Deneme7", false));
            statusTypeDtos.Add(new StatusTypeDto(8, "Deneme3", true));
            statusTypeDtos.Add(new StatusTypeDto(9, "Deneme7", false));
            statusTypeDtos.Add(new StatusTypeDto(10, "Deneme4", true));
            statusTypeDtos.Add(new StatusTypeDto(11, "Deneme7", false));
            statusTypeDtos.Add(new StatusTypeDto(12, "Deneme6", true));
            statusTypeDtos.Add(new StatusTypeDto(13, "Deneme7", false));
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Type()
        {


            return View();
        }
        [HttpPost]
        public IActionResult Type(string id)
        {
            return View();
        }

        [HttpGet]
        public IActionResult TypeAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult TypeAdd(StatusTypeAddDto statusTypeAddDto)
        {
            return View();
        }
        [HttpPost]
        public IActionResult TypeUpdate(StatusTypeUpdate statusTypeUpdate)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Value()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ValueAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ValueAdd(StatusValueAddDto statusValueAddDto)
        {
            return View();
        }
        [HttpPost]
        public IActionResult ValueUpdate(string id)
        {
            return View();
        }


    }
}
