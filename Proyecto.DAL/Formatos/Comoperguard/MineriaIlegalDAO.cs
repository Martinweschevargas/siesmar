using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comoperguard;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comoperguard
{
    public class MineriaIlegalDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<MineriaIlegalDTO> ObtenerLista()
        {
            List<MineriaIlegalDTO> lista = new List<MineriaIlegalDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_MineriaIlegalListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new MineriaIlegalDTO()
                        {
                            MineriaIlegalId = Convert.ToInt32(dr["MineriaIlegalId"]),
                            DescJefaturaDistritoCapitania = dr["DescJefaturaDistritoCapitania"].ToString(),
                            NombreCapitania = dr["NombreCapitania"].ToString(),
                            AreaIntervenida = dr["AreaIntervenida"].ToString(),
                            RefMensajeNaval = dr["RefMensajeNaval"].ToString(),
                            HoraIntervencion = dr["HoraIntervencion"].ToString(),
                            DiaIntervencion = Convert.ToInt32(dr["DiaIntervencion"]),
                            DescMes = dr["DescMes"].ToString(),
                            AnioIntervencion = Convert.ToInt32(dr["AnioIntervencion"]),
                            LatitudUbicacionNave = dr["LatitudUbicacionNave"].ToString(),
                            LongitudUbicacionNave = dr["LongitudUbicacionNave"].ToString(),
                            DescUnidadNaval = dr["DescUnidadNaval"].ToString(),
                            CascoUnidadNaval = Convert.ToInt32(dr["CascoUnidadNaval"]),
                            DescSectorExtraInstitucional = dr["DescSectorExtraInstitucional"].ToString(),
                            DescTipoMaterialDestruido = dr["DescTipoMaterialDestruido"].ToString(),
                            CantidadPersonasDetenidas = Convert.ToInt32(dr["CantidadPersonasDetenidas"]),
                            Observaciones = dr["Observaciones"].ToString(),

                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(MineriaIlegalDTO mineriaIlegalDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_MineriaIlegalRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MineriaIlegalId", SqlDbType.Int);
                    cmd.Parameters["@MineriaIlegalId"].Value = mineriaIlegalDTO.MineriaIlegalId;

                    cmd.Parameters.Add("@JefaturaDistritoCapitaniaId", SqlDbType.Int);
                    cmd.Parameters["@JefaturaDistritoCapitaniaId"].Value = mineriaIlegalDTO.JefaturaDistritoCapitaniaId;

                    cmd.Parameters.Add("@CapitaniaId", SqlDbType.Int);
                    cmd.Parameters["@CapitaniaId"].Value = mineriaIlegalDTO.CapitaniaId;

                    cmd.Parameters.Add("@AreaIntervenida", SqlDbType.VarChar,200);
                    cmd.Parameters["@AreaIntervenida"].Value = mineriaIlegalDTO.AreaIntervenida;

                    cmd.Parameters.Add("@RefMensajeNaval", SqlDbType.VarChar,20);
                    cmd.Parameters["@RefMensajeNaval"].Value = mineriaIlegalDTO.RefMensajeNaval;

                    cmd.Parameters.Add("@HoraIntervencion", SqlDbType.Time);
                    cmd.Parameters["@HoraIntervencion"].Value = mineriaIlegalDTO.HoraIntervencion;

                    cmd.Parameters.Add("@DiaIntervencion", SqlDbType.Int);
                    cmd.Parameters["@DiaIntervencion"].Value = mineriaIlegalDTO.DiaIntervencion;

                    cmd.Parameters.Add("@MesId", SqlDbType.Int);
                    cmd.Parameters["@MesId"].Value = mineriaIlegalDTO.MesId;

                    cmd.Parameters.Add("@AnioIntervencion", SqlDbType.Int);
                    cmd.Parameters["@AnioIntervencion"].Value = mineriaIlegalDTO.AnioIntervencion;

                    cmd.Parameters.Add("@LatitudUbicacionNave", SqlDbType.VarChar,15);
                    cmd.Parameters["@LatitudUbicacionNave"].Value = mineriaIlegalDTO.LatitudUbicacionNave;

                    cmd.Parameters.Add("@LongitudUbicacionNave", SqlDbType.VarChar,15);
                    cmd.Parameters["@LongitudUbicacionNave"].Value = mineriaIlegalDTO.LongitudUbicacionNave;

                    cmd.Parameters.Add("@UnidadNavalId", SqlDbType.Int);
                    cmd.Parameters["@UnidadNavalId"].Value = mineriaIlegalDTO.UnidadNavalId;

                    cmd.Parameters.Add("@CascoUnidadNaval", SqlDbType.Int);
                    cmd.Parameters["@CascoUnidadNaval"].Value = mineriaIlegalDTO.CascoUnidadNaval;

                    cmd.Parameters.Add("@SectorExtraInstitucionalId", SqlDbType.Int);
                    cmd.Parameters["@SectorExtraInstitucionalId"].Value = mineriaIlegalDTO.SectorExtraInstitucionalId;

                    cmd.Parameters.Add("@TipoMaterialDestruidoId", SqlDbType.Int);
                    cmd.Parameters["@TipoMaterialDestruidoId"].Value = mineriaIlegalDTO.TipoMaterialDestruidoId;

                    cmd.Parameters.Add("@CantidadPersonasDetenidas", SqlDbType.Int);
                    cmd.Parameters["@CantidadPersonasDetenidas"].Value = mineriaIlegalDTO.CantidadPersonasDetenidas;

                    cmd.Parameters.Add("@Observaciones", SqlDbType.VarChar,500);
                    cmd.Parameters["@Observaciones"].Value = mineriaIlegalDTO.Observaciones;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = mineriaIlegalDTO.UsuarioIngresoRegistro;

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

        public MineriaIlegalDTO BuscarFormato(int Codigo)
        {
            MineriaIlegalDTO mineriaIlegalDTO = new MineriaIlegalDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_MineriaIlegalEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MineriaIlegalId", SqlDbType.Int);
                    cmd.Parameters["@MineriaIlegalId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        mineriaIlegalDTO.MineriaIlegalId = Convert.ToInt32(dr["MineriaIlegalId"]);
                        mineriaIlegalDTO.JefaturaDistritoCapitaniaId = Convert.ToInt32(dr["JefaturaDistritoCapitaniaId"]);
                        mineriaIlegalDTO.CapitaniaId = Convert.ToInt32(dr["CapitaniaId"]);
                        mineriaIlegalDTO.AreaIntervenida = dr["AreaIntervenida"].ToString();
                        mineriaIlegalDTO.RefMensajeNaval = dr["RefMensajeNaval"].ToString();
                        mineriaIlegalDTO.HoraIntervencion = dr["HoraIntervencion"].ToString();
                        mineriaIlegalDTO.DiaIntervencion = Convert.ToInt32(dr["DiaIntervencion"]);
                        mineriaIlegalDTO.MesId = Convert.ToInt32(dr["MesId"]);
                        mineriaIlegalDTO.AnioIntervencion = Convert.ToInt32(dr["AnioIntervencion"]);
                        mineriaIlegalDTO.LatitudUbicacionNave = dr["LatitudUbicacionNave"].ToString();
                        mineriaIlegalDTO.LongitudUbicacionNave = dr["LongitudUbicacionNave"].ToString();
                        mineriaIlegalDTO.UnidadNavalId = Convert.ToInt32(dr["UnidadNavalId"]);
                        mineriaIlegalDTO.CascoUnidadNaval = Convert.ToInt32(dr["CascoUnidadNaval"]);
                        mineriaIlegalDTO.SectorExtraInstitucionalId = Convert.ToInt32(dr["SectorExtraInstitucionalId"]);
                        mineriaIlegalDTO.TipoMaterialDestruidoId = Convert.ToInt32(dr["TipoMaterialDestruidoId"]);
                        mineriaIlegalDTO.CantidadPersonasDetenidas = Convert.ToInt32(dr["CantidadPersonasDetenidas"]);
                        mineriaIlegalDTO.Observaciones = dr["Observaciones"].ToString(); 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return mineriaIlegalDTO;
        }

        public string ActualizaFormato(MineriaIlegalDTO mineriaIlegalDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_MineriaIlegalActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@MineriaIlegalId", SqlDbType.Int);
                    cmd.Parameters["@MineriaIlegalId"].Value = mineriaIlegalDTO.MineriaIlegalId;

                    cmd.Parameters.Add("@JefaturaDistritoCapitaniaId", SqlDbType.Int);
                    cmd.Parameters["@JefaturaDistritoCapitaniaId"].Value = mineriaIlegalDTO.JefaturaDistritoCapitaniaId;

                    cmd.Parameters.Add("@CapitaniaId", SqlDbType.Int);
                    cmd.Parameters["@CapitaniaId"].Value = mineriaIlegalDTO.CapitaniaId;

                    cmd.Parameters.Add("@AreaIntervenida", SqlDbType.VarChar, 200);
                    cmd.Parameters["@AreaIntervenida"].Value = mineriaIlegalDTO.AreaIntervenida;

                    cmd.Parameters.Add("@RefMensajeNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@RefMensajeNaval"].Value = mineriaIlegalDTO.RefMensajeNaval;

                    cmd.Parameters.Add("@HoraIntervencion", SqlDbType.Time);
                    cmd.Parameters["@HoraIntervencion"].Value = mineriaIlegalDTO.HoraIntervencion;

                    cmd.Parameters.Add("@DiaIntervencion", SqlDbType.Int);
                    cmd.Parameters["@DiaIntervencion"].Value = mineriaIlegalDTO.DiaIntervencion;

                    cmd.Parameters.Add("@MesId", SqlDbType.Int);
                    cmd.Parameters["@MesId"].Value = mineriaIlegalDTO.MesId;

                    cmd.Parameters.Add("@AnioIntervencion", SqlDbType.Int);
                    cmd.Parameters["@AnioIntervencion"].Value = mineriaIlegalDTO.AnioIntervencion;

                    cmd.Parameters.Add("@LatitudUbicacionNave", SqlDbType.VarChar, 15);
                    cmd.Parameters["@LatitudUbicacionNave"].Value = mineriaIlegalDTO.LatitudUbicacionNave;

                    cmd.Parameters.Add("@LongitudUbicacionNave", SqlDbType.VarChar, 15);
                    cmd.Parameters["@LongitudUbicacionNave"].Value = mineriaIlegalDTO.LongitudUbicacionNave;

                    cmd.Parameters.Add("@UnidadNavalId", SqlDbType.Int);
                    cmd.Parameters["@UnidadNavalId"].Value = mineriaIlegalDTO.UnidadNavalId;

                    cmd.Parameters.Add("@CascoUnidadNaval", SqlDbType.Int);
                    cmd.Parameters["@CascoUnidadNaval"].Value = mineriaIlegalDTO.CascoUnidadNaval;

                    cmd.Parameters.Add("@SectorExtraInstitucionalId", SqlDbType.Int);
                    cmd.Parameters["@SectorExtraInstitucionalId"].Value = mineriaIlegalDTO.SectorExtraInstitucionalId;

                    cmd.Parameters.Add("@TipoMaterialDestruidoId", SqlDbType.Int);
                    cmd.Parameters["@TipoMaterialDestruidoId"].Value = mineriaIlegalDTO.TipoMaterialDestruidoId;

                    cmd.Parameters.Add("@CantidadPersonasDetenidas", SqlDbType.Int);
                    cmd.Parameters["@CantidadPersonasDetenidas"].Value = mineriaIlegalDTO.CantidadPersonasDetenidas;

                    cmd.Parameters.Add("@Observaciones", SqlDbType.VarChar, 500);
                    cmd.Parameters["@Observaciones"].Value = mineriaIlegalDTO.Observaciones;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = mineriaIlegalDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(MineriaIlegalDTO mineriaIlegalDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_MineriaIlegalEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MineriaIlegalId", SqlDbType.Int);
                    cmd.Parameters["@MineriaIlegalId"].Value = mineriaIlegalDTO.MineriaIlegalId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = mineriaIlegalDTO.UsuarioIngresoRegistro;

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
        public bool InsercionMasiva(IEnumerable<MineriaIlegalDTO> mineriaIlegalDTO)
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
                            foreach (var item in mineriaIlegalDTO)
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
