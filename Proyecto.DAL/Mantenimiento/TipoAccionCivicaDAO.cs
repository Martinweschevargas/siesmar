using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class TipoAccionCivicaDAO
    {

        SqlCommand cmd = new();

        public List<TipoAccionCivicaDTO> ObtenerTipoAccionCivicas()
        {
            List<TipoAccionCivicaDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_TipoAccionCivicaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new TipoAccionCivicaDTO()
                        {
                            TipoAccionCivicaId = Convert.ToInt32(dr["TipoAccionCivicaId"]),
                            DescTipoAccionCivica = dr["DescTipoAccionCivica"].ToString(),
                            CodigoTipoAccionCivica = dr["CodigoTipoAccionCivica"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarTipoAccionCivica(TipoAccionCivicaDTO tipoAccionCivicaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoAccionCivicaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescTipoAccionCivica", SqlDbType.VarChar, 260);
                    cmd.Parameters["@DescTipoAccionCivica"].Value = tipoAccionCivicaDTO.DescTipoAccionCivica;

                    cmd.Parameters.Add("@CodigoTipoAccionCivica", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoTipoAccionCivica"].Value = tipoAccionCivicaDTO.CodigoTipoAccionCivica;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoAccionCivicaDTO.UsuarioIngresoRegistro;

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

        public TipoAccionCivicaDTO BuscarTipoAccionCivicaID(int Codigo)
        {
            TipoAccionCivicaDTO tipoAccionCivicaDTO = new TipoAccionCivicaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoAccionCivicaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoAccionCivicaId", SqlDbType.Int);
                    cmd.Parameters["@TipoAccionCivicaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        tipoAccionCivicaDTO.TipoAccionCivicaId = Convert.ToInt32(dr["TipoAccionCivicaId"]);
                        tipoAccionCivicaDTO.DescTipoAccionCivica = dr["DescTipoAccionCivica"].ToString();
                        tipoAccionCivicaDTO.CodigoTipoAccionCivica = dr["CodigoTipoAccionCivica"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return tipoAccionCivicaDTO;
        }

        public string ActualizarTipoAccionCivica(TipoAccionCivicaDTO tipoAccionCivicaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoAccionCivicaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoAccionCivicaId", SqlDbType.Int);
                    cmd.Parameters["@TipoAccionCivicaId"].Value = tipoAccionCivicaDTO.TipoAccionCivicaId;

                    cmd.Parameters.Add("@DescTipoAccionCivica", SqlDbType.VarChar, 260);
                    cmd.Parameters["@DescTipoAccionCivica"].Value = tipoAccionCivicaDTO.DescTipoAccionCivica;

                    cmd.Parameters.Add("@CodigoTipoAccionCivica", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoTipoAccionCivica"].Value = tipoAccionCivicaDTO.CodigoTipoAccionCivica;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoAccionCivicaDTO.UsuarioIngresoRegistro;

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

        public string EliminarTipoAccionCivica(TipoAccionCivicaDTO tipoAccionCivicaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoAccionCivicaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoAccionCivicaId", SqlDbType.Int);
                    cmd.Parameters["@TipoAccionCivicaId"].Value = tipoAccionCivicaDTO.TipoAccionCivicaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoAccionCivicaDTO.UsuarioIngresoRegistro;

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
