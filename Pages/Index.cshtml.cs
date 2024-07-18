using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Project_Cecilious.Data;
using Project_Cecilious.Model;
namespace Project_Cecilious.Pages
{
	public class IndexModel : PageModel
	{
		private readonly ILogger<IndexModel> _logger;
		private readonly CeciliousContext _context;

		public IndexModel(ILogger<IndexModel> logger, CeciliousContext context)
		{
			_logger = logger;
			_context = context;
		}
		float totalReviewPoint = 0;
		string cateImage = "";
		public IList<Restaurant> Restaurants { get; set; } = default!;
		public IList<DishCategory> DishCategories { get; set; } = default!;

		public Dictionary<string, float> listTotalRating = new Dictionary<string, float>();
        public Dictionary<string, string> listCateWithImage = new Dictionary<string, string>();

        public async Task OnGetAsync()
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
                foreach (var review in item.Review)
                {
					totalReviewPoint += review.Rating;
				}
				totalReviewPoint =totalReviewPoint/ (float)item.Review.Count;
				listTotalRating.Add(item.RestaurantId+"",totalReviewPoint);
				totalReviewPoint = 0;
            }
			DishCategories = await _context.DishCategories
				.OrderBy(r => Guid.NewGuid())
                .Include(c => c.Dishes)
                .Take(6)
				.ToListAsync();
            foreach (var item in DishCategories)
            {
                var sampleDish = _context.Dishes.FirstOrDefault(f=>f.DishCategoryId==item.DishCategoryId);
                if (sampleDish!=null)
                {
                    if (sampleDish.Image!=null) cateImage = sampleDish.Image;
					else cateImage = "/images/homepage/recipes/recipe_02.jpg";
					cateImage = "/images/homepage/recipes/recipe_02.jpg";
                }
                listCateWithImage.Add(item.DishCategoryId+"", cateImage);
            }
        }

	}
}