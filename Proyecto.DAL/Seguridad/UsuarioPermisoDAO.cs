using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Seguridad
{
    public class UsuarioPermisoDAO
    {
        SqlCommand cmd = new SqlCommand();

        public List<UsuarioPermisoDTO> ObtenerUsuarioPermiso()
        {
            List<UsuarioPermisoDTO> lista = new List<UsuarioPermisoDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Seguridad.usp_UsuarioPermisoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new UsuarioPermisoDTO()
                        {
                            UsuarioPermisoId = Convert.ToInt32(dr["UsuarioPermisoId"]),
                            Usuario = dr["NombreUsuario"].ToString(),
                            Dependencia = dr["Dependencia"].ToString(),
                            DependenciaSubordinada = dr["DependenciaSubordinada"].ToString(),
                            Formato = dr["Formato"].ToString(),
                            Permiso = dr["Permiso"].ToString(),
                            Estado = dr["Estado"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarUsuarioPermiso(UsuarioPermisoDTO usuarioPermisoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Seguridad.usp_UsuarioPermisoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UsuarioFormatoId", SqlDbType.Int);
                    cmd.Parameters["@UsuarioFormatoId"].Value = usuarioPermisoDTO.UsuarioFormatoId;

                    cmd.Parameters.Add("@PermisoId", SqlDbType.Int);
                    cmd.Parameters["@PermisoId"].Value = usuarioPermisoDTO.PermisoId;

                    cmd.Parameters.Add("@Estado", SqlDbType.Int);
                    cmd.Parameters["@Estado"].Value = usuarioPermisoDTO.EstadoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Usuario"].Value = usuarioPermisoDTO.UsuarioIngresoRegistro;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Mac"].Value = UtilitariosGlobales.obtenerDireccionMac();
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

        public UsuarioPermisoDTO BuscarUsuarioPermisoID(int usuarioPermisoId)
        {
            UsuarioPermisoDTO usuarioPermisoDTO = new();
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Seguridad.usp_UsuarioPermisoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter pIDUsuarioPermiso = new SqlParameter();
                    pIDUsuarioPermiso.ParameterName = "@UsuarioPermisoId";
                    pIDUsuarioPermiso.SqlDbType = SqlDbType.Int;
                    pIDUsuarioPermiso.Value = usuarioPermisoId;

                    cmd.Parameters.Add(pIDUsuarioPermiso);

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        usuarioPermisoDTO.UsuarioPermisoId = Convert.ToInt32(dr["UsuarioPermisoId"]);
                        usuarioPermisoDTO.PermisoId = Convert.ToInt32(dr["PermisoId"]);
                        usuarioPermisoDTO.FormatoId = Convert.ToInt32(dr["FormatoReporteId"]);
                        usuarioPermisoDTO.EstadoId = Convert.ToInt32(dr["Estado"]);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return usuarioPermisoDTO;
        }

        public bool ActualizarUsuarioPermiso(UsuarioPermisoDTO usuarioPermisoDTO)
        {
            bool respuesta = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Seguridad.usp_UsuarioPermisoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter pUsuarioRolId = new SqlParameter();
                    pUsuarioRolId.ParameterName = "@UsuarioRolId";
                    pUsuarioRolId.SqlDbType = SqlDbType.Int;
                    pUsuarioRolId.Value = usuarioPermisoDTO.UsuarioPermisoId;

                    SqlParameter pUsuarioId = new SqlParameter();
                    pUsuarioId.ParameterName = "@UsuarioId";
                    pUsuarioId.SqlDbType = SqlDbType.Int;
                    pUsuarioId.Value = usuarioPermisoDTO.UsuarioPermisoId;

                    SqlParameter pRolId = new SqlParameter();
                    pRolId.ParameterName = "@RolId";
                    pRolId.SqlDbType = SqlDbType.Int;
                    pRolId.Value = usuarioPermisoDTO.Usuario;

                    SqlParameter pIP = new SqlParameter();
                    pIP.ParameterName = "@Usuario";
                    pIP.SqlDbType = SqlDbType.VarChar;
                    pIP.Size = 80;
                    pIP.Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add(pUsuarioId);
                    cmd.Parameters.Add(pRolId);
                    cmd.Parameters.Add(pIP);

                    cmd.ExecuteNonQuery();
                    respuesta = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return respuesta;
        }

        public string EliminarUsuarioPermiso(UsuarioPermisoDTO usuarioPermisoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Seguridad.usp_UsuarioPermisoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UsuarioPermisoId", SqlDbType.Int);
                    cmd.Parameters["@UsuarioPermisoId"].Value = usuarioPermisoDTO.UsuarioPermisoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = usuarioPermisoDTO.UsuarioIngresoRegistro;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Mac"].Value = UtilitariosGlobales.obtenerDireccionMac();

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
    }

}
