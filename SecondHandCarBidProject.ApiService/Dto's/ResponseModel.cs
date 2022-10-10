using SecondHandCarBidProject.AdminUI.DTO.Validation;

    namespace SecondHandCarBidProject.AdminUI.DTO
{
    public class ResponseModel<T>
    {
        public T Data { get; set; }
        public BusinessValidationRule businessValidationRule { get; set; }
        public bool IsSuccess { get; set; }
    }
}
