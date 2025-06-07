using System;
using System.Text.Json.Serialization;

namespace GSProjetoSocial.Models
{
    public class Relato
    {
        public int Id { get; set; }

        [JsonPropertyName("reportDate")]
        public DateTime DataAjuda { get; set; }

        [JsonPropertyName("reportDescription")]
        public string DescricaoAjuda { get; set; }
    }
}
