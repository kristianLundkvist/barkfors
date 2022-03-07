using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using SharedDO;

namespace FrontendRazorPages.Pages
{
    public class IndexModel : PageModel
    {
        public IHttpClientFactory _httpClientFactory { get; set; }
        public IList<VehicleDO> VehicleDOs { get; set; } = new List<VehicleDO>();
        private readonly IMemoryCache _cache;

        public IndexModel(IHttpClientFactory httpClientFactory, IMemoryCache cache)
        {
            _httpClientFactory = httpClientFactory;
            _cache = cache;
        }


        public async Task<IActionResult> OnGet()
        {
            if (!_cache.TryGetValue("List Vehicle DO", out List<VehicleDO> vehicles))
            {
                var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "http://localhost:5187/api/Vehicle");

                var httpClient = _httpClientFactory.CreateClient();
                var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    if (httpResponseMessage.Content != null)
                    {
                        vehicles = httpResponseMessage.Content.ReadFromJsonAsync<List<VehicleDO>>().Result!;

                        var cacheOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(2)).SetAbsoluteExpiration(TimeSpan.FromSeconds(10));
                        _cache.Set("List Vehicle DO", vehicles, cacheOptions);
                        VehicleDOs = vehicles;
                    }
                }
            }

            VehicleDOs = vehicles;

            return Page();
        }
    }
}
