using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comoperguard;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comoperguard
{
    public class NaveExtranjeraCapturadaDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<NaveExtranjeraCapturadaDTO> ObtenerLista()
        {
            List<NaveExtranjeraCapturadaDTO> lista = new List<NaveExtranjeraCapturadaDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_NaveExtranjeraCapturadaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new NaveExtranjeraCapturadaDTO()
                        {
                            NavesExtranjerasCapturadasId = Convert.ToInt32(dr["NavesExtranjerasCapturadasId"]),
                            DescJefaturaDistritoCapitania = dr["DescJefaturaDistritoCapitania"].ToString(),
                            NombreCapitania = dr["NombreCapitania"].ToString(),
                            HoraCaptura = dr["HoraCaptura"].ToString(),
                            DiaCaptura = Convert.ToInt32(dr["DiaCaptura"]),
                            DescMes = dr["DescMes"].ToString(),
                            AnioCaptura = Convert.ToInt32(dr["AnioCaptura"]),
                            NombreNaveExtranjera = dr["NombreNaveExtranjera"].ToString(),
                            MatriculaNaveExtranjera = dr["MatriculaNaveExtranjera"].ToString(),
                            NombrePais = dr["NombrePais"].ToString(),
                            DescTipoNave = dr["DescTipoNave"].ToString(),
                            DescUnidadNaval = dr["DescUnidadNaval"].ToString(),
                            DescAmbitoNave = dr["DescAmbitoNave"].ToString(),
                            TenorInfracciones = dr["TenorInfracciones"].ToString(),
                            ArticuloInfraccion = dr["ArticuloInfraccion"].ToString(),
                            ProcesoAdministrativo = dr["ProcesoAdministrativo"].ToString(),
                            Observaciones = dr["Observaciones"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(NaveExtranjeraCapturadaDTO naveExtranjeraCapturadaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_NaveExtranjeraCapturadaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@JefaturaDistritoCapitaniaId", SqlDbType.Int);
                    cmd.Parameters["@JefaturaDistritoCapitaniaId"].Value = naveExtranjeraCapturadaDTO.JefaturaDistritoCapitaniaId;

                    cmd.Parameters.Add("@CapitaniaId", SqlDbType.Int);
                    cmd.Parameters["@CapitaniaId"].Value = naveExtranjeraCapturadaDTO.CapitaniaId;

                    cmd.Parameters.Add("@HoraCaptura", SqlDbType.Time);
                    cmd.Parameters["@HoraCaptura"].Value = naveExtranjeraCapturadaDTO.HoraCaptura;

                    cmd.Parameters.Add("@DiaCaptura", SqlDbType.Int);
                    cmd.Parameters["@DiaCaptura"].Value = naveExtranjeraCapturadaDTO.DiaCaptura;

                    cmd.Parameters.Add("@MesId", SqlDbType.Int);
                    cmd.Parameters["@MesId"].Value = naveExtranjeraCapturadaDTO.MesId;

                    cmd.Parameters.Add("@AnioCaptura", SqlDbType.Int);
                    cmd.Parameters["@AnioCaptura"].Value = naveExtranjeraCapturadaDTO.AnioCaptura;

                    cmd.Parameters.Add("@NombreNaveExtranjera", SqlDbType.VarChar,150);
                    cmd.Parameters["@NombreNaveExtranjera"].Value = naveExtranjeraCapturadaDTO.NombreNaveExtranjera;

                    cmd.Parameters.Add("@MatriculaNaveExtranjera", SqlDbType.VarChar,15);
                    cmd.Parameters["@MatriculaNaveExtranjera"].Value = naveExtranjeraCapturadaDTO.MatriculaNaveExtranjera;

                    cmd.Parameters.Add("@PaisUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@PaisUbigeoId"].Value = naveExtranjeraCapturadaDTO.PaisUbigeoId;

                    cmd.Parameters.Add("@TipoNaveId", SqlDbType.Int);
                    cmd.Parameters["@TipoNaveId"].Value = naveExtranjeraCapturadaDTO.TipoNaveId;

                    cmd.Parameters.Add("@UnidadNavalId", SqlDbType.Int);
                    cmd.Parameters["@UnidadNavalId"].Value = naveExtranjeraCapturadaDTO.UnidadNavalId;

                    cmd.Parameters.Add("@AmbitoNaveId", SqlDbType.Int);
                    cmd.Parameters["@AmbitoNaveId"].Value = naveExtranjeraCapturadaDTO.AmbitoNaveId;

                    cmd.Parameters.Add("@TenorInfracciones", SqlDbType.VarChar,10);
                    cmd.Parameters["@TenorInfracciones"].Value = naveExtranjeraCapturadaDTO.TenorInfracciones;

                    cmd.Parameters.Add("@ArticuloInfraccion", SqlDbType.VarChar,100);
                    cmd.Parameters["@ArticuloInfraccion"].Value = naveExtranjeraCapturadaDTO.ArticuloInfraccion;

                    cmd.Parameters.Add("@ProcesoAdministrativo", SqlDbType.VarChar,50);
                    cmd.Parameters["@ProcesoAdministrativo"].Value = naveExtranjeraCapturadaDTO.ProcesoAdministrativo;

                    cmd.Parameters.Add("@Observaciones", SqlDbType.VarChar,200);
                    cmd.Parameters["@Observaciones"].Value = naveExtranjeraCapturadaDTO.Observaciones;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = naveExtranjeraCapturadaDTO.UsuarioIngresoRegistro;

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

        public NaveExtranjeraCapturadaDTO BuscarFormato(int Codigo)
        {
            NaveExtranjeraCapturadaDTO naveExtranjeraCapturadaDTO = new NaveExtranjeraCapturadaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_NaveExtranjeraCapturadaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@NavesExtranjerasCapturadasId", SqlDbType.Int);
                    cmd.Parameters["@NavesExtranjerasCapturadasId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        naveExtranjeraCapturadaDTO.NavesExtranjerasCapturadasId = Convert.ToInt32(dr["NavesExtranjerasCapturadasId"]);
                        naveExtranjeraCapturadaDTO.JefaturaDistritoCapitaniaId = Convert.ToInt32(dr["JefaturaDistritoCapitaniaId"]);
                        naveExtranjeraCapturadaDTO.CapitaniaId = Convert.ToInt32(dr["CapitaniaId"]);
                        naveExtranjeraCapturadaDTO.HoraCaptura = dr["HoraCaptura"].ToString();
                        naveExtranjeraCapturadaDTO.DiaCaptura = Convert.ToInt32(dr["DiaCaptura"]);
                        naveExtranjeraCapturadaDTO.MesId = Convert.ToInt32(dr["MesId"]);
                        naveExtranjeraCapturadaDTO.AnioCaptura = Convert.ToInt32(dr["AnioCaptura"]);
                        naveExtranjeraCapturadaDTO.NombreNaveExtranjera = dr["NombreNaveExtranjera"].ToString();
                        naveExtranjeraCapturadaDTO.MatriculaNaveExtranjera = dr["MatriculaNaveExtranjera"].ToString();
                        naveExtranjeraCapturadaDTO.PaisUbigeoId = Convert.ToInt32(dr["PaisUbigeoId"]);
                        naveExtranjeraCapturadaDTO.TipoNaveId = Convert.ToInt32(dr["TipoNaveId"]);
                        naveExtranjeraCapturadaDTO.UnidadNavalId = Convert.ToInt32(dr["UnidadNavalId"]);
                        naveExtranjeraCapturadaDTO.AmbitoNaveId = Convert.ToInt32(dr["AmbitoNaveId"]);
                        naveExtranjeraCapturadaDTO.TenorInfracciones = dr["TenorInfracciones"].ToString();
                        naveExtranjeraCapturadaDTO.ArticuloInfraccion = dr["ArticuloInfraccion"].ToString();
                        naveExtranjeraCapturadaDTO.ProcesoAdministrativo = dr["ProcesoAdministrativo"].ToString();
                        naveExtranjeraCapturadaDTO.Observaciones = dr["Observaciones"].ToString(); 
 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return naveExtranjeraCapturadaDTO;
        }

        public string ActualizaFormato(NaveExtranjeraCapturadaDTO naveExtranjeraCapturadaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_NaveExtranjeraCapturadaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@NavesExtranjerasCapturadasId", SqlDbType.Int);
                    cmd.Parameters["@NavesExtranjerasCapturadasId"].Value = naveExtranjeraCapturadaDTO.NavesExtranjerasCapturadasId;

                    cmd.Parameters.Add("@JefaturaDistritoCapitaniaId", SqlDbType.Int);
                    cmd.Parameters["@JefaturaDistritoCapitaniaId"].Value = naveExtranjeraCapturadaDTO.JefaturaDistritoCapitaniaId;

                    cmd.Parameters.Add("@CapitaniaId", SqlDbType.Int);
                    cmd.Parameters["@CapitaniaId"].Value = naveExtranjeraCapturadaDTO.CapitaniaId;

                    cmd.Parameters.Add("@HoraCaptura", SqlDbType.Time);
                    cmd.Parameters["@HoraCaptura"].Value = naveExtranjeraCapturadaDTO.HoraCaptura;

                    cmd.Parameters.Add("@DiaCaptura", SqlDbType.Int);
                    cmd.Parameters["@DiaCaptura"].Value = naveExtranjeraCapturadaDTO.DiaCaptura;

                    cmd.Parameters.Add("@MesId", SqlDbType.Int);
                    cmd.Parameters["@MesId"].Value = naveExtranjeraCapturadaDTO.MesId;

                    cmd.Parameters.Add("@AnioCaptura", SqlDbType.Int);
                    cmd.Parameters["@AnioCaptura"].Value = naveExtranjeraCapturadaDTO.AnioCaptura;

                    cmd.Parameters.Add("@NombreNaveExtranjera", SqlDbType.VarChar, 150);
                    cmd.Parameters["@NombreNaveExtranjera"].Value = naveExtranjeraCapturadaDTO.NombreNaveExtranjera;

                    cmd.Parameters.Add("@MatriculaNaveExtranjera", SqlDbType.VarChar, 15);
                    cmd.Parameters["@MatriculaNaveExtranjera"].Value = naveExtranjeraCapturadaDTO.MatriculaNaveExtranjera;

                    cmd.Parameters.Add("@PaisUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@PaisUbigeoId"].Value = naveExtranjeraCapturadaDTO.PaisUbigeoId;

                    cmd.Parameters.Add("@TipoNaveId", SqlDbType.Int);
                    cmd.Parameters["@TipoNaveId"].Value = naveExtranjeraCapturadaDTO.TipoNaveId;

                    cmd.Parameters.Add("@UnidadNavalId", SqlDbType.Int);
                    cmd.Parameters["@UnidadNavalId"].Value = naveExtranjeraCapturadaDTO.UnidadNavalId;

                    cmd.Parameters.Add("@AmbitoNaveId", SqlDbType.Int);
                    cmd.Parameters["@AmbitoNaveId"].Value = naveExtranjeraCapturadaDTO.AmbitoNaveId;

                    cmd.Parameters.Add("@TenorInfracciones", SqlDbType.VarChar, 10);
                    cmd.Parameters["@TenorInfracciones"].Value = naveExtranjeraCapturadaDTO.TenorInfracciones;

                    cmd.Parameters.Add("@ArticuloInfraccion", SqlDbType.VarChar, 100);
                    cmd.Parameters["@ArticuloInfraccion"].Value = naveExtranjeraCapturadaDTO.ArticuloInfraccion;

                    cmd.Parameters.Add("@ProcesoAdministrativo", SqlDbType.VarChar, 50);
                    cmd.Parameters["@ProcesoAdministrativo"].Value = naveExtranjeraCapturadaDTO.ProcesoAdministrativo;

                    cmd.Parameters.Add("@Observaciones", SqlDbType.VarChar, 200);
                    cmd.Parameters["@Observaciones"].Value = naveExtranjeraCapturadaDTO.Observaciones;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = naveExtranjeraCapturadaDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(NaveExtranjeraCapturadaDTO naveExtranjeraCapturadaDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_NaveExtranjeraCapturadaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@NavesExtranjerasCapturadasId", SqlDbType.Int);
                    cmd.Parameters["@NavesExtranjerasCapturadasId"].Value = naveExtranjeraCapturadaDTO.NavesExtranjerasCapturadasId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = naveExtranjeraCapturadaDTO.UsuarioIngresoRegistro;

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
        public bool InsercionMasiva(IEnumerable<NaveExtranjeraCapturadaDTO> naveExtranjeraCapturadaDTO)
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
                            foreach (var item in naveExtranjeraCapturadaDTO)
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
