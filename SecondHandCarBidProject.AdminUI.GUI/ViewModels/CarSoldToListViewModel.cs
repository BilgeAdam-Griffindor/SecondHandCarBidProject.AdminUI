﻿using SecondHandCarBidProject.AdminUI.DTO.CarDtos;

namespace SecondHandCarBidProject.AdminUI.GUI.ViewModels
{
    public record CarSoldToListViewModel
 (
     List<CarSoldToTableRowDTO> TableRows
 );
}
