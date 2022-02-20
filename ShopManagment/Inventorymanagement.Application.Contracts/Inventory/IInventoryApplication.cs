using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace InventoryManagement.Application.Contracts.Inventory
{
    public interface IInventoryApplication
    {
        List<InventoryViewModel> Search(InventorySearchModel searchModel);
        EditInventory GetDetails(int id);
        void Increase(IncreaseInventory command);
        void Reduce(ReduceInventory command);
        void Reduce(List<ReduceInventory> command);
        void Create(CreateInventory command);
        void Edit(EditInventory command);


    }
}
