﻿using DotNetNote.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DotNetNote.ViewComponents
{
    public class TechListViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var techLists = new List<Tech>
            {
                new Tech{Id =1, Title = "ASP.NET Core"},
                new Tech{Id = 2, Title = "BootStrap"},
                new Tech{Id = 3, Title = "C#"},
                new Tech{Id = 4, Title = "Dapper"},
                new Tech{Id = 5, Title = "Azure"},
                new Tech{Id= 6, Title = "jquery"},
                new Tech{Id = 7, Title="Angular"}
            };

            return View(techLists);
        }
    }
}
