/* Group:      8
   References: Liu, F (2021) Full C# Project: Supermarket Management System | ASP.NET Core Blazor, EF Core, SQL Server, Identity source code (Version 16) [Source code]. https://www.youtube.com/watch?v=DWrH7br4DsM&t=140s

 */

using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Text;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
    public class EditStockUseCase : IEditStockUseCase
    {
        private readonly IStockRepository stockRepository;

        public EditStockUseCase(IStockRepository stockRepository)
        {
            this.stockRepository = stockRepository;
        }

        public void Execute(Stock stock)
        {
            stockRepository.UpdateStock(stock);
        }
    }
}