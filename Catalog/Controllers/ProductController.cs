using Catalog.Models;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Contracts;

namespace Catalog.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IPublishEndpoint _publish;
        public ProductController(IPublishEndpoint publish)
        {
            _publish = publish;

        }

        [HttpPost]
        public Task Post([FromBody] ProductCreateDto product)
        {
            _publish.Publish<ProductMessage>(new
            {
                Code = product.Code,
                Name = product.Name
            });
            return Task.CompletedTask;
        }
    }
}
