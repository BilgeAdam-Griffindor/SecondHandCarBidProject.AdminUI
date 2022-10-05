using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DTO
{
    public class CarDetailUpdatePageDTO
    {
        public Guid Id { get; set; }

        public decimal Price { get; set; }

        public int Kilometre { get; set; }

        public short CarYear { get; set; }

        public bool IsCorporate { get; set; }

        public string CarDescription { get; set; }

        public short CarBrandId { get; set; }

        public int CarModelId { get; set; }

        public int CorporationId { get; set; }

        public List<CarImageListDTO> CarImages { get; set; }

        public List<IdNameListDTO> BrandList { get; set; }
        public List<IdNameListDTO> ModelList { get; set; }
        public List<IdNameListDTO> StatusList { get; set; }
        public List<IdNameListDTO> CorporationList { get; set; }
        public List<IdNameListDTO> BodyTypeList { get; set; }
        public List<IdNameListDTO> FuelTypeList { get; set; }
        public List<IdNameListDTO> GearTypeList { get; set; }
        public List<IdNameListDTO> VersionList { get; set; }
        public List<IdNameListDTO> ColorList { get; set; }
        public List<IdNameListDTO> OptionalHardwareList { get; set; }
    }
}
