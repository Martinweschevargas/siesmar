using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class TipoApoyoSocialDAO
    {

        SqlCommand cmd = new();

        public List<TipoApoyoSocialDTO> ObtenerTipoApoyoSocials()
        {
            List<TipoApoyoSocialDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_TipoApoyoSocialListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new TipoApoyoSocialDTO()
                        {
                            TipoApoyoSocialId = Convert.ToInt32(dr["TipoApoyoSocialId"]),
                            DescTipoApoyoSocial = dr["DescTipoApoyoSocial"].ToString(),
                            CodigoTipoApoyoSocial = dr["CodigoTipoApoyoSocial"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarTipoApoyoSocial(TipoApoyoSocialDTO tipoApoyoSocialDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoApoyoSocialRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescTipoApoyoSocial", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescTipoApoyoSocial"].Value = tipoApoyoSocialDTO.DescTipoApoyoSocial;

                    cmd.Parameters.Add("@CodigoTipoApoyoSocial", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoTipoApoyoSocial"].Value = tipoApoyoSocialDTO.CodigoTipoApoyoSocial;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoApoyoSocialDTO.UsuarioIngresoRegistro;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Mac"].Value = UtilitariosGlobales.obtenerDireccionMac();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        dr.Read();
                        if (dr.HasRows)
                        {
#pragma warning disable CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
                            IND_OPERACION = dr["IND_OPERACION"].ToString();
#pragma warning restore CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
                        }
                    }
                }
                catch (Exception ex)
                {
                    IND_OPERACION = ex.Message;
                }
            }
#pragma warning disable CS8603 // Posible tipo de valor devuelto de referencia nulo
            return IND_OPERACION;
#pragma warning restore CS8603 // Posible tipo de valor devuelto de referencia nulo
        }

        public TipoApoyoSocialDTO BuscarTipoApoyoSocialID(int Codigo)
        {
            TipoApoyoSocialDTO tipoApoyoSocialDTO = new TipoApoyoSocialDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoApoyoSocialEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoApoyoSocialId", SqlDbType.Int);
                    cmd.Parameters["@TipoApoyoSocialId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        tipoApoyoSocialDTO.TipoApoyoSocialId = Convert.ToInt32(dr["TipoApoyoSocialId"]);
                        tipoApoyoSocialDTO.DescTipoApoyoSocial = dr["DescTipoApoyoSocial"].ToString();
                        tipoApoyoSocialDTO.CodigoTipoApoyoSocial = dr["CodigoTipoApoyoSocial"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return tipoApoyoSocialDTO;
        }

        public string ActualizarTipoApoyoSocial(TipoApoyoSocialDTO tipoApoyoSocialDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_TipoApoyoSocialActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoApoyoSocialId", SqlDbType.Int);
                    cmd.Parameters["@TipoApoyoSocialId"].Value = tipoApoyoSocialDTO.TipoApoyoSocialId;

                    cmd.Parameters.Add("@DescTipoApoyoSocial", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescTipoApoyoSocial"].Value = tipoApoyoSocialDTO.DescTipoApoyoSocial;

                    cmd.Parameters.Add("@CodigoTipoApoyoSocial", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoTipoApoyoSocial"].Value = tipoApoyoSocialDTO.CodigoTipoApoyoSocial;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoApoyoSocialDTO.UsuarioIngresoRegistro;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Mac"].Value = UtilitariosGlobales.obtenerDireccionMac();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        dr.Read();
                        if (dr.HasRows)
                        {
#pragma warning disable CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
                            IND_OPERACION = dr["IND_OPERACION"].ToString();
#pragma warning restore CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                IND_OPERACION = ex.Message;
            }
#pragma warning disable CS8603 // Posible tipo de valor devuelto de referencia nulo
            return IND_OPERACION;
#pragma warning restore CS8603 // Posible tipo de valor devuelto de referencia nulo
        }

        public bool EliminarTipoApoyoSocial(TipoApoyoSocialDTO tipoApoyoSocialDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoApoyoSocialEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoApoyoSocialId", SqlDbType.Int);
                    cmd.Parameters["@TipoApoyoSocialId"].Value = tipoApoyoSocialDTO.TipoApoyoSocialId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoApoyoSocialDTO.UsuarioIngresoRegistro;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Mac"].Value = UtilitariosGlobales.obtenerDireccionMac();
                    cmd.ExecuteNonQuery();
                    eliminado = true;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return eliminado;
        }

    }
}
