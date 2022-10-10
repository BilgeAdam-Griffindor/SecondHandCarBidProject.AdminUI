namespace SecondHandCarBidProject.AdminUI.DTO.CarDetailDtos
{
    public class CarSoldToAddDTO
    {
        public Guid Id { get; set; }
        public Guid CarId { get; set; }
        public Guid SoldToBaseUserId { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
