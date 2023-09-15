using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class TipoPlataformaNaveDAO
    {

        SqlCommand cmd = new();

        public List<TipoPlataformaNaveDTO> ObtenerTipoPlataformaNaves()
        {
            List<TipoPlataformaNaveDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_TipoPlataformaNaveListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new TipoPlataformaNaveDTO()
                        {
                            TipoPlataformaNaveId = Convert.ToInt32(dr["TipoPlataformaNaveId"]),
                            DescTipoPlataformaNave = dr["DescTipoPlataformaNave"].ToString(),
                            CodigoTipoPlataformaNave = dr["CodigoTipoPlataformaNave"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarTipoPlataformaNave(TipoPlataformaNaveDTO tipoPlataformaNaveDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoPlataformaNaveRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescTipoPlataformaNave", SqlDbType.VarChar, 100);
                    cmd.Parameters["@DescTipoPlataformaNave"].Value = tipoPlataformaNaveDTO.DescTipoPlataformaNave;

                    cmd.Parameters.Add("@CodigoTipoPlataformaNave", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoTipoPlataformaNave"].Value = tipoPlataformaNaveDTO.CodigoTipoPlataformaNave;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoPlataformaNaveDTO.UsuarioIngresoRegistro;

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

        public TipoPlataformaNaveDTO BuscarTipoPlataformaNaveID(int Codigo)
        {
            TipoPlataformaNaveDTO tipoPlataformaNaveDTO = new TipoPlataformaNaveDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoPlataformaNaveEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoPlataformaNaveId", SqlDbType.Int);
                    cmd.Parameters["@TipoPlataformaNaveId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        tipoPlataformaNaveDTO.TipoPlataformaNaveId = Convert.ToInt32(dr["TipoPlataformaNaveId"]);
                        tipoPlataformaNaveDTO.DescTipoPlataformaNave = dr["DescTipoPlataformaNave"].ToString();
                        tipoPlataformaNaveDTO.CodigoTipoPlataformaNave = dr["CodigoTipoPlataformaNave"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return tipoPlataformaNaveDTO;
        }

        public string ActualizarTipoPlataformaNave(TipoPlataformaNaveDTO tipoPlataformaNaveDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoPlataformaNaveActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoPlataformaNaveId", SqlDbType.Int);
                    cmd.Parameters["@TipoPlataformaNaveId"].Value = tipoPlataformaNaveDTO.TipoPlataformaNaveId;

                    cmd.Parameters.Add("@DescTipoPlataformaNave", SqlDbType.VarChar, 100);
                    cmd.Parameters["@DescTipoPlataformaNave"].Value = tipoPlataformaNaveDTO.DescTipoPlataformaNave;

                    cmd.Parameters.Add("@CodigoTipoPlataformaNave", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoTipoPlataformaNave"].Value = tipoPlataformaNaveDTO.CodigoTipoPlataformaNave;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoPlataformaNaveDTO.UsuarioIngresoRegistro;

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

        public string EliminarTipoPlataformaNave(TipoPlataformaNaveDTO tipoPlataformaNaveDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoPlataformaNaveEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoPlataformaNaveId", SqlDbType.Int);
                    cmd.Parameters["@TipoPlataformaNaveId"].Value = tipoPlataformaNaveDTO.TipoPlataformaNaveId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoPlataformaNaveDTO.UsuarioIngresoRegistro;

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
