using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
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

		public IList<Restaurant> Restaurants { get;set; } = default!;
		public IList<RestaurantCategory> RestaurantCategories { get; set; } = default!;
        public IList<DishCategory> DishCategories { get; set; }

		[BindProperty]
		public List<int> selectedResCategories { get; set; }
		[BindProperty]
		public List<int> selectedDishCategories { get; set; }
		[BindProperty]
		public int selectedRating { get; set; }

		public List<int> listRateChecked { get; set; }

		public Dictionary<string, float> listTotalRating = new Dictionary<string, float>();

		public float getTotalRating(Restaurant rest)
		{
			float totalReviewPoint = 0;
			float count=0;
			foreach (var review in rest.Review)
				{
					totalReviewPoint += review.Rating;
					count++;
				}
			totalReviewPoint = totalReviewPoint / count ;
			return totalReviewPoint;
		}
		public async Task<IActionResult> OnGetAsync()
        {
			Restaurants = await _context.Restaurants
				 .Include(r => r.RestaurantAddress)
				 .Include(c => c.RestaurantCategory)
				 .Include(c => c.Review)
				 .OrderBy(r => Guid.NewGuid())
				 .Take(8)
				 .ToListAsync();
			foreach (var item in Restaurants)
			{
				listTotalRating.Add(item.RestaurantId + "", getTotalRating(item));
			}
			RestaurantCategories = await _context.RestaurantCategories.ToListAsync();
			DishCategories = await _context.DishCategories.ToListAsync();
			ViewData["RestaurantCategories"] = RestaurantCategories;
			return Page();
		}
      
		public async Task<IActionResult> OnPost()
        {

			var res = await _context.Restaurants
				 .Include(r => r.RestaurantAddress)
				 .Include(c => c.RestaurantCategory)
				 .Include(c => c.Review)
				 .ToListAsync();
			foreach (var item in res)
			{
				listTotalRating.Add(item.RestaurantId + "", getTotalRating(item));
			}
			if (selectedResCategories.Count!=0)
            {
				res  = _context.Restaurants.
				 Include(c => c.Review)
			   .Where(r => selectedResCategories.Contains((int)r.RestaurantCategoryId))
			   .ToList();
				
				
                Restaurants = res;
			}
			if (selectedRating!=null || selectedRating!=0 )
			{
				foreach (var item in res.ToList())
				{
					int ie = (int)getTotalRating(item);
					if (ie>selectedRating)
					{
						res.Remove(item);
					}
				}
			}
			// Đưa dữ liệu vào ViewData để sử dụng trong view
			Restaurants = res;
			/*listRateChecked = selectedRating;*/
            RestaurantCategories = await _context.RestaurantCategories.ToListAsync();
			ViewData["RestaurantCategories"] = RestaurantCategories;
			return Page();
		}
	}
	
}
