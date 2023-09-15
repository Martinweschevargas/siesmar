using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Dicapi;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dicapi
{
    public class OtorgamientoDerechoAreaAcuaticaDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<OtorgamientoDerechoAreaAcuaticaDTO> ObtenerLista(int? CargaId = null)
        {
            List<OtorgamientoDerechoAreaAcuaticaDTO> lista = new List<OtorgamientoDerechoAreaAcuaticaDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_OtorgamientoDerechoAreaAcuaticaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new OtorgamientoDerechoAreaAcuaticaDTO()
                        {
                            OtorgamientoDerechoAreaAcuaticaId = Convert.ToInt32(dr["OtorgamientoDerechoAreaAcuaticaId"]),
                            NumeroDocumento = Convert.ToInt32(dr["NumeroDocumento"]),
                            FechaIngresoSolicitud = (dr["FechaIngresoSolicitud"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            DescDptoRiberaZocaloCont = dr["DescDptoRiberaZocaloCont"].ToString(),
                            PropietarioNave = dr["PropietarioNave"].ToString(),
                            DescInstalacionTerrestreAcuatica = dr["DescInstalacionTerrestreAcuatica"].ToString(),
                            DescDepartamento = dr["DescDepartamento"].ToString(),
                            DescProvincia = dr["DescProvincia"].ToString(),
                            DescDistrito = dr["DescDistrito"].ToString(),
                            TiempoConcesion = Convert.ToInt32(dr["TipoConcesion"]),
                            TipoTiempo = dr["TipoTiempo"].ToString(),
                            FechaAtencionSolicitud = (dr["FechaAtencionSolicitud"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            CargaId = Convert.ToInt32(dr["CargaId"])
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(OtorgamientoDerechoAreaAcuaticaDTO otorgamientoDerechoAreaAcuaticaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_OtorgamientoDerechoAreaAcuaticaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@NumeroDocumento", SqlDbType.Int);
                    cmd.Parameters["@NumeroDocumento"].Value = otorgamientoDerechoAreaAcuaticaDTO.NumeroDocumento;

                    cmd.Parameters.Add("@FechaIngresoSolicitud", SqlDbType.Date);
                    cmd.Parameters["@FechaIngresoSolicitud"].Value = otorgamientoDerechoAreaAcuaticaDTO.FechaIngresoSolicitud;

                    cmd.Parameters.Add("@CodigoDptoRiberaZocaloCont", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDptoRiberaZocaloCont"].Value = otorgamientoDerechoAreaAcuaticaDTO.CodigoDptoRiberaZocaloCont;

                    cmd.Parameters.Add("@PropietarioNave", SqlDbType.VarChar,100);
                    cmd.Parameters["@PropietarioNave"].Value = otorgamientoDerechoAreaAcuaticaDTO.PropietarioNave;

                    cmd.Parameters.Add("@CodigoInstalacionTerrestreAcuatica", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoInstalacionTerrestreAcuatica"].Value = otorgamientoDerechoAreaAcuaticaDTO.CodigoInstalacionTerrestreAcuatica;

                    cmd.Parameters.Add("@DistritoUbigeo", SqlDbType.VarChar, 20);
                    cmd.Parameters["@DistritoUbigeo"].Value = otorgamientoDerechoAreaAcuaticaDTO.DistritoUbigeo;

                    cmd.Parameters.Add("@TiempoConcesion", SqlDbType.Int);
                    cmd.Parameters["@TiempoConcesion"].Value = otorgamientoDerechoAreaAcuaticaDTO.TiempoConcesion;

                    cmd.Parameters.Add("@TipoTiempo", SqlDbType.VarChar,10);
                    cmd.Parameters["@TipoTiempo"].Value = otorgamientoDerechoAreaAcuaticaDTO.TipoTiempo;

                    cmd.Parameters.Add("@FechaAtencionSolicitud", SqlDbType.Date);
                    cmd.Parameters["@FechaAtencionSolicitud"].Value = otorgamientoDerechoAreaAcuaticaDTO.FechaAtencionSolicitud;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = otorgamientoDerechoAreaAcuaticaDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = otorgamientoDerechoAreaAcuaticaDTO.UsuarioIngresoRegistro;

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

        public OtorgamientoDerechoAreaAcuaticaDTO BuscarFormato(int Codigo)
        {
            OtorgamientoDerechoAreaAcuaticaDTO otorgamientoDerechoAreaAcuaticaDTO = new OtorgamientoDerechoAreaAcuaticaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_OtorgamientoDerechoAreaAcuaticaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@OtorgamientoDerechoAreaAcuaticaId", SqlDbType.Int);
                    cmd.Parameters["@OtorgamientoDerechoAreaAcuaticaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        otorgamientoDerechoAreaAcuaticaDTO.OtorgamientoDerechoAreaAcuaticaId = Convert.ToInt32(dr["OtorgamientoDerechoAreaAcuaticaId"]);
                        otorgamientoDerechoAreaAcuaticaDTO.NumeroDocumento = Convert.ToInt32(dr["NumeroDocumento"]);
                        otorgamientoDerechoAreaAcuaticaDTO.FechaIngresoSolicitud = Convert.ToDateTime(dr["FechaIngresoSolicitud"]).ToString("yyy-MM-dd");
                        otorgamientoDerechoAreaAcuaticaDTO.CodigoDptoRiberaZocaloCont = dr["CodigoDptoRiberaZocaloCont"].ToString();
                        otorgamientoDerechoAreaAcuaticaDTO.PropietarioNave = dr["PropietarioNave"].ToString();
                        otorgamientoDerechoAreaAcuaticaDTO.CodigoInstalacionTerrestreAcuatica = dr["CodigoInstalacionTerrestreAcuatica"].ToString();
                        otorgamientoDerechoAreaAcuaticaDTO.DistritoUbigeo = dr["DistritoUbigeo"].ToString();
                        otorgamientoDerechoAreaAcuaticaDTO.TiempoConcesion = Convert.ToInt32(dr["TiempoConcesion"]);
                        otorgamientoDerechoAreaAcuaticaDTO.TipoTiempo = dr["TipoTiempo"].ToString();
                        otorgamientoDerechoAreaAcuaticaDTO.FechaAtencionSolicitud = Convert.ToDateTime(dr["FechaAtencionSolicitud"]).ToString("yyy-MM-dd"); 
 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return otorgamientoDerechoAreaAcuaticaDTO;
        }

        public string ActualizaFormato(OtorgamientoDerechoAreaAcuaticaDTO otorgamientoDerechoAreaAcuaticaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_OtorgamientoDerechoAreaAcuaticaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@OtorgamientoDerechoAreaAcuaticaId", SqlDbType.Int);
                    cmd.Parameters["@OtorgamientoDerechoAreaAcuaticaId"].Value = otorgamientoDerechoAreaAcuaticaDTO.OtorgamientoDerechoAreaAcuaticaId;

                    cmd.Parameters.Add("@NumeroDocumento", SqlDbType.Int);
                    cmd.Parameters["@NumeroDocumento"].Value = otorgamientoDerechoAreaAcuaticaDTO.NumeroDocumento;

                    cmd.Parameters.Add("@FechaIngresoSolicitud", SqlDbType.Date);
                    cmd.Parameters["@FechaIngresoSolicitud"].Value = otorgamientoDerechoAreaAcuaticaDTO.FechaIngresoSolicitud;

                    cmd.Parameters.Add("@CodigoDptoRiberaZocaloCont", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoDptoRiberaZocaloCont"].Value = otorgamientoDerechoAreaAcuaticaDTO.CodigoDptoRiberaZocaloCont;

                    cmd.Parameters.Add("@PropietarioNave", SqlDbType.VarChar,100);
                    cmd.Parameters["@PropietarioNave"].Value = otorgamientoDerechoAreaAcuaticaDTO.PropietarioNave;

                    cmd.Parameters.Add("@CodigoInstalacionTerrestreAcuatica", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoInstalacionTerrestreAcuatica"].Value = otorgamientoDerechoAreaAcuaticaDTO.CodigoInstalacionTerrestreAcuatica;

                    cmd.Parameters.Add("@DistritoUbigeo", SqlDbType.VarChar, 20);
                    cmd.Parameters["@DistritoUbigeo"].Value = otorgamientoDerechoAreaAcuaticaDTO.DistritoUbigeo;

                    cmd.Parameters.Add("@TiempoConcesion", SqlDbType.Int);
                    cmd.Parameters["@TiempoConcesion"].Value = otorgamientoDerechoAreaAcuaticaDTO.TiempoConcesion;

                    cmd.Parameters.Add("@TipoTiempo", SqlDbType.VarChar,10);
                    cmd.Parameters["@TipoTiempo"].Value = otorgamientoDerechoAreaAcuaticaDTO.TipoTiempo;

                    cmd.Parameters.Add("@FechaAtencionSolicitud", SqlDbType.Date);
                    cmd.Parameters["@FechaAtencionSolicitud"].Value = otorgamientoDerechoAreaAcuaticaDTO.FechaAtencionSolicitud;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = otorgamientoDerechoAreaAcuaticaDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(OtorgamientoDerechoAreaAcuaticaDTO otorgamientoDerechoAreaAcuaticaDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_OtorgamientoDerechoAreaAcuaticaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@OtorgamientoDerechoAreaAcuaticaId", SqlDbType.Int);
                    cmd.Parameters["@OtorgamientoDerechoAreaAcuaticaId"].Value = otorgamientoDerechoAreaAcuaticaDTO.OtorgamientoDerechoAreaAcuaticaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = otorgamientoDerechoAreaAcuaticaDTO.UsuarioIngresoRegistro;

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

        public string InsertarDatos(DataTable datos)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("Formato.usp_OtorgamientoDerechoAreaAcuaticaRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@OtorgamientoDerechoAreaAcuatica", SqlDbType.Structured);
                    cmd.Parameters["@OtorgamientoDerechoAreaAcuatica"].TypeName = "Formato.OtorgamientoDerechoAreaAcuatica";
                    cmd.Parameters["@OtorgamientoDerechoAreaAcuatica"].Value = datos;

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

        //public bool InsercionMasiva(IEnumerable<OtorgamientoDerechoAreaAcuaticaDTO> otorgamientoDerechoAreaAcuaticaDTO)
        //{
        //    bool respuesta = false;
        //    var cn = new ConfiguracionConexion();

        //    using (var conexion = new SqlConnection(cn.getCadenaSQL()))
        //    {
        //        conexion.Open();
        //        using (SqlTransaction transaction = conexion.BeginTransaction())
        //        {
        //            using (var cmd = new SqlCommand())
        //            {

        //                cmd.Connection = conexion;
        //                cmd.Transaction = transaction;
        //                cmd.CommandType = CommandType.Text;
        //                cmd.CommandText = "insert into FIEstudiosInvestigacionHistoricaNaval " +
        //                    " (NombreInvestigacion, TipoEstudioInvestigacionId, FechaInicioInvestigacion, " +
        //                    "FechaTerminoInvestigacion, ResponsableInvestigacion, SolicitanteInvestigacion, " +
        //                    "UsuarioIngresoRegistro, FechaIngresoRegistro, NroIpRegistro, NroMacRegistro, " +
        //                    "UsuarioBaseDatos, CodigoIngreso, Año, Mes, Dia) values (@NombreInvestigacion, " +
        //                    "@TipoEstudioInvestigacionId, @FechaInicioInvestigacion, @FechaTerminoInvestigacion, " +
        //                    "@ResponsableInvestigacion, @SolicitanteInvestigacion, @Usuario, GETDATE(), @IP, @MAC, " +
        //                    "@UsuarioDB, 0, @YEAR, @MES, @DIA)";
        //                cmd.Parameters.Add("@NombreInvestigacion", SqlDbType.VarChar, 250);
        //                cmd.Parameters.Add("@TipoEstudioInvestigacionId", SqlDbType.Int);
        //                cmd.Parameters.Add("@FechaInicioInvestigacion", SqlDbType.Date);
        //                cmd.Parameters.Add("@FechaTerminoInvestigacion", SqlDbType.Date);
        //                cmd.Parameters.Add("@ResponsableInvestigacion", SqlDbType.VarChar, 250);
        //                cmd.Parameters.Add("@SolicitanteInvestigacion", SqlDbType.VarChar, 250);
        //                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50);
        //                cmd.Parameters.Add("@IP", SqlDbType.VarChar, 50);
        //                cmd.Parameters.Add("@MAC", SqlDbType.VarChar, 50);
        //                cmd.Parameters.Add("@UsuarioDB", SqlDbType.VarChar, 50);
        //                cmd.Parameters.Add("@YEAR", SqlDbType.Int);
        //                cmd.Parameters.Add("@MES", SqlDbType.Int);
        //                cmd.Parameters.Add("@DIA", SqlDbType.Int);
        //                try
        //                {
        //                    foreach (var item in otorgamientoDerechoAreaAcuaticaDTO)
        //                    {
        //                        //cmd.Parameters["@NombreInvestigacion"].Value = item.NombreActividadCultural;
        //                        //cmd.Parameters["@TipoEstudioInvestigacionId"].Value = item.TipoActividadCulturalId;
        //                        //cmd.Parameters["@FechaInicioInvestigacion"].Value = Convert.ToDateTime(item.FechaInicioActCultural);
        //                        //cmd.Parameters["@FechaTerminoInvestigacion"].Value = Convert.ToDateTime(item.FechaTerminoActCultural);
        //                        //cmd.Parameters["@ResponsableInvestigacion"].Value = item.LugarActCultural;
        //                        //cmd.Parameters["@SolicitanteInvestigacion"].Value = item.AuspiciadoresActCultural;
        //                        //cmd.Parameters["@NParticipantesActCultural"].Value = item.NParticipantesActCultural;
        //                        //cmd.Parameters["@InversionActCultural"].Value = item.InversionActCultural;
        //                        //cmd.Parameters["@Usuario"].Value = item.UsuarioIngresoRegistro;
        //                        //cmd.Parameters["@IP"].Value = UtilitariosGlobales.obtenerDireccionIp();
        //                        //cmd.Parameters["@MAC"].Value = UtilitariosGlobales.obtenerDireccionMac();
        //                        //cmd.Parameters["@UsuarioDB"].Value = UtilitariosGlobales.obtenerUsuarioDB();
        //                        //cmd.Parameters["@Year"].Value = DateTime.Now.Year;
        //                        //cmd.Parameters["@Mes"].Value = DateTime.Now.Month;
        //                        //cmd.Parameters["@Dia"].Value = DateTime.Now.Day;
        //                        //cmd.ExecuteNonQuery();
        //                    }
        //                    transaction.Commit();
        //                    respuesta = true;
        //                }
        //                catch (SqlException)
        //                {
        //                    transaction.Rollback();
        //                    throw;
        //                }
        //                finally
        //                {
        //                    conexion.Close();
        //                }
        //            }
        //        }
        //    }
        //    return respuesta;
        //}
    }
}
