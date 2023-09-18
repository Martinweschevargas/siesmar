using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comoperguard;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comoperguard
{
    public class ArriboNaveDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<ArriboNaveDTO> ObtenerLista()
        {
            List<ArriboNaveDTO> lista = new List<ArriboNaveDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_ArriboNaveListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ArriboNaveDTO()
                        {
                            ArriboNaveId = Convert.ToInt32(dr["ArriboNaveId"]),
                            DescJefaturaDistritoCapitania = dr["DescJefaturaDistritoCapitania"].ToString(),
                            NombreCapitania = dr["NombreCapitania"].ToString(),
                            HoraArribo = dr["HoraArribo"].ToString(),
                            DiaArribo = Convert.ToInt32(dr["DiaArribo"]),
                            DescMes = dr["DescMes"].ToString(),
                            AnioArribo = Convert.ToInt32(dr["AnioArribo"]),
                            DescPuertoPeru = dr["DescPuertoPeru"].ToString(),
                            IndicativoNave = dr["IndicativoNave"].ToString(),
                            NombreNave = dr["NombreNave"].ToString(),
                            NombrePais = dr["NombrePais"].ToString(),
                            DescTipoNave = dr["DescTipoNave"].ToString(),
                            NumeroOMI = dr["NumeroOMI"].ToString(),
                            AB = dr["AB"].ToString(),
                            AgenciaMaritima = dr["AgenciaMaritima"].ToString(),
                            PaisProcedencia = Convert.ToInt32(dr["PaisProcedencia"]),
                            PuertoProcedencia = dr["PuertoProcedencia"].ToString(),
                            TripulantesChilenos = Convert.ToInt32(dr["TripulantesChilenos"]),
                            TripulantesEcuatorianos = Convert.ToInt32(dr["TripulantesEcuatorianos"]),
                            TripulantesTotal = Convert.ToInt32(dr["TripulantesTotal"]),
                            PasajerosChilenos = Convert.ToInt32(dr["PasajerosChilenos"]),
                            PasajerosEcuatorianos = Convert.ToInt32(dr["PasajerosEcuatorianos"]),
                            PasajerosTotal = Convert.ToInt32(dr["PasajerosTotal"]),
                            CantidadCargaDesembarcada = Convert.ToInt32(dr["CantidadCargaDesembarcada"]),
                            DescUnidadMedida = dr["DescUnidadMedida"].ToString(),
                            DescTipoCarga = dr["DescTipoCarga"].ToString(),
                            CantidadCargaPeligrosa = Convert.ToInt32(dr["CantidadCargaPeligrosa"]),
                            UnidadMedidaPeligrosa = Convert.ToInt32(dr["UnidadMedidaPeligrosa"]),
                            TipoCargaPeligrosa = Convert.ToInt32(dr["TipoCargaPeligrosa"]),
                            Observaciones = dr["Observaciones"].ToString(),

                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(ArriboNaveDTO arriboNaveDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ArriboNaveRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@JefaturaDistritoCapitaniaId", SqlDbType.Int);
                    cmd.Parameters["@JefaturaDistritoCapitaniaId"].Value = arriboNaveDTO.JefaturaDistritoCapitaniaId;

                    cmd.Parameters.Add("@CapitaniaId", SqlDbType.Int);
                    cmd.Parameters["@CapitaniaId"].Value = arriboNaveDTO.CapitaniaId;

                    cmd.Parameters.Add("@HoraArribo", SqlDbType.Time);
                    cmd.Parameters["@HoraArribo"].Value = arriboNaveDTO.HoraArribo;

                    cmd.Parameters.Add("@DiaArribo", SqlDbType.Int);
                    cmd.Parameters["@DiaArribo"].Value = arriboNaveDTO.DiaArribo;

                    cmd.Parameters.Add("@MesId", SqlDbType.Int);
                    cmd.Parameters["@MesId"].Value = arriboNaveDTO.MesId;

                    cmd.Parameters.Add("@AnioArribo", SqlDbType.Int);
                    cmd.Parameters["@AnioArribo"].Value = arriboNaveDTO.AnioArribo;

                    cmd.Parameters.Add("@PuertoPeruId", SqlDbType.Int);
                    cmd.Parameters["@PuertoPeruId"].Value = arriboNaveDTO.PuertoPeruId;

                    cmd.Parameters.Add("@IndicativoNave", SqlDbType.VarChar,20);
                    cmd.Parameters["@IndicativoNave"].Value = arriboNaveDTO.IndicativoNave;

                    cmd.Parameters.Add("@NombreNave", SqlDbType.VarChar,150);
                    cmd.Parameters["@NombreNave"].Value = arriboNaveDTO.NombreNave;

                    cmd.Parameters.Add("@PaisUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@PaisUbigeoId"].Value = arriboNaveDTO.PaisUbigeoId;

                    cmd.Parameters.Add("@TipoNaveId", SqlDbType.Int);
                    cmd.Parameters["@TipoNaveId"].Value = arriboNaveDTO.TipoNaveId;

                    cmd.Parameters.Add("@NumeroOMI", SqlDbType.VarChar,20);
                    cmd.Parameters["@NumeroOMI"].Value = arriboNaveDTO.NumeroOMI;

                    cmd.Parameters.Add("@AB", SqlDbType.VarChar,20);
                    cmd.Parameters["@AB"].Value = arriboNaveDTO.AB;

                    cmd.Parameters.Add("@AgenciaMaritima", SqlDbType.VarChar,50);
                    cmd.Parameters["@AgenciaMaritima"].Value = arriboNaveDTO.AgenciaMaritima;

                    cmd.Parameters.Add("@PaisProcedencia", SqlDbType.Int);
                    cmd.Parameters["@PaisProcedencia"].Value = arriboNaveDTO.PaisProcedencia;

                    cmd.Parameters.Add("@PuertoProcedencia", SqlDbType.VarChar,50);
                    cmd.Parameters["@PuertoProcedencia"].Value = arriboNaveDTO.PuertoProcedencia;

                    cmd.Parameters.Add("@TripulantesChilenos", SqlDbType.Int);
                    cmd.Parameters["@TripulantesChilenos"].Value = arriboNaveDTO.TripulantesChilenos;

                    cmd.Parameters.Add("@TripulantesEcuatorianos", SqlDbType.Int);
                    cmd.Parameters["@TripulantesEcuatorianos"].Value = arriboNaveDTO.TripulantesEcuatorianos;

                    cmd.Parameters.Add("@TripulantesTotal", SqlDbType.Int);
                    cmd.Parameters["@TripulantesTotal"].Value = arriboNaveDTO.TripulantesTotal;

                    cmd.Parameters.Add("@PasajerosChilenos", SqlDbType.Int);
                    cmd.Parameters["@PasajerosChilenos"].Value = arriboNaveDTO.PasajerosChilenos;

                    cmd.Parameters.Add("@PasajerosEcuatorianos", SqlDbType.Int);
                    cmd.Parameters["@PasajerosEcuatorianos"].Value = arriboNaveDTO.PasajerosEcuatorianos;

                    cmd.Parameters.Add("@PasajerosTotal", SqlDbType.Int);
                    cmd.Parameters["@PasajerosTotal"].Value = arriboNaveDTO.PasajerosTotal;

                    cmd.Parameters.Add("@CantidadCargaDesembarcada", SqlDbType.Int);
                    cmd.Parameters["@CantidadCargaDesembarcada"].Value = arriboNaveDTO.CantidadCargaDesembarcada;

                    cmd.Parameters.Add("@UnidadMedidaId", SqlDbType.Int);
                    cmd.Parameters["@UnidadMedidaId"].Value = arriboNaveDTO.UnidadMedidaId;

                    cmd.Parameters.Add("@TipoCargaId", SqlDbType.Int);
                    cmd.Parameters["@TipoCargaId"].Value = arriboNaveDTO.TipoCargaId;

                    cmd.Parameters.Add("@CantidadCargaPeligrosa", SqlDbType.Int);
                    cmd.Parameters["@CantidadCargaPeligrosa"].Value = arriboNaveDTO.CantidadCargaPeligrosa;

                    cmd.Parameters.Add("@UnidadMedidaPeligrosa", SqlDbType.Int);
                    cmd.Parameters["@UnidadMedidaPeligrosa"].Value = arriboNaveDTO.UnidadMedidaPeligrosa;

                    cmd.Parameters.Add("@TipoCargaPeligrosa", SqlDbType.Int);
                    cmd.Parameters["@TipoCargaPeligrosa"].Value = arriboNaveDTO.TipoCargaPeligrosa;

                    cmd.Parameters.Add("@Observaciones", SqlDbType.VarChar,200);
                    cmd.Parameters["@Observaciones"].Value = arriboNaveDTO.Observaciones;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = arriboNaveDTO.UsuarioIngresoRegistro;

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

        public ArriboNaveDTO BuscarFormato(int Codigo)
        {
            ArriboNaveDTO arriboNaveDTO = new ArriboNaveDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ArriboNaveEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ArriboNaveId", SqlDbType.Int);
                    cmd.Parameters["@ArriboNaveId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        arriboNaveDTO.ArriboNaveId = Convert.ToInt32(dr["ArriboNaveId"]);
                        arriboNaveDTO.JefaturaDistritoCapitaniaId = Convert.ToInt32(dr["JefaturaDistritoCapitaniaId"]);
                        arriboNaveDTO.CapitaniaId = Convert.ToInt32(dr["CapitaniaId"]);
                        arriboNaveDTO.HoraArribo = dr["HoraArribo"].ToString();
                        arriboNaveDTO.DiaArribo = Convert.ToInt32(dr["DiaArribo"]);
                        arriboNaveDTO.MesId = Convert.ToInt32(dr["MesId"]);
                        arriboNaveDTO.AnioArribo = Convert.ToInt32(dr["AnioArribo"]);
                        arriboNaveDTO.PuertoPeruId = Convert.ToInt32(dr["PuertoPeruId"]);
                        arriboNaveDTO.IndicativoNave = dr["IndicativoNave"].ToString();
                        arriboNaveDTO.NombreNave = dr["NombreNave"].ToString();
                        arriboNaveDTO.PaisUbigeoId = Convert.ToInt32(dr["PaisUbigeoId"]);
                        arriboNaveDTO.TipoNaveId = Convert.ToInt32(dr["TipoNaveId"]);
                        arriboNaveDTO.NumeroOMI = dr["NumeroOMI"].ToString();
                        arriboNaveDTO.AB = dr["AB"].ToString();
                        arriboNaveDTO.AgenciaMaritima = dr["AgenciaMaritima"].ToString();
                        arriboNaveDTO.PaisProcedencia = Convert.ToInt32(dr["PaisProcedencia"]);
                        arriboNaveDTO.PuertoProcedencia = dr["PuertoProcedencia"].ToString();
                        arriboNaveDTO.TripulantesChilenos = Convert.ToInt32(dr["TripulantesChilenos"]);
                        arriboNaveDTO.TripulantesEcuatorianos = Convert.ToInt32(dr["TripulantesEcuatorianos"]);
                        arriboNaveDTO.TripulantesTotal = Convert.ToInt32(dr["TripulantesTotal"]);
                        arriboNaveDTO.PasajerosChilenos = Convert.ToInt32(dr["PasajerosChilenos"]);
                        arriboNaveDTO.PasajerosEcuatorianos = Convert.ToInt32(dr["PasajerosEcuatorianos"]);
                        arriboNaveDTO.PasajerosTotal = Convert.ToInt32(dr["PasajerosTotal"]);
                        arriboNaveDTO.CantidadCargaDesembarcada = Convert.ToInt32(dr["CantidadCargaDesembarcada"]);
                        arriboNaveDTO.UnidadMedidaId = Convert.ToInt32(dr["UnidadMedidaId"]);
                        arriboNaveDTO.TipoCargaId = Convert.ToInt32(dr["TipoCargaId"]);
                        arriboNaveDTO.CantidadCargaPeligrosa = Convert.ToInt32(dr["CantidadCargaPeligrosa"]);
                        arriboNaveDTO.UnidadMedidaPeligrosa = Convert.ToInt32(dr["UnidadMedidaPeligrosa"]);
                        arriboNaveDTO.TipoCargaPeligrosa = Convert.ToInt32(dr["TipoCargaPeligrosa"]);
                        arriboNaveDTO.Observaciones = dr["Observaciones"].ToString(); 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return arriboNaveDTO;
        }

        public string ActualizaFormato(ArriboNaveDTO arriboNaveDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_ArriboNaveActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@ArriboNaveId", SqlDbType.Int);
                    cmd.Parameters["@ArriboNaveId"].Value = arriboNaveDTO.ArriboNaveId;

                    cmd.Parameters.Add("@JefaturaDistritoCapitaniaId", SqlDbType.Int);
                    cmd.Parameters["@JefaturaDistritoCapitaniaId"].Value = arriboNaveDTO.JefaturaDistritoCapitaniaId;

                    cmd.Parameters.Add("@CapitaniaId", SqlDbType.Int);
                    cmd.Parameters["@CapitaniaId"].Value = arriboNaveDTO.CapitaniaId;

                    cmd.Parameters.Add("@HoraArribo", SqlDbType.Time);
                    cmd.Parameters["@HoraArribo"].Value = arriboNaveDTO.HoraArribo;

                    cmd.Parameters.Add("@DiaArribo", SqlDbType.Int);
                    cmd.Parameters["@DiaArribo"].Value = arriboNaveDTO.DiaArribo;

                    cmd.Parameters.Add("@MesId", SqlDbType.Int);
                    cmd.Parameters["@MesId"].Value = arriboNaveDTO.MesId;

                    cmd.Parameters.Add("@AnioArribo", SqlDbType.Int);
                    cmd.Parameters["@AnioArribo"].Value = arriboNaveDTO.AnioArribo;

                    cmd.Parameters.Add("@PuertoPeruId", SqlDbType.Int);
                    cmd.Parameters["@PuertoPeruId"].Value = arriboNaveDTO.PuertoPeruId;

                    cmd.Parameters.Add("@IndicativoNave", SqlDbType.VarChar, 20);
                    cmd.Parameters["@IndicativoNave"].Value = arriboNaveDTO.IndicativoNave;

                    cmd.Parameters.Add("@NombreNave", SqlDbType.VarChar, 150);
                    cmd.Parameters["@NombreNave"].Value = arriboNaveDTO.NombreNave;

                    cmd.Parameters.Add("@PaisUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@PaisUbigeoId"].Value = arriboNaveDTO.PaisUbigeoId;

                    cmd.Parameters.Add("@TipoNaveId", SqlDbType.Int);
                    cmd.Parameters["@TipoNaveId"].Value = arriboNaveDTO.TipoNaveId;

                    cmd.Parameters.Add("@NumeroOMI", SqlDbType.VarChar, 20);
                    cmd.Parameters["@NumeroOMI"].Value = arriboNaveDTO.NumeroOMI;

                    cmd.Parameters.Add("@AB", SqlDbType.VarChar, 20);
                    cmd.Parameters["@AB"].Value = arriboNaveDTO.AB;

                    cmd.Parameters.Add("@AgenciaMaritima", SqlDbType.VarChar, 50);
                    cmd.Parameters["@AgenciaMaritima"].Value = arriboNaveDTO.AgenciaMaritima;

                    cmd.Parameters.Add("@PaisProcedencia", SqlDbType.Int);
                    cmd.Parameters["@PaisProcedencia"].Value = arriboNaveDTO.PaisProcedencia;

                    cmd.Parameters.Add("@PuertoProcedencia", SqlDbType.VarChar, 50);
                    cmd.Parameters["@PuertoProcedencia"].Value = arriboNaveDTO.PuertoProcedencia;

                    cmd.Parameters.Add("@TripulantesChilenos", SqlDbType.Int);
                    cmd.Parameters["@TripulantesChilenos"].Value = arriboNaveDTO.TripulantesChilenos;

                    cmd.Parameters.Add("@TripulantesEcuatorianos", SqlDbType.Int);
                    cmd.Parameters["@TripulantesEcuatorianos"].Value = arriboNaveDTO.TripulantesEcuatorianos;

                    cmd.Parameters.Add("@TripulantesTotal", SqlDbType.Int);
                    cmd.Parameters["@TripulantesTotal"].Value = arriboNaveDTO.TripulantesTotal;

                    cmd.Parameters.Add("@PasajerosChilenos", SqlDbType.Int);
                    cmd.Parameters["@PasajerosChilenos"].Value = arriboNaveDTO.PasajerosChilenos;

                    cmd.Parameters.Add("@PasajerosEcuatorianos", SqlDbType.Int);
                    cmd.Parameters["@PasajerosEcuatorianos"].Value = arriboNaveDTO.PasajerosEcuatorianos;

                    cmd.Parameters.Add("@PasajerosTotal", SqlDbType.Int);
                    cmd.Parameters["@PasajerosTotal"].Value = arriboNaveDTO.PasajerosTotal;

                    cmd.Parameters.Add("@CantidadCargaDesembarcada", SqlDbType.Int);
                    cmd.Parameters["@CantidadCargaDesembarcada"].Value = arriboNaveDTO.CantidadCargaDesembarcada;

                    cmd.Parameters.Add("@UnidadMedidaId", SqlDbType.Int);
                    cmd.Parameters["@UnidadMedidaId"].Value = arriboNaveDTO.UnidadMedidaId;

                    cmd.Parameters.Add("@TipoCargaId", SqlDbType.Int);
                    cmd.Parameters["@TipoCargaId"].Value = arriboNaveDTO.TipoCargaId;

                    cmd.Parameters.Add("@CantidadCargaPeligrosa", SqlDbType.Int);
                    cmd.Parameters["@CantidadCargaPeligrosa"].Value = arriboNaveDTO.CantidadCargaPeligrosa;

                    cmd.Parameters.Add("@UnidadMedidaPeligrosa", SqlDbType.Int);
                    cmd.Parameters["@UnidadMedidaPeligrosa"].Value = arriboNaveDTO.UnidadMedidaPeligrosa;

                    cmd.Parameters.Add("@TipoCargaPeligrosa", SqlDbType.Int);
                    cmd.Parameters["@TipoCargaPeligrosa"].Value = arriboNaveDTO.TipoCargaPeligrosa;

                    cmd.Parameters.Add("@Observaciones", SqlDbType.VarChar, 200);
                    cmd.Parameters["@Observaciones"].Value = arriboNaveDTO.Observaciones;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = arriboNaveDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(ArriboNaveDTO arriboNaveDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ArriboNaveEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ArriboNaveId", SqlDbType.Int);
                    cmd.Parameters["@ArriboNaveId"].Value = arriboNaveDTO.ArriboNaveId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = arriboNaveDTO.UsuarioIngresoRegistro;

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
        public bool InsercionMasiva(IEnumerable<ArriboNaveDTO> arriboNaveDTO)
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
                            foreach (var item in arriboNaveDTO)
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
