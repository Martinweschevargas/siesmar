using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comescla;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comescla
{
    public class EvaluacionAlistamientoEntrenamientoComesclaDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<EvaluacionAlistamientoEntrenamientoComesclaDTO> ObtenerLista()
        {
            List<EvaluacionAlistamientoEntrenamientoComesclaDTO> lista = new List<EvaluacionAlistamientoEntrenamientoComesclaDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoEntrenamientoComesclaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new EvaluacionAlistamientoEntrenamientoComesclaDTO()
                        {
                            EvaluacionAlistamientoEntrenamientoId = Convert.ToInt32(dr["EvaluacionAlistamientoEntrenamientoId"]),
                            UnidadNavalId = Convert.ToInt32(dr["UnidadNavalId"]),
                            NivelEntrenamientoId = Convert.ToInt32(dr["NivelEntrenamientoId"]),
                            CapacidadOperativaId = Convert.ToInt32(dr["CapacidadOperativaId"]),
                            TipoCapacidadOperativa = dr["TipoCapacidadOperativa"].ToString(),
                            CodigoEjercicioEntrenamiento = Convert.ToInt32(dr["CodigoEjercicioEntrenamiento"]),
                            EjercicioEntrenamiento = Convert.ToInt32(dr["EjercicioEntrenamiento"]),
                            EjercicioEntrenamientoAspectos = Convert.ToInt32(dr["EjercicioEntrenamientoAspectos"]),
                            PesoEjercicioEntrenamiento = Convert.ToInt32(dr["PesoEjercicioEntrenamiento"]),
                            CalificativoAsignadoEjercicioId = Convert.ToInt32(dr["CalificativoAsignadoEjercicioId"]),
                            FechaPeriodoEvaluar = (dr["FechaPeriodoEvaluar"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            FechaRealizacionEjercicio = (dr["FechaRealizacionEjercicio"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            TiempoVigencia = Convert.ToInt32(dr["TiempoVigencia"]),
 

                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(EvaluacionAlistamientoEntrenamientoComesclaDTO evaluacionAlistamientoEntrenamientoComesclaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoEntrenamientoComesclaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UnidadNavalId", SqlDbType.Int);
                    cmd.Parameters["@UnidadNavalId"].Value = evaluacionAlistamientoEntrenamientoComesclaDTO.UnidadNavalId;

                    cmd.Parameters.Add("@NivelEntrenamientoId", SqlDbType.Int);
                    cmd.Parameters["@NivelEntrenamientoId"].Value = evaluacionAlistamientoEntrenamientoComesclaDTO.NivelEntrenamientoId;

                    cmd.Parameters.Add("@CapacidadOperativaId", SqlDbType.Int);
                    cmd.Parameters["@CapacidadOperativaId"].Value = evaluacionAlistamientoEntrenamientoComesclaDTO.CapacidadOperativaId;

                    cmd.Parameters.Add("@TipoCapacidadOperativa", SqlDbType.NChar,1);
                    cmd.Parameters["@TipoCapacidadOperativa"].Value = evaluacionAlistamientoEntrenamientoComesclaDTO.TipoCapacidadOperativa;

                    cmd.Parameters.Add("@CodigoEjercicioEntrenamiento", SqlDbType.Int);
                    cmd.Parameters["@CodigoEjercicioEntrenamiento"].Value = evaluacionAlistamientoEntrenamientoComesclaDTO.CodigoEjercicioEntrenamiento;

                    cmd.Parameters.Add("@EjercicioEntrenamiento", SqlDbType.Int);
                    cmd.Parameters["@EjercicioEntrenamiento"].Value = evaluacionAlistamientoEntrenamientoComesclaDTO.EjercicioEntrenamiento;

                    cmd.Parameters.Add("@EjercicioEntrenamientoAspectos", SqlDbType.Int);
                    cmd.Parameters["@EjercicioEntrenamientoAspectos"].Value = evaluacionAlistamientoEntrenamientoComesclaDTO.EjercicioEntrenamientoAspectos;

                    cmd.Parameters.Add("@PesoEjercicioEntrenamiento", SqlDbType.Int);
                    cmd.Parameters["@PesoEjercicioEntrenamiento"].Value = evaluacionAlistamientoEntrenamientoComesclaDTO.PesoEjercicioEntrenamiento;

                    cmd.Parameters.Add("@CalificativoAsignadoEjercicioId", SqlDbType.Int);
                    cmd.Parameters["@CalificativoAsignadoEjercicioId"].Value = evaluacionAlistamientoEntrenamientoComesclaDTO.CalificativoAsignadoEjercicioId;

                    cmd.Parameters.Add("@FechaPeriodoEvaluar", SqlDbType.Date);
                    cmd.Parameters["@FechaPeriodoEvaluar"].Value = evaluacionAlistamientoEntrenamientoComesclaDTO.FechaPeriodoEvaluar;

                    cmd.Parameters.Add("@FechaRealizacionEjercicio", SqlDbType.Date);
                    cmd.Parameters["@FechaRealizacionEjercicio"].Value = evaluacionAlistamientoEntrenamientoComesclaDTO.FechaRealizacionEjercicio;

                    cmd.Parameters.Add("@TiempoVigencia", SqlDbType.Int);
                    cmd.Parameters["@TiempoVigencia"].Value = evaluacionAlistamientoEntrenamientoComesclaDTO.TiempoVigencia;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = evaluacionAlistamientoEntrenamientoComesclaDTO.UsuarioIngresoRegistro;

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

        public EvaluacionAlistamientoEntrenamientoComesclaDTO BuscarFormato(int Codigo)
        {
            EvaluacionAlistamientoEntrenamientoComesclaDTO evaluacionAlistamientoEntrenamientoComesclaDTO = new EvaluacionAlistamientoEntrenamientoComesclaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoEntrenamientoComesclaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EvaluacionAlistamientoEntrenamientoComesclaId", SqlDbType.Int);
                    cmd.Parameters["@EvaluacionAlistamientoEntrenamientoComesclaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        evaluacionAlistamientoEntrenamientoComesclaDTO.EvaluacionAlistamientoEntrenamientoId = Convert.ToInt32(dr["EvaluacionAlistamientoEntrenamientoId"]);
                        evaluacionAlistamientoEntrenamientoComesclaDTO.UnidadNavalId = Convert.ToInt32(dr["UnidadNavalId"]);
                        evaluacionAlistamientoEntrenamientoComesclaDTO.NivelEntrenamientoId = Convert.ToInt32(dr["NivelEntrenamientoId"]);
                        evaluacionAlistamientoEntrenamientoComesclaDTO.CapacidadOperativaId = Convert.ToInt32(dr["CapacidadOperativaId"]);
                        evaluacionAlistamientoEntrenamientoComesclaDTO.TipoCapacidadOperativa = dr["TipoCapacidadOperativa"].ToString();
                        evaluacionAlistamientoEntrenamientoComesclaDTO.CodigoEjercicioEntrenamiento = Convert.ToInt32(dr["CodigoEjercicioEntrenamiento"]);
                        evaluacionAlistamientoEntrenamientoComesclaDTO.EjercicioEntrenamiento = Convert.ToInt32(dr["EjercicioEntrenamiento"]);
                        evaluacionAlistamientoEntrenamientoComesclaDTO.EjercicioEntrenamientoAspectos = Convert.ToInt32(dr["EjercicioEntrenamientoAspectos"]);
                        evaluacionAlistamientoEntrenamientoComesclaDTO.PesoEjercicioEntrenamiento = Convert.ToInt32(dr["PesoEjercicioEntrenamiento"]);
                        evaluacionAlistamientoEntrenamientoComesclaDTO.CalificativoAsignadoEjercicioId = Convert.ToInt32(dr["CalificativoAsignadoEjercicioId"]);
                        evaluacionAlistamientoEntrenamientoComesclaDTO.FechaPeriodoEvaluar = Convert.ToDateTime(dr["FechaPeriodoEvaluar"]).ToString("yyy-MM-dd");
                        evaluacionAlistamientoEntrenamientoComesclaDTO.FechaRealizacionEjercicio = Convert.ToDateTime(dr["FechaRealizacionEjercicio"]).ToString("yyy-MM-dd");
                        evaluacionAlistamientoEntrenamientoComesclaDTO.TiempoVigencia = Convert.ToInt32(dr["TiempoVigencia"]); 
 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return evaluacionAlistamientoEntrenamientoComesclaDTO;
        }

        public string ActualizaFormato(EvaluacionAlistamientoEntrenamientoComesclaDTO evaluacionAlistamientoEntrenamientoComesclaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoEntrenamientoComesclaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@EvaluacionAlistamientoEntrenamientoId", SqlDbType.Int);
                    cmd.Parameters["@EvaluacionAlistamientoEntrenamientoId"].Value = evaluacionAlistamientoEntrenamientoComesclaDTO.EvaluacionAlistamientoEntrenamientoId;

                    cmd.Parameters.Add("@UnidadNavalId", SqlDbType.Int);
                    cmd.Parameters["@UnidadNavalId"].Value = evaluacionAlistamientoEntrenamientoComesclaDTO.UnidadNavalId;

                    cmd.Parameters.Add("@NivelEntrenamientoId", SqlDbType.Int);
                    cmd.Parameters["@NivelEntrenamientoId"].Value = evaluacionAlistamientoEntrenamientoComesclaDTO.NivelEntrenamientoId;

                    cmd.Parameters.Add("@CapacidadOperativaId", SqlDbType.Int);
                    cmd.Parameters["@CapacidadOperativaId"].Value = evaluacionAlistamientoEntrenamientoComesclaDTO.CapacidadOperativaId;

                    cmd.Parameters.Add("@TipoCapacidadOperativa", SqlDbType.NChar,1);
                    cmd.Parameters["@TipoCapacidadOperativa"].Value = evaluacionAlistamientoEntrenamientoComesclaDTO.TipoCapacidadOperativa;

                    cmd.Parameters.Add("@CodigoEjercicioEntrenamiento", SqlDbType.Int);
                    cmd.Parameters["@CodigoEjercicioEntrenamiento"].Value = evaluacionAlistamientoEntrenamientoComesclaDTO.CodigoEjercicioEntrenamiento;

                    cmd.Parameters.Add("@EjercicioEntrenamiento", SqlDbType.Int);
                    cmd.Parameters["@EjercicioEntrenamiento"].Value = evaluacionAlistamientoEntrenamientoComesclaDTO.EjercicioEntrenamiento;

                    cmd.Parameters.Add("@EjercicioEntrenamientoAspectos", SqlDbType.Int);
                    cmd.Parameters["@EjercicioEntrenamientoAspectos"].Value = evaluacionAlistamientoEntrenamientoComesclaDTO.EjercicioEntrenamientoAspectos;

                    cmd.Parameters.Add("@PesoEjercicioEntrenamiento", SqlDbType.Int);
                    cmd.Parameters["@PesoEjercicioEntrenamiento"].Value = evaluacionAlistamientoEntrenamientoComesclaDTO.PesoEjercicioEntrenamiento;

                    cmd.Parameters.Add("@CalificativoAsignadoEjercicioId", SqlDbType.Int);
                    cmd.Parameters["@CalificativoAsignadoEjercicioId"].Value = evaluacionAlistamientoEntrenamientoComesclaDTO.CalificativoAsignadoEjercicioId;

                    cmd.Parameters.Add("@FechaPeriodoEvaluar", SqlDbType.Date);
                    cmd.Parameters["@FechaPeriodoEvaluar"].Value = evaluacionAlistamientoEntrenamientoComesclaDTO.FechaPeriodoEvaluar;

                    cmd.Parameters.Add("@FechaRealizacionEjercicio", SqlDbType.Date);
                    cmd.Parameters["@FechaRealizacionEjercicio"].Value = evaluacionAlistamientoEntrenamientoComesclaDTO.FechaRealizacionEjercicio;

                    cmd.Parameters.Add("@TiempoVigencia", SqlDbType.Int);
                    cmd.Parameters["@TiempoVigencia"].Value = evaluacionAlistamientoEntrenamientoComesclaDTO.TiempoVigencia;


                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = evaluacionAlistamientoEntrenamientoComesclaDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(EvaluacionAlistamientoEntrenamientoComesclaDTO evaluacionAlistamientoEntrenamientoComesclaDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoEntrenamientoComesclaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EvaluacionAlistamientoEntrenamientoComesclaId", SqlDbType.Int);
                    cmd.Parameters["@EvaluacionAlistamientoEntrenamientoComesclaId"].Value = evaluacionAlistamientoEntrenamientoComesclaDTO.EvaluacionAlistamientoEntrenamientoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = evaluacionAlistamientoEntrenamientoComesclaDTO.UsuarioIngresoRegistro;

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
        public bool InsercionMasiva(IEnumerable<EvaluacionAlistamientoEntrenamientoComesclaDTO> evalAlistamientoEntrenamientoComesclaDTO)
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
                            foreach (var item in evalAlistamientoEntrenamientoComesclaDTO)
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
