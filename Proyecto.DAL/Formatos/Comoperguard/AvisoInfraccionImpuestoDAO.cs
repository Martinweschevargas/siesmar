using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comoperguard;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comoperguard
{
    public class AvisoInfraccionImpuestoDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<AvisoInfraccionImpuestoDTO> ObtenerLista()
        {
            List<AvisoInfraccionImpuestoDTO> lista = new List<AvisoInfraccionImpuestoDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_AvisoInfraccionImpuestoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new AvisoInfraccionImpuestoDTO()
                        {
                            AvisoInfraccionImpuestoId = Convert.ToInt32(dr["AvisoInfraccionImpuestoId"]),
                            DescJefaturaDistritoCapitania = dr["DescJefaturaDistritoCapitania"].ToString(),
                            NombreCapitania = dr["NombreCapitania"].ToString(),
                            HoraInfraccion = dr["HoraInfraccion"].ToString(), 
                            FechaInfraccion = (dr["FechaInfraccion"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            NombreNoveInfractora = dr["NombreNoveInfractora"].ToString(),
                            MatriculaNaveInfractora = dr["MatriculaNaveInfractora"].ToString(),
                            DescTipoNave = dr["DescTipoNave"].ToString(),
                            NombrePais = dr["NombrePais"].ToString(),
                            PropietarioNave = dr["PropietarioNave"].ToString(),
                            LatitudUbicacionNave = dr["LatitudUbicacionNave"].ToString(),
                            LongitudUbicacionNave = dr["LongitudUbicacionNave"].ToString(),
                            AreaIntervencion = dr["AreaIntervencion"].ToString(),
                            DescAmbitoNave = dr["DescAmbitoNave"].ToString(),
                            SectorExtrainstitucional = dr["SectorExtrainstitucional"].ToString(),
                            Tenor = dr["Tenor"].ToString(),
                            Articulo = dr["Articulo"].ToString(),
                            AvisosInfraccion = Convert.ToInt32(dr["AvisosInfraccion"]),
                            Observaciones = dr["Observaciones"].ToString(),
 

                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(AvisoInfraccionImpuestoDTO avisoInfraccionImpuestoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AvisoInfraccionImpuestoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@JefaturaDistritoCapitaniaId", SqlDbType.Int);
                    cmd.Parameters["@JefaturaDistritoCapitaniaId"].Value = avisoInfraccionImpuestoDTO.JefaturaDistritoCapitaniaId;

                    cmd.Parameters.Add("@CapitaniaId", SqlDbType.Int);
                    cmd.Parameters["@CapitaniaId"].Value = avisoInfraccionImpuestoDTO.CapitaniaId;

                    cmd.Parameters.Add("@HoraInfraccion", SqlDbType.Time);
                    cmd.Parameters["@HoraInfraccion"].Value = avisoInfraccionImpuestoDTO.HoraInfraccion;

                    cmd.Parameters.Add("@FechaInfraccion", SqlDbType.Date);
                    cmd.Parameters["@FechaInfraccion"].Value = avisoInfraccionImpuestoDTO.FechaInfraccion;

                    cmd.Parameters.Add("@NombreNoveInfractora", SqlDbType.VarChar,150);
                    cmd.Parameters["@NombreNoveInfractora"].Value = avisoInfraccionImpuestoDTO.NombreNoveInfractora;

                    cmd.Parameters.Add("@MatriculaNaveInfractora", SqlDbType.VarChar,15);
                    cmd.Parameters["@MatriculaNaveInfractora"].Value = avisoInfraccionImpuestoDTO.MatriculaNaveInfractora;

                    cmd.Parameters.Add("@TipoNaveId", SqlDbType.Int);
                    cmd.Parameters["@TipoNaveId"].Value = avisoInfraccionImpuestoDTO.TipoNaveId;

                    cmd.Parameters.Add("@PaisUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@PaisUbigeoId"].Value = avisoInfraccionImpuestoDTO.PaisUbigeoId;

                    cmd.Parameters.Add("@PropietarioNave", SqlDbType.VarChar,200);
                    cmd.Parameters["@PropietarioNave"].Value = avisoInfraccionImpuestoDTO.PropietarioNave;

                    cmd.Parameters.Add("@LatitudUbicacionNave", SqlDbType.VarChar,15);
                    cmd.Parameters["@LatitudUbicacionNave"].Value = avisoInfraccionImpuestoDTO.LatitudUbicacionNave;

                    cmd.Parameters.Add("@LongitudUbicacionNave", SqlDbType.VarChar,15);
                    cmd.Parameters["@LongitudUbicacionNave"].Value = avisoInfraccionImpuestoDTO.LongitudUbicacionNave;

                    cmd.Parameters.Add("@AreaIntervencion", SqlDbType.VarChar,50);
                    cmd.Parameters["@AreaIntervencion"].Value = avisoInfraccionImpuestoDTO.AreaIntervencion;

                    cmd.Parameters.Add("@AmbitoNaveId", SqlDbType.Int);
                    cmd.Parameters["@AmbitoNaveId"].Value = avisoInfraccionImpuestoDTO.AmbitoNaveId;

                    cmd.Parameters.Add("@SectorExtrainstitucional", SqlDbType.VarChar,50);
                    cmd.Parameters["@SectorExtrainstitucional"].Value = avisoInfraccionImpuestoDTO.SectorExtrainstitucional;

                    cmd.Parameters.Add("@Tenor", SqlDbType.VarChar,10);
                    cmd.Parameters["@Tenor"].Value = avisoInfraccionImpuestoDTO.Tenor;

                    cmd.Parameters.Add("@Articulo", SqlDbType.VarChar,500);
                    cmd.Parameters["@Articulo"].Value = avisoInfraccionImpuestoDTO.Articulo;

                    cmd.Parameters.Add("@AvisosInfraccion", SqlDbType.Int);
                    cmd.Parameters["@AvisosInfraccion"].Value = avisoInfraccionImpuestoDTO.AvisosInfraccion;

                    cmd.Parameters.Add("@Observaciones", SqlDbType.VarChar,500);
                    cmd.Parameters["@Observaciones"].Value = avisoInfraccionImpuestoDTO.Observaciones;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = avisoInfraccionImpuestoDTO.UsuarioIngresoRegistro;

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

        public AvisoInfraccionImpuestoDTO BuscarFormato(int Codigo)
        {
            AvisoInfraccionImpuestoDTO avisoInfraccionImpuestoDTO = new AvisoInfraccionImpuestoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AvisoInfraccionImpuestoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AvisoInfraccionImpuestoId", SqlDbType.Int);
                    cmd.Parameters["@AvisoInfraccionImpuestoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        avisoInfraccionImpuestoDTO.AvisoInfraccionImpuestoId = Convert.ToInt32(dr["AvisoInfraccionImpuestoId"]);
                        avisoInfraccionImpuestoDTO.JefaturaDistritoCapitaniaId = Convert.ToInt32(dr["JefaturaDistritoCapitaniaId"]);
                        avisoInfraccionImpuestoDTO.CapitaniaId = Convert.ToInt32(dr["CapitaniaId"]);
                        avisoInfraccionImpuestoDTO.HoraInfraccion = dr["HoraInfraccion"].ToString();
                        avisoInfraccionImpuestoDTO.FechaInfraccion = Convert.ToDateTime(dr["FechaInfraccion"]).ToString("yyy-MM-dd");
                        avisoInfraccionImpuestoDTO.NombreNoveInfractora = dr["NombreNoveInfractora"].ToString();
                        avisoInfraccionImpuestoDTO.MatriculaNaveInfractora = dr["MatriculaNaveInfractora"].ToString();
                        avisoInfraccionImpuestoDTO.TipoNaveId = Convert.ToInt32(dr["TipoNaveId"]);
                        avisoInfraccionImpuestoDTO.PaisUbigeoId = Convert.ToInt32(dr["PaisUbigeoId"]);
                        avisoInfraccionImpuestoDTO.PropietarioNave = dr["PropietarioNave"].ToString();
                        avisoInfraccionImpuestoDTO.LatitudUbicacionNave = dr["LatitudUbicacionNave"].ToString();
                        avisoInfraccionImpuestoDTO.LongitudUbicacionNave = dr["LongitudUbicacionNave"].ToString();
                        avisoInfraccionImpuestoDTO.AreaIntervencion = dr["AreaIntervencion"].ToString();
                        avisoInfraccionImpuestoDTO.AmbitoNaveId = Convert.ToInt32(dr["AmbitoNaveId"]);
                        avisoInfraccionImpuestoDTO.SectorExtrainstitucional = dr["SectorExtrainstitucional"].ToString();
                        avisoInfraccionImpuestoDTO.Tenor = dr["Tenor"].ToString();
                        avisoInfraccionImpuestoDTO.Articulo = dr["Articulo"].ToString();
                        avisoInfraccionImpuestoDTO.AvisosInfraccion = Convert.ToInt32(dr["AvisosInfraccion"]);
                        avisoInfraccionImpuestoDTO.Observaciones = dr["Observaciones"].ToString(); 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return avisoInfraccionImpuestoDTO;
        }

        public string ActualizaFormato(AvisoInfraccionImpuestoDTO avisoInfraccionImpuestoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_AvisoInfraccionImpuestoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@AvisoInfraccionImpuestoId", SqlDbType.Int);
                    cmd.Parameters["@AvisoInfraccionImpuestoId"].Value = avisoInfraccionImpuestoDTO.AvisoInfraccionImpuestoId;

                    cmd.Parameters.Add("@JefaturaDistritoCapitaniaId", SqlDbType.Int);
                    cmd.Parameters["@JefaturaDistritoCapitaniaId"].Value = avisoInfraccionImpuestoDTO.JefaturaDistritoCapitaniaId;

                    cmd.Parameters.Add("@CapitaniaId", SqlDbType.Int);
                    cmd.Parameters["@CapitaniaId"].Value = avisoInfraccionImpuestoDTO.CapitaniaId;

                    cmd.Parameters.Add("@HoraInfraccion", SqlDbType.Time);
                    cmd.Parameters["@HoraInfraccion"].Value = avisoInfraccionImpuestoDTO.HoraInfraccion;

                    cmd.Parameters.Add("@FechaInfraccion", SqlDbType.Date);
                    cmd.Parameters["@FechaInfraccion"].Value = avisoInfraccionImpuestoDTO.FechaInfraccion;

                    cmd.Parameters.Add("@NombreNoveInfractora", SqlDbType.VarChar, 150);
                    cmd.Parameters["@NombreNoveInfractora"].Value = avisoInfraccionImpuestoDTO.NombreNoveInfractora;

                    cmd.Parameters.Add("@MatriculaNaveInfractora", SqlDbType.VarChar, 15);
                    cmd.Parameters["@MatriculaNaveInfractora"].Value = avisoInfraccionImpuestoDTO.MatriculaNaveInfractora;

                    cmd.Parameters.Add("@TipoNaveId", SqlDbType.Int);
                    cmd.Parameters["@TipoNaveId"].Value = avisoInfraccionImpuestoDTO.TipoNaveId;

                    cmd.Parameters.Add("@PaisUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@PaisUbigeoId"].Value = avisoInfraccionImpuestoDTO.PaisUbigeoId;

                    cmd.Parameters.Add("@PropietarioNave", SqlDbType.VarChar, 200);
                    cmd.Parameters["@PropietarioNave"].Value = avisoInfraccionImpuestoDTO.PropietarioNave;

                    cmd.Parameters.Add("@LatitudUbicacionNave", SqlDbType.VarChar, 15);
                    cmd.Parameters["@LatitudUbicacionNave"].Value = avisoInfraccionImpuestoDTO.LatitudUbicacionNave;

                    cmd.Parameters.Add("@LongitudUbicacionNave", SqlDbType.VarChar, 15);
                    cmd.Parameters["@LongitudUbicacionNave"].Value = avisoInfraccionImpuestoDTO.LongitudUbicacionNave;

                    cmd.Parameters.Add("@AreaIntervencion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@AreaIntervencion"].Value = avisoInfraccionImpuestoDTO.AreaIntervencion;

                    cmd.Parameters.Add("@AmbitoNaveId", SqlDbType.Int);
                    cmd.Parameters["@AmbitoNaveId"].Value = avisoInfraccionImpuestoDTO.AmbitoNaveId;

                    cmd.Parameters.Add("@SectorExtrainstitucional", SqlDbType.VarChar, 50);
                    cmd.Parameters["@SectorExtrainstitucional"].Value = avisoInfraccionImpuestoDTO.SectorExtrainstitucional;

                    cmd.Parameters.Add("@Tenor", SqlDbType.VarChar, 10);
                    cmd.Parameters["@Tenor"].Value = avisoInfraccionImpuestoDTO.Tenor;

                    cmd.Parameters.Add("@Articulo", SqlDbType.VarChar, 500);
                    cmd.Parameters["@Articulo"].Value = avisoInfraccionImpuestoDTO.Articulo;

                    cmd.Parameters.Add("@AvisosInfraccion", SqlDbType.Int);
                    cmd.Parameters["@AvisosInfraccion"].Value = avisoInfraccionImpuestoDTO.AvisosInfraccion;

                    cmd.Parameters.Add("@Observaciones", SqlDbType.VarChar, 500);
                    cmd.Parameters["@Observaciones"].Value = avisoInfraccionImpuestoDTO.Observaciones;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = avisoInfraccionImpuestoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(AvisoInfraccionImpuestoDTO avisoInfraccionImpuestoDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AvisoInfraccionImpuestoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AvisoInfraccionImpuestoId", SqlDbType.Int);
                    cmd.Parameters["@AvisoInfraccionImpuestoId"].Value = avisoInfraccionImpuestoDTO.AvisoInfraccionImpuestoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = avisoInfraccionImpuestoDTO.UsuarioIngresoRegistro;

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
        public bool InsercionMasiva(IEnumerable<AvisoInfraccionImpuestoDTO> avisoInfraccionImpuestoDTO)
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
                            foreach (var item in avisoInfraccionImpuestoDTO)
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
