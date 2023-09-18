using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comestre;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comestre
{
    public class EjercicioTipoArmaMenorComestreDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<EjercicioTipoArmaMenorComestreDTO> ObtenerLista()
        {
            List<EjercicioTipoArmaMenorComestreDTO> lista = new List<EjercicioTipoArmaMenorComestreDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_EjercicioTipoArmaMenorComestreListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new EjercicioTipoArmaMenorComestreDTO()
                        {
                            EjercicioTipoArmaMenorComestreId = Convert.ToInt32(dr["EjercicioTipoArmaMenorComestreId"]),
                            DescEspecialidad = dr["DescEspecialidadGenericaPersonal"].ToString(),
                            DescGrado = dr["DescGradoPersonalMilitar"].ToString(),
                            FechaEjercicio = (dr["FechaEjercicio"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            DescTipoArmamento = dr["DescTipoArmamento"].ToString(),
                            Posicion = dr["Posicion"].ToString(),
                            DistanciaMetro = Convert.ToInt32(dr["DistanciaMetro"]),
                            CantidadTipo = Convert.ToInt32(dr["CantidadTipo"]),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(EjercicioTipoArmaMenorComestreDTO ejercicioTipoArmaMenorComestreDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EjercicioTipoArmaMenorComestreRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EspecialidadGenericaPersonalId", SqlDbType.Int);
                    cmd.Parameters["@EspecialidadGenericaPersonalId"].Value = ejercicioTipoArmaMenorComestreDTO.EspecialidadGenericaPersonalId;

                    cmd.Parameters.Add("@GradoPersonalMilitarId", SqlDbType.Int);
                    cmd.Parameters["@GradoPersonalMilitarId"].Value = ejercicioTipoArmaMenorComestreDTO.GradoPersonalMilitarId;

                    cmd.Parameters.Add("@FechaEjercicio", SqlDbType.Date);
                    cmd.Parameters["@FechaEjercicio"].Value = ejercicioTipoArmaMenorComestreDTO.FechaEjercicio;

                    cmd.Parameters.Add("@TipoArmamentoId", SqlDbType.Int);
                    cmd.Parameters["@TipoArmamentoId"].Value = ejercicioTipoArmaMenorComestreDTO.TipoArmamentoId;

                    cmd.Parameters.Add("@Posicion", SqlDbType.VarChar,2);
                    cmd.Parameters["@Posicion"].Value = ejercicioTipoArmaMenorComestreDTO.Posicion;

                    cmd.Parameters.Add("@DistanciaMetro", SqlDbType.Int);
                    cmd.Parameters["@DistanciaMetro"].Value = ejercicioTipoArmaMenorComestreDTO.DistanciaMetro;

                    cmd.Parameters.Add("@CantidadTipo", SqlDbType.Int);
                    cmd.Parameters["@CantidadTipo"].Value = ejercicioTipoArmaMenorComestreDTO.CantidadTipo;


                    cmd.Parameters.Add("@YEAR", SqlDbType.Int);
                    cmd.Parameters["@YEAR"].Value = ejercicioTipoArmaMenorComestreDTO.Año;

                    cmd.Parameters.Add("@MES", SqlDbType.Int);
                    cmd.Parameters["@MES"].Value = ejercicioTipoArmaMenorComestreDTO.Mes;

                    cmd.Parameters.Add("@DIA", SqlDbType.Int);
                    cmd.Parameters["@DIA"].Value = ejercicioTipoArmaMenorComestreDTO.Dia;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ejercicioTipoArmaMenorComestreDTO.UsuarioIngresoRegistro;

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

        public EjercicioTipoArmaMenorComestreDTO BuscarFormato(int Codigo)
        {
            EjercicioTipoArmaMenorComestreDTO ejercicioTipoArmaMenorComestreDTO = new EjercicioTipoArmaMenorComestreDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EjercicioTipoArmaMenorComestreEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EjercicioTipoArmaMenorComestreId", SqlDbType.Int);
                    cmd.Parameters["@EjercicioTipoArmaMenorComestreId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        ejercicioTipoArmaMenorComestreDTO.EjercicioTipoArmaMenorComestreId = Convert.ToInt32(dr["EjercicioTipoArmaMenorComestreId"]);
                        ejercicioTipoArmaMenorComestreDTO.EspecialidadGenericaPersonalId = Convert.ToInt32(dr["EspecialidadGenericaPersonalId"]);
                        ejercicioTipoArmaMenorComestreDTO.GradoPersonalMilitarId = Convert.ToInt32(dr["GradoPersonalMilitarId"]);
                        ejercicioTipoArmaMenorComestreDTO.FechaEjercicio = Convert.ToDateTime(dr["FechaEjercicio"]).ToString("yyy-MM-dd");
                        ejercicioTipoArmaMenorComestreDTO.TipoArmamentoId = Convert.ToInt32(dr["TipoArmamentoId"]);
                        ejercicioTipoArmaMenorComestreDTO.Posicion = dr["Posicion"].ToString();
                        ejercicioTipoArmaMenorComestreDTO.DistanciaMetro = Convert.ToInt32(dr["DistanciaMetro"]);
                        ejercicioTipoArmaMenorComestreDTO.CantidadTipo = Convert.ToInt32(dr["CantidadTipo"]); 
 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return ejercicioTipoArmaMenorComestreDTO;
        }

        public string ActualizaFormato(EjercicioTipoArmaMenorComestreDTO ejercicioTipoArmaMenorComestreDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_EjercicioTipoArmaMenorComestreActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@EjercicioTipoArmaMenorComestreId", SqlDbType.Int);
                    cmd.Parameters["@EjercicioTipoArmaMenorComestreId"].Value = ejercicioTipoArmaMenorComestreDTO.EjercicioTipoArmaMenorComestreId;

                    cmd.Parameters.Add("@EspecialidadGenericaPersonalId", SqlDbType.Int);
                    cmd.Parameters["@EspecialidadGenericaPersonalId"].Value = ejercicioTipoArmaMenorComestreDTO.EspecialidadGenericaPersonalId;

                    cmd.Parameters.Add("@GradoPersonalMilitarId", SqlDbType.Int);
                    cmd.Parameters["@GradoPersonalMilitarId"].Value = ejercicioTipoArmaMenorComestreDTO.GradoPersonalMilitarId;

                    cmd.Parameters.Add("@FechaEjercicio", SqlDbType.Date);
                    cmd.Parameters["@FechaEjercicio"].Value = ejercicioTipoArmaMenorComestreDTO.FechaEjercicio;

                    cmd.Parameters.Add("@TipoArmamentoId", SqlDbType.Int);
                    cmd.Parameters["@TipoArmamentoId"].Value = ejercicioTipoArmaMenorComestreDTO.TipoArmamentoId;

                    cmd.Parameters.Add("@Posicion", SqlDbType.VarChar,2);
                    cmd.Parameters["@Posicion"].Value = ejercicioTipoArmaMenorComestreDTO.Posicion;

                    cmd.Parameters.Add("@DistanciaMetro", SqlDbType.Int);
                    cmd.Parameters["@DistanciaMetro"].Value = ejercicioTipoArmaMenorComestreDTO.DistanciaMetro;

                    cmd.Parameters.Add("@CantidadTipo", SqlDbType.Int);
                    cmd.Parameters["@CantidadTipo"].Value = ejercicioTipoArmaMenorComestreDTO.CantidadTipo;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ejercicioTipoArmaMenorComestreDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(EjercicioTipoArmaMenorComestreDTO ejercicioTipoArmaMenorComestreDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EjercicioTipoArmaMenorComestreEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EjercicioTipoArmaMenorComestreId", SqlDbType.Int);
                    cmd.Parameters["@EjercicioTipoArmaMenorComestreId"].Value = ejercicioTipoArmaMenorComestreDTO.EjercicioTipoArmaMenorComestreId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ejercicioTipoArmaMenorComestreDTO.UsuarioIngresoRegistro;

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


        public bool InsercionMasiva(IEnumerable<EjercicioTipoArmaMenorComestreDTO> ejercicioTipoArmaMenorComestreDTO)
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
                            foreach (var item in ejercicioTipoArmaMenorComestreDTO)
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
