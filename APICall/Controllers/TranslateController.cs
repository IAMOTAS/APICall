using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
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
            return View("Index");
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

                // Deserialize the JSON response
                var responseObject = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, string>>>(responseContent);

                // Extract the translated text
                string translatedText = responseObject["contents"]["translated"];

                ViewBag.TranslatedText = translatedText;
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
