using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comzocuatro
{
    public partial class SituacionOperatividadNaveComzocuatroDTO
    {

        public int? SituacionOperativaNaveComzocuatroId { get; set; }
        public string? CodigoTipoNave { get; set; }
        public int? CascoNave { get; set; }
        public string? CodigoTipoPlataformaNave { get; set; }
        public string? CodigoDependencia { get; set; }
        public string? Ubicacion { get; set; }
        public string? DistritoUbigeo { get; set; }
        public string? CodigoCapacidadOperativaRequerida { get; set; }
        public string? CodigoCondicion { get; set; }
        public string? Observacion { get; set; }


        public string? DescTipoNave { get; set; }
        public string? DescTipoPlataformaNave { get; set; }
        public string? DescDependencia { get; set; }
        public string? DescDepartamento { get; set; }
        public string? DescProvincia { get; set; }
        public string? DescDistrito { get; set; }

        public string? DescCapacidadOperativaRequerida { get; set; }
        public string? DescCondicion { get; set; }

        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
        public int Año { get; set; }
        public int Mes { get; set; }
        public int Dia { get; set; }
    }
}