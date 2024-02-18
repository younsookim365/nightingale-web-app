using CoreBusiness;
using System.Collections.Generic;

namespace UseCases
{
    public interface IViewStocksUseCase
    {
        IEnumerable<Stock> Execute();
    }
}
