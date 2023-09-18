using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Dicapi;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dicapi
{
    public class ExpTransporteMercanciaSustanciaDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<ExpTransporteMercanciaSustanciaDTO> ObtenerLista(int? CargaId = null)
        {
            List<ExpTransporteMercanciaSustanciaDTO> lista = new List<ExpTransporteMercanciaSustanciaDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_ExpTransporteMercanciaSustanciaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ExpTransporteMercanciaSustanciaDTO()
                        {
                            ExpTransporteMercanciaSustanciaId = Convert.ToInt32(dr["ExpTransporteMercanciaSustanciaId"]),
                            NumeroDocumento = Convert.ToInt32(dr["NumeroDocumento"]),
                            FechaIngresoSolicitud = (dr["FechaIngresoSolicitud"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            DescDptoMercanciaPeligrosa = dr["DescDptoMercanciaPeligrosa"].ToString(),
                            DocumentoExpedido = Convert.ToInt32(dr["DocumentoExpedido"]),
                            NombreNave = dr["NombreNave"].ToString(),
                            PropietarioNave = dr["PropietarioNave"].ToString(),
                            RazonSocial = dr["RazonSocial"].ToString(),
                            DescClaseNave = dr["DescClaseNave"].ToString(),
                            MatriculaNave = dr["MatriculaNave"].ToString(),
                            NombrePais = dr["NombrePais"].ToString(),
                            FechaAtencionSolicitud = (dr["FechaAtencionSolicitud"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            CargaId = Convert.ToInt32(dr["CargaId"])

                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(ExpTransporteMercanciaSustanciaDTO expTransporteMercanciaSustanciaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ExpTransporteMercanciaSustanciaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@NumeroDocumento", SqlDbType.Int);
                    cmd.Parameters["@NumeroDocumento"].Value = expTransporteMercanciaSustanciaDTO.NumeroDocumento;

                    cmd.Parameters.Add("@FechaIngresoSolicitud", SqlDbType.Date);
                    cmd.Parameters["@FechaIngresoSolicitud"].Value = expTransporteMercanciaSustanciaDTO.FechaIngresoSolicitud;

                    cmd.Parameters.Add("@CodigoDptoMercanciaPeligrosa", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoDptoMercanciaPeligrosa"].Value = expTransporteMercanciaSustanciaDTO.CodigoDptoMercanciaPeligrosa;

                    cmd.Parameters.Add("@DocumentoExpedido", SqlDbType.Int);
                    cmd.Parameters["@DocumentoExpedido"].Value = expTransporteMercanciaSustanciaDTO.DocumentoExpedido;

                    cmd.Parameters.Add("@NombreNave", SqlDbType.VarChar,100);
                    cmd.Parameters["@NombreNave"].Value = expTransporteMercanciaSustanciaDTO.NombreNave;

                    cmd.Parameters.Add("@PropietarioNave", SqlDbType.VarChar,100);
                    cmd.Parameters["@PropietarioNave"].Value = expTransporteMercanciaSustanciaDTO.PropietarioNave;

                    cmd.Parameters.Add("@RazonSocial", SqlDbType.VarChar,100);
                    cmd.Parameters["@RazonSocial"].Value = expTransporteMercanciaSustanciaDTO.RazonSocial;

                    cmd.Parameters.Add("@CodigoClaseNave", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoClaseNave"].Value = expTransporteMercanciaSustanciaDTO.CodigoClaseNave;

                    cmd.Parameters.Add("@MatriculaNave", SqlDbType.VarChar,15);
                    cmd.Parameters["@MatriculaNave"].Value = expTransporteMercanciaSustanciaDTO.MatriculaNave;

                    cmd.Parameters.Add("@NumericoPais", SqlDbType.VarChar, 20);
                    cmd.Parameters["@NumericoPais"].Value = expTransporteMercanciaSustanciaDTO.NumericoPais;

                    cmd.Parameters.Add("@FechaAtencionSolicitud", SqlDbType.Date);
                    cmd.Parameters["@FechaAtencionSolicitud"].Value = expTransporteMercanciaSustanciaDTO.FechaAtencionSolicitud;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = expTransporteMercanciaSustanciaDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = expTransporteMercanciaSustanciaDTO.UsuarioIngresoRegistro;

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

        public ExpTransporteMercanciaSustanciaDTO BuscarFormato(int Codigo)
        {
            ExpTransporteMercanciaSustanciaDTO expTransporteMercanciaSustanciaDTO = new ExpTransporteMercanciaSustanciaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ExpTransporteMercanciaSustanciaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ExpTransporteMercanciaSustanciaId", SqlDbType.Int);
                    cmd.Parameters["@ExpTransporteMercanciaSustanciaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        expTransporteMercanciaSustanciaDTO.ExpTransporteMercanciaSustanciaId = Convert.ToInt32(dr["ExpTransporteMercanciaSustanciaId"]);
                        expTransporteMercanciaSustanciaDTO.NumeroDocumento = Convert.ToInt32(dr["NumeroDocumento"]);
                        expTransporteMercanciaSustanciaDTO.FechaIngresoSolicitud = Convert.ToDateTime(dr["FechaIngresoSolicitud"]).ToString("yyy-MM-dd");
                        expTransporteMercanciaSustanciaDTO.CodigoDptoMercanciaPeligrosa = dr["CodigoDptoMercanciaPeligrosa"].ToString();
                        expTransporteMercanciaSustanciaDTO.DocumentoExpedido = Convert.ToInt32(dr["DocumentoExpedido"]);
                        expTransporteMercanciaSustanciaDTO.NombreNave = dr["NombreNave"].ToString();
                        expTransporteMercanciaSustanciaDTO.PropietarioNave = dr["PropietarioNave"].ToString();
                        expTransporteMercanciaSustanciaDTO.RazonSocial = dr["RazonSocial"].ToString();
                        expTransporteMercanciaSustanciaDTO.CodigoClaseNave = dr["CodigoClaseNave"].ToString();
                        expTransporteMercanciaSustanciaDTO.MatriculaNave = dr["MatriculaNave"].ToString();
                        expTransporteMercanciaSustanciaDTO.NumericoPais = dr["NumericoPais"].ToString();
                        expTransporteMercanciaSustanciaDTO.FechaAtencionSolicitud = Convert.ToDateTime(dr["FechaAtencionSolicitud"]).ToString("yyy-MM-dd"); 
 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return expTransporteMercanciaSustanciaDTO;
        }

        public string ActualizaFormato(ExpTransporteMercanciaSustanciaDTO expTransporteMercanciaSustanciaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_ExpTransporteMercanciaSustanciaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@ExpTransporteMercanciaSustanciaId", SqlDbType.Int);
                    cmd.Parameters["@ExpTransporteMercanciaSustanciaId"].Value = expTransporteMercanciaSustanciaDTO.ExpTransporteMercanciaSustanciaId;

                    cmd.Parameters.Add("@NumeroDocumento", SqlDbType.Int);
                    cmd.Parameters["@NumeroDocumento"].Value = expTransporteMercanciaSustanciaDTO.NumeroDocumento;

                    cmd.Parameters.Add("@FechaIngresoSolicitud", SqlDbType.Date);
                    cmd.Parameters["@FechaIngresoSolicitud"].Value = expTransporteMercanciaSustanciaDTO.FechaIngresoSolicitud;

                    cmd.Parameters.Add("@CodigoDptoMercanciaPeligrosa", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoDptoMercanciaPeligrosa"].Value = expTransporteMercanciaSustanciaDTO.CodigoDptoMercanciaPeligrosa;

                    cmd.Parameters.Add("@DocumentoExpedido", SqlDbType.Int);
                    cmd.Parameters["@DocumentoExpedido"].Value = expTransporteMercanciaSustanciaDTO.DocumentoExpedido;

                    cmd.Parameters.Add("@NombreNave", SqlDbType.VarChar, 100);
                    cmd.Parameters["@NombreNave"].Value = expTransporteMercanciaSustanciaDTO.NombreNave;

                    cmd.Parameters.Add("@PropietarioNave", SqlDbType.VarChar, 100);
                    cmd.Parameters["@PropietarioNave"].Value = expTransporteMercanciaSustanciaDTO.PropietarioNave;

                    cmd.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 100);
                    cmd.Parameters["@RazonSocial"].Value = expTransporteMercanciaSustanciaDTO.RazonSocial;

                    cmd.Parameters.Add("@CodigoClaseNave", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoClaseNave"].Value = expTransporteMercanciaSustanciaDTO.CodigoClaseNave;

                    cmd.Parameters.Add("@MatriculaNave", SqlDbType.VarChar, 15);
                    cmd.Parameters["@MatriculaNave"].Value = expTransporteMercanciaSustanciaDTO.MatriculaNave;

                    cmd.Parameters.Add("@NumericoPais", SqlDbType.VarChar, 20);
                    cmd.Parameters["@NumericoPais"].Value = expTransporteMercanciaSustanciaDTO.NumericoPais;

                    cmd.Parameters.Add("@FechaAtencionSolicitud", SqlDbType.Date);
                    cmd.Parameters["@FechaAtencionSolicitud"].Value = expTransporteMercanciaSustanciaDTO.FechaAtencionSolicitud;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = expTransporteMercanciaSustanciaDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(ExpTransporteMercanciaSustanciaDTO expTransporteMercanciaSustanciaDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ExpTransporteMercanciaSustanciaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ExpTransporteMercanciaSustanciaId", SqlDbType.Int);
                    cmd.Parameters["@ExpTransporteMercanciaSustanciaId"].Value = expTransporteMercanciaSustanciaDTO.ExpTransporteMercanciaSustanciaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = expTransporteMercanciaSustanciaDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_ExpTransporteMercanciaSustanciaRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ExpTransporteMercanciaSustancia", SqlDbType.Structured);
                    cmd.Parameters["@ExpTransporteMercanciaSustancia"].TypeName = "Formato.ExpTransporteMercanciaSustancia";
                    cmd.Parameters["@ExpTransporteMercanciaSustancia"].Value = datos;

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

        //public bool InsercionMasiva(IEnumerable<ExpTransporteMercanciaSustanciaDTO> expTransporteMercanciaSustanciaDTO)
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
        //                    foreach (var item in expTransporteMercanciaSustanciaDTO)
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
