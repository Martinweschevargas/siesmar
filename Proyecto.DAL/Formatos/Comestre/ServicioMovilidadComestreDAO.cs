using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comestre;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comestre
{
    public class ServicioMovilidadComestreDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<ServicioMovilidadComestreDTO> ObtenerLista()
        {
            List<ServicioMovilidadComestreDTO> lista = new List<ServicioMovilidadComestreDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_ServicioMovilidadComestreListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ServicioMovilidadComestreDTO()
                        {
                            ServicioMovilidadComestreId = Convert.ToInt32(dr["ServicioMovilidadComestreId"]),
                            FechaInicio = (dr["FechaInicio"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            FechaTermino = (dr["FechaTermino"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            DescDependencia = dr["DescDependencia"].ToString(),
                            DescClaseVehiculo = dr["DescClaseVehiculo"].ToString(),
                            DescMarcaVehiculo = dr["DescMarcaVehiculo"].ToString(),
                            Carroceria = dr["Carroceria"].ToString(),
                            PlacaRodaje = dr["PlacaRodaje"].ToString(),
                            EstadoOperatividad = dr["EstadoOperatividad"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(ServicioMovilidadComestreDTO servicioMovilidadComestreDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ServicioMovilidadComestreRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FechaInicio", SqlDbType.Date);
                    cmd.Parameters["@FechaInicio"].Value = servicioMovilidadComestreDTO.FechaInicio;

                    cmd.Parameters.Add("@FechaTermino", SqlDbType.Date);
                    cmd.Parameters["@FechaTermino"].Value = servicioMovilidadComestreDTO.FechaTermino;

                    cmd.Parameters.Add("@DependenciaId", SqlDbType.Int);
                    cmd.Parameters["@DependenciaId"].Value = servicioMovilidadComestreDTO.DependenciaId;

                    cmd.Parameters.Add("@ClaseVehiculoId", SqlDbType.Int);
                    cmd.Parameters["@ClaseVehiculoId"].Value = servicioMovilidadComestreDTO.ClaseVehiculoId;

                    cmd.Parameters.Add("@MarcaVehiculoId", SqlDbType.Int);
                    cmd.Parameters["@MarcaVehiculoId"].Value = servicioMovilidadComestreDTO.MarcaVehiculoId;

                    cmd.Parameters.Add("@Carroceria", SqlDbType.VarChar,10);
                    cmd.Parameters["@Carroceria"].Value = servicioMovilidadComestreDTO.Carroceria;

                    cmd.Parameters.Add("@PlacaRodaje", SqlDbType.VarChar,10);
                    cmd.Parameters["@PlacaRodaje"].Value = servicioMovilidadComestreDTO.PlacaRodaje;

                    cmd.Parameters.Add("@EstadoOperatividad", SqlDbType.VarChar,1);
                    cmd.Parameters["@EstadoOperatividad"].Value = servicioMovilidadComestreDTO.EstadoOperatividad;

                    cmd.Parameters.Add("@YEAR", SqlDbType.Int);
                    cmd.Parameters["@YEAR"].Value = servicioMovilidadComestreDTO.Año;

                    cmd.Parameters.Add("@MES", SqlDbType.Int);
                    cmd.Parameters["@MES"].Value = servicioMovilidadComestreDTO.Mes;

                    cmd.Parameters.Add("@DIA", SqlDbType.Int);
                    cmd.Parameters["@DIA"].Value = servicioMovilidadComestreDTO.Dia;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = servicioMovilidadComestreDTO.UsuarioIngresoRegistro;

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

        public ServicioMovilidadComestreDTO BuscarFormato(int Codigo)
        {
            ServicioMovilidadComestreDTO servicioMovilidadComestreDTO = new ServicioMovilidadComestreDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ServicioMovilidadComestreEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ServicioMovilidadComestreId", SqlDbType.Int);
                    cmd.Parameters["@ServicioMovilidadComestreId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        servicioMovilidadComestreDTO.ServicioMovilidadComestreId = Convert.ToInt32(dr["ServicioMovilidadComestreId"]);
                        servicioMovilidadComestreDTO.FechaInicio = Convert.ToDateTime(dr["FechaInicio"]).ToString("yyy-MM-dd");
                        servicioMovilidadComestreDTO.FechaTermino = Convert.ToDateTime(dr["FechaTermino"]).ToString("yyy-MM-dd");
                        servicioMovilidadComestreDTO.DependenciaId = Convert.ToInt32(dr["DependenciaId"]);
                        servicioMovilidadComestreDTO.ClaseVehiculoId = Convert.ToInt32(dr["ClaseVehiculoId"]);
                        servicioMovilidadComestreDTO.MarcaVehiculoId = Convert.ToInt32(dr["MarcaVehiculoId"]);
                        servicioMovilidadComestreDTO.Carroceria = dr["Carroceria"].ToString();
                        servicioMovilidadComestreDTO.PlacaRodaje = dr["PlacaRodaje"].ToString();
                        servicioMovilidadComestreDTO.EstadoOperatividad = dr["EstadoOperatividad"].ToString(); 


                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return servicioMovilidadComestreDTO;
        }

        public string ActualizaFormato(ServicioMovilidadComestreDTO servicioMovilidadComestreDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_ServicioMovilidadComestreActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@ServicioMovilidadComestreId", SqlDbType.Int);
                    cmd.Parameters["@ServicioMovilidadComestreId"].Value = servicioMovilidadComestreDTO.ServicioMovilidadComestreId;

                    cmd.Parameters.Add("@FechaInicio", SqlDbType.Date);
                    cmd.Parameters["@FechaInicio"].Value = servicioMovilidadComestreDTO.FechaInicio;

                    cmd.Parameters.Add("@FechaTermino", SqlDbType.Date);
                    cmd.Parameters["@FechaTermino"].Value = servicioMovilidadComestreDTO.FechaTermino;

                    cmd.Parameters.Add("@DependenciaId", SqlDbType.Int);
                    cmd.Parameters["@DependenciaId"].Value = servicioMovilidadComestreDTO.DependenciaId;

                    cmd.Parameters.Add("@ClaseVehiculoId", SqlDbType.Int);
                    cmd.Parameters["@ClaseVehiculoId"].Value = servicioMovilidadComestreDTO.ClaseVehiculoId;

                    cmd.Parameters.Add("@MarcaVehiculoId", SqlDbType.Int);
                    cmd.Parameters["@MarcaVehiculoId"].Value = servicioMovilidadComestreDTO.MarcaVehiculoId;

                    cmd.Parameters.Add("@Carroceria", SqlDbType.VarChar,10);
                    cmd.Parameters["@Carroceria"].Value = servicioMovilidadComestreDTO.Carroceria;

                    cmd.Parameters.Add("@PlacaRodaje", SqlDbType.VarChar,10);
                    cmd.Parameters["@PlacaRodaje"].Value = servicioMovilidadComestreDTO.PlacaRodaje;

                    cmd.Parameters.Add("@EstadoOperatividad", SqlDbType.VarChar,1);
                    cmd.Parameters["@EstadoOperatividad"].Value = servicioMovilidadComestreDTO.EstadoOperatividad;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = servicioMovilidadComestreDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(ServicioMovilidadComestreDTO servicioMovilidadComestreDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ServicioMovilidadComestreEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ServicioMovilidadComestreId", SqlDbType.Int);
                    cmd.Parameters["@ServicioMovilidadComestreId"].Value = servicioMovilidadComestreDTO.ServicioMovilidadComestreId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = servicioMovilidadComestreDTO.UsuarioIngresoRegistro;

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

        public bool InsercionMasiva(IEnumerable<ServicioMovilidadComestreDTO> servicioMovilidadComestreDTO)
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
                            foreach (var item in servicioMovilidadComestreDTO)
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
