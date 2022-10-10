namespace SecondHandCarBidProject.AdminUI.DTO.CarDetailDtos
{
    public class CarStatusHistoryDTO
    {
        public Guid Id { get; set; }
        public Guid CarId { get; set; }
        public int StatusValueId { get; set; }
        public string Explanation { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public List<CarPropertyValueDTO> Status { get; set; }
        public List<CarDetailUpdatePageDTO> Cars { get; set; }
    }
}
