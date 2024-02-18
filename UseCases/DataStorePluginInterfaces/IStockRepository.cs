/* Group:      8
   References: Liu, F (2021) Full C# Project: Supermarket Management System | ASP.NET Core Blazor, EF Core, SQL Server, Identity source code (Version 16) [Source code]. https://www.youtube.com/watch?v=DWrH7br4DsM&t=140s

 */

using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Text;

namespace UseCases.DataStorePluginInterfaces
{
    public interface IStockRepository
    {
        IEnumerable<Stock> GetStocks();
        void AddStock(Stock stock);
        void UpdateStock(Stock stock);
        Stock GetStockById(int stockId);
        void DeleteStock(int stockId);
    }
}