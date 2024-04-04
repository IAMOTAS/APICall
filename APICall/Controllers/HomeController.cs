using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace APICall.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl;

        public HomeController()
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
            try
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
                    using var responseStream = await response.Content.ReadAsStreamAsync();
                    using var jsonDocument = await JsonDocument.ParseAsync(responseStream);

                    // Extract the translated text
                    var responseObject = jsonDocument.RootElement;
                    string translatedText = responseObject.GetProperty("contents").GetProperty("translated").GetString();

                    ViewBag.TranslatedText = translatedText;
                }
                else
                {
                    // Handle unsuccessful response
                    ViewBag.ErrorMessage = "Error: " + response.StatusCode.ToString();
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Error: " + ex.Message;
            }

            return View("Index");
        }
    }
}
