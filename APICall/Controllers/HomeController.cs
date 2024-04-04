using System;
using System.Collections.Generic;
using System.Net.Http;
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
                    string responseContent = await response.Content.ReadAsStringAsync();

                    // Extracting the translated text from the response content
                    // Here you may need to deserialize the JSON response and extract the translated text property
                    // For simplicity, let's assume the translated text is directly available in the response content
                    ViewBag.TranslatedText = responseContent;
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
