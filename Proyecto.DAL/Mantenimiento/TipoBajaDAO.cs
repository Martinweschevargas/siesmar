using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class TipoBajaDAO
    {

        SqlCommand cmd = new();

        public List<TipoBajaDTO> ObtenerTipoBajas()
        {
            List<TipoBajaDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_TipoBajaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new TipoBajaDTO()
                        {
                            TipoBajaId = Convert.ToInt32(dr["TipoBajaId"]),
                            DescTipoBaja = dr["DescTipoBaja"].ToString(),
                            CodigoTipoBaja = dr["CodigoTipoBaja"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarTipoBaja(TipoBajaDTO tipoBajaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoBajaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescTipoBaja", SqlDbType.VarChar, 260);
                    cmd.Parameters["@DescTipoBaja"].Value = tipoBajaDTO.DescTipoBaja;

                    cmd.Parameters.Add("@CodigoTipoBaja", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoBaja"].Value = tipoBajaDTO.CodigoTipoBaja;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoBajaDTO.UsuarioIngresoRegistro;

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

        public TipoBajaDTO BuscarTipoBajaID(int Codigo)
        {
            TipoBajaDTO tipoBajaDTO = new TipoBajaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoBajaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoBajaId", SqlDbType.Int);
                    cmd.Parameters["@TipoBajaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        tipoBajaDTO.TipoBajaId = Convert.ToInt32(dr["TipoBajaId"]);
                        tipoBajaDTO.DescTipoBaja = dr["DescTipoBaja"].ToString();
                        tipoBajaDTO.CodigoTipoBaja = dr["CodigoTipoBaja"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return tipoBajaDTO;
        }

        public string ActualizarTipoBaja(TipoBajaDTO tipoBajaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoBajaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoBajaId", SqlDbType.Int);
                    cmd.Parameters["@TipoBajaId"].Value = tipoBajaDTO.TipoBajaId;

                    cmd.Parameters.Add("@DescTipoBaja", SqlDbType.VarChar, 260);
                    cmd.Parameters["@DescTipoBaja"].Value = tipoBajaDTO.DescTipoBaja;

                    cmd.Parameters.Add("@CodigoTipoBaja", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoBaja"].Value = tipoBajaDTO.CodigoTipoBaja;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoBajaDTO.UsuarioIngresoRegistro;

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

        public string EliminarTipoBaja(TipoBajaDTO tipoBajaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoBajaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoBajaId", SqlDbType.Int);
                    cmd.Parameters["@TipoBajaId"].Value = tipoBajaDTO.TipoBajaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoBajaDTO.UsuarioIngresoRegistro;

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
