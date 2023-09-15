using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Jesehin
{
    public partial class SituacionOperatividadNaveJesehinDTO
    {

        public int? SituacionOperatividadNaveJesehinId { get; set; }
        public int? TipoNaveId { get; set; }
        public int? CascoNaval { get; set; }
        public int? TipoPlataformaNaveId { get; set; }
        public int? DependenciaId { get; set; }
        public string? Ubicacion { get; set; }
        public int? DepartamentoUbigeoId { get; set; }
        public int? ProvinciaUbigeoId { get; set; }
        public int? DistritoUbigeoId { get; set; }
        public int? CapacidadOperativaRequeridaId { get; set; }
        public int? CondicionId { get; set; }
        public string? Observacion { get; set; }


        public string? DescTipoNave { get; set; }
        public string? DescTipoPlataformaNave { get; set; }
        public string? DescDependencia { get; set; }
        public string? DescDepartamento { get; set; }
        public string? DescProvincia { get; set; }
        public string? DescDistrito { get; set; }
        public string? DescCapacidadOperativaRequerida { get; set; }
        public string? DescCondicion { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}