namespace SecondHandCarBidProject.AdminUI.DTO.CarDtos
{
    public record CarCorporationAddPageDTO(
      List<IdNameListDTO> CarList,
      List<IdNameListDTO> CorporationList
      );
}
