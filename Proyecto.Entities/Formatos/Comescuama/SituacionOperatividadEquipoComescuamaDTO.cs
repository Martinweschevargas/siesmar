using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comescuama
{
    public partial class SituacionOperatividadEquipoComescuamaDTO
    {

        public int? SituacionOperatividadEquipoId { get; set; }
        public int? DescripcionMaterialId { get; set; }
        public int? Cantidad { get; set; }
        public int? UnidadNavalId { get; set; }
        public string? Ubicacion { get; set; }
        public int? DistritoUbigeoId { get; set; }
        public int? CondicionId { get; set; }
        public string? Observacion { get; set; }



        public string? DescripcionMaterial { get; set; }
        public string? DescUnidadNaval { get; set; }
        public string? DescProvincia { get; set; }
        public string? DescDepartamenteo { get; set; }
        public string? DescDistrito { get; set; }
        public string? DescCondicion { get; set; }




        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }


    }
}
