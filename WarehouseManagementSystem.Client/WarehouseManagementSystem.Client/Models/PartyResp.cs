using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseManagementSystem.Client.Models
{
    public class PartyResp
    {
        public int Id { get; set; }
        public PartyMaui Party { get; set; }
        public string CellTitle { get; set; }
    }
}
