using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class TipoCiberataqueDAO
    {

        SqlCommand cmd = new();

        public List<TipoCiberataqueDTO> ObtenerTipoCiberataques()
        {
            List<TipoCiberataqueDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_TipoCiberataqueListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new TipoCiberataqueDTO()
                        {
                            TipoCiberataqueId = Convert.ToInt32(dr["TipoCiberataqueId"]),
                            DescTipoCiberataque = dr["DescTipoCiberataque"].ToString(),
                            CodigoTipoCiberataque = dr["CodigoTipoCiberataque"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarTipoCiberataque(TipoCiberataqueDTO tipoCiberataqueDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoCiberataqueRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescTipoCiberataque", SqlDbType.VarChar, 260);
                    cmd.Parameters["@DescTipoCiberataque"].Value = tipoCiberataqueDTO.DescTipoCiberataque;

                    cmd.Parameters.Add("@CodigoTipoCiberataque", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoTipoCiberataque"].Value = tipoCiberataqueDTO.CodigoTipoCiberataque;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoCiberataqueDTO.UsuarioIngresoRegistro;

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

        public TipoCiberataqueDTO BuscarTipoCiberataqueID(int Codigo)
        {
            TipoCiberataqueDTO tipoCiberataqueDTO = new TipoCiberataqueDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoCiberataqueEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoCiberataqueId", SqlDbType.Int);
                    cmd.Parameters["@TipoCiberataqueId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        tipoCiberataqueDTO.TipoCiberataqueId = Convert.ToInt32(dr["TipoCiberataqueId"]);
                        tipoCiberataqueDTO.DescTipoCiberataque = dr["DescTipoCiberataque"].ToString();
                        tipoCiberataqueDTO.CodigoTipoCiberataque = dr["CodigoTipoCiberataque"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return tipoCiberataqueDTO;
        }

        public string ActualizarTipoCiberataque(TipoCiberataqueDTO tipoCiberataqueDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoCiberataqueActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoCiberataqueId", SqlDbType.Int);
                    cmd.Parameters["@TipoCiberataqueId"].Value = tipoCiberataqueDTO.TipoCiberataqueId;

                    cmd.Parameters.Add("@DescTipoCiberataque", SqlDbType.VarChar, 260);
                    cmd.Parameters["@DescTipoCiberataque"].Value = tipoCiberataqueDTO.DescTipoCiberataque;

                    cmd.Parameters.Add("@CodigoTipoCiberataque", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoTipoCiberataque"].Value = tipoCiberataqueDTO.CodigoTipoCiberataque;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoCiberataqueDTO.UsuarioIngresoRegistro;

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

        public string EliminarTipoCiberataque(TipoCiberataqueDTO tipoCiberataqueDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoCiberataqueEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoCiberataqueId", SqlDbType.Int);
                    cmd.Parameters["@TipoCiberataqueId"].Value = tipoCiberataqueDTO.TipoCiberataqueId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoCiberataqueDTO.UsuarioIngresoRegistro;

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
