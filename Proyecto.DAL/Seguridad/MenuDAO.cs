using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Seguridad;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Seguridad
{
    public class MenuDAO
    {
        SqlCommand cmd = new SqlCommand();

        public List<MenuPrincipalDTO> ObtenerMenuSeguridad(int UsuarioId)
        {
            List<MenuPrincipalDTO> lista = new List<MenuPrincipalDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Seguridad.usp_MenuSeguridadListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@UsuarioId", SqlDbType.Int);
                cmd.Parameters["@UsuarioId"].Value = UsuarioId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new MenuPrincipalDTO()
                        {
                            DependenciaID = Convert.ToInt32(dr["FormatoReporteId"]),
                            NombreFormatoReporte = dr["NombreFormatoReporte"].ToString(),
                            Menu = dr["ControladorFormatoReporte"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public List<MenuPrincipalDTO> ObtenerDependencias(int UsuarioId)
        {
            List<MenuPrincipalDTO> lista = new List<MenuPrincipalDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Seguridad.usp_UsuarioDependenciaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@IdUsuario", SqlDbType.Int);
                cmd.Parameters["@IdUsuario"].Value = UsuarioId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new MenuPrincipalDTO()
                        {
                            Dependencia = dr["NombreDependencia"].ToString(),
                            //Nivel = dr["DescNivelDependencia"].ToString(),
                            DependenciaID = Convert.ToInt32(dr["DependenciaID"])
                        });
                    }
                }
            }
            return lista;
        }

        public List<MenuPrincipalDTO> ObtenerDependenciasSubordinadas1(string DependenciaDesc, int UsuarioId)
        {
            List<MenuPrincipalDTO> lista = new List<MenuPrincipalDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Seguridad.usp_UsuarioDependenciaSubordinadas1Listar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@DependenciaDesc", SqlDbType.VarChar, 50);
                cmd.Parameters["@DependenciaDesc"].Value = DependenciaDesc;

                cmd.Parameters.Add("@UsuarioId", SqlDbType.Int);
                cmd.Parameters["@UsuarioId"].Value = UsuarioId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new MenuPrincipalDTO()
                        {
                            Dependencia = dr["Nombre"].ToString(),
                            DependenciaID = Convert.ToInt32(dr["DependenciaId"]),
                            //DependenciaSubordinadoID =Convert.ToInt32(dr["DependenciaSubordinadoId"]),
                            NombreFormatoReporte = dr["NombreFormatoReporte"].ToString(),
                            Menu = dr["ControladorFormatoReporte"].ToString(),
                            NombrePeriodo = dr["NombrePeriodo"].ToString(),
                            TipoFormato = dr["Tipo"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public List<MenuPrincipalDTO> ObtenerDependenciasSubordinadas2(string DependenciaDesc, int UsuarioId)
        {
            List<MenuPrincipalDTO> lista = new List<MenuPrincipalDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Seguridad.usp_UsuarioDependenciaSubordinadas2Listar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@DependenciaDesc", SqlDbType.VarChar, 50);
                cmd.Parameters["@DependenciaDesc"].Value = DependenciaDesc;

                cmd.Parameters.Add("@UsuarioId", SqlDbType.Int);
                cmd.Parameters["@UsuarioId"].Value = UsuarioId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new MenuPrincipalDTO()
                        {
                            Dependencia = dr["Nombre"].ToString(),
                            DependenciaID = Convert.ToInt32(dr["DependenciaId"]),
                            DependenciaSubordinadoID = Convert.ToInt32(dr["DependenciaSubordinadoId"]),
                            NombreFormatoReporte = dr["NombreFormatoReporte"].ToString(),
                            Menu = dr["ControladorFormatoReporte"].ToString(),
                            NombrePeriodo = dr["NombrePeriodo"].ToString(),
                            TipoFormato = dr["Tipo"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public int ValidarPermiso(int IdUsuario, int IdFormato, int IdPermiso)
        {
            int respuesta=0;

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Seguridad.usp_UsuarioValidarPermiso", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@IdUsuario", SqlDbType.Int);
                cmd.Parameters["@IdUsuario"].Value = IdUsuario;

                cmd.Parameters.Add("@IdFormato", SqlDbType.Int);
                cmd.Parameters["@IdFormato"].Value = IdFormato;

                cmd.Parameters.Add("@IdPermiso", SqlDbType.Int);
                cmd.Parameters["@IdPermiso"].Value = IdPermiso;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    dr.Read();
                    if (dr.HasRows)
                    {
                        respuesta = Convert.ToInt32(dr["Estado"]);
                    }
                }
            }
            return respuesta;
        }

    }
}
