using FluentValidation;
using SecondHandCarBidProject.AdminUI.DTO.AdditionalFeeDtos;

namespace SecondHandCarBidProject.AdminUI.Validator.CommissionFee
{
    public class CommissionFeeAddValidator : AbstractValidator<CommissionFeeAddSendDTO>
    {
        public CommissionFeeAddValidator()
        {
            RuleFor(x => x.FeeAmount).GreaterThanOrEqualTo(0).WithMessage("Lütfen 0 dan Büyük Sayı Seçiniz");
            RuleFor(x => x.MinPrice).GreaterThanOrEqualTo(0).WithMessage("Lütfen 0 dan Büyük Sayı Seçiniz");
            RuleFor(x => x.MaxPrice).GreaterThanOrEqualTo(0).WithMessage("Lütfen 0 dan Büyük Sayı Seçiniz");
            RuleFor(x => x.StartDate).Must(x => x.Year < 3000).NotEmpty().WithMessage("Lütfen Geçerli bir Tarih Seçiniz");
            RuleFor(x => x.EndDate).Must(x => x.Year < 3000).NotEmpty().WithMessage("Lütfen Geçerli bir Tarih Seçiniz");
        }
    }
}
