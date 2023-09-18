using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class ResultadoTerminoSemestreDAO
    {

        SqlCommand cmd = new();

        public List<ResultadoTerminoSemestreDTO> ObtenerResultadoTerminoSemestres()
        {
            List<ResultadoTerminoSemestreDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_ResultadoTerminoSemestreListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ResultadoTerminoSemestreDTO()
                        {
                            ResultadoTerminoSemestreId = Convert.ToInt32(dr["ResultadoTerminoSemestreId"]),
                            DescResultadoTerminoSemestre = dr["DescResultadoTerminoSemestre"].ToString(),
                            CodigoResultadoTerminoSemestre = dr["CodigoResultadoTerminoSemestre"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarResultadoTerminoSemestre(ResultadoTerminoSemestreDTO resultadoTerminoSemestreDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ResultadoTerminoSemestreRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescResultadoTerminoSemestre", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescResultadoTerminoSemestre"].Value = resultadoTerminoSemestreDTO.DescResultadoTerminoSemestre;

                    cmd.Parameters.Add("@CodigoResultadoTerminoSemestre", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoResultadoTerminoSemestre"].Value = resultadoTerminoSemestreDTO.CodigoResultadoTerminoSemestre;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = resultadoTerminoSemestreDTO.UsuarioIngresoRegistro;

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

        public ResultadoTerminoSemestreDTO BuscarResultadoTerminoSemestreID(int Codigo)
        {
            ResultadoTerminoSemestreDTO resultadoTerminoSemestreDTO = new ResultadoTerminoSemestreDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ResultadoTerminoSemestreEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ResultadoTerminoSemestreId", SqlDbType.Int);
                    cmd.Parameters["@ResultadoTerminoSemestreId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        resultadoTerminoSemestreDTO.ResultadoTerminoSemestreId = Convert.ToInt32(dr["ResultadoTerminoSemestreId"]);
                        resultadoTerminoSemestreDTO.DescResultadoTerminoSemestre = dr["DescResultadoTerminoSemestre"].ToString();
                        resultadoTerminoSemestreDTO.CodigoResultadoTerminoSemestre = dr["CodigoResultadoTerminoSemestre"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return resultadoTerminoSemestreDTO;
        }

        public string ActualizarResultadoTerminoSemestre(ResultadoTerminoSemestreDTO resultadoTerminoSemestreDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ResultadoTerminoSemestreActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ResultadoTerminoSemestreId", SqlDbType.Int);
                    cmd.Parameters["@ResultadoTerminoSemestreId"].Value = resultadoTerminoSemestreDTO.ResultadoTerminoSemestreId;

                    cmd.Parameters.Add("@DescResultadoTerminoSemestre", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescResultadoTerminoSemestre"].Value = resultadoTerminoSemestreDTO.DescResultadoTerminoSemestre;

                    cmd.Parameters.Add("@CodigoResultadoTerminoSemestre", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoResultadoTerminoSemestre"].Value = resultadoTerminoSemestreDTO.CodigoResultadoTerminoSemestre;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = resultadoTerminoSemestreDTO.UsuarioIngresoRegistro;

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

        public string EliminarResultadoTerminoSemestre(ResultadoTerminoSemestreDTO resultadoTerminoSemestreDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ResultadoTerminoSemestreEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ResultadoTerminoSemestreId", SqlDbType.Int);
                    cmd.Parameters["@ResultadoTerminoSemestreId"].Value = resultadoTerminoSemestreDTO.ResultadoTerminoSemestreId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = resultadoTerminoSemestreDTO.UsuarioIngresoRegistro;

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
