using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SecondHandCarBidProject.AdminUI.DTO
{
    public class CarDetailAddDto
    {
        public List<SelectListItem> BireyselKurumsalListe { get; set; }
        public int BireyselKurumsalId { get; set; }

        public List<SelectListItem> KurumsalSirketAdiListe { get; set; }
        public int KurumsalSirketAdireyselKurumsalId { get; set; }

        public string description { get; set; }
        public string SelectedItem { get; set; }
        public List<SelectListItem> selectItemList
        {
            get; set;
        }
    }
}
