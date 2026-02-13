using System.Xml.Linq;
using ProductsApi.DTOs;
using ProductsApi.Models;
namespace ProductsApi.Services
{
    public class ProductService : IProductService
    {
        private static List<Product> products = new List<Product>
        {
        new Product{Id=1,Name="Television",Price=50000},
        new Product{ Id = 2, Name = "Washing Machine", Price = 40000}
        };
        //Get All
        public List<ProductReadDto> GetAll()
        {
            return products.Select(p=>new ProductReadDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = (decimal)p.Price
            }).ToList();
        }
        //Get BY ID
        public ProductReadDto GetById(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null) return null;
            return new ProductReadDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = (decimal)product.Price
            };
        }
        //Post
        public ProductReadDto Create(ProductCreateDto dto)
        {
            var newProduct = new Product
            {
                Id = products.Max(p => p.Id) + 1,
                Name = dto.Name,
                Price = dto.Price
            };
            products.Add(newProduct);
            return new ProductReadDto
            {
                Id = newProduct.Id,
                Name = newProduct.Name,
                Price = (decimal)newProduct.Price
            };
        }
        // PUT: Full Update
        public bool UpdatePut(int id, ProductUpdateDto dto)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null) return false;

            product.Name = dto.Name;
            product.Price = dto.Price;

            return true;
        }
        // PATCH: Partial Update
        public bool UpdatePatch(int id, ProductUpdateDto dto)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null) return false;

            if (dto.Name != null)
                product.Name = dto.Name;

            if (dto.Price != 0)
                product.Price = dto.Price;

            return true;
        }
        // DELETE
        public bool Delete(ProductDeleteDto dto)
        {
            var product = products.FirstOrDefault(p => p.Id == dto.Id);
            if (product == null) return false;

            products.Remove(product);
            return true;
        }
    }
    }
