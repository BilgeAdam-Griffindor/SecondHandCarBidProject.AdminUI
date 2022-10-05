using SecondHandCarBidProject.ApiService.Validation;

namespace SecondHandCarBidProject.ApiService.Dto_s
{
    public class ResponseModel<T>
    {
        public T Data { get; set; }
        public BusinessValidationRule businessValidationRule { get; set; }
        public bool IsSuccess { get; set; }
    }
}
