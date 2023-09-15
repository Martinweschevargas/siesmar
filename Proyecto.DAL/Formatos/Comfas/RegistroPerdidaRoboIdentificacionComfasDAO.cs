using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comfas;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comfas
{
    public class RegistroPerdidaRoboIdentificacionComfasDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<RegistroPerdidaRoboIdentificacionComfasDTO> ObtenerLista()
        {
            List<RegistroPerdidaRoboIdentificacionComfasDTO> lista = new List<RegistroPerdidaRoboIdentificacionComfasDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_RegistroPerdidaRoboIdentificacionComfasListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new RegistroPerdidaRoboIdentificacionComfasDTO()
                        {
                            RegistroPerdidaRoboIdentificacionId = Convert.ToInt32(dr["RegistroPerdidaRoboIdentificacionId"]),
                            DescUnidadNaval = dr["DescUnidadNaval"].ToString(),
                            FechaInforme = (dr["FechaInforme"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            DescGradoPersonalMilitar = dr["DescGradoPersonalMilitar"].ToString(),
                            DescEspecialidadGenericaPersonal = dr["DescEspecialidadGenericaPersonal"].ToString(),
                            CIPPersonal = Convert.ToInt32(dr["CIPPersonal"]),
                            FechaIncidente = (dr["FechaIncidente"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            Motivo = dr["Motivo"].ToString(),
                            MensajeNavalReferencia = dr["MensajeNavalReferencia"].ToString(),
 

                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(RegistroPerdidaRoboIdentificacionComfasDTO registroPerdidaRoboIdentificacionComfasDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_RegistroPerdidaRoboIdentificacionComfasRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@UnidadNavalId", SqlDbType.Int);
                    cmd.Parameters["@UnidadNavalId"].Value = registroPerdidaRoboIdentificacionComfasDTO.UnidadNavalId;

                    cmd.Parameters.Add("@FechaInforme", SqlDbType.Date);
                    cmd.Parameters["@FechaInforme"].Value = registroPerdidaRoboIdentificacionComfasDTO.FechaInforme;

                    cmd.Parameters.Add("@GradoPersonalMilitarId", SqlDbType.Int);
                    cmd.Parameters["@GradoPersonalMilitarId"].Value = registroPerdidaRoboIdentificacionComfasDTO.GradoPersonalMilitarId;

                    cmd.Parameters.Add("@EspecialidadGenericaPersonalId", SqlDbType.Int);
                    cmd.Parameters["@EspecialidadGenericaPersonalId"].Value = registroPerdidaRoboIdentificacionComfasDTO.EspecialidadGenericaPersonalId;

                    cmd.Parameters.Add("@CIPPersonal", SqlDbType.Int);
                    cmd.Parameters["@CIPPersonal"].Value = registroPerdidaRoboIdentificacionComfasDTO.CIPPersonal;

                    cmd.Parameters.Add("@FechaIncidente", SqlDbType.Date);
                    cmd.Parameters["@FechaIncidente"].Value = registroPerdidaRoboIdentificacionComfasDTO.FechaIncidente;

                    cmd.Parameters.Add("@Motivo", SqlDbType.VarChar,50);
                    cmd.Parameters["@Motivo"].Value = registroPerdidaRoboIdentificacionComfasDTO.Motivo;

                    cmd.Parameters.Add("@MensajeNavalReferencia", SqlDbType.VarChar,20);
                    cmd.Parameters["@MensajeNavalReferencia"].Value = registroPerdidaRoboIdentificacionComfasDTO.MensajeNavalReferencia;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = registroPerdidaRoboIdentificacionComfasDTO.UsuarioIngresoRegistro;

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

        public RegistroPerdidaRoboIdentificacionComfasDTO BuscarFormato(int Codigo)
        {
            RegistroPerdidaRoboIdentificacionComfasDTO registroPerdidaRoboIdentificacionComfasDTO = new RegistroPerdidaRoboIdentificacionComfasDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_RegistroPerdidaRoboIdentificacionComfasEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RegistroPerdidaRoboIdentificacionId", SqlDbType.Int);
                    cmd.Parameters["@RegistroPerdidaRoboIdentificacionId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        registroPerdidaRoboIdentificacionComfasDTO.RegistroPerdidaRoboIdentificacionId = Convert.ToInt32(dr["RegistroPerdidaRoboIdentificacionId"]);
                        registroPerdidaRoboIdentificacionComfasDTO.UnidadNavalId = Convert.ToInt32(dr["UnidadNavalId"]);
                        registroPerdidaRoboIdentificacionComfasDTO.FechaInforme = Convert.ToDateTime(dr["FechaInforme"]).ToString("yyy-MM-dd");
                        registroPerdidaRoboIdentificacionComfasDTO.GradoPersonalMilitarId = Convert.ToInt32(dr["GradoPersonalMilitarId"]);
                        registroPerdidaRoboIdentificacionComfasDTO.EspecialidadGenericaPersonalId = Convert.ToInt32(dr["EspecialidadGenericaPersonalId"]);
                        registroPerdidaRoboIdentificacionComfasDTO.CIPPersonal = Convert.ToInt32(dr["CIPPersonal"]);
                        registroPerdidaRoboIdentificacionComfasDTO.FechaIncidente = Convert.ToDateTime(dr["FechaIncidente"]).ToString("yyy-MM-dd");
                        registroPerdidaRoboIdentificacionComfasDTO.Motivo = dr["Motivo"].ToString();
                        registroPerdidaRoboIdentificacionComfasDTO.MensajeNavalReferencia = dr["MensajeNavalReferencia"].ToString(); 
 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return registroPerdidaRoboIdentificacionComfasDTO;
        }

        public string ActualizaFormato(RegistroPerdidaRoboIdentificacionComfasDTO registroPerdidaRoboIdentificacionComfasDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_RegistroPerdidaRoboIdentificacionComfasActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@RegistroPerdidaRoboIdentificacionId", SqlDbType.Int);
                    cmd.Parameters["@RegistroPerdidaRoboIdentificacionId"].Value = registroPerdidaRoboIdentificacionComfasDTO.RegistroPerdidaRoboIdentificacionId;

                    cmd.Parameters.Add("@UnidadNavalId", SqlDbType.Int);
                    cmd.Parameters["@UnidadNavalId"].Value = registroPerdidaRoboIdentificacionComfasDTO.UnidadNavalId;

                    cmd.Parameters.Add("@FechaInforme", SqlDbType.Date);
                    cmd.Parameters["@FechaInforme"].Value = registroPerdidaRoboIdentificacionComfasDTO.FechaInforme;

                    cmd.Parameters.Add("@GradoPersonalMilitarId", SqlDbType.Int);
                    cmd.Parameters["@GradoPersonalMilitarId"].Value = registroPerdidaRoboIdentificacionComfasDTO.GradoPersonalMilitarId;

                    cmd.Parameters.Add("@EspecialidadGenericaPersonalId", SqlDbType.Int);
                    cmd.Parameters["@EspecialidadGenericaPersonalId"].Value = registroPerdidaRoboIdentificacionComfasDTO.EspecialidadGenericaPersonalId;

                    cmd.Parameters.Add("@CIPPersonal", SqlDbType.Int);
                    cmd.Parameters["@CIPPersonal"].Value = registroPerdidaRoboIdentificacionComfasDTO.CIPPersonal;

                    cmd.Parameters.Add("@FechaIncidente", SqlDbType.Date);
                    cmd.Parameters["@FechaIncidente"].Value = registroPerdidaRoboIdentificacionComfasDTO.FechaIncidente;

                    cmd.Parameters.Add("@Motivo", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Motivo"].Value = registroPerdidaRoboIdentificacionComfasDTO.Motivo;

                    cmd.Parameters.Add("@MensajeNavalReferencia", SqlDbType.VarChar, 20);
                    cmd.Parameters["@MensajeNavalReferencia"].Value = registroPerdidaRoboIdentificacionComfasDTO.MensajeNavalReferencia;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = registroPerdidaRoboIdentificacionComfasDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(RegistroPerdidaRoboIdentificacionComfasDTO registroPerdidaRoboIdentificacionComfasDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_RegistroPerdidaRoboIdentificacionComfasEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RegistroPerdidaRoboIdentificacionId", SqlDbType.Int);
                    cmd.Parameters["@RegistroPerdidaRoboIdentificacionId"].Value = registroPerdidaRoboIdentificacionComfasDTO.RegistroPerdidaRoboIdentificacionId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = registroPerdidaRoboIdentificacionComfasDTO.UsuarioIngresoRegistro;

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
        public bool InsercionMasiva(IEnumerable<RegistroPerdidaRoboIdentificacionComfasDTO> registroPerdidaRoboIdentificacionComfasDTO)
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
                            foreach (var item in registroPerdidaRoboIdentificacionComfasDTO)
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
