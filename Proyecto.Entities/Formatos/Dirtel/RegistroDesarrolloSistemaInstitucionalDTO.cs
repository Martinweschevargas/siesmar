using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dirtel
{
    public partial class RegistroDesarrolloSistemaInstitucionalDTO
    {

        public int? RegistroDesarrolloSistemaInstitucionalId { get; set; }
        public string? NombreSistema { get; set; }
        public string? SiglaSoftware { get; set; }
        public string? CodigoAreaSatisfaceDirtel { get; set; }
        public string? DescripcionFuncionalidad { get; set; }
        public string? FechaDesarrollo { get; set; }
        public string? CodigoCicloDesarrolloSoftware { get; set; }
        public string? AvanceDesarrollo { get; set; }
        public string? ServicioWeb { get; set; }
        public string? AlcanceSistemaInstitucional { get; set; }
        public string? ModalidadDesarrollo { get; set; }
        public string? CodigoDenominacionBaseDato { get; set; }
        public string? CodigoDenominacionLenguajeProgramacion { get; set; }
        public string? ServidorWeb { get; set; }
        public string? CodigoDependencia { get; set; }
        public string? FechaPuestaProduccion { get; set; }
        public string? ServidorBD { get; set; }


        public string? DescAreaSatisfaceDirtel { get; set; }
        public string? DescCicloDesarrolloSoftware { get; set; }
        public string? DescDenominacionBaseDato { get; set; }
        public string? DescDenominacionLenguajeProgramacion { get; set; }
        public string? DescDependencia { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}