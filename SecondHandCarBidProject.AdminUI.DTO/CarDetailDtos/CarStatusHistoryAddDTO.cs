namespace SecondHandCarBidProject.AdminUI.DTO.CarDetailDtos
{
    public class CarStatusHistoryAddDTO
    {
        public Guid Id { get; set; }
        public Guid CarId { get; set; }
        public int StatusValueId { get; set; }
        public string Explanation { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
