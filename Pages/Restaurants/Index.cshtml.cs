﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Project_Cecilious.Data;
using Project_Cecilious.Model;

namespace Project_Cecilious.Pages.Restaurants
{
    public class IndexModel : PageModel
    {
        private readonly Project_Cecilious.Data.CeciliousContext _context;

        public IndexModel(Project_Cecilious.Data.CeciliousContext context)
        {
            _context = context;
        }

        public IList<Restaurant> Restaurant { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Restaurant = await _context.Restaurants
                .Include(r => r.RestaurantAddress)
                .Include(r => r.RestaurantCategory).ToListAsync();
        }
    }
}
