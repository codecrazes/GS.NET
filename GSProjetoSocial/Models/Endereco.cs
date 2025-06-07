using System.Text.Json.Serialization;

namespace GSProjetoSocial.Models
{
    public class Endereco
    {
        public int Id { get; set; }

        [JsonPropertyName("street")]
        public string Rua { get; set; }

        [JsonPropertyName("number")]
        public string Numero { get; set; }

        [JsonPropertyName("neighborhood")]
        public string Bairro { get; set; }

        [JsonPropertyName("city")]
        public string Cidade { get; set; }

        [JsonPropertyName("state")]
        public string Estado { get; set; }

        [JsonPropertyName("zipCode")]
        public string Cep { get; set; }

        [JsonPropertyName("referencePoint")]
        public string PontoReferencia { get; set; }
    }
}
