using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Dicapi;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dicapi
{
    public class DireccionInspeccionAuditoriaSupervisionDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<DireccionInspeccionAuditoriaSupervisionDTO> ObtenerLista(int? CargaId=null)
        {
            List<DireccionInspeccionAuditoriaSupervisionDTO> lista = new List<DireccionInspeccionAuditoriaSupervisionDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_DireccionInspeccionAuditoriaSupervisionListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new DireccionInspeccionAuditoriaSupervisionDTO()
                        {
                            DireccionInspeccionAuditoriaSupervisionId = Convert.ToInt32(dr["DireccionInspeccionAuditoriaSupervisionId"]),
                            NumeroNombramiento = dr["NumeroNombramiento"].ToString(),
                            FechaInspeccion = (dr["FechaInspeccion"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            DescCapitania = dr["DescCapitania"].ToString(),
                            Nombre1Inspector = dr["Nombre1Inspector"].ToString(),
                            Nombre2Inspector = dr["Nombre2Inspector"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"])
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(DireccionInspeccionAuditoriaSupervisionDTO direccionInspeccionAuditoriaSupervisionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_DireccionInspeccionAuditoriaSupervisionRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@NumeroNombramiento", SqlDbType.VarChar,20);
                    cmd.Parameters["@NumeroNombramiento"].Value = direccionInspeccionAuditoriaSupervisionDTO.NumeroNombramiento;

                    cmd.Parameters.Add("@FechaInspeccion", SqlDbType.Date);
                    cmd.Parameters["@FechaInspeccion"].Value = direccionInspeccionAuditoriaSupervisionDTO.FechaInspeccion;

                    cmd.Parameters.Add("@CodigoCapitania", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCapitania"].Value = direccionInspeccionAuditoriaSupervisionDTO.CodigoCapitania;

                    cmd.Parameters.Add("@Nombre1Inspector", SqlDbType.VarChar,200);
                    cmd.Parameters["@Nombre1Inspector"].Value = direccionInspeccionAuditoriaSupervisionDTO.Nombre1Inspector;

                    cmd.Parameters.Add("@Nombre2Inspector", SqlDbType.VarChar,200);
                    cmd.Parameters["@Nombre2Inspector"].Value = direccionInspeccionAuditoriaSupervisionDTO.Nombre2Inspector;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = direccionInspeccionAuditoriaSupervisionDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = direccionInspeccionAuditoriaSupervisionDTO.UsuarioIngresoRegistro;

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

        public DireccionInspeccionAuditoriaSupervisionDTO BuscarFormato(int Codigo)
        {
            DireccionInspeccionAuditoriaSupervisionDTO direccionInspeccionAuditoriaSupervisionDTO = new DireccionInspeccionAuditoriaSupervisionDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_DireccionInspeccionAuditoriaSupervisionEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DireccionInspeccionAuditoriaSupervisionId", SqlDbType.Int);
                    cmd.Parameters["@DireccionInspeccionAuditoriaSupervisionId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        direccionInspeccionAuditoriaSupervisionDTO.DireccionInspeccionAuditoriaSupervisionId = Convert.ToInt32(dr["DireccionInspeccionAuditoriaSupervisionId"]);
                        direccionInspeccionAuditoriaSupervisionDTO.NumeroNombramiento = dr["NumeroNombramiento"].ToString();
                        direccionInspeccionAuditoriaSupervisionDTO.FechaInspeccion = Convert.ToDateTime(dr["FechaInspeccion"]).ToString("yyy-MM-dd");
                        direccionInspeccionAuditoriaSupervisionDTO.CodigoCapitania = dr["CodigoCapitania"].ToString();
                        direccionInspeccionAuditoriaSupervisionDTO.Nombre1Inspector = dr["Nombre1Inspector"].ToString();
                        direccionInspeccionAuditoriaSupervisionDTO.Nombre2Inspector = dr["Nombre2Inspector"].ToString(); 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return direccionInspeccionAuditoriaSupervisionDTO;
        }

        public string ActualizaFormato(DireccionInspeccionAuditoriaSupervisionDTO direccionInspeccionAuditoriaSupervisionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_DireccionInspeccionAuditoriaSupervisionActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@DireccionInspeccionAuditoriaSupervisionId", SqlDbType.Int);
                    cmd.Parameters["@DireccionInspeccionAuditoriaSupervisionId"].Value = direccionInspeccionAuditoriaSupervisionDTO.DireccionInspeccionAuditoriaSupervisionId;

                    cmd.Parameters.Add("@NumeroNombramiento", SqlDbType.VarChar, 20);
                    cmd.Parameters["@NumeroNombramiento"].Value = direccionInspeccionAuditoriaSupervisionDTO.NumeroNombramiento;

                    cmd.Parameters.Add("@FechaInspeccion", SqlDbType.Date);
                    cmd.Parameters["@FechaInspeccion"].Value = direccionInspeccionAuditoriaSupervisionDTO.FechaInspeccion;

                    cmd.Parameters.Add("@CodigoCapitania", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoCapitania"].Value = direccionInspeccionAuditoriaSupervisionDTO.CodigoCapitania;

                    cmd.Parameters.Add("@Nombre1Inspector", SqlDbType.VarChar, 200);
                    cmd.Parameters["@Nombre1Inspector"].Value = direccionInspeccionAuditoriaSupervisionDTO.Nombre1Inspector;

                    cmd.Parameters.Add("@Nombre2Inspector", SqlDbType.VarChar, 200);
                    cmd.Parameters["@Nombre2Inspector"].Value = direccionInspeccionAuditoriaSupervisionDTO.Nombre2Inspector;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = direccionInspeccionAuditoriaSupervisionDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(DireccionInspeccionAuditoriaSupervisionDTO direccionInspeccionAuditoriaSupervisionDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_DireccionInspeccionAuditoriaSupervisionEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DireccionInspeccionAuditoriaSupervisionId", SqlDbType.Int);
                    cmd.Parameters["@DireccionInspeccionAuditoriaSupervisionId"].Value = direccionInspeccionAuditoriaSupervisionDTO.DireccionInspeccionAuditoriaSupervisionId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = direccionInspeccionAuditoriaSupervisionDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_DireccionInspeccionAuditoriaSupervisionRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DireccionInspeccionAuditoriaSupervision", SqlDbType.Structured);
                    cmd.Parameters["@DireccionInspeccionAuditoriaSupervision"].TypeName = "Formato.DireccionInspeccionAuditoriaSupervision";
                    cmd.Parameters["@DireccionInspeccionAuditoriaSupervision"].Value = datos;

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

        //public bool InsercionMasiva(IEnumerable<DireccionInspeccionAuditoriaSupervisionDTO> direccionInspeccionAuditoriaSupervisionDTO)
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
        //                    foreach (var item in direccionInspeccionAuditoriaSupervisionDTO)
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
