/* Group:      8
   References: Liu, F (2021) Full C# Project: Supermarket Management System | ASP.NET Core Blazor, EF Core, SQL Server, Identity source code (Version 16) [Source code]. https://www.youtube.com/watch?v=DWrH7br4DsM&t=140s

 */

using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL
{
    public class StockRepository : IStockRepository
    {
        private readonly MarketContext db;

        public StockRepository(MarketContext db)
        {
            this.db = db;
        }

        public void AddStock(Stock stock)
        {
            db.Stocks.Add(stock);
            db.SaveChanges();
        }

        public void DeleteStock(int stockId)
        {
            var stock = db.Stocks.Find(stockId);
            if (stock == null) return;

            db.Stocks.Remove(stock);
            db.SaveChanges();
        }

        public IEnumerable<Stock> GetStocks()
        {
            return db.Stocks.ToList();
        }

        public Stock GetStockById(int stockId)
        {
            return db.Stocks.Find(stockId);
        }

        public void UpdateStock(Stock stock)
        {
            var cat = db.Stocks.Find(stock.StockId);
            cat.Type = stock.Type;
            cat.Type = stock.Type;
            db.SaveChanges();
        }
    }
}
