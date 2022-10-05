using SecondHandCarBidProject.AdminUI.GUI.Common.Validation;

namespace SecondHandCarBidProject.AdminUI.GUI.Common.DTOs
{
    public class ResponseModel<T>
    {
        public T Data { get; set; }
        public BusinessValidationRule businessValidationRule { get; set; }
        public bool IsSuccess { get; set; }
    }
}
