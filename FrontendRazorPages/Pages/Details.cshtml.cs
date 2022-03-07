using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using SharedDO;

namespace FrontendRazorPages.Pages
{
    public class DetailsModel : PageModel
    {

        private readonly IMemoryCache _cache;

        public DetailsModel(IMemoryCache cache)
        {
            _cache = cache;
        }
        public async Task<IActionResult> OnGet(string VIN)
        {

            _cache.Remove("List Vehicle DO");
            return Page();
        }
    }
}