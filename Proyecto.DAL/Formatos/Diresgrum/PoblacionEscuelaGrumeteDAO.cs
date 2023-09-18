using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Diresgrum;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Diresgrum
{
    public class PoblacionEscuelaGrumeteDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<PoblacionEscuelaGrumeteDTO> ObtenerLista()
        {
            List<PoblacionEscuelaGrumeteDTO> lista = new List<PoblacionEscuelaGrumeteDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_PoblacionEscuelaGrumeteListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new PoblacionEscuelaGrumeteDTO()
                        {
                            PoblacionEscuelaGrumeteId = Convert.ToInt32(dr["PoblacionEscuelaGrumeteId"]),
                            DNIGrumete = Convert.ToInt32(dr["DNIGrumete"]),
                            SexoGrumete = dr["SexoGrumete"].ToString(),
                            LugarNacimiento = Convert.ToInt32(dr["LugarNacimiento"]),
                            FechaNacimiento = (dr["FechaNacimiento"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            LugarDomicilio = Convert.ToInt32(dr["LugarDomicilio"]),
                            DescLugarFormacionServicioMilitar = dr["DescLugarFormacionServicioMilitar"].ToString(),
                            DescZonaNaval = dr["DescZonaNaval"].ToString(),
                            FechaPresentacionGrumete = (dr["FechaPresentacionGrumete"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            NumeroContingenciaGrumete = Convert.ToInt32(dr["NumeroContingenciaGrumete"]),
                            DescEstudioAlcanzado = dr["DescEstudioAlcanzado"].ToString(),
                            DescGradoEstudioEspecif = dr["DescGradoEstudioEspecif"].ToString(),
                            DescEspecialidadGrumete = dr["DescEspecialidadGrumete"].ToString(),
                            DescCertificacionCETPRO = dr["DescCertificacionCETPRO"].ToString(),
                            CalificacionCETPRO = Convert.ToDecimal(dr["CalificacionCETPRO"]),
                            PromedioFormacionFisdepaica1ra = Convert.ToDecimal(dr["PromedioFormacionFisdepaica1ra"]),
                            PromedioRendimientoAcademico1ra = Convert.ToDecimal(dr["PromedioRendimientoAcademico1ra"]),
                            PromedioConducta1ra = Convert.ToDecimal(dr["PromedioConducta1ra"]),
                            PromedioCaracterMilitar1ra = Convert.ToDecimal(dr["PromedioCaracterMilitar1ra"]),
                            PromedioFormacionFisica2da = Convert.ToDecimal(dr["PromedioFormacionFisica2da"]),
                            PromedioRendimientoFinal2da = Convert.ToDecimal(dr["PromedioRendimientoFinal2da"]),
                            PromedioConducta2da = Convert.ToDecimal(dr["PromedioConducta2da"]),
                            PromedioCaracterMilitar2da = Convert.ToDecimal(dr["PromedioCaracterMilitar2da"]),
                            ResultadoTerminoEjercicio = dr["ResultadoTerminoEjercicio"].ToString(),
 

                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(PoblacionEscuelaGrumeteDTO poblacionEscuelaGrumeteDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_PoblacionEscuelaGrumeteRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@DNIGrumete", SqlDbType.Int);
                    cmd.Parameters["@DNIGrumete"].Value = poblacionEscuelaGrumeteDTO.DNIGrumete;

                    cmd.Parameters.Add("@SexoGrumete", SqlDbType.VarChar,10);
                    cmd.Parameters["@SexoGrumete"].Value = poblacionEscuelaGrumeteDTO.SexoGrumete;

                    cmd.Parameters.Add("@LugarNacimiento", SqlDbType.Int);
                    cmd.Parameters["@LugarNacimiento"].Value = poblacionEscuelaGrumeteDTO.LugarNacimiento;

                    cmd.Parameters.Add("@FechaNacimiento", SqlDbType.Date);
                    cmd.Parameters["@FechaNacimiento"].Value = poblacionEscuelaGrumeteDTO.FechaNacimiento;

                    cmd.Parameters.Add("@LugarDomicilio", SqlDbType.Int);
                    cmd.Parameters["@LugarDomicilio"].Value = poblacionEscuelaGrumeteDTO.LugarDomicilio;

                    cmd.Parameters.Add("@LugarFormacionServicioMilitarId", SqlDbType.Int);
                    cmd.Parameters["@LugarFormacionServicioMilitarId"].Value = poblacionEscuelaGrumeteDTO.LugarFormacionServicioMilitarId;

                    cmd.Parameters.Add("@ZonaNavalId", SqlDbType.Int);
                    cmd.Parameters["@ZonaNavalId"].Value = poblacionEscuelaGrumeteDTO.ZonaNavalId;

                    cmd.Parameters.Add("@FechaPresentacionGrumete", SqlDbType.Date);
                    cmd.Parameters["@FechaPresentacionGrumete"].Value = poblacionEscuelaGrumeteDTO.FechaPresentacionGrumete;

                    cmd.Parameters.Add("@NumeroContingenciaGrumete", SqlDbType.Int);
                    cmd.Parameters["@NumeroContingenciaGrumete"].Value = poblacionEscuelaGrumeteDTO.NumeroContingenciaGrumete;

                    cmd.Parameters.Add("@GradoEstudioAlcanzadoId", SqlDbType.Int);
                    cmd.Parameters["@GradoEstudioAlcanzadoId"].Value = poblacionEscuelaGrumeteDTO.GradoEstudioAlcanzadoId;

                    cmd.Parameters.Add("@GradoEstudioEspecifId", SqlDbType.Int);
                    cmd.Parameters["@GradoEstudioEspecifId"].Value = poblacionEscuelaGrumeteDTO.GradoEstudioEspecifId;

                    cmd.Parameters.Add("@EspecialidadGrumeteId", SqlDbType.Int);
                    cmd.Parameters["@EspecialidadGrumeteId"].Value = poblacionEscuelaGrumeteDTO.EspecialidadGrumeteId;

                    cmd.Parameters.Add("@CertificacionCETPROId", SqlDbType.Int);
                    cmd.Parameters["@CertificacionCETPROId"].Value = poblacionEscuelaGrumeteDTO.CertificacionCETPROId;

                    cmd.Parameters.Add("@CalificacionCETPRO", SqlDbType.Decimal);
                    cmd.Parameters["@CalificacionCETPRO"].Value = poblacionEscuelaGrumeteDTO.CalificacionCETPRO;

                    cmd.Parameters.Add("@PromedioFormacionFisdepaica1ra", SqlDbType.Decimal);
                    cmd.Parameters["@PromedioFormacionFisdepaica1ra"].Value = poblacionEscuelaGrumeteDTO.PromedioFormacionFisdepaica1ra;

                    cmd.Parameters.Add("@PromedioRendimientoAcademico1ra", SqlDbType.Decimal);
                    cmd.Parameters["@PromedioRendimientoAcademico1ra"].Value = poblacionEscuelaGrumeteDTO.PromedioRendimientoAcademico1ra;

                    cmd.Parameters.Add("@PromedioConducta1ra", SqlDbType.Decimal);
                    cmd.Parameters["@PromedioConducta1ra"].Value = poblacionEscuelaGrumeteDTO.PromedioConducta1ra;

                    cmd.Parameters.Add("@PromedioCaracterMilitar1ra", SqlDbType.Decimal);
                    cmd.Parameters["@PromedioCaracterMilitar1ra"].Value = poblacionEscuelaGrumeteDTO.PromedioCaracterMilitar1ra;

                    cmd.Parameters.Add("@PromedioFormacionFisica2da", SqlDbType.Decimal);
                    cmd.Parameters["@PromedioFormacionFisica2da"].Value = poblacionEscuelaGrumeteDTO.PromedioFormacionFisica2da;

                    cmd.Parameters.Add("@PromedioRendimientoFinal2da", SqlDbType.Decimal);
                    cmd.Parameters["@PromedioRendimientoFinal2da"].Value = poblacionEscuelaGrumeteDTO.PromedioRendimientoFinal2da;

                    cmd.Parameters.Add("@PromedioConducta2da", SqlDbType.Decimal);
                    cmd.Parameters["@PromedioConducta2da"].Value = poblacionEscuelaGrumeteDTO.PromedioConducta2da;

                    cmd.Parameters.Add("@PromedioCaracterMilitar2da", SqlDbType.Decimal);
                    cmd.Parameters["@PromedioCaracterMilitar2da"].Value = poblacionEscuelaGrumeteDTO.PromedioCaracterMilitar2da;

                    cmd.Parameters.Add("@ResultadoTerminoEjercicio", SqlDbType.VarChar,50);
                    cmd.Parameters["@ResultadoTerminoEjercicio"].Value = poblacionEscuelaGrumeteDTO.ResultadoTerminoEjercicio;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = poblacionEscuelaGrumeteDTO.UsuarioIngresoRegistro;

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

        public PoblacionEscuelaGrumeteDTO BuscarFormato(int Codigo)
        {
            PoblacionEscuelaGrumeteDTO poblacionEscuelaGrumeteDTO = new PoblacionEscuelaGrumeteDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_PoblacionEscuelaGrumeteEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PoblacionEscuelaGrumeteId", SqlDbType.Int);
                    cmd.Parameters["@PoblacionEscuelaGrumeteId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        poblacionEscuelaGrumeteDTO.PoblacionEscuelaGrumeteId = Convert.ToInt32(dr["PoblacionEscuelaGrumeteId"]);
                        poblacionEscuelaGrumeteDTO.DNIGrumete = Convert.ToInt32(dr["DNIGrumete"]);
                        poblacionEscuelaGrumeteDTO.SexoGrumete = dr["SexoGrumete"].ToString();
                        poblacionEscuelaGrumeteDTO.LugarNacimiento = Convert.ToInt32(dr["LugarNacimiento"]);
                        poblacionEscuelaGrumeteDTO.FechaNacimiento = Convert.ToDateTime(dr["FechaNacimiento"]).ToString("yyy-MM-dd");
                        poblacionEscuelaGrumeteDTO.LugarDomicilio = Convert.ToInt32(dr["LugarDomicilio"]);
                        poblacionEscuelaGrumeteDTO.LugarFormacionServicioMilitarId = Convert.ToInt32(dr["LugarFormacionServicioMilitarId"]);
                        poblacionEscuelaGrumeteDTO.ZonaNavalId = Convert.ToInt32(dr["ZonaNavalId"]);
                        poblacionEscuelaGrumeteDTO.FechaPresentacionGrumete = Convert.ToDateTime(dr["FechaPresentacionGrumete"]).ToString("yyy-MM-dd");
                        poblacionEscuelaGrumeteDTO.NumeroContingenciaGrumete = Convert.ToInt32(dr["NumeroContingenciaGrumete"]);
                        poblacionEscuelaGrumeteDTO.GradoEstudioAlcanzadoId = Convert.ToInt32(dr["GradoEstudioAlcanzadoId"]);
                        poblacionEscuelaGrumeteDTO.GradoEstudioEspecifId = Convert.ToInt32(dr["GradoEstudioEspecifId"]);
                        poblacionEscuelaGrumeteDTO.EspecialidadGrumeteId = Convert.ToInt32(dr["EspecialidadGrumeteId"]);
                        poblacionEscuelaGrumeteDTO.CertificacionCETPROId = Convert.ToInt32(dr["CertificacionCETPROId"]);
                        poblacionEscuelaGrumeteDTO.CalificacionCETPRO = Convert.ToDecimal(dr["CalificacionCETPRO"]);
                        poblacionEscuelaGrumeteDTO.PromedioFormacionFisdepaica1ra = Convert.ToDecimal(dr["PromedioFormacionFisdepaica1ra"]);
                        poblacionEscuelaGrumeteDTO.PromedioRendimientoAcademico1ra = Convert.ToDecimal(dr["PromedioRendimientoAcademico1ra"]);
                        poblacionEscuelaGrumeteDTO.PromedioConducta1ra = Convert.ToDecimal(dr["PromedioConducta1ra"]);
                        poblacionEscuelaGrumeteDTO.PromedioCaracterMilitar1ra = Convert.ToDecimal(dr["PromedioCaracterMilitar1ra"]);
                        poblacionEscuelaGrumeteDTO.PromedioFormacionFisica2da = Convert.ToDecimal(dr["PromedioFormacionFisica2da"]);
                        poblacionEscuelaGrumeteDTO.PromedioRendimientoFinal2da = Convert.ToDecimal(dr["PromedioRendimientoFinal2da"]);
                        poblacionEscuelaGrumeteDTO.PromedioConducta2da = Convert.ToDecimal(dr["PromedioConducta2da"]);
                        poblacionEscuelaGrumeteDTO.PromedioCaracterMilitar2da = Convert.ToDecimal(dr["PromedioCaracterMilitar2da"]);
                        poblacionEscuelaGrumeteDTO.ResultadoTerminoEjercicio = dr["ResultadoTerminoEjercicio"].ToString(); 
 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return poblacionEscuelaGrumeteDTO;
        }

        public string ActualizaFormato(PoblacionEscuelaGrumeteDTO poblacionEscuelaGrumeteDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_PoblacionEscuelaGrumeteActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@PoblacionEscuelaGrumeteId", SqlDbType.Int);
                    cmd.Parameters["@PoblacionEscuelaGrumeteId"].Value = poblacionEscuelaGrumeteDTO.PoblacionEscuelaGrumeteId;

                    cmd.Parameters.Add("@DNIGrumete", SqlDbType.Int);
                    cmd.Parameters["@DNIGrumete"].Value = poblacionEscuelaGrumeteDTO.DNIGrumete;

                    cmd.Parameters.Add("@SexoGrumete", SqlDbType.VarChar,10);
                    cmd.Parameters["@SexoGrumete"].Value = poblacionEscuelaGrumeteDTO.SexoGrumete;

                    cmd.Parameters.Add("@LugarNacimiento", SqlDbType.Int);
                    cmd.Parameters["@LugarNacimiento"].Value = poblacionEscuelaGrumeteDTO.LugarNacimiento;

                    cmd.Parameters.Add("@FechaNacimiento", SqlDbType.Date);
                    cmd.Parameters["@FechaNacimiento"].Value = poblacionEscuelaGrumeteDTO.FechaNacimiento;

                    cmd.Parameters.Add("@LugarDomicilio", SqlDbType.Int);
                    cmd.Parameters["@LugarDomicilio"].Value = poblacionEscuelaGrumeteDTO.LugarDomicilio;

                    cmd.Parameters.Add("@LugarFormacionServicioMilitarId", SqlDbType.Int);
                    cmd.Parameters["@LugarFormacionServicioMilitarId"].Value = poblacionEscuelaGrumeteDTO.LugarFormacionServicioMilitarId;

                    cmd.Parameters.Add("@ZonaNavalId", SqlDbType.Int);
                    cmd.Parameters["@ZonaNavalId"].Value = poblacionEscuelaGrumeteDTO.ZonaNavalId;

                    cmd.Parameters.Add("@FechaPresentacionGrumete", SqlDbType.Date);
                    cmd.Parameters["@FechaPresentacionGrumete"].Value = poblacionEscuelaGrumeteDTO.FechaPresentacionGrumete;

                    cmd.Parameters.Add("@NumeroContingenciaGrumete", SqlDbType.Int);
                    cmd.Parameters["@NumeroContingenciaGrumete"].Value = poblacionEscuelaGrumeteDTO.NumeroContingenciaGrumete;

                    cmd.Parameters.Add("@GradoEstudioAlcanzadoId", SqlDbType.Int);
                    cmd.Parameters["@GradoEstudioAlcanzadoId"].Value = poblacionEscuelaGrumeteDTO.GradoEstudioAlcanzadoId;

                    cmd.Parameters.Add("@GradoEstudioEspecifId", SqlDbType.Int);
                    cmd.Parameters["@GradoEstudioEspecifId"].Value = poblacionEscuelaGrumeteDTO.GradoEstudioEspecifId;

                    cmd.Parameters.Add("@EspecialidadGrumeteId", SqlDbType.Int);
                    cmd.Parameters["@EspecialidadGrumeteId"].Value = poblacionEscuelaGrumeteDTO.EspecialidadGrumeteId;

                    cmd.Parameters.Add("@CertificacionCETPROId", SqlDbType.Int);
                    cmd.Parameters["@CertificacionCETPROId"].Value = poblacionEscuelaGrumeteDTO.CertificacionCETPROId;

                    cmd.Parameters.Add("@CalificacionCETPRO", SqlDbType.Decimal);
                    cmd.Parameters["@CalificacionCETPRO"].Value = poblacionEscuelaGrumeteDTO.CalificacionCETPRO;

                    cmd.Parameters.Add("@PromedioFormacionFisdepaica1ra", SqlDbType.Decimal);
                    cmd.Parameters["@PromedioFormacionFisdepaica1ra"].Value = poblacionEscuelaGrumeteDTO.PromedioFormacionFisdepaica1ra;

                    cmd.Parameters.Add("@PromedioRendimientoAcademico1ra", SqlDbType.Decimal);
                    cmd.Parameters["@PromedioRendimientoAcademico1ra"].Value = poblacionEscuelaGrumeteDTO.PromedioRendimientoAcademico1ra;

                    cmd.Parameters.Add("@PromedioConducta1ra", SqlDbType.Decimal);
                    cmd.Parameters["@PromedioConducta1ra"].Value = poblacionEscuelaGrumeteDTO.PromedioConducta1ra;

                    cmd.Parameters.Add("@PromedioCaracterMilitar1ra", SqlDbType.Decimal);
                    cmd.Parameters["@PromedioCaracterMilitar1ra"].Value = poblacionEscuelaGrumeteDTO.PromedioCaracterMilitar1ra;

                    cmd.Parameters.Add("@PromedioFormacionFisica2da", SqlDbType.Decimal);
                    cmd.Parameters["@PromedioFormacionFisica2da"].Value = poblacionEscuelaGrumeteDTO.PromedioFormacionFisica2da;

                    cmd.Parameters.Add("@PromedioRendimientoFinal2da", SqlDbType.Decimal);
                    cmd.Parameters["@PromedioRendimientoFinal2da"].Value = poblacionEscuelaGrumeteDTO.PromedioRendimientoFinal2da;

                    cmd.Parameters.Add("@PromedioConducta2da", SqlDbType.Decimal);
                    cmd.Parameters["@PromedioConducta2da"].Value = poblacionEscuelaGrumeteDTO.PromedioConducta2da;

                    cmd.Parameters.Add("@PromedioCaracterMilitar2da", SqlDbType.Decimal);
                    cmd.Parameters["@PromedioCaracterMilitar2da"].Value = poblacionEscuelaGrumeteDTO.PromedioCaracterMilitar2da;

                    cmd.Parameters.Add("@ResultadoTerminoEjercicio", SqlDbType.VarChar,50);
                    cmd.Parameters["@ResultadoTerminoEjercicio"].Value = poblacionEscuelaGrumeteDTO.ResultadoTerminoEjercicio;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = poblacionEscuelaGrumeteDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(PoblacionEscuelaGrumeteDTO poblacionEscuelaGrumeteDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_PoblacionEscuelaGrumeteEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PoblacionEscuelaGrumeteId", SqlDbType.Int);
                    cmd.Parameters["@PoblacionEscuelaGrumeteId"].Value = poblacionEscuelaGrumeteDTO.PoblacionEscuelaGrumeteId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = poblacionEscuelaGrumeteDTO.UsuarioIngresoRegistro;

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

        public bool InsercionMasiva(IEnumerable<PoblacionEscuelaGrumeteDTO> poblacionEscuelaGrumeteDTO)
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
                        try
                        {
                            foreach (var item in poblacionEscuelaGrumeteDTO)
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
