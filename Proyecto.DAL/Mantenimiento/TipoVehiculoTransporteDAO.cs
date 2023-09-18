using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class TipoVehiculoTransporteDAO
    {

        SqlCommand cmd = new();

        public List<TipoVehiculoTransporteDTO> ObtenerTipoVehiculoTransportes()
        {
            List<TipoVehiculoTransporteDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_TipoVehiculoTransporteListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new TipoVehiculoTransporteDTO()
                        {
                            TipoVehiculoTransporteId = Convert.ToInt32(dr["TipoVehiculoTransporteId"]),
                            DescTipoVehiculoTransporte = dr["DescTipoVehiculoTransporte"].ToString(),
                            CodigoTipoVehiculoTransporte = dr["CodigoTipoVehiculoTransporte"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarTipoVehiculoTransporte(TipoVehiculoTransporteDTO tipoVehiculoTransporteDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoVehiculoTransporteRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescTipoVehiculoTransporte", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescTipoVehiculoTransporte"].Value = tipoVehiculoTransporteDTO.DescTipoVehiculoTransporte;

                    cmd.Parameters.Add("@CodigoTipoVehiculoTransporte", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoTipoVehiculoTransporte"].Value = tipoVehiculoTransporteDTO.CodigoTipoVehiculoTransporte;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoVehiculoTransporteDTO.UsuarioIngresoRegistro;

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

        public TipoVehiculoTransporteDTO BuscarTipoVehiculoTransporteID(int Codigo)
        {
            TipoVehiculoTransporteDTO tipoVehiculoTransporteDTO = new TipoVehiculoTransporteDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoVehiculoTransporteEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoVehiculoTransporteId", SqlDbType.Int);
                    cmd.Parameters["@TipoVehiculoTransporteId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        tipoVehiculoTransporteDTO.TipoVehiculoTransporteId = Convert.ToInt32(dr["TipoVehiculoTransporteId"]);
                        tipoVehiculoTransporteDTO.DescTipoVehiculoTransporte = dr["DescTipoVehiculoTransporte"].ToString();
                        tipoVehiculoTransporteDTO.CodigoTipoVehiculoTransporte = dr["CodigoTipoVehiculoTransporte"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return tipoVehiculoTransporteDTO;
        }

        public string ActualizarTipoVehiculoTransporte(TipoVehiculoTransporteDTO tipoVehiculoTransporteDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_TipoVehiculoTransporteActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoVehiculoTransporteId", SqlDbType.Int);
                    cmd.Parameters["@TipoVehiculoTransporteId"].Value = tipoVehiculoTransporteDTO.TipoVehiculoTransporteId;

                    cmd.Parameters.Add("@DescTipoVehiculoTransporte", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescTipoVehiculoTransporte"].Value = tipoVehiculoTransporteDTO.DescTipoVehiculoTransporte;

                    cmd.Parameters.Add("@CodigoTipoVehiculoTransporte", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoTipoVehiculoTransporte"].Value = tipoVehiculoTransporteDTO.CodigoTipoVehiculoTransporte;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoVehiculoTransporteDTO.UsuarioIngresoRegistro;

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

        public string EliminarTipoVehiculoTransporte(TipoVehiculoTransporteDTO tipoVehiculoTransporteDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoVehiculoTransporteEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoVehiculoTransporteId", SqlDbType.Int);
                    cmd.Parameters["@TipoVehiculoTransporteId"].Value = tipoVehiculoTransporteDTO.TipoVehiculoTransporteId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoVehiculoTransporteDTO.UsuarioIngresoRegistro;

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
