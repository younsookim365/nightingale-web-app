﻿/* Group:      Nightingale
   References: Liu, F (2021) Full C# Project: Supermarket Management System | ASP.NET Core Blazor, EF Core, SQL Server, Identity source code (Version 16) [Source code]. https://www.youtube.com/watch?v=DWrH7br4DsM&t=140s 

 */

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoreBusiness
{
    public class Product
    {
        // Getters and Setters
        public int ProductId { get; set; }
        [Required]
        public int? CategoryId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int? Quantity { get; set; }
        [Required]
        public double? Price { get; set; }

        // Navigation for Entity Framework Core
        public Category Category { get; set; }
    }
}
