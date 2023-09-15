using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Combima1;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Combima1
{
    public class EvaluacionAlistPersonalCombima1DAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<EvaluacionAlistPersonalCombima1DTO> ObtenerLista()
        {
            List<EvaluacionAlistPersonalCombima1DTO> lista = new List<EvaluacionAlistPersonalCombima1DTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoPersonalCombima1Listar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new EvaluacionAlistPersonalCombima1DTO()
                        {
                            EvaluacionAlistamientoPersonalId = Convert.ToInt32(dr["EvaluacionAlistamientoPersonalId"]),
                            DescUnidadNaval = dr["DescUnidadNaval"].ToString(),
                            FechaEvaluacion = (dr["FechaEvaluacion"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            DNIPersonal = Convert.ToInt32(dr["DNIPersonal"]),
                            CIPPersonal = Convert.ToInt32(dr["CIPPersonal"]),
                            CargoPersonal = dr["CargoPersonal"].ToString(),
                            DescGradoPersonalMilitarEsperado = dr["DescGradoPersonalMilitarEsperado"].ToString(),
                            DescEspecialidadGenericaEsperado = dr["DescEspecialidadGenericaEsperado"].ToString(),
                            DescGradoPersonalMilitarActual = dr["DescGradoPersonalMilitarActual"].ToString(),
                            DescEspecialidadGenericaActual = dr["DescEspecialidadGenericaActual"].ToString(),
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

        public string AgregarRegistro(EvaluacionAlistPersonalCombima1DTO evaluacionAlistPersonalCombima1DTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoPersonalCombima1Registrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@UnidadNavalId", SqlDbType.Int);
                    cmd.Parameters["@UnidadNavalId"].Value = evaluacionAlistPersonalCombima1DTO.UnidadNavalId;

                    cmd.Parameters.Add("@FechaEvaluacion", SqlDbType.Date);
                    cmd.Parameters["@FechaEvaluacion"].Value = evaluacionAlistPersonalCombima1DTO.FechaEvaluacion;

                    cmd.Parameters.Add("@DNIPersonal", SqlDbType.Int);
                    cmd.Parameters["@DNIPersonal"].Value = evaluacionAlistPersonalCombima1DTO.DNIPersonal;

                    cmd.Parameters.Add("@CIPPersonal", SqlDbType.Int);
                    cmd.Parameters["@CIPPersonal"].Value = evaluacionAlistPersonalCombima1DTO.CIPPersonal;

                    cmd.Parameters.Add("@CargoPersonal", SqlDbType.VarChar,50);
                    cmd.Parameters["@CargoPersonal"].Value = evaluacionAlistPersonalCombima1DTO.CargoPersonal;

                    cmd.Parameters.Add("@GradoPersonalMilitarEsperado", SqlDbType.Int);
                    cmd.Parameters["@GradoPersonalMilitarEsperado"].Value = evaluacionAlistPersonalCombima1DTO.GradoPersonalMilitarEsperado;

                    cmd.Parameters.Add("@EspecialidadGenericaEsperado", SqlDbType.Int);
                    cmd.Parameters["@EspecialidadGenericaEsperado"].Value = evaluacionAlistPersonalCombima1DTO.EspecialidadGenericaEsperado;

                    cmd.Parameters.Add("@GradoPersonalMilitarActual", SqlDbType.Int);
                    cmd.Parameters["@GradoPersonalMilitarActual"].Value = evaluacionAlistPersonalCombima1DTO.GradoPersonalMilitarActual;

                    cmd.Parameters.Add("@EspecialidadGenericaActual", SqlDbType.Int);
                    cmd.Parameters["@EspecialidadGenericaActual"].Value = evaluacionAlistPersonalCombima1DTO.EspecialidadGenericaActual;

                    cmd.Parameters.Add("@GradoJerarquico", SqlDbType.Decimal);
                    cmd.Parameters["@GradoJerarquico"].Value = evaluacionAlistPersonalCombima1DTO.GradoJerarquico;

                    cmd.Parameters.Add("@ServicioExperiencia", SqlDbType.Decimal);
                    cmd.Parameters["@ServicioExperiencia"].Value = evaluacionAlistPersonalCombima1DTO.ServicioExperiencia;

                    cmd.Parameters.Add("@EspecializacionProfesional", SqlDbType.Decimal);
                    cmd.Parameters["@EspecializacionProfesional"].Value = evaluacionAlistPersonalCombima1DTO.EspecializacionProfesional;

                    cmd.Parameters.Add("@CursoProfesionalRequerido", SqlDbType.Decimal);
                    cmd.Parameters["@CursoProfesionalRequerido"].Value = evaluacionAlistPersonalCombima1DTO.CursoProfesionalRequerido;

                    cmd.Parameters.Add("@PuntajeTotalPersonal", SqlDbType.Decimal);
                    cmd.Parameters["@PuntajeTotalPersonal"].Value = evaluacionAlistPersonalCombima1DTO.PuntajeTotalPersonal;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = evaluacionAlistPersonalCombima1DTO.UsuarioIngresoRegistro;

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

        public EvaluacionAlistPersonalCombima1DTO BuscarFormato(int Codigo)
        {
            EvaluacionAlistPersonalCombima1DTO evaluacionAlistPersonalCombima1DTO = new EvaluacionAlistPersonalCombima1DTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoPersonalCombima1Encontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EvaluacionAlistamientoPersonalId", SqlDbType.Int);
                    cmd.Parameters["@EvaluacionAlistamientoPersonalId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        evaluacionAlistPersonalCombima1DTO.EvaluacionAlistamientoPersonalId = Convert.ToInt32(dr["EvaluacionAlistamientoPersonalId"]);
                        evaluacionAlistPersonalCombima1DTO.UnidadNavalId = Convert.ToInt32(dr["UnidadNavalId"]);
                        evaluacionAlistPersonalCombima1DTO.FechaEvaluacion = Convert.ToDateTime(dr["FechaEvaluacion"]).ToString("yyy-MM-dd");
                        evaluacionAlistPersonalCombima1DTO.DNIPersonal = Convert.ToInt32(dr["DNIPersonal"]);
                        evaluacionAlistPersonalCombima1DTO.CIPPersonal = Convert.ToInt32(dr["CIPPersonal"]);
                        evaluacionAlistPersonalCombima1DTO.CargoPersonal = dr["CargoPersonal"].ToString();
                        evaluacionAlistPersonalCombima1DTO.GradoPersonalMilitarEsperado = Convert.ToInt32(dr["GradoPersonalMilitarEsperado"]);
                        evaluacionAlistPersonalCombima1DTO.EspecialidadGenericaEsperado = Convert.ToInt32(dr["EspecialidadGenericaEsperado"]);
                        evaluacionAlistPersonalCombima1DTO.GradoPersonalMilitarActual = Convert.ToInt32(dr["GradoPersonalMilitarActual"]);
                        evaluacionAlistPersonalCombima1DTO.EspecialidadGenericaActual = Convert.ToInt32(dr["EspecialidadGenericaActual"]);
                        evaluacionAlistPersonalCombima1DTO.GradoJerarquico = Convert.ToDecimal(dr["GradoJerarquico"]);
                        evaluacionAlistPersonalCombima1DTO.ServicioExperiencia = Convert.ToDecimal(dr["ServicioExperiencia"]);
                        evaluacionAlistPersonalCombima1DTO.EspecializacionProfesional = Convert.ToDecimal(dr["EspecializacionProfesional"]);
                        evaluacionAlistPersonalCombima1DTO.CursoProfesionalRequerido = Convert.ToDecimal(dr["CursoProfesionalRequerido"]);
                        evaluacionAlistPersonalCombima1DTO.PuntajeTotalPersonal = Convert.ToDecimal(dr["PuntajeTotalPersonal"]); 
 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return evaluacionAlistPersonalCombima1DTO;
        }

        public string ActualizaFormato(EvaluacionAlistPersonalCombima1DTO evaluacionAlistPersonalCombima1DTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoPersonalCombima1Actualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@EvaluacionAlistamientoPersonalId", SqlDbType.Int);
                    cmd.Parameters["@EvaluacionAlistamientoPersonalId"].Value = evaluacionAlistPersonalCombima1DTO.EvaluacionAlistamientoPersonalId;

                    cmd.Parameters.Add("@UnidadNavalId", SqlDbType.Int);
                    cmd.Parameters["@UnidadNavalId"].Value = evaluacionAlistPersonalCombima1DTO.UnidadNavalId;

                    cmd.Parameters.Add("@FechaEvaluacion", SqlDbType.Date);
                    cmd.Parameters["@FechaEvaluacion"].Value = evaluacionAlistPersonalCombima1DTO.FechaEvaluacion;

                    cmd.Parameters.Add("@DNIPersonal", SqlDbType.Int);
                    cmd.Parameters["@DNIPersonal"].Value = evaluacionAlistPersonalCombima1DTO.DNIPersonal;

                    cmd.Parameters.Add("@CIPPersonal", SqlDbType.Int);
                    cmd.Parameters["@CIPPersonal"].Value = evaluacionAlistPersonalCombima1DTO.CIPPersonal;

                    cmd.Parameters.Add("@CargoPersonal", SqlDbType.VarChar,50);
                    cmd.Parameters["@CargoPersonal"].Value = evaluacionAlistPersonalCombima1DTO.CargoPersonal;

                    cmd.Parameters.Add("@GradoPersonalMilitarEsperado", SqlDbType.Int);
                    cmd.Parameters["@GradoPersonalMilitarEsperado"].Value = evaluacionAlistPersonalCombima1DTO.GradoPersonalMilitarEsperado;

                    cmd.Parameters.Add("@EspecialidadGenericaEsperado", SqlDbType.Int);
                    cmd.Parameters["@EspecialidadGenericaEsperado"].Value = evaluacionAlistPersonalCombima1DTO.EspecialidadGenericaEsperado;

                    cmd.Parameters.Add("@GradoPersonalMilitarActual", SqlDbType.Int);
                    cmd.Parameters["@GradoPersonalMilitarActual"].Value = evaluacionAlistPersonalCombima1DTO.GradoPersonalMilitarActual;

                    cmd.Parameters.Add("@EspecialidadGenericaActual", SqlDbType.Int);
                    cmd.Parameters["@EspecialidadGenericaActual"].Value = evaluacionAlistPersonalCombima1DTO.EspecialidadGenericaActual;

                    cmd.Parameters.Add("@GradoJerarquico", SqlDbType.Decimal);
                    cmd.Parameters["@GradoJerarquico"].Value = evaluacionAlistPersonalCombima1DTO.GradoJerarquico;

                    cmd.Parameters.Add("@ServicioExperiencia", SqlDbType.Decimal);
                    cmd.Parameters["@ServicioExperiencia"].Value = evaluacionAlistPersonalCombima1DTO.ServicioExperiencia;

                    cmd.Parameters.Add("@EspecializacionProfesional", SqlDbType.Decimal);
                    cmd.Parameters["@EspecializacionProfesional"].Value = evaluacionAlistPersonalCombima1DTO.EspecializacionProfesional;

                    cmd.Parameters.Add("@CursoProfesionalRequerido", SqlDbType.Decimal);
                    cmd.Parameters["@CursoProfesionalRequerido"].Value = evaluacionAlistPersonalCombima1DTO.CursoProfesionalRequerido;

                    cmd.Parameters.Add("@PuntajeTotalPersonal", SqlDbType.Decimal);
                    cmd.Parameters["@PuntajeTotalPersonal"].Value = evaluacionAlistPersonalCombima1DTO.PuntajeTotalPersonal;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = evaluacionAlistPersonalCombima1DTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(EvaluacionAlistPersonalCombima1DTO evaluacionAlistPersonalCombima1DTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoPersonalEvaluacionAlistamientoPersonalCombima1Eliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EvaluacionAlistamientoPersonalId", SqlDbType.Int);
                    cmd.Parameters["@EvaluacionAlistamientoPersonalId"].Value = evaluacionAlistPersonalCombima1DTO.EvaluacionAlistamientoPersonalId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = evaluacionAlistPersonalCombima1DTO.UsuarioIngresoRegistro;

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
        public bool InsercionMasiva(IEnumerable<EvaluacionAlistPersonalCombima1DTO> evaluacionAlistPersonalCombima1DTO)
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
                            foreach (var item in evaluacionAlistPersonalCombima1DTO)
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
