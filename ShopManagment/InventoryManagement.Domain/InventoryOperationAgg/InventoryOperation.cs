using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Domain.InventoryAgg;

namespace InventoryManagement.Domain.InventoryOperationAgg
{
    public class InventoryOperation
    {
        public int Id { get; set; }
        public bool Operation { get; set; }
        public int Count { get; set; }
        public int OperatorId { get; set; }
        public DateTime OperationDate { get; set; }
        public string Description { get; set; }
        public int CurrentCount { get; set; }
        public int OrderId { get; set; }
        public Inventory Inventory { get; set; }
        public int InventoryId { get; set; }

        public InventoryOperation(bool operation, int count, int operatorId, string description, int currentCount,
            int orderId, int inventoryId)
        {
            Operation = operation;
            Count = count;
            Count = count;
            OperatorId = operatorId;
            CurrentCount = currentCount;
            OrderId = orderId;
            InventoryId = inventoryId;
            OperationDate = DateTime.Now;
        }
    }
}
