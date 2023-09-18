using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comestre;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comestre
{
    public class ServicioSastreriaComestreDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<ServicioSastreriaComestreDTO> ObtenerLista()
        {
            List<ServicioSastreriaComestreDTO> lista = new List<ServicioSastreriaComestreDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_ServicioSastreriaComestreListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ServicioSastreriaComestreDTO()
                        {
                            ServicioSastreriaComestreId = Convert.ToInt32(dr["ServicioSastreriaComestreId"]),
                            FechaIngreso = (dr["FechaIngreso"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            FechaRecojo = (dr["FechaRecojo"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            CIP = Convert.ToInt32(dr["CIP"]),
                            DescGrado = dr["DescGrado"].ToString(),
                            DescEspecialidad = dr["DescEspecialidad"].ToString(),
                            SexoPersonal = dr["SexoPersonal"].ToString(),
                            DescDependencia = dr["DescDependencia"].ToString(),
                            NumeroPrenda = Convert.ToInt32(dr["NumeroPrenda"]),
                            DescServicioSastreria = dr["DescServicioSastreria"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(ServicioSastreriaComestreDTO ServicioSastreriaComestreDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ServicioSastreriaComestreRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FechaIngreso", SqlDbType.Date);
                    cmd.Parameters["@FechaIngreso"].Value = ServicioSastreriaComestreDTO.FechaIngreso;

                    cmd.Parameters.Add("@FechaRecojo", SqlDbType.Date);
                    cmd.Parameters["@FechaRecojo"].Value = ServicioSastreriaComestreDTO.FechaRecojo;

                    cmd.Parameters.Add("@CIP", SqlDbType.Int);
                    cmd.Parameters["@CIP"].Value = ServicioSastreriaComestreDTO.CIP;

                    cmd.Parameters.Add("@GradoPersonalMilitarId", SqlDbType.Int);
                    cmd.Parameters["@GradoPersonalMilitarId"].Value = ServicioSastreriaComestreDTO.GradoPersonalMilitarId;

                    cmd.Parameters.Add("@EspecialidadGenericaPersonalId", SqlDbType.Int);
                    cmd.Parameters["@EspecialidadGenericaPersonalId"].Value = ServicioSastreriaComestreDTO.EspecialidadGenericaPersonalId;

                    cmd.Parameters.Add("@SexoPersonal", SqlDbType.VarChar,10);
                    cmd.Parameters["@SexoPersonal"].Value = ServicioSastreriaComestreDTO.SexoPersonal;

                    cmd.Parameters.Add("@DependenciaId", SqlDbType.Int);
                    cmd.Parameters["@DependenciaId"].Value = ServicioSastreriaComestreDTO.DependenciaId;

                    cmd.Parameters.Add("@NumeroPrenda", SqlDbType.Int);
                    cmd.Parameters["@NumeroPrenda"].Value = ServicioSastreriaComestreDTO.NumeroPrenda;

                    cmd.Parameters.Add("@TipoServicioSastreriaId", SqlDbType.Int);
                    cmd.Parameters["@TipoServicioSastreriaId"].Value = ServicioSastreriaComestreDTO.TipoServicioSastreriaId;

                    cmd.Parameters.Add("@YEAR", SqlDbType.Int);
                    cmd.Parameters["@YEAR"].Value = ServicioSastreriaComestreDTO.Año;

                    cmd.Parameters.Add("@MES", SqlDbType.Int);
                    cmd.Parameters["@MES"].Value = ServicioSastreriaComestreDTO.Mes;

                    cmd.Parameters.Add("@DIA", SqlDbType.Int);
                    cmd.Parameters["@DIA"].Value = ServicioSastreriaComestreDTO.Dia;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ServicioSastreriaComestreDTO.UsuarioIngresoRegistro;

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

        public ServicioSastreriaComestreDTO BuscarFormato(int Codigo)
        {
            ServicioSastreriaComestreDTO ServicioSastreriaComestreDTO = new ServicioSastreriaComestreDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ServicioSastreriaComestreEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ServicioSastreriaComestreId", SqlDbType.Int);
                    cmd.Parameters["@ServicioSastreriaComestreId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        ServicioSastreriaComestreDTO.ServicioSastreriaComestreId = Convert.ToInt32(dr["ServicioSastreriaComestreId"]);
                        ServicioSastreriaComestreDTO.FechaIngreso = Convert.ToDateTime(dr["FechaIngreso"]).ToString("yyy-MM-dd");
                        ServicioSastreriaComestreDTO.FechaRecojo = Convert.ToDateTime(dr["FechaRecojo"]).ToString("yyy-MM-dd");
                        ServicioSastreriaComestreDTO.CIP = Convert.ToInt32(dr["CIP"]);
                        ServicioSastreriaComestreDTO.GradoPersonalMilitarId = Convert.ToInt32(dr["GradoPersonalMilitarId"]);
                        ServicioSastreriaComestreDTO.EspecialidadGenericaPersonalId = Convert.ToInt32(dr["EspecialidadGenericaPersonalId"]);
                        ServicioSastreriaComestreDTO.SexoPersonal = dr["SexoPersonal"].ToString();
                        ServicioSastreriaComestreDTO.DependenciaId = Convert.ToInt32(dr["DependenciaId"]);
                        ServicioSastreriaComestreDTO.NumeroPrenda = Convert.ToInt32(dr["NumeroPrenda"]);
                        ServicioSastreriaComestreDTO.TipoServicioSastreriaId = Convert.ToInt32(dr["TipoServicioSastreriaId"]); 
 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return ServicioSastreriaComestreDTO;
        }

        public string ActualizaFormato(ServicioSastreriaComestreDTO ServicioSastreriaComestreDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_ServicioSastreriaComestreActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@ServicioSastreriaComestreId", SqlDbType.Int);
                    cmd.Parameters["@ServicioSastreriaComestreId"].Value = ServicioSastreriaComestreDTO.ServicioSastreriaComestreId;

                    cmd.Parameters.Add("@FechaIngreso", SqlDbType.Date);
                    cmd.Parameters["@FechaIngreso"].Value = ServicioSastreriaComestreDTO.FechaIngreso;

                    cmd.Parameters.Add("@FechaRecojo", SqlDbType.Date);
                    cmd.Parameters["@FechaRecojo"].Value = ServicioSastreriaComestreDTO.FechaRecojo;

                    cmd.Parameters.Add("@CIP", SqlDbType.Int);
                    cmd.Parameters["@CIP"].Value = ServicioSastreriaComestreDTO.CIP;

                    cmd.Parameters.Add("@GradoPersonalMilitarId", SqlDbType.Int);
                    cmd.Parameters["@GradoPersonalMilitarId"].Value = ServicioSastreriaComestreDTO.GradoPersonalMilitarId;

                    cmd.Parameters.Add("@EspecialidadGenericaPersonalId", SqlDbType.Int);
                    cmd.Parameters["@EspecialidadGenericaPersonalId"].Value = ServicioSastreriaComestreDTO.EspecialidadGenericaPersonalId;

                    cmd.Parameters.Add("@SexoPersonal", SqlDbType.VarChar,10);
                    cmd.Parameters["@SexoPersonal"].Value = ServicioSastreriaComestreDTO.SexoPersonal;

                    cmd.Parameters.Add("@DependenciaId", SqlDbType.Int);
                    cmd.Parameters["@DependenciaId"].Value = ServicioSastreriaComestreDTO.DependenciaId;

                    cmd.Parameters.Add("@NumeroPrenda", SqlDbType.Int);
                    cmd.Parameters["@NumeroPrenda"].Value = ServicioSastreriaComestreDTO.NumeroPrenda;

                    cmd.Parameters.Add("@TipoServicioSastreriaId", SqlDbType.Int);
                    cmd.Parameters["@TipoServicioSastreriaId"].Value = ServicioSastreriaComestreDTO.TipoServicioSastreriaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ServicioSastreriaComestreDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(ServicioSastreriaComestreDTO ServicioSastreriaComestreDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ServicioSastreriaComestreEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ServicioSastreriaComestreId", SqlDbType.Int);
                    cmd.Parameters["@ServicioSastreriaComestreId"].Value = ServicioSastreriaComestreDTO.ServicioSastreriaComestreId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ServicioSastreriaComestreDTO.UsuarioIngresoRegistro;

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

        public bool InsercionMasiva(IEnumerable<ServicioSastreriaComestreDTO> servicioSastreriaComestreDTO)
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
                            foreach (var item in servicioSastreriaComestreDTO)
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
