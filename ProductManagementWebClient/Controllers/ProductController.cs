using Microsoft.AspNetCore.Mvc;
using BusinessObject;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Text.Json;

namespace ProductManagementWebClient
{
    public class ProductController : Controller
    {
        private readonly HttpClient client;
        private readonly string productApiUrl = "";
        public ProductController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            this.productApiUrl = "http://localhost:5143/api/ProductManagementAPI";
        }
        public async Task<IActionResult> Index()
        {
            HttpResponseMessage respone = await client.GetAsync(productApiUrl);
            string strData = await respone.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive= true
            };
            List<Product> listProducts = JsonSerializer.Deserialize<List<Product>>(strData, options);
            return View(listProducts);
        }
    }
}