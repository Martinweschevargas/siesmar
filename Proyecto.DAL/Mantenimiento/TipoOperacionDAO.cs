using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class TipoOperacionDAO
    {

        SqlCommand cmd = new();

        public List<TipoOperacionDTO> ObtenerTipoOperacions()
        {
            List<TipoOperacionDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_TipoOperacionListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new TipoOperacionDTO()
                        {
                            TipoOperacionId = Convert.ToInt32(dr["TipoOperacionId"]),
                            DescTipoOperacion = dr["DescTipoOperacion"].ToString(),
                            Operacion = dr["Operacion"].ToString(),
                            CodigoTipoOperacion = dr["CodigoTipoOperacion"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarTipoOperacion(TipoOperacionDTO tipoOperacionDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoOperacionRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescTipoOperacion", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescTipoOperacion"].Value = tipoOperacionDTO.DescTipoOperacion;

                    cmd.Parameters.Add("@Operacion", SqlDbType.VarChar, 80);
                    cmd.Parameters["@Operacion"].Value = tipoOperacionDTO.Operacion;

                    cmd.Parameters.Add("@CodigoTipoOperacion", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoTipoOperacion"].Value = tipoOperacionDTO.CodigoTipoOperacion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoOperacionDTO.UsuarioIngresoRegistro;

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

        public TipoOperacionDTO BuscarTipoOperacionID(int Codigo)
        {
            TipoOperacionDTO tipoOperacionDTO = new TipoOperacionDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoOperacionEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoOperacionId", SqlDbType.Int);
                    cmd.Parameters["@TipoOperacionId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        tipoOperacionDTO.TipoOperacionId = Convert.ToInt32(dr["TipoOperacionId"]);
                        tipoOperacionDTO.DescTipoOperacion = dr["DescTipoOperacion"].ToString();
                        tipoOperacionDTO.Operacion = dr["Operacion"].ToString();
                        tipoOperacionDTO.CodigoTipoOperacion = dr["CodigoTipoOperacion"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return tipoOperacionDTO;
        }

        public string ActualizarTipoOperacion(TipoOperacionDTO tipoOperacionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_TipoOperacionActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoOperacionId", SqlDbType.Int);
                    cmd.Parameters["@TipoOperacionId"].Value = tipoOperacionDTO.TipoOperacionId;

                    cmd.Parameters.Add("@DescTipoOperacion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescTipoOperacion"].Value = tipoOperacionDTO.DescTipoOperacion;

                    cmd.Parameters.Add("@Operacion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Operacion"].Value = tipoOperacionDTO.Operacion;

                    cmd.Parameters.Add("@CodigoTipoOperacion", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoTipoOperacion"].Value = tipoOperacionDTO.CodigoTipoOperacion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoOperacionDTO.UsuarioIngresoRegistro;

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

        public string EliminarTipoOperacion(TipoOperacionDTO tipoOperacionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoOperacionEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoOperacionId", SqlDbType.Int);
                    cmd.Parameters["@TipoOperacionId"].Value = tipoOperacionDTO.TipoOperacionId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoOperacionDTO.UsuarioIngresoRegistro;

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
