using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comfas;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comfas
{
    public class EvaluacionAlistamientoEntrenamientoComfasDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<EvaluacionAlistamientoEntrenamientoComfasDTO> ObtenerLista()
        {
            List<EvaluacionAlistamientoEntrenamientoComfasDTO> lista = new List<EvaluacionAlistamientoEntrenamientoComfasDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoEntrenamientoComfasListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new EvaluacionAlistamientoEntrenamientoComfasDTO()
                        {
                            EvaluacionAlistamientoEntrenamientoId = Convert.ToInt32(dr["EvaluacionAlistamientoEntrenamientoId"]),
                            DescUnidadNaval = dr["DescUnidadNaval"].ToString(),
                            NivelEntrenamiento = dr["NivelEntrenamiento"].ToString(),
                            DescCapacidadOperativa = dr["DescCapacidadOperativa"].ToString(),
                            CodigoEjercicioEntrenamiento = Convert.ToInt32(dr["CodigoEjercicioEntrenamiento"]),
                            DescEjercicioEntrenamiento = dr["DescEjercicioEntrenamiento"].ToString(),
                            DescEjercicioEntrenamientoAspecto = dr["DescEjercicioEntrenamientoAspecto"].ToString(),
                            PesoEjercicioEntrenamienti = Convert.ToInt32(dr["PesoEjercicioEntrenamienti"]),
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

        public string AgregarRegistro(EvaluacionAlistamientoEntrenamientoComfasDTO evaluacionAlistamientoEntrenamientoComfasDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoEntrenamientoComfasRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                   
                    cmd.Parameters.Add("@UnidadNavalId", SqlDbType.Int);
                    cmd.Parameters["@UnidadNavalId"].Value = evaluacionAlistamientoEntrenamientoComfasDTO.UnidadNavalId;

                    cmd.Parameters.Add("@NivelEntrenamiento", SqlDbType.VarChar,1);
                    cmd.Parameters["@NivelEntrenamiento"].Value = evaluacionAlistamientoEntrenamientoComfasDTO.NivelEntrenamiento;

                    cmd.Parameters.Add("@CapacidadOperativaId", SqlDbType.Int);
                    cmd.Parameters["@CapacidadOperativaId"].Value = evaluacionAlistamientoEntrenamientoComfasDTO.CapacidadOperativaId;

                    cmd.Parameters.Add("@CodigoEjercicioEntrenamiento", SqlDbType.Int);
                    cmd.Parameters["@CodigoEjercicioEntrenamiento"].Value = evaluacionAlistamientoEntrenamientoComfasDTO.CodigoEjercicioEntrenamiento;

                    cmd.Parameters.Add("@EjercicioEntrenamientoId", SqlDbType.Int);
                    cmd.Parameters["@EjercicioEntrenamientoId"].Value = evaluacionAlistamientoEntrenamientoComfasDTO.EjercicioEntrenamientoId;

                    cmd.Parameters.Add("@EjercicioEntrenamientoAspectoId", SqlDbType.Int);
                    cmd.Parameters["@EjercicioEntrenamientoAspectoId"].Value = evaluacionAlistamientoEntrenamientoComfasDTO.EjercicioEntrenamientoAspectoId;

                    cmd.Parameters.Add("@PesoEjercicioEntrenamienti", SqlDbType.Int);
                    cmd.Parameters["@PesoEjercicioEntrenamienti"].Value = evaluacionAlistamientoEntrenamientoComfasDTO.PesoEjercicioEntrenamienti;

                    cmd.Parameters.Add("@CalificativoAsignadoEjercicioId", SqlDbType.Int);
                    cmd.Parameters["@CalificativoAsignadoEjercicioId"].Value = evaluacionAlistamientoEntrenamientoComfasDTO.CalificativoAsignadoEjercicioId;

                    cmd.Parameters.Add("@FechaPeriodoEvaluar", SqlDbType.Date);
                    cmd.Parameters["@FechaPeriodoEvaluar"].Value = evaluacionAlistamientoEntrenamientoComfasDTO.FechaPeriodoEvaluar;

                    cmd.Parameters.Add("@FechaRealizacionEjercicio", SqlDbType.Date);
                    cmd.Parameters["@FechaRealizacionEjercicio"].Value = evaluacionAlistamientoEntrenamientoComfasDTO.FechaRealizacionEjercicio;

                    cmd.Parameters.Add("@TiempoVigencia", SqlDbType.Int);
                    cmd.Parameters["@TiempoVigencia"].Value = evaluacionAlistamientoEntrenamientoComfasDTO.TiempoVigencia;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = evaluacionAlistamientoEntrenamientoComfasDTO.UsuarioIngresoRegistro;

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

        public EvaluacionAlistamientoEntrenamientoComfasDTO BuscarFormato(int Codigo)
        {
            EvaluacionAlistamientoEntrenamientoComfasDTO evaluacionAlistamientoEntrenamientoComfasDTO = new EvaluacionAlistamientoEntrenamientoComfasDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoEntrenamientoComfasEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EvaluacionAlistamientoEntrenamientoId", SqlDbType.Int);
                    cmd.Parameters["@EvaluacionAlistamientoEntrenamientoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        evaluacionAlistamientoEntrenamientoComfasDTO.EvaluacionAlistamientoEntrenamientoId = Convert.ToInt32(dr["EvaluacionAlistamientoEntrenamientoId"]);
                        evaluacionAlistamientoEntrenamientoComfasDTO.UnidadNavalId = Convert.ToInt32(dr["UnidadNavalId"]);
                        evaluacionAlistamientoEntrenamientoComfasDTO.NivelEntrenamiento = dr["NivelEntrenamiento"].ToString();
                        evaluacionAlistamientoEntrenamientoComfasDTO.CapacidadOperativaId = Convert.ToInt32(dr["CapacidadOperativaId"]);
                        evaluacionAlistamientoEntrenamientoComfasDTO.CodigoEjercicioEntrenamiento = Convert.ToInt32(dr["CodigoEjercicioEntrenamiento"]);
                        evaluacionAlistamientoEntrenamientoComfasDTO.EjercicioEntrenamientoId = Convert.ToInt32(dr["EjercicioEntrenamientoId"]);
                        evaluacionAlistamientoEntrenamientoComfasDTO.EjercicioEntrenamientoAspectoId = Convert.ToInt32(dr["EjercicioEntrenamientoAspectoId"]);
                        evaluacionAlistamientoEntrenamientoComfasDTO.PesoEjercicioEntrenamienti = Convert.ToInt32(dr["PesoEjercicioEntrenamienti"]);
                        evaluacionAlistamientoEntrenamientoComfasDTO.CalificativoAsignadoEjercicioId = Convert.ToInt32(dr["CalificativoAsignadoEjercicioId"]);
                        evaluacionAlistamientoEntrenamientoComfasDTO.FechaPeriodoEvaluar = Convert.ToDateTime(dr["FechaPeriodoEvaluar"]).ToString("yyy-MM-dd");
                        evaluacionAlistamientoEntrenamientoComfasDTO.FechaRealizacionEjercicio = Convert.ToDateTime(dr["FechaRealizacionEjercicio"]).ToString("yyy-MM-dd");
                        evaluacionAlistamientoEntrenamientoComfasDTO.TiempoVigencia = Convert.ToInt32(dr["TiempoVigencia"]); 
 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return evaluacionAlistamientoEntrenamientoComfasDTO;
        }

        public string ActualizaFormato(EvaluacionAlistamientoEntrenamientoComfasDTO evaluacionAlistamientoEntrenamientoComfasDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoEntrenamientoComfasActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@EvaluacionAlistamientoEntrenamientoId", SqlDbType.Int);
                    cmd.Parameters["@EvaluacionAlistamientoEntrenamientoId"].Value = evaluacionAlistamientoEntrenamientoComfasDTO.EvaluacionAlistamientoEntrenamientoId;

                    cmd.Parameters.Add("@UnidadNavalId", SqlDbType.Int);
                    cmd.Parameters["@UnidadNavalId"].Value = evaluacionAlistamientoEntrenamientoComfasDTO.UnidadNavalId;

                    cmd.Parameters.Add("@NivelEntrenamiento", SqlDbType.VarChar,1);
                    cmd.Parameters["@NivelEntrenamiento"].Value = evaluacionAlistamientoEntrenamientoComfasDTO.NivelEntrenamiento;

                    cmd.Parameters.Add("@CapacidadOperativaId", SqlDbType.Int);
                    cmd.Parameters["@CapacidadOperativaId"].Value = evaluacionAlistamientoEntrenamientoComfasDTO.CapacidadOperativaId;

                    cmd.Parameters.Add("@CodigoEjercicioEntrenamiento", SqlDbType.Int);
                    cmd.Parameters["@CodigoEjercicioEntrenamiento"].Value = evaluacionAlistamientoEntrenamientoComfasDTO.CodigoEjercicioEntrenamiento;

                    cmd.Parameters.Add("@EjercicioEntrenamientoId", SqlDbType.Int);
                    cmd.Parameters["@EjercicioEntrenamientoId"].Value = evaluacionAlistamientoEntrenamientoComfasDTO.EjercicioEntrenamientoId;

                    cmd.Parameters.Add("@EjercicioEntrenamientoAspectoId", SqlDbType.Int);
                    cmd.Parameters["@EjercicioEntrenamientoAspectoId"].Value = evaluacionAlistamientoEntrenamientoComfasDTO.EjercicioEntrenamientoAspectoId;

                    cmd.Parameters.Add("@PesoEjercicioEntrenamienti", SqlDbType.Int);
                    cmd.Parameters["@PesoEjercicioEntrenamienti"].Value = evaluacionAlistamientoEntrenamientoComfasDTO.PesoEjercicioEntrenamienti;

                    cmd.Parameters.Add("@CalificativoAsignadoEjercicioId", SqlDbType.Int);
                    cmd.Parameters["@CalificativoAsignadoEjercicioId"].Value = evaluacionAlistamientoEntrenamientoComfasDTO.CalificativoAsignadoEjercicioId;

                    cmd.Parameters.Add("@FechaPeriodoEvaluar", SqlDbType.Date);
                    cmd.Parameters["@FechaPeriodoEvaluar"].Value = evaluacionAlistamientoEntrenamientoComfasDTO.FechaPeriodoEvaluar;

                    cmd.Parameters.Add("@FechaRealizacionEjercicio", SqlDbType.Date);
                    cmd.Parameters["@FechaRealizacionEjercicio"].Value = evaluacionAlistamientoEntrenamientoComfasDTO.FechaRealizacionEjercicio;

                    cmd.Parameters.Add("@TiempoVigencia", SqlDbType.Int);
                    cmd.Parameters["@TiempoVigencia"].Value = evaluacionAlistamientoEntrenamientoComfasDTO.TiempoVigencia;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = evaluacionAlistamientoEntrenamientoComfasDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(EvaluacionAlistamientoEntrenamientoComfasDTO evaluacionAlistamientoEntrenamientoComfasDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoEntrenamientoComfasEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EvaluacionAlistamientoEntrenamientoId", SqlDbType.Int);
                    cmd.Parameters["@EvaluacionAlistamientoEntrenamientoId"].Value = evaluacionAlistamientoEntrenamientoComfasDTO.EvaluacionAlistamientoEntrenamientoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = evaluacionAlistamientoEntrenamientoComfasDTO.UsuarioIngresoRegistro;

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
        public bool InsercionMasiva(IEnumerable<EvaluacionAlistamientoEntrenamientoComfasDTO> evaluacionAlistamientoEntrenamientoComfasDTO)
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
                            foreach (var item in evaluacionAlistamientoEntrenamientoComfasDTO)
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
