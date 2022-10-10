namespace SecondHandCarBidProject.AdminUI.DTO.CarDetailDtos
{
    public class CommissionFeeDTO
    {
        public Guid Id { get; set; }
        public decimal FeeAmount { get; set; }
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }

    }
}
