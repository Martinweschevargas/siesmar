using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class EstadoFase2EjecucionDAO
    {

        SqlCommand cmd = new();

        public List<EstadoFase2EjecucionDTO> ObtenerEstadoFase2Ejecucions()
        {
            List<EstadoFase2EjecucionDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_EstadosFase2EjecucionListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new EstadoFase2EjecucionDTO()
                        {
                            EstadoFase2EjecucionId = Convert.ToInt32(dr["EstadoFase2EjecucionId"]),
                            DescEstadoFase2Ejecucion = dr["DescEstadoFase2Ejecucion"].ToString(),
                            CodigoEstadoFase2Ejecucion = dr["CodigoEstadoFase2Ejecucion"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarEstadoFase2Ejecucion(EstadoFase2EjecucionDTO estadoFase2EjecucionDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EstadosFase2EjecucionRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescEstadoFase2Ejecucion", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescEstadoFase2Ejecucion"].Value = estadoFase2EjecucionDTO.DescEstadoFase2Ejecucion;

                    cmd.Parameters.Add("@CodigoEstadoFase2Ejecucion", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoEstadoFase2Ejecucion"].Value = estadoFase2EjecucionDTO.CodigoEstadoFase2Ejecucion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = estadoFase2EjecucionDTO.UsuarioIngresoRegistro;

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

        public EstadoFase2EjecucionDTO BuscarEstadoFase2EjecucionID(int Codigo)
        {
            EstadoFase2EjecucionDTO estadoFase2EjecucionDTO = new EstadoFase2EjecucionDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EstadosFase2EjecucionEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EstadoFase2EjecucionId", SqlDbType.Int);
                    cmd.Parameters["@EstadoFase2EjecucionId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        estadoFase2EjecucionDTO.EstadoFase2EjecucionId = Convert.ToInt32(dr["EstadoFase2EjecucionId"]);
                        estadoFase2EjecucionDTO.DescEstadoFase2Ejecucion = dr["DescEstadoFase2Ejecucion"].ToString();
                        estadoFase2EjecucionDTO.CodigoEstadoFase2Ejecucion = dr["CodigoEstadoFase2Ejecucion"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return estadoFase2EjecucionDTO;
        }

        public string ActualizarEstadoFase2Ejecucion(EstadoFase2EjecucionDTO estadoFase2EjecucionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_EstadosFase2EjecucionActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EstadoFase2EjecucionId", SqlDbType.Int);
                    cmd.Parameters["@EstadoFase2EjecucionId"].Value = estadoFase2EjecucionDTO.EstadoFase2EjecucionId;

                    cmd.Parameters.Add("@DescEstadoFase2Ejecucion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescEstadoFase2Ejecucion"].Value = estadoFase2EjecucionDTO.DescEstadoFase2Ejecucion;

                    cmd.Parameters.Add("@CodigoEstadoFase2Ejecucion", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoEstadoFase2Ejecucion"].Value = estadoFase2EjecucionDTO.CodigoEstadoFase2Ejecucion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = estadoFase2EjecucionDTO.UsuarioIngresoRegistro;

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

        public bool EliminarEstadoFase2Ejecucion(EstadoFase2EjecucionDTO estadoFase2EjecucionDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EstadosFase2EjecucionEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EstadoFase2EjecucionId", SqlDbType.Int);
                    cmd.Parameters["@EstadoFase2EjecucionId"].Value = estadoFase2EjecucionDTO.EstadoFase2EjecucionId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = estadoFase2EjecucionDTO.UsuarioIngresoRegistro;

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
