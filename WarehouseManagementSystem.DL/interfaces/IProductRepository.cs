using System;
using System.Collections.Generic;
using System.Text;
using WarehouseManagementSystem.DL.models;

namespace WarehouseManagementSystem.DL.interfaces
{
    public interface IProductRepository
    {
        public Task<Product[]> GetProducts();
        public Task<Party[]> GetParty();
    }
}
