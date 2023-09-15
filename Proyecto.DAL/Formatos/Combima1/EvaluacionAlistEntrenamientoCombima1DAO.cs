using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Combima1;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Combima1
{
    public class EvaluacionAlistEntrenamientoCombima1DAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<EvaluacionAlistEntrenamientoCombima1DTO> ObtenerLista()
        {
            List<EvaluacionAlistEntrenamientoCombima1DTO> lista = new List<EvaluacionAlistEntrenamientoCombima1DTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoEntrenamientoCombima1Listar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new EvaluacionAlistEntrenamientoCombima1DTO()
                        {
                            EvaluacionAlistamientoEntrenamientoId = Convert.ToInt32(dr["EvaluacionAlistamientoEntrenamientoId"]),
                            DescUnidadNaval = dr["DescUnidadNaval"].ToString(),
                            NivelEntrenamiento = dr["NivelEntrenamiento"].ToString(),
                            DescCapacidadOperativa = dr["DescCapacidadOperativa"].ToString(),
                            TipoCapacidadOperativo = dr["TipoCapacidadOperativo"].ToString(),
                            Codigo = dr["Codigo"].ToString(),
                            DescEjercicioEntrenamiento = dr["DescEjercicioEntrenamiento"].ToString(),
                            AspectoEvaluacion = dr["AspectoEvaluacion"].ToString(),
                            Peso = dr["Peso"].ToString(),
                            DescCalificativoAsignadoEjercicio = dr["DescCalificativoAsignadoEjercicio"].ToString(),
                            PuntajeObtenido = Convert.ToInt32(dr["PuntajeObtenido"]),
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

        public string AgregarRegistro(EvaluacionAlistEntrenamientoCombima1DTO evaluacionAlistEntrenamientoCombima1DTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoEntrenamientoCombima1Registrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@UnidadNavalId", SqlDbType.Int);
                    cmd.Parameters["@UnidadNavalId"].Value = evaluacionAlistEntrenamientoCombima1DTO.UnidadNavalId;

                    cmd.Parameters.Add("@NivelEntrenamiento", SqlDbType.VarChar,1);
                    cmd.Parameters["@NivelEntrenamiento"].Value = evaluacionAlistEntrenamientoCombima1DTO.NivelEntrenamiento;

                    cmd.Parameters.Add("@CapacidadOperativaId", SqlDbType.Int);
                    cmd.Parameters["@CapacidadOperativaId"].Value = evaluacionAlistEntrenamientoCombima1DTO.CapacidadOperativaId;

                    cmd.Parameters.Add("@TipoCapacidadOperativo", SqlDbType.VarChar,15);
                    cmd.Parameters["@TipoCapacidadOperativo"].Value = evaluacionAlistEntrenamientoCombima1DTO.TipoCapacidadOperativo;

                    cmd.Parameters.Add("@EjercicioEntrenamientoAspectoId", SqlDbType.Int);
                    cmd.Parameters["@EjercicioEntrenamientoAspectoId"].Value = evaluacionAlistEntrenamientoCombima1DTO.EjercicioEntrenamientoAspectoId;

                    cmd.Parameters.Add("@CalificativoAsignadoEjercicioId", SqlDbType.Int);
                    cmd.Parameters["@CalificativoAsignadoEjercicioId"].Value = evaluacionAlistEntrenamientoCombima1DTO.CalificativoAsignadoEjercicioId;

                    cmd.Parameters.Add("@PuntajeObtenido", SqlDbType.Int);
                    cmd.Parameters["@PuntajeObtenido"].Value = evaluacionAlistEntrenamientoCombima1DTO.PuntajeObtenido;

                    cmd.Parameters.Add("@FechaPeriodoEvaluar", SqlDbType.Date);
                    cmd.Parameters["@FechaPeriodoEvaluar"].Value = evaluacionAlistEntrenamientoCombima1DTO.FechaPeriodoEvaluar;

                    cmd.Parameters.Add("@FechaRealizacionEjercicio", SqlDbType.Date);
                    cmd.Parameters["@FechaRealizacionEjercicio"].Value = evaluacionAlistEntrenamientoCombima1DTO.FechaRealizacionEjercicio;

                    cmd.Parameters.Add("@TiempoVigencia", SqlDbType.Int);
                    cmd.Parameters["@TiempoVigencia"].Value = evaluacionAlistEntrenamientoCombima1DTO.TiempoVigencia;

                    cmd.Parameters.Add("@FechaCaducidadEjercicio", SqlDbType.Date);
                    cmd.Parameters["@FechaCaducidadEjercicio"].Value = evaluacionAlistEntrenamientoCombima1DTO.FechaCaducidadEjercicio;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = evaluacionAlistEntrenamientoCombima1DTO.UsuarioIngresoRegistro;

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

        public EvaluacionAlistEntrenamientoCombima1DTO BuscarFormato(int Codigo)
        {
            EvaluacionAlistEntrenamientoCombima1DTO evaluacionAlistEntrenamientoCombima1DTO = new EvaluacionAlistEntrenamientoCombima1DTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoEntrenamientoCombima1Encontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EvaluacionAlistamientoEntrenamientoId", SqlDbType.Int);
                    cmd.Parameters["@EvaluacionAlistamientoEntrenamientoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        evaluacionAlistEntrenamientoCombima1DTO.EvaluacionAlistamientoEntrenamientoId = Convert.ToInt32(dr["EvaluacionAlistamientoEntrenamientoId"]);
                        evaluacionAlistEntrenamientoCombima1DTO.UnidadNavalId = Convert.ToInt32(dr["UnidadNavalId"]);
                        evaluacionAlistEntrenamientoCombima1DTO.NivelEntrenamiento = dr["NivelEntrenamiento"].ToString();
                        evaluacionAlistEntrenamientoCombima1DTO.CapacidadOperativaId = Convert.ToInt32(dr["CapacidadOperativaId"]);
                        evaluacionAlistEntrenamientoCombima1DTO.TipoCapacidadOperativo = dr["TipoCapacidadOperativo"].ToString();
                        evaluacionAlistEntrenamientoCombima1DTO.EjercicioEntrenamientoAspectoId = Convert.ToInt32(dr["EjercicioEntrenamientoAspectoId"]);
                        evaluacionAlistEntrenamientoCombima1DTO.DescEjercicioEntrenamiento = dr["DescEjercicioEntrenamiento"].ToString();
                        evaluacionAlistEntrenamientoCombima1DTO.AspectoEvaluacion = dr["AspectoEvaluacion"].ToString();
                        evaluacionAlistEntrenamientoCombima1DTO.Peso = dr["Peso"].ToString();
                        evaluacionAlistEntrenamientoCombima1DTO.CalificativoAsignadoEjercicioId = Convert.ToInt32(dr["CalificativoAsignadoEjercicioId"]);
                        evaluacionAlistEntrenamientoCombima1DTO.PuntajeObtenido = Convert.ToInt32(dr["PuntajeObtenido"]);
                        evaluacionAlistEntrenamientoCombima1DTO.FechaPeriodoEvaluar = Convert.ToDateTime(dr["FechaPeriodoEvaluar"]).ToString("yyy-MM-dd");
                        evaluacionAlistEntrenamientoCombima1DTO.FechaRealizacionEjercicio = Convert.ToDateTime(dr["FechaRealizacionEjercicio"]).ToString("yyy-MM-dd");
                        evaluacionAlistEntrenamientoCombima1DTO.TiempoVigencia = Convert.ToInt32(dr["TiempoVigencia"]);
                        evaluacionAlistEntrenamientoCombima1DTO.FechaCaducidadEjercicio = Convert.ToDateTime(dr["FechaCaducidadEjercicio"]).ToString("yyy-MM-dd"); 


                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return evaluacionAlistEntrenamientoCombima1DTO;
        }

        public string ActualizaFormato(EvaluacionAlistEntrenamientoCombima1DTO evaluacionAlistEntrenamientoCombima1DTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoEntrenamientoCombima1Actualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@EvaluacionAlistamientoEntrenamientoId", SqlDbType.Int);
                    cmd.Parameters["@EvaluacionAlistamientoEntrenamientoId"].Value = evaluacionAlistEntrenamientoCombima1DTO.EvaluacionAlistamientoEntrenamientoId;

                    cmd.Parameters.Add("@UnidadNavalId", SqlDbType.Int);
                    cmd.Parameters["@UnidadNavalId"].Value = evaluacionAlistEntrenamientoCombima1DTO.UnidadNavalId;

                    cmd.Parameters.Add("@NivelEntrenamiento", SqlDbType.VarChar,1);
                    cmd.Parameters["@NivelEntrenamiento"].Value = evaluacionAlistEntrenamientoCombima1DTO.NivelEntrenamiento;

                    cmd.Parameters.Add("@CapacidadOperativaId", SqlDbType.Int);
                    cmd.Parameters["@CapacidadOperativaId"].Value = evaluacionAlistEntrenamientoCombima1DTO.CapacidadOperativaId;

                    cmd.Parameters.Add("@TipoCapacidadOperativo", SqlDbType.VarChar,15);
                    cmd.Parameters["@TipoCapacidadOperativo"].Value = evaluacionAlistEntrenamientoCombima1DTO.TipoCapacidadOperativo;

                    cmd.Parameters.Add("@EjercicioEntrenamientoAspectoId", SqlDbType.Int);
                    cmd.Parameters["@EjercicioEntrenamientoAspectoId"].Value = evaluacionAlistEntrenamientoCombima1DTO.EjercicioEntrenamientoAspectoId;

                    cmd.Parameters.Add("@CalificativoAsignadoEjercicioId", SqlDbType.Int);
                    cmd.Parameters["@CalificativoAsignadoEjercicioId"].Value = evaluacionAlistEntrenamientoCombima1DTO.CalificativoAsignadoEjercicioId;

                    cmd.Parameters.Add("@PuntajeObtenido", SqlDbType.Int);
                    cmd.Parameters["@PuntajeObtenido"].Value = evaluacionAlistEntrenamientoCombima1DTO.PuntajeObtenido;

                    cmd.Parameters.Add("@FechaPeriodoEvaluar", SqlDbType.Date);
                    cmd.Parameters["@FechaPeriodoEvaluar"].Value = evaluacionAlistEntrenamientoCombima1DTO.FechaPeriodoEvaluar;

                    cmd.Parameters.Add("@FechaRealizacionEjercicio", SqlDbType.Date);
                    cmd.Parameters["@FechaRealizacionEjercicio"].Value = evaluacionAlistEntrenamientoCombima1DTO.FechaRealizacionEjercicio;

                    cmd.Parameters.Add("@TiempoVigencia", SqlDbType.Int);
                    cmd.Parameters["@TiempoVigencia"].Value = evaluacionAlistEntrenamientoCombima1DTO.TiempoVigencia;

                    cmd.Parameters.Add("@FechaCaducidadEjercicio", SqlDbType.Date);
                    cmd.Parameters["@FechaCaducidadEjercicio"].Value = evaluacionAlistEntrenamientoCombima1DTO.FechaCaducidadEjercicio;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = evaluacionAlistEntrenamientoCombima1DTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(EvaluacionAlistEntrenamientoCombima1DTO evaluacionAlistEntrenamientoCombima1DTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoEntrenamientoCombima1Eliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EvaluacionAlistamientoEntrenamientoId", SqlDbType.Int);
                    cmd.Parameters["@EvaluacionAlistamientoEntrenamientoId"].Value = evaluacionAlistEntrenamientoCombima1DTO.EvaluacionAlistamientoEntrenamientoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = evaluacionAlistEntrenamientoCombima1DTO.UsuarioIngresoRegistro;

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
        public bool InsercionMasiva(IEnumerable<EvaluacionAlistEntrenamientoCombima1DTO> evaluacionAlistEntrenamientoCombima1DTO)
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
                            foreach (var item in evaluacionAlistEntrenamientoCombima1DTO)
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
