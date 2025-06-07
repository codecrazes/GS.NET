using System.Text.Json.Serialization;

namespace GSProjetoSocial.Models
{
    public class Voluntario
    {
        public int Id { get; set; }

        [JsonPropertyName("fullName")]
        public string NomeCompleto { get; set; }

        [JsonPropertyName("phone")]
        public string Telefone { get; set; }

        [JsonPropertyName("helpType")]
        public string TipoAjuda { get; set; }

        [JsonPropertyName("availability")]
        public string Disponibilidade { get; set; }

        [JsonPropertyName("city")]
        public string Cidade { get; set; }
    }
}
