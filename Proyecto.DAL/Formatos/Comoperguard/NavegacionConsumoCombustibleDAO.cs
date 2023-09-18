using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comoperguard;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comoperguard
{
    public class NavegacionConsumoCombustibleDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<NavegacionConsumoCombustibleDTO> ObtenerLista()
        {
            List<NavegacionConsumoCombustibleDTO> lista = new List<NavegacionConsumoCombustibleDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_NavegacionConsumoCombustibleListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new NavegacionConsumoCombustibleDTO()
                        {
                            NavesExtranjerasCapturadasId = Convert.ToInt32(dr["NavesExtranjerasCapturadasId"]),
                            DescJefaturaDistritoCapitania = dr["DescJefaturaDistritoCapitania"].ToString(),
                            NombreCapitania = dr["NombreCapitania"].ToString(),
                            DescUnidadNaval = dr["DescUnidadNaval"].ToString(),
                            CascoUnidadNaval = Convert.ToInt32(dr["CascoUnidadNaval"]),
                            DescTipoUnidadNavalInterventora = dr["DescTipoUnidadNavalInterventora"].ToString(),
                            DescTipoCombustibleComoperguard = dr["DescTipoCombustibleComoperguard"].ToString(),
                            StockServicentroSaldop = Convert.ToInt32(dr["StockServicentroSaldop"]),
                            StockTanque = Convert.ToInt32(dr["StockTanque"]),
                            StockTotal = Convert.ToInt32(dr["StockTotal"]),
                            AsignacionMes = Convert.ToInt32(dr["AsignacionMes"]),
                            EntregaOtrasUUGG = Convert.ToInt32(dr["EntregaOtrasUUGG"]),
                            ConsumoTotal = Convert.ToInt32(dr["ConsumoTotal"]),
                            SaldoTotalMes = Convert.ToInt32(dr["SaldoTotalMes"]),
                            StockServicentro = Convert.ToInt32(dr["StockServicentro"]),
                            StockTanques = Convert.ToInt32(dr["StockTanques"]),
                            FechaInicio = (dr["FechaInicio"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            FechaTermino = (dr["FechaTermino"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            Hora = dr["Hora"].ToString(),
                            Milla = Convert.ToInt32(dr["Milla"]),
                            OficioReferencia = dr["OficioReferencia"].ToString(),
                            FechaReferenciaOficio = (dr["FechaReferenciaOficio"].ToString()).Split(" ", StringSplitOptions.None)[0],
 

                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(NavegacionConsumoCombustibleDTO navegacionConsumoCombustibleDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_NavegacionConsumoCombustibleRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@JefaturaDistritoCapitaniaId", SqlDbType.Int);
                    cmd.Parameters["@JefaturaDistritoCapitaniaId"].Value = navegacionConsumoCombustibleDTO.JefaturaDistritoCapitaniaId;

                    cmd.Parameters.Add("@CapitaniaId", SqlDbType.Int);
                    cmd.Parameters["@CapitaniaId"].Value = navegacionConsumoCombustibleDTO.CapitaniaId;

                    cmd.Parameters.Add("@UnidadNavalId", SqlDbType.Int);
                    cmd.Parameters["@UnidadNavalId"].Value = navegacionConsumoCombustibleDTO.UnidadNavalId;

                    cmd.Parameters.Add("@CascoUnidadNaval", SqlDbType.Int);
                    cmd.Parameters["@CascoUnidadNaval"].Value = navegacionConsumoCombustibleDTO.CascoUnidadNaval;

                    cmd.Parameters.Add("@TipoUnidadNavalInterventoraId", SqlDbType.Int);
                    cmd.Parameters["@TipoUnidadNavalInterventoraId"].Value = navegacionConsumoCombustibleDTO.TipoUnidadNavalInterventoraId;

                    cmd.Parameters.Add("@TipoCombustibleComoperguardId", SqlDbType.Int);
                    cmd.Parameters["@TipoCombustibleComoperguardId"].Value = navegacionConsumoCombustibleDTO.TipoCombustibleComoperguardId;

                    cmd.Parameters.Add("@StockServicentroSaldop", SqlDbType.Int);
                    cmd.Parameters["@StockServicentroSaldop"].Value = navegacionConsumoCombustibleDTO.StockServicentroSaldop;

                    cmd.Parameters.Add("@StockTanque", SqlDbType.Int);
                    cmd.Parameters["@StockTanque"].Value = navegacionConsumoCombustibleDTO.StockTanque;

                    cmd.Parameters.Add("@StockTotal", SqlDbType.Int);
                    cmd.Parameters["@StockTotal"].Value = navegacionConsumoCombustibleDTO.StockTotal;

                    cmd.Parameters.Add("@AsignacionMes", SqlDbType.Int);
                    cmd.Parameters["@AsignacionMes"].Value = navegacionConsumoCombustibleDTO.AsignacionMes;

                    cmd.Parameters.Add("@EntregaOtrasUUGG", SqlDbType.Int);
                    cmd.Parameters["@EntregaOtrasUUGG"].Value = navegacionConsumoCombustibleDTO.EntregaOtrasUUGG;

                    cmd.Parameters.Add("@ConsumoTotal", SqlDbType.Int);
                    cmd.Parameters["@ConsumoTotal"].Value = navegacionConsumoCombustibleDTO.ConsumoTotal;

                    cmd.Parameters.Add("@SaldoTotalMes", SqlDbType.Int);
                    cmd.Parameters["@SaldoTotalMes"].Value = navegacionConsumoCombustibleDTO.SaldoTotalMes;

                    cmd.Parameters.Add("@StockServicentro", SqlDbType.Int);
                    cmd.Parameters["@StockServicentro"].Value = navegacionConsumoCombustibleDTO.StockServicentro;

                    cmd.Parameters.Add("@StockTanques", SqlDbType.Int);
                    cmd.Parameters["@StockTanques"].Value = navegacionConsumoCombustibleDTO.StockTanques;

                    cmd.Parameters.Add("@FechaInicio", SqlDbType.Date);
                    cmd.Parameters["@FechaInicio"].Value = navegacionConsumoCombustibleDTO.FechaInicio;

                    cmd.Parameters.Add("@FechaTermino", SqlDbType.Date);
                    cmd.Parameters["@FechaTermino"].Value = navegacionConsumoCombustibleDTO.FechaTermino;

                    cmd.Parameters.Add("@Hora", SqlDbType.Time);
                    cmd.Parameters["@Hora"].Value = navegacionConsumoCombustibleDTO.Hora;

                    cmd.Parameters.Add("@Milla", SqlDbType.Int);
                    cmd.Parameters["@Milla"].Value = navegacionConsumoCombustibleDTO.Milla;

                    cmd.Parameters.Add("@OficioReferencia", SqlDbType.VarChar,10);
                    cmd.Parameters["@OficioReferencia"].Value = navegacionConsumoCombustibleDTO.OficioReferencia;

                    cmd.Parameters.Add("@FechaReferenciaOficio", SqlDbType.Date);
                    cmd.Parameters["@FechaReferenciaOficio"].Value = navegacionConsumoCombustibleDTO.FechaReferenciaOficio;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = navegacionConsumoCombustibleDTO.UsuarioIngresoRegistro;

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

        public NavegacionConsumoCombustibleDTO BuscarFormato(int Codigo)
        {
            NavegacionConsumoCombustibleDTO navegacionConsumoCombustibleDTO = new NavegacionConsumoCombustibleDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_NavegacionConsumoCombustibleEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@NavesExtranjerasCapturadasId", SqlDbType.Int);
                    cmd.Parameters["@NavesExtranjerasCapturadasId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        navegacionConsumoCombustibleDTO.NavesExtranjerasCapturadasId = Convert.ToInt32(dr["NavesExtranjerasCapturadasId"]);
                        navegacionConsumoCombustibleDTO.JefaturaDistritoCapitaniaId = Convert.ToInt32(dr["JefaturaDistritoCapitaniaId"]);
                        navegacionConsumoCombustibleDTO.CapitaniaId = Convert.ToInt32(dr["CapitaniaId"]);
                        navegacionConsumoCombustibleDTO.UnidadNavalId = Convert.ToInt32(dr["UnidadNavalId"]);
                        navegacionConsumoCombustibleDTO.CascoUnidadNaval = Convert.ToInt32(dr["CascoUnidadNaval"]);
                        navegacionConsumoCombustibleDTO.TipoUnidadNavalInterventoraId = Convert.ToInt32(dr["TipoUnidadNavalInterventoraId"]);
                        navegacionConsumoCombustibleDTO.TipoCombustibleComoperguardId = Convert.ToInt32(dr["TipoCombustibleComoperguardId"]);
                        navegacionConsumoCombustibleDTO.StockServicentroSaldop = Convert.ToInt32(dr["StockServicentroSaldop"]);
                        navegacionConsumoCombustibleDTO.StockTanque = Convert.ToInt32(dr["StockTanque"]);
                        navegacionConsumoCombustibleDTO.StockTotal = Convert.ToInt32(dr["StockTotal"]);
                        navegacionConsumoCombustibleDTO.AsignacionMes = Convert.ToInt32(dr["AsignacionMes"]);
                        navegacionConsumoCombustibleDTO.EntregaOtrasUUGG = Convert.ToInt32(dr["EntregaOtrasUUGG"]);
                        navegacionConsumoCombustibleDTO.ConsumoTotal = Convert.ToInt32(dr["ConsumoTotal"]);
                        navegacionConsumoCombustibleDTO.SaldoTotalMes = Convert.ToInt32(dr["SaldoTotalMes"]);
                        navegacionConsumoCombustibleDTO.StockServicentro = Convert.ToInt32(dr["StockServicentro"]);
                        navegacionConsumoCombustibleDTO.StockTanques = Convert.ToInt32(dr["StockTanques"]);
                        navegacionConsumoCombustibleDTO.FechaInicio = Convert.ToDateTime(dr["FechaInicio"]).ToString("yyy-MM-dd");
                        navegacionConsumoCombustibleDTO.FechaTermino = Convert.ToDateTime(dr["FechaTermino"]).ToString("yyy-MM-dd");
                        navegacionConsumoCombustibleDTO.Hora = dr["Hora"].ToString();
                        navegacionConsumoCombustibleDTO.Milla = Convert.ToInt32(dr["Milla"]);
                        navegacionConsumoCombustibleDTO.OficioReferencia = dr["OficioReferencia"].ToString();
                        navegacionConsumoCombustibleDTO.FechaReferenciaOficio = Convert.ToDateTime(dr["FechaReferenciaOficio"]).ToString("yyy-MM-dd"); 


                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return navegacionConsumoCombustibleDTO;
        }

        public string ActualizaFormato(NavegacionConsumoCombustibleDTO navegacionConsumoCombustibleDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_NavegacionConsumoCombustibleActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@NavesExtranjerasCapturadasId", SqlDbType.Int);
                    cmd.Parameters["@NavesExtranjerasCapturadasId"].Value = navegacionConsumoCombustibleDTO.NavesExtranjerasCapturadasId;

                    cmd.Parameters.Add("@JefaturaDistritoCapitaniaId", SqlDbType.Int);
                    cmd.Parameters["@JefaturaDistritoCapitaniaId"].Value = navegacionConsumoCombustibleDTO.JefaturaDistritoCapitaniaId;

                    cmd.Parameters.Add("@CapitaniaId", SqlDbType.Int);
                    cmd.Parameters["@CapitaniaId"].Value = navegacionConsumoCombustibleDTO.CapitaniaId;

                    cmd.Parameters.Add("@UnidadNavalId", SqlDbType.Int);
                    cmd.Parameters["@UnidadNavalId"].Value = navegacionConsumoCombustibleDTO.UnidadNavalId;

                    cmd.Parameters.Add("@CascoUnidadNaval", SqlDbType.Int);
                    cmd.Parameters["@CascoUnidadNaval"].Value = navegacionConsumoCombustibleDTO.CascoUnidadNaval;

                    cmd.Parameters.Add("@TipoUnidadNavalInterventoraId", SqlDbType.Int);
                    cmd.Parameters["@TipoUnidadNavalInterventoraId"].Value = navegacionConsumoCombustibleDTO.TipoUnidadNavalInterventoraId;

                    cmd.Parameters.Add("@TipoCombustibleComoperguardId", SqlDbType.Int);
                    cmd.Parameters["@TipoCombustibleComoperguardId"].Value = navegacionConsumoCombustibleDTO.TipoCombustibleComoperguardId;

                    cmd.Parameters.Add("@StockServicentroSaldop", SqlDbType.Int);
                    cmd.Parameters["@StockServicentroSaldop"].Value = navegacionConsumoCombustibleDTO.StockServicentroSaldop;

                    cmd.Parameters.Add("@StockTanque", SqlDbType.Int);
                    cmd.Parameters["@StockTanque"].Value = navegacionConsumoCombustibleDTO.StockTanque;

                    cmd.Parameters.Add("@StockTotal", SqlDbType.Int);
                    cmd.Parameters["@StockTotal"].Value = navegacionConsumoCombustibleDTO.StockTotal;

                    cmd.Parameters.Add("@AsignacionMes", SqlDbType.Int);
                    cmd.Parameters["@AsignacionMes"].Value = navegacionConsumoCombustibleDTO.AsignacionMes;

                    cmd.Parameters.Add("@EntregaOtrasUUGG", SqlDbType.Int);
                    cmd.Parameters["@EntregaOtrasUUGG"].Value = navegacionConsumoCombustibleDTO.EntregaOtrasUUGG;

                    cmd.Parameters.Add("@ConsumoTotal", SqlDbType.Int);
                    cmd.Parameters["@ConsumoTotal"].Value = navegacionConsumoCombustibleDTO.ConsumoTotal;

                    cmd.Parameters.Add("@SaldoTotalMes", SqlDbType.Int);
                    cmd.Parameters["@SaldoTotalMes"].Value = navegacionConsumoCombustibleDTO.SaldoTotalMes;

                    cmd.Parameters.Add("@StockServicentro", SqlDbType.Int);
                    cmd.Parameters["@StockServicentro"].Value = navegacionConsumoCombustibleDTO.StockServicentro;

                    cmd.Parameters.Add("@StockTanques", SqlDbType.Int);
                    cmd.Parameters["@StockTanques"].Value = navegacionConsumoCombustibleDTO.StockTanques;

                    cmd.Parameters.Add("@FechaInicio", SqlDbType.Date);
                    cmd.Parameters["@FechaInicio"].Value = navegacionConsumoCombustibleDTO.FechaInicio;

                    cmd.Parameters.Add("@FechaTermino", SqlDbType.Date);
                    cmd.Parameters["@FechaTermino"].Value = navegacionConsumoCombustibleDTO.FechaTermino;

                    cmd.Parameters.Add("@Hora", SqlDbType.VarChar);
                    cmd.Parameters["@Hora"].Value = navegacionConsumoCombustibleDTO.Hora;

                    cmd.Parameters.Add("@Milla", SqlDbType.Int);
                    cmd.Parameters["@Milla"].Value = navegacionConsumoCombustibleDTO.Milla;

                    cmd.Parameters.Add("@OficioReferencia", SqlDbType.VarChar,10);
                    cmd.Parameters["@OficioReferencia"].Value = navegacionConsumoCombustibleDTO.OficioReferencia;

                    cmd.Parameters.Add("@FechaReferenciaOficio", SqlDbType.Date);
                    cmd.Parameters["@FechaReferenciaOficio"].Value = navegacionConsumoCombustibleDTO.FechaReferenciaOficio;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = navegacionConsumoCombustibleDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(NavegacionConsumoCombustibleDTO navegacionConsumoCombustibleDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_NavegacionConsumoCombustibleEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@NavesExtranjerasCapturadasId", SqlDbType.Int);
                    cmd.Parameters["@NavesExtranjerasCapturadasId"].Value = navegacionConsumoCombustibleDTO.NavesExtranjerasCapturadasId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = navegacionConsumoCombustibleDTO.UsuarioIngresoRegistro;

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
        public bool InsercionMasiva(IEnumerable<NavegacionConsumoCombustibleDTO> navegacionConsumoCombustibleDTO)
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
                            foreach (var item in navegacionConsumoCombustibleDTO)
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
