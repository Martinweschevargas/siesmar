using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class TipoPlataformaAeronaveDAO
    {

        SqlCommand cmd = new();

        public List<TipoPlataformaAeronaveDTO> ObtenerTipoPlataformaAeronaves()
        {
            List<TipoPlataformaAeronaveDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_TipoPlataformaAeronaveListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new TipoPlataformaAeronaveDTO()
                        {
                            TipoPlataformaAeronaveId = Convert.ToInt32(dr["TipoPlataformaAeronaveId"]),
                            DescTipoPlataformaAeronave = dr["DescTipoPlataformaAeronave"].ToString(),
                            CodigoTipoPlataformaAeronave = dr["CodigoTipoPlataformaAeronave"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarTipoPlataformaAeronave(TipoPlataformaAeronaveDTO tipoPlataformaAeronaveDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoPlataformaAeronaveRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescTipoPlataformaAeronave", SqlDbType.VarChar, 100);
                    cmd.Parameters["@DescTipoPlataformaAeronave"].Value = tipoPlataformaAeronaveDTO.DescTipoPlataformaAeronave;

                    cmd.Parameters.Add("@CodigoTipoPlataformaAeronave", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoTipoPlataformaAeronave"].Value = tipoPlataformaAeronaveDTO.CodigoTipoPlataformaAeronave;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoPlataformaAeronaveDTO.UsuarioIngresoRegistro;

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

        public TipoPlataformaAeronaveDTO BuscarTipoPlataformaAeronaveID(int Codigo)
        {
            TipoPlataformaAeronaveDTO tipoPlataformaAeronaveDTO = new TipoPlataformaAeronaveDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoPlataformaAeronaveEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoPlataformaAeronaveId", SqlDbType.Int);
                    cmd.Parameters["@TipoPlataformaAeronaveId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        tipoPlataformaAeronaveDTO.TipoPlataformaAeronaveId = Convert.ToInt32(dr["TipoPlataformaAeronaveId"]);
                        tipoPlataformaAeronaveDTO.DescTipoPlataformaAeronave = dr["DescTipoPlataformaAeronave"].ToString();
                        tipoPlataformaAeronaveDTO.CodigoTipoPlataformaAeronave = dr["CodigoTipoPlataformaAeronave"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return tipoPlataformaAeronaveDTO;
        }

        public string ActualizarTipoPlataformaAeronave(TipoPlataformaAeronaveDTO tipoPlataformaAeronaveDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoPlataformaAeronaveActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoPlataformaAeronaveId", SqlDbType.Int);
                    cmd.Parameters["@TipoPlataformaAeronaveId"].Value = tipoPlataformaAeronaveDTO.TipoPlataformaAeronaveId;

                    cmd.Parameters.Add("@DescTipoPlataformaAeronave", SqlDbType.VarChar, 100);
                    cmd.Parameters["@DescTipoPlataformaAeronave"].Value = tipoPlataformaAeronaveDTO.DescTipoPlataformaAeronave;

                    cmd.Parameters.Add("@CodigoTipoPlataformaAeronave", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoTipoPlataformaAeronave"].Value = tipoPlataformaAeronaveDTO.CodigoTipoPlataformaAeronave;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoPlataformaAeronaveDTO.UsuarioIngresoRegistro;

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

        public string EliminarTipoPlataformaAeronave(TipoPlataformaAeronaveDTO tipoPlataformaAeronaveDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoPlataformaAeronaveEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoPlataformaAeronaveId", SqlDbType.Int);
                    cmd.Parameters["@TipoPlataformaAeronaveId"].Value = tipoPlataformaAeronaveDTO.TipoPlataformaAeronaveId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoPlataformaAeronaveDTO.UsuarioIngresoRegistro;

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
