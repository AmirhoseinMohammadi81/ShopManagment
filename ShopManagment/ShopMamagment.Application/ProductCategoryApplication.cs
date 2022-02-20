using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;

namespace ShopManagement.Application
{
    public class ProductCategoryApplication : IProductCategoryApplication
    {
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryApplication(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }
        public void Create(CreateProductCategory command)
        {
            if (_productCategoryRepository.Exists(x => x.Name == command.Name))
            {
                return;
            }
            var productCategory = new ProductCategory(command.Name,command.Picture,command.PictureAlt,
                command.PictureTitle,command.MetaDescription,command.Keyword,command.Slug);
            _productCategoryRepository.Create(productCategory);
            _productCategoryRepository.SaveChanges();

        }

        public void Edit(EditProductCategory command)
        {
            var productCategory = _productCategoryRepository.GetBy(command.Id);
            productCategory?.Edit(command.Name, command.Picture, command.PictureAlt,
                command.PictureTitle, command.MetaDescription, command.Keyword, command.Slug);
            _productCategoryRepository.SaveChanges();
        }

        public EditProductCategory GetDetails(int id)
        {
            throw new NotImplementedException();
        }

        public List<ProductCategoryViewModel> Search(string name)
        {
            throw new NotImplementedException();
        }
    }
}
