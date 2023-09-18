using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dirintemar
{
    public partial class VisitaArchivoHistoricoDTO
    {
        public int VisitaArchivoHistoricoId { get; set; }
        public string? FechaVisitaArchivoHistorico { get; set; }
        public string? VisitanteArchivoHistorico { get; set; }
        public string? DocIdentidadVisita { get; set; }
        public int? TipoVisitaGeneralId { get; set; }
        public string? EntidadVisita { get; set; }
        public string? TemaArchivoHistorico { get; set; }
        public string? NacionalidadVisitante { get; set; }
        public string? DescTipoVisitaGeneral { get; set; }
        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
