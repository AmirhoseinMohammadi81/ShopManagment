using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contracts.ProductCategory
{
    public interface IProductCategoryApplication
    {
        List<ProductCategoryViewModel> Search(string name);
        EditProductCategory GetDetails(int id);
        void Create(CreateProductCategory command);
        void Edit(EditProductCategory command);
    }
}
