using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Project_Cecilious.Data;
using Project_Cecilious.Model;

namespace Project_Cecilious.Pages.Dishes
{
    public class DetailsModel : PageModel
    {
        private readonly Project_Cecilious.Data.CeciliousContext _context;

        public DetailsModel(Project_Cecilious.Data.CeciliousContext context)
        {
            _context = context;
        }

        public Dish Dish { get; set; } = default!;
		public Restaurant currentRestaurant { get; set; } = default!;

		public IList<DishCategory> Cates { get; set; } = default!;
        public IList<Dish> Dishes { get; set; } = default!;

		public IList<Restaurant> listRes;

		public double totalReviewPoint;


		public IList<Review> listReview;

		public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dish = await _context.Dishes.Include(d=>d.Restaurant).FirstOrDefaultAsync(m => m.DishId == id);
            
            if (dish == null)
            {
                return NotFound();
            }
            else
            {
                Dish = dish;
                Dish.DishImages = await _context.DishImages.Where(a => a.DishId == id).ToListAsync();
				currentRestaurant = _context.Restaurants.FirstOrDefault(b=>b.RestaurantId == Dish.RestaurantId);
				Dish.Restaurant.RestaurantAddress =  _context.RestaurantAddresses.FirstOrDefault(c => c.RestaurantAddressId == currentRestaurant.RestaurantAddressId);
                listReview = _context.Reviews.Where(a => a.RestaurantId == currentRestaurant.RestaurantId).ToList();
				foreach (var item in listReview)
				{
					item.User = _context.Users.FirstOrDefault(fr => fr.UserId == item.UserId);
					totalReviewPoint += item.Rating;
				}
				totalReviewPoint /= listReview.Count;
			}
            return Page();
        }
    }
   /* var currentRestaurent = await _context.Restaurants.FirstOrDefaultAsync(m => m.RestaurantId == id);
    currentRestaurent.RestaurantAddress = await _context.RestaurantAddresses.FirstOrDefaultAsync(a => a.RestaurantAddressId == currentRestaurent.RestaurantAddressId);
    currentRestaurent.RestaurantCategory = await _context.RestaurantCategories.FirstOrDefaultAsync(a => a.RestaurantCategoryId == currentRestaurent.RestaurantCategoryId);
    currentRestaurent.RestaurantImages = await _context.RestaurantImages.Where(a => a.RestaurantId != currentRestaurent.RestaurantId).ToListAsync();*/
}
