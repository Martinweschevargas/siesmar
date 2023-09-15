using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class TipoPuertoPeruDAO
    {

        SqlCommand cmd = new();

        public List<TipoPuertoPeruDTO> ObtenerTipoPuertoPerus()
        {
            List<TipoPuertoPeruDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_TipoPuertoPeruListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new TipoPuertoPeruDTO()
                        {
                            TipoPuertoPeruId = Convert.ToInt32(dr["TipoPuertoPeruId"]),
                            DescTipoPuertoPeru = dr["DescTipoPuertoPeru"].ToString(),
                            CodigoTipoPuertoPeru = dr["CodigoTipoPuertoPeru"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarTipoPuertoPeru(TipoPuertoPeruDTO TipoPuertoPeruDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoPuertoPeruRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescTipoPuertoPeru", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescTipoPuertoPeru"].Value = TipoPuertoPeruDTO.DescTipoPuertoPeru;

                    cmd.Parameters.Add("@CodigoTipoPuertoPeru", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoTipoPuertoPeru"].Value = TipoPuertoPeruDTO.CodigoTipoPuertoPeru;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = TipoPuertoPeruDTO.UsuarioIngresoRegistro;

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

        public TipoPuertoPeruDTO BuscarTipoPuertoPeruID(int Codigo)
        {
            TipoPuertoPeruDTO TipoPuertoPeruDTO = new TipoPuertoPeruDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoPuertoPeruEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoPuertoPeruId", SqlDbType.Int);
                    cmd.Parameters["@TipoPuertoPeruId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        TipoPuertoPeruDTO.TipoPuertoPeruId = Convert.ToInt32(dr["TipoPuertoPeruId"]);
                        TipoPuertoPeruDTO.DescTipoPuertoPeru = dr["DescTipoPuertoPeru"].ToString();
                        TipoPuertoPeruDTO.CodigoTipoPuertoPeru = dr["CodigoTipoPuertoPeru"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return TipoPuertoPeruDTO;
        }

        public string ActualizarTipoPuertoPeru(TipoPuertoPeruDTO TipoPuertoPeruDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoPuertoPeruActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoPuertoPeruId", SqlDbType.Int);
                    cmd.Parameters["@TipoPuertoPeruId"].Value = TipoPuertoPeruDTO.TipoPuertoPeruId;

                    cmd.Parameters.Add("@DescTipoPuertoPeru", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescTipoPuertoPeru"].Value = TipoPuertoPeruDTO.DescTipoPuertoPeru;

                    cmd.Parameters.Add("@CodigoTipoPuertoPeru", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoTipoPuertoPeru"].Value = TipoPuertoPeruDTO.CodigoTipoPuertoPeru;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = TipoPuertoPeruDTO.UsuarioIngresoRegistro;

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

        public string EliminarTipoPuertoPeru(TipoPuertoPeruDTO TipoPuertoPeruDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoPuertoPeruEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoPuertoPeruId", SqlDbType.Int);
                    cmd.Parameters["@TipoPuertoPeruId"].Value = TipoPuertoPeruDTO.TipoPuertoPeruId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = TipoPuertoPeruDTO.UsuarioIngresoRegistro;

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
