using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class TipoInformacionEmitidaDAO
    {

        SqlCommand cmd = new();

        public List<TipoInformacionEmitidaDTO> ObtenerTipoInformacionEmitidas()
        {
            List<TipoInformacionEmitidaDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_TipoInformacionEmitidaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new TipoInformacionEmitidaDTO()
                        {
                            TipoInformacionEmitidaId = Convert.ToInt32(dr["TipoInformacionEmitidaId"]),
                            DescTipoInformacionEmitida = dr["DescTipoInformacionEmitida"].ToString(),
                            CodigoTipoInformacionEmitida = dr["CodigoTipoInformacionEmitida"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarTipoInformacionEmitida(TipoInformacionEmitidaDTO tipoInformacionEmitidaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoInformacionEmitidaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescTipoInformacionEmitida", SqlDbType.VarChar, 80);
                    cmd.Parameters["@DescTipoInformacionEmitida"].Value = tipoInformacionEmitidaDTO.DescTipoInformacionEmitida;

                    cmd.Parameters.Add("@CodigoTipoInformacionEmitida", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoTipoInformacionEmitida"].Value = tipoInformacionEmitidaDTO.CodigoTipoInformacionEmitida;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoInformacionEmitidaDTO.UsuarioIngresoRegistro;

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

        public TipoInformacionEmitidaDTO BuscarTipoInformacionEmitidaID(int Codigo)
        {
            TipoInformacionEmitidaDTO tipoInformacionEmitidaDTO = new TipoInformacionEmitidaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoInformacionEmitidaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoInformacionEmitidaId", SqlDbType.Int);
                    cmd.Parameters["@TipoInformacionEmitidaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        tipoInformacionEmitidaDTO.TipoInformacionEmitidaId = Convert.ToInt32(dr["TipoInformacionEmitidaId"]);
                        tipoInformacionEmitidaDTO.DescTipoInformacionEmitida = dr["DescTipoInformacionEmitida"].ToString();
                        tipoInformacionEmitidaDTO.CodigoTipoInformacionEmitida = dr["CodigoTipoInformacionEmitida"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return tipoInformacionEmitidaDTO;
        }

        public string ActualizarTipoInformacionEmitida(TipoInformacionEmitidaDTO tipoInformacionEmitidaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoInformacionEmitidaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoInformacionEmitidaId", SqlDbType.Int);
                    cmd.Parameters["@TipoInformacionEmitidaId"].Value = tipoInformacionEmitidaDTO.TipoInformacionEmitidaId;

                    cmd.Parameters.Add("@DescTipoInformacionEmitida", SqlDbType.VarChar, 80);
                    cmd.Parameters["@DescTipoInformacionEmitida"].Value = tipoInformacionEmitidaDTO.DescTipoInformacionEmitida;

                    cmd.Parameters.Add("@CodigoTipoInformacionEmitida", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoTipoInformacionEmitida"].Value = tipoInformacionEmitidaDTO.CodigoTipoInformacionEmitida;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoInformacionEmitidaDTO.UsuarioIngresoRegistro;

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

        public string EliminarTipoInformacionEmitida(TipoInformacionEmitidaDTO tipoInformacionEmitidaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoInformacionEmitidaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoInformacionEmitidaId", SqlDbType.Int);
                    cmd.Parameters["@TipoInformacionEmitidaId"].Value = tipoInformacionEmitidaDTO.TipoInformacionEmitidaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoInformacionEmitidaDTO.UsuarioIngresoRegistro;

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
