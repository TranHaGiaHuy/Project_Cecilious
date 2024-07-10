using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Project_Cecilious.Data;
using Project_Cecilious.Model;

namespace Project_Cecilious.Pages.Views.Dishes
{
    public class IndexModel : PageModel
    {
        private readonly Project_Cecilious.Data.CeciliousContext _context;

        public IndexModel(Project_Cecilious.Data.CeciliousContext context)
        {
            _context = context;
        }

        public IList<Dish> Dishes { get;set; } = default!;
        public IList<DishCategory> DishCategories { get; set; } = default!;

        public IList<(Dish Dish, DishCategory DishCategory)> DishesWithCategories { get; set; } = new List<(Dish, DishCategory)>();
        //public IList<(Dish Dish, DishCategory DishCategory, Restaurant Restaurant)> DishesWithCategoriesAndRestaurants { get; set; } = new List<(Dish, DishCategory, Restaurant)>();
        public async Task OnGetAsync()
        {

            /*Dishes = await _context.Dishes
               .Include(d => d.DishCategory)
               .Include(d => d.Restaurant).ToListAsync();
            DishCategories = await _context.DishCategories.ToListAsync();

            DishesWithCategories = Dishes
           .Select(d => (Dish: d, DishCategory: d.DishCategory))
           .ToList();*/

            Dishes = await _context.Dishes
        .Include(d => d.DishCategory)
        .Include(d => d.Restaurant)
        .ToListAsync();
         /*   DishCategories = await _context.DishCategories.ToListAsync();
            DishesWithCategories = Dishes
          .Select(d => (Dish: d, DishCategory: d.DishCategory))
          .ToList();*/

        }
    }
}
