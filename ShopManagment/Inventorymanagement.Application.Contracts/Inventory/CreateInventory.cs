using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Contracts.Inventory
{
    public class CreateInventory
    {
        public int ProductId { get; set; }
        public int UnitPrice { get; set; }
    }
}
