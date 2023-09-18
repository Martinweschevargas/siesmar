using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class TipoServicioPublicoDAO
    {

        SqlCommand cmd = new();

        public List<TipoServicioPublicoDTO> ObtenerTipoServicioPublicos()
        {
            List<TipoServicioPublicoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_TipoServicioPublicoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new TipoServicioPublicoDTO()
                        {
                            TipoServicioPublicoId = Convert.ToInt32(dr["TipoServicioPublicoId"]),
                            DescTipoServicioPublico = dr["DescTipoServicioPublico"].ToString(),
                            CodigoTipoServicioPublico = dr["CodigoTipoServicioPublico"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarTipoServicioPublico(TipoServicioPublicoDTO tipoServicioPublicoDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoServicioPublicoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescTipoServicioPublico", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescTipoServicioPublico"].Value = tipoServicioPublicoDTO.DescTipoServicioPublico;

                    cmd.Parameters.Add("@CodigoTipoServicioPublico", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoTipoServicioPublico"].Value = tipoServicioPublicoDTO.CodigoTipoServicioPublico;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoServicioPublicoDTO.UsuarioIngresoRegistro;

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

        public TipoServicioPublicoDTO BuscarTipoServicioPublicoID(int Codigo)
        {
            TipoServicioPublicoDTO tipoServicioPublicoDTO = new TipoServicioPublicoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoServicioPublicoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoServicioPublicoId", SqlDbType.Int);
                    cmd.Parameters["@TipoServicioPublicoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        tipoServicioPublicoDTO.TipoServicioPublicoId = Convert.ToInt32(dr["TipoServicioPublicoId"]);
                        tipoServicioPublicoDTO.DescTipoServicioPublico = dr["DescTipoServicioPublico"].ToString();
                        tipoServicioPublicoDTO.CodigoTipoServicioPublico = dr["CodigoTipoServicioPublico"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return tipoServicioPublicoDTO;
        }

        public string ActualizarTipoServicioPublico(TipoServicioPublicoDTO tipoServicioPublicoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_TipoServicioPublicoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoServicioPublicoId", SqlDbType.Int);
                    cmd.Parameters["@TipoServicioPublicoId"].Value = tipoServicioPublicoDTO.TipoServicioPublicoId;

                    cmd.Parameters.Add("@DescTipoServicioPublico", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescTipoServicioPublico"].Value = tipoServicioPublicoDTO.DescTipoServicioPublico;

                    cmd.Parameters.Add("@CodigoTipoServicioPublico", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoTipoServicioPublico"].Value = tipoServicioPublicoDTO.CodigoTipoServicioPublico;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoServicioPublicoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarTipoServicioPublico(TipoServicioPublicoDTO tipoServicioPublicoDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoServicioPublicoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoServicioPublicoId", SqlDbType.Int);
                    cmd.Parameters["@TipoServicioPublicoId"].Value = tipoServicioPublicoDTO.TipoServicioPublicoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoServicioPublicoDTO.UsuarioIngresoRegistro;

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
