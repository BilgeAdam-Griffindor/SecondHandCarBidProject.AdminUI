namespace SecondHandCarBidProject.AdminUI.DTO.CarDetailDtos
{
    public class CarModelDTO
    {
        public int Id { get; set; }
        public short CarBrandId { get; set; }
        public string ModelName { get; set; }
        public bool IsActive { get; set; }
        public List<CarDetailUpdatePageDTO> Brands { get; set; }
    }
}
