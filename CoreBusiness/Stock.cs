﻿/* Group:      Nightingale
   References: Liu, F (2021) Full C# Project: Supermarket Management System | ASP.NET Core Blazor, EF Core, SQL Server, Identity source code (Version 16) [Source code]. https://www.youtube.com/watch?v=DWrH7br4DsM&t=140s 

 */

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoreBusiness
{
    public class Stock
    {
        // Getters and Setters
        public int StockId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Type { get; set; }
    }
}