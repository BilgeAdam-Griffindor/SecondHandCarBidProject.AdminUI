namespace SecondHandCarBidProject.AdminUI.DTO
{
    public class CarListPageDTO
    {
        public List<IdNameListDTO> BrandList { get; set; }
        public List<IdNameListDTO> ModelList { get; set; }
        public List<IdNameListDTO> StatusList { get; set; }
        public List<CarListTableRowDTO> CarTableRows { get; set; }
    }
}