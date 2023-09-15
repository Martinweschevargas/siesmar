namespace Marina.Siesmar.Entidades.Seguridad
{
    public class MenuPrincipalDTO
    {
        public string Nivel { get; set; }
        public int NivelDependenciaId { get; set; }
        public string Dependencia { get; set; }
        public int DependenciaID { get; set; }
        public int DependenciaSubordinadoID { get; set; }
        public string NombrePeriodo { get; set; }
        public string Menu { get; set; }
        public string NombreFormatoReporte { get; set; }
        public string DependenciaSuperior { get; set; }
        public string NivelSuperior { get; set; }
        public string TipoFormato { get; set; }
    }
}
