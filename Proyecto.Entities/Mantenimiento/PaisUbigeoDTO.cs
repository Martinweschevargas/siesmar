using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class PaisUbigeoDTO
    {
        public int PaisUbigeoId { get; set; }
        public string? CodIsoAlfa2 { get; set; }
        public string? NombrePais { get; set; }
        public string? Numerico { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
