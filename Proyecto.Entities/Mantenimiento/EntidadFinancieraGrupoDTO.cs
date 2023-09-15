using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class EntidadFinancieraGrupoDTO
    {
        public int EntidadFinancieraGrupoId { get; set; }
        public string? DescEntidadFinancieraGrupo { get; set; }
        public string? CodigoEntidadFinancieraGrupo { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
