using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comfuavinav;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comfuavinav
{
    public class EvaluacionAlistamientoPersonalComfuavinavDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<EvaluacionAlistamientoPersonalComfuavinavDTO> ObtenerLista()
        {
            List<EvaluacionAlistamientoPersonalComfuavinavDTO> lista = new List<EvaluacionAlistamientoPersonalComfuavinavDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoPersonalComfuavinavListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new EvaluacionAlistamientoPersonalComfuavinavDTO()
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


                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(EvaluacionAlistamientoPersonalComfuavinavDTO evaluacionAlistPersonalComfuavinavDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoPersonalComfuavinavRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@UnidadNavalId", SqlDbType.Int);
                    cmd.Parameters["@UnidadNavalId"].Value = evaluacionAlistPersonalComfuavinavDTO.UnidadNavalId;

                    cmd.Parameters.Add("@FechaEvaluacion", SqlDbType.Date);
                    cmd.Parameters["@FechaEvaluacion"].Value = evaluacionAlistPersonalComfuavinavDTO.FechaEvaluacion;

                    cmd.Parameters.Add("@DNIPersonal", SqlDbType.Int);
                    cmd.Parameters["@DNIPersonal"].Value = evaluacionAlistPersonalComfuavinavDTO.DNIPersonal;

                    cmd.Parameters.Add("@CIPPersonal", SqlDbType.Int);
                    cmd.Parameters["@CIPPersonal"].Value = evaluacionAlistPersonalComfuavinavDTO.CIPPersonal;

                    cmd.Parameters.Add("@CargoPersonal", SqlDbType.VarChar,50);
                    cmd.Parameters["@CargoPersonal"].Value = evaluacionAlistPersonalComfuavinavDTO.CargoPersonal;

                    cmd.Parameters.Add("@GradoPersonalMilitarEsperado", SqlDbType.Int);
                    cmd.Parameters["@GradoPersonalMilitarEsperado"].Value = evaluacionAlistPersonalComfuavinavDTO.GradoPersonalMilitarEsperado;

                    cmd.Parameters.Add("@EspecialidadGenericaEsperado", SqlDbType.Int);
                    cmd.Parameters["@EspecialidadGenericaEsperado"].Value = evaluacionAlistPersonalComfuavinavDTO.EspecialidadGenericaEsperado;

                    cmd.Parameters.Add("@GradoPersonalMilitarActual", SqlDbType.Int);
                    cmd.Parameters["@GradoPersonalMilitarActual"].Value = evaluacionAlistPersonalComfuavinavDTO.GradoPersonalMilitarActual;

                    cmd.Parameters.Add("@EspecialidadGenericaActual", SqlDbType.Int);
                    cmd.Parameters["@EspecialidadGenericaActual"].Value = evaluacionAlistPersonalComfuavinavDTO.EspecialidadGenericaActual;

                    cmd.Parameters.Add("@GradoJerarquico", SqlDbType.Decimal);
                    cmd.Parameters["@GradoJerarquico"].Value = evaluacionAlistPersonalComfuavinavDTO.GradoJerarquico;

                    cmd.Parameters.Add("@ServicioExperiencia", SqlDbType.Decimal);
                    cmd.Parameters["@ServicioExperiencia"].Value = evaluacionAlistPersonalComfuavinavDTO.ServicioExperiencia;

                    cmd.Parameters.Add("@EspecializacionProfesional", SqlDbType.Decimal);
                    cmd.Parameters["@EspecializacionProfesional"].Value = evaluacionAlistPersonalComfuavinavDTO.EspecializacionProfesional;

                    cmd.Parameters.Add("@CursoProfesionalRequerido", SqlDbType.Decimal);
                    cmd.Parameters["@CursoProfesionalRequerido"].Value = evaluacionAlistPersonalComfuavinavDTO.CursoProfesionalRequerido;


                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = evaluacionAlistPersonalComfuavinavDTO.UsuarioIngresoRegistro;

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

        public EvaluacionAlistamientoPersonalComfuavinavDTO BuscarFormato(int Codigo)
        {
            EvaluacionAlistamientoPersonalComfuavinavDTO evaluacionAlistPersonalComfuavinavDTO = new EvaluacionAlistamientoPersonalComfuavinavDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoPersonalComfuavinavEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EvaluacionAlistamientoPersonalId", SqlDbType.Int);
                    cmd.Parameters["@EvaluacionAlistamientoPersonalId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        evaluacionAlistPersonalComfuavinavDTO.EvaluacionAlistamientoPersonalId = Convert.ToInt32(dr["EvaluacionAlistamientoPersonalId"]);
                        evaluacionAlistPersonalComfuavinavDTO.UnidadNavalId = Convert.ToInt32(dr["UnidadNavalId"]);
                        evaluacionAlistPersonalComfuavinavDTO.FechaEvaluacion = Convert.ToDateTime(dr["FechaEvaluacion"]).ToString("yyy-MM-dd");
                        evaluacionAlistPersonalComfuavinavDTO.DNIPersonal = Convert.ToInt32(dr["DNIPersonal"]);
                        evaluacionAlistPersonalComfuavinavDTO.CIPPersonal = Convert.ToInt32(dr["CIPPersonal"]);
                        evaluacionAlistPersonalComfuavinavDTO.CargoPersonal = dr["CargoPersonal"].ToString();
                        evaluacionAlistPersonalComfuavinavDTO.GradoPersonalMilitarEsperado = Convert.ToInt32(dr["GradoPersonalMilitarEsperado"]);
                        evaluacionAlistPersonalComfuavinavDTO.EspecialidadGenericaEsperado = Convert.ToInt32(dr["EspecialidadGenericaEsperado"]);
                        evaluacionAlistPersonalComfuavinavDTO.GradoPersonalMilitarActual = Convert.ToInt32(dr["GradoPersonalMilitarActual"]);
                        evaluacionAlistPersonalComfuavinavDTO.EspecialidadGenericaActual = Convert.ToInt32(dr["EspecialidadGenericaActual"]);
                        evaluacionAlistPersonalComfuavinavDTO.GradoJerarquico = Convert.ToDecimal(dr["GradoJerarquico"]);
                        evaluacionAlistPersonalComfuavinavDTO.ServicioExperiencia = Convert.ToDecimal(dr["ServicioExperiencia"]);
                        evaluacionAlistPersonalComfuavinavDTO.EspecializacionProfesional = Convert.ToDecimal(dr["EspecializacionProfesional"]);
                        evaluacionAlistPersonalComfuavinavDTO.CursoProfesionalRequerido = Convert.ToDecimal(dr["CursoProfesionalRequerido"]);

 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return evaluacionAlistPersonalComfuavinavDTO;
        }

        public string ActualizaFormato(EvaluacionAlistamientoPersonalComfuavinavDTO evaluacionAlistPersonalComfuavinavDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoPersonalComfuavinavActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@EvaluacionAlistamientoPersonalId", SqlDbType.Int);
                    cmd.Parameters["@EvaluacionAlistamientoPersonalId"].Value = evaluacionAlistPersonalComfuavinavDTO.EvaluacionAlistamientoPersonalId;

                    cmd.Parameters.Add("@UnidadNavalId", SqlDbType.Int);
                    cmd.Parameters["@UnidadNavalId"].Value = evaluacionAlistPersonalComfuavinavDTO.UnidadNavalId;

                    cmd.Parameters.Add("@FechaEvaluacion", SqlDbType.Date);
                    cmd.Parameters["@FechaEvaluacion"].Value = evaluacionAlistPersonalComfuavinavDTO.FechaEvaluacion;

                    cmd.Parameters.Add("@DNIPersonal", SqlDbType.Int);
                    cmd.Parameters["@DNIPersonal"].Value = evaluacionAlistPersonalComfuavinavDTO.DNIPersonal;

                    cmd.Parameters.Add("@CIPPersonal", SqlDbType.Int);
                    cmd.Parameters["@CIPPersonal"].Value = evaluacionAlistPersonalComfuavinavDTO.CIPPersonal;

                    cmd.Parameters.Add("@CargoPersonal", SqlDbType.VarChar,50);
                    cmd.Parameters["@CargoPersonal"].Value = evaluacionAlistPersonalComfuavinavDTO.CargoPersonal;

                    cmd.Parameters.Add("@GradoPersonalMilitarEsperado", SqlDbType.Int);
                    cmd.Parameters["@GradoPersonalMilitarEsperado"].Value = evaluacionAlistPersonalComfuavinavDTO.GradoPersonalMilitarEsperado;

                    cmd.Parameters.Add("@EspecialidadGenericaEsperado", SqlDbType.Int);
                    cmd.Parameters["@EspecialidadGenericaEsperado"].Value = evaluacionAlistPersonalComfuavinavDTO.EspecialidadGenericaEsperado;

                    cmd.Parameters.Add("@GradoPersonalMilitarActual", SqlDbType.Int);
                    cmd.Parameters["@GradoPersonalMilitarActual"].Value = evaluacionAlistPersonalComfuavinavDTO.GradoPersonalMilitarActual;

                    cmd.Parameters.Add("@EspecialidadGenericaActual", SqlDbType.Int);
                    cmd.Parameters["@EspecialidadGenericaActual"].Value = evaluacionAlistPersonalComfuavinavDTO.EspecialidadGenericaActual;

                    cmd.Parameters.Add("@GradoJerarquico", SqlDbType.Decimal);
                    cmd.Parameters["@GradoJerarquico"].Value = evaluacionAlistPersonalComfuavinavDTO.GradoJerarquico;

                    cmd.Parameters.Add("@ServicioExperiencia", SqlDbType.Decimal);
                    cmd.Parameters["@ServicioExperiencia"].Value = evaluacionAlistPersonalComfuavinavDTO.ServicioExperiencia;

                    cmd.Parameters.Add("@EspecializacionProfesional", SqlDbType.Decimal);
                    cmd.Parameters["@EspecializacionProfesional"].Value = evaluacionAlistPersonalComfuavinavDTO.EspecializacionProfesional;

                    cmd.Parameters.Add("@CursoProfesionalRequerido", SqlDbType.Decimal);
                    cmd.Parameters["@CursoProfesionalRequerido"].Value = evaluacionAlistPersonalComfuavinavDTO.CursoProfesionalRequerido;


                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = evaluacionAlistPersonalComfuavinavDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(EvaluacionAlistamientoPersonalComfuavinavDTO evaluacionAlistPersonalComfuavinavDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoPersonalComfuavinavEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EvaluacionAlistamientoPersonalId", SqlDbType.Int);
                    cmd.Parameters["@EvaluacionAlistamientoPersonalId"].Value = evaluacionAlistPersonalComfuavinavDTO.EvaluacionAlistamientoPersonalId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = evaluacionAlistPersonalComfuavinavDTO.UsuarioIngresoRegistro;

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
        public bool InsercionMasiva(IEnumerable<EvaluacionAlistamientoPersonalComfuavinavDTO> evaluacionAlistPersonalComfuavinavDTO)
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
                            foreach (var item in evaluacionAlistPersonalComfuavinavDTO)
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
