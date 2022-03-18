using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using SharedDO;

namespace FrontendRazorPages.Pages
{
    public class DetailsModel : PageModel
    {

        public IHttpClientFactory _httpClientFactory { get; set; }
        private readonly IMemoryCache _cache;
        public VehicleDO? Vehicle { get; set; }

        public DetailsModel(IHttpClientFactory httpClientFactory, IMemoryCache cache)
        {
            _httpClientFactory = httpClientFactory;
            _cache = cache;
        }
        public async Task<IActionResult> OnGet(string VIN)
        {
            if (_cache.TryGetValue("Vehicle DO " + VIN, out VehicleDO vehicle))
            {
                Vehicle = vehicle;
                return Page();
            }
            if (_cache.TryGetValue("List Vehicle DO", out List<VehicleDO> vehicles))
            {
                Vehicle = vehicles.Find(v => v.VIN == VIN);
                if (Vehicle != null)
                {
                    return Page();
                }
            }

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "http://localhost:5187/api/Vehicle/" + VIN);
            var httpClient = _httpClientFactory.CreateClient();
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                if (httpResponseMessage.Content != null)
                {
                    Vehicle = httpResponseMessage.Content.ReadFromJsonAsync<VehicleDO>().Result;

                    var cacheOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(2)).SetAbsoluteExpiration(TimeSpan.FromSeconds(5));
                    _cache.Set("Vehicle DO " + VIN, Vehicle, cacheOptions);
                }
            }
            else
            {
                return NotFound();
            }

            return Page();
        }
    }
}