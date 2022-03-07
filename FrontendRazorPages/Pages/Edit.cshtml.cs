using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using SharedDO;

namespace FrontendRazorPages.Pages
{
    public class EditModel : PageModel
    {

        private readonly IMemoryCache _cache;

        public EditModel(IMemoryCache cache)
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