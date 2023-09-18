using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comoperguard;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comoperguard
{ 
    public class ZarpeRetornoNaveExtranjeraDAO
    {

    SqlCommand cmd = new SqlCommand();

    public List<ZarpeRetornoNaveExtranjeraDTO> ObtenerLista()
    {
        List<ZarpeRetornoNaveExtranjeraDTO> lista = new List<ZarpeRetornoNaveExtranjeraDTO>();

        var cn = new ConfiguracionConexion();

        using (var conexion = new SqlConnection(cn.getCadenaSQL()))
        {
            conexion.Open();
            cmd = new SqlCommand("Formato.usp_ZarpeRetornoNaveExtranjeraListar", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            using (SqlDataReader dr = cmd.ExecuteReader())
            {

                while (dr.Read())
                {
                    lista.Add(new ZarpeRetornoNaveExtranjeraDTO()
                    {
                        ZarpeRetornoNaveExtranjeraId = Convert.ToInt32(dr["ZarpeRetornoNaveExtranjeraId"]),
                        DescJefaturaDistritoCapitania = dr["DescJefaturaDistritoCapitania"].ToString(),
                        NombreCapitania = dr["NombreCapitania"].ToString(),
                        HoraCaptura = dr["HoraCaptura"].ToString(),
                        DiaCaptura = Convert.ToInt32(dr["DiaCaptura"]),
                        DescMesa = dr["DescMesa"].ToString(),
                        AnioCaptura = Convert.ToInt32(dr["AnioCaptura"]),
                        NombreNaveExtranjera = dr["NombreNaveExtranjera"].ToString(),
                        MatriculaNaveExtranjera = dr["MatriculaNaveExtranjera"].ToString(),
                        NombrePais = dr["NombrePais"].ToString(),
                        DescTipoNave = dr["DescTipoNave"].ToString(),
                        DescUnidadNaval = dr["DescUnidadNaval"].ToString(),
                        CascoUnidadNaval = Convert.ToInt32(dr["CascoUnidadNaval"]),
                        DescPuertoPeru = dr["DescPuertoPeru"].ToString(),
                        DescAmbitoNave = dr["DescAmbitoNave"].ToString(),
                        HoraArribo = dr["HoraArribo"].ToString(),
                        DiaArribo = Convert.ToInt32(dr["DiaArribo"]),
                        MesArribo = Convert.ToInt32(dr["MesArribo"]),
                        AnioArribo = Convert.ToInt32(dr["AnioArribo"]),
                        PuertoDestino = dr["PuertoDestino"].ToString(),
                        PaisDestino = Convert.ToInt32(dr["PaisDestino"]),
                        ETA = dr["ETA"].ToString(),

                        });
                }
            }
        }
        return lista;
    }

    public string AgregarRegistro(ZarpeRetornoNaveExtranjeraDTO zarpeRetornoNaveExtranjeraDTO)
    {
        string IND_OPERACION = "0";
        var cn = new ConfiguracionConexion();
        using (var conexion = new SqlConnection(cn.getCadenaSQL()))
        {
            try
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_ZarpeRetornoNaveExtranjeraRegistrar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@JefaturaDistritoCapitaniaId", SqlDbType.Int);
                cmd.Parameters["@JefaturaDistritoCapitaniaId"].Value = zarpeRetornoNaveExtranjeraDTO.JefaturaDistritoCapitaniaId;

                cmd.Parameters.Add("@CapitaniaId", SqlDbType.Int);
                cmd.Parameters["@CapitaniaId"].Value = zarpeRetornoNaveExtranjeraDTO.CapitaniaId;

                cmd.Parameters.Add("@HoraCaptura", SqlDbType.Time);
                cmd.Parameters["@HoraCaptura"].Value = zarpeRetornoNaveExtranjeraDTO.HoraCaptura;

                cmd.Parameters.Add("@DiaCaptura", SqlDbType.Int);
                cmd.Parameters["@DiaCaptura"].Value = zarpeRetornoNaveExtranjeraDTO.DiaCaptura;

                cmd.Parameters.Add("@MesId", SqlDbType.Int);
                cmd.Parameters["@MesId"].Value = zarpeRetornoNaveExtranjeraDTO.MesId;

                cmd.Parameters.Add("@AnioCaptura", SqlDbType.Int);
                cmd.Parameters["@AnioCaptura"].Value = zarpeRetornoNaveExtranjeraDTO.AnioCaptura;

                cmd.Parameters.Add("@NombreNaveExtranjera", SqlDbType.VarChar,150);
                cmd.Parameters["@NombreNaveExtranjera"].Value = zarpeRetornoNaveExtranjeraDTO.NombreNaveExtranjera;

                cmd.Parameters.Add("@MatriculaNaveExtranjera", SqlDbType.VarChar,15);
                cmd.Parameters["@MatriculaNaveExtranjera"].Value = zarpeRetornoNaveExtranjeraDTO.MatriculaNaveExtranjera;

                cmd.Parameters.Add("@PaisUbigeoId", SqlDbType.Int);
                cmd.Parameters["@PaisUbigeoId"].Value = zarpeRetornoNaveExtranjeraDTO.PaisUbigeoId;

                cmd.Parameters.Add("@TipoNaveId", SqlDbType.Int);
                cmd.Parameters["@TipoNaveId"].Value = zarpeRetornoNaveExtranjeraDTO.TipoNaveId;

                cmd.Parameters.Add("@UnidadNavalId", SqlDbType.Int);
                cmd.Parameters["@UnidadNavalId"].Value = zarpeRetornoNaveExtranjeraDTO.UnidadNavalId;

                cmd.Parameters.Add("@CascoUnidadNaval", SqlDbType.Int);
                cmd.Parameters["@CascoUnidadNaval"].Value = zarpeRetornoNaveExtranjeraDTO.CascoUnidadNaval;

                cmd.Parameters.Add("@PuertoPeruId", SqlDbType.Int);
                cmd.Parameters["@PuertoPeruId"].Value = zarpeRetornoNaveExtranjeraDTO.PuertoPeruId;

                cmd.Parameters.Add("@AmbitoNaveId", SqlDbType.Int);
                cmd.Parameters["@AmbitoNaveId"].Value = zarpeRetornoNaveExtranjeraDTO.AmbitoNaveId;

                cmd.Parameters.Add("@HoraArribo", SqlDbType.Time);
                cmd.Parameters["@HoraArribo"].Value = zarpeRetornoNaveExtranjeraDTO.HoraArribo;

                cmd.Parameters.Add("@DiaArribo", SqlDbType.Int);
                cmd.Parameters["@DiaArribo"].Value = zarpeRetornoNaveExtranjeraDTO.DiaArribo;

                cmd.Parameters.Add("@MesArribo", SqlDbType.Int);
                cmd.Parameters["@MesArribo"].Value = zarpeRetornoNaveExtranjeraDTO.MesArribo;

                cmd.Parameters.Add("@AnioArribo", SqlDbType.Int);
                cmd.Parameters["@AnioArribo"].Value = zarpeRetornoNaveExtranjeraDTO.AnioArribo;

                cmd.Parameters.Add("@PuertoDestino", SqlDbType.VarChar,50);
                cmd.Parameters["@PuertoDestino"].Value = zarpeRetornoNaveExtranjeraDTO.PuertoDestino;

                cmd.Parameters.Add("@PaisDestino", SqlDbType.Int);
                cmd.Parameters["@PaisDestino"].Value = zarpeRetornoNaveExtranjeraDTO.PaisDestino;

                cmd.Parameters.Add("@ETA", SqlDbType.VarChar,100);
                cmd.Parameters["@ETA"].Value = zarpeRetornoNaveExtranjeraDTO.ETA;

                cmd.Parameters.Add("@Observaciones", SqlDbType.VarChar,200);
                cmd.Parameters["@Observaciones"].Value = zarpeRetornoNaveExtranjeraDTO.Observaciones;

                cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                cmd.Parameters["@CodigoCargo"].Value = "1";

                cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                cmd.Parameters["@Usuario"].Value = zarpeRetornoNaveExtranjeraDTO.UsuarioIngresoRegistro;

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

    public ZarpeRetornoNaveExtranjeraDTO BuscarFormato(int Codigo)
    {
        ZarpeRetornoNaveExtranjeraDTO zarpeRetornoNaveExtranjeraDTO = new ZarpeRetornoNaveExtranjeraDTO();
        var cn = new ConfiguracionConexion();

        try
        {
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_ZarpeRetornoNaveExtranjeraEncontrar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@ZarpeRetornoNaveExtranjeraId", SqlDbType.Int);
                cmd.Parameters["@ZarpeRetornoNaveExtranjeraId"].Value = Codigo;

                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();

                if (dr.HasRows)
                {

                    zarpeRetornoNaveExtranjeraDTO.ZarpeRetornoNaveExtranjeraId = Convert.ToInt32(dr["ZarpeRetornoNaveExtranjeraId"]);
                    zarpeRetornoNaveExtranjeraDTO.JefaturaDistritoCapitaniaId = Convert.ToInt32(dr["JefaturaDistritoCapitaniaId"]);
                    zarpeRetornoNaveExtranjeraDTO.CapitaniaId = Convert.ToInt32(dr["CapitaniaId"]);
                    zarpeRetornoNaveExtranjeraDTO.HoraCaptura = dr["HoraCaptura"].ToString();
                    zarpeRetornoNaveExtranjeraDTO.DiaCaptura = Convert.ToInt32(dr["DiaCaptura"]);
                    zarpeRetornoNaveExtranjeraDTO.MesId = Convert.ToInt32(dr["MesId"]);
                    zarpeRetornoNaveExtranjeraDTO.AnioCaptura = Convert.ToInt32(dr["AnioCaptura"]);
                    zarpeRetornoNaveExtranjeraDTO.NombreNaveExtranjera = dr["NombreNaveExtranjera"].ToString();
                    zarpeRetornoNaveExtranjeraDTO.MatriculaNaveExtranjera = dr["MatriculaNaveExtranjera"].ToString();
                    zarpeRetornoNaveExtranjeraDTO.PaisUbigeoId = Convert.ToInt32(dr["PaisUbigeoId"]);
                    zarpeRetornoNaveExtranjeraDTO.TipoNaveId = Convert.ToInt32(dr["TipoNaveId"]);
                    zarpeRetornoNaveExtranjeraDTO.UnidadNavalId = Convert.ToInt32(dr["UnidadNavalId"]);
                    zarpeRetornoNaveExtranjeraDTO.CascoUnidadNaval = Convert.ToInt32(dr["CascoUnidadNaval"]);
                    zarpeRetornoNaveExtranjeraDTO.PuertoPeruId = Convert.ToInt32(dr["PuertoPeruId"]);
                    zarpeRetornoNaveExtranjeraDTO.AmbitoNaveId = Convert.ToInt32(dr["AmbitoNaveId"]);
                    zarpeRetornoNaveExtranjeraDTO.HoraArribo = dr["HoraArribo"].ToString();
                    zarpeRetornoNaveExtranjeraDTO.DiaArribo = Convert.ToInt32(dr["DiaArribo"]);
                    zarpeRetornoNaveExtranjeraDTO.MesArribo = Convert.ToInt32(dr["MesArribo"]);
                    zarpeRetornoNaveExtranjeraDTO.AnioArribo = Convert.ToInt32(dr["AnioArribo"]);
                    zarpeRetornoNaveExtranjeraDTO.PuertoDestino = dr["PuertoDestino"].ToString();
                    zarpeRetornoNaveExtranjeraDTO.PaisDestino = Convert.ToInt32(dr["PaisDestino"]);
                    zarpeRetornoNaveExtranjeraDTO.ETA = dr["ETA"].ToString(); 

                    }

            }
        }
        catch (Exception)
        {
            throw;
        }
        return zarpeRetornoNaveExtranjeraDTO;
    }

    public string ActualizaFormato(ZarpeRetornoNaveExtranjeraDTO zarpeRetornoNaveExtranjeraDTO)
    {
        string IND_OPERACION = "0";
        var cn = new ConfiguracionConexion();

        try
        {
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();

                cmd = new SqlCommand("Formato.usp_ZarpeRetornoNaveExtranjeraActualizar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.Add("@ZarpeRetornoNaveExtranjeraId", SqlDbType.Int);
                cmd.Parameters["@ZarpeRetornoNaveExtranjeraId"].Value = zarpeRetornoNaveExtranjeraDTO.ZarpeRetornoNaveExtranjeraId;

                cmd.Parameters.Add("@JefaturaDistritoCapitaniaId", SqlDbType.Int);
                cmd.Parameters["@JefaturaDistritoCapitaniaId"].Value = zarpeRetornoNaveExtranjeraDTO.JefaturaDistritoCapitaniaId;

                cmd.Parameters.Add("@CapitaniaId", SqlDbType.Int);
                cmd.Parameters["@CapitaniaId"].Value = zarpeRetornoNaveExtranjeraDTO.CapitaniaId;

                cmd.Parameters.Add("@HoraCaptura", SqlDbType.Time);
                cmd.Parameters["@HoraCaptura"].Value = zarpeRetornoNaveExtranjeraDTO.HoraCaptura;

                cmd.Parameters.Add("@DiaCaptura", SqlDbType.Int);
                cmd.Parameters["@DiaCaptura"].Value = zarpeRetornoNaveExtranjeraDTO.DiaCaptura;

                cmd.Parameters.Add("@MesId", SqlDbType.Int);
                cmd.Parameters["@MesId"].Value = zarpeRetornoNaveExtranjeraDTO.MesId;

                cmd.Parameters.Add("@AnioCaptura", SqlDbType.Int);
                cmd.Parameters["@AnioCaptura"].Value = zarpeRetornoNaveExtranjeraDTO.AnioCaptura;

                cmd.Parameters.Add("@NombreNaveExtranjera", SqlDbType.VarChar, 150);
                cmd.Parameters["@NombreNaveExtranjera"].Value = zarpeRetornoNaveExtranjeraDTO.NombreNaveExtranjera;

                cmd.Parameters.Add("@MatriculaNaveExtranjera", SqlDbType.VarChar, 15);
                cmd.Parameters["@MatriculaNaveExtranjera"].Value = zarpeRetornoNaveExtranjeraDTO.MatriculaNaveExtranjera;

                cmd.Parameters.Add("@PaisUbigeoId", SqlDbType.Int);
                cmd.Parameters["@PaisUbigeoId"].Value = zarpeRetornoNaveExtranjeraDTO.PaisUbigeoId;

                cmd.Parameters.Add("@TipoNaveId", SqlDbType.Int);
                cmd.Parameters["@TipoNaveId"].Value = zarpeRetornoNaveExtranjeraDTO.TipoNaveId;

                cmd.Parameters.Add("@UnidadNavalId", SqlDbType.Int);
                cmd.Parameters["@UnidadNavalId"].Value = zarpeRetornoNaveExtranjeraDTO.UnidadNavalId;

                cmd.Parameters.Add("@CascoUnidadNaval", SqlDbType.Int);
                cmd.Parameters["@CascoUnidadNaval"].Value = zarpeRetornoNaveExtranjeraDTO.CascoUnidadNaval;

                cmd.Parameters.Add("@PuertoPeruId", SqlDbType.Int);
                cmd.Parameters["@PuertoPeruId"].Value = zarpeRetornoNaveExtranjeraDTO.PuertoPeruId;

                cmd.Parameters.Add("@AmbitoNaveId", SqlDbType.Int);
                cmd.Parameters["@AmbitoNaveId"].Value = zarpeRetornoNaveExtranjeraDTO.AmbitoNaveId;

                cmd.Parameters.Add("@HoraArribo", SqlDbType.Time);
                cmd.Parameters["@HoraArribo"].Value = zarpeRetornoNaveExtranjeraDTO.HoraArribo;

                cmd.Parameters.Add("@DiaArribo", SqlDbType.Int);
                cmd.Parameters["@DiaArribo"].Value = zarpeRetornoNaveExtranjeraDTO.DiaArribo;

                cmd.Parameters.Add("@MesArribo", SqlDbType.Int);
                cmd.Parameters["@MesArribo"].Value = zarpeRetornoNaveExtranjeraDTO.MesArribo;

                cmd.Parameters.Add("@AnioArribo", SqlDbType.Int);
                cmd.Parameters["@AnioArribo"].Value = zarpeRetornoNaveExtranjeraDTO.AnioArribo;

                cmd.Parameters.Add("@PuertoDestino", SqlDbType.VarChar, 50);
                cmd.Parameters["@PuertoDestino"].Value = zarpeRetornoNaveExtranjeraDTO.PuertoDestino;

                cmd.Parameters.Add("@PaisDestino", SqlDbType.Int);
                cmd.Parameters["@PaisDestino"].Value = zarpeRetornoNaveExtranjeraDTO.PaisDestino;

                cmd.Parameters.Add("@ETA", SqlDbType.VarChar, 100);
                cmd.Parameters["@ETA"].Value = zarpeRetornoNaveExtranjeraDTO.ETA;

                cmd.Parameters.Add("@Observaciones", SqlDbType.VarChar, 200);
                cmd.Parameters["@Observaciones"].Value = zarpeRetornoNaveExtranjeraDTO.Observaciones;


                cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                cmd.Parameters["@Usuario"].Value = zarpeRetornoNaveExtranjeraDTO.UsuarioIngresoRegistro;

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

    public bool EliminarFormato(ZarpeRetornoNaveExtranjeraDTO zarpeRetornoNaveExtranjeraDTO)
    {
        bool eliminado = false;
        var cn = new ConfiguracionConexion();

        try
        {
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_ZarpeRetornoNaveExtranjeraEliminar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@ZarpeRetornoNaveExtranjeraId", SqlDbType.Int);
                cmd.Parameters["@ZarpeRetornoNaveExtranjeraId"].Value = zarpeRetornoNaveExtranjeraDTO.ZarpeRetornoNaveExtranjeraId;

                cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                cmd.Parameters["@Usuario"].Value = zarpeRetornoNaveExtranjeraDTO.UsuarioIngresoRegistro;

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
    public bool InsercionMasiva(IEnumerable<ZarpeRetornoNaveExtranjeraDTO> zarpeRetornoNaveExtranjeraDTO)
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
                            foreach (var item in zarpeRetornoNaveExtranjeraDTO)
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
