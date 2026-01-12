using WarehouseManagementSystem.DL.interfaces;
using WarehouseManagementSystem.DL.models;
using WarehouseManagementSystem.IL.databases;

namespace WarehouseManagementSystem.PL.repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext dataContext;

        public ProductRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public async Task<Product[]> GetProducts()
        {
            return dataContext.products.ToArray();
        }
    }
}
