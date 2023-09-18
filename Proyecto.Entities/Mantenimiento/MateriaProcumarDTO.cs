using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class MateriaProcumarDTO
    {
        public int MateriaProcumarId { get; set; }
        public string? DescMateriaProcumar { get; set; }
        public string? CodigoMateriaProcumar { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
