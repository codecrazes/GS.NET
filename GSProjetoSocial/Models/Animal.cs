using System.Text.Json.Serialization;

namespace GSProjetoSocial.Models
{
    public class Animal
    {
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Nome { get; set; }

        [JsonPropertyName("type")]
        public string Tipo { get; set; }

        [JsonPropertyName("needsVeterinaryHelp")]
        public bool PrecisaAjudaVeterinaria { get; set; }
    }
}
