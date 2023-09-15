using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class TipoPresenteProtocolarDAO
    {

        SqlCommand cmd = new();

        public List<TipoPresenteProtocolarDTO> ObtenerTipoPresenteProtocolars()
        {
            List<TipoPresenteProtocolarDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_TipoPresenteProtocolarListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new TipoPresenteProtocolarDTO()
                        {
                            TipoPresenteProtocolarId = Convert.ToInt32(dr["TipoPresenteProtocolarId"]),
                            DescTipoPresenteProtocolar = dr["DescTipoPresenteProtocolar"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarTipoPresenteProtocolar(TipoPresenteProtocolarDTO tipoPresenteProtocolarDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoPresenteProtocolarRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescTipoPresenteProtocolar", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescTipoPresenteProtocolar"].Value = tipoPresenteProtocolarDTO.DescTipoPresenteProtocolar;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoPresenteProtocolarDTO.UsuarioIngresoRegistro;

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

        public TipoPresenteProtocolarDTO BuscarTipoPresenteProtocolarID(int Codigo)
        {
            TipoPresenteProtocolarDTO tipoPresenteProtocolarDTO = new TipoPresenteProtocolarDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoPresenteProtocolarEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoPresenteProtocolarId", SqlDbType.Int);
                    cmd.Parameters["@TipoPresenteProtocolarId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        tipoPresenteProtocolarDTO.TipoPresenteProtocolarId = Convert.ToInt32(dr["TipoPresenteProtocolarId"]);
                        tipoPresenteProtocolarDTO.DescTipoPresenteProtocolar = dr["DescTipoPresenteProtocolar"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return tipoPresenteProtocolarDTO;
        }

        public string ActualizarTipoPresenteProtocolar(TipoPresenteProtocolarDTO tipoPresenteProtocolarDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoPresenteProtocolarActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoPresenteProtocolarId", SqlDbType.Int);
                    cmd.Parameters["@TipoPresenteProtocolarId"].Value = tipoPresenteProtocolarDTO.TipoPresenteProtocolarId;

                    cmd.Parameters.Add("@DescTipoPresenteProtocolar", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescTipoPresenteProtocolar"].Value = tipoPresenteProtocolarDTO.DescTipoPresenteProtocolar;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoPresenteProtocolarDTO.UsuarioIngresoRegistro;

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

        public string EliminarTipoPresenteProtocolar(TipoPresenteProtocolarDTO tipoPresenteProtocolarDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoPresenteProtocolarEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoPresenteProtocolarId", SqlDbType.Int);
                    cmd.Parameters["@TipoPresenteProtocolarId"].Value = tipoPresenteProtocolarDTO.TipoPresenteProtocolarId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoPresenteProtocolarDTO.UsuarioIngresoRegistro;

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
