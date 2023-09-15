using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class MontoAdjudicadoDAO
    {

        SqlCommand cmd = new();

        public List<MontoAdjudicadoDTO> ObtenerMontoAdjudicados()
        {
            List<MontoAdjudicadoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_MontoAdjudicadoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new MontoAdjudicadoDTO()
                        {
                            MontoAdjudicadoId = Convert.ToInt32(dr["MontoAdjudicadoId"]),
                            DescMontoAdjudicado = dr["DescMontoAdjudicado"].ToString(),
                            CodigoMontoAdjudicado = dr["CodigoMontoAdjudicado"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarMontoAdjudicado(MontoAdjudicadoDTO montoAdjudicadoDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_MontoAdjudicadoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescMontoAdjudicado", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescMontoAdjudicado"].Value = montoAdjudicadoDTO.DescMontoAdjudicado;

                    cmd.Parameters.Add("@CodigoMontoAdjudicado", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoMontoAdjudicado"].Value = montoAdjudicadoDTO.CodigoMontoAdjudicado;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = montoAdjudicadoDTO.UsuarioIngresoRegistro;

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

        public MontoAdjudicadoDTO BuscarMontoAdjudicadoID(int Codigo)
        {
            MontoAdjudicadoDTO montoAdjudicadoDTO = new MontoAdjudicadoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_MontoAdjudicadoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MontoAdjudicadoId", SqlDbType.Int);
                    cmd.Parameters["@MontoAdjudicadoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        montoAdjudicadoDTO.MontoAdjudicadoId = Convert.ToInt32(dr["MontoAdjudicadoId"]);
                        montoAdjudicadoDTO.DescMontoAdjudicado = dr["DescMontoAdjudicado"].ToString();
                        montoAdjudicadoDTO.CodigoMontoAdjudicado = dr["CodigoMontoAdjudicado"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return montoAdjudicadoDTO;
        }

        public string ActualizarMontoAdjudicado(MontoAdjudicadoDTO montoAdjudicadoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_MontoAdjudicadoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MontoAdjudicadoId", SqlDbType.Int);
                    cmd.Parameters["@MontoAdjudicadoId"].Value = montoAdjudicadoDTO.MontoAdjudicadoId;

                    cmd.Parameters.Add("@DescMontoAdjudicado", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescMontoAdjudicado"].Value = montoAdjudicadoDTO.DescMontoAdjudicado;

                    cmd.Parameters.Add("@CodigoMontoAdjudicado", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoMontoAdjudicado"].Value = montoAdjudicadoDTO.CodigoMontoAdjudicado;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = montoAdjudicadoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarMontoAdjudicado(int Codigo)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_MontoAdjudicadoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MontoAdjudicadoId", SqlDbType.Int);
                    cmd.Parameters["@MontoAdjudicadoId"].Value = Codigo;
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
