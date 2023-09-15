using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Jesehin;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Jesehin
{
    public class EvaluacionAlistamientoEntrenamientoJesehinDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<EvaluacionAlistamientoEntrenamientoJesehinDTO> ObtenerLista()
        {
            List<EvaluacionAlistamientoEntrenamientoJesehinDTO> lista = new List<EvaluacionAlistamientoEntrenamientoJesehinDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoEntrenamientoJesehinListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new EvaluacionAlistamientoEntrenamientoJesehinDTO()
                        {
                            EvaluacionAlistamientoEntrenamientoId = Convert.ToInt32(dr["EvaluacionAlistamientoEntrenamientoId"]),
                            DescUnidadNaval = dr["DescUnidadNaval"].ToString(),
                            NivelEntrenamiento = dr["NivelEntrenamiento"].ToString(),
                            DescCapacidadOperativa = dr["DescCapacidadOperativa"].ToString(),
                            TipoCapacidadOperativa = dr["TipoCapacidadOperativa"].ToString(),
                            EjercicioEntrenamientoAspectoId = Convert.ToInt32(dr["EjercicioEntrenamientoAspectoId"]),
                            CodigoEjercicioEntrenamiento = dr["CodigoEjercicioEntrenamiento"].ToString(),
                            DescEjercicioEntrenamiento = dr["DescEjercicioEntrenamiento"].ToString(),
                            AspectoEvaluacion = dr["AspectoEvaluacion"].ToString(),
                            Peso = dr["Peso"].ToString(),
                            Descripcion = dr["Descripcion"].ToString(),
                            PuntajeObtenidoEjercicio = Convert.ToInt32(dr["PuntajeObtenidoEjercicio"]),
                            FechaPeriodoEvaluar = (dr["FechaPeriodoEvaluar"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            FechaRealizacionEjercicio = (dr["FechaRealizacionEjercicio"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            TiempoVigencia = Convert.ToInt32(dr["TiempoVigencia"]),
                            FechaCaducidadEjercicio = (dr["FechaCaducidadEjercicio"].ToString()).Split(" ", StringSplitOptions.None)[0],
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(EvaluacionAlistamientoEntrenamientoJesehinDTO evaluacionAlistamientoEntrenamientoJesehinDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoEntrenamientoJesehinRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@UnidadNavalId", SqlDbType.Int);
                    cmd.Parameters["@UnidadNavalId"].Value = evaluacionAlistamientoEntrenamientoJesehinDTO.UnidadNavalId;

                    cmd.Parameters.Add("@NivelEntrenamiento", SqlDbType.VarChar, 1);
                    cmd.Parameters["@NivelEntrenamiento"].Value = evaluacionAlistamientoEntrenamientoJesehinDTO.NivelEntrenamiento;

                    cmd.Parameters.Add("@CapacidadOperativaId", SqlDbType.Int);
                    cmd.Parameters["@CapacidadOperativaId"].Value = evaluacionAlistamientoEntrenamientoJesehinDTO.CapacidadOperativaId;

                    cmd.Parameters.Add("@TipoCapacidadOperativa", SqlDbType.VarChar, 15);
                    cmd.Parameters["@TipoCapacidadOperativa"].Value = evaluacionAlistamientoEntrenamientoJesehinDTO.TipoCapacidadOperativa;

                    cmd.Parameters.Add("@EjercicioEntrenamientoAspectoId", SqlDbType.Int);
                    cmd.Parameters["@EjercicioEntrenamientoAspectoId"].Value = evaluacionAlistamientoEntrenamientoJesehinDTO.EjercicioEntrenamientoAspectoId;

                    cmd.Parameters.Add("@CalificativoAsignadoEjercicioId", SqlDbType.Int);
                    cmd.Parameters["@CalificativoAsignadoEjercicioId"].Value = evaluacionAlistamientoEntrenamientoJesehinDTO.CalificativoAsignadoEjercicioId;

                    cmd.Parameters.Add("@PuntajeObtenidoEjercicio", SqlDbType.Int);
                    cmd.Parameters["@PuntajeObtenidoEjercicio"].Value = evaluacionAlistamientoEntrenamientoJesehinDTO.PuntajeObtenidoEjercicio;

                    cmd.Parameters.Add("@FechaPeriodoEvaluar", SqlDbType.Date);
                    cmd.Parameters["@FechaPeriodoEvaluar"].Value = evaluacionAlistamientoEntrenamientoJesehinDTO.FechaPeriodoEvaluar;

                    cmd.Parameters.Add("@FechaRealizacionEjercicio", SqlDbType.Date);
                    cmd.Parameters["@FechaRealizacionEjercicio"].Value = evaluacionAlistamientoEntrenamientoJesehinDTO.FechaRealizacionEjercicio;

                    cmd.Parameters.Add("@TiempoVigencia", SqlDbType.Int);
                    cmd.Parameters["@TiempoVigencia"].Value = evaluacionAlistamientoEntrenamientoJesehinDTO.TiempoVigencia;


                    cmd.Parameters.Add("@FechaCaducidadEjercicio", SqlDbType.Date);
                    cmd.Parameters["@FechaCaducidadEjercicio"].Value = evaluacionAlistamientoEntrenamientoJesehinDTO.FechaCaducidadEjercicio;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = evaluacionAlistamientoEntrenamientoJesehinDTO.UsuarioIngresoRegistro;

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

        public EvaluacionAlistamientoEntrenamientoJesehinDTO BuscarFormato(int Codigo)
        {
            EvaluacionAlistamientoEntrenamientoJesehinDTO evaluacionAlistamientoEntrenamientoJesehinDTO = new EvaluacionAlistamientoEntrenamientoJesehinDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoEntrenamientoJesehinEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EvaluacionAlistamientoEntrenamientoId", SqlDbType.Int);
                    cmd.Parameters["@EvaluacionAlistamientoEntrenamientoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        evaluacionAlistamientoEntrenamientoJesehinDTO.EvaluacionAlistamientoEntrenamientoId = Convert.ToInt32(dr["EvaluacionAlistamientoEntrenamientoId"]);
                        evaluacionAlistamientoEntrenamientoJesehinDTO.UnidadNavalId = Convert.ToInt32(dr["UnidadNavalId"]);
                        evaluacionAlistamientoEntrenamientoJesehinDTO.NivelEntrenamiento = dr["NivelEntrenamiento"].ToString();
                        evaluacionAlistamientoEntrenamientoJesehinDTO.CapacidadOperativaId = Convert.ToInt32(dr["CapacidadOperativaId"]);
                        evaluacionAlistamientoEntrenamientoJesehinDTO.TipoCapacidadOperativa = dr["TipoCapacidadOperativa"].ToString();
                        evaluacionAlistamientoEntrenamientoJesehinDTO.EjercicioEntrenamientoAspectoId = Convert.ToInt32(dr["EjercicioEntrenamientoAspectoId"]);
                        evaluacionAlistamientoEntrenamientoJesehinDTO.CodigoEjercicioEntrenamiento = dr["CodigoEjercicioEntrenamiento"].ToString();
                        evaluacionAlistamientoEntrenamientoJesehinDTO.DescEjercicioEntrenamiento = dr["DescEjercicioEntrenamiento"].ToString();
                        evaluacionAlistamientoEntrenamientoJesehinDTO.AspectoEvaluacion = dr["AspectoEvaluacion"].ToString();
                        evaluacionAlistamientoEntrenamientoJesehinDTO.Peso = dr["Peso"].ToString();
                        evaluacionAlistamientoEntrenamientoJesehinDTO.CalificativoAsignadoEjercicioId = Convert.ToInt32(dr["CalificativoAsignadoEjercicioId"]);
                        evaluacionAlistamientoEntrenamientoJesehinDTO.PuntajeObtenidoEjercicio = Convert.ToInt32(dr["PuntajeObtenidoEjercicio"]);
                        evaluacionAlistamientoEntrenamientoJesehinDTO.FechaPeriodoEvaluar = Convert.ToDateTime(dr["FechaPeriodoEvaluar"]).ToString("yyy-MM-dd");
                        evaluacionAlistamientoEntrenamientoJesehinDTO.FechaRealizacionEjercicio = Convert.ToDateTime(dr["FechaRealizacionEjercicio"]).ToString("yyy-MM-dd");
                        evaluacionAlistamientoEntrenamientoJesehinDTO.TiempoVigencia = Convert.ToInt32(dr["TiempoVigencia"]);
                        evaluacionAlistamientoEntrenamientoJesehinDTO.FechaCaducidadEjercicio = Convert.ToDateTime(dr["FechaCaducidadEjercicio"]).ToString("yyy-MM-dd");
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return evaluacionAlistamientoEntrenamientoJesehinDTO;
        }

        public string ActualizaFormato(EvaluacionAlistamientoEntrenamientoJesehinDTO evaluacionAlistamientoEntrenamientoJesehinDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoEntrenamientoJesehinActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EvaluacionAlistamientoEntrenamientoId", SqlDbType.Int);
                    cmd.Parameters["@EvaluacionAlistamientoEntrenamientoId"].Value = evaluacionAlistamientoEntrenamientoJesehinDTO.EvaluacionAlistamientoEntrenamientoId;

                    cmd.Parameters.Add("@UnidadNavalId", SqlDbType.Int);
                    cmd.Parameters["@UnidadNavalId"].Value = evaluacionAlistamientoEntrenamientoJesehinDTO.UnidadNavalId;

                    cmd.Parameters.Add("@NivelEntrenamiento", SqlDbType.VarChar, 1);
                    cmd.Parameters["@NivelEntrenamiento"].Value = evaluacionAlistamientoEntrenamientoJesehinDTO.NivelEntrenamiento;

                    cmd.Parameters.Add("@CapacidadOperativaId", SqlDbType.Int);
                    cmd.Parameters["@CapacidadOperativaId"].Value = evaluacionAlistamientoEntrenamientoJesehinDTO.CapacidadOperativaId;

                    cmd.Parameters.Add("@TipoCapacidadOperativa", SqlDbType.VarChar, 15);
                    cmd.Parameters["@TipoCapacidadOperativa"].Value = evaluacionAlistamientoEntrenamientoJesehinDTO.TipoCapacidadOperativa;

                    cmd.Parameters.Add("@EjercicioEntrenamientoAspectoId", SqlDbType.Int);
                    cmd.Parameters["@EjercicioEntrenamientoAspectoId"].Value = evaluacionAlistamientoEntrenamientoJesehinDTO.EjercicioEntrenamientoAspectoId;

                    cmd.Parameters.Add("@CalificativoAsignadoEjercicioId", SqlDbType.Int);
                    cmd.Parameters["@CalificativoAsignadoEjercicioId"].Value = evaluacionAlistamientoEntrenamientoJesehinDTO.CalificativoAsignadoEjercicioId;

                    cmd.Parameters.Add("@PuntajeObtenidoEjercicio", SqlDbType.Int);
                    cmd.Parameters["@PuntajeObtenidoEjercicio"].Value = evaluacionAlistamientoEntrenamientoJesehinDTO.PuntajeObtenidoEjercicio;

                    cmd.Parameters.Add("@FechaPeriodoEvaluar", SqlDbType.Date);
                    cmd.Parameters["@FechaPeriodoEvaluar"].Value = evaluacionAlistamientoEntrenamientoJesehinDTO.FechaPeriodoEvaluar;

                    cmd.Parameters.Add("@FechaRealizacionEjercicio", SqlDbType.Date);
                    cmd.Parameters["@FechaRealizacionEjercicio"].Value = evaluacionAlistamientoEntrenamientoJesehinDTO.FechaRealizacionEjercicio;

                    cmd.Parameters.Add("@TiempoVigencia", SqlDbType.Int);
                    cmd.Parameters["@TiempoVigencia"].Value = evaluacionAlistamientoEntrenamientoJesehinDTO.TiempoVigencia;


                    cmd.Parameters.Add("@FechaCaducidadEjercicio", SqlDbType.Date);
                    cmd.Parameters["@FechaCaducidadEjercicio"].Value = evaluacionAlistamientoEntrenamientoJesehinDTO.FechaCaducidadEjercicio;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = evaluacionAlistamientoEntrenamientoJesehinDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(EvaluacionAlistamientoEntrenamientoJesehinDTO evaluacionAlistamientoEntrenamientoJesehinDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoEntrenamientoJesehinEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EvaluacionAlistamientoEntrenamientoId", SqlDbType.Int);
                    cmd.Parameters["@EvaluacionAlistamientoEntrenamientoId"].Value = evaluacionAlistamientoEntrenamientoJesehinDTO.EvaluacionAlistamientoEntrenamientoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = evaluacionAlistamientoEntrenamientoJesehinDTO.UsuarioIngresoRegistro;

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

        public bool InsercionMasiva(IEnumerable<EvaluacionAlistamientoEntrenamientoJesehinDTO> emisionNotaPrensaDTO)
        {
            bool respuesta = false;
            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                using (SqlTransaction transaction = conexion.BeginTransaction())
                {
                    using (var cmd = new SqlCommand())
                    {

                        cmd.Connection = conexion;
                        cmd.Transaction = transaction;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "insert into Formato.EstudiosInvestigacionHistoricaNaval " +
                            " (NombreInvestigacion, TipoEstudioInvestigacionId, FechaInicioInvestigacion, " +
                            "FechaTerminoInvestigacion, ResponsableInvestigacion, SolicitanteInvestigacion, " +
                            "UsuarioIngresoRegistro, FechaIngresoRegistro, NroIpRegistro, NroMacRegistro, " +
                            "UsuarioBaseDatos, CodigoIngreso, Año, Mes, Dia) values (@NombreInvestigacion, " +
                            "@TipoEstudioInvestigacionId, @FechaInicioInvestigacion, @FechaTerminoInvestigacion, " +
                            "@ResponsableInvestigacion, @SolicitanteInvestigacion, @Usuario, GETDATE(), @IP, @MAC, " +
                            "@UsuarioDB, 0, @YEAR, @MES, @DIA)";
                        cmd.Parameters.Add("@NombreInvestigacion", SqlDbType.VarChar, 250);
                        cmd.Parameters.Add("@TipoEstudioInvestigacionId", SqlDbType.Int);
                        cmd.Parameters.Add("@FechaInicioInvestigacion", SqlDbType.Date);
                        cmd.Parameters.Add("@FechaTerminoInvestigacion", SqlDbType.Date);
                        cmd.Parameters.Add("@ResponsableInvestigacion", SqlDbType.VarChar, 250);
                        cmd.Parameters.Add("@SolicitanteInvestigacion", SqlDbType.VarChar, 250);
                        cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50);
                        cmd.Parameters.Add("@IP", SqlDbType.VarChar, 50);
                        cmd.Parameters.Add("@MAC", SqlDbType.VarChar, 50);
                        cmd.Parameters.Add("@UsuarioDB", SqlDbType.VarChar, 50);
                        cmd.Parameters.Add("@YEAR", SqlDbType.Int);
                        cmd.Parameters.Add("@MES", SqlDbType.Int);
                        cmd.Parameters.Add("@DIA", SqlDbType.Int);
                        try
                        {
                            foreach (var item in emisionNotaPrensaDTO)
                            {
                                //cmd.Parameters["@NombreInvestigacion"].Value = item.NombreTemaEstudioInvestigacion;
                                //cmd.Parameters["@TipoEstudioInvestigacionId"].Value = item.TipoEstudioInvestigacionIds;
                                //cmd.Parameters["@FechaInicioInvestigacion"].Value = Convert.ToDateTime(item.FechaInicio);
                                //cmd.Parameters["@FechaTerminoInvestigacion"].Value = Convert.ToDateTime(item.FechaTermino);
                                //cmd.Parameters["@ResponsableInvestigacion"].Value = item.Responsable;
                                //cmd.Parameters["@SolicitanteInvestigacion"].Value = item.Solicitante;
                                cmd.Parameters["@Usuario"].Value = item.UsuarioIngresoRegistro;
                                cmd.Parameters["@IP"].Value = UtilitariosGlobales.obtenerDireccionIp();
                                cmd.Parameters["@MAC"].Value = UtilitariosGlobales.obtenerDireccionMac();

                                cmd.ExecuteNonQuery();
                            }
                            transaction.Commit();
                            respuesta = true;
                        }
                        catch (SqlException)
                        {
                            transaction.Rollback();
                            throw;
                        }
                        finally
                        {
                            conexion.Close();
                        }
                    }
                }
            }
            return respuesta;
        }
    }
}
