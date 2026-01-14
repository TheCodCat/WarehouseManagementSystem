using Microsoft.EntityFrameworkCore;
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

        public async Task<Party[]> GetParty()
        {
            return dataContext.parties.Include(x => x.Product).Include(x => x.CellStorage).ToArray();
        }

        public async Task<Product[]> GetProducts()
        {
            return dataContext.products.ToArray();
        }
    }
}
