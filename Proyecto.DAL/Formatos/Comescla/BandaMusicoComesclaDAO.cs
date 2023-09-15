using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comescla;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comescla
{
    public class BandaMusicoComesclaDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<BandaMusicoComesclaDTO> ObtenerLista()
        {
            List<BandaMusicoComesclaDTO> lista = new List<BandaMusicoComesclaDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_BandaMusicoComesclaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new BandaMusicoComesclaDTO()
                        {
                            BandaMusicoId = Convert.ToInt32(dr["BandaMusicoId"]),
                            DescTipoComision = dr["DescTipoComision"].ToString(),
                            DescEvento = dr["DescEvento"].ToString(),
                            SolicitudDocumentoReferencia = dr["SolicitudDocumentoReferencia"].ToString(),
                            InstitucionSolicitante = dr["InstitucionSolicitante"].ToString(),
                            DescGrupoComisionado = dr["DescGrupoComisionado"].ToString(),
                            VestimentaUniforme = dr["VestimentaUniforme"].ToString(),
                            NombreEvento = dr["NombreEvento"].ToString(),
                            Lugar = dr["Lugar"].ToString(),
                            FechaHoraSalida = dr["FechaHoraSalida"].ToString(),
                            FechaHoraInicio = dr["FechaHoraInicio"].ToString(),
                            FechaHoraTermino = dr["FechaHoraTermino"].ToString(),
                            RequerimientoMovilidad = dr["RequerimientoMovilidad"].ToString() ,
                            Observaciones = dr["Observaciones"].ToString(),


                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(BandaMusicoComesclaDTO bandaMusicoComesclaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_BandaMusicoComesclaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoComisionId", SqlDbType.Int);
                    cmd.Parameters["@TipoComisionId"].Value = bandaMusicoComesclaDTO.TipoComisionId;

                    cmd.Parameters.Add("@EventoId", SqlDbType.Int);
                    cmd.Parameters["@EventoId"].Value = bandaMusicoComesclaDTO.EventoId;

                    cmd.Parameters.Add("@SolicitudDocumentoReferencia", SqlDbType.VarChar,50);
                    cmd.Parameters["@SolicitudDocumentoReferencia"].Value = bandaMusicoComesclaDTO.SolicitudDocumentoReferencia;

                    cmd.Parameters.Add("@InstitucionSolicitante", SqlDbType.VarChar,100);
                    cmd.Parameters["@InstitucionSolicitante"].Value = bandaMusicoComesclaDTO.InstitucionSolicitante;

                    cmd.Parameters.Add("@GrupoComisionadoId", SqlDbType.Int);
                    cmd.Parameters["@GrupoComisionadoId"].Value = bandaMusicoComesclaDTO.GrupoComisionadoId;

                    cmd.Parameters.Add("@VestimentaUniforme", SqlDbType.VarChar,50);
                    cmd.Parameters["@VestimentaUniforme"].Value = bandaMusicoComesclaDTO.VestimentaUniforme;

                    cmd.Parameters.Add("@NombreEvento", SqlDbType.VarChar,200);
                    cmd.Parameters["@NombreEvento"].Value = bandaMusicoComesclaDTO.NombreEvento;

                    cmd.Parameters.Add("@Lugar", SqlDbType.VarChar,200);
                    cmd.Parameters["@Lugar"].Value = bandaMusicoComesclaDTO.Lugar;

                    cmd.Parameters.Add("@FechaHoraSalida", SqlDbType.DateTime);
                    cmd.Parameters["@FechaHoraSalida"].Value = bandaMusicoComesclaDTO.FechaHoraSalida;

                    cmd.Parameters.Add("@FechaHoraInicio", SqlDbType.DateTime);
                    cmd.Parameters["@FechaHoraInicio"].Value = bandaMusicoComesclaDTO.FechaHoraInicio;

                    cmd.Parameters.Add("@FechaHoraTermino", SqlDbType.DateTime);
                    cmd.Parameters["@FechaHoraTermino"].Value = bandaMusicoComesclaDTO.FechaHoraTermino;

                    cmd.Parameters.Add("@RequerimientoMovilidad", SqlDbType.NChar,1);
                    cmd.Parameters["@RequerimientoMovilidad"].Value = bandaMusicoComesclaDTO.RequerimientoMovilidad;

                    cmd.Parameters.Add("@Observaciones", SqlDbType.VarChar,200);
                    cmd.Parameters["@Observaciones"].Value = bandaMusicoComesclaDTO.Observaciones;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = bandaMusicoComesclaDTO.UsuarioIngresoRegistro;

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

        public BandaMusicoComesclaDTO BuscarFormato(int Codigo)
        {
            BandaMusicoComesclaDTO bandaMusicoComesclaDTO = new BandaMusicoComesclaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_BandaMusicoComesclaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@BandaMusicoId", SqlDbType.Int);
                    cmd.Parameters["@BandaMusicoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        bandaMusicoComesclaDTO.BandaMusicoId = Convert.ToInt32(dr["BandaMusicoId"]);
                        bandaMusicoComesclaDTO.TipoComisionId = Convert.ToInt32(dr["TipoComisionId"]);
                        bandaMusicoComesclaDTO.EventoId = Convert.ToInt32(dr["EventoId"]);
                        bandaMusicoComesclaDTO.SolicitudDocumentoReferencia = dr["SolicitudDocumentoReferencia"].ToString();
                        bandaMusicoComesclaDTO.InstitucionSolicitante = dr["InstitucionSolicitante"].ToString();
                        bandaMusicoComesclaDTO.GrupoComisionadoId = Convert.ToInt32(dr["GrupoComisionadoId"]);
                        bandaMusicoComesclaDTO.VestimentaUniforme = dr["VestimentaUniforme"].ToString();
                        bandaMusicoComesclaDTO.NombreEvento = dr["NombreEvento"].ToString();
                        bandaMusicoComesclaDTO.Lugar = dr["Lugar"].ToString();
                        bandaMusicoComesclaDTO.FechaHoraSalida = Convert.ToDateTime(dr["FechaHoraSalida"]).ToString("yyy-MM-dd");
                        bandaMusicoComesclaDTO.FechaHoraInicio = Convert.ToDateTime(dr["FechaHoraInicio"]).ToString("yyy-MM-dd");
                        bandaMusicoComesclaDTO.FechaHoraTermino = Convert.ToDateTime(dr["FechaHoraTermino"]).ToString("yyy-MM-dd");
                        bandaMusicoComesclaDTO.RequerimientoMovilidad = dr["RequerimientoMovilidad"].ToString();
                        bandaMusicoComesclaDTO.Observaciones = dr["Observaciones"].ToString(); 
 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return bandaMusicoComesclaDTO;
        }

        public string ActualizaFormato(BandaMusicoComesclaDTO bandaMusicoComesclaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_BandaMusicoComesclaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@BandaMusicoId", SqlDbType.Int);
                    cmd.Parameters["@BandaMusicoId"].Value = bandaMusicoComesclaDTO.BandaMusicoId;

                    cmd.Parameters.Add("@TipoComisionId", SqlDbType.Int);
                    cmd.Parameters["@TipoComisionId"].Value = bandaMusicoComesclaDTO.TipoComisionId;

                    cmd.Parameters.Add("@EventoId", SqlDbType.Int);
                    cmd.Parameters["@EventoId"].Value = bandaMusicoComesclaDTO.EventoId;

                    cmd.Parameters.Add("@SolicitudDocumentoReferencia", SqlDbType.VarChar, 50);
                    cmd.Parameters["@SolicitudDocumentoReferencia"].Value = bandaMusicoComesclaDTO.SolicitudDocumentoReferencia;

                    cmd.Parameters.Add("@InstitucionSolicitante", SqlDbType.VarChar, 100);
                    cmd.Parameters["@InstitucionSolicitante"].Value = bandaMusicoComesclaDTO.InstitucionSolicitante;

                    cmd.Parameters.Add("@GrupoComisionadoId", SqlDbType.Int);
                    cmd.Parameters["@GrupoComisionadoId"].Value = bandaMusicoComesclaDTO.GrupoComisionadoId;

                    cmd.Parameters.Add("@VestimentaUniforme", SqlDbType.VarChar, 50);
                    cmd.Parameters["@VestimentaUniforme"].Value = bandaMusicoComesclaDTO.VestimentaUniforme;

                    cmd.Parameters.Add("@NombreEvento", SqlDbType.VarChar, 200);
                    cmd.Parameters["@NombreEvento"].Value = bandaMusicoComesclaDTO.NombreEvento;

                    cmd.Parameters.Add("@Lugar", SqlDbType.VarChar, 200);
                    cmd.Parameters["@Lugar"].Value = bandaMusicoComesclaDTO.Lugar;

                    cmd.Parameters.Add("@FechaHoraSalida", SqlDbType.DateTime);
                    cmd.Parameters["@FechaHoraSalida"].Value = bandaMusicoComesclaDTO.FechaHoraSalida;

                    cmd.Parameters.Add("@FechaHoraInicio", SqlDbType.DateTime);
                    cmd.Parameters["@FechaHoraInicio"].Value = bandaMusicoComesclaDTO.FechaHoraInicio;

                    cmd.Parameters.Add("@FechaHoraTermino", SqlDbType.DateTime);
                    cmd.Parameters["@FechaHoraTermino"].Value = bandaMusicoComesclaDTO.FechaHoraTermino;

                    cmd.Parameters.Add("@RequerimientoMovilidad", SqlDbType.NChar, 1);
                    cmd.Parameters["@RequerimientoMovilidad"].Value = bandaMusicoComesclaDTO.RequerimientoMovilidad;

                    cmd.Parameters.Add("@Observaciones", SqlDbType.VarChar, 200);
                    cmd.Parameters["@Observaciones"].Value = bandaMusicoComesclaDTO.Observaciones;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = bandaMusicoComesclaDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(BandaMusicoComesclaDTO bandaMusicoComesclaDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_BandaMusicoComesclaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@BandaMusicoId", SqlDbType.Int);
                    cmd.Parameters["@BandaMusicoId"].Value = bandaMusicoComesclaDTO.BandaMusicoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = bandaMusicoComesclaDTO.UsuarioIngresoRegistro;

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
        public bool InsercionMasiva(IEnumerable<BandaMusicoComesclaDTO> bandaMusicoComesclaDTO)
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
                            foreach (var item in bandaMusicoComesclaDTO)
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
