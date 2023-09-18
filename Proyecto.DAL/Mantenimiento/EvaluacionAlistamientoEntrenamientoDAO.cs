using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class EvaluacionAlistamientoEntrenamientoDAO
    {

        SqlCommand cmd = new();

        public List<EvaluacionAlistamientoEntrenamientoDTO> ObtenerEvaluacionAlistamientoEntrenamientos()
        {
            List<EvaluacionAlistamientoEntrenamientoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_EvaluacionAlistamientoEntrenamientoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new EvaluacionAlistamientoEntrenamientoDTO()
                        {
                            EvaluacionAlistamientoEntrenamientoId = Convert.ToInt32(dr["EvaluacionAlistamientoEntrenamientoId"]),
                            NivelEntrenamiento = dr["NivelEntrenamiento"].ToString(),
                            CodigoCapacidadOperativa = Convert.ToInt32(dr["CodigoCapacidadOperativa"]),
                            TipoCapacidadOperativa = dr["TipoCapacidadOperativa"].ToString(),
                            CodigoEjercicio = dr["CodigoEjercicio"].ToString(),
                            Calificativo = dr["Calificativo"].ToString(),
                            FechaPeriodoEvaluacionEjercicio = Convert.ToDateTime(dr["FechaPeriodoEvaluacionEjercicio"]).ToString("yyyy-MM-dd HH:mm:ss"),
                            FechaRealizacionEjercicio = Convert.ToDateTime(dr["FechaRealizacionEjercicio"]).ToString("yyyy-MM-dd HH:mm:ss"),
                            TiempoVigencia = dr["TiempoVigencia"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarEvaluacionAlistamientoEntrenamiento(EvaluacionAlistamientoEntrenamientoDTO evaluacionAlistamientoEntrenamientoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EvaluacionAlistamientoEntrenamientoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@NivelEntrenamiento", SqlDbType.VarChar, 20);
                    cmd.Parameters["@NivelEntrenamiento"].Value = evaluacionAlistamientoEntrenamientoDTO.NivelEntrenamiento;

                    cmd.Parameters.Add("@CodigoCapacidadOperativa", SqlDbType.Int);
                    cmd.Parameters["@CodigoCapacidadOperativa"].Value = evaluacionAlistamientoEntrenamientoDTO.CodigoCapacidadOperativa;

                    cmd.Parameters.Add("@TipoCapacidadOperativa", SqlDbType.VarChar, 20);
                    cmd.Parameters["@TipoCapacidadOperativa"].Value = evaluacionAlistamientoEntrenamientoDTO.TipoCapacidadOperativa;

                    cmd.Parameters.Add("@CodigoEjercicio", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEjercicio"].Value = evaluacionAlistamientoEntrenamientoDTO.CodigoEjercicio;

                    cmd.Parameters.Add("@Calificativo", SqlDbType.VarChar, 20);
                    cmd.Parameters["@Calificativo"].Value = evaluacionAlistamientoEntrenamientoDTO.Calificativo;

                    cmd.Parameters.Add("@FechaPeriodoEvaluacionEjercicio", SqlDbType.DateTime);
                    cmd.Parameters["@FechaPeriodoEvaluacionEjercicio"].Value = evaluacionAlistamientoEntrenamientoDTO.FechaPeriodoEvaluacionEjercicio;

                    cmd.Parameters.Add("@FechaRealizacionEjercicio", SqlDbType.DateTime);
                    cmd.Parameters["@FechaRealizacionEjercicio"].Value = evaluacionAlistamientoEntrenamientoDTO.FechaRealizacionEjercicio;

                    cmd.Parameters.Add("@TiempoVigencia", SqlDbType.VarChar, 20);
                    cmd.Parameters["@TiempoVigencia"].Value = evaluacionAlistamientoEntrenamientoDTO.TiempoVigencia;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = evaluacionAlistamientoEntrenamientoDTO.UsuarioIngresoRegistro;

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

        public EvaluacionAlistamientoEntrenamientoDTO BuscarEvaluacionAlistamientoEntrenamientoID(int Codigo)
        {
            EvaluacionAlistamientoEntrenamientoDTO evaluacionAlistamientoEntrenamientoDTO = new EvaluacionAlistamientoEntrenamientoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EvaluacionAlistamientoEntrenamientoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EvaluacionAlistamientoEntrenamientoId", SqlDbType.Int);
                    cmd.Parameters["@EvaluacionAlistamientoEntrenamientoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        evaluacionAlistamientoEntrenamientoDTO.EvaluacionAlistamientoEntrenamientoId = Convert.ToInt32(dr["EvaluacionAlistamientoEntrenamientoId"]);
                        evaluacionAlistamientoEntrenamientoDTO.NivelEntrenamiento = dr["NivelEntrenamiento"].ToString();
                        evaluacionAlistamientoEntrenamientoDTO.CodigoCapacidadOperativa = Convert.ToInt32(dr["CodigoCapacidadOperativa"]);
                        evaluacionAlistamientoEntrenamientoDTO.TipoCapacidadOperativa = dr["TipoCapacidadOperativa"].ToString();
                        evaluacionAlistamientoEntrenamientoDTO.CodigoEjercicio = dr["CodigoEjercicio"].ToString();
                        evaluacionAlistamientoEntrenamientoDTO.Calificativo = dr["Calificativo"].ToString();
                        evaluacionAlistamientoEntrenamientoDTO.FechaPeriodoEvaluacionEjercicio = Convert.ToDateTime(dr["FechaPeriodoEvaluacionEjercicio"]).ToString("yyy-MM-dd HH:mm:ss");
                        evaluacionAlistamientoEntrenamientoDTO.FechaRealizacionEjercicio = Convert.ToDateTime(dr["FechaRealizacionEjercicio"]).ToString("yyy-MM-dd HH:mm:ss");
                        evaluacionAlistamientoEntrenamientoDTO.TiempoVigencia = dr["Calificativo"].ToString();

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return evaluacionAlistamientoEntrenamientoDTO;
        }

        public string ActualizarEvaluacionAlistamientoEntrenamiento(EvaluacionAlistamientoEntrenamientoDTO evaluacionAlistamientoEntrenamientoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EvaluacionAlistamientoEntrenamientoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EvaluacionAlistamientoEntrenamientoId", SqlDbType.Int);
                    cmd.Parameters["@EvaluacionAlistamientoEntrenamientoId"].Value = evaluacionAlistamientoEntrenamientoDTO.EvaluacionAlistamientoEntrenamientoId;
                    cmd.Parameters.Add("@NivelEntrenamiento", SqlDbType.VarChar, 20);
                    cmd.Parameters["@NivelEntrenamiento"].Value = evaluacionAlistamientoEntrenamientoDTO.NivelEntrenamiento;

                    cmd.Parameters.Add("@CodigoCapacidadOperativa", SqlDbType.Int);
                    cmd.Parameters["@CodigoCapacidadOperativa"].Value = evaluacionAlistamientoEntrenamientoDTO.CodigoCapacidadOperativa;

                    cmd.Parameters.Add("@TipoCapacidadOperativa", SqlDbType.VarChar, 20);
                    cmd.Parameters["@TipoCapacidadOperativa"].Value = evaluacionAlistamientoEntrenamientoDTO.TipoCapacidadOperativa;

                    cmd.Parameters.Add("@CodigoEjercicio", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEjercicio"].Value = evaluacionAlistamientoEntrenamientoDTO.CodigoEjercicio;

                    cmd.Parameters.Add("@Calificativo", SqlDbType.VarChar, 20);
                    cmd.Parameters["@Calificativo"].Value = evaluacionAlistamientoEntrenamientoDTO.Calificativo;

                    cmd.Parameters.Add("@FechaPeriodoEvaluacionEjercicio", SqlDbType.DateTime);
                    cmd.Parameters["@FechaPeriodoEvaluacionEjercicio"].Value = evaluacionAlistamientoEntrenamientoDTO.FechaPeriodoEvaluacionEjercicio;

                    cmd.Parameters.Add("@FechaRealizacionEjercicio", SqlDbType.DateTime);
                    cmd.Parameters["@FechaRealizacionEjercicio"].Value = evaluacionAlistamientoEntrenamientoDTO.FechaRealizacionEjercicio;

                    cmd.Parameters.Add("@TiempoVigencia", SqlDbType.VarChar, 20);
                    cmd.Parameters["@TiempoVigencia"].Value = evaluacionAlistamientoEntrenamientoDTO.TiempoVigencia;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = evaluacionAlistamientoEntrenamientoDTO.UsuarioIngresoRegistro;

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

        public string EliminarEvaluacionAlistamientoEntrenamiento(EvaluacionAlistamientoEntrenamientoDTO evaluacionAlistamientoEntrenamientoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EvaluacionAlistamientoEntrenamientoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EvaluacionAlistamientoEntrenamientoId", SqlDbType.Int);
                    cmd.Parameters["@EvaluacionAlistamientoEntrenamientoId"].Value = evaluacionAlistamientoEntrenamientoDTO.EvaluacionAlistamientoEntrenamientoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = evaluacionAlistamientoEntrenamientoDTO.UsuarioIngresoRegistro;

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
