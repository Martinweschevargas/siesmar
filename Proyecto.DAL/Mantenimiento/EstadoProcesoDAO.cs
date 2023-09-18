using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class EstadoProcesoDAO
    {

        SqlCommand cmd = new();

        public List<EstadoProcesoDTO> ObtenerEstadoProcesos()
        {
            List<EstadoProcesoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_EstadoProcesoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new EstadoProcesoDTO()
                        {
                            EstadoProcesoId = Convert.ToInt32(dr["EstadoProcesoId"]),
                            DescEstadoProceso = dr["DescEstadoProceso"].ToString(),
                            CodigoEstadoProceso = dr["CodigoEstadoProceso"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarEstadoProceso(EstadoProcesoDTO EstadoProcesoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EstadoProcesoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescEstadoProceso", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescEstadoProceso"].Value = EstadoProcesoDTO.DescEstadoProceso;

                    cmd.Parameters.Add("@CodigoEstadoProceso", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoEstadoProceso"].Value = EstadoProcesoDTO.CodigoEstadoProceso;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = EstadoProcesoDTO.UsuarioIngresoRegistro;

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

        public EstadoProcesoDTO BuscarEstadoProcesoID(int Codigo)
        {
            EstadoProcesoDTO EstadoProcesoDTO = new EstadoProcesoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EstadoProcesoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EstadoProcesoId", SqlDbType.Int);
                    cmd.Parameters["@EstadoProcesoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        EstadoProcesoDTO.EstadoProcesoId = Convert.ToInt32(dr["EstadoProcesoId"]);
                        EstadoProcesoDTO.DescEstadoProceso = dr["DescEstadoProceso"].ToString();
                        EstadoProcesoDTO.CodigoEstadoProceso = dr["CodigoEstadoProceso"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return EstadoProcesoDTO;
        }

        public string ActualizarEstadoProceso(EstadoProcesoDTO EstadoProcesoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EstadoProcesoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EstadoProcesoId", SqlDbType.Int);
                    cmd.Parameters["@EstadoProcesoId"].Value = EstadoProcesoDTO.EstadoProcesoId;

                    cmd.Parameters.Add("@DescEstadoProceso", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescEstadoProceso"].Value = EstadoProcesoDTO.DescEstadoProceso;

                    cmd.Parameters.Add("@CodigoEstadoProceso", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoEstadoProceso"].Value = EstadoProcesoDTO.CodigoEstadoProceso;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = EstadoProcesoDTO.UsuarioIngresoRegistro;

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

        public string EliminarEstadoProceso(EstadoProcesoDTO EstadoProcesoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EstadoProcesoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EstadoProcesoId", SqlDbType.Int);
                    cmd.Parameters["@EstadoProcesoId"].Value = EstadoProcesoDTO.EstadoProcesoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = EstadoProcesoDTO.UsuarioIngresoRegistro;

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