using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class TipoAfiliacionDAO
    {

        SqlCommand cmd = new();

        public List<TipoAfiliacionDTO> ObtenerTipoAfiliacions()
        {
            List<TipoAfiliacionDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_TipoAfiliacionListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new TipoAfiliacionDTO()
                        {
                            TipoAfiliacionId = Convert.ToInt32(dr["TipoAfiliacionId"]),
                            DescTipoAfiliacion = dr["DescTipoAfiliacion"].ToString(),
                            CodigoTipoAfiliacion = dr["CodigoTipoAfiliacion"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarTipoAfiliacion(TipoAfiliacionDTO tipoAfiliacionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoAfiliacionRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescTipoAfiliacion", SqlDbType.VarChar, 260);
                    cmd.Parameters["@DescTipoAfiliacion"].Value = tipoAfiliacionDTO.DescTipoAfiliacion;

                    cmd.Parameters.Add("@CodigoTipoAfiliacion", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoTipoAfiliacion"].Value = tipoAfiliacionDTO.CodigoTipoAfiliacion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoAfiliacionDTO.UsuarioIngresoRegistro;

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

        public TipoAfiliacionDTO BuscarTipoAfiliacionID(int Codigo)
        {
            TipoAfiliacionDTO tipoAfiliacionDTO = new TipoAfiliacionDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoAfiliacionEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoAfiliacionId", SqlDbType.Int);
                    cmd.Parameters["@TipoAfiliacionId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        tipoAfiliacionDTO.TipoAfiliacionId = Convert.ToInt32(dr["TipoAfiliacionId"]);
                        tipoAfiliacionDTO.DescTipoAfiliacion = dr["DescTipoAfiliacion"].ToString();
                        tipoAfiliacionDTO.CodigoTipoAfiliacion = dr["CodigoTipoAfiliacion"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return tipoAfiliacionDTO;
        }

        public string ActualizarTipoAfiliacion(TipoAfiliacionDTO tipoAfiliacionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoAfiliacionActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoAfiliacionId", SqlDbType.Int);
                    cmd.Parameters["@TipoAfiliacionId"].Value = tipoAfiliacionDTO.TipoAfiliacionId;

                    cmd.Parameters.Add("@DescTipoAfiliacion", SqlDbType.VarChar, 260);
                    cmd.Parameters["@DescTipoAfiliacion"].Value = tipoAfiliacionDTO.DescTipoAfiliacion;

                    cmd.Parameters.Add("@CodigoTipoAfiliacion", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoTipoAfiliacion"].Value = tipoAfiliacionDTO.CodigoTipoAfiliacion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoAfiliacionDTO.UsuarioIngresoRegistro;

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

        public string EliminarTipoAfiliacion(TipoAfiliacionDTO tipoAfiliacionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoAfiliacionEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoAfiliacionId", SqlDbType.Int);
                    cmd.Parameters["@TipoAfiliacionId"].Value = tipoAfiliacionDTO.TipoAfiliacionId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoAfiliacionDTO.UsuarioIngresoRegistro;

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
