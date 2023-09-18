using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Seguridad
{
    public class UsuarioDependenciaDAO
    {
        SqlCommand cmd = new SqlCommand();

        public List<UsuarioDependenciaDTO> ObtenerUsuarioDependencia()
        {
            List<UsuarioDependenciaDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Seguridad.usp_UsuarioDependenciaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new UsuarioDependenciaDTO()
                        {
                            UsuarioDependenciaId = Convert.ToInt32(dr["UsuarioDependenciaId"]),
                            NombreUsuario = dr["NombreCompleto"].ToString(),
                            DescDependencia = dr["NombreDependencia"].ToString(),                           
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarUsuarioDependencia(UsuarioDependenciaDTO usuarioDependenciaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();

                    cmd = new SqlCommand("Seguridad.usp_UsuarioDependenciaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UsuarioId", SqlDbType.Int);
                    cmd.Parameters["@UsuarioId"].Value = usuarioDependenciaDTO.UsuarioId;

                    cmd.Parameters.Add("@DependenciaId", SqlDbType.Int);
                    cmd.Parameters["@DependenciaId"].Value = usuarioDependenciaDTO.Dependencia;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        dr.Read();
                        if (dr.HasRows)
                        {
                            IND_OPERACION = dr["IND_OPERACION"].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    IND_OPERACION = ex.Message;
                }
            }
            return IND_OPERACION;
        }

        public UsuarioDependenciaDTO BuscarUsuarioDependenciaID(int UsuarioDependenciaId)
        {
            UsuarioDependenciaDTO usuarioDependenciaDTO = new();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Seguridad.usp_UsuarioDependenciaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter pIDUsuarioDependencia = new SqlParameter();
                    pIDUsuarioDependencia.ParameterName = "@UsuarioDependenciaId";
                    pIDUsuarioDependencia.SqlDbType = SqlDbType.Int;
                    pIDUsuarioDependencia.Value = UsuarioDependenciaId;

                    cmd.Parameters.Add(pIDUsuarioDependencia);

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        usuarioDependenciaDTO.UsuarioDependenciaId = Convert.ToInt32(dr["UsuarioDependenciaId"]);
                        usuarioDependenciaDTO.UsuarioId = Convert.ToInt32(dr["UsuarioId"]);
                        usuarioDependenciaDTO.Dependencia = Convert.ToInt32(dr["DependenciaId"]);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return usuarioDependenciaDTO;
        }

        public string ActualizarUsuarioDependencia(UsuarioDependenciaDTO usuarioDependenciaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Seguridad.usp_UsuarioDependenciaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter pUsuarioId = new SqlParameter();
                    pUsuarioId.ParameterName = "@UsuarioId";
                    pUsuarioId.SqlDbType = SqlDbType.Int;
                    pUsuarioId.Value = usuarioDependenciaDTO.UsuarioId;

                    SqlParameter pUsuarioDependenciaId = new SqlParameter();
                    pUsuarioDependenciaId.ParameterName = "@UsuarioDependenciaId";
                    pUsuarioDependenciaId.SqlDbType = SqlDbType.Int;
                    pUsuarioDependenciaId.Value = usuarioDependenciaDTO.UsuarioDependenciaId;

                    SqlParameter pDependenciaId = new SqlParameter();
                    pDependenciaId.ParameterName = "@DependenciaId";
                    pDependenciaId.SqlDbType = SqlDbType.Int;
                    pDependenciaId.Value = usuarioDependenciaDTO.Dependencia;

                    cmd.Parameters.Add(pUsuarioId);
                    cmd.Parameters.Add(pDependenciaId);
                    cmd.Parameters.Add(pUsuarioDependenciaId);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        dr.Read();
                        if (dr.HasRows)
                        {
                            IND_OPERACION = dr["IND_OPERACION"].ToString();

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                IND_OPERACION = ex.Message;
            }
            return IND_OPERACION;
        }

        public string EliminarUsuarioDependencia(int UsuarioDependenciaId)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Seguridad.usp_UsuarioDependenciaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter pUsuarioDependenciaId = new SqlParameter();
                    pUsuarioDependenciaId.ParameterName = "@UsuarioDependenciaId";
                    pUsuarioDependenciaId.SqlDbType = SqlDbType.Int;
                    pUsuarioDependenciaId.Value = UsuarioDependenciaId;
                    cmd.Parameters.Add(pUsuarioDependenciaId);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        dr.Read();
                        if (dr.HasRows)
                        {
                            IND_OPERACION = dr["IND_OPERACION"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                IND_OPERACION = ex.Message;
            }
            return IND_OPERACION;
        }
    }

}
