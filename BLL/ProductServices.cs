using AutoMapper;
using BLL.DTO;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BLL
{
    public class ProductServices : IProductServices
    {
        private readonly UnitOfWork _unitOfWork;
        public ProductServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ProductDto GetProductById(int productId)
        {
            var product = _unitOfWork.ProductRepository.GetByID(productId);
            if (product != null)
            {
                //here, make use of AutoMapper plugin to do Object-Object Mapping between Dto and Model
                //var productModel = Mapper.Map<Product, ProductDto>(product);
                var productModel = new ProductDto();
                productModel.ProductId = product.ProductId;
                productModel.ProductName = product.ProductName;
                return productModel;
            }
            return null;
        }

        public IEnumerable<ProductDto> GetAllProducts()
        {
            var products = _unitOfWork.ProductRepository.GetAll().ToList();
            if (products.Any())
            {
                var productsModel = Mapper.Map<List<Product>, List<ProductDto>>(products);
                return productsModel;
            }
            return null;
        }

        public int CreateProduct(ProductDto productDto)
        {
            using (var scope = new TransactionScope())
            {
                var product = new Product
                {
                    ProductName = productDto.ProductName
                };
                _unitOfWork.ProductRepository.Insert(product);
                _unitOfWork.Save();
                scope.Complete();
                return product.ProductId;
            }
        }

        public bool UpdateProduct(int productId, ProductDto productDto)
        {
            var success = false;
            if (productDto != null)
            {
                using (var scope = new TransactionScope())
                {
                    var product = _unitOfWork.ProductRepository.GetByID(productId);
                    if (product != null)
                    {
                        product.ProductName = productDto.ProductName;
                        _unitOfWork.ProductRepository.Update(product);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }

        public bool DeleteProduct(int productId)
        {
            var success = false;
            if (productId > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var product = _unitOfWork.ProductRepository.GetByID(productId);
                    if (product != null)
                    {

                        _unitOfWork.ProductRepository.Delete(product);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }
    }
}
