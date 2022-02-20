using InventoryManagement.Domain.InventoryAgg;
using System;
using _0_Framework.Infrastructure;
using InventoryManagement.Application.Contracts.Inventory;
using System.Collections.Generic;
using System.Linq;
using InventoryManagement.Infrastructure.EFCore.context;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Infrastructure.EFCore.context;

namespace InventoryManagement.Infrastructure.EFCore.Repository
{
    public class InventoryRepository : RepositoryBase<int, Inventory>, IInventoryRepository

    {
        private readonly ShopContext _shopContext;
        private readonly InventoryContext _context;

        public InventoryRepository(InventoryContext context,ShopContext shopContext) : base(context)
        {
            _context = context;
            _shopContext = shopContext;
        }
        public EditInventory GetDetails(int id)
        {
            return _context.Inventory.Select(x => new EditInventory()
            {
                Id = x.Id,
                ProductId = x.ProductId,
                UnitPrice = x.UnitPrice
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<InventoryViewModel> Search(InventorySearchModel searchModel)
        {
            var products = _shopContext.Products.Select(x => new {x.Id, x.Name});
            var query = _context.Inventory.Select(x => new InventoryViewModel()
            {
                Id=x.Id,
                UnitPrice = x.UnitPrice,
                InStock = x.InStock,
                CurrentCount = x.CalculateCurrentCount(),
                CreationDate = x.CreationDate.ToShortDateString()
            });

            var inventory = query.OrderBy(x => x.Id).ToList();

            foreach (var item in inventory)
            {
                item.Product = products.FirstOrDefault(x => x.Id == item.ProductId)?.Name;
            }

            return inventory;
        }
    }
}
