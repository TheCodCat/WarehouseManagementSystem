using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseManagementSystem.Client.Models
{
    public class ShipmentBoardDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Count { get; set; }
    }
}
