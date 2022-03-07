using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using SharedDO;

namespace FrontendRazorPages.Pages
{
    public class CreateModel : PageModel
    {

        private readonly IMemoryCache _cache;

        public CreateModel(IMemoryCache cache)
        {
            _cache = cache;
        }
        public async Task<IActionResult> OnGet()
        {

            _cache.Remove("List Vehicle DO");
            return Page();
        }
    }
}