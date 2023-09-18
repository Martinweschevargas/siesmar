using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dincydet
{
    public partial class ArchivoPersonalCTDocenteDTO
    {
        public int ArchivoPersonalCTDocenteId { get; set; }
        public string? DNIPersonalCTDocente { get; set; }
        public string? CodigoInstitucionEjerce { get; set; }
        public string? CodigoAreaCT { get; set; }
        public int? AniosDocenciaPersonalCTDocente { get; set; }
        public int? CargaId { get; set; }
        public string? DescAreasCT { get; set; }
        public string? InstitucionEjercePersonalCTDocente { get; set; }
        public string? DescAreaCT { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
        

    }
}
