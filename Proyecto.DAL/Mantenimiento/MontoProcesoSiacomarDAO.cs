using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class MontoProcesoSiacomarDAO
    {

        SqlCommand cmd = new();

        public List<MontoProcesoSiacomarDTO> ObtenerMontoProcesoSiacomars()
        {
            List<MontoProcesoSiacomarDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_MontoProcesoSiacomarListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new MontoProcesoSiacomarDTO()
                        {
                            MontoProcesoSiacomarId = Convert.ToInt32(dr["MontoProcesoSiacomarId"]),
                            DescMontoProcesoSiacomar = dr["DescMontoProcesoSiacomar"].ToString(),
                            CodigoMontoProcesoSiacomar = dr["CodigoMontoProcesoSiacomar"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarMontoProcesoSiacomar(MontoProcesoSiacomarDTO montoProcesoSiacomarDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_MontoProcesoSiacomarRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescMontoProcesoSiacomar", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescMontoProcesoSiacomar"].Value = montoProcesoSiacomarDTO.DescMontoProcesoSiacomar;

                    cmd.Parameters.Add("@CodigoMontoProcesoSiacomar", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoMontoProcesoSiacomar"].Value = montoProcesoSiacomarDTO.CodigoMontoProcesoSiacomar;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = montoProcesoSiacomarDTO.UsuarioIngresoRegistro;

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
#pragma warning disable CS8603 // Posible tipo de valor devuelto de referencia nulo
            return IND_OPERACION;
#pragma warning restore CS8603 // Posible tipo de valor devuelto de referencia nulo
        }

        public MontoProcesoSiacomarDTO BuscarMontoProcesoSiacomarID(int Codigo)
        {
            MontoProcesoSiacomarDTO montoProcesoSiacomarDTO = new MontoProcesoSiacomarDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_MontoProcesoSiacomarEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MontoProcesoSiacomarId", SqlDbType.Int);
                    cmd.Parameters["@MontoProcesoSiacomarId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        montoProcesoSiacomarDTO.MontoProcesoSiacomarId = Convert.ToInt32(dr["MontoProcesoSiacomarId"]);
                        montoProcesoSiacomarDTO.DescMontoProcesoSiacomar = dr["DescMontoProcesoSiacomar"].ToString();
                        montoProcesoSiacomarDTO.CodigoMontoProcesoSiacomar = dr["CodigoMontoProcesoSiacomar"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return montoProcesoSiacomarDTO;
        }

        public string ActualizarMontoProcesoSiacomar(MontoProcesoSiacomarDTO montoProcesoSiacomarDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_MontoProcesoSiacomarActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MontoProcesoSiacomarId", SqlDbType.Int);
                    cmd.Parameters["@MontoProcesoSiacomarId"].Value = montoProcesoSiacomarDTO.MontoProcesoSiacomarId;

                    cmd.Parameters.Add("@DescMontoProcesoSiacomar", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescMontoProcesoSiacomar"].Value = montoProcesoSiacomarDTO.DescMontoProcesoSiacomar;

                    cmd.Parameters.Add("@CodigoMontoProcesoSiacomar", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoMontoProcesoSiacomar"].Value = montoProcesoSiacomarDTO.CodigoMontoProcesoSiacomar;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = montoProcesoSiacomarDTO.UsuarioIngresoRegistro;

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

        public bool EliminarMontoProcesoSiacomar(int Codigo)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_MontoProcesoSiacomarEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MontoProcesoSiacomarId", SqlDbType.Int);
                    cmd.Parameters["@MontoProcesoSiacomarId"].Value = Codigo;
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
