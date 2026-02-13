using ProductsApi.DTOs;
namespace ProductsApi.Services
{
    public interface IProductService
    {
        List<ProductReadDto> GetAll();
        ProductReadDto GetById(int id);
        ProductReadDto Create(ProductCreateDto productReadDto);
        bool UpdatePut(int id, ProductUpdateDto dto);
        bool UpdatePatch(int id, ProductUpdateDto dto);
        bool Delete(ProductDeleteDto dto);

    }
}
