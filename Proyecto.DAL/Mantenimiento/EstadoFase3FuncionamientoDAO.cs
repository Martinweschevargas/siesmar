using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class EstadoFase3FuncionamientoDAO
    {

        SqlCommand cmd = new();

        public List<EstadoFase3FuncionamientoDTO> ObtenerEstadoFase3Funcionamientos()
        {
            List<EstadoFase3FuncionamientoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_EstadoFase3FuncionamientoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new EstadoFase3FuncionamientoDTO()
                        {
                            EstadoFase3FuncionamientoId = Convert.ToInt32(dr["EstadoFase3FuncionamientoId"]),
                            DescEstadoFase3Funcionamiento = dr["DescEstadoFase3Funcionamiento"].ToString(),
                            CodigoEstadoFase3Funcionamiento = dr["CodigoEstadoFase3Funcionamiento"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarEstadoFase3Funcionamiento(EstadoFase3FuncionamientoDTO estadoFase3FuncionamientoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EstadoFase3FuncionamientoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescEstadoFase3Funcionamiento", SqlDbType.VarChar, 260);
                    cmd.Parameters["@DescEstadoFase3Funcionamiento"].Value = estadoFase3FuncionamientoDTO.DescEstadoFase3Funcionamiento;

                    cmd.Parameters.Add("@CodigoEstadoFase3Funcionamiento", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoEstadoFase3Funcionamiento"].Value = estadoFase3FuncionamientoDTO.CodigoEstadoFase3Funcionamiento;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = estadoFase3FuncionamientoDTO.UsuarioIngresoRegistro;

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

        public EstadoFase3FuncionamientoDTO BuscarEstadoFase3FuncionamientoID(int Codigo)
        {
            EstadoFase3FuncionamientoDTO estadoFase3FuncionamientoDTO = new EstadoFase3FuncionamientoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EstadoFase3FuncionamientoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EstadoFase3FuncionamientoId", SqlDbType.Int);
                    cmd.Parameters["@EstadoFase3FuncionamientoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        estadoFase3FuncionamientoDTO.EstadoFase3FuncionamientoId = Convert.ToInt32(dr["EstadoFase3FuncionamientoId"]);
                        estadoFase3FuncionamientoDTO.DescEstadoFase3Funcionamiento = dr["DescEstadoFase3Funcionamiento"].ToString();
                        estadoFase3FuncionamientoDTO.CodigoEstadoFase3Funcionamiento = dr["CodigoEstadoFase3Funcionamiento"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return estadoFase3FuncionamientoDTO;
        }

        public string ActualizarEstadoFase3Funcionamiento(EstadoFase3FuncionamientoDTO estadoFase3FuncionamientoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EstadoFase3FuncionamientoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EstadoFase3FuncionamientoId", SqlDbType.Int);
                    cmd.Parameters["@EstadoFase3FuncionamientoId"].Value = estadoFase3FuncionamientoDTO.EstadoFase3FuncionamientoId;

                    cmd.Parameters.Add("@DescEstadoFase3Funcionamiento", SqlDbType.VarChar, 260);
                    cmd.Parameters["@DescEstadoFase3Funcionamiento"].Value = estadoFase3FuncionamientoDTO.DescEstadoFase3Funcionamiento;

                    cmd.Parameters.Add("@CodigoEstadoFase3Funcionamiento", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoEstadoFase3Funcionamiento"].Value = estadoFase3FuncionamientoDTO.CodigoEstadoFase3Funcionamiento;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = estadoFase3FuncionamientoDTO.UsuarioIngresoRegistro;

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

        public string EliminarEstadoFase3Funcionamiento(EstadoFase3FuncionamientoDTO estadoFase3FuncionamientoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EstadoFase3FuncionamientoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EstadoFase3FuncionamientoId", SqlDbType.Int);
                    cmd.Parameters["@EstadoFase3FuncionamientoId"].Value = estadoFase3FuncionamientoDTO.EstadoFase3FuncionamientoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = estadoFase3FuncionamientoDTO.UsuarioIngresoRegistro;

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
