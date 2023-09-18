using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comescla
{
    public partial class BandaMusicoComesclaDTO
    {

        public int? BandaMusicoId { get; set; }
        public int? TipoComisionId { get; set; }
        public int? EventoId { get; set; }
        public string? SolicitudDocumentoReferencia { get; set; }
        public string? InstitucionSolicitante { get; set; }
        public int? GrupoComisionadoId { get; set; }
        public string? VestimentaUniforme { get; set; }
        public string? NombreEvento { get; set; }
        public string? Lugar { get; set; }
        public string? FechaHoraSalida { get; set; }
        public string? FechaHoraInicio { get; set; }
        public string? FechaHoraTermino { get; set; }
        public string? RequerimientoMovilidad { get; set; }
        public string? Observaciones { get; set; }



        public string? DescTipoComision { get; set; }
        public string? DescEvento { get; set; }
        public string? DescGrupoComisionado { get; set; }




        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }


    }
}
