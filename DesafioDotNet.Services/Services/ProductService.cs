using DesafioDotNet.Domain.Models;
using DesafioDotNet.Infra.Repositories.Interfaces;
using DesafioDotNet.Infra.Repositories.Interfaces.Base;
using DesafioDotNet.Services.Interfaces;
using System.Collections.Generic;

namespace DesafioDotNet.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepositoryProduct _repository;
        public ProductService(IRepositoryProduct repository)
        {
            _repository = repository;
        }

        public void Add(Product entity)
        {
            _repository.Add(entity);
        }

        public IEnumerable<Product> GetAll()
        {
            return _repository.GetAll();
        }

        public Product GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Remove(int id)
        {
            _repository.Remove(id);
        }

        public void Update(Product entity, int id)
        {
            _repository.Update(entity, id);
        }
    }
}
