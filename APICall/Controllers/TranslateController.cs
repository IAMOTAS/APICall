using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace APICall.Controllers
{
    public class TranslateController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl;

        public TranslateController()
        {
            _httpClient = new HttpClient();
            _apiUrl = "https://api.funtranslations.com/translate/klingon.json";
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> TranslateToKlingon(string textToTranslate)
        {
            // Constructing the request content
            var requestData = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("text", textToTranslate)
            });

            // Sending the request and getting the response
            HttpResponseMessage response = await _httpClient.PostAsync(_apiUrl, requestData);

            // Checking if the response is successful
            if (response.IsSuccessStatusCode)
            {
                // Reading the response content
                string responseContent = await response.Content.ReadAsStringAsync();
                ViewBag.TranslatedText = responseContent;
            }
            else
            {
                // Handle unsuccessful response
                ViewBag.ErrorMessage = "Error: " + response.StatusCode.ToString();
            }

            return View("Index");
        }
    }
}
