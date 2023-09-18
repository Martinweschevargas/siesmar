using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class ResultadoEjercicioEducativoDAO
    {

        SqlCommand cmd = new();

        public List<ResultadoEjercicioEducativoDTO> ObtenerResultadoEjercicioEducativos()
        {
            List<ResultadoEjercicioEducativoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_ResultadoEjercicioEducativoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ResultadoEjercicioEducativoDTO()
                        {
                            ResultadoEjercicioEducativoId = Convert.ToInt32(dr["ResultadoEjercicioEducativoId"]),
                            DescResultadoEjercicioEducativo = dr["DescResultadoEjercicioEducativo"].ToString(),
                            CodigoResultadoEjercicioEducativo = dr["CodigoResultadoEjercicioEducativo"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarResultadoEjercicioEducativo(ResultadoEjercicioEducativoDTO ResultadoEjercicioEducativoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ResultadoEjercicioEducativoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescResultadoEjercicioEducativo", SqlDbType.VarChar, 70);
                    cmd.Parameters["@DescResultadoEjercicioEducativo"].Value = ResultadoEjercicioEducativoDTO.DescResultadoEjercicioEducativo;

                    cmd.Parameters.Add("@CodigoResultadoEjercicioEducativo", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoResultadoEjercicioEducativo"].Value = ResultadoEjercicioEducativoDTO.CodigoResultadoEjercicioEducativo;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ResultadoEjercicioEducativoDTO.UsuarioIngresoRegistro;

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

        public ResultadoEjercicioEducativoDTO BuscarResultadoEjercicioEducativoID(int Codigo)
        {
            ResultadoEjercicioEducativoDTO ResultadoEjercicioEducativoDTO = new ResultadoEjercicioEducativoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ResultadoEjercicioEducativoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ResultadoEjercicioEducativoId", SqlDbType.Int);
                    cmd.Parameters["@ResultadoEjercicioEducativoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        ResultadoEjercicioEducativoDTO.ResultadoEjercicioEducativoId = Convert.ToInt32(dr["ResultadoEjercicioEducativoId"]);
                        ResultadoEjercicioEducativoDTO.DescResultadoEjercicioEducativo = dr["DescResultadoEjercicioEducativo"].ToString();
                        ResultadoEjercicioEducativoDTO.CodigoResultadoEjercicioEducativo = dr["CodigoResultadoEjercicioEducativo"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return ResultadoEjercicioEducativoDTO;
        }

        public string ActualizarResultadoEjercicioEducativo(ResultadoEjercicioEducativoDTO ResultadoEjercicioEducativoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ResultadoEjercicioEducativoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ResultadoEjercicioEducativoId", SqlDbType.Int);
                    cmd.Parameters["@ResultadoEjercicioEducativoId"].Value = ResultadoEjercicioEducativoDTO.ResultadoEjercicioEducativoId;

                    cmd.Parameters.Add("@DescResultadoEjercicioEducativo", SqlDbType.VarChar, 70);
                    cmd.Parameters["@DescResultadoEjercicioEducativo"].Value = ResultadoEjercicioEducativoDTO.DescResultadoEjercicioEducativo;

                    cmd.Parameters.Add("@CodigoResultadoEjercicioEducativo", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoResultadoEjercicioEducativo"].Value = ResultadoEjercicioEducativoDTO.CodigoResultadoEjercicioEducativo;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ResultadoEjercicioEducativoDTO.UsuarioIngresoRegistro;

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

        public string EliminarResultadoEjercicioEducativo(ResultadoEjercicioEducativoDTO ResultadoEjercicioEducativoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ResultadoEjercicioEducativoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ResultadoEjercicioEducativoId", SqlDbType.Int);
                    cmd.Parameters["@ResultadoEjercicioEducativoId"].Value = ResultadoEjercicioEducativoDTO.ResultadoEjercicioEducativoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ResultadoEjercicioEducativoDTO.UsuarioIngresoRegistro;

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
