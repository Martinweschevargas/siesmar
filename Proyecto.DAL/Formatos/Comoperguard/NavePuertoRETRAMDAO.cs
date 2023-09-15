using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comoperguard;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comoperguard
{
    public class NavePuertoRETRAMDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<NavePuertoRETRAMDTO> ObtenerLista()
        {
            List<NavePuertoRETRAMDTO> lista = new List<NavePuertoRETRAMDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_NavePuertoRETRAMListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new NavePuertoRETRAMDTO()
                        {
                            NavePuertoRETRAMId = Convert.ToInt32(dr["NavePuertoRETRAMId"]),
                            DescJefaturaDistritoCapitania = dr["DescJefaturaDistritoCapitania"].ToString(),
                            NombreCapitania = dr["NombreCapitania"].ToString(),
                            IndicativoLlamada = dr["IndicativoLlamada"].ToString(),
                            NombreBuque = dr["NombreBuque"].ToString(),
                            NombrePais = dr["NombrePais"].ToString(),
                            DescTipoNave = dr["DescTipoNave"].ToString(),
                            NumeroOMI = dr["NumeroOMI"].ToString(),
                            AB = dr["AB"].ToString(),
                            DescPaisProcedencia = dr["DescPaisProcedencia"].ToString(),
                            FechaArribo = (dr["FechaArribo"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            HoraArribo = dr["HoraArribo"].ToString(),
                            DescPuertoPeru = dr["DescPuertoPeru"].ToString(),
                            TiempoPermanencia = dr["TiempoPermanencia"].ToString(),
                            ProximosPuertos = Convert.ToInt32(dr["ProximosPuertos"]),
                            TripulantesChilenos = Convert.ToInt32(dr["TripulantesChilenos"]),
                            TripulantesEcuatorianos = Convert.ToInt32(dr["TripulantesEcuatorianos"]),
                            Observaciones = dr["Observaciones"].ToString(),
 

                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(NavePuertoRETRAMDTO navePuertoRETRAMDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_NavePuertoRETRAMRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@JefaturaDistritoCapitaniaId", SqlDbType.Int);
                    cmd.Parameters["@JefaturaDistritoCapitaniaId"].Value = navePuertoRETRAMDTO.JefaturaDistritoCapitaniaId;

                    cmd.Parameters.Add("@CapitaniaId", SqlDbType.Int);
                    cmd.Parameters["@CapitaniaId"].Value = navePuertoRETRAMDTO.CapitaniaId;

                    cmd.Parameters.Add("@IndicativoLlamada", SqlDbType.VarChar,20);
                    cmd.Parameters["@IndicativoLlamada"].Value = navePuertoRETRAMDTO.IndicativoLlamada;

                    cmd.Parameters.Add("@NombreBuque", SqlDbType.VarChar,50);
                    cmd.Parameters["@NombreBuque"].Value = navePuertoRETRAMDTO.NombreBuque;

                    cmd.Parameters.Add("@PaisUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@PaisUbigeoId"].Value = navePuertoRETRAMDTO.PaisUbigeoId;

                    cmd.Parameters.Add("@TipoNaveId", SqlDbType.Int);
                    cmd.Parameters["@TipoNaveId"].Value = navePuertoRETRAMDTO.TipoNaveId;

                    cmd.Parameters.Add("@NumeroOMI", SqlDbType.VarChar,20);
                    cmd.Parameters["@NumeroOMI"].Value = navePuertoRETRAMDTO.NumeroOMI;

                    cmd.Parameters.Add("@AB", SqlDbType.VarChar,20);
                    cmd.Parameters["@AB"].Value = navePuertoRETRAMDTO.AB;

                    cmd.Parameters.Add("@PaisProcedencia", SqlDbType.Int);
                    cmd.Parameters["@PaisProcedencia"].Value = navePuertoRETRAMDTO.PaisProcedencia;

                    cmd.Parameters.Add("@FechaArribo", SqlDbType.Date);
                    cmd.Parameters["@FechaArribo"].Value = navePuertoRETRAMDTO.FechaArribo;

                    cmd.Parameters.Add("@HoraArribo", SqlDbType.Time);
                    cmd.Parameters["@HoraArribo"].Value = navePuertoRETRAMDTO.HoraArribo;

                    cmd.Parameters.Add("@PuertoPeruId", SqlDbType.Int);
                    cmd.Parameters["@PuertoPeruId"].Value = navePuertoRETRAMDTO.PuertoPeruId;

                    cmd.Parameters.Add("@TiempoPermanencia", SqlDbType.VarChar,10);
                    cmd.Parameters["@TiempoPermanencia"].Value = navePuertoRETRAMDTO.TiempoPermanencia;

                    cmd.Parameters.Add("@ProximosPuertos", SqlDbType.Int);
                    cmd.Parameters["@ProximosPuertos"].Value = navePuertoRETRAMDTO.ProximosPuertos;

                    cmd.Parameters.Add("@TripulantesChilenos", SqlDbType.Int);
                    cmd.Parameters["@TripulantesChilenos"].Value = navePuertoRETRAMDTO.TripulantesChilenos;

                    cmd.Parameters.Add("@TripulantesEcuatorianos", SqlDbType.Int);
                    cmd.Parameters["@TripulantesEcuatorianos"].Value = navePuertoRETRAMDTO.TripulantesEcuatorianos;

                    cmd.Parameters.Add("@Observaciones", SqlDbType.VarChar,200);
                    cmd.Parameters["@Observaciones"].Value = navePuertoRETRAMDTO.Observaciones;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = navePuertoRETRAMDTO.UsuarioIngresoRegistro;

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

        public NavePuertoRETRAMDTO BuscarFormato(int Codigo)
        {
            NavePuertoRETRAMDTO navePuertoRETRAMDTO = new NavePuertoRETRAMDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_NavePuertoRETRAMEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@NavePuertoRETRAMId", SqlDbType.Int);
                    cmd.Parameters["@NavePuertoRETRAMId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        navePuertoRETRAMDTO.NavePuertoRETRAMId = Convert.ToInt32(dr["NavePuertoRETRAMId"]);
                        navePuertoRETRAMDTO.JefaturaDistritoCapitaniaId = Convert.ToInt32(dr["JefaturaDistritoCapitaniaId"]);
                        navePuertoRETRAMDTO.CapitaniaId = Convert.ToInt32(dr["CapitaniaId"]);
                        navePuertoRETRAMDTO.IndicativoLlamada = dr["IndicativoLlamada"].ToString();
                        navePuertoRETRAMDTO.NombreBuque = dr["NombreBuque"].ToString();
                        navePuertoRETRAMDTO.PaisUbigeoId = Convert.ToInt32(dr["PaisUbigeoId"]);
                        navePuertoRETRAMDTO.TipoNaveId = Convert.ToInt32(dr["TipoNaveId"]);
                        navePuertoRETRAMDTO.NumeroOMI = dr["NumeroOMI"].ToString();
                        navePuertoRETRAMDTO.AB = dr["AB"].ToString();
                        navePuertoRETRAMDTO.PaisProcedencia = Convert.ToInt32(dr["PaisProcedencia"]);
                        navePuertoRETRAMDTO.FechaArribo = Convert.ToDateTime(dr["FechaArribo"]).ToString("yyy-MM-dd");
                        navePuertoRETRAMDTO.HoraArribo = dr["HoraArribo"].ToString();
                        navePuertoRETRAMDTO.PuertoPeruId = Convert.ToInt32(dr["PuertoPeruId"]);
                        navePuertoRETRAMDTO.TiempoPermanencia = dr["TiempoPermanencia"].ToString();
                        navePuertoRETRAMDTO.ProximosPuertos = Convert.ToInt32(dr["ProximosPuertos"]);
                        navePuertoRETRAMDTO.TripulantesChilenos = Convert.ToInt32(dr["TripulantesChilenos"]);
                        navePuertoRETRAMDTO.TripulantesEcuatorianos = Convert.ToInt32(dr["TripulantesEcuatorianos"]);
                        navePuertoRETRAMDTO.Observaciones = dr["Observaciones"].ToString(); 


                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return navePuertoRETRAMDTO;
        }

        public string ActualizaFormato(NavePuertoRETRAMDTO navePuertoRETRAMDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_NavePuertoRETRAMActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@NavePuertoRETRAMId", SqlDbType.Int);
                    cmd.Parameters["@NavePuertoRETRAMId"].Value = navePuertoRETRAMDTO.NavePuertoRETRAMId;

                    cmd.Parameters.Add("@JefaturaDistritoCapitaniaId", SqlDbType.Int);
                    cmd.Parameters["@JefaturaDistritoCapitaniaId"].Value = navePuertoRETRAMDTO.JefaturaDistritoCapitaniaId;

                    cmd.Parameters.Add("@CapitaniaId", SqlDbType.Int);
                    cmd.Parameters["@CapitaniaId"].Value = navePuertoRETRAMDTO.CapitaniaId;

                    cmd.Parameters.Add("@IndicativoLlamada", SqlDbType.VarChar, 20);
                    cmd.Parameters["@IndicativoLlamada"].Value = navePuertoRETRAMDTO.IndicativoLlamada;

                    cmd.Parameters.Add("@NombreBuque", SqlDbType.VarChar, 50);
                    cmd.Parameters["@NombreBuque"].Value = navePuertoRETRAMDTO.NombreBuque;

                    cmd.Parameters.Add("@PaisUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@PaisUbigeoId"].Value = navePuertoRETRAMDTO.PaisUbigeoId;

                    cmd.Parameters.Add("@TipoNaveId", SqlDbType.Int);
                    cmd.Parameters["@TipoNaveId"].Value = navePuertoRETRAMDTO.TipoNaveId;

                    cmd.Parameters.Add("@NumeroOMI", SqlDbType.VarChar, 20);
                    cmd.Parameters["@NumeroOMI"].Value = navePuertoRETRAMDTO.NumeroOMI;

                    cmd.Parameters.Add("@AB", SqlDbType.VarChar, 20);
                    cmd.Parameters["@AB"].Value = navePuertoRETRAMDTO.AB;

                    cmd.Parameters.Add("@PaisProcedencia", SqlDbType.Int);
                    cmd.Parameters["@PaisProcedencia"].Value = navePuertoRETRAMDTO.PaisProcedencia;

                    cmd.Parameters.Add("@FechaArribo", SqlDbType.Date);
                    cmd.Parameters["@FechaArribo"].Value = navePuertoRETRAMDTO.FechaArribo;

                    cmd.Parameters.Add("@HoraArribo", SqlDbType.Time);
                    cmd.Parameters["@HoraArribo"].Value = navePuertoRETRAMDTO.HoraArribo;

                    cmd.Parameters.Add("@PuertoPeruId", SqlDbType.Int);
                    cmd.Parameters["@PuertoPeruId"].Value = navePuertoRETRAMDTO.PuertoPeruId;

                    cmd.Parameters.Add("@TiempoPermanencia", SqlDbType.VarChar, 10);
                    cmd.Parameters["@TiempoPermanencia"].Value = navePuertoRETRAMDTO.TiempoPermanencia;

                    cmd.Parameters.Add("@ProximosPuertos", SqlDbType.Int);
                    cmd.Parameters["@ProximosPuertos"].Value = navePuertoRETRAMDTO.ProximosPuertos;

                    cmd.Parameters.Add("@TripulantesChilenos", SqlDbType.Int);
                    cmd.Parameters["@TripulantesChilenos"].Value = navePuertoRETRAMDTO.TripulantesChilenos;

                    cmd.Parameters.Add("@TripulantesEcuatorianos", SqlDbType.Int);
                    cmd.Parameters["@TripulantesEcuatorianos"].Value = navePuertoRETRAMDTO.TripulantesEcuatorianos;

                    cmd.Parameters.Add("@Observaciones", SqlDbType.VarChar, 200);
                    cmd.Parameters["@Observaciones"].Value = navePuertoRETRAMDTO.Observaciones;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = navePuertoRETRAMDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(NavePuertoRETRAMDTO navePuertoRETRAMDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_NavePuertoRETRAMEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@NavePuertoRETRAMId", SqlDbType.Int);
                    cmd.Parameters["@NavePuertoRETRAMId"].Value = navePuertoRETRAMDTO.NavePuertoRETRAMId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = navePuertoRETRAMDTO.UsuarioIngresoRegistro;

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
        public bool InsercionMasiva(IEnumerable<NavePuertoRETRAMDTO> navePuertoRETRAMDTO)
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
                            foreach (var item in navePuertoRETRAMDTO)
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
