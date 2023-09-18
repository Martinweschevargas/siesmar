using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Seguridad
{
    public class UsuarioFormatoDAO
    {
        SqlCommand cmd = new SqlCommand();

        public List<UsuarioFormatoDTO> ObtenerUsuarioFormatos(int? usuario = null)
        {
            List<UsuarioFormatoDTO> lista = new List<UsuarioFormatoDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Seguridad.usp_UsuarioFormatosListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@UsuarioId", SqlDbType.Int);
                cmd.Parameters["@UsuarioId"].Value = usuario;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new UsuarioFormatoDTO()
                        {
                            UsuarioFormatoId = Convert.ToInt32(dr["UsuarioFormatoId"]),
                            NombreUsuario = dr["NombreUsuario"].ToString(),
                            DependenciaId = dr["DependenciaId"].ToString(),
                            DependenciaSubordinadoId = dr["DependenciaSubordinadoId"].ToString(),
                            DescFormato = dr["DescFormato"].ToString(),
                            DescDependencia = dr["DescDependencia"].ToString(),
                            DescDependenciaSubordinado = dr["DescDependenciaSubordinada"].ToString(),
                            Flag = Convert.ToInt32(dr["flag"].ToString())
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarUsuarioFormato(UsuarioFormatoDTO usuarioFormatoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();

                    cmd = new SqlCommand("Seguridad.usp_UsuarioFormatosRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UsuarioId", SqlDbType.Int);
                    cmd.Parameters["@UsuarioId"].Value = usuarioFormatoDTO.UsuarioId;

                    cmd.Parameters.Add("@FormatoReporteId", SqlDbType.Int);
                    cmd.Parameters["@FormatoReporteId"].Value = usuarioFormatoDTO.FormatoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = usuarioFormatoDTO.UsuarioIngresoRegistro;

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

        public UsuarioFormatoDTO BuscarUsuarioFormatoID(int UsuarioFormatoId)
        {
            UsuarioFormatoDTO UsuarioFormatoDTO = new UsuarioFormatoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Seguridad.usp_UsuarioFormatosEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter pIDUsuarioFormato = new SqlParameter();
                    pIDUsuarioFormato.ParameterName = "@UsuarioFormatosId";
                    pIDUsuarioFormato.SqlDbType = SqlDbType.Int;
                    pIDUsuarioFormato.Value = UsuarioFormatoId;

                    cmd.Parameters.Add(pIDUsuarioFormato);

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        UsuarioFormatoDTO.UsuarioFormatoId = Convert.ToInt32(dr["UsuarioFormatoId"]);
                        UsuarioFormatoDTO.UsuarioId = Convert.ToInt32(dr["UsuarioId"]);
                        // UsuarioFormatoDTO.NombreFormatoReporte = dr["NombreFormatoReporte"].ToString();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return UsuarioFormatoDTO;
        }

        public string ActualizarUsuarioFormato(UsuarioFormatoDTO usuarioFormatoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Seguridad.usp_UsuarioFormatosActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter pUsuarioFormatoId = new SqlParameter();
                    pUsuarioFormatoId.ParameterName = "@UsuarioFormatoId";
                    pUsuarioFormatoId.SqlDbType = SqlDbType.Int;
                    pUsuarioFormatoId.Value = usuarioFormatoDTO.UsuarioFormatoId;

                    SqlParameter pUsuarioId = new SqlParameter();
                    pUsuarioId.ParameterName = "@UsuarioId";
                    pUsuarioId.SqlDbType = SqlDbType.Int;
                    pUsuarioId.Value = usuarioFormatoDTO.UsuarioId;

                    //SqlParameter pFormatoReporteSId = new SqlParameter();
                    //pFormatoReporteSId.ParameterName = "@FormatoReporteSubordinadoId";
                    // pFormatoReporteSId.SqlDbType = SqlDbType.Int;
                    // pFormatoReporteSId.Value = usuarioFormatoDTO.FormatoReporteSubordinadoId;

                    SqlParameter pIP = new SqlParameter();
                    pIP.ParameterName = "@Usuario";
                    pIP.SqlDbType = SqlDbType.VarChar;
                    pIP.Size = 80;
                    pIP.Value = UtilitariosGlobales.obtenerDireccionIp();

                    // cmd.Parameters.Add(pUsuarioFormatoId);
                    //  cmd.Parameters.Add(pUsuarioId);
                    // cmd.Parameters.Add(pFormatoReporteSId);

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

        public string EliminarUsuarioFormato(UsuarioFormatoDTO usuarioFormatoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Seguridad.usp_UsuarioFormatosEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UsuarioFormatoId", SqlDbType.Int);
                    cmd.Parameters["@UsuarioFormatoId"].Value = usuarioFormatoDTO.UsuarioFormatoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = usuarioFormatoDTO.UsuarioIngresoRegistro;

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
