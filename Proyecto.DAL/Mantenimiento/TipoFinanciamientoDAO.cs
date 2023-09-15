using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class TipoFinanciamientoDAO
    {

        SqlCommand cmd = new();

        public List<TipoFinanciamientoDTO> ObtenerTipoFinanciamientos()
        {
            List<TipoFinanciamientoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_TipoFinanciamientoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new TipoFinanciamientoDTO()
                        {
                            TipoFinanciamientoId = Convert.ToInt32(dr["TipoFinanciamientoId"]),
                            DescTipoFinanciamiento = dr["DescTipoFinanciamiento"].ToString(),
                            CodigoTipoFinanciamiento = dr["CodigoTipoFinanciamiento"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarTipoFinanciamiento(TipoFinanciamientoDTO tipoFinanciamientoDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoFinanciamientoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescTipoFinanciamiento", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescTipoFinanciamiento"].Value = tipoFinanciamientoDTO.DescTipoFinanciamiento;

                    cmd.Parameters.Add("@CodigoTipoFinanciamiento", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoTipoFinanciamiento"].Value = tipoFinanciamientoDTO.CodigoTipoFinanciamiento;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoFinanciamientoDTO.UsuarioIngresoRegistro;

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

        public TipoFinanciamientoDTO BuscarTipoFinanciamientoID(int Codigo)
        {
            TipoFinanciamientoDTO tipoFinanciamientoDTO = new TipoFinanciamientoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoFinanciamientoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoFinanciamientoId", SqlDbType.Int);
                    cmd.Parameters["@TipoFinanciamientoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        tipoFinanciamientoDTO.TipoFinanciamientoId = Convert.ToInt32(dr["TipoFinanciamientoId"]);
                        tipoFinanciamientoDTO.DescTipoFinanciamiento = dr["DescTipoFinanciamiento"].ToString();
                        tipoFinanciamientoDTO.CodigoTipoFinanciamiento = dr["CodigoTipoFinanciamiento"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return tipoFinanciamientoDTO;
        }

        public string ActualizarTipoFinanciamiento(TipoFinanciamientoDTO tipoFinanciamientoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_TipoFinanciamientoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoFinanciamientoId", SqlDbType.Int);
                    cmd.Parameters["@TipoFinanciamientoId"].Value = tipoFinanciamientoDTO.TipoFinanciamientoId;

                    cmd.Parameters.Add("@DescTipoFinanciamiento", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescTipoFinanciamiento"].Value = tipoFinanciamientoDTO.DescTipoFinanciamiento;

                    cmd.Parameters.Add("@CodigoTipoFinanciamiento", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoTipoFinanciamiento"].Value = tipoFinanciamientoDTO.CodigoTipoFinanciamiento;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoFinanciamientoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarTipoFinanciamiento(TipoFinanciamientoDTO tipoFinanciamientoDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoFinanciamientoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoFinanciamientoId", SqlDbType.Int);
                    cmd.Parameters["@TipoFinanciamientoId"].Value = tipoFinanciamientoDTO.TipoFinanciamientoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoFinanciamientoDTO.UsuarioIngresoRegistro;

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
