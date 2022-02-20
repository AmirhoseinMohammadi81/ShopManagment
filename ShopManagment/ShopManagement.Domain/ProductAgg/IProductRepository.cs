
using System.Collections.Generic;
using _0_Framework.Domain;
using ShopManagement.Application.Contracts.Product;

namespace ShopManagement.Domain.ProductAgg
{
    public interface IProductRepository : IRepository<int,Product>
    {
        List<ProductViewModel> Search(ProductSearchModel searchModel);
        EditProduct GetDetails(int id);
        
    }
}
