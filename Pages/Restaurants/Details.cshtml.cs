using System;
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
    public class DetailsModel : PageModel
    {

        private readonly Project_Cecilious.Data.CeciliousContext _context;

        public DetailsModel(Project_Cecilious.Data.CeciliousContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Review Review { get; set; } = default!;

        public Restaurant Restaurant { get; set; } = default!;
        public IList<DishCategory> Cates { get; set; } = default!;
        public IList<Dish> Dishes { get; set; } = default!;

        public User currentUser { get; set; }

        public IList<Restaurant> listRes;

        public IList<Review> listReview;

        public double totalReviewPoint;
        public void GetCurrentUser(int id)
        {
            currentUser = _context.Users.Where(u => u.UserId == id).Include(c => Review).SingleOrDefault();
        }
        public void GetListReviews()
        {
            listReview = _context.Reviews.Where(d => d.RestaurantId == Restaurant.RestaurantId).ToList();

        }
        public void GetListRestaurant()
        {
            listRes = _context.Restaurants.OrderBy(r => Guid.NewGuid()).ToList();
            if (listRes.Count > 5)
            {
                listRes.Take(4);
            }
            foreach (var item in listRes)
            {
                item.RestaurantAddress = _context.RestaurantAddresses.FirstOrDefault(a => a.RestaurantAddressId == item.RestaurantAddressId);
            }
        }
        public async void GetListDishes(int resID)
        {
            Cates = _context.DishCategories.ToList();
            Dishes = _context.Dishes.Where(d => d.RestaurantId == resID).ToList();
        }
        public async void GetCurrentRestaurant(int? id)
        {
            var currentRestaurent = await _context.Restaurants.FirstOrDefaultAsync(m => m.RestaurantId == id);
            currentRestaurent.RestaurantAddress = await _context.RestaurantAddresses.FirstOrDefaultAsync(a => a.RestaurantAddressId == currentRestaurent.RestaurantAddressId);
            currentRestaurent.RestaurantCategory = await _context.RestaurantCategories.FirstOrDefaultAsync(a => a.RestaurantCategoryId == currentRestaurent.RestaurantCategoryId);
            currentRestaurent.RestaurantImages = await _context.RestaurantImages.Where(a => a.RestaurantId != currentRestaurent.RestaurantId).ToListAsync();
            Restaurant = currentRestaurent;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                var currentRestaurent = await _context.Restaurants.FirstOrDefaultAsync(m => m.RestaurantId == id);
                currentRestaurent.RestaurantAddress = await _context.RestaurantAddresses.FirstOrDefaultAsync(a => a.RestaurantAddressId == currentRestaurent.RestaurantAddressId);
                currentRestaurent.RestaurantCategory = await _context.RestaurantCategories.FirstOrDefaultAsync(a => a.RestaurantCategoryId == currentRestaurent.RestaurantCategoryId);
                currentRestaurent.RestaurantImages = await _context.RestaurantImages.Where(a => a.RestaurantId != currentRestaurent.RestaurantId).ToListAsync();

                Restaurant = currentRestaurent;
                if (Restaurant == null)
                {
                    return NotFound();
                }
                else
                {
                    //GetCurrentUser(1);
                    GetListRestaurant();
                    GetListDishes(Restaurant.RestaurantId);
                    GetListReviews();
                    foreach (var item in listReview)
                    {
                        item.User = _context.Users.FirstOrDefault(fr => fr.UserId == item.UserId);
                        totalReviewPoint += item.Rating;
                    }
                    totalReviewPoint /= listReview.Count;
                    totalReviewPoint = Math.Round(totalReviewPoint, 1);
                }

                return Page();
            }

        }

        public async Task<IActionResult> OnPostAsync(int id)
        {    
            var currentUser = _context.Users.Where(u => u.UserId == 2).FirstOrDefault();

            var checkReview = _context.Reviews.Where(v => v.UserId == currentUser.UserId && v.RestaurantId == id).FirstOrDefault();

            if (checkReview != null)
            {
                checkReview.Image = Review.Image;
                checkReview.Description = Review.Description;

                _context.Reviews.Update(checkReview);
            } else
            {
                Review.RestaurantId = id;
                Review.UserId = currentUser.UserId;

                _context.Reviews.Add(Review);
            }
            
            await _context.SaveChangesAsync();

            return RedirectToPage(new { id });
        }

    }
}

