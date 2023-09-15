using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comestre;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comestre
{
    public class ServicioAlimentacionComestreDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<ServicioAlimentacionComestreDTO> ObtenerLista()
        {
            List<ServicioAlimentacionComestreDTO> lista = new List<ServicioAlimentacionComestreDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_ServicioAlimentacionComestreListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ServicioAlimentacionComestreDTO()
                        {
                            ServicioAlimentacionComestreId = Convert.ToInt32(dr["ServicioAlimentacionComestreId"]),
                            NumeroRacion = Convert.ToInt32(dr["NumeroRacion"]),
                            DescMes = dr["DescMes"].ToString(),
                            PeriodoDias = Convert.ToInt32(dr["PeriodoDias"]),
                            DescDependencia = dr["DescDependencia"].ToString(),
                            CantidadPersupe = Convert.ToInt32(dr["CantidadPersupe"]),
                            CantidadPersuba = Convert.ToInt32(dr["CantidadPersuba"]),
                            CantidadPermar = Convert.ToInt32(dr["CantidadPermar"]),
                            Vacacion = Convert.ToInt32(dr["Vacacion"]),
                            TotalPersonalDiaHabil = Convert.ToInt32(dr["TotalPersonalDiaHabil"]),
                            TotalPersonalDiaNoHabil = Convert.ToInt32(dr["TotalPersonalDiaNoHabil"]),
                            DiaHabil = Convert.ToInt32(dr["DiaHabil"]),
                            DiaNoHabil = Convert.ToInt32(dr["DiaNoHabil"]),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(ServicioAlimentacionComestreDTO servicioAlimentacionComestreDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ServicioAlimentacionComestreRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@NumeroRacion", SqlDbType.Int);
                    cmd.Parameters["@NumeroRacion"].Value = servicioAlimentacionComestreDTO.NumeroRacion;

                    cmd.Parameters.Add("@MesId", SqlDbType.Int);
                    cmd.Parameters["@MesId"].Value = servicioAlimentacionComestreDTO.MesId;

                    cmd.Parameters.Add("@PeriodoDias", SqlDbType.Int);
                    cmd.Parameters["@PeriodoDias"].Value = servicioAlimentacionComestreDTO.PeriodoDias;

                    cmd.Parameters.Add("@DependenciaId", SqlDbType.Int);
                    cmd.Parameters["@DependenciaId"].Value = servicioAlimentacionComestreDTO.DependenciaId;

                    cmd.Parameters.Add("@CantidadPersupe", SqlDbType.Int);
                    cmd.Parameters["@CantidadPersupe"].Value = servicioAlimentacionComestreDTO.CantidadPersupe;

                    cmd.Parameters.Add("@CantidadPersuba", SqlDbType.Int);
                    cmd.Parameters["@CantidadPersuba"].Value = servicioAlimentacionComestreDTO.CantidadPersuba;

                    cmd.Parameters.Add("@CantidadPermar", SqlDbType.Int);
                    cmd.Parameters["@CantidadPermar"].Value = servicioAlimentacionComestreDTO.CantidadPermar;

                    cmd.Parameters.Add("@Vacacion", SqlDbType.Int);
                    cmd.Parameters["@Vacacion"].Value = servicioAlimentacionComestreDTO.Vacacion;

                    cmd.Parameters.Add("@TotalPersonalDiaHabil", SqlDbType.Int);
                    cmd.Parameters["@TotalPersonalDiaHabil"].Value = servicioAlimentacionComestreDTO.TotalPersonalDiaHabil;

                    cmd.Parameters.Add("@TotalPersonalDiaNoHabil", SqlDbType.Int);
                    cmd.Parameters["@TotalPersonalDiaNoHabil"].Value = servicioAlimentacionComestreDTO.TotalPersonalDiaNoHabil;

                    cmd.Parameters.Add("@DiaHabil", SqlDbType.Int);
                    cmd.Parameters["@DiaHabil"].Value = servicioAlimentacionComestreDTO.DiaHabil;

                    cmd.Parameters.Add("@DiaNoHabil", SqlDbType.Int);
                    cmd.Parameters["@DiaNoHabil"].Value = servicioAlimentacionComestreDTO.DiaNoHabil;

                    cmd.Parameters.Add("@YEAR", SqlDbType.Int);
                    cmd.Parameters["@YEAR"].Value = servicioAlimentacionComestreDTO.Año;

                    cmd.Parameters.Add("@MES", SqlDbType.Int);
                    cmd.Parameters["@MES"].Value = servicioAlimentacionComestreDTO.Mes;

                    cmd.Parameters.Add("@DIA", SqlDbType.Int);
                    cmd.Parameters["@DIA"].Value = servicioAlimentacionComestreDTO.Dia;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = servicioAlimentacionComestreDTO.UsuarioIngresoRegistro;

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

        public ServicioAlimentacionComestreDTO BuscarFormato(int Codigo)
        {
            ServicioAlimentacionComestreDTO servicioAlimentacionComestreDTO = new ServicioAlimentacionComestreDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ServicioAlimentacionComestreEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ServicioAlimentacionComestreId", SqlDbType.Int);
                    cmd.Parameters["@ServicioAlimentacionComestreId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        servicioAlimentacionComestreDTO.ServicioAlimentacionComestreId = Convert.ToInt32(dr["ServicioAlimentacionComestreId"]);
                        servicioAlimentacionComestreDTO.NumeroRacion = Convert.ToInt32(dr["NumeroRacion"]);
                        servicioAlimentacionComestreDTO.MesId = Convert.ToInt32(dr["MesId"]);
                        servicioAlimentacionComestreDTO.PeriodoDias = Convert.ToInt32(dr["PeriodoDias"]);
                        servicioAlimentacionComestreDTO.DependenciaId = Convert.ToInt32(dr["DependenciaId"]);
                        servicioAlimentacionComestreDTO.CantidadPersupe = Convert.ToInt32(dr["CantidadPersupe"]);
                        servicioAlimentacionComestreDTO.CantidadPersuba = Convert.ToInt32(dr["CantidadPersuba"]);
                        servicioAlimentacionComestreDTO.CantidadPermar = Convert.ToInt32(dr["CantidadPermar"]);
                        servicioAlimentacionComestreDTO.Vacacion = Convert.ToInt32(dr["Vacacion"]);
                        servicioAlimentacionComestreDTO.TotalPersonalDiaHabil = Convert.ToInt32(dr["TotalPersonalDiaHabil"]);
                        servicioAlimentacionComestreDTO.TotalPersonalDiaNoHabil = Convert.ToInt32(dr["TotalPersonalDiaNoHabil"]);
                        servicioAlimentacionComestreDTO.DiaHabil = Convert.ToInt32(dr["DiaHabil"]);
                        servicioAlimentacionComestreDTO.DiaNoHabil = Convert.ToInt32(dr["DiaNoHabil"]); 


                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return servicioAlimentacionComestreDTO;
        }

        public string ActualizaFormato(ServicioAlimentacionComestreDTO servicioAlimentacionComestreDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_ServicioAlimentacionComestreActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@ServicioAlimentacionComestreId", SqlDbType.Int);
                    cmd.Parameters["@ServicioAlimentacionComestreId"].Value = servicioAlimentacionComestreDTO.ServicioAlimentacionComestreId;

                    cmd.Parameters.Add("@NumeroRacion", SqlDbType.Int);
                    cmd.Parameters["@NumeroRacion"].Value = servicioAlimentacionComestreDTO.NumeroRacion;

                    cmd.Parameters.Add("@MesId", SqlDbType.Int);
                    cmd.Parameters["@MesId"].Value = servicioAlimentacionComestreDTO.MesId;

                    cmd.Parameters.Add("@PeriodoDias", SqlDbType.Int);
                    cmd.Parameters["@PeriodoDias"].Value = servicioAlimentacionComestreDTO.PeriodoDias;

                    cmd.Parameters.Add("@DependenciaId", SqlDbType.Int);
                    cmd.Parameters["@DependenciaId"].Value = servicioAlimentacionComestreDTO.DependenciaId;

                    cmd.Parameters.Add("@CantidadPersupe", SqlDbType.Int);
                    cmd.Parameters["@CantidadPersupe"].Value = servicioAlimentacionComestreDTO.CantidadPersupe;

                    cmd.Parameters.Add("@CantidadPersuba", SqlDbType.Int);
                    cmd.Parameters["@CantidadPersuba"].Value = servicioAlimentacionComestreDTO.CantidadPersuba;

                    cmd.Parameters.Add("@CantidadPermar", SqlDbType.Int);
                    cmd.Parameters["@CantidadPermar"].Value = servicioAlimentacionComestreDTO.CantidadPermar;

                    cmd.Parameters.Add("@Vacacion", SqlDbType.Int);
                    cmd.Parameters["@Vacacion"].Value = servicioAlimentacionComestreDTO.Vacacion;

                    cmd.Parameters.Add("@TotalPersonalDiaHabil", SqlDbType.Int);
                    cmd.Parameters["@TotalPersonalDiaHabil"].Value = servicioAlimentacionComestreDTO.TotalPersonalDiaHabil;

                    cmd.Parameters.Add("@TotalPersonalDiaNoHabil", SqlDbType.Int);
                    cmd.Parameters["@TotalPersonalDiaNoHabil"].Value = servicioAlimentacionComestreDTO.TotalPersonalDiaNoHabil;

                    cmd.Parameters.Add("@DiaHabil", SqlDbType.Int);
                    cmd.Parameters["@DiaHabil"].Value = servicioAlimentacionComestreDTO.DiaHabil;

                    cmd.Parameters.Add("@DiaNoHabil", SqlDbType.Int);
                    cmd.Parameters["@DiaNoHabil"].Value = servicioAlimentacionComestreDTO.DiaNoHabil;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = servicioAlimentacionComestreDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(ServicioAlimentacionComestreDTO servicioAlimentacionComestreDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ServicioAlimentacionComestreEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ServicioAlimentacionComestreId", SqlDbType.Int);
                    cmd.Parameters["@ServicioAlimentacionComestreId"].Value = servicioAlimentacionComestreDTO.ServicioAlimentacionComestreId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = servicioAlimentacionComestreDTO.UsuarioIngresoRegistro;

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

        public bool InsercionMasiva(IEnumerable<ServicioAlimentacionComestreDTO> servicioAlimentacionComestreDTO)
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
                            foreach (var item in servicioAlimentacionComestreDTO)
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
