using AdvancedDevSample.Application.DTOs;
using AdvancedDevSample.Application.Exceptions;
using AdvancedDevSample.Application.Interface;
using AdvancedDevSample.Domain.Entities;
using AdvancedDevSample.Domain.Exceptions;
using AdvancedDevSample.Domain.Interfaces.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedDevSample.Application.Services
{
    public class ProductService: IProductService
    {
        private readonly IProductRepository _repo;
        public ProductService(IProductRepository repo)
        {
            _repo = repo;
        }

        public void ChangeProductPrice(Guid productId, ChangePriceRequest request)
        {
            var product = GetProduct(productId);
            product.ChangePrice(request.NewPrice);
            _repo.Save(product);
        }
        public void ChangeProductLibelle(Guid productId, ChangeLibelleRequest request)
        {
            var product = GetProduct(productId);
            product.ChangeLibelle(request.NewLibelle);
            _repo.Save(product);
        }

        private Product GetProduct(Guid id)
        {
            return _repo.GetById(id)
                ?? throw new ApplicationServiceException("Produit introuvable",System.Net.HttpStatusCode.NotFound);
        }
        public void ChangePrice(Guid id, decimal prix)
        {
            var product = GetProduct(id);
            product.ChangePrice(prix);
            _repo.Save(product);
        }
        public ProductResponse GetById(Guid productId)
        {
            var product = GetProduct(productId);

            var result = new ProductResponse
            {
                Id = productId,
                Price = product.Price
            };

            return result;
        }
    }
}
