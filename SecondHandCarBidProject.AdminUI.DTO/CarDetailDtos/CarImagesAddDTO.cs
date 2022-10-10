namespace SecondHandCarBidProject.AdminUI.DTO.CarDetailDtos
{
    public class CarImagesAddDTO
    {
        public Guid Id { get; set; }
        public Guid CarId { get; set; }
        public byte[] CarImage { get; set; }
    }
}
