
using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class DistritoJudicialDTO
    {
        public int DistritoJudicialId { get; set; }
        public string? DescDistritoJudicial { get; set; }
        public string? CodigoDistritoJudicial { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}