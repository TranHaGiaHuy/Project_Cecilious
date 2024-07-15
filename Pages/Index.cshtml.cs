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
		public IList<Restaurant> Restaurants { get; set; } = default!;
		public async Task OnGetAsync()
        {
			Restaurants = await _context.Restaurants
				.Include(r => r.RestaurantAddress)
				.Include(c => c.RestaurantCategory)
				.Include(c=>c.Review).
				ToListAsync();
		}
		
	}
}
