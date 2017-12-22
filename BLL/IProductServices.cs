using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IProductServices
    {
        ProductDto GetProductById(int productId);
        IEnumerable<ProductDto> GetAllProducts();
        int CreateProduct(ProductDto productDto);
        bool UpdateProduct(int productId, ProductDto productDto);
        bool DeleteProduct(int productId);
    }
}
