using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class EstadoFase1FormEvalDAO
    {

        SqlCommand cmd = new();

        public List<EstadoFase1FormEvalDTO> ObtenerEstadoFase1FormEvals()
        {
            List<EstadoFase1FormEvalDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_EstadoFase1FormEvalListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new EstadoFase1FormEvalDTO()
                        {
                            EstadoFase1FormEvalId = Convert.ToInt32(dr["EstadoFase1FormEvalId"]),
                            DescEstadoFase1FormEval = dr["DescEstadoFase1FormEval"].ToString(),
                            CodigoEstadoFase1FormEval = dr["CodigoEstadoFase1FormEval"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarEstadoFase1FormEval(EstadoFase1FormEvalDTO estadoFase1FormEvalDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EstadoFase1FormEvalRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescEstadoFase1FormEval", SqlDbType.VarChar, 50);                    
                    cmd.Parameters["@DescEstadoFase1FormEval"].Value = estadoFase1FormEvalDTO.DescEstadoFase1FormEval;

                    cmd.Parameters.Add("@CodigoEstadoFase1FormEval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEstadoFase1FormEval"].Value = estadoFase1FormEvalDTO.CodigoEstadoFase1FormEval;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = estadoFase1FormEvalDTO.UsuarioIngresoRegistro;

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
            return IND_OPERACION;
        }

        public EstadoFase1FormEvalDTO BuscarEstadoFase1FormEvalID(int Codigo)
        {
            EstadoFase1FormEvalDTO estadoFase1FormEvalDTO = new EstadoFase1FormEvalDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EstadoFase1FormEvalEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EstadoFase1FormEvalId", SqlDbType.Int);
                    cmd.Parameters["@EstadoFase1FormEvalId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        estadoFase1FormEvalDTO.EstadoFase1FormEvalId = Convert.ToInt32(dr["EstadoFase1FormEvalId"]);
                        estadoFase1FormEvalDTO.DescEstadoFase1FormEval = dr["DescEstadoFase1FormEval"].ToString();
                        estadoFase1FormEvalDTO.CodigoEstadoFase1FormEval = dr["CodigoEstadoFase1FormEval"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return estadoFase1FormEvalDTO;
        }

        public string ActualizarEstadoFase1FormEval(EstadoFase1FormEvalDTO estadoFase1FormEvalDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_EstadoFase1FormEvalActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EstadoFase1FormEvalId", SqlDbType.Int);
                    cmd.Parameters["@EstadoFase1FormEvalId"].Value = estadoFase1FormEvalDTO.EstadoFase1FormEvalId;

                    cmd.Parameters.Add("@DescEstadoFase1FormEval", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescEstadoFase1FormEval"].Value = estadoFase1FormEvalDTO.DescEstadoFase1FormEval;

                    cmd.Parameters.Add("@CodigoEstadoFase1FormEval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEstadoFase1FormEval"].Value = estadoFase1FormEvalDTO.CodigoEstadoFase1FormEval;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = estadoFase1FormEvalDTO.UsuarioIngresoRegistro;

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

        public bool EliminarEstadoFase1FormEval(EstadoFase1FormEvalDTO estadoFase1FormEvalDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EstadoFase1FormEvalEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EstadoFase1FormEvalId", SqlDbType.Int);
                    cmd.Parameters["@EstadoFase1FormEvalId"].Value = estadoFase1FormEvalDTO.EstadoFase1FormEvalId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = estadoFase1FormEvalDTO.UsuarioIngresoRegistro;

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
