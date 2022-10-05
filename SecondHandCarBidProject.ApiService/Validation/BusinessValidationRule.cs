using System.ComponentModel;

namespace SecondHandCarBidProject.ApiService.Validation
{
    public enum BusinessValidationRule
    {
        [Description("Başarılı.")] Success = 200,
        [Description("Gönderdiğiniz alanların doğruluğundan emin olunuz.")] BadRequest = 400,
        [Description("Lütfen önce giriş yapınız.")] Unauthorized = 401,
        [Description("İşlem zaman aşımına uğradı.")] TimeOut = 504
    }
}
