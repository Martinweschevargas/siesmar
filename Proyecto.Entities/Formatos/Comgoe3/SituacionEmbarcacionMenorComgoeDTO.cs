using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comgoe3
{
    public partial class SituacionEmbarcacionMenorComgoeDTO
    {
        public int? SituacionEmbarcacionMenorId { get; set; }
        public int? UnidadNavalId { get; set; }
        public int? TipoNaveId { get; set; }
        public string? TipoPlataforma { get; set; }
        public int? UnidadNavalDestino { get; set; }
        public string? Ubicacion { get; set; }
        public int? DepartamentoUbigeoId { get; set; }
        public int? ProvinciaUbigeoId { get; set; }
        public int? DistritoUbigeoId { get; set; }
        public int? CondicionId { get; set; }
        public int? CapacidadOperativaRequeridaId { get; set; }
        public string? Observaciones { get; set; } 
 
        public string? DescUnidadNaval { get; set; }
        public string? DescTipoNave { get; set; }
        public string? DescUnidadNavalDestino { get; set; }
        public string? DescDepartamento { get; set; }
        public string? DescProvincia { get; set; }
        public string? DescDistrito { get; set; }
        public string? DescCondicion { get; set; }
        public string? DescCapacidadOperativaRequerida { get; set; } 
 
        
        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
