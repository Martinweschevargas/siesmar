using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comflotflu
{
    public partial class SituacionOperativaNaveComflotfluDTO
    {

        public int? SituacionOperativaNaveId { get; set; }
        public int? TipoNaveId { get; set; }
        public int? CascoUnidadNaval { get; set; }
        public string? TipoPlataforma { get; set; }
        public int? DependenciaId { get; set; }
        public string? Ubicacion { get; set; }
        public int? DepartamentoUbigeoId { get; set; }
        public int? ProvinciaUbigeoId { get; set; }
        public int? DistritoUbigeoId { get; set; }
        public int? CapacidadOperativaId { get; set; }
        public string? Condicion { get; set; }
        public string? Observaciones { get; set; } 


        public string? DescTipoNave { get; set; }
        public string? DescCascoUnidadNaval { get; set; }
        public string? NombreDependencia { get; set; }
        public string? DescDepartamento { get; set; }
        public string? DescProvincia { get; set; }
        public string? DescDistrito { get; set; }
        public string? DescCapacidadOperativaId { get; set; } 
 
        
        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
