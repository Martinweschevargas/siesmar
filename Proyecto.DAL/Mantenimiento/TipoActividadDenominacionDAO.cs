using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class TipoActividadDenominacionDAO
    {

        SqlCommand cmd = new();

        public List<TipoActividadDenominacionDTO> ObtenerTipoActividadDenominacions()
        {
            List<TipoActividadDenominacionDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_TipoActividadDenominacionListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new TipoActividadDenominacionDTO()
                        {
                            TipoActividadDenominacionId = Convert.ToInt32(dr["TipoActividadDenominacionId"]),
                            DescTipoActividadDenominacion = dr["DescTipoActividadDenominacion"].ToString(),
                            CodigoTipoActividadDenominacion = dr["CodigoTipoActividadDenominacion"].ToString(),
                            DescTipoActividad = dr["DescTipoActividad"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarTipoActividadDenominacion(TipoActividadDenominacionDTO tipoActividadDenominacionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoActividadDenominacionRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescTipoActividadDenominacion", SqlDbType.VarChar, 260);
                    cmd.Parameters["@DescTipoActividadDenominacion"].Value = tipoActividadDenominacionDTO.DescTipoActividadDenominacion;

                    cmd.Parameters.Add("@CodigoTipoActividadDenominacion", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoTipoActividadDenominacion"].Value = tipoActividadDenominacionDTO.CodigoTipoActividadDenominacion;

                    cmd.Parameters.Add("@TipoActividadId", SqlDbType.Int);
                    cmd.Parameters["@TipoActividadId"].Value = tipoActividadDenominacionDTO.TipoActividadId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoActividadDenominacionDTO.UsuarioIngresoRegistro;

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

        public TipoActividadDenominacionDTO BuscarTipoActividadDenominacionID(int Codigo)
        {
            TipoActividadDenominacionDTO tipoActividadDenominacionDTO = new TipoActividadDenominacionDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoActividadDenominacionEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoActividadDenominacionId", SqlDbType.Int);
                    cmd.Parameters["@TipoActividadDenominacionId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        tipoActividadDenominacionDTO.TipoActividadDenominacionId = Convert.ToInt32(dr["TipoActividadDenominacionId"]);
                        tipoActividadDenominacionDTO.DescTipoActividadDenominacion = dr["DescTipoActividadDenominacion"].ToString();
                        tipoActividadDenominacionDTO.CodigoTipoActividadDenominacion = dr["CodigoTipoActividadDenominacion"].ToString();
                        tipoActividadDenominacionDTO.TipoActividadId = Convert.ToInt32(dr["TipoActividadId"]);
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return tipoActividadDenominacionDTO;
        }

        public string ActualizarTipoActividadDenominacion(TipoActividadDenominacionDTO tipoActividadDenominacionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_TipoActividadDenominacionActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoActividadDenominacionId", SqlDbType.Int);
                    cmd.Parameters["@TipoActividadDenominacionId"].Value = tipoActividadDenominacionDTO.TipoActividadDenominacionId;

                    cmd.Parameters.Add("@DescTipoActividadDenominacion", SqlDbType.VarChar, 260);
                    cmd.Parameters["@DescTipoActividadDenominacion"].Value = tipoActividadDenominacionDTO.DescTipoActividadDenominacion;

                    cmd.Parameters.Add("@CodigoTipoActividadDenominacion", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoTipoActividadDenominacion"].Value = tipoActividadDenominacionDTO.CodigoTipoActividadDenominacion;

                    cmd.Parameters.Add("@TipoActividadId", SqlDbType.Int);
                    cmd.Parameters["@TipoActividadId"].Value = tipoActividadDenominacionDTO.TipoActividadId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoActividadDenominacionDTO.UsuarioIngresoRegistro;

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
            }
            catch (Exception ex)
            {
                IND_OPERACION = ex.Message;
            }
            return IND_OPERACION;
        }

        public string EliminarTipoActividadDenominacion(TipoActividadDenominacionDTO tipoActividadDenominacionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoActividadDenominacionEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoActividadDenominacionId", SqlDbType.Int);
                    cmd.Parameters["@TipoActividadDenominacionId"].Value = tipoActividadDenominacionDTO.TipoActividadDenominacionId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoActividadDenominacionDTO.UsuarioIngresoRegistro;

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
            }
            catch (Exception ex)
            {
                IND_OPERACION = ex.Message;
            }
            return IND_OPERACION;
        }


    }
}
