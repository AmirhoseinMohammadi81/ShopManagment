using InventoryManagement.Application.Contracts.Inventory;
using InventoryManagement.Domain.InventoryAgg;
using System;
using System.Collections.Generic;

namespace InventoryManagement.Application
{
    public class InventoryApplication : IInventoryApplication
    {
        private readonly IInventoryRepository _inventoryRepository;

        public InventoryApplication(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }
        public void Create(CreateInventory command)
        {
            if (_inventoryRepository.Exists(x => x.ProductId == command.ProductId))
            {
                return;
            }
            var inventory = new Inventory(command.ProductId, command.UnitPrice);
            _inventoryRepository.Create(inventory);
            _inventoryRepository.SaveChanges();
        }

        public void Edit(EditInventory command)
        {
            var inventory = _inventoryRepository.GetBy(command.Id);
            if (inventory == null)
            {
                return;
            }
            inventory.Edit(command.ProductId,command.UnitPrice);
            _inventoryRepository.SaveChanges();
        }

        public EditInventory GetDetails(int id)
        {
            throw new NotImplementedException();
        }

        public void Increase(IncreaseInventory command)
        {
            const int operatorId = 1;
            var inventory = _inventoryRepository.GetBy(command.ProductId);
            if (inventory == null)
            {
                return;
            }
            inventory.Increase(command.Count,operatorId,command.Description);
            _inventoryRepository.SaveChanges();
        }

        public void Reduce(ReduceInventory command)
        {
            const int operatorId = 1;
            var inventory = _inventoryRepository.GetBy(command.ProductId);
            if (inventory == null)
            {
                return;
            }

            inventory.Reduce(command.Count, operatorId, command.Description,command.OrderId);
            _inventoryRepository.SaveChanges();
        }

        public void Reduce(List<ReduceInventory> command)
        {
            const int operatorId = 1;
            foreach (var item in command)
            {
                var inventory = _inventoryRepository.GetBy(item.ProductId);
                if (inventory == null)
                {
                    return;
                }
                inventory.Reduce(item.Count,operatorId,item.Description,item.OrderId);
            }
            _inventoryRepository.SaveChanges();
        }

        public List<InventoryViewModel> Search(InventorySearchModel searchModel)
        {
            throw new NotImplementedException();
        }
    }
}
