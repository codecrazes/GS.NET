using System.Net.Http;
using System.Text.Json;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GSProjetoSocial.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GeocodeController : ControllerBase
    {
        private readonly IHttpClientFactory _http;
        private readonly ILogger<GeocodeController> _log;

        public GeocodeController(IHttpClientFactory http, ILogger<GeocodeController> log)
        {
            _http = http;
            _log = log;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string address)
        {
            if (string.IsNullOrWhiteSpace(address))
                return BadRequest("O parâmetro 'address' é obrigatório.");

            var client = _http.CreateClient();
            client.DefaultRequestHeaders.Add("User-Agent", "RedeSOS/1.0 (contato@suadomain.com)");

            var url = "https://nominatim.openstreetmap.org/search?format=json&limit=1&q=" + HttpUtility.UrlEncode(address);
            var resp = await client.GetAsync(url);
            if (!resp.IsSuccessStatusCode)
            {
                _log.LogWarning("Geocode failed: {Status}", resp.StatusCode);
                return StatusCode((int)resp.StatusCode);
            }

            var content = await resp.Content.ReadAsStringAsync();
            var list = JsonSerializer.Deserialize<List<NominatimResult>>(content);
            if (list == null || list.Count == 0)
                return NotFound();

            return Ok(new { lat = list[0].Lat, lon = list[0].Lon });
        }
    }

    public class NominatimResult
    {
        public string Lat { get; set; }
        public string Lon { get; set; }
    }
}
