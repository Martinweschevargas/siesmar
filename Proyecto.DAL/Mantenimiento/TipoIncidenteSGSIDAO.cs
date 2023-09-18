using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class TipoIncidenteSGSIDAO
    {

        SqlCommand cmd = new();

        public List<TipoIncidenteSGSIDTO> ObtenerTipoIncidenteSGSIs()
        {
            List<TipoIncidenteSGSIDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_TipoIncidenteSGSIListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new TipoIncidenteSGSIDTO()
                        {
                            TipoIncidenteSGSIId = Convert.ToInt32(dr["TipoIncidenteSGSIId"]),
                            DescTipoIncidenteSGSI = dr["DescTipoIncidenteSGSI"].ToString(),
                            CodigoTipoIncidenteSGSI = dr["CodigoTipoIncidenteSGSI"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarTipoIncidenteSGSI(TipoIncidenteSGSIDTO tipoIncidenteSGSIDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoIncidenteSGSIRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescTipoIncidenteSGSI", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescTipoIncidenteSGSI"].Value = tipoIncidenteSGSIDTO.DescTipoIncidenteSGSI;

                    cmd.Parameters.Add("@CodigoTipoIncidenteSGSI", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoTipoIncidenteSGSI"].Value = tipoIncidenteSGSIDTO.CodigoTipoIncidenteSGSI;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoIncidenteSGSIDTO.UsuarioIngresoRegistro;

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

        public TipoIncidenteSGSIDTO BuscarTipoIncidenteSGSIID(int Codigo)
        {
            TipoIncidenteSGSIDTO tipoIncidenteSGSIDTO = new TipoIncidenteSGSIDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoIncidenteSGSIEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoIncidenteSGSIId", SqlDbType.Int);
                    cmd.Parameters["@TipoIncidenteSGSIId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        tipoIncidenteSGSIDTO.TipoIncidenteSGSIId = Convert.ToInt32(dr["TipoIncidenteSGSIId"]);
                        tipoIncidenteSGSIDTO.DescTipoIncidenteSGSI = dr["DescTipoIncidenteSGSI"].ToString();
                        tipoIncidenteSGSIDTO.CodigoTipoIncidenteSGSI = dr["CodigoTipoIncidenteSGSI"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return tipoIncidenteSGSIDTO;
        }

        public string ActualizarTipoIncidenteSGSI(TipoIncidenteSGSIDTO tipoIncidenteSGSIDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoIncidenteSGSIActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoIncidenteSGSIId", SqlDbType.Int);
                    cmd.Parameters["@TipoIncidenteSGSIId"].Value = tipoIncidenteSGSIDTO.TipoIncidenteSGSIId;

                    cmd.Parameters.Add("@DescTipoIncidenteSGSI", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescTipoIncidenteSGSI"].Value = tipoIncidenteSGSIDTO.DescTipoIncidenteSGSI;

                    cmd.Parameters.Add("@CodigoTipoIncidenteSGSI", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoTipoIncidenteSGSI"].Value = tipoIncidenteSGSIDTO.CodigoTipoIncidenteSGSI;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoIncidenteSGSIDTO.UsuarioIngresoRegistro;

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

        public string EliminarTipoIncidenteSGSI(TipoIncidenteSGSIDTO tipoIncidenteSGSIDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoIncidenteSGSIEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoIncidenteSGSIId", SqlDbType.Int);
                    cmd.Parameters["@TipoIncidenteSGSIId"].Value = tipoIncidenteSGSIDTO.TipoIncidenteSGSIId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoIncidenteSGSIDTO.UsuarioIngresoRegistro;

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
