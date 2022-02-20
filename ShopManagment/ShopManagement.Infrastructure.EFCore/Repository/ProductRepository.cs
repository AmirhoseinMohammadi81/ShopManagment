using _0_Framework.Infrastructure;
using ShopManagement.Domain.ProductAgg;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Infrastructure.EFCore.context;
using ShopManagement.Application.Contracts.Product;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class ProductRepository : RepositoryBase<int, Product>, IProductRepository
    {
        private readonly ShopContext _context;
        public ProductRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public EditProduct GetDetails(int id)
        {
            return _context.Products.Select(x=>new EditProduct()
            {
                Id = x.Id,
                Name = x.Name,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                MetaDescription = x.MetaDescription,
                Keyword = x.Keyword,
                Slug = x.Slug,
                CategoryId = x.CategoryId
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ProductViewModel> Search(ProductSearchModel searchModel)
        {
            var query = _context.Products.Include(x=>x.ProductCategory).Select(x => new ProductViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Picture = x.Picture,
                CategoryId = x.CategoryId,
                Product = x.ProductCategory.Name,
                CreationDate = x.CreationDate.ToShortDateString()
            });

            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));

            return query.OrderBy(x => x.Id).ToList();

        }
    }
}
