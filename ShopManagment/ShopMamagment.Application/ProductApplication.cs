using ShopManagement.Application.Contracts.Product;
using ShopManagement.Domain.ProductAgg;
using System.Collections.Generic;

namespace ShopManagement.Application
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductRepository _productRepository;

        public ProductApplication(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public void Create(CreateProduct command)
        {
            if (_productRepository.Exists(x => x.Name == command.Name))
            {
                return;
            }
            var product = new Product(command.Name, command.Picture, command.PictureAlt, command.PictureTitle
                , command.MetaDescription, command.Keyword, command.Slug, command.CategoryId);
            _productRepository.Create(product);
            _productRepository.SaveChanges();

        }

        public void Edit(EditProduct command)
        {
            var product = _productRepository.GetBy(command.Id);
            product?.Edit(command.Name,command.Picture,command.PictureAlt,command.PictureTitle
                ,command.MetaDescription,command.Keyword,command.Slug,command.CategoryId);
            _productRepository.SaveChanges();
        }

        public EditProduct GetDetails(int id)
        {
            throw new System.NotImplementedException();

        }

        public List<ProductViewModel> Search(ProductSearchModel searchModel)
        {
            throw new System.NotImplementedException();
        }
    }
}
