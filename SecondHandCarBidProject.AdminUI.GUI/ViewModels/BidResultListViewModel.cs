﻿using SecondHandCarBidProject.AdminUI.DTO.BidDtos;

namespace SecondHandCarBidProject.AdminUI.GUI.ViewModels
{
    public record BidResultListViewModel
    (
        List<BidResultListTableRowsDTO> TableRows
    );
}
