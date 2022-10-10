namespace SecondHandCarBidProject.AdminUI.DTO.CarDetailDtos
{
    public class CommissionFeeAddDTO
    {
        public Guid Id { get; set; }
        public decimal FeeAmount { get; set; }
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
