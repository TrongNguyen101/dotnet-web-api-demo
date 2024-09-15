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
    }
}