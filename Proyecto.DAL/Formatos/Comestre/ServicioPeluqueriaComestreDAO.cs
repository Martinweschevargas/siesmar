using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comestre;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comestre
{
    public class ServicioPeluqueriaComestreDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<ServicioPeluqueriaComestreDTO> ObtenerLista()
        {
            List<ServicioPeluqueriaComestreDTO> lista = new List<ServicioPeluqueriaComestreDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_ServicioPeluqueriaComestreListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ServicioPeluqueriaComestreDTO()
                        {
                            ServicioPeluqueriaComestreId = Convert.ToInt32(dr["ServicioPeluqueriaComestreId"]),
                            Fecha = (dr["Fecha"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            CIPPersonal = Convert.ToInt32(dr["CIPPersonal"]),
                            DescGrado = dr["DescGrado"].ToString(),
                            DescEspecialidad = dr["DescEspecialidad"].ToString(),
                            DescDependencia = dr["DescDependencia"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(ServicioPeluqueriaComestreDTO servicioPeluqueriaComestreDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ServicioPeluqueriaComestreRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Fecha", SqlDbType.Date);
                    cmd.Parameters["@Fecha"].Value = servicioPeluqueriaComestreDTO.Fecha;

                    cmd.Parameters.Add("@CIPPersonal", SqlDbType.Int);
                    cmd.Parameters["@CIPPersonal"].Value = servicioPeluqueriaComestreDTO.CIPPersonal;

                    cmd.Parameters.Add("@GradoPersonalMilitarId", SqlDbType.Int);
                    cmd.Parameters["@GradoPersonalMilitarId"].Value = servicioPeluqueriaComestreDTO.GradoPersonalMilitarId;

                    cmd.Parameters.Add("@EspecialidadGenericaPersonalId", SqlDbType.Int);
                    cmd.Parameters["@EspecialidadGenericaPersonalId"].Value = servicioPeluqueriaComestreDTO.EspecialidadGenericaPersonalId;

                    cmd.Parameters.Add("@DependenciaId", SqlDbType.Int);
                    cmd.Parameters["@DependenciaId"].Value = servicioPeluqueriaComestreDTO.DependenciaId;

                    cmd.Parameters.Add("@YEAR", SqlDbType.Int);
                    cmd.Parameters["@YEAR"].Value = servicioPeluqueriaComestreDTO.Año;

                    cmd.Parameters.Add("@MES", SqlDbType.Int);
                    cmd.Parameters["@MES"].Value = servicioPeluqueriaComestreDTO.Mes;

                    cmd.Parameters.Add("@DIA", SqlDbType.Int);
                    cmd.Parameters["@DIA"].Value = servicioPeluqueriaComestreDTO.Dia;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = servicioPeluqueriaComestreDTO.UsuarioIngresoRegistro;

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

        public ServicioPeluqueriaComestreDTO BuscarFormato(int Codigo)
        {
            ServicioPeluqueriaComestreDTO servicioPeluqueriaComestreDTO = new ServicioPeluqueriaComestreDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ServicioPeluqueriaComestreEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ServicioPeluqueriaComestreId", SqlDbType.Int);
                    cmd.Parameters["@ServicioPeluqueriaComestreId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        servicioPeluqueriaComestreDTO.ServicioPeluqueriaComestreId = Convert.ToInt32(dr["ServicioPeluqueriaComestreId"]);
                        servicioPeluqueriaComestreDTO.Fecha = Convert.ToDateTime(dr["Fecha"]).ToString("yyy-MM-dd");
                        servicioPeluqueriaComestreDTO.CIPPersonal = Convert.ToInt32(dr["CIPPersonal"]);
                        servicioPeluqueriaComestreDTO.GradoPersonalMilitarId = Convert.ToInt32(dr["GradoPersonalMilitarId"]);
                        servicioPeluqueriaComestreDTO.EspecialidadGenericaPersonalId = Convert.ToInt32(dr["EspecialidadGenericaPersonalId"]);
                        servicioPeluqueriaComestreDTO.DependenciaId = Convert.ToInt32(dr["DependenciaId"]); 
 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return servicioPeluqueriaComestreDTO;
        }

        public string ActualizaFormato(ServicioPeluqueriaComestreDTO servicioPeluqueriaComestreDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_ServicioPeluqueriaComestreActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@ServicioPeluqueriaComestreId", SqlDbType.Int);
                    cmd.Parameters["@ServicioPeluqueriaComestreId"].Value = servicioPeluqueriaComestreDTO.ServicioPeluqueriaComestreId;

                    cmd.Parameters.Add("@Fecha", SqlDbType.Date);
                    cmd.Parameters["@Fecha"].Value = servicioPeluqueriaComestreDTO.Fecha;

                    cmd.Parameters.Add("@CIPPersonal", SqlDbType.Int);
                    cmd.Parameters["@CIPPersonal"].Value = servicioPeluqueriaComestreDTO.CIPPersonal;

                    cmd.Parameters.Add("@GradoPersonalMilitarId", SqlDbType.Int);
                    cmd.Parameters["@GradoPersonalMilitarId"].Value = servicioPeluqueriaComestreDTO.GradoPersonalMilitarId;

                    cmd.Parameters.Add("@EspecialidadGenericaPersonalId", SqlDbType.Int);
                    cmd.Parameters["@EspecialidadGenericaPersonalId"].Value = servicioPeluqueriaComestreDTO.EspecialidadGenericaPersonalId;

                    cmd.Parameters.Add("@DependenciaId", SqlDbType.Int);
                    cmd.Parameters["@DependenciaId"].Value = servicioPeluqueriaComestreDTO.DependenciaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = servicioPeluqueriaComestreDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(ServicioPeluqueriaComestreDTO servicioPeluqueriaComestreDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ServicioPeluqueriaComestreEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ServicioPeluqueriaComestreId", SqlDbType.Int);
                    cmd.Parameters["@ServicioPeluqueriaComestreId"].Value = servicioPeluqueriaComestreDTO.ServicioPeluqueriaComestreId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = servicioPeluqueriaComestreDTO.UsuarioIngresoRegistro;

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

        public bool InsercionMasiva(IEnumerable<ServicioPeluqueriaComestreDTO> servicioPeluqueriaComestreDTO)
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
                        cmd.CommandText = "insert into FIEstudiosInvestigacionHistoricaNaval " +
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
                            foreach (var item in servicioPeluqueriaComestreDTO)
                            {
                                //cmd.Parameters["@NombreInvestigacion"].Value = item.NombreActividadCultural;
                                //cmd.Parameters["@TipoEstudioInvestigacionId"].Value = item.TipoActividadCulturalId;
                                //cmd.Parameters["@FechaInicioInvestigacion"].Value = Convert.ToDateTime(item.FechaInicioActCultural);
                                //cmd.Parameters["@FechaTerminoInvestigacion"].Value = Convert.ToDateTime(item.FechaTerminoActCultural);
                                //cmd.Parameters["@ResponsableInvestigacion"].Value = item.LugarActCultural;
                                //cmd.Parameters["@SolicitanteInvestigacion"].Value = item.AuspiciadoresActCultural;
                                //cmd.Parameters["@NParticipantesActCultural"].Value = item.NParticipantesActCultural;
                                //cmd.Parameters["@InversionActCultural"].Value = item.InversionActCultural;
                                //cmd.Parameters["@Usuario"].Value = item.UsuarioIngresoRegistro;
                                //cmd.Parameters["@IP"].Value = UtilitariosGlobales.obtenerDireccionIp();
                                //cmd.Parameters["@MAC"].Value = UtilitariosGlobales.obtenerDireccionMac();
                                //cmd.Parameters["@UsuarioDB"].Value = UtilitariosGlobales.obtenerUsuarioDB();
                                //cmd.Parameters["@Year"].Value = DateTime.Now.Year;
                                //cmd.Parameters["@Mes"].Value = DateTime.Now.Month;
                                //cmd.Parameters["@Dia"].Value = DateTime.Now.Day;
                                //cmd.ExecuteNonQuery();
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
