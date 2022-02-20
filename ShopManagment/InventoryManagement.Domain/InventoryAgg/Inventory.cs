using _0_Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using InventoryManagement.Domain.InventoryOperationAgg;

namespace InventoryManagement.Domain.InventoryAgg
{
    public class Inventory:EntityBase
    {
        public int ProductId { get; set; }
        public int UnitPrice { get; set; }
        public bool InStock { get; set; }
        public List<InventoryOperation> InventoryOperations { get; set; }

        public Inventory(int productId, int unitPrice)
        {
            ProductId = productId;
            UnitPrice = unitPrice;
            InStock = false;
        }

        public void Edit(int productId, int unitPrice)
        {
            ProductId = productId;
            UnitPrice = unitPrice;
        }

        public int CalculateCurrentCount()
        {
            var plus = InventoryOperations.Where(x => x.Operation).Sum(x => x.Count);
            var minus = InventoryOperations.Where(x => !x.Operation).Sum(x => x.Count);
            return plus - minus;
        }

        public void Increase(int count, int operatorId, string description)
        {
            var currentCount = CalculateCurrentCount() + count;
            var operation = new InventoryOperation(true,count,operatorId,description,
                currentCount,0,Id);
            InventoryOperations.Add(operation);
            InStock = currentCount > 0;
        }

        public void Reduce(int count, int operatorId, string description, int orderId)
        {
            var currentCount = CalculateCurrentCount() + count;
            var operation = new InventoryOperation(false,count,operatorId,
                description,currentCount,orderId,Id);
            InventoryOperations.Add(operation);
            InStock = currentCount > 0;
        }

    }
}
