using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class TipoDesplazamientoDAO
    {

        SqlCommand cmd = new();

        public List<TipoDesplazamientoDTO> ObtenerTipoDesplazamientos()
        {
            List<TipoDesplazamientoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_TipoDesplazamientoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new TipoDesplazamientoDTO()
                        {
                            TipoDesplazamientoId = Convert.ToInt32(dr["TipoDesplazamientoId"]),
                            DescTipoDesplazamiento = dr["DescTipoDesplazamiento"].ToString(),
                            CodigoTipoDesplazamiento = dr["CodigoTipoDesplazamiento"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarTipoDesplazamiento(TipoDesplazamientoDTO tipoDesplazamientoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoDesplazamientoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescTipoDesplazamiento", SqlDbType.VarChar, 200);
                    cmd.Parameters["@DescTipoDesplazamiento"].Value = tipoDesplazamientoDTO.DescTipoDesplazamiento;

                    cmd.Parameters.Add("@CodigoTipoDesplazamiento", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoDesplazamiento"].Value = tipoDesplazamientoDTO.CodigoTipoDesplazamiento;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoDesplazamientoDTO.UsuarioIngresoRegistro;

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

        public TipoDesplazamientoDTO BuscarTipoDesplazamientoID(int Codigo)
        {
            TipoDesplazamientoDTO tipoDesplazamientoDTO = new TipoDesplazamientoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoDesplazamientoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoDesplazamientoId", SqlDbType.Int);
                    cmd.Parameters["@TipoDesplazamientoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        tipoDesplazamientoDTO.TipoDesplazamientoId = Convert.ToInt32(dr["TipoDesplazamientoId"]);
                        tipoDesplazamientoDTO.DescTipoDesplazamiento = dr["DescTipoDesplazamiento"].ToString();
                        tipoDesplazamientoDTO.CodigoTipoDesplazamiento = dr["CodigoTipoDesplazamiento"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return tipoDesplazamientoDTO;
        }

        public string ActualizarTipoDesplazamiento(TipoDesplazamientoDTO tipoDesplazamientoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoDesplazamientoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoDesplazamientoId", SqlDbType.Int);
                    cmd.Parameters["@TipoDesplazamientoId"].Value = tipoDesplazamientoDTO.TipoDesplazamientoId;

                    cmd.Parameters.Add("@DescTipoDesplazamiento", SqlDbType.VarChar, 200);
                    cmd.Parameters["@DescTipoDesplazamiento"].Value = tipoDesplazamientoDTO.DescTipoDesplazamiento;

                    cmd.Parameters.Add("@CodigoTipoDesplazamiento", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoDesplazamiento"].Value = tipoDesplazamientoDTO.CodigoTipoDesplazamiento;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoDesplazamientoDTO.UsuarioIngresoRegistro;

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

        public string EliminarTipoDesplazamiento(TipoDesplazamientoDTO tipoDesplazamientoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoDesplazamientoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoDesplazamientoId", SqlDbType.Int);
                    cmd.Parameters["@TipoDesplazamientoId"].Value = tipoDesplazamientoDTO.TipoDesplazamientoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoDesplazamientoDTO.UsuarioIngresoRegistro;

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
