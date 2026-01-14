using Mapster;
using System;
using System.Collections.Generic;
using System.Text;
using WarehouseManagementSystem.AL.Dtos;
using WarehouseManagementSystem.DL.interfaces;
using WarehouseManagementSystem.DL.models;

namespace WarehouseManagementSystem.AL.services
{
    public class ProductServiceAL
    {
        private readonly IUnitOfWork unitOfWork;

        public ProductServiceAL(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<ProductDto[]> GetAllProducts()
        {
            var results = await unitOfWork.ProductRepository.GetProducts();
            return results.Adapt<ProductDto[]>();
        }

        public async Task<PartyDto[]> GetPartiesToCell()
        {
            var result = await unitOfWork.ProductRepository.GetParty();
            return result.Adapt<PartyDto[]>();
        }
    }
}
