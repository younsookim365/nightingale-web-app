﻿using CoreBusiness;
using System.Collections.Generic;

namespace UseCases
{
    public interface IViewVehiclesUseCase
    {
        IEnumerable<Vehicle> Execute();
    }
}
