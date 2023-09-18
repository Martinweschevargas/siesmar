using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Dicapi;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dicapi
{
    public class ExpNavePrevencionContaminacionDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<ExpNavePrevencionContaminacionDTO> ObtenerLista(int? CargaId = null)
        {
            List<ExpNavePrevencionContaminacionDTO> lista = new List<ExpNavePrevencionContaminacionDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_ExpNavePrevencionContaminacionListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ExpNavePrevencionContaminacionDTO()
                        {
                            ExpNavePrevencionContaminacionId = Convert.ToInt32(dr["ExpNavePrevencionContaminacionId"]),
                            NumeroDocumento = Convert.ToInt32(dr["NumeroDocumento"]),
                            FechaIngresoSolicitud = (dr["FechaIngresoSolicitud"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            DescDptoProteccionMedioAmbiente = dr["DescDptoProteccionMedioAmbiente"].ToString(),
                            DocumentoExpedido = Convert.ToInt32(dr["DocumentoExpedido"]),
                            NombreNaveArtefacto = dr["NombreNaveArtefacto"].ToString(),
                            DescClaseNave = dr["DescClaseNave"].ToString(),
                            DescInstalacionTerrestreAcuatica = dr["DescInstalacionTerrestreAcuatica"].ToString(),
                            MatriculaNave = dr["MatriculaNave"].ToString(),
                            PropietarioNave = dr["PropietarioNave"].ToString(),
                            NombrePais = dr["NombrePais"].ToString(),
                            FechaAtencionSolicitud = (dr["FechaAtencionSolicitud"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            CargaId = Convert.ToInt32(dr["CargaId"]),

                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(ExpNavePrevencionContaminacionDTO expNavePrevencionContaminacionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ExpNavePrevencionContaminacionRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@NumeroDocumento", SqlDbType.Int);
                    cmd.Parameters["@NumeroDocumento"].Value = expNavePrevencionContaminacionDTO.NumeroDocumento;

                    cmd.Parameters.Add("@FechaIngresoSolicitud", SqlDbType.Date);
                    cmd.Parameters["@FechaIngresoSolicitud"].Value = expNavePrevencionContaminacionDTO.FechaIngresoSolicitud;

                    cmd.Parameters.Add("@CodigoDptoProteccionMedioAmbiente", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoDptoProteccionMedioAmbiente"].Value = expNavePrevencionContaminacionDTO.CodigoDptoProteccionMedioAmbiente;

                    cmd.Parameters.Add("@DocumentoExpedido", SqlDbType.Int);
                    cmd.Parameters["@DocumentoExpedido"].Value = expNavePrevencionContaminacionDTO.DocumentoExpedido;

                    cmd.Parameters.Add("@NombreNaveArtefacto", SqlDbType.VarChar,100);
                    cmd.Parameters["@NombreNaveArtefacto"].Value = expNavePrevencionContaminacionDTO.NombreNaveArtefacto;

                    cmd.Parameters.Add("@CodigoClaseNave", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoClaseNave"].Value = expNavePrevencionContaminacionDTO.CodigoClaseNave;

                    cmd.Parameters.Add("@CodigoInstalacionTerrestreAcuatica", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoInstalacionTerrestreAcuatica"].Value = expNavePrevencionContaminacionDTO.CodigoInstalacionTerrestreAcuatica;

                    cmd.Parameters.Add("@MatriculaNave", SqlDbType.VarChar,15);
                    cmd.Parameters["@MatriculaNave"].Value = expNavePrevencionContaminacionDTO.MatriculaNave;

                    cmd.Parameters.Add("@PropietarioNave", SqlDbType.VarChar,100);
                    cmd.Parameters["@PropietarioNave"].Value = expNavePrevencionContaminacionDTO.PropietarioNave;

                    cmd.Parameters.Add("@NumericoPais", SqlDbType.VarChar, 20);
                    cmd.Parameters["@NumericoPais"].Value = expNavePrevencionContaminacionDTO.NumericoPais;

                    cmd.Parameters.Add("@FechaAtencionSolicitud", SqlDbType.Date);
                    cmd.Parameters["@FechaAtencionSolicitud"].Value = expNavePrevencionContaminacionDTO.FechaAtencionSolicitud;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = expNavePrevencionContaminacionDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = expNavePrevencionContaminacionDTO.UsuarioIngresoRegistro;

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

        public ExpNavePrevencionContaminacionDTO BuscarFormato(int Codigo)
        {
            ExpNavePrevencionContaminacionDTO expNavePrevencionContaminacionDTO = new ExpNavePrevencionContaminacionDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ExpNavePrevencionContaminacionEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ExpNavePrevencionContaminacionId", SqlDbType.Int);
                    cmd.Parameters["@ExpNavePrevencionContaminacionId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        expNavePrevencionContaminacionDTO.ExpNavePrevencionContaminacionId = Convert.ToInt32(dr["ExpNavePrevencionContaminacionId"]);
                        expNavePrevencionContaminacionDTO.NumeroDocumento = Convert.ToInt32(dr["NumeroDocumento"]);
                        expNavePrevencionContaminacionDTO.FechaIngresoSolicitud = Convert.ToDateTime(dr["FechaIngresoSolicitud"]).ToString("yyy-MM-dd");
                        expNavePrevencionContaminacionDTO.CodigoDptoProteccionMedioAmbiente = dr["CodigoDptoProteccionMedioAmbiente"].ToString();
                        expNavePrevencionContaminacionDTO.DocumentoExpedido = Convert.ToInt32(dr["DocumentoExpedido"]);
                        expNavePrevencionContaminacionDTO.NombreNaveArtefacto = dr["NombreNaveArtefacto"].ToString();
                        expNavePrevencionContaminacionDTO.CodigoClaseNave = dr["CodigoClaseNave"].ToString();
                        expNavePrevencionContaminacionDTO.CodigoInstalacionTerrestreAcuatica = dr["CodigoInstalacionTerrestreAcuatica"].ToString();
                        expNavePrevencionContaminacionDTO.MatriculaNave = dr["MatriculaNave"].ToString();
                        expNavePrevencionContaminacionDTO.PropietarioNave = dr["PropietarioNave"].ToString();
                        expNavePrevencionContaminacionDTO.NumericoPais = dr["NumericoPais"].ToString();
                        expNavePrevencionContaminacionDTO.FechaAtencionSolicitud = Convert.ToDateTime(dr["FechaAtencionSolicitud"]).ToString("yyy-MM-dd"); 


                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return expNavePrevencionContaminacionDTO;
        }

        public string ActualizaFormato(ExpNavePrevencionContaminacionDTO expNavePrevencionContaminacionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_ExpNavePrevencionContaminacionActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@ExpNavePrevencionContaminacionId", SqlDbType.Int);
                    cmd.Parameters["@ExpNavePrevencionContaminacionId"].Value = expNavePrevencionContaminacionDTO.ExpNavePrevencionContaminacionId;

                    cmd.Parameters.Add("@NumeroDocumento", SqlDbType.Int);
                    cmd.Parameters["@NumeroDocumento"].Value = expNavePrevencionContaminacionDTO.NumeroDocumento;

                    cmd.Parameters.Add("@FechaIngresoSolicitud", SqlDbType.Date);
                    cmd.Parameters["@FechaIngresoSolicitud"].Value = expNavePrevencionContaminacionDTO.FechaIngresoSolicitud;

                    cmd.Parameters.Add("@CodigoDptoProteccionMedioAmbiente", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDptoProteccionMedioAmbiente"].Value = expNavePrevencionContaminacionDTO.CodigoDptoProteccionMedioAmbiente;

                    cmd.Parameters.Add("@DocumentoExpedido", SqlDbType.Int);
                    cmd.Parameters["@DocumentoExpedido"].Value = expNavePrevencionContaminacionDTO.DocumentoExpedido;

                    cmd.Parameters.Add("@NombreNaveArtefacto", SqlDbType.VarChar, 100);
                    cmd.Parameters["@NombreNaveArtefacto"].Value = expNavePrevencionContaminacionDTO.NombreNaveArtefacto;

                    cmd.Parameters.Add("@CodigoClaseNave", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoClaseNave"].Value = expNavePrevencionContaminacionDTO.CodigoClaseNave;

                    cmd.Parameters.Add("@CodigoInstalacionTerrestreAcuatica", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoInstalacionTerrestreAcuatica"].Value = expNavePrevencionContaminacionDTO.CodigoInstalacionTerrestreAcuatica;

                    cmd.Parameters.Add("@MatriculaNave", SqlDbType.VarChar, 15);
                    cmd.Parameters["@MatriculaNave"].Value = expNavePrevencionContaminacionDTO.MatriculaNave;

                    cmd.Parameters.Add("@PropietarioNave", SqlDbType.VarChar, 100);
                    cmd.Parameters["@PropietarioNave"].Value = expNavePrevencionContaminacionDTO.PropietarioNave;

                    cmd.Parameters.Add("@NumericoPais", SqlDbType.VarChar, 20);
                    cmd.Parameters["@NumericoPais"].Value = expNavePrevencionContaminacionDTO.NumericoPais;

                    cmd.Parameters.Add("@FechaAtencionSolicitud", SqlDbType.Date);
                    cmd.Parameters["@FechaAtencionSolicitud"].Value = expNavePrevencionContaminacionDTO.FechaAtencionSolicitud;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = expNavePrevencionContaminacionDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(ExpNavePrevencionContaminacionDTO expNavePrevencionContaminacionDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ExpNavePrevencionContaminacionEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ExpNavePrevencionContaminacionId", SqlDbType.Int);
                    cmd.Parameters["@ExpNavePrevencionContaminacionId"].Value = expNavePrevencionContaminacionDTO.ExpNavePrevencionContaminacionId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = expNavePrevencionContaminacionDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_ExpNavePrevencionContaminacionRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ExpNavePrevencionContaminacion", SqlDbType.Structured);
                    cmd.Parameters["@ExpNavePrevencionContaminacion"].TypeName = "Formato.ExpNavePrevencionContaminacion";
                    cmd.Parameters["@ExpNavePrevencionContaminacion"].Value = datos;

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

        //public bool InsercionMasiva(IEnumerable<ExpNavePrevencionContaminacionDTO> expNavePrevencionContaminacionDTO)
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
        //                    foreach (var item in expNavePrevencionContaminacionDTO)
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
