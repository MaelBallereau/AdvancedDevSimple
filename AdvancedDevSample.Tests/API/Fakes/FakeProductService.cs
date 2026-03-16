using AdvancedDevSample.Application.DTOs;
using AdvancedDevSample.Application.Exceptions;
using AdvancedDevSample.Application.Interface;
using AdvancedDevSample.Application.Services;
using AdvancedDevSample.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedDevSample.Tests.API.Fakes
{
    public class FakeProductService : IProductService
    {
        public bool ThrowDomainException { get; set; }
        public bool ThrowApplicationException { get; set; }
        public ProductResponse? ProductToReturn { get; set; }

        public void ChangePrice(Guid id, decimal prix)
        {
            if (ThrowDomainException)
                throw new DomainException("Règle métier violée");

            if (ThrowApplicationException)
                throw new ApplicationServiceException("Produit introuvable", System.Net.HttpStatusCode.NotFound);
        }
        public ProductResponse GetById(Guid productId)
        {
            if (ThrowApplicationException)
                throw new ApplicationServiceException("Produit introuvable", System.Net.HttpStatusCode.NotFound);

            // Valeur par défaut si le test n’a rien configuré
            var result = ProductToReturn ?? new ProductResponse
            {
                Id = productId,
                Price = 10
            };

            return result;
        }
    }
   
    }
