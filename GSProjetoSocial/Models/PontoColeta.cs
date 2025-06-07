using System.Text.Json.Serialization;

namespace GSProjetoSocial.Models
{
    public class PontoColeta
    {
        public int Id { get; set; }

        [JsonPropertyName("pointName")]
        public string NomePonto { get; set; }

        [JsonPropertyName("acceptedItems")]
        public string ItensAceitos { get; set; }

        [JsonPropertyName("address")]
        public Endereco Endereco { get; set; }

        [JsonPropertyName("contactName")]
        public string Responsavel { get; set; }

        [JsonPropertyName("operatingHours")]
        public string HorarioRecebimento { get; set; }
    }
}
