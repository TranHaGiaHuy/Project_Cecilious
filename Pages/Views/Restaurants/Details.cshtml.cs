using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Project_Cecilious.Data;
using Project_Cecilious.Model;

namespace Project_Cecilious.Pages.Views.Restaurants
{
    public class DetailsModel : PageModel
    {
        private readonly Project_Cecilious.Data.CeciliousContext _context;

        public DetailsModel(Project_Cecilious.Data.CeciliousContext context)
        {
            _context = context;
        }

        public Restaurant Restaurant { get; set; } = default!;
		public IList<DishCategory> Cates { get; set; } = default!;
		public IList<Dish> Dishes { get; set; } = default!;


		public IList<Restaurant> listRes; 

		public IList<Restaurant> GetListRestaurant()
        {
            listRes = _context.Restaurants.OrderBy(r => Guid.NewGuid()).ToList();
            if (listRes.Count>5)
            {
				listRes.Take(4);
			}
            foreach (var item in listRes)
            {
				item.RestaurantAddress = _context.RestaurantAddresses.FirstOrDefault(a => a.RestaurantAddressId == item.RestaurantAddressId);
			}
			return listRes;
		}
		
		public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurant = await _context.Restaurants.FirstOrDefaultAsync(m => m.RestaurantId == id);
            Cates = _context.DishCategories.ToList();
			Dishes = _context.Dishes.Where(d=>d.RestaurantId == restaurant.RestaurantId).ToList();
			if (restaurant == null)
            {
                return NotFound();
            }
            else
            {
                GetListRestaurant();
				restaurant.RestaurantAddress = await _context.RestaurantAddresses.FirstOrDefaultAsync(a => a.RestaurantAddressId == restaurant.RestaurantAddressId);
				restaurant.RestaurantCategory = await _context.RestaurantCategories.FirstOrDefaultAsync(a => a.RestaurantCategoryId == restaurant.RestaurantCategoryId);
				
                Restaurant = restaurant;
            }
            return Page();
        }
    }
}
