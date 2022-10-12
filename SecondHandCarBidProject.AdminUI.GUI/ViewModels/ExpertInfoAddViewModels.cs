﻿namespace SecondHandCarBidProject.AdminUI.GUI.ViewModels
{
    public record ExpertInfoAddViewModels(string? CentreName, int AddressInfoId, decimal? Longitude, decimal? Latitude, byte[]? Picture,
        byte IsActive, string? ExpertAddress, DateTime CreatedDate, DateTime? ModifiedDate, Guid CreatedBy, Guid? ModifiedBy)
    {

    }
}
