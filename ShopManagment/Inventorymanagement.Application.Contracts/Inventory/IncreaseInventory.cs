using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Contracts.Inventory
{
    public class IncreaseInventory
    {
        public int InventoryId { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public int UnitPrice { get; set; }
        public string Description { get; set; }

    }
}
