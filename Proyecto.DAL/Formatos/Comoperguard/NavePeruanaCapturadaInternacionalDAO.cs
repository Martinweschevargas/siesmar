using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comoperguard;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comoperguard
{
    public class NavePeruanaCapturadaInternacionalDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<NavePeruanaCapturadaInternacionalDTO> ObtenerLista()
        {
            List<NavePeruanaCapturadaInternacionalDTO> lista = new List<NavePeruanaCapturadaInternacionalDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_NavePeruanaCapturadaInternacionalListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new NavePeruanaCapturadaInternacionalDTO()
                        {
                            NavePeruanaCapturadaInternacionalId = Convert.ToInt32(dr["NavePeruanaCapturadaInternacionalId"]),
                            DescJefaturaDistritoCapitania = dr["DescJefaturaDistritoCapitania"].ToString(),
                            NombreCapitania = dr["NombreCapitania"].ToString(),
                            HoraCaptura = dr["HoraCaptura"].ToString(),
                            DiaCaptura = Convert.ToInt32(dr["DiaCaptura"]),
                            DescMes = dr["DescMes"].ToString(),
                            AnioCaptura = Convert.ToInt32(dr["AnioCaptura"]),
                            NombreNave = dr["NombreNave"].ToString(),
                            MatriculaNave = dr["MatriculaNave"].ToString(),
                            DescTipoNave = dr["DescTipoNave"].ToString(),
                            CantidadTripulantes = Convert.ToInt32(dr["CantidadTripulantes"]),
                            CantidadPasajeros = Convert.ToInt32(dr["CantidadPasajeros"]),
                            DescAutoridadEmiteZarpe = dr["DescAutoridadEmiteZarpe"].ToString(),
                            Latitud = dr["Latitud"].ToString(),
                            Longitud = dr["Longitud"].ToString(), 
                            DescAmbitoNaveo = dr["DescAmbitoNaveo"].ToString(),
                            DescPuertoPeru = dr["DescPuertoPeru"].ToString(),
                            NombrePais = dr["NombrePais"].ToString(),
                            Observaciones = dr["Observaciones"].ToString(),
 

                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(NavePeruanaCapturadaInternacionalDTO navePeruanaCapturadaInternacionalDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_NavePeruanaCapturadaInternacionalRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@JefaturaDistritoCapitaniaId", SqlDbType.Int);
                    cmd.Parameters["@JefaturaDistritoCapitaniaId"].Value = navePeruanaCapturadaInternacionalDTO.JefaturaDistritoCapitaniaId;

                    cmd.Parameters.Add("@CapitaniaId", SqlDbType.Int);
                    cmd.Parameters["@CapitaniaId"].Value = navePeruanaCapturadaInternacionalDTO.CapitaniaId;

                    cmd.Parameters.Add("@HoraCaptura", SqlDbType.Time);
                    cmd.Parameters["@HoraCaptura"].Value = navePeruanaCapturadaInternacionalDTO.HoraCaptura;

                    cmd.Parameters.Add("@DiaCaptura", SqlDbType.Int);
                    cmd.Parameters["@DiaCaptura"].Value = navePeruanaCapturadaInternacionalDTO.DiaCaptura;

                    cmd.Parameters.Add("@MesId", SqlDbType.Int);
                    cmd.Parameters["@MesId"].Value = navePeruanaCapturadaInternacionalDTO.MesId;

                    cmd.Parameters.Add("@AnioCaptura", SqlDbType.Int);
                    cmd.Parameters["@AnioCaptura"].Value = navePeruanaCapturadaInternacionalDTO.AnioCaptura;

                    cmd.Parameters.Add("@NombreNave", SqlDbType.VarChar,150);
                    cmd.Parameters["@NombreNave"].Value = navePeruanaCapturadaInternacionalDTO.NombreNave;

                    cmd.Parameters.Add("@MatriculaNave", SqlDbType.VarChar,15);
                    cmd.Parameters["@MatriculaNave"].Value = navePeruanaCapturadaInternacionalDTO.MatriculaNave;

                    cmd.Parameters.Add("@TipoNaveId", SqlDbType.Int);
                    cmd.Parameters["@TipoNaveId"].Value = navePeruanaCapturadaInternacionalDTO.TipoNaveId;

                    cmd.Parameters.Add("@CantidadTripulantes", SqlDbType.Int);
                    cmd.Parameters["@CantidadTripulantes"].Value = navePeruanaCapturadaInternacionalDTO.CantidadTripulantes;

                    cmd.Parameters.Add("@CantidadPasajeros", SqlDbType.Int);
                    cmd.Parameters["@CantidadPasajeros"].Value = navePeruanaCapturadaInternacionalDTO.CantidadPasajeros;

                    cmd.Parameters.Add("@AutoridadEmiteZarpeId", SqlDbType.Int);
                    cmd.Parameters["@AutoridadEmiteZarpeId"].Value = navePeruanaCapturadaInternacionalDTO.AutoridadEmiteZarpeId;

                    cmd.Parameters.Add("@Latitud", SqlDbType.VarChar,15);
                    cmd.Parameters["@Latitud"].Value = navePeruanaCapturadaInternacionalDTO.Latitud;

                    cmd.Parameters.Add("@Longitud", SqlDbType.VarChar,15);
                    cmd.Parameters["@Longitud"].Value = navePeruanaCapturadaInternacionalDTO.Longitud;

                    cmd.Parameters.Add("@AmbitoNaveId", SqlDbType.Int);
                    cmd.Parameters["@AmbitoNaveId"].Value = navePeruanaCapturadaInternacionalDTO.AmbitoNaveId;

                    cmd.Parameters.Add("@PuertoPeruId", SqlDbType.Int);
                    cmd.Parameters["@PuertoPeruId"].Value = navePeruanaCapturadaInternacionalDTO.PuertoPeruId;

                    cmd.Parameters.Add("@PaisUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@PaisUbigeoId"].Value = navePeruanaCapturadaInternacionalDTO.PaisUbigeoId;

                    cmd.Parameters.Add("@Observaciones", SqlDbType.VarChar,200);
                    cmd.Parameters["@Observaciones"].Value = navePeruanaCapturadaInternacionalDTO.Observaciones;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = navePeruanaCapturadaInternacionalDTO.UsuarioIngresoRegistro;

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

        public NavePeruanaCapturadaInternacionalDTO BuscarFormato(int Codigo)
        {
            NavePeruanaCapturadaInternacionalDTO navePeruanaCapturadaInternacionalDTO = new NavePeruanaCapturadaInternacionalDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_NavePeruanaCapturadaInternacionalEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@NavePeruanaCapturadaInternacionalId", SqlDbType.Int);
                    cmd.Parameters["@NavePeruanaCapturadaInternacionalId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        navePeruanaCapturadaInternacionalDTO.NavePeruanaCapturadaInternacionalId = Convert.ToInt32(dr["NavePeruanaCapturadaInternacionalId"]);
                        navePeruanaCapturadaInternacionalDTO.JefaturaDistritoCapitaniaId = Convert.ToInt32(dr["JefaturaDistritoCapitaniaId"]);
                        navePeruanaCapturadaInternacionalDTO.CapitaniaId = Convert.ToInt32(dr["CapitaniaId"]);
                        navePeruanaCapturadaInternacionalDTO.HoraCaptura = dr["HoraCaptura"].ToString();
                        navePeruanaCapturadaInternacionalDTO.DiaCaptura = Convert.ToInt32(dr["DiaCaptura"]);
                        navePeruanaCapturadaInternacionalDTO.MesId = Convert.ToInt32(dr["MesId"]);
                        navePeruanaCapturadaInternacionalDTO.AnioCaptura = Convert.ToInt32(dr["AnioCaptura"]);
                        navePeruanaCapturadaInternacionalDTO.NombreNave = dr["NombreNave"].ToString();
                        navePeruanaCapturadaInternacionalDTO.MatriculaNave = dr["MatriculaNave"].ToString();
                        navePeruanaCapturadaInternacionalDTO.TipoNaveId = Convert.ToInt32(dr["TipoNaveId"]);
                        navePeruanaCapturadaInternacionalDTO.CantidadTripulantes = Convert.ToInt32(dr["CantidadTripulantes"]);
                        navePeruanaCapturadaInternacionalDTO.CantidadPasajeros = Convert.ToInt32(dr["CantidadPasajeros"]);
                        navePeruanaCapturadaInternacionalDTO.AutoridadEmiteZarpeId = Convert.ToInt32(dr["AutoridadEmiteZarpeId"]);
                        navePeruanaCapturadaInternacionalDTO.Latitud = dr["Latitud"].ToString();
                        navePeruanaCapturadaInternacionalDTO.Longitud = dr["Longitud"].ToString();
                        navePeruanaCapturadaInternacionalDTO.AmbitoNaveId = Convert.ToInt32(dr["AmbitoNaveId"]);
                        navePeruanaCapturadaInternacionalDTO.PuertoPeruId = Convert.ToInt32(dr["PuertoPeruId"]);
                        navePeruanaCapturadaInternacionalDTO.PaisUbigeoId = Convert.ToInt32(dr["PaisUbigeoId"]);
                        navePeruanaCapturadaInternacionalDTO.Observaciones = dr["Observaciones"].ToString(); 
 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return navePeruanaCapturadaInternacionalDTO;
        }

        public string ActualizaFormato(NavePeruanaCapturadaInternacionalDTO navePeruanaCapturadaInternacionalDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_NavePeruanaCapturadaInternacionalActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@NavePeruanaCapturadaInternacionalId", SqlDbType.Int);
                    cmd.Parameters["@NavePeruanaCapturadaInternacionalId"].Value = navePeruanaCapturadaInternacionalDTO.NavePeruanaCapturadaInternacionalId;

                    cmd.Parameters.Add("@JefaturaDistritoCapitaniaId", SqlDbType.Int);
                    cmd.Parameters["@JefaturaDistritoCapitaniaId"].Value = navePeruanaCapturadaInternacionalDTO.JefaturaDistritoCapitaniaId;

                    cmd.Parameters.Add("@CapitaniaId", SqlDbType.Int);
                    cmd.Parameters["@CapitaniaId"].Value = navePeruanaCapturadaInternacionalDTO.CapitaniaId;

                    cmd.Parameters.Add("@HoraCaptura", SqlDbType.Time);
                    cmd.Parameters["@HoraCaptura"].Value = navePeruanaCapturadaInternacionalDTO.HoraCaptura;

                    cmd.Parameters.Add("@DiaCaptura", SqlDbType.Int);
                    cmd.Parameters["@DiaCaptura"].Value = navePeruanaCapturadaInternacionalDTO.DiaCaptura;

                    cmd.Parameters.Add("@MesId", SqlDbType.Int);
                    cmd.Parameters["@MesId"].Value = navePeruanaCapturadaInternacionalDTO.MesId;

                    cmd.Parameters.Add("@AnioCaptura", SqlDbType.Int);
                    cmd.Parameters["@AnioCaptura"].Value = navePeruanaCapturadaInternacionalDTO.AnioCaptura;

                    cmd.Parameters.Add("@NombreNave", SqlDbType.VarChar, 150);
                    cmd.Parameters["@NombreNave"].Value = navePeruanaCapturadaInternacionalDTO.NombreNave;

                    cmd.Parameters.Add("@MatriculaNave", SqlDbType.VarChar, 15);
                    cmd.Parameters["@MatriculaNave"].Value = navePeruanaCapturadaInternacionalDTO.MatriculaNave;

                    cmd.Parameters.Add("@TipoNaveId", SqlDbType.Int);
                    cmd.Parameters["@TipoNaveId"].Value = navePeruanaCapturadaInternacionalDTO.TipoNaveId;

                    cmd.Parameters.Add("@CantidadTripulantes", SqlDbType.Int);
                    cmd.Parameters["@CantidadTripulantes"].Value = navePeruanaCapturadaInternacionalDTO.CantidadTripulantes;

                    cmd.Parameters.Add("@CantidadPasajeros", SqlDbType.Int);
                    cmd.Parameters["@CantidadPasajeros"].Value = navePeruanaCapturadaInternacionalDTO.CantidadPasajeros;

                    cmd.Parameters.Add("@AutoridadEmiteZarpeId", SqlDbType.Int);
                    cmd.Parameters["@AutoridadEmiteZarpeId"].Value = navePeruanaCapturadaInternacionalDTO.AutoridadEmiteZarpeId;

                    cmd.Parameters.Add("@Latitud", SqlDbType.VarChar, 15);
                    cmd.Parameters["@Latitud"].Value = navePeruanaCapturadaInternacionalDTO.Latitud;

                    cmd.Parameters.Add("@Longitud", SqlDbType.VarChar, 15);
                    cmd.Parameters["@Longitud"].Value = navePeruanaCapturadaInternacionalDTO.Longitud;

                    cmd.Parameters.Add("@AmbitoNaveId", SqlDbType.Int);
                    cmd.Parameters["@AmbitoNaveId"].Value = navePeruanaCapturadaInternacionalDTO.AmbitoNaveId;

                    cmd.Parameters.Add("@PuertoPeruId", SqlDbType.Int);
                    cmd.Parameters["@PuertoPeruId"].Value = navePeruanaCapturadaInternacionalDTO.PuertoPeruId;

                    cmd.Parameters.Add("@PaisUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@PaisUbigeoId"].Value = navePeruanaCapturadaInternacionalDTO.PaisUbigeoId;

                    cmd.Parameters.Add("@Observaciones", SqlDbType.VarChar, 200);
                    cmd.Parameters["@Observaciones"].Value = navePeruanaCapturadaInternacionalDTO.Observaciones;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = navePeruanaCapturadaInternacionalDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(NavePeruanaCapturadaInternacionalDTO navePeruanaCapturadaInternacionalDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_NavePeruanaCapturadaInternacionalEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@NavePeruanaCapturadaInternacionalId", SqlDbType.Int);
                    cmd.Parameters["@NavePeruanaCapturadaInternacionalId"].Value = navePeruanaCapturadaInternacionalDTO.NavePeruanaCapturadaInternacionalId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = navePeruanaCapturadaInternacionalDTO.UsuarioIngresoRegistro;

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
        public bool InsercionMasiva(IEnumerable<NavePeruanaCapturadaInternacionalDTO> navePeruanaCapturadaInternacionalDTO)
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
                        cmd.CommandText = "insert into Formato.EstudiosInvestigacionHistoricaNaval " +
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
                            foreach (var item in navePeruanaCapturadaInternacionalDTO)
                            {
                                //cmd.Parameters["@NombreInvestigacion"].Value = item.NombreTemaEstudioInvestigacion;
                                //cmd.Parameters["@TipoEstudioInvestigacionId"].Value = item.TipoEstudioInvestigacionIds;
                                //cmd.Parameters["@FechaInicioInvestigacion"].Value = Convert.ToDateTime(item.FechaInicio);
                                //cmd.Parameters["@FechaTerminoInvestigacion"].Value = Convert.ToDateTime(item.FechaTermino);
                                //cmd.Parameters["@ResponsableInvestigacion"].Value = item.Responsable;
                                //cmd.Parameters["@SolicitanteInvestigacion"].Value = item.Solicitante;
                                cmd.Parameters["@Usuario"].Value = item.UsuarioIngresoRegistro;
                                cmd.Parameters["@IP"].Value = UtilitariosGlobales.obtenerDireccionIp();
                                cmd.Parameters["@MAC"].Value = UtilitariosGlobales.obtenerDireccionMac();

                                cmd.ExecuteNonQuery();
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
