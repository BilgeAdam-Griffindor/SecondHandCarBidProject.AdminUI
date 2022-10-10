namespace SecondHandCarBidProject.AdminUI.DTO.CarDetailDtos
{
    public class CarImagesDTO
    {
        public Guid Id { get; set; }
        public Guid CarId { get; set; }
        public byte[] CarImage { get; set; }
        public bool IsActive { get; set; }
        public List<CarDetailUpdatePageDTO> Cars { get; set; }
    }
}
