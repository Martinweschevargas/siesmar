using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class TipoComunicacionDirtelDAO
    {

        SqlCommand cmd = new();

        public List<TipoComunicacionDirtelDTO> ObtenerTipoComunicacionDirtels()
        {
            List<TipoComunicacionDirtelDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_TipoComunicacionDirtelListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new TipoComunicacionDirtelDTO()
                        {
                            TipoComunicacionDirtelId = Convert.ToInt32(dr["TipoComunicacionDirtelId"]),
                            DescTipoComunicacionDirtel = dr["DescTipoComunicacionDirtel"].ToString(),
                            CodigoTipoComunicacionDirtel = dr["CodigoTipoComunicacionDirtel"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarTipoComunicacionDirtel(TipoComunicacionDirtelDTO tipoComunicacionDirtelDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoComunicacionDirtelRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescTipoComunicacionDirtel", SqlDbType.VarChar, 100);                    
                    cmd.Parameters["@DescTipoComunicacionDirtel"].Value = tipoComunicacionDirtelDTO.DescTipoComunicacionDirtel;

                    cmd.Parameters.Add("@CodigoTipoComunicacionDirtel", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoComunicacionDirtel"].Value = tipoComunicacionDirtelDTO.CodigoTipoComunicacionDirtel;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoComunicacionDirtelDTO.UsuarioIngresoRegistro;

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

        public TipoComunicacionDirtelDTO BuscarTipoComunicacionDirtelID(int Codigo)
        {
            TipoComunicacionDirtelDTO tipoComunicacionDirtelDTO = new TipoComunicacionDirtelDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoComunicacionDirtelEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoComunicacionDirtelId", SqlDbType.Int);
                    cmd.Parameters["@TipoComunicacionDirtelId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        tipoComunicacionDirtelDTO.TipoComunicacionDirtelId = Convert.ToInt32(dr["TipoComunicacionDirtelId"]);
                        tipoComunicacionDirtelDTO.DescTipoComunicacionDirtel = dr["DescTipoComunicacionDirtel"].ToString();
                        tipoComunicacionDirtelDTO.CodigoTipoComunicacionDirtel = dr["CodigoTipoComunicacionDirtel"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return tipoComunicacionDirtelDTO;
        }

        public string ActualizarTipoComunicacionDirtel(TipoComunicacionDirtelDTO tipoComunicacionDirtelDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoComunicacionDirtelActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoComunicacionDirtelId", SqlDbType.Int);
                    cmd.Parameters["@TipoComunicacionDirtelId"].Value = tipoComunicacionDirtelDTO.TipoComunicacionDirtelId;

                    cmd.Parameters.Add("@DescTipoComunicacionDirtel", SqlDbType.VarChar, 100);
                    cmd.Parameters["@DescTipoComunicacionDirtel"].Value = tipoComunicacionDirtelDTO.DescTipoComunicacionDirtel;

                    cmd.Parameters.Add("@CodigoTipoComunicacionDirtel", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoComunicacionDirtel"].Value = tipoComunicacionDirtelDTO.CodigoTipoComunicacionDirtel;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoComunicacionDirtelDTO.UsuarioIngresoRegistro;

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

        public string EliminarTipoComunicacionDirtel(TipoComunicacionDirtelDTO tipoComunicacionDirtelDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoComunicacionDirtelEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoComunicacionDirtelId", SqlDbType.Int);
                    cmd.Parameters["@TipoComunicacionDirtelId"].Value = tipoComunicacionDirtelDTO.TipoComunicacionDirtelId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoComunicacionDirtelDTO.UsuarioIngresoRegistro;

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
