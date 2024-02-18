/* Group:      8
   References: Liu, F (2021) Full C# Project: Supermarket Management System | ASP.NET Core Blazor, EF Core, SQL Server, Identity source code (Version 16) [Source code]. https://www.youtube.com/watch?v=DWrH7br4DsM&t=140s

 */

using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory
{
    public class StockInMemoryRepository : IStockRepository
    {
        private List<Stock> stocks;

        public StockInMemoryRepository()
        {
            // Default Vehicles
            stocks = new List<Stock>()
            {
                new Stock { StockId = 1, Name = "Furniture", Type = "Collection"},
                new Stock { StockId = 2, Name = "Bric n brac", Type = "Collection"},
                new Stock { StockId = 3, Name = "Clothing", Type = "Delivery"}
            };

        }

        public void AddStock(Stock stock)
        {
            if (stocks.Any(x => x.Name.Equals(stock.Name, StringComparison.OrdinalIgnoreCase))) return;

            if (stocks != null && stocks.Count > 0)
            {
                var maxId = stocks.Max(x => x.StockId);
                stock.StockId = maxId + 1;
            }
            else
            {
                stock.StockId = 1;
            }


            stocks.Add(stock);
        }

        public void UpdateStock(Stock stock)
        {
            var stockToUpdate = GetStockById(stock.StockId);
            if (stockToUpdate != null)
            {
                stockToUpdate.Name = stock.Name;
                stockToUpdate.Type = stock.Type;
            }
        }

        public IEnumerable<Stock> GetStocks()
        {
            return stocks;
        }

        public Stock GetStockById(int stockId)
        {
            return stocks?.FirstOrDefault(x => x.StockId == stockId);
        }

        public void DeleteStock(int stockId)
        {
            stocks?.Remove(GetStockById(stockId));
        }
    }
}
