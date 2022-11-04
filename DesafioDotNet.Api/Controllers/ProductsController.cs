using DesafioDotNet.Domain.Models;
using DesafioDotNet.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DesafioDotNet.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return productService.GetAll();
        }

        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return productService.GetById(id);
        }

        [HttpPost]
        public IEnumerable<Product> Post([FromBody]Product product)
        {
            productService.Add(product);
            return Get();
        }

        [HttpPut("{id}")]
        public Product Put(int id, [FromBody] Product product)
        {
            productService.Update(product, id);
            return Get(id);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            productService.Remove(id);
        }
    }
}
