using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DTO
{
    public class CarListTableRowDTO
    {
        public int CarId { get; set; }
        public string CarBrandName { get; set; }
        public string CarModelName { get; set; }
        public string Status { get; set; }
        public string UserName { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
