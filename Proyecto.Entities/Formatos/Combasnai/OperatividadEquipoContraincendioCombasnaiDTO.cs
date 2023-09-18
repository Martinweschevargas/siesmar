using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Combasnai
{
    public partial class OperatividadEquipoContraincendioCombasnaiDTO
    {

        public int? OperatividadEquipoContraincendioId { get; set; }
        public int? DescripcionMaterialId { get; set; }
        public int? CantidadMaterial { get; set; }
        public string? Ubicacion { get; set; }
        public int? DepartamentoUbigeoId { get; set; }
        public int? ProvinciaUbigeoId { get; set; }
        public int? DistritoUbigeoId { get; set; }
        public int? CondicionId { get; set; }
        public string? Observacion { get; set; }



        public string? DescDescripcionMaterial { get; set; }
        public string? DescDepartamento { get; set; }
        public string? DescProvincia { get; set; }  
        public string? DescDistrito { get; set; }
        public string? DescCondicion { get; set; }




        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }


    }
}
