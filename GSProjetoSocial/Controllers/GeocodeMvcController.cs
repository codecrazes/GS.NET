using System.Net.Http;
using System.Text.Json;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text.Json.Serialization;

namespace GSProjetoSocial.Controllers
{
    public class GeocodeMvcController : Controller
    {
        private readonly IHttpClientFactory _http;
        private readonly ILogger<GeocodeMvcController> _log;

        public GeocodeMvcController(IHttpClientFactory http, ILogger<GeocodeMvcController> log)
        {
            _http = http;
            _log = log;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(string address)
        {
            if (string.IsNullOrWhiteSpace(address))
            {
                ModelState.AddModelError(nameof(address), "O parâmetro 'address' é obrigatório.");
                return View();
            }

            var client = _http.CreateClient();
            client.DefaultRequestHeaders.Add("User-Agent", "RedeSOS/1.0 (contato@suadomain.com)");

            var url = "https://nominatim.openstreetmap.org/search?format=json&limit=1&q=" + HttpUtility.UrlEncode(address);
            var resp = await client.GetAsync(url);
            if (!resp.IsSuccessStatusCode)
            {
                _log.LogWarning("Geocode failed: {Status}", resp.StatusCode);
                ModelState.AddModelError(string.Empty, "Serviço indisponível no momento.");
                return View();
            }

            var content = await resp.Content.ReadAsStringAsync();
            var list = JsonSerializer.Deserialize<List<Nominatim>>(content);
            if (list == null || list.Count == 0)
            {
                ModelState.AddModelError(string.Empty, "Endereço não encontrado.");
                return View();
            }

            ViewData["Lat"] = list[0].Lat;
            ViewData["Lon"] = list[0].Lon;
            ViewData["Address"] = address;
            return View();
        }
    }

    public class Nominatim
    {
        [JsonPropertyName("lat")]
        public string Lat { get; set; }
        [JsonPropertyName("lon")]
        public string Lon { get; set; }
    }
}
