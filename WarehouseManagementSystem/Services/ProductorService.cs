using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Mapster;
using WarehouseManagementSystem.AL.services;
using WarehouseManagementSystemServer;

namespace WarehouseManagementSystem.PL.Services
{
    public class ProductorService : Productor.ProductorBase
    {
        private readonly ProductServiceAL productServiceAL;

        public ProductorService(ProductServiceAL productServiceAL)
        {
            this.productServiceAL = productServiceAL;
        }
        public override async Task<AllProductResponce> GetAllProduct(Empty request, ServerCallContext context)
        {
            var result = await productServiceAL.GetAllProducts();
            var products = result.Adapt<Product[]>();
            var responce = new AllProductResponce();
            responce.Products.AddRange(products);

            return responce;
        }

        public override async Task<ShipmentResponce> GetPartiesToCell(Empty request, ServerCallContext context)
        {
            var result = await productServiceAL.GetPartiesToCell();
            var partyes = result.Adapt<PartyResponce[]>();
            var responce = new ShipmentResponce();
            responce.Responce.AddRange(partyes);

            return responce;
        }
    }
}
