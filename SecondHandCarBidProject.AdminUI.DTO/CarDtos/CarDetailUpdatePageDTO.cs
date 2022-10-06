using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SecondHandCarBidProject.AdminUI.DTO
{
    public record CarDetailUpdatePageDTO(
        Guid Id,
        decimal Price,
        int Kilometre,
        short CarYear,
        bool IsCorporate,
        string CarDescription,
        short CarBrandId,
        int CarModelId,
        int StatusId,
        Guid BodyTypeId,
        Guid FuelTypeId,
        Guid GearTypeId,
        Guid VersionId,
        Guid ColorId,
        List<Guid> OptionalHardwareIds,
        int? CorporationId,
        List<CarImageListDTO> CarImages,
        List<IdNameListDTO> BrandList,
        List<IdNameListDTO> ModelList,
        List<IdNameListDTO> StatusList,
        List<IdNameListDTO> CorporationList,
        List<IdNameListDTO> BodyTypeList,
        List<IdNameListDTO> FuelTypeList,
        List<IdNameListDTO> GearTypeList,
        List<IdNameListDTO> VersionList,
        List<IdNameListDTO> ColorList,
        List<IdNameListDTO> OptionalHardwareList
        );
}
