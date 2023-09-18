using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class ResultadoInvestigacionDAO
    {

        SqlCommand cmd = new();

        public List<ResultadoInvestigacionDTO> ObtenerResultadoInvestigacions()
        {
            List<ResultadoInvestigacionDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_ResultadoInvestigacionListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ResultadoInvestigacionDTO()
                        {
                            ResultadoInvestigacionId = Convert.ToInt32(dr["ResultadoInvestigacionId"]),
                            DescResultadoInvestigacion = dr["DescResultadoInvestigacion"].ToString(),
                            CodigoResultadoInvestigacion = dr["CodigoResultadoInvestigacion"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarResultadoInvestigacion(ResultadoInvestigacionDTO resultadoInvestigacionDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ResultadoInvestigacionRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescResultadoInvestigacion", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescResultadoInvestigacion"].Value = resultadoInvestigacionDTO.DescResultadoInvestigacion;

                    cmd.Parameters.Add("@CodigoResultadoInvestigacion", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoResultadoInvestigacion"].Value = resultadoInvestigacionDTO.CodigoResultadoInvestigacion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = resultadoInvestigacionDTO.UsuarioIngresoRegistro;

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

        public ResultadoInvestigacionDTO BuscarResultadoInvestigacionID(int Codigo)
        {
            ResultadoInvestigacionDTO resultadoInvestigacionDTO = new ResultadoInvestigacionDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ResultadoInvestigacionEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ResultadoInvestigacionId", SqlDbType.Int);
                    cmd.Parameters["@ResultadoInvestigacionId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        resultadoInvestigacionDTO.ResultadoInvestigacionId = Convert.ToInt32(dr["ResultadoInvestigacionId"]);
                        resultadoInvestigacionDTO.DescResultadoInvestigacion = dr["DescResultadoInvestigacion"].ToString();
                        resultadoInvestigacionDTO.CodigoResultadoInvestigacion = dr["CodigoResultadoInvestigacion"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return resultadoInvestigacionDTO;
        }

        public string ActualizarResultadoInvestigacion(ResultadoInvestigacionDTO resultadoInvestigacionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ResultadoInvestigacionActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ResultadoInvestigacionId", SqlDbType.Int);
                    cmd.Parameters["@ResultadoInvestigacionId"].Value = resultadoInvestigacionDTO.ResultadoInvestigacionId;

                    cmd.Parameters.Add("@DescResultadoInvestigacion", SqlDbType.VarChar, 80);
                    cmd.Parameters["@DescResultadoInvestigacion"].Value = resultadoInvestigacionDTO.DescResultadoInvestigacion;

                    cmd.Parameters.Add("@CodigoResultadoInvestigacion", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoResultadoInvestigacion"].Value = resultadoInvestigacionDTO.CodigoResultadoInvestigacion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = resultadoInvestigacionDTO.UsuarioIngresoRegistro;

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

        public string EliminarResultadoInvestigacion(ResultadoInvestigacionDTO resultadoInvestigacionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ResultadoInvestigacionEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ResultadoInvestigacionId", SqlDbType.Int);
                    cmd.Parameters["@ResultadoInvestigacionId"].Value = resultadoInvestigacionDTO.ResultadoInvestigacionId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = resultadoInvestigacionDTO.UsuarioIngresoRegistro;

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
