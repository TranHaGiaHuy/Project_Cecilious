using Project_Cecilious.Model;
namespace Project_Cecilious.Data
{
    public class DbInitializer
    {
        public static void Initialize(CeciliousContext context)
        {

            if (!context.RestaurantCategories.Any())
            {
              
            var restaurantCategories = new RestaurantCategory[]
                {
                     new RestaurantCategory { RestaurantCategoryId = 1, Name = "Category 1" },
                     new RestaurantCategory { RestaurantCategoryId = 2, Name = "Category 2" },
                     new RestaurantCategory { RestaurantCategoryId = 3, Name = "Category 3" },
                     new RestaurantCategory { RestaurantCategoryId = 4, Name = "Category 4" },
                     new RestaurantCategory { RestaurantCategoryId = 5, Name = "Category 5" }

                };

            context.RestaurantCategories.AddRange(restaurantCategories);
            }
            context.SaveChanges();
           
            //=====================================================================
            if (!context.RestaurantAddresses.Any())
            {
             
            var restaurantAddresses = new RestaurantAddress[]
                {
                    new RestaurantAddress { RestaurantAddressId = 1, HouseNumber = "43A", Street = "Nguyen Van Cu", District = "An Hoa", Province = "Can Tho", GoogleMapLink = "https://maps.app.goo.gl/DaB7fy8yHryDc77P8" },
                    new RestaurantAddress { RestaurantAddressId = 2, HouseNumber = "22B", Street = "Vo Van Kiet", District = "An Binh", Province = "An Giang", GoogleMapLink = "https://maps.app.goo.gl/etrpPa5GXwg31uem7" },
                    new RestaurantAddress { RestaurantAddressId = 3, HouseNumber = "54B", Street = "Hoang Hoa Tham", District = "An Cu", Province = "Can Tho", GoogleMapLink = "https://maps.app.goo.gl/W78UiYcpagZo1yGQ9" },
                    new RestaurantAddress { RestaurantAddressId = 4, HouseNumber = "890NH", Street = "Dien Bien Phu", District = "An Binh", Province = "Ho Chi Minh", GoogleMapLink = "https://maps.app.goo.gl/scbsaM31xNhDT3od8" },
                    new RestaurantAddress { RestaurantAddressId = 5, HouseNumber = "53U", Street = "Vo Van Linh", District = "An Thoi", Province = "Soc Trang", GoogleMapLink = "https://maps.app.goo.gl/e69hrTDrDkMkqkUa9" }
                };
            context.RestaurantAddresses.AddRange(restaurantAddresses);
            }
            context.SaveChanges();
           

            //=====================================================================
            if (!context.Restaurants.Any())
            {
             
            var restaurants = new Restaurant[]
                {
                     new Restaurant { RestaurantId = 1, RestaurantAddressId = 1, RestaurantName = "Nha Hang Sanh Loc", Phone = "0572857285", Description = "Quan an ngon", StartTime = new TimeOnly(10, 0), EndTime = new TimeOnly(20, 0), RestaurantCategoryId = 2 },
                     new Restaurant { RestaurantId = 2, RestaurantAddressId = 2, RestaurantName = "Ga Ran Five Start", Phone = "0576938761", Description = "crunch", StartTime = new TimeOnly(11, 0), EndTime = new TimeOnly(21, 0), RestaurantCategoryId = 1 },
                     new Restaurant { RestaurantId = 3, RestaurantAddressId = 3, RestaurantName = "Domino Pizza", Phone = "0395684691", Description = "Banh pizza", StartTime = new TimeOnly(9, 0), EndTime = new TimeOnly(22, 0), RestaurantCategoryId = 4 },
                     new Restaurant { RestaurantId = 4, RestaurantAddressId = 4, RestaurantName = "Chu Lun", Phone = "0923487318", Description = "Com me nau", StartTime = new TimeOnly(10, 0), EndTime = new TimeOnly(23, 0), RestaurantCategoryId = 3 },
                     new Restaurant { RestaurantId = 5, RestaurantAddressId = 5, RestaurantName = "Com Nong", Phone = "0924783451", Description = "Com bo nau", StartTime = new TimeOnly(6, 0), EndTime = new TimeOnly(22, 0), RestaurantCategoryId = 1 }
                };

            context.Restaurants.AddRange(restaurants);
            }
            context.SaveChanges();
           
            //=====================================================================
            if (!context.Users.Any())
            {
             
            var users = new User[]
                {
                    new User { UserId = 1, FullName = "Nguyen Van A", Phone = 123456789, CreateDate = new DateTime(2023, 6, 1), Gender = "Male", Avatar = "https://example.com/avatar1.jpg", Address = "123 Nguyen Van Cu, Can Tho" },
                    new User { UserId = 2, FullName = "Tran Thi B", Phone = 987654321, CreateDate = new DateTime(2023, 6, 15), Gender = "Female", Avatar = "https://example.com/avatar2.jpg", Address = "456 Vo Van Kiet, An Giang" },
                    new User { UserId = 3, FullName = "Le Van C", Phone = 112233445, CreateDate = new DateTime(2023, 7, 1), Gender = "Male", Avatar = "https://example.com/avatar3.jpg", Address = "789 Hoang Hoa Tham, Can Tho" },
                    new User { UserId = 4, FullName = "Phan Thi D", Phone = 556677889, CreateDate = new DateTime(2023, 7, 20), Gender = "Female", Avatar = "https://example.com/avatar4.jpg", Address = "101 Dien Bien Phu, Ho Chi Minh" },
                    new User { UserId = 5, FullName = "Hoang Van E", Phone = 667788990, CreateDate = new DateTime(2023, 8, 5), Gender = "Male", Avatar = "https://example.com/avatar5.jpg", Address = "202 Vo Van Linh, Soc Trang" }
                };

            context.Users.AddRange(users);
            }
            context.SaveChanges();
            //=====================================================================
            if (!context.Accounts.Any())
            {

                var accounts = new Account[]
                    {
                    new Account { AccountId = 1, UserId = 1, Username = "admin", Password = "admin123", Role = 1, Status = 1 },
                    new Account { AccountId = 2, UserId = 2, Username = "user", Password = "user123", Role = 2, Status = 1 },
                    new Account { AccountId = 3, UserId = 3, Username = "guest", Password = "guest123", Role = 3, Status = 0 }
                     };

                context.Accounts.AddRange(accounts);
            }
            context.SaveChanges();
            //=====================================================================
            if (!context.Reviews.Any())
            {
                
                    var reviews = new Review[]
         {
                         new Review { UserId = 1, RestaurantId = 1, Title = "Great food!", Description = "The food was amazing. Will visit again.", Image = "https://example.com/image1.jpg", Rating = 4.5f, CreateTime = new DateOnly(2024, 1, 10) },
                         new Review { UserId = 2, RestaurantId = 2, Title = "Good service", Description = "Friendly staff and great service.", Image = "https://example.com/image2.jpg", Rating = 4.0f, CreateTime = new DateOnly(2024, 1, 11) },
                         new Review { UserId = 3, RestaurantId = 3, Title = "Delicious Pizza", Description = "The pizza was really delicious and well made.", Image = "https://example.com/image3.jpg", Rating = 5.0f, CreateTime = new DateOnly(2024, 1, 12) },
                         new Review { UserId = 4, RestaurantId = 4, Title = "Not bad", Description = "Food was okay, but the service needs improvement.", Image = "https://example.com/image4.jpg", Rating = 3.0f, CreateTime = new DateOnly(2024, 1, 13) },
                         new Review { UserId = 5, RestaurantId = 5, Title = "Excellent!", Description = "Everything was perfect, highly recommended.", Image = "https://example.com/image5.jpg", Rating = 5.0f, CreateTime = new DateOnly(2024, 1, 14) }
                     };

                    context.Reviews.AddRange(reviews);
            }

            context.SaveChanges();
            //=====================================================================
            if (!context.DishCategories.Any())
            {

                var dishCategories = new DishCategory[]
     {
                     new DishCategory { DishCategoryId = 1, Name = "Appetizers" },
            new DishCategory { DishCategoryId = 2, Name = "Main Courses" },
            new DishCategory { DishCategoryId = 3, Name = "Desserts" },
            new DishCategory { DishCategoryId = 4, Name = "Beverages" },
            new DishCategory { DishCategoryId = 5, Name = "Salads" } };

                context.DishCategories.AddRange(dishCategories);
            }

            context.SaveChanges();
            //=====================================================================
            if (!context.Dishes.Any())
            {

                var dishes = new Dish[]
                {
                    new Dish { DishId = 1, RestaurantId = 1, DishCategoryId = 1, DishName = "Spring Rolls", Description = "Crispy rolls with vegetables", Price = 5.99, LinkToShoppe = "https://example.com/shoppe/spring-rolls", Image = "https://example.com/images/spring-rolls.jpg" },
                    new Dish { DishId = 2, RestaurantId = 1, DishCategoryId = 2, DishName = "Grilled Chicken", Description = "Juicy grilled chicken with herbs", Price = 12.99, LinkToShoppe = "https://example.com/shoppe/grilled-chicken", Image = "https://example.com/images/grilled-chicken.jpg" },
                    new Dish { DishId = 3, RestaurantId = 2, DishCategoryId = 3, DishName = "Chocolate Cake", Description = "Rich chocolate cake with a creamy filling", Price = 7.49, LinkToShoppe = "https://example.com/shoppe/chocolate-cake", Image = "https://example.com/images/chocolate-cake.jpg" },
                    new Dish { DishId = 4, RestaurantId = 3, DishCategoryId = 4, DishName = "Green Tea", Description = "Refreshing green tea with mint", Price = 2.99, LinkToShoppe = "https://example.com/shoppe/green-tea", Image = "https://example.com/images/green-tea.jpg" },
                    new Dish { DishId = 5, RestaurantId = 3, DishCategoryId = 5, DishName = "Caesar Salad", Description = "Classic Caesar salad with crisp lettuce and Parmesan cheese", Price = 6.49, LinkToShoppe = "https://example.com/shoppe/caesar-salad", Image = "https://example.com/images/caesar-salad.jpg" }

                };

                context.Dishes.AddRange(dishes);
                }

            context.SaveChanges();
            //=====================================================================
           
        }

    }
}
