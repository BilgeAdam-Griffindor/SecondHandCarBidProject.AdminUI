namespace SecondHandCarBidProject.AdminUI.DTO.CarDetailDtos
{
    public class CarPropertyValueDTO
    {
        public Guid Id { get; set; }
        public string PropertValue { get; set; }
        public Guid TopPropertyValueId { get; set; }
        public bool IsActive { get; set; }
    }
}
