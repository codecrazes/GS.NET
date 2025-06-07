using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GSProjetoSocial.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly HttpClient _http;

        public AddressController(IHttpClientFactory httpFactory)
        {
            _http = httpFactory.CreateClient();
        }

        public class ViaCepResult
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

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string cep)
        {
            if (string.IsNullOrWhiteSpace(cep) || cep.Length != 8)
                return BadRequest("CEP inválido");

            var url = $"https://viacep.com.br/ws/{cep}/json/";
            var resp = await _http.GetAsync(url);
            if (!resp.IsSuccessStatusCode)
                return StatusCode((int)resp.StatusCode, "Falha ao consultar CEP");

            var viaCep = await resp.Content.ReadFromJsonAsync<ViaCepResult>();
            if (viaCep == null || viaCep.Erro == true)
                return NotFound("CEP não encontrado");

            return Ok(new
            {
                rua = viaCep.Rua,
                bairro = viaCep.Bairro,
                cidade = viaCep.Cidade,
                estado = viaCep.Estado
            });
        }
    }
}
