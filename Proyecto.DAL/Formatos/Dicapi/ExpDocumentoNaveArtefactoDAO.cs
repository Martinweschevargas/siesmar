using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Dicapi;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dicapi
{
    public class ExpDocumentoNaveArtefactoDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<ExpDocumentoNaveArtefactoDTO> ObtenerLista(int? CargaId = null)
        {
            List<ExpDocumentoNaveArtefactoDTO> lista = new List<ExpDocumentoNaveArtefactoDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_ExpDocumentoNaveArtefactoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ExpDocumentoNaveArtefactoDTO()
                        {
                            ExpDocumentoNaveArtefactoId = Convert.ToInt32(dr["ExpDocumentoNaveArtefactoId"]),
                            NumeroDocumento = Convert.ToInt32(dr["NumeroDocumento"]),
                            FechaIngresoSolicitud = (dr["FechaIngresoSolicitud"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            CodigoDptoMaterialAcuatico = dr["CodigoDptoMaterialAcuatico"].ToString(),
                            DescDptoMaterialAcuatico = dr["DescDptoMaterialAcuatico"].ToString(),
                            NombreNaveArtefacto = dr["NombreNaveArtefacto"].ToString(),
                            PropietarioNave = dr["PropietarioNave"].ToString(),
                            RazonSocial = dr["RazonSocial"].ToString(),
                            DescClaseNave = dr["DescClaseNave"].ToString(),
                            MatriculaNave = dr["MatriculaNave"].ToString(),
                            NombrePais = dr["NombrePais"].ToString(),
                            FechaAtencionSolicitud = (dr["FechaAtencionSolicitud"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            Observacion = dr["Observacion"].ToString(),
                            ResponsableDocumentoExpedido = dr["ResponsableDocumentoExpedido"].ToString(),
                            DescCapitania = dr["DescCapitania"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"]),

                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(ExpDocumentoNaveArtefactoDTO expDocumentoNaveArtefactoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ExpDocumentoNaveArtefactoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@NumeroDocumento", SqlDbType.Int);
                    cmd.Parameters["@NumeroDocumento"].Value = expDocumentoNaveArtefactoDTO.NumeroDocumento;

                    cmd.Parameters.Add("@FechaIngresoSolicitud", SqlDbType.Date);
                    cmd.Parameters["@FechaIngresoSolicitud"].Value = expDocumentoNaveArtefactoDTO.FechaIngresoSolicitud;

                    cmd.Parameters.Add("@CodigoDptoMaterialAcuatico", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoDptoMaterialAcuatico"].Value = expDocumentoNaveArtefactoDTO.CodigoDptoMaterialAcuatico;

                    cmd.Parameters.Add("@NombreNaveArtefacto", SqlDbType.VarChar,100);
                    cmd.Parameters["@NombreNaveArtefacto"].Value = expDocumentoNaveArtefactoDTO.NombreNaveArtefacto;

                    cmd.Parameters.Add("@PropietarioNave", SqlDbType.VarChar,100);
                    cmd.Parameters["@PropietarioNave"].Value = expDocumentoNaveArtefactoDTO.PropietarioNave;

                    cmd.Parameters.Add("@RazonSocial", SqlDbType.VarChar,100);
                    cmd.Parameters["@RazonSocial"].Value = expDocumentoNaveArtefactoDTO.RazonSocial;

                    cmd.Parameters.Add("@CodigoClaseNave", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoClaseNave"].Value = expDocumentoNaveArtefactoDTO.CodigoClaseNave;

                    cmd.Parameters.Add("@MatriculaNave", SqlDbType.VarChar,15);
                    cmd.Parameters["@MatriculaNave"].Value = expDocumentoNaveArtefactoDTO.MatriculaNave;

                    cmd.Parameters.Add("@NumericoPais", SqlDbType.VarChar, 20);
                    cmd.Parameters["@NumericoPais"].Value = expDocumentoNaveArtefactoDTO.NumericoPais;

                    cmd.Parameters.Add("@FechaAtencionSolicitud", SqlDbType.Date);
                    cmd.Parameters["@FechaAtencionSolicitud"].Value = expDocumentoNaveArtefactoDTO.FechaAtencionSolicitud;

                    cmd.Parameters.Add("@Observacion", SqlDbType.VarChar,200);
                    cmd.Parameters["@Observacion"].Value = expDocumentoNaveArtefactoDTO.Observacion;

                    cmd.Parameters.Add("@ResponsableDocumentoExpedido", SqlDbType.VarChar,200);
                    cmd.Parameters["@ResponsableDocumentoExpedido"].Value = expDocumentoNaveArtefactoDTO.ResponsableDocumentoExpedido;

                    cmd.Parameters.Add("@CodigoCapitania", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCapitania"].Value = expDocumentoNaveArtefactoDTO.CodigoCapitania;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = expDocumentoNaveArtefactoDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = expDocumentoNaveArtefactoDTO.UsuarioIngresoRegistro;

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

        public ExpDocumentoNaveArtefactoDTO BuscarFormato(int Codigo)
        {
            ExpDocumentoNaveArtefactoDTO expDocumentoNaveArtefactoDTO = new ExpDocumentoNaveArtefactoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ExpDocumentoNaveArtefactoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ExpDocumentoNaveArtefactoId", SqlDbType.Int);
                    cmd.Parameters["@ExpDocumentoNaveArtefactoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        expDocumentoNaveArtefactoDTO.ExpDocumentoNaveArtefactoId = Convert.ToInt32(dr["ExpDocumentoNaveArtefactoId"]);
                        expDocumentoNaveArtefactoDTO.NumeroDocumento = Convert.ToInt32(dr["NumeroDocumento"]);
                        expDocumentoNaveArtefactoDTO.FechaIngresoSolicitud = Convert.ToDateTime(dr["FechaIngresoSolicitud"]).ToString("yyy-MM-dd");
                        expDocumentoNaveArtefactoDTO.CodigoDptoMaterialAcuatico = dr["CodigoDptoMaterialAcuatico"].ToString();
                        expDocumentoNaveArtefactoDTO.NombreNaveArtefacto = dr["NombreNaveArtefacto"].ToString();
                        expDocumentoNaveArtefactoDTO.PropietarioNave = dr["PropietarioNave"].ToString();
                        expDocumentoNaveArtefactoDTO.RazonSocial = dr["RazonSocial"].ToString();
                        expDocumentoNaveArtefactoDTO.CodigoClaseNave = dr["CodigoClaseNave"].ToString();
                        expDocumentoNaveArtefactoDTO.MatriculaNave = dr["MatriculaNave"].ToString();
                        expDocumentoNaveArtefactoDTO.NumericoPais = dr["NumericoPais"].ToString();
                        expDocumentoNaveArtefactoDTO.FechaAtencionSolicitud = Convert.ToDateTime(dr["FechaAtencionSolicitud"]).ToString("yyy-MM-dd");
                        expDocumentoNaveArtefactoDTO.Observacion = dr["Observacion"].ToString();
                        expDocumentoNaveArtefactoDTO.ResponsableDocumentoExpedido = dr["ResponsableDocumentoExpedido"].ToString();
                        expDocumentoNaveArtefactoDTO.CodigoCapitania = dr["CodigoCapitania"].ToString(); 


                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return expDocumentoNaveArtefactoDTO;
        }

        public string ActualizaFormato(ExpDocumentoNaveArtefactoDTO expDocumentoNaveArtefactoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_ExpDocumentoNaveArtefactoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@ExpDocumentoNaveArtefactoId", SqlDbType.Int);
                    cmd.Parameters["@ExpDocumentoNaveArtefactoId"].Value = expDocumentoNaveArtefactoDTO.ExpDocumentoNaveArtefactoId;


                    cmd.Parameters.Add("@NumeroDocumento", SqlDbType.Int);
                    cmd.Parameters["@NumeroDocumento"].Value = expDocumentoNaveArtefactoDTO.NumeroDocumento;

                    cmd.Parameters.Add("@FechaIngresoSolicitud", SqlDbType.Date);
                    cmd.Parameters["@FechaIngresoSolicitud"].Value = expDocumentoNaveArtefactoDTO.FechaIngresoSolicitud;

                    cmd.Parameters.Add("@CodigoDptoMaterialAcuatico", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDptoMaterialAcuatico"].Value = expDocumentoNaveArtefactoDTO.CodigoDptoMaterialAcuatico;

                    cmd.Parameters.Add("@NombreNaveArtefacto", SqlDbType.VarChar, 100);
                    cmd.Parameters["@NombreNaveArtefacto"].Value = expDocumentoNaveArtefactoDTO.NombreNaveArtefacto;

                    cmd.Parameters.Add("@PropietarioNave", SqlDbType.VarChar, 100);
                    cmd.Parameters["@PropietarioNave"].Value = expDocumentoNaveArtefactoDTO.PropietarioNave;

                    cmd.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 100);
                    cmd.Parameters["@RazonSocial"].Value = expDocumentoNaveArtefactoDTO.RazonSocial;

                    cmd.Parameters.Add("@CodigoClaseNave", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoClaseNave"].Value = expDocumentoNaveArtefactoDTO.CodigoClaseNave;

                    cmd.Parameters.Add("@MatriculaNave", SqlDbType.VarChar, 15);
                    cmd.Parameters["@MatriculaNave"].Value = expDocumentoNaveArtefactoDTO.MatriculaNave;

                    cmd.Parameters.Add("@NumericoPais", SqlDbType.VarChar, 20);
                    cmd.Parameters["@NumericoPais"].Value = expDocumentoNaveArtefactoDTO.NumericoPais;

                    cmd.Parameters.Add("@FechaAtencionSolicitud", SqlDbType.Date);
                    cmd.Parameters["@FechaAtencionSolicitud"].Value = expDocumentoNaveArtefactoDTO.FechaAtencionSolicitud;

                    cmd.Parameters.Add("@Observacion", SqlDbType.VarChar, 200);
                    cmd.Parameters["@Observacion"].Value = expDocumentoNaveArtefactoDTO.Observacion;

                    cmd.Parameters.Add("@ResponsableDocumentoExpedido", SqlDbType.VarChar, 200);
                    cmd.Parameters["@ResponsableDocumentoExpedido"].Value = expDocumentoNaveArtefactoDTO.ResponsableDocumentoExpedido;

                    cmd.Parameters.Add("@CodigoCapitania", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoCapitania"].Value = expDocumentoNaveArtefactoDTO.CodigoCapitania;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = expDocumentoNaveArtefactoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(ExpDocumentoNaveArtefactoDTO expDocumentoNaveArtefactoDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ExpDocumentoNaveArtefactoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ExpDocumentoNaveArtefactoId", SqlDbType.Int);
                    cmd.Parameters["@ExpDocumentoNaveArtefactoId"].Value = expDocumentoNaveArtefactoDTO.ExpDocumentoNaveArtefactoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = expDocumentoNaveArtefactoDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.ExpDocumentoNaveArtefactoRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ExpDocumentoNaveArtefacto", SqlDbType.Structured);
                    cmd.Parameters["@ExpDocumentoNaveArtefacto"].TypeName = "Formato.ExpDocumentoNaveArtefacto";
                    cmd.Parameters["@ExpDocumentoNaveArtefacto"].Value = datos;

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




        //public bool InsercionMasiva(IEnumerable<ExpDocumentoNaveArtefactoDTO> expDocumentoNaveArtefactoDTO)
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
        //                    foreach (var item in expDocumentoNaveArtefactoDTO)
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
