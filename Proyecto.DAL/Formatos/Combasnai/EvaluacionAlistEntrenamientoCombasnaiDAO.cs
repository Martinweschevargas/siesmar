using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Combasnai;
using Marina.Siesmar.Utilitarios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Combasnai
{
    public class EvaluacionAlistEntrenamientoCombasnaiDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<EvaluacionAlistEntrenamientoCombasnaiDTO> ObtenerLista()
        {
            List<EvaluacionAlistEntrenamientoCombasnaiDTO> lista = new List<EvaluacionAlistEntrenamientoCombasnaiDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoPersonalCombasnaiListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new EvaluacionAlistEntrenamientoCombasnaiDTO()
                        {
                            EvaluacionAlistamientoEntrenamientoId = Convert.ToInt32(dr["EvaluacionAlistamientoEntrenamientoId"]),
                            DescUnidadNaval = dr["DescUnidadNaval"].ToString(),
                            NivelEntrenamiento = dr["NivelEntrenamiento"].ToString(),
                            DescCapacidadOperativa = dr["DescCapacidadOperativa"].ToString(),
                            TipoCapacidadOperativa = dr["TipoCapacidadOperativa"].ToString(),
                            CodigoEjercicioEntrenamiento = Convert.ToInt32(dr["CodigoEjercicioEntrenamiento"]),
                            EjercicioEntrenamiento = Convert.ToInt32(dr["EjercicioEntrenamiento"]),
                            EjercicioEntrenamientoAspectos = dr["EjercicioEntrenamientoAspectos"].ToString(),
                            PesoEjercicioEntrenamiento = Convert.ToInt32(dr["PesoEjercicioEntrenamiento"]),
                            DescCalificativoAsignadoEjercicio = dr["DescCalificativoAsignadoEjercicio"].ToString(),
                            FechaPeriodoEvaluar = (dr["FechaPeriodoEvaluar"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            FechaRealizacionEjercicio = (dr["FechaRealizacionEjercicio"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            TiempoVigencia = Convert.ToInt32(dr["TiempoVigencia"]),
 

                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(EvaluacionAlistEntrenamientoCombasnaiDTO evaluacionAlistamientoEntrenamientoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoPersonalCombasnaiRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UnidadNavalId", SqlDbType.Int);
                    cmd.Parameters["@UnidadNavalId"].Value = evaluacionAlistamientoEntrenamientoDTO.UnidadNavalId;

                    cmd.Parameters.Add("@NivelEntrenamiento", SqlDbType.VarChar,1);
                    cmd.Parameters["@NivelEntrenamiento"].Value = evaluacionAlistamientoEntrenamientoDTO.NivelEntrenamiento;

                    cmd.Parameters.Add("@CapacidadOperativaId", SqlDbType.Int);
                    cmd.Parameters["@CapacidadOperativaId"].Value = evaluacionAlistamientoEntrenamientoDTO.CapacidadOperativaId;

                    cmd.Parameters.Add("@TipoCapacidadOperativa", SqlDbType.NChar,1);
                    cmd.Parameters["@TipoCapacidadOperativa"].Value = evaluacionAlistamientoEntrenamientoDTO.TipoCapacidadOperativa;

                    cmd.Parameters.Add("@EjercicioEntrenamientoAspectoId", SqlDbType.Int);
                    cmd.Parameters["@EjercicioEntrenamientoAspectoId"].Value = evaluacionAlistamientoEntrenamientoDTO.EjercicioEntrenamientoAspectoId;

                    cmd.Parameters.Add("@CalificativoAsignadoEjercicioId", SqlDbType.Int);
                    cmd.Parameters["@CalificativoAsignadoEjercicioId"].Value = evaluacionAlistamientoEntrenamientoDTO.CalificativoAsignadoEjercicioId;

                    cmd.Parameters.Add("@FechaPeriodoEvaluar", SqlDbType.Date);
                    cmd.Parameters["@FechaPeriodoEvaluar"].Value = evaluacionAlistamientoEntrenamientoDTO.FechaPeriodoEvaluar;

                    cmd.Parameters.Add("@FechaRealizacionEjercicio", SqlDbType.Date);
                    cmd.Parameters["@FechaRealizacionEjercicio"].Value = evaluacionAlistamientoEntrenamientoDTO.FechaRealizacionEjercicio;

                    cmd.Parameters.Add("@TiempoVigencia", SqlDbType.Int);
                    cmd.Parameters["@TiempoVigencia"].Value = evaluacionAlistamientoEntrenamientoDTO.TiempoVigencia;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

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

        public EvaluacionAlistEntrenamientoCombasnaiDTO BuscarFormato(int Codigo)
        {
            EvaluacionAlistEntrenamientoCombasnaiDTO evaluacionAlistamientoEntrenamientoDTO = new EvaluacionAlistEntrenamientoCombasnaiDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoPersonalCombasnaiEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EvaluacionAlistamientoEntrenamientoId", SqlDbType.Int);
                    cmd.Parameters["@EvaluacionAlistamientoEntrenamientoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        evaluacionAlistamientoEntrenamientoDTO.EvaluacionAlistamientoEntrenamientoId = Convert.ToInt32(dr["EvaluacionAlistamientoEntrenamientoId"]);
                        evaluacionAlistamientoEntrenamientoDTO.UnidadNavalId = Convert.ToInt32(dr["UnidadNavalId"]);
                        evaluacionAlistamientoEntrenamientoDTO.NivelEntrenamiento = dr["NivelEntrenamiento"].ToString();
                        evaluacionAlistamientoEntrenamientoDTO.CapacidadOperativaId = Convert.ToInt32(dr["CapacidadOperativaId"]);
                        evaluacionAlistamientoEntrenamientoDTO.EjercicioEntrenamientoAspectoId = Convert.ToInt32(dr["EjercicioEntrenamientoAspectoId"]);
                        evaluacionAlistamientoEntrenamientoDTO.TipoCapacidadOperativa = dr["TipoCapacidadOperativa"].ToString();
                        evaluacionAlistamientoEntrenamientoDTO.CodigoEjercicioEntrenamiento = Convert.ToInt32(dr["CodigoEjercicioEntrenamiento"]);
                        evaluacionAlistamientoEntrenamientoDTO.EjercicioEntrenamiento = Convert.ToInt32(dr["EjercicioEntrenamiento"]);
                        evaluacionAlistamientoEntrenamientoDTO.EjercicioEntrenamientoAspectos = dr["EjercicioEntrenamientoAspectos"].ToString();
                        evaluacionAlistamientoEntrenamientoDTO.PesoEjercicioEntrenamiento = Convert.ToInt32(dr["PesoEjercicioEntrenamiento"]);
                        evaluacionAlistamientoEntrenamientoDTO.CalificativoAsignadoEjercicioId = Convert.ToInt32(dr["CalificativoAsignadoEjercicioId"]);
                        evaluacionAlistamientoEntrenamientoDTO.FechaPeriodoEvaluar = Convert.ToDateTime(dr["FechaPeriodoEvaluar"]).ToString("yyy-MM-dd");
                        evaluacionAlistamientoEntrenamientoDTO.FechaRealizacionEjercicio = Convert.ToDateTime(dr["FechaRealizacionEjercicio"]).ToString("yyy-MM-dd");
                        evaluacionAlistamientoEntrenamientoDTO.TiempoVigencia = Convert.ToInt32(dr["TiempoVigencia"]); 
 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return evaluacionAlistamientoEntrenamientoDTO;
        }

        public string ActualizaFormato(EvaluacionAlistEntrenamientoCombasnaiDTO evaluacionAlistamientoEntrenamientoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoPersonalCombasnaiActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@EvaluacionAlistamientoEntrenamientoId", SqlDbType.Int);
                    cmd.Parameters["@EvaluacionAlistamientoEntrenamientoId"].Value = evaluacionAlistamientoEntrenamientoDTO.EvaluacionAlistamientoEntrenamientoId;

                    cmd.Parameters.Add("@UnidadNavalId", SqlDbType.Int);
                    cmd.Parameters["@UnidadNavalId"].Value = evaluacionAlistamientoEntrenamientoDTO.UnidadNavalId;

                    cmd.Parameters.Add("@NivelEntrenamiento", SqlDbType.VarChar, 1);
                    cmd.Parameters["@NivelEntrenamiento"].Value = evaluacionAlistamientoEntrenamientoDTO.NivelEntrenamiento;

                    cmd.Parameters.Add("@CapacidadOperativaId", SqlDbType.Int);
                    cmd.Parameters["@CapacidadOperativaId"].Value = evaluacionAlistamientoEntrenamientoDTO.CapacidadOperativaId;

                    cmd.Parameters.Add("@EjercicioEntrenamientoAspectoId", SqlDbType.Int);
                    cmd.Parameters["@EjercicioEntrenamientoAspectoId"].Value = evaluacionAlistamientoEntrenamientoDTO.EjercicioEntrenamientoAspectoId;

                    cmd.Parameters.Add("@PesoEjercicioEntrenamiento", SqlDbType.Int);
                    cmd.Parameters["@PesoEjercicioEntrenamiento"].Value = evaluacionAlistamientoEntrenamientoDTO.PesoEjercicioEntrenamiento;

                    cmd.Parameters.Add("@CalificativoAsignadoEjercicioId", SqlDbType.Int);
                    cmd.Parameters["@CalificativoAsignadoEjercicioId"].Value = evaluacionAlistamientoEntrenamientoDTO.CalificativoAsignadoEjercicioId;

                    cmd.Parameters.Add("@FechaPeriodoEvaluar", SqlDbType.Date);
                    cmd.Parameters["@FechaPeriodoEvaluar"].Value = evaluacionAlistamientoEntrenamientoDTO.FechaPeriodoEvaluar;

                    cmd.Parameters.Add("@FechaRealizacionEjercicio", SqlDbType.Date);
                    cmd.Parameters["@FechaRealizacionEjercicio"].Value = evaluacionAlistamientoEntrenamientoDTO.FechaRealizacionEjercicio;

                    cmd.Parameters.Add("@TiempoVigencia", SqlDbType.Int);
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

        public bool EliminarFormato(EvaluacionAlistEntrenamientoCombasnaiDTO evaluacionAlistamientoEntrenamientoDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoPersonalCombasnaiEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EvaluacionAlistamientoEntrenamientoId", SqlDbType.Int);
                    cmd.Parameters["@EvaluacionAlistamientoEntrenamientoId"].Value = evaluacionAlistamientoEntrenamientoDTO.EvaluacionAlistamientoEntrenamientoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = evaluacionAlistamientoEntrenamientoDTO.UsuarioIngresoRegistro;

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
        public bool InsercionMasiva(IEnumerable<EvaluacionAlistEntrenamientoCombasnaiDTO> evaluacionAlistamientoEntrenamientoDTO)
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
                            foreach (var item in evaluacionAlistamientoEntrenamientoDTO)
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
