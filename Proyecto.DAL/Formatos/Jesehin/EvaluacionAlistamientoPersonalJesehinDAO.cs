using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Jesehin;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Jesehin
{
    public class EvaluacionAlistamientoPersonalJesehinDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<EvaluacionAlistamientoPersonalJesehinDTO> ObtenerLista()
        {
            List<EvaluacionAlistamientoPersonalJesehinDTO> lista = new List<EvaluacionAlistamientoPersonalJesehinDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoPersonalJesehinListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new EvaluacionAlistamientoPersonalJesehinDTO()
                        {
                            EvaluacionAlistamientoPersonalId = Convert.ToInt32(dr["EvaluacionAlistamientoPersonalId"]),
                            DescUnidadNaval = dr["DescUnidadNaval"].ToString(),
                            FechaEvaluacion = (dr["FechaEvaluacion"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            DNIPersonal = Convert.ToInt32(dr["DNIPersonal"]),
                            CIPPersonal = Convert.ToInt32(dr["CIPPersonal"]),
                            Cargo = dr["Cargo"].ToString(),
                            DescGrado = dr["DescGrado"].ToString(),
                            DescEspecialidad = dr["DescEspecialidad"].ToString(),
                            DescGradoPersonalMilitarActual = dr["DescGrado"].ToString(),
                            DescEspecialidadGenericaPersonalActual = dr["DescEspecialidad"].ToString(),
                            GradoJerarquico = Convert.ToDecimal(dr["GradoJerarquico"]),
                            ServicioExperiencia = Convert.ToDecimal(dr["ServicioExperiencia"]),
                            EspecializacionProfesional = Convert.ToDecimal(dr["EspecializacionProfesional"]),
                            CursoProfesionalRequerido = Convert.ToDecimal(dr["CursoProfesionalRequerido"]),
                            PuntajeTotalPersonal = Convert.ToDecimal(dr["PuntajeTotalPersonal"]),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(EvaluacionAlistamientoPersonalJesehinDTO evaluacionAlistamientoPersonalJesehinDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoPersonalJesehinRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UnidadNavalId", SqlDbType.Int);
                    cmd.Parameters["@UnidadNavalId"].Value = evaluacionAlistamientoPersonalJesehinDTO.UnidadNavalId;

                    cmd.Parameters.Add("@FechaEvaluacion", SqlDbType.Date);
                    cmd.Parameters["@FechaEvaluacion"].Value = evaluacionAlistamientoPersonalJesehinDTO.FechaEvaluacion;

                    cmd.Parameters.Add("@DNIPersonal", SqlDbType.Int);
                    cmd.Parameters["@DNIPersonal"].Value = evaluacionAlistamientoPersonalJesehinDTO.DNIPersonal;

                    cmd.Parameters.Add("@CIPPersonal", SqlDbType.Int);
                    cmd.Parameters["@CIPPersonal"].Value = evaluacionAlistamientoPersonalJesehinDTO.CIPPersonal;

                    cmd.Parameters.Add("@Cargo", SqlDbType.VarChar);
                    cmd.Parameters["@Cargo"].Value = evaluacionAlistamientoPersonalJesehinDTO.Cargo;

                    cmd.Parameters.Add("@GradoPersonalMilitarId", SqlDbType.Int);
                    cmd.Parameters["@GradoPersonalMilitarId"].Value = evaluacionAlistamientoPersonalJesehinDTO.GradoPersonalMilitarId;

                    cmd.Parameters.Add("@EspecialidadGenericaPersonalId", SqlDbType.Int);
                    cmd.Parameters["@EspecialidadGenericaPersonalId"].Value = evaluacionAlistamientoPersonalJesehinDTO.EspecialidadGenericaPersonalId;

                    cmd.Parameters.Add("@GradoPersonalMilitarActual", SqlDbType.Int);
                    cmd.Parameters["@GradoPersonalMilitarActual"].Value = evaluacionAlistamientoPersonalJesehinDTO.GradoPersonalMilitarActual;

                    cmd.Parameters.Add("@EspecialidadGenericaPersonalActual", SqlDbType.Int);
                    cmd.Parameters["@EspecialidadGenericaPersonalActual"].Value = evaluacionAlistamientoPersonalJesehinDTO.EspecialidadGenericaPersonalActual;

                    cmd.Parameters.Add("@GradoJerarquico", SqlDbType.Decimal);
                    cmd.Parameters["@GradoJerarquico"].Value = evaluacionAlistamientoPersonalJesehinDTO.GradoJerarquico;

                    cmd.Parameters.Add("@ServicioExperiencia", SqlDbType.Decimal);
                    cmd.Parameters["@ServicioExperiencia"].Value = evaluacionAlistamientoPersonalJesehinDTO.ServicioExperiencia;

                    cmd.Parameters.Add("@EspecializacionProfesional", SqlDbType.Decimal);
                    cmd.Parameters["@EspecializacionProfesional"].Value = evaluacionAlistamientoPersonalJesehinDTO.EspecializacionProfesional;

                    cmd.Parameters.Add("@CursoProfesionalRequerido", SqlDbType.Decimal);
                    cmd.Parameters["@CursoProfesionalRequerido"].Value = evaluacionAlistamientoPersonalJesehinDTO.CursoProfesionalRequerido;

                    cmd.Parameters.Add("@PuntajeTotalPersonal", SqlDbType.Decimal);
                    cmd.Parameters["@PuntajeTotalPersonal"].Value = evaluacionAlistamientoPersonalJesehinDTO.PuntajeTotalPersonal;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = evaluacionAlistamientoPersonalJesehinDTO.UsuarioIngresoRegistro;

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

        public EvaluacionAlistamientoPersonalJesehinDTO BuscarFormato(int Codigo)
        {
            EvaluacionAlistamientoPersonalJesehinDTO evaluacionAlistamientoPersonalJesehinDTO = new EvaluacionAlistamientoPersonalJesehinDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoPersonalJesehinEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EvaluacionAlistamientoPersonalId", SqlDbType.Int);
                    cmd.Parameters["@EvaluacionAlistamientoPersonalId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        evaluacionAlistamientoPersonalJesehinDTO.EvaluacionAlistamientoPersonalId = Convert.ToInt32(dr["EvaluacionAlistamientoPersonalId"]);
                        evaluacionAlistamientoPersonalJesehinDTO.UnidadNavalId = Convert.ToInt32(dr["UnidadNavalId"]);
                        evaluacionAlistamientoPersonalJesehinDTO.FechaEvaluacion = Convert.ToDateTime(dr["FechaEvaluacion"]).ToString("yyy-MM-dd");
                        evaluacionAlistamientoPersonalJesehinDTO.DNIPersonal = Convert.ToInt32(dr["DNIPersonal"]);
                        evaluacionAlistamientoPersonalJesehinDTO.CIPPersonal = Convert.ToInt32(dr["CIPPersonal"]);
                        evaluacionAlistamientoPersonalJesehinDTO.Cargo = dr["Cargo"].ToString();
                        evaluacionAlistamientoPersonalJesehinDTO.GradoPersonalMilitarId = Convert.ToInt32(dr["GradoPersonalMilitarId"]);
                        evaluacionAlistamientoPersonalJesehinDTO.EspecialidadGenericaPersonalId = Convert.ToInt32(dr["EspecialidadGenericaPersonalId"]);
                        evaluacionAlistamientoPersonalJesehinDTO.GradoPersonalMilitarActual = Convert.ToInt32(dr["GradoPersonalMilitarActual"]);
                        evaluacionAlistamientoPersonalJesehinDTO.EspecialidadGenericaPersonalActual = Convert.ToInt32(dr["EspecialidadGenericaPersonalActual"]);
                        evaluacionAlistamientoPersonalJesehinDTO.GradoJerarquico = Convert.ToDecimal(dr["GradoJerarquico"]);
                        evaluacionAlistamientoPersonalJesehinDTO.ServicioExperiencia = Convert.ToDecimal(dr["ServicioExperiencia"]);
                        evaluacionAlistamientoPersonalJesehinDTO.EspecializacionProfesional = Convert.ToDecimal(dr["EspecializacionProfesional"]);
                        evaluacionAlistamientoPersonalJesehinDTO.CursoProfesionalRequerido = Convert.ToDecimal(dr["CursoProfesionalRequerido"]); 
                        evaluacionAlistamientoPersonalJesehinDTO.PuntajeTotalPersonal = Convert.ToDecimal(dr["PuntajeTotalPersonal"]); 
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return evaluacionAlistamientoPersonalJesehinDTO;
        }

        public string ActualizaFormato(EvaluacionAlistamientoPersonalJesehinDTO evaluacionAlistamientoPersonalJesehinDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoPersonalJesehinActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@EvaluacionAlistamientoPersonalId", SqlDbType.Int);
                    cmd.Parameters["@EvaluacionAlistamientoPersonalId"].Value = evaluacionAlistamientoPersonalJesehinDTO.EvaluacionAlistamientoPersonalId;

                    cmd.Parameters.Add("@UnidadNavalId", SqlDbType.Int);
                    cmd.Parameters["@UnidadNavalId"].Value = evaluacionAlistamientoPersonalJesehinDTO.UnidadNavalId;

                    cmd.Parameters.Add("@FechaEvaluacion", SqlDbType.Date);
                    cmd.Parameters["@FechaEvaluacion"].Value = evaluacionAlistamientoPersonalJesehinDTO.FechaEvaluacion;

                    cmd.Parameters.Add("@DNIPersonal", SqlDbType.Int);
                    cmd.Parameters["@DNIPersonal"].Value = evaluacionAlistamientoPersonalJesehinDTO.DNIPersonal;

                    cmd.Parameters.Add("@CIPPersonal", SqlDbType.Int);
                    cmd.Parameters["@CIPPersonal"].Value = evaluacionAlistamientoPersonalJesehinDTO.CIPPersonal;

                    cmd.Parameters.Add("@Cargo", SqlDbType.VarChar);
                    cmd.Parameters["@Cargo"].Value = evaluacionAlistamientoPersonalJesehinDTO.Cargo;

                    cmd.Parameters.Add("@GradoPersonalMilitarId", SqlDbType.Int);
                    cmd.Parameters["@GradoPersonalMilitarId"].Value = evaluacionAlistamientoPersonalJesehinDTO.GradoPersonalMilitarId;

                    cmd.Parameters.Add("@EspecialidadGenericaPersonalId", SqlDbType.Int);
                    cmd.Parameters["@EspecialidadGenericaPersonalId"].Value = evaluacionAlistamientoPersonalJesehinDTO.EspecialidadGenericaPersonalId;

                    cmd.Parameters.Add("@GradoPersonalMilitarActual", SqlDbType.Int);
                    cmd.Parameters["@GradoPersonalMilitarActual"].Value = evaluacionAlistamientoPersonalJesehinDTO.GradoPersonalMilitarActual;

                    cmd.Parameters.Add("@EspecialidadGenericaPersonalActual", SqlDbType.Int);
                    cmd.Parameters["@EspecialidadGenericaPersonalActual"].Value = evaluacionAlistamientoPersonalJesehinDTO.EspecialidadGenericaPersonalActual;

                    cmd.Parameters.Add("@GradoJerarquico", SqlDbType.Decimal);
                    cmd.Parameters["@GradoJerarquico"].Value = evaluacionAlistamientoPersonalJesehinDTO.GradoJerarquico;

                    cmd.Parameters.Add("@ServicioExperiencia", SqlDbType.Decimal);
                    cmd.Parameters["@ServicioExperiencia"].Value = evaluacionAlistamientoPersonalJesehinDTO.ServicioExperiencia;

                    cmd.Parameters.Add("@EspecializacionProfesional", SqlDbType.Decimal);
                    cmd.Parameters["@EspecializacionProfesional"].Value = evaluacionAlistamientoPersonalJesehinDTO.EspecializacionProfesional;

                    cmd.Parameters.Add("@CursoProfesionalRequerido", SqlDbType.Decimal);
                    cmd.Parameters["@CursoProfesionalRequerido"].Value = evaluacionAlistamientoPersonalJesehinDTO.CursoProfesionalRequerido;

                    cmd.Parameters.Add("@PuntajeTotalPersonal", SqlDbType.Decimal);
                    cmd.Parameters["@PuntajeTotalPersonal"].Value = evaluacionAlistamientoPersonalJesehinDTO.PuntajeTotalPersonal;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = evaluacionAlistamientoPersonalJesehinDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(EvaluacionAlistamientoPersonalJesehinDTO evaluacionAlistamientoPersonalJesehinDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoPersonalJesehinEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EvaluacionAlistamientoPersonalId", SqlDbType.Int);
                    cmd.Parameters["@EvaluacionAlistamientoPersonalId"].Value = evaluacionAlistamientoPersonalJesehinDTO.EvaluacionAlistamientoPersonalId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = evaluacionAlistamientoPersonalJesehinDTO.UsuarioIngresoRegistro;

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

        public bool InsercionMasiva(IEnumerable<EvaluacionAlistamientoPersonalJesehinDTO> emisionNotaPrensaDTO)
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
