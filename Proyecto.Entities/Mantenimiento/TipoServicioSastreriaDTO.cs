using System.ComponentModel.DataAnnotations.Schema;


namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TipoServicioSastreriaDTO
    {
        public int TipoServicioSastreriaId { get; set; }
        public string? DescServicioSastreria { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
