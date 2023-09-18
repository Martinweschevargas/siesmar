using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comzocuatro
{
    public partial class SituacionOperatividadEquipoComzocuatroDTO
    {

        public int? SituacionOperatividadEquipoId { get; set; }
        public string? CodigoDescripcionMaterial { get; set; }
        public int? Cantidad { get; set; }
        public string? CodigoUnidadNaval { get; set; }
        public string? Ubicacion { get; set; }
        public string? DistritoUbigeo { get; set; }
        public string? CodigoCondicion { get; set; }
        public string? Observacion { get; set; }



        public string? DescripcionMaterial { get; set; }
        public string? DescUnidadNaval { get; set; }
        public string? DescDistrito { get; set; }
        public string? DescCondicion { get; set; }


        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }


    }
}
