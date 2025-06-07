using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GSProjetoSocial.Models
{
    public class FormularioFamilia
    {
        public int Id { get; set; }

        [JsonPropertyName("fullName")]
        public string NomeCompleto { get; set; }

        [JsonPropertyName("cpf")]
        public string Cpf { get; set; }

        [JsonPropertyName("phone")]
        public string Telefone { get; set; }

        [JsonPropertyName("address")]
        public Endereco Endereco { get; set; }

        [JsonPropertyName("hasDisability")]
        public bool PossuiDeficiencia { get; set; }

        [JsonPropertyName("disabilityType")]
        public string? TipoDeficiencia { get; set; }

        [JsonPropertyName("householdCount")]
        public int QuantidadePessoasCasa { get; set; }

        [JsonPropertyName("childrenCount")]
        public int QuantidadeCriancas { get; set; }

        [JsonPropertyName("hasPets")]
        public bool PossuiAnimais { get; set; }

        [JsonPropertyName("animals")]
        public List<Animal> Animais { get; set; } = new List<Animal>();
    }
}
