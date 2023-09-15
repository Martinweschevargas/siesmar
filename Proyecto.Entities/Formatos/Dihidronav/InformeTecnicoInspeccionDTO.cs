using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dihidronav
{
    public partial class InformeTecnicoInspeccionDTO
    {

        public int? InformeTecnicoInspeccionId { get; set; }
        public int? NumeroOrden { get; set; }
        public string? NumeroInformeTecnico { get; set; }
        public string? CodigoTipoObra { get; set; }
        public string? DescripcionInspeccion { get; set; }
        public string? FechaEvaluacion { get; set; }
        public string? EmpresaPersonaSolicitante { get; set; }
        public string? DistritoUbigeo { get; set; }
        public string? DescTipoObra { get; set; }
        public string? DescDepartamento { get; set; }
        public string? DescProvincia { get; set; }
        public string? DescDistrito { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}