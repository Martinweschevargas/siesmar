using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class ResultadoApelacionReconsideracionDAO
    {

        SqlCommand cmd = new();

        public List<ResultadoApelacionReconsideracionDTO> ObtenerResultadoApelacionReconsideracions()
        {
            List<ResultadoApelacionReconsideracionDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_ResultadoApelacionReconsideracionListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ResultadoApelacionReconsideracionDTO()
                        {
                            ResultadoApelacionReconsideracionId = Convert.ToInt32(dr["ResultadoApelacionReconsideracionId"]),
                            DescResultadoApelacionReconsideracion = dr["DescResultadoApelacionReconsideracion"].ToString(),
                            CodigoResultadoApelacionReconsideracion = dr["CodigoResultadoApelacionReconsideracion"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarResultadoApelacionReconsideracion(ResultadoApelacionReconsideracionDTO resultadoApelacionReconsideracionDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ResultadoApelacionReconsideracionRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescResultadoApelacionReconsideracion", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescResultadoApelacionReconsideracion"].Value = resultadoApelacionReconsideracionDTO.DescResultadoApelacionReconsideracion;

                    cmd.Parameters.Add("@CodigoResultadoApelacionReconsideracion", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoResultadoApelacionReconsideracion"].Value = resultadoApelacionReconsideracionDTO.CodigoResultadoApelacionReconsideracion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = resultadoApelacionReconsideracionDTO.UsuarioIngresoRegistro;

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

        public ResultadoApelacionReconsideracionDTO BuscarResultadoApelacionReconsideracionID(int Codigo)
        {
            ResultadoApelacionReconsideracionDTO resultadoApelacionReconsideracionDTO = new ResultadoApelacionReconsideracionDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ResultadoApelacionReconsideracionEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ResultadoApelacionReconsideracionId", SqlDbType.Int);
                    cmd.Parameters["@ResultadoApelacionReconsideracionId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        resultadoApelacionReconsideracionDTO.ResultadoApelacionReconsideracionId = Convert.ToInt32(dr["ResultadoApelacionReconsideracionId"]);
                        resultadoApelacionReconsideracionDTO.DescResultadoApelacionReconsideracion = dr["DescResultadoApelacionReconsideracion"].ToString();
                        resultadoApelacionReconsideracionDTO.CodigoResultadoApelacionReconsideracion = dr["CodigoResultadoApelacionReconsideracion"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return resultadoApelacionReconsideracionDTO;
        }

        public string ActualizarResultadoApelacionReconsideracion(ResultadoApelacionReconsideracionDTO resultadoApelacionReconsideracionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ResultadoApelacionReconsideracionActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ResultadoApelacionReconsideracionId", SqlDbType.Int);
                    cmd.Parameters["@ResultadoApelacionReconsideracionId"].Value = resultadoApelacionReconsideracionDTO.ResultadoApelacionReconsideracionId;

                    cmd.Parameters.Add("@DescResultadoApelacionReconsideracion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescResultadoApelacionReconsideracion"].Value = resultadoApelacionReconsideracionDTO.DescResultadoApelacionReconsideracion;

                    cmd.Parameters.Add("@CodigoResultadoApelacionReconsideracion", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoResultadoApelacionReconsideracion"].Value = resultadoApelacionReconsideracionDTO.CodigoResultadoApelacionReconsideracion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = resultadoApelacionReconsideracionDTO.UsuarioIngresoRegistro;

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

        public string EliminarResultadoApelacionReconsideracion(ResultadoApelacionReconsideracionDTO resultadoApelacionReconsideracionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ResultadoApelacionReconsideracionEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ResultadoApelacionReconsideracionId", SqlDbType.Int);
                    cmd.Parameters["@ResultadoApelacionReconsideracionId"].Value = resultadoApelacionReconsideracionDTO.ResultadoApelacionReconsideracionId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = resultadoApelacionReconsideracionDTO.UsuarioIngresoRegistro;

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
