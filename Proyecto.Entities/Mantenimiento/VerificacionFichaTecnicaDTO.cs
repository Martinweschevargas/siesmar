using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class VerificacionFichaTecnicaDTO
    {
        public int VerificacionFichaTecnicaId { get; set; }
        public string? DescVerificacionFichaTecnica { get; set; }
        public string? CodigoVerificacionFichaTecnica { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
