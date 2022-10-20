namespace SecondHandCarBidProject.AdminUI.GUI.ViewModels
{
        public record ExpertInfoUpdateViewModels(
      int Id,
      string? CentreName,
      int AddressInfoId,
      decimal? Longitude,
      decimal? Latitude,
      byte[]? Picture,
      bool IsActive,
      string? ExpertAddress,
      DateTime CreatedDate,
      DateTime? ModifiedDate,
      Guid CreatedBy,
      Guid? ModifiedBy
      );
}
