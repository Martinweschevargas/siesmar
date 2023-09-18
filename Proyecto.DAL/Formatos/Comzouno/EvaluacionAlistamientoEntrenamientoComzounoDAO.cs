using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comzouno;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comzouno
{
    public class EvaluacionAlistamientoEntrenamientoComzounoDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<EvaluacionAlistamientoEntrenamientoComzounoDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<EvaluacionAlistamientoEntrenamientoComzounoDTO> lista = new List<EvaluacionAlistamientoEntrenamientoComzounoDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoEntrenamientoComzounoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                cmd.Parameters.Add("@FechaInicio", SqlDbType.Date);
                cmd.Parameters["@FechaInicio"].Value = fechainicio;

                cmd.Parameters.Add("@FechaFin", SqlDbType.Date);
                cmd.Parameters["@FechaFin"].Value = fechafin;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new EvaluacionAlistamientoEntrenamientoComzounoDTO()
                        {
                            EvaluacionAlistamientoEntrenamientoId = Convert.ToInt32(dr["EvaluacionAlistamientoEntrenamientoId"]),
                            DescUnidadNaval = dr["DescUnidadNaval"].ToString(),
                            DescNivelEntrenamiento = dr["DescNivelEntrenamiento"].ToString(),
                            DescCapacidadOperativa = dr["DescCapacidadOperativa"].ToString(),
                            TipoCapacidadOperativa = dr["TipoCapacidadOperativa"].ToString(),
                            CodigoEjercicioEntrenamientoAspecto = dr["CodigoEjercicioEntrenamientoAspecto"].ToString(),
                            DescEjercicioEntrenamiento = dr["DescEjercicioEntrenamiento"].ToString(),
                            AspectoEvaluacion = dr["AspectoEvaluacion"].ToString(),
                            Peso = dr["Peso"].ToString(),
                            Descripcion = dr["Descripcion"].ToString(),
                            PuntajeObtenidoEjercicio = Convert.ToInt32(dr["PuntajeObtenidoEjercicio"]),
                            FechaPeriodoEvaluar = (dr["FechaPeriodoEvaluar"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            FechaRealizacionEjercicio = (dr["FechaRealizacionEjercicio"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            TiempoVigencia = Convert.ToInt32(dr["TiempoVigencia"]),
                            FechaCaducidadEjercicio = (dr["FechaCaducidadEjercicio"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            CargaId = Convert.ToInt32(dr["CargaId"])
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(EvaluacionAlistamientoEntrenamientoComzounoDTO evaluacionAlistamientoEntrenamientoComzounoDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoEntrenamientoComzounoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoUnidadNaval", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoUnidadNaval"].Value = evaluacionAlistamientoEntrenamientoComzounoDTO.CodigoUnidadNaval;

                    cmd.Parameters.Add("@CodigoNivelEntrenamiento", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoNivelEntrenamiento"].Value = evaluacionAlistamientoEntrenamientoComzounoDTO.CodigoNivelEntrenamiento;

                    cmd.Parameters.Add("@CodigoCapacidadOperativa", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCapacidadOperativa"].Value = evaluacionAlistamientoEntrenamientoComzounoDTO.CodigoCapacidadOperativa;

                    cmd.Parameters.Add("@TipoCapacidadOperativa", SqlDbType.NChar,2);
                    cmd.Parameters["@TipoCapacidadOperativa"].Value = evaluacionAlistamientoEntrenamientoComzounoDTO.TipoCapacidadOperativa;

                    cmd.Parameters.Add("@CodigoEjercicioEntrenamientoAspecto", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEjercicioEntrenamientoAspecto"].Value = evaluacionAlistamientoEntrenamientoComzounoDTO.CodigoEjercicioEntrenamientoAspecto;

                    cmd.Parameters.Add("@CodigoCalificativoAsignadoEjercicio", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCalificativoAsignadoEjercicio"].Value = evaluacionAlistamientoEntrenamientoComzounoDTO.CodigoCalificativoAsignadoEjercicio;

                    cmd.Parameters.Add("@PuntajeObtenidoEjercicio", SqlDbType.Int);
                    cmd.Parameters["@PuntajeObtenidoEjercicio"].Value = evaluacionAlistamientoEntrenamientoComzounoDTO.PuntajeObtenidoEjercicio;

                    cmd.Parameters.Add("@FechaPeriodoEvaluar", SqlDbType.Date);
                    cmd.Parameters["@FechaPeriodoEvaluar"].Value = evaluacionAlistamientoEntrenamientoComzounoDTO.FechaPeriodoEvaluar;

                    cmd.Parameters.Add("@FechaRealizacionEjercicio", SqlDbType.Date);
                    cmd.Parameters["@FechaRealizacionEjercicio"].Value = evaluacionAlistamientoEntrenamientoComzounoDTO.FechaRealizacionEjercicio;

                    cmd.Parameters.Add("@TiempoVigencia", SqlDbType.Int);
                    cmd.Parameters["@TiempoVigencia"].Value = evaluacionAlistamientoEntrenamientoComzounoDTO.TiempoVigencia;

                    cmd.Parameters.Add("@FechaCaducidadEjercicio", SqlDbType.Date);
                    cmd.Parameters["@FechaCaducidadEjercicio"].Value = evaluacionAlistamientoEntrenamientoComzounoDTO.FechaCaducidadEjercicio;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = evaluacionAlistamientoEntrenamientoComzounoDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = evaluacionAlistamientoEntrenamientoComzounoDTO.UsuarioIngresoRegistro;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Mac"].Value = UtilitariosGlobales.obtenerDireccionMac();

                    cmd.Parameters.Add("@FechaCarga", SqlDbType.Date);
                    cmd.Parameters["@FechaCarga"].Value = fecha;

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

        public EvaluacionAlistamientoEntrenamientoComzounoDTO BuscarFormato(int Codigo)
        {
            EvaluacionAlistamientoEntrenamientoComzounoDTO evaluacionAlistamientoEntrenamientoComzounoDTO = new EvaluacionAlistamientoEntrenamientoComzounoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoEntrenamientoComzounoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EvaluacionAlistamientoEntrenamientoId", SqlDbType.Int);
                    cmd.Parameters["@EvaluacionAlistamientoEntrenamientoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        evaluacionAlistamientoEntrenamientoComzounoDTO.EvaluacionAlistamientoEntrenamientoId = Convert.ToInt32(dr["EvaluacionAlistamientoEntrenamientoId"]);
                        evaluacionAlistamientoEntrenamientoComzounoDTO.CodigoUnidadNaval = dr["CodigoUnidadNaval"].ToString();
                        evaluacionAlistamientoEntrenamientoComzounoDTO.CodigoNivelEntrenamiento = dr["CodigoNivelEntrenamiento"].ToString();
                        evaluacionAlistamientoEntrenamientoComzounoDTO.CodigoCapacidadOperativa = dr["CodigoCapacidadOperativa"].ToString();
                        evaluacionAlistamientoEntrenamientoComzounoDTO.TipoCapacidadOperativa = dr["TipoCapacidadOperativa"].ToString();
                        evaluacionAlistamientoEntrenamientoComzounoDTO.CodigoEjercicioEntrenamientoAspecto = dr["CodigoEjercicioEntrenamientoAspecto"].ToString();
                        evaluacionAlistamientoEntrenamientoComzounoDTO.CodigoCalificativoAsignadoEjercicio = dr["CodigoCalificativoAsignadoEjercicio"].ToString();
                        evaluacionAlistamientoEntrenamientoComzounoDTO.PuntajeObtenidoEjercicio = Convert.ToInt32(dr["PuntajeObtenidoEjercicio"]);
                        evaluacionAlistamientoEntrenamientoComzounoDTO.FechaPeriodoEvaluar = Convert.ToDateTime(dr["FechaPeriodoEvaluar"]).ToString("yyy-MM-dd");
                        evaluacionAlistamientoEntrenamientoComzounoDTO.FechaRealizacionEjercicio = Convert.ToDateTime(dr["FechaRealizacionEjercicio"]).ToString("yyy-MM-dd");
                        evaluacionAlistamientoEntrenamientoComzounoDTO.TiempoVigencia = Convert.ToInt32(dr["TiempoVigencia"]);
                        evaluacionAlistamientoEntrenamientoComzounoDTO.FechaCaducidadEjercicio = Convert.ToDateTime(dr["FechaCaducidadEjercicio"]).ToString("yyy-MM-dd");

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return evaluacionAlistamientoEntrenamientoComzounoDTO;
        }

        public string ActualizaFormato(EvaluacionAlistamientoEntrenamientoComzounoDTO evaluacionAlistamientoEntrenamientoComzounoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoEntrenamientoComzounoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EvaluacionAlistamientoEntrenamientoId", SqlDbType.Int);
                    cmd.Parameters["@EvaluacionAlistamientoEntrenamientoId"].Value = evaluacionAlistamientoEntrenamientoComzounoDTO.EvaluacionAlistamientoEntrenamientoId;

                    cmd.Parameters.Add("@CodigoUnidadNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUnidadNaval"].Value = evaluacionAlistamientoEntrenamientoComzounoDTO.CodigoUnidadNaval;

                    cmd.Parameters.Add("@CodigoNivelEntrenamiento", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoNivelEntrenamiento"].Value = evaluacionAlistamientoEntrenamientoComzounoDTO.CodigoNivelEntrenamiento;

                    cmd.Parameters.Add("@CodigoCapacidadOperativa", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCapacidadOperativa"].Value = evaluacionAlistamientoEntrenamientoComzounoDTO.CodigoCapacidadOperativa;

                    cmd.Parameters.Add("@TipoCapacidadOperativa", SqlDbType.NChar,2);
                    cmd.Parameters["@TipoCapacidadOperativa"].Value = evaluacionAlistamientoEntrenamientoComzounoDTO.TipoCapacidadOperativa;

                    cmd.Parameters.Add("@CodigoEjercicioEntrenamientoAspecto", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEjercicioEntrenamientoAspecto"].Value = evaluacionAlistamientoEntrenamientoComzounoDTO.CodigoEjercicioEntrenamientoAspecto;

                    cmd.Parameters.Add("@CodigoCalificativoAsignadoEjercicio", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCalificativoAsignadoEjercicio"].Value = evaluacionAlistamientoEntrenamientoComzounoDTO.CodigoCalificativoAsignadoEjercicio;

                    cmd.Parameters.Add("@PuntajeObtenidoEjercicio", SqlDbType.Int);
                    cmd.Parameters["@PuntajeObtenidoEjercicio"].Value = evaluacionAlistamientoEntrenamientoComzounoDTO.PuntajeObtenidoEjercicio;

                    cmd.Parameters.Add("@FechaPeriodoEvaluar", SqlDbType.Date);
                    cmd.Parameters["@FechaPeriodoEvaluar"].Value = evaluacionAlistamientoEntrenamientoComzounoDTO.FechaPeriodoEvaluar;

                    cmd.Parameters.Add("@FechaRealizacionEjercicio", SqlDbType.Date);
                    cmd.Parameters["@FechaRealizacionEjercicio"].Value = evaluacionAlistamientoEntrenamientoComzounoDTO.FechaRealizacionEjercicio;

                    cmd.Parameters.Add("@TiempoVigencia", SqlDbType.Int);
                    cmd.Parameters["@TiempoVigencia"].Value = evaluacionAlistamientoEntrenamientoComzounoDTO.TiempoVigencia;

                    cmd.Parameters.Add("@FechaCaducidadEjercicio", SqlDbType.Date);
                    cmd.Parameters["@FechaCaducidadEjercicio"].Value = evaluacionAlistamientoEntrenamientoComzounoDTO.FechaCaducidadEjercicio;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = evaluacionAlistamientoEntrenamientoComzounoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(EvaluacionAlistamientoEntrenamientoComzounoDTO evaluacionAlistamientoEntrenamientoComzounoDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoEntrenamientoComzounoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EvaluacionAlistamientoEntrenamientoId", SqlDbType.Int);
                    cmd.Parameters["@EvaluacionAlistamientoEntrenamientoId"].Value = evaluacionAlistamientoEntrenamientoComzounoDTO.EvaluacionAlistamientoEntrenamientoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = evaluacionAlistamientoEntrenamientoComzounoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(EvaluacionAlistamientoEntrenamientoComzounoDTO evaluacionAlistamientoEntrenamientoComzounoDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Seguridad.usp_CargaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Formato", SqlDbType.NVarChar, 200);
                    cmd.Parameters["@Formato"].Value = "EvaluacionAlistamientoEntrenamientoComzouno";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = evaluacionAlistamientoEntrenamientoComzounoDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = evaluacionAlistamientoEntrenamientoComzounoDTO.UsuarioIngresoRegistro;

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

        public string InsertarDatos(DataTable datos, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoEntrenamientoComzounoRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EvaluacionAlistamientoEntrenamientoComzouno", SqlDbType.Structured);
                    cmd.Parameters["@EvaluacionAlistamientoEntrenamientoComzouno"].TypeName = "Formato.EvaluacionAlistamientoEntrenamientoComzouno";
                    cmd.Parameters["@EvaluacionAlistamientoEntrenamientoComzouno"].Value = datos;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Mac"].Value = UtilitariosGlobales.obtenerDireccionMac();

                    cmd.Parameters.Add("@FechaCarga", SqlDbType.Date);
                    cmd.Parameters["@FechaCarga"].Value = fecha;

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
