using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dintemar
{
    public partial class InteligenciaContraintelAmenazaDTO : DintemarBaseDto
    {
        public int InteligenciaContrainteligenciaAmenazaId { get; set; }
        public string? CodigoAmenazaSeguridadNacional { get; set; }
        public int? NotasInteligentes { get; set; }
        public int? EstudiosInteligencia { get; set; }
        public int? ApreciacionesInteligencia { get; set; }
        public int? NotasInformacion { get; set; }
        public int? NotasContrainteligencia { get; set; }
        public int? EstudiosContrainteligencia { get; set; }
        public int? ApreciacionesContrainteligencia { get; set; }
        public int? NotasInformacionContrainteligencia { get; set; }


        public string? DescAmenazaSeguridadNacional { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
