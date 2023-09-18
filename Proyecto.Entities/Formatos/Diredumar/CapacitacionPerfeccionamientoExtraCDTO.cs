using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Diredumar
{
    public partial class CapacitacionPerfeccionamientoExtraCDTO
    {

        public int CapacitacionPerfeccionamientoExtraCId { get; set; }
        public string? CIPCapaPerfPCivil { get; set; }
        public string? TipoDocumento { get; set; }
        public string? DNICapaPerfPCivil { get; set; }
        public string? CodigoGrupoOcupacionalCivil { get; set; }
        public string? CodigoNivelEstudio { get; set; }
        public string? CodigoInstitucionEducativaSuperior { get; set; }
        public string? MencionCapacitacion { get; set; }
        public string? FinanciamientoCapacitacion { get; set; }
        public string? CodigoCondicionLaboralCivil { get; set; }
        public string? NumericoPais { get; set; }

        public string? DescGrupoOcupacionalCivil { get; set; }
        public string? DescNivelEstudio { get; set ; }
        public string? DescInstitucionEducativaSuperior { get; set; }
        public string? DescCondicionLaboralCivil { get; set; }
        public string? NombrePais { get; set; }

        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}