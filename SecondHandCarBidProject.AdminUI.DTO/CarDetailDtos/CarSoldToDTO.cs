namespace SecondHandCarBidProject.AdminUI.DTO.CarDetailDtos
{
    public class CarSoldToDTO
    {
        public Guid Id { get; set; }
        public Guid CarId { get; set; }
        public Guid SoldToBaseUserId { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public List<CarPropertyValueDTO> Users { get; set; }
        public List<CarDetailUpdatePageDTO> Cars { get; set; }
    }
}
