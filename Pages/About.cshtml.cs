using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace Project_Cecilious.Pages
{
  
    public class About : PageModel
    {
        public string? RequestId { get; set; }


        private readonly ILogger<About> _logger;

        public About(ILogger<About> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }

}
