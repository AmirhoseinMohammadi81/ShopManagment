using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Domain;
using InventoryManagement.Application.Contracts.Inventory;

namespace InventoryManagement.Domain.InventoryAgg
{
    public interface IInventoryRepository:IRepository<int,Inventory>
    {
        List<InventoryViewModel> Search(InventorySearchModel searchModel);
        EditInventory GetDetails(int id);
    }
}
