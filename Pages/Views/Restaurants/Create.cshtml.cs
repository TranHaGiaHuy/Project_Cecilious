using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project_Cecilious.Data;
using Project_Cecilious.Model;

namespace Project_Cecilious.Pages.Views.Restaurants
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
        ViewData["RestaurantAddressId"] = new SelectList(_context.RestaurantAddresses, "RestaurantAddressId", "RestaurantAddressId");
        ViewData["RestaurantCategoryId"] = new SelectList(_context.RestaurantCategories, "RestaurantCategoryId", "RestaurantCategoryId");
            return Page();
        }

        [BindProperty]
        public Restaurant Restaurant { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Restaurants.Add(Restaurant);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
