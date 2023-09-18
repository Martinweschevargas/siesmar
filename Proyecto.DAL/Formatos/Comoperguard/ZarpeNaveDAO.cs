using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comoperguard;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comoperguard
{
    public class ZarpeNaveDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<ZarpeNaveDTO> ObtenerLista()
        {
            List<ZarpeNaveDTO> lista = new List<ZarpeNaveDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_ZarpeNaveListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ZarpeNaveDTO()
                        {
                            ZarpeNaveId = Convert.ToInt32(dr["ZarpeNaveId"]),
                            DescJefaturaDistritoCapitania = dr["DescJefaturaDistritoCapitania"].ToString(),
                            NombreCapitania = dr["NombreCapitania"].ToString(),
                            HoraZarpe = dr["HoraZarpe"].ToString(),
                            DiaZarpe = Convert.ToInt32(dr["DiaZarpe"]),
                            DescMes = dr["DescMes"].ToString(),
                            AnioZarpe = Convert.ToInt32(dr["AnioZarpe"]),
                            PuertoZarpe = dr["PuertoZarpe"].ToString(),
                            IndicativoNave = dr["IndicativoNave"].ToString(),
                            NombreNave = dr["NombreNave"].ToString(),
                            NombrePais = dr["NombrePais"].ToString(),
                            DescTipoNave = dr["DescTipoNave"].ToString(),
                            NumeroOMI = dr["NumeroOMI"].ToString(),
                            AB = dr["AB"].ToString(),
                            AgenciaMaritima = dr["AgenciaMaritima"].ToString(),
                            NombrePaisProcedencia = dr["NombrePaisProcedencia"].ToString(),
                            PuertoProcedencia = dr["PuertoProcedencia"].ToString(),
                            TiempoEstimadoArriboHoras = Convert.ToInt32(dr["TiempoEstimadoArriboHoras"]),
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
                            DescUnidadMedidaPeligrosa = dr["DescUnidadMedidaPeligrosa"].ToString(),
                            DesceTipoCargaPeligrosa = dr["DesceTipoCargaPeligrosa"].ToString(),
                            CantidadCargaTransito = Convert.ToInt32(dr["CantidadCargaTransito"]),
                            DescUnidadMedidaTransito = dr["DescUnidadMedidaTransito"].ToString(),
                            DescTipoCargaTransito = dr["DescTipoCargaTransito"].ToString(),
                            CantidadCargaPeligrosaTransito = Convert.ToInt32(dr["CantidadCargaPeligrosaTransito"]),
                            DescUnidadMedidaPeligrosaTransito = dr["DescUnidadMedidaPeligrosaTransito"].ToString(),
                            DescTipoCargaPeligrosaTransito = dr["DescTipoCargaPeligrosaTransito"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(ZarpeNaveDTO zarpeNaveDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ZarpeNaveRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@JefaturaDistritoCapitaniaId", SqlDbType.Int);
                    cmd.Parameters["@JefaturaDistritoCapitaniaId"].Value = zarpeNaveDTO.JefaturaDistritoCapitaniaId;

                    cmd.Parameters.Add("@CapitaniaId", SqlDbType.Int);
                    cmd.Parameters["@CapitaniaId"].Value = zarpeNaveDTO.CapitaniaId;

                    cmd.Parameters.Add("@HoraZarpe", SqlDbType.Time);
                    cmd.Parameters["@HoraZarpe"].Value = zarpeNaveDTO.HoraZarpe;

                    cmd.Parameters.Add("@DiaZarpe", SqlDbType.Int);
                    cmd.Parameters["@DiaZarpe"].Value = zarpeNaveDTO.DiaZarpe;

                    cmd.Parameters.Add("@MesId", SqlDbType.Int);
                    cmd.Parameters["@MesId"].Value = zarpeNaveDTO.MesId;

                    cmd.Parameters.Add("@AnioZarpe", SqlDbType.Int);
                    cmd.Parameters["@AnioZarpe"].Value = zarpeNaveDTO.AnioZarpe;

                    cmd.Parameters.Add("@PuertoZarpe", SqlDbType.VarChar,50);
                    cmd.Parameters["@PuertoZarpe"].Value = zarpeNaveDTO.PuertoZarpe;

                    cmd.Parameters.Add("@IndicativoNave", SqlDbType.VarChar,20);
                    cmd.Parameters["@IndicativoNave"].Value = zarpeNaveDTO.IndicativoNave;

                    cmd.Parameters.Add("@NombreNave", SqlDbType.VarChar,150);
                    cmd.Parameters["@NombreNave"].Value = zarpeNaveDTO.NombreNave;

                    cmd.Parameters.Add("@PaisUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@PaisUbigeoId"].Value = zarpeNaveDTO.PaisUbigeoId;

                    cmd.Parameters.Add("@TipoNaveId", SqlDbType.Int);
                    cmd.Parameters["@TipoNaveId"].Value = zarpeNaveDTO.TipoNaveId;

                    cmd.Parameters.Add("@NumeroOMI", SqlDbType.VarChar,20);
                    cmd.Parameters["@NumeroOMI"].Value = zarpeNaveDTO.NumeroOMI;

                    cmd.Parameters.Add("@AB", SqlDbType.VarChar,20);
                    cmd.Parameters["@AB"].Value = zarpeNaveDTO.AB;

                    cmd.Parameters.Add("@AgenciaMaritima", SqlDbType.VarChar,50);
                    cmd.Parameters["@AgenciaMaritima"].Value = zarpeNaveDTO.AgenciaMaritima;

                    cmd.Parameters.Add("@PaisProcedencia", SqlDbType.Int);
                    cmd.Parameters["@PaisProcedencia"].Value = zarpeNaveDTO.PaisProcedencia;

                    cmd.Parameters.Add("@PuertoProcedencia", SqlDbType.VarChar,50);
                    cmd.Parameters["@PuertoProcedencia"].Value = zarpeNaveDTO.PuertoProcedencia;

                    cmd.Parameters.Add("@TiempoEstimadoArriboHoras", SqlDbType.Int);
                    cmd.Parameters["@TiempoEstimadoArriboHoras"].Value = zarpeNaveDTO.TiempoEstimadoArriboHoras;

                    cmd.Parameters.Add("@TripulantesChilenos", SqlDbType.Int);
                    cmd.Parameters["@TripulantesChilenos"].Value = zarpeNaveDTO.TripulantesChilenos;

                    cmd.Parameters.Add("@TripulantesEcuatorianos", SqlDbType.Int);
                    cmd.Parameters["@TripulantesEcuatorianos"].Value = zarpeNaveDTO.TripulantesEcuatorianos;

                    cmd.Parameters.Add("@TripulantesTotal", SqlDbType.Int);
                    cmd.Parameters["@TripulantesTotal"].Value = zarpeNaveDTO.TripulantesTotal;

                    cmd.Parameters.Add("@PasajerosChilenos", SqlDbType.Int);
                    cmd.Parameters["@PasajerosChilenos"].Value = zarpeNaveDTO.PasajerosChilenos;

                    cmd.Parameters.Add("@PasajerosEcuatorianos", SqlDbType.Int);
                    cmd.Parameters["@PasajerosEcuatorianos"].Value = zarpeNaveDTO.PasajerosEcuatorianos;

                    cmd.Parameters.Add("@PasajerosTotal", SqlDbType.Int);
                    cmd.Parameters["@PasajerosTotal"].Value = zarpeNaveDTO.PasajerosTotal;

                    cmd.Parameters.Add("@CantidadCargaDesembarcada", SqlDbType.Int);
                    cmd.Parameters["@CantidadCargaDesembarcada"].Value = zarpeNaveDTO.CantidadCargaDesembarcada;

                    cmd.Parameters.Add("@UnidadMedidaId", SqlDbType.Int);
                    cmd.Parameters["@UnidadMedidaId"].Value = zarpeNaveDTO.UnidadMedidaId;

                    cmd.Parameters.Add("@TipoCargaId", SqlDbType.Int);
                    cmd.Parameters["@TipoCargaId"].Value = zarpeNaveDTO.TipoCargaId;

                    cmd.Parameters.Add("@CantidadCargaPeligrosa", SqlDbType.Int);
                    cmd.Parameters["@CantidadCargaPeligrosa"].Value = zarpeNaveDTO.CantidadCargaPeligrosa;

                    cmd.Parameters.Add("@UnidadMedidaPeligrosa", SqlDbType.Int);
                    cmd.Parameters["@UnidadMedidaPeligrosa"].Value = zarpeNaveDTO.UnidadMedidaPeligrosa;

                    cmd.Parameters.Add("@TipoCargaPeligrosa", SqlDbType.Int);
                    cmd.Parameters["@TipoCargaPeligrosa"].Value = zarpeNaveDTO.TipoCargaPeligrosa;

                    cmd.Parameters.Add("@CantidadCargaTransito", SqlDbType.Int);
                    cmd.Parameters["@CantidadCargaTransito"].Value = zarpeNaveDTO.CantidadCargaTransito;

                    cmd.Parameters.Add("@UnidadMedidaTransito", SqlDbType.Int);
                    cmd.Parameters["@UnidadMedidaTransito"].Value = zarpeNaveDTO.UnidadMedidaTransito;

                    cmd.Parameters.Add("@TipoCargaTransito", SqlDbType.Int);
                    cmd.Parameters["@TipoCargaTransito"].Value = zarpeNaveDTO.TipoCargaTransito;

                    cmd.Parameters.Add("@CantidadCargaPeligrosaTransito", SqlDbType.Int);
                    cmd.Parameters["@CantidadCargaPeligrosaTransito"].Value = zarpeNaveDTO.CantidadCargaPeligrosaTransito;

                    cmd.Parameters.Add("@UnidadMedidaPeligrosaTransito", SqlDbType.Int);
                    cmd.Parameters["@UnidadMedidaPeligrosaTransito"].Value = zarpeNaveDTO.UnidadMedidaPeligrosaTransito;

                    cmd.Parameters.Add("@TipoCargaPeligrosaTransito", SqlDbType.Int);
                    cmd.Parameters["@TipoCargaPeligrosaTransito"].Value = zarpeNaveDTO.TipoCargaPeligrosaTransito;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = zarpeNaveDTO.UsuarioIngresoRegistro;

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

        public ZarpeNaveDTO BuscarFormato(int Codigo)
        {
            ZarpeNaveDTO zarpeNaveDTO = new ZarpeNaveDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ZarpeNaveEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ZarpeNaveId", SqlDbType.Int);
                    cmd.Parameters["@ZarpeNaveId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        zarpeNaveDTO.ZarpeNaveId = Convert.ToInt32(dr["ZarpeNaveId"]);
                        zarpeNaveDTO.JefaturaDistritoCapitaniaId = Convert.ToInt32(dr["JefaturaDistritoCapitaniaId"]);
                        zarpeNaveDTO.CapitaniaId = Convert.ToInt32(dr["CapitaniaId"]);
                        zarpeNaveDTO.HoraZarpe = dr["HoraZarpe"].ToString();
                        zarpeNaveDTO.DiaZarpe = Convert.ToInt32(dr["DiaZarpe"]);
                        zarpeNaveDTO.MesId = Convert.ToInt32(dr["MesId"]);
                        zarpeNaveDTO.AnioZarpe = Convert.ToInt32(dr["AnioZarpe"]);
                        zarpeNaveDTO.PuertoZarpe = dr["PuertoZarpe"].ToString();
                        zarpeNaveDTO.IndicativoNave = dr["IndicativoNave"].ToString();
                        zarpeNaveDTO.NombreNave = dr["NombreNave"].ToString();
                        zarpeNaveDTO.PaisUbigeoId = Convert.ToInt32(dr["PaisUbigeoId"]);
                        zarpeNaveDTO.TipoNaveId = Convert.ToInt32(dr["TipoNaveId"]);
                        zarpeNaveDTO.NumeroOMI = dr["NumeroOMI"].ToString();
                        zarpeNaveDTO.AB = dr["AB"].ToString();
                        zarpeNaveDTO.AgenciaMaritima = dr["AgenciaMaritima"].ToString();
                        zarpeNaveDTO.PaisProcedencia = Convert.ToInt32(dr["PaisProcedencia"]);
                        zarpeNaveDTO.PuertoProcedencia = dr["PuertoProcedencia"].ToString();
                        zarpeNaveDTO.TiempoEstimadoArriboHoras = Convert.ToInt32(dr["TiempoEstimadoArriboHoras"]);
                        zarpeNaveDTO.TripulantesChilenos = Convert.ToInt32(dr["TripulantesChilenos"]);
                        zarpeNaveDTO.TripulantesEcuatorianos = Convert.ToInt32(dr["TripulantesEcuatorianos"]);
                        zarpeNaveDTO.TripulantesTotal = Convert.ToInt32(dr["TripulantesTotal"]);
                        zarpeNaveDTO.PasajerosChilenos = Convert.ToInt32(dr["PasajerosChilenos"]);
                        zarpeNaveDTO.PasajerosEcuatorianos = Convert.ToInt32(dr["PasajerosEcuatorianos"]);
                        zarpeNaveDTO.PasajerosTotal = Convert.ToInt32(dr["PasajerosTotal"]);
                        zarpeNaveDTO.CantidadCargaDesembarcada = Convert.ToInt32(dr["CantidadCargaDesembarcada"]);
                        zarpeNaveDTO.UnidadMedidaId = Convert.ToInt32(dr["UnidadMedidaId"]);
                        zarpeNaveDTO.TipoCargaId = Convert.ToInt32(dr["TipoCargaId"]);
                        zarpeNaveDTO.CantidadCargaPeligrosa = Convert.ToInt32(dr["CantidadCargaPeligrosa"]);
                        zarpeNaveDTO.UnidadMedidaPeligrosa = Convert.ToInt32(dr["UnidadMedidaPeligrosa"]);
                        zarpeNaveDTO.TipoCargaPeligrosa = Convert.ToInt32(dr["TipoCargaPeligrosa"]);
                        zarpeNaveDTO.CantidadCargaTransito = Convert.ToInt32(dr["CantidadCargaTransito"]);
                        zarpeNaveDTO.UnidadMedidaTransito = Convert.ToInt32(dr["UnidadMedidaTransito"]);
                        zarpeNaveDTO.TipoCargaTransito = Convert.ToInt32(dr["TipoCargaTransito"]);
                        zarpeNaveDTO.CantidadCargaPeligrosaTransito = Convert.ToInt32(dr["CantidadCargaPeligrosaTransito"]);
                        zarpeNaveDTO.UnidadMedidaPeligrosaTransito = Convert.ToInt32(dr["UnidadMedidaPeligrosaTransito"]);
                        zarpeNaveDTO.TipoCargaPeligrosaTransito = Convert.ToInt32(dr["TipoCargaPeligrosaTransito"]); 
 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return zarpeNaveDTO;
        }

        public string ActualizaFormato(ZarpeNaveDTO zarpeNaveDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_ZarpeNaveActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@ZarpeNaveId", SqlDbType.Int);
                    cmd.Parameters["@ZarpeNaveId"].Value = zarpeNaveDTO.ZarpeNaveId;

                    cmd.Parameters.Add("@JefaturaDistritoCapitaniaId", SqlDbType.Int);
                    cmd.Parameters["@JefaturaDistritoCapitaniaId"].Value = zarpeNaveDTO.JefaturaDistritoCapitaniaId;

                    cmd.Parameters.Add("@CapitaniaId", SqlDbType.Int);
                    cmd.Parameters["@CapitaniaId"].Value = zarpeNaveDTO.CapitaniaId;

                    cmd.Parameters.Add("@HoraZarpe", SqlDbType.Time);
                    cmd.Parameters["@HoraZarpe"].Value = zarpeNaveDTO.HoraZarpe;

                    cmd.Parameters.Add("@DiaZarpe", SqlDbType.Int);
                    cmd.Parameters["@DiaZarpe"].Value = zarpeNaveDTO.DiaZarpe;

                    cmd.Parameters.Add("@MesId", SqlDbType.Int);
                    cmd.Parameters["@MesId"].Value = zarpeNaveDTO.MesId;

                    cmd.Parameters.Add("@AnioZarpe", SqlDbType.Int);
                    cmd.Parameters["@AnioZarpe"].Value = zarpeNaveDTO.AnioZarpe;

                    cmd.Parameters.Add("@PuertoZarpe", SqlDbType.VarChar, 50);
                    cmd.Parameters["@PuertoZarpe"].Value = zarpeNaveDTO.PuertoZarpe;

                    cmd.Parameters.Add("@IndicativoNave", SqlDbType.VarChar, 20);
                    cmd.Parameters["@IndicativoNave"].Value = zarpeNaveDTO.IndicativoNave;

                    cmd.Parameters.Add("@NombreNave", SqlDbType.VarChar, 150);
                    cmd.Parameters["@NombreNave"].Value = zarpeNaveDTO.NombreNave;

                    cmd.Parameters.Add("@PaisUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@PaisUbigeoId"].Value = zarpeNaveDTO.PaisUbigeoId;

                    cmd.Parameters.Add("@TipoNaveId", SqlDbType.Int);
                    cmd.Parameters["@TipoNaveId"].Value = zarpeNaveDTO.TipoNaveId;

                    cmd.Parameters.Add("@NumeroOMI", SqlDbType.VarChar, 20);
                    cmd.Parameters["@NumeroOMI"].Value = zarpeNaveDTO.NumeroOMI;

                    cmd.Parameters.Add("@AB", SqlDbType.VarChar, 20);
                    cmd.Parameters["@AB"].Value = zarpeNaveDTO.AB;

                    cmd.Parameters.Add("@AgenciaMaritima", SqlDbType.VarChar, 50);
                    cmd.Parameters["@AgenciaMaritima"].Value = zarpeNaveDTO.AgenciaMaritima;

                    cmd.Parameters.Add("@PaisProcedencia", SqlDbType.Int);
                    cmd.Parameters["@PaisProcedencia"].Value = zarpeNaveDTO.PaisProcedencia;

                    cmd.Parameters.Add("@PuertoProcedencia", SqlDbType.VarChar, 50);
                    cmd.Parameters["@PuertoProcedencia"].Value = zarpeNaveDTO.PuertoProcedencia;

                    cmd.Parameters.Add("@TiempoEstimadoArriboHoras", SqlDbType.Int);
                    cmd.Parameters["@TiempoEstimadoArriboHoras"].Value = zarpeNaveDTO.TiempoEstimadoArriboHoras;

                    cmd.Parameters.Add("@TripulantesChilenos", SqlDbType.Int);
                    cmd.Parameters["@TripulantesChilenos"].Value = zarpeNaveDTO.TripulantesChilenos;

                    cmd.Parameters.Add("@TripulantesEcuatorianos", SqlDbType.Int);
                    cmd.Parameters["@TripulantesEcuatorianos"].Value = zarpeNaveDTO.TripulantesEcuatorianos;

                    cmd.Parameters.Add("@TripulantesTotal", SqlDbType.Int);
                    cmd.Parameters["@TripulantesTotal"].Value = zarpeNaveDTO.TripulantesTotal;

                    cmd.Parameters.Add("@PasajerosChilenos", SqlDbType.Int);
                    cmd.Parameters["@PasajerosChilenos"].Value = zarpeNaveDTO.PasajerosChilenos;

                    cmd.Parameters.Add("@PasajerosEcuatorianos", SqlDbType.Int);
                    cmd.Parameters["@PasajerosEcuatorianos"].Value = zarpeNaveDTO.PasajerosEcuatorianos;

                    cmd.Parameters.Add("@PasajerosTotal", SqlDbType.Int);
                    cmd.Parameters["@PasajerosTotal"].Value = zarpeNaveDTO.PasajerosTotal;

                    cmd.Parameters.Add("@CantidadCargaDesembarcada", SqlDbType.Int);
                    cmd.Parameters["@CantidadCargaDesembarcada"].Value = zarpeNaveDTO.CantidadCargaDesembarcada;

                    cmd.Parameters.Add("@UnidadMedidaId", SqlDbType.Int);
                    cmd.Parameters["@UnidadMedidaId"].Value = zarpeNaveDTO.UnidadMedidaId;

                    cmd.Parameters.Add("@TipoCargaId", SqlDbType.Int);
                    cmd.Parameters["@TipoCargaId"].Value = zarpeNaveDTO.TipoCargaId;

                    cmd.Parameters.Add("@CantidadCargaPeligrosa", SqlDbType.Int);
                    cmd.Parameters["@CantidadCargaPeligrosa"].Value = zarpeNaveDTO.CantidadCargaPeligrosa;

                    cmd.Parameters.Add("@UnidadMedidaPeligrosa", SqlDbType.Int);
                    cmd.Parameters["@UnidadMedidaPeligrosa"].Value = zarpeNaveDTO.UnidadMedidaPeligrosa;

                    cmd.Parameters.Add("@TipoCargaPeligrosa", SqlDbType.Int);
                    cmd.Parameters["@TipoCargaPeligrosa"].Value = zarpeNaveDTO.TipoCargaPeligrosa;

                    cmd.Parameters.Add("@CantidadCargaTransito", SqlDbType.Int);
                    cmd.Parameters["@CantidadCargaTransito"].Value = zarpeNaveDTO.CantidadCargaTransito;

                    cmd.Parameters.Add("@UnidadMedidaTransito", SqlDbType.Int);
                    cmd.Parameters["@UnidadMedidaTransito"].Value = zarpeNaveDTO.UnidadMedidaTransito;

                    cmd.Parameters.Add("@TipoCargaTransito", SqlDbType.Int);
                    cmd.Parameters["@TipoCargaTransito"].Value = zarpeNaveDTO.TipoCargaTransito;

                    cmd.Parameters.Add("@CantidadCargaPeligrosaTransito", SqlDbType.Int);
                    cmd.Parameters["@CantidadCargaPeligrosaTransito"].Value = zarpeNaveDTO.CantidadCargaPeligrosaTransito;

                    cmd.Parameters.Add("@UnidadMedidaPeligrosaTransito", SqlDbType.Int);
                    cmd.Parameters["@UnidadMedidaPeligrosaTransito"].Value = zarpeNaveDTO.UnidadMedidaPeligrosaTransito;

                    cmd.Parameters.Add("@TipoCargaPeligrosaTransito", SqlDbType.Int);
                    cmd.Parameters["@TipoCargaPeligrosaTransito"].Value = zarpeNaveDTO.TipoCargaPeligrosaTransito;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = zarpeNaveDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(ZarpeNaveDTO zarpeNaveDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ZarpeNaveEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ZarpeNaveId", SqlDbType.Int);
                    cmd.Parameters["@ZarpeNaveId"].Value = zarpeNaveDTO.ZarpeNaveId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = zarpeNaveDTO.UsuarioIngresoRegistro;

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
        public bool InsercionMasiva(IEnumerable<ZarpeNaveDTO> zarpeNaveDTO)
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
                            foreach (var item in zarpeNaveDTO)
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
