namespace SecondHandCarBidProject.AdminUI.DTO.CarDetailDtos
{
    public class CarFavoriteAddDTO
    {
        public Guid CarId { get; set; }
        public Guid BaseUserId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
