using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class ServicioLavanderiaDTO
    {
        public int ServicioLavanderiaId { get; set; }
        public string? DescServicioLavanderia { get; set; }
        public string? CodigoServicioLavanderia { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
