using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Contracts.Inventory
{
    public class InventoryViewModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public bool InStock { get; set; }
        public string Product { get; set; }
        public int CurrentCount { get; set; }
        public int UnitPrice { get; set; }
        public string CreationDate { get; set; }
    }
}
