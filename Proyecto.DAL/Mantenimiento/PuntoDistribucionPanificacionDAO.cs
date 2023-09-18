using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class PuntoDistribucionPanificacionDAO
    {

        SqlCommand cmd = new();

        public List<PuntoDistribucionPanificacionDTO> ObtenerPuntoDistribucionPanificacions()
        {
            List<PuntoDistribucionPanificacionDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_PuntosDistribucionPanificacionListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new PuntoDistribucionPanificacionDTO()
                        {
                            PuntoDistribucionPanificacionId = Convert.ToInt32(dr["PuntoDistribucionPanificacionId"]),
                            DescPuntoDistribucionPanificacion = dr["DescPuntoDistribucionPanificacion"].ToString(),
                            CodigoPuntoDistribucionPanificacion = dr["CodigoPuntoDistribucionPanificacion"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarPuntoDistribucionPanificacion(PuntoDistribucionPanificacionDTO puntoDistribucionPanificacionDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_PuntosDistribucionPanificacionRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescPuntoDistribucionPanificacion", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescPuntoDistribucionPanificacion"].Value = puntoDistribucionPanificacionDTO.DescPuntoDistribucionPanificacion;

                    cmd.Parameters.Add("@CodigoPuntoDistribucionPanificacion", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoPuntoDistribucionPanificacion"].Value = puntoDistribucionPanificacionDTO.CodigoPuntoDistribucionPanificacion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = puntoDistribucionPanificacionDTO.UsuarioIngresoRegistro;

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

        public PuntoDistribucionPanificacionDTO BuscarPuntoDistribucionPanificacionID(int Codigo)
        {
            PuntoDistribucionPanificacionDTO puntoDistribucionPanificacionDTO = new PuntoDistribucionPanificacionDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_PuntosDistribucionPanificacionEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PuntoDistribucionPanificacionId", SqlDbType.Int);
                    cmd.Parameters["@PuntoDistribucionPanificacionId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        puntoDistribucionPanificacionDTO.PuntoDistribucionPanificacionId = Convert.ToInt32(dr["PuntoDistribucionPanificacionId"]);
                        puntoDistribucionPanificacionDTO.DescPuntoDistribucionPanificacion = dr["DescPuntoDistribucionPanificacion"].ToString();
                        puntoDistribucionPanificacionDTO.CodigoPuntoDistribucionPanificacion = dr["CodigoPuntoDistribucionPanificacion"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return puntoDistribucionPanificacionDTO;
        }

        public string ActualizarPuntoDistribucionPanificacion(PuntoDistribucionPanificacionDTO puntoDistribucionPanificacionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_PuntosDistribucionPanificacionActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PuntoDistribucionPanificacionId", SqlDbType.Int);
                    cmd.Parameters["@PuntoDistribucionPanificacionId"].Value = puntoDistribucionPanificacionDTO.PuntoDistribucionPanificacionId;

                    cmd.Parameters.Add("@DescPuntoDistribucionPanificacion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescPuntoDistribucionPanificacion"].Value = puntoDistribucionPanificacionDTO.DescPuntoDistribucionPanificacion;

                    cmd.Parameters.Add("@CodigoPuntoDistribucionPanificacion", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoPuntoDistribucionPanificacion"].Value = puntoDistribucionPanificacionDTO.CodigoPuntoDistribucionPanificacion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = puntoDistribucionPanificacionDTO.UsuarioIngresoRegistro;

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

        public bool EliminarPuntoDistribucionPanificacion(PuntoDistribucionPanificacionDTO puntoDistribucionPanificacionDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_PuntosDistribucionPanificacionEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PuntoDistribucionPanificacionId", SqlDbType.Int);
                    cmd.Parameters["@PuntoDistribucionPanificacionId"].Value = puntoDistribucionPanificacionDTO.PuntoDistribucionPanificacionId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = puntoDistribucionPanificacionDTO.UsuarioIngresoRegistro;

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
