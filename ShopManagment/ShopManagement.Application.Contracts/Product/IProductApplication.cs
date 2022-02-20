using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contracts.Product
{
    public interface IProductApplication
    {
        void Create(CreateProduct command);
        void Edit(EditProduct command);
        EditProduct GetDetails(int id);
        List<ProductViewModel> Search(ProductSearchModel searchModel);
    }
}
