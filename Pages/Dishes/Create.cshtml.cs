using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project_Cecilious.Data;
using Project_Cecilious.Model;

namespace Project_Cecilious.Pages.Dishes
{
    public class CreateModel : PageModel
    {
        private readonly Project_Cecilious.Data.CeciliousContext _context;

        public CreateModel(Project_Cecilious.Data.CeciliousContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["DishCategoryId"] = new SelectList(_context.DishCategories, "DishCategoryId", "DishCategoryId");
        ViewData["RestaurantId"] = new SelectList(_context.Restaurants, "RestaurantId", "RestaurantId");
            return Page();
        }

        [BindProperty]
        public Dish Dish { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Dishes.Add(Dish);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
