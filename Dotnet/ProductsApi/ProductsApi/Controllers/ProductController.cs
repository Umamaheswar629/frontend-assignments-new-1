using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsApi.DTOs;
using ProductsApi.Services;

namespace ProductsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_productService.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product= _productService.GetById(id);
            if (product == null) return NotFound("Product Not Found");
            return Ok(product);
        }
        [HttpPost]
        public IActionResult Create(ProductCreateDto dto)
        {
            var product=_productService.Create(dto);
            return CreatedAtAction(nameof(GetById),new{ id = product.Id }, product);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id,ProductUpdateDto dto)
        {
            if (!_productService.UpdatePut(id, dto))
                return NotFound();

            return NoContent();
        }
        [HttpPatch("{id}")]
        public IActionResult UpdatePatch(int id,ProductUpdateDto dto)
        {
            if(!_productService.UpdatePatch(id, dto)) return NotFound();
            return NoContent();
        }
        [HttpDelete]
        public IActionResult Delete(ProductDeleteDto dto)
        {
            if (!_productService.Delete(dto)) return NotFound();
            return NoContent();
        }
        
}
}
