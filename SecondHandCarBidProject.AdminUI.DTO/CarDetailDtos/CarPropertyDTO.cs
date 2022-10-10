namespace SecondHandCarBidProject.AdminUI.DTO.CarDetailDtos
{
    public class CarPropertyDTO
    {
        public Guid CarId { get; set; }
        public short CarPropertyValueId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public List<CarPropertyValueDTO> CarPropertyValues { get; set; }
        public List<CarDetailUpdatePageDTO> Cars { get; set; }
    }
}
