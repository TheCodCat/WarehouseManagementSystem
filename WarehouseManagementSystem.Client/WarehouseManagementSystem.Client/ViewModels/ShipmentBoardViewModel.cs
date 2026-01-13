using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FastCloner;
using System.Collections.ObjectModel;
using System.Linq;
using WarehouseManagementSystem.Client.Models;

namespace WarehouseManagementSystem.Client.ViewModels
{
    public partial class MainViewModel
    {
        [ObservableProperty]
        private ObservableCollection<ShipmentBoardDto> shipmentBoardDtos = new ObservableCollection<ShipmentBoardDto>()
        {
            new ShipmentBoardDto(){ Id = 24, Description = "asddsa", Title = "sdoiydf",Count = 1}
        };
        [RelayCommand]
        public async void AddCount(ShipmentBoardDto shipmentBoardDto)
        {
            if (shipmentBoardDto == null) return;
            
            var clone = FastCloner.FastCloner.DeepClone(shipmentBoardDto);
            clone.Count += 1;

            var index = ShipmentBoardDtos.IndexOf(shipmentBoardDto);
            ShipmentBoardDtos[index] = clone;

            //ShipmentBoardDtos.Remove(shipmentBoardDto);
        }

        [RelayCommand]
        public async void MinusCount(ShipmentBoardDto shipmentBoardDto)
        {
            if (shipmentBoardDto == null) return;

            shipmentBoardDto.Count -= 1;
            if (shipmentBoardDto.Count <= 0)
                ShipmentBoardDtos.Remove(shipmentBoardDto);
            else
            {
                var item = new ShipmentBoardDto()
                {
                    Id = shipmentBoardDto.Id,
                    Description = shipmentBoardDto.Description,
                    Title = shipmentBoardDto.Title,
                    Count = shipmentBoardDto.Count
                };

                var index = ShipmentBoardDtos.IndexOf(shipmentBoardDto);
                ShipmentBoardDtos[index] = item;
            }
        }
    }
}
