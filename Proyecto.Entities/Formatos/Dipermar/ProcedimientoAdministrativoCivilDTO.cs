using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dipermar
{
    public partial class ProcedimientoAdministrativoCivilDTO
    {
        public int ProcedimientoAdministrativoCivilId { get; set; }
        public string? NroDocumentoProcedimientoAdm { get; set; }
        public string? FechaDocumento { get; set; }
        public string? CodigoCondicionLaboralCivil { get; set; }
        public string? CodigoGrupoOcupacionalCivil { get; set; }
        public string? CodigoCargo { get; set; }
        public string? CodigoDependencia { get; set; }
        public string? CodigoInfraccionDisciplinariaCivil { get; set; }
        public string? SolicitanteSancion { get; set; }
        public string? CodigoGradoPersonalMilitar { get; set; }
        public string? CodigoCargoSolicitante { get; set; }
        public string? CodigoGradoPersonalMilitarSansion { get; set; }
        public string? CodigoCargoImponeSancion { get; set; }
        public string? CodigoSancionDisciplinariaCivil { get; set; }
        public string? InicioSancion { get; set; }
        public string? TerminoSancion { get; set; }
        public string? DescGrupoOcupacionalCivil { get; set; }
        public string? NombreDependencia { get; set; }
        public string? DescInfraccionDisciplinariaCivil { get; set; }
        public string? DescGrado { get; set; }
        public string? DescCargo { get; set; }
        public string? DescCargoSolicitante { get; set; }
        public string? DescGradoPersonalMilitarSansion { get; set; }
        public string? DescCargoImponeSancion { get; set; }
        public string? DescCondicionLaboralCivil { get; set; }


        public string? DescSancionDisciplinariaCivil { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
