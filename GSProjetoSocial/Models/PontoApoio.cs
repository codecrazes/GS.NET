using System.Text.Json.Serialization;

namespace GSProjetoSocial.Models
{
    public class PontoApoio
    {
        public int Id { get; set; }

        [JsonPropertyName("placeName")]
        public string NomeLocal { get; set; }

        [JsonPropertyName("shelterType")]
        public string TipoAbrigo { get; set; }

        [JsonPropertyName("capacity")]
        public int Capacidade { get; set; }

        [JsonPropertyName("address")]
        public Endereco Endereco { get; set; }

        [JsonPropertyName("contactName")]
        public string ResponsavelNome { get; set; }

        [JsonPropertyName("contactPhone")]
        public string ResponsavelTelefone { get; set; }

        [JsonPropertyName("operatingHours")]
        public string HorarioFuncionamento { get; set; }
    }
}
