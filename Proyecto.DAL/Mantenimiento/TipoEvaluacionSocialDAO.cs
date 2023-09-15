using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class TipoEvaluacionSocialDAO
    {

        SqlCommand cmd = new();

        public List<TipoEvaluacionSocialDTO> ObtenerTipoEvaluacionSocials()
        {
            List<TipoEvaluacionSocialDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_TipoEvaluacionSocialListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new TipoEvaluacionSocialDTO()
                        {
                            TipoEvaluacionSocialId = Convert.ToInt32(dr["TipoEvaluacionSocialId"]),
                            DescTipoEvaluacionSocial = dr["DescTipoEvaluacionSocial"].ToString(),
                            CodigoTipoEvaluacionSocial = dr["CodigoTipoEvaluacionSocial"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarTipoEvaluacionSocial(TipoEvaluacionSocialDTO tipoEvaluacionSocialDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoEvaluacionSocialRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescTipoEvaluacionSocial", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescTipoEvaluacionSocial"].Value = tipoEvaluacionSocialDTO.DescTipoEvaluacionSocial;

                    cmd.Parameters.Add("@CodigoTipoEvaluacionSocial", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoTipoEvaluacionSocial"].Value = tipoEvaluacionSocialDTO.CodigoTipoEvaluacionSocial;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoEvaluacionSocialDTO.UsuarioIngresoRegistro;

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

        public TipoEvaluacionSocialDTO BuscarTipoEvaluacionSocialID(int Codigo)
        {
            TipoEvaluacionSocialDTO tipoEvaluacionSocialDTO = new TipoEvaluacionSocialDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoEvaluacionSocialEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoEvaluacionSocialId", SqlDbType.Int);
                    cmd.Parameters["@TipoEvaluacionSocialId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        tipoEvaluacionSocialDTO.TipoEvaluacionSocialId = Convert.ToInt32(dr["TipoEvaluacionSocialId"]);
                        tipoEvaluacionSocialDTO.DescTipoEvaluacionSocial = dr["DescTipoEvaluacionSocial"].ToString();
                        tipoEvaluacionSocialDTO.CodigoTipoEvaluacionSocial = dr["CodigoTipoEvaluacionSocial"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return tipoEvaluacionSocialDTO;
        }

        public string ActualizarTipoEvaluacionSocial(TipoEvaluacionSocialDTO tipoEvaluacionSocialDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_TipoEvaluacionSocialActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoEvaluacionSocialId", SqlDbType.Int);
                    cmd.Parameters["@TipoEvaluacionSocialId"].Value = tipoEvaluacionSocialDTO.TipoEvaluacionSocialId;

                    cmd.Parameters.Add("@DescTipoEvaluacionSocial", SqlDbType.VarChar, 80);
                    cmd.Parameters["@DescTipoEvaluacionSocial"].Value = tipoEvaluacionSocialDTO.DescTipoEvaluacionSocial;

                    cmd.Parameters.Add("@CodigoTipoEvaluacionSocial", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoTipoEvaluacionSocial"].Value = tipoEvaluacionSocialDTO.CodigoTipoEvaluacionSocial;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoEvaluacionSocialDTO.UsuarioIngresoRegistro;

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

        public bool EliminarTipoEvaluacionSocial(TipoEvaluacionSocialDTO tipoEvaluacionSocialDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoEvaluacionSocialEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoEvaluacionSocialId", SqlDbType.Int);
                    cmd.Parameters["@TipoEvaluacionSocialId"].Value = tipoEvaluacionSocialDTO.TipoEvaluacionSocialId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoEvaluacionSocialDTO.UsuarioIngresoRegistro;

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
