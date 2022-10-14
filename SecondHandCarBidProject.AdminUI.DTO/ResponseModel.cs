using Newtonsoft.Json.Linq;
using SecondHandCarBidProject.AdminUI.DTO;
using SecondHandCarBidProject.AdminUI.DTO.Validation;

namespace SecondHandCarBidProject.AdminUI.DTO
{
    public class ResponseModel<T>
    {
        public T Data { get; set; }
        public StatusCode statusCode { 
            get
            {
                if (IsSuccess)
                {
                    return StatusCode.Success;
                }
                else
                {
                    return statusCode;
                }
            } 
            set 
            {
                if (!IsSuccess)
                {
                    statusCode = value;
                }
            }
        }
        public bool IsSuccess { get; set; }
    }
}
