using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GSProjetoSocial.Controllers
{
    public class AddressMvcController : Controller
    {
        private readonly IHttpClientFactory _httpFactory;
        private readonly ILogger<AddressMvcController> _log;

        public AddressMvcController(IHttpClientFactory httpFactory, ILogger<AddressMvcController> log)
        {
            _httpFactory = httpFactory;
            _log = log;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(string cep)
        {
            if (string.IsNullOrWhiteSpace(cep) || cep.Length != 8)
            {
                ModelState.AddModelError(nameof(cep), "CEP inválido");
                return View();
            }

            var client = _httpFactory.CreateClient();
            var url = $"https://viacep.com.br/ws/{cep}/json/";
            var resp = await client.GetAsync(url);
            if (!resp.IsSuccessStatusCode)
            {
                _log.LogWarning("Consulta CEP falhou: {Status}", resp.StatusCode);
                ModelState.AddModelError(string.Empty, "Falha ao consultar CEP");
                return View();
            }

            var viaCep = await resp.Content.ReadFromJsonAsync<ViaCep>();
            if (viaCep == null || viaCep.Erro == true)
            {
                ModelState.AddModelError(string.Empty, "CEP não encontrado");
                return View();
            }

            ViewData["Rua"] = viaCep.Rua;
            ViewData["Bairro"] = viaCep.Bairro;
            ViewData["Cidade"] = viaCep.Cidade;
            ViewData["Estado"] = viaCep.Estado;
            ViewData["Cep"] = cep;
            return View();
        }
    }

    public class ViaCep
    {
        [JsonPropertyName("logradouro")]
        public string Rua { get; set; }
        [JsonPropertyName("bairro")]
        public string Bairro { get; set; }
        [JsonPropertyName("localidade")]
        public string Cidade { get; set; }
        [JsonPropertyName("uf")]
        public string Estado { get; set; }
        [JsonPropertyName("erro")]
        public bool? Erro { get; set; }
    }
}
