namespace SecondHandCarBidProject.AdminUI.DTO.CarDetailDtos
{
    public class CarCorporationDTO
    {
        public Guid CarId { get; set; }
        public int CorporationId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public List<CarPropertyValueDTO> CarCorporations { get; set; }
        public List<CarDetailUpdatePageDTO> Cars { get; set; }
    }
}
