using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comoperguard;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comoperguard
{
    public class ZarpeRetornoNavePeruanaDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<ZarpeRetornoNavePeruanaDTO> ObtenerLista()
        {
            List<ZarpeRetornoNavePeruanaDTO> lista = new List<ZarpeRetornoNavePeruanaDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_ZarpeRetornoNavePeruanaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ZarpeRetornoNavePeruanaDTO()
                        {
                            ZarpeRetornoNavePeruanaId = Convert.ToInt32(dr["ZarpeRetornoNavePeruanaId"]),
                            Numero = Convert.ToInt32(dr["Numero"]),
                            DescJefaturaDistritoCapitania = dr["DescJefaturaDistritoCapitania"].ToString(),
                            HoraCaptura = dr["HoraCaptura"].ToString(),
                            DiaCaptura = Convert.ToInt32(dr["DiaCaptura"]),
                            DescMes = dr["DescMes"].ToString(),
                            AnioCaptura = Convert.ToInt32(dr["AnioCaptura"]),
                            NombreNavePeruana = dr["NombreNavePeruana"].ToString(),
                            MatriculaNavePeruana = dr["MatriculaNavePeruana"].ToString(),
                            DescTipoNave = dr["DescTipoNave"].ToString(),
                            DescAutoridadEmiteZarpe = dr["DescAutoridadEmiteZarpe"].ToString(),
                            HoraArribo = dr["HoraArribo"].ToString(),
                            DiaArribo = Convert.ToInt32(dr["DiaArribo"]),
                            DescMesArribo = dr["DescMesArribo"].ToString(),
                            AnioArribo = Convert.ToInt32(dr["AnioArribo"]),
                            DescPuertoPeru = dr["DescPuertoPeru"].ToString(),
                            DescJefaturaCapitania = dr["DescJefaturaCapitania"].ToString(),
                            Observaciones = dr["Observaciones"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(ZarpeRetornoNavePeruanaDTO zarpeRetornoNavePeruanaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ZarpeRetornoNavePeruanaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Numero", SqlDbType.Int);
                    cmd.Parameters["@Numero"].Value = zarpeRetornoNavePeruanaDTO.Numero;

                    cmd.Parameters.Add("@JefaturaDistritoCapitaniaId", SqlDbType.Int);
                    cmd.Parameters["@JefaturaDistritoCapitaniaId"].Value = zarpeRetornoNavePeruanaDTO.JefaturaDistritoCapitaniaId;

                    cmd.Parameters.Add("@HoraCaptura", SqlDbType.Time);
                    cmd.Parameters["@HoraCaptura"].Value = zarpeRetornoNavePeruanaDTO.HoraCaptura;

                    cmd.Parameters.Add("@DiaCaptura", SqlDbType.Int);
                    cmd.Parameters["@DiaCaptura"].Value = zarpeRetornoNavePeruanaDTO.DiaCaptura;

                    cmd.Parameters.Add("@MesId", SqlDbType.Int);
                    cmd.Parameters["@MesId"].Value = zarpeRetornoNavePeruanaDTO.MesId;

                    cmd.Parameters.Add("@AnioCaptura", SqlDbType.Int);
                    cmd.Parameters["@AnioCaptura"].Value = zarpeRetornoNavePeruanaDTO.AnioCaptura;

                    cmd.Parameters.Add("@NombreNavePeruana", SqlDbType.VarChar,150);
                    cmd.Parameters["@NombreNavePeruana"].Value = zarpeRetornoNavePeruanaDTO.NombreNavePeruana;

                    cmd.Parameters.Add("@MatriculaNavePeruana", SqlDbType.VarChar,150);
                    cmd.Parameters["@MatriculaNavePeruana"].Value = zarpeRetornoNavePeruanaDTO.MatriculaNavePeruana;

                    cmd.Parameters.Add("@TipoNaveId", SqlDbType.Int);
                    cmd.Parameters["@TipoNaveId"].Value = zarpeRetornoNavePeruanaDTO.TipoNaveId;

                    cmd.Parameters.Add("@AutoridadEmiteZarpeId", SqlDbType.Int);
                    cmd.Parameters["@AutoridadEmiteZarpeId"].Value = zarpeRetornoNavePeruanaDTO.AutoridadEmiteZarpeId;

                    cmd.Parameters.Add("@HoraArribo", SqlDbType.Time);
                    cmd.Parameters["@HoraArribo"].Value = zarpeRetornoNavePeruanaDTO.HoraArribo;

                    cmd.Parameters.Add("@DiaArribo", SqlDbType.Int);
                    cmd.Parameters["@DiaArribo"].Value = zarpeRetornoNavePeruanaDTO.DiaArribo;

                    cmd.Parameters.Add("@MesArribo", SqlDbType.Int);
                    cmd.Parameters["@MesArribo"].Value = zarpeRetornoNavePeruanaDTO.MesArribo;

                    cmd.Parameters.Add("@AnioArribo", SqlDbType.Int);
                    cmd.Parameters["@AnioArribo"].Value = zarpeRetornoNavePeruanaDTO.AnioArribo;

                    cmd.Parameters.Add("@PuertoPeruId", SqlDbType.Int);
                    cmd.Parameters["@PuertoPeruId"].Value = zarpeRetornoNavePeruanaDTO.PuertoPeruId;

                    cmd.Parameters.Add("@JefaturaCapitaniaId", SqlDbType.Int);
                    cmd.Parameters["@JefaturaCapitaniaId"].Value = zarpeRetornoNavePeruanaDTO.JefaturaCapitaniaId;

                    cmd.Parameters.Add("@Observaciones", SqlDbType.VarChar,200);
                    cmd.Parameters["@Observaciones"].Value = zarpeRetornoNavePeruanaDTO.Observaciones;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = zarpeRetornoNavePeruanaDTO.UsuarioIngresoRegistro;

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

        public ZarpeRetornoNavePeruanaDTO BuscarFormato(int Codigo)
        {
            ZarpeRetornoNavePeruanaDTO zarpeRetornoNavePeruanaDTO = new ZarpeRetornoNavePeruanaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ZarpeRetornoNavePeruanaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ZarpeRetornoNavePeruanaId", SqlDbType.Int);
                    cmd.Parameters["@ZarpeRetornoNavePeruanaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        zarpeRetornoNavePeruanaDTO.ZarpeRetornoNavePeruanaId = Convert.ToInt32(dr["ZarpeRetornoNavePeruanaId"]);
                        zarpeRetornoNavePeruanaDTO.Numero = Convert.ToInt32(dr["Numero"]);
                        zarpeRetornoNavePeruanaDTO.JefaturaDistritoCapitaniaId = Convert.ToInt32(dr["JefaturaDistritoCapitaniaId"]);
                        zarpeRetornoNavePeruanaDTO.HoraCaptura = dr["HoraCaptura"].ToString();
                        zarpeRetornoNavePeruanaDTO.DiaCaptura = Convert.ToInt32(dr["DiaCaptura"]);
                        zarpeRetornoNavePeruanaDTO.MesId = Convert.ToInt32(dr["MesId"]);
                        zarpeRetornoNavePeruanaDTO.AnioCaptura = Convert.ToInt32(dr["AnioCaptura"]);
                        zarpeRetornoNavePeruanaDTO.NombreNavePeruana = dr["NombreNavePeruana"].ToString();
                        zarpeRetornoNavePeruanaDTO.MatriculaNavePeruana = dr["MatriculaNavePeruana"].ToString();
                        zarpeRetornoNavePeruanaDTO.TipoNaveId = Convert.ToInt32(dr["TipoNaveId"]);
                        zarpeRetornoNavePeruanaDTO.AutoridadEmiteZarpeId = Convert.ToInt32(dr["AutoridadEmiteZarpeId"]);
                        zarpeRetornoNavePeruanaDTO.HoraArribo = dr["HoraArribo"].ToString();
                        zarpeRetornoNavePeruanaDTO.DiaArribo = Convert.ToInt32(dr["DiaArribo"]);
                        zarpeRetornoNavePeruanaDTO.MesArribo = Convert.ToInt32(dr["MesArribo"]);
                        zarpeRetornoNavePeruanaDTO.AnioArribo = Convert.ToInt32(dr["AnioArribo"]);
                        zarpeRetornoNavePeruanaDTO.PuertoPeruId = Convert.ToInt32(dr["PuertoPeruId"]);
                        zarpeRetornoNavePeruanaDTO.JefaturaCapitaniaId = Convert.ToInt32(dr["JefaturaCapitaniaId"]);
                        zarpeRetornoNavePeruanaDTO.Observaciones = dr["Observaciones"].ToString(); 
 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return zarpeRetornoNavePeruanaDTO;
        }

        public string ActualizaFormato(ZarpeRetornoNavePeruanaDTO zarpeRetornoNavePeruanaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_ZarpeRetornoNavePeruanaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@ZarpeRetornoNavePeruanaId", SqlDbType.Int);
                    cmd.Parameters["@ZarpeRetornoNavePeruanaId"].Value = zarpeRetornoNavePeruanaDTO.ZarpeRetornoNavePeruanaId;

                    cmd.Parameters.Add("@Numero", SqlDbType.Int);
                    cmd.Parameters["@Numero"].Value = zarpeRetornoNavePeruanaDTO.Numero;

                    cmd.Parameters.Add("@JefaturaDistritoCapitaniaId", SqlDbType.Int);
                    cmd.Parameters["@JefaturaDistritoCapitaniaId"].Value = zarpeRetornoNavePeruanaDTO.JefaturaDistritoCapitaniaId;

                    cmd.Parameters.Add("@HoraCaptura", SqlDbType.Time);
                    cmd.Parameters["@HoraCaptura"].Value = zarpeRetornoNavePeruanaDTO.HoraCaptura;

                    cmd.Parameters.Add("@DiaCaptura", SqlDbType.Int);
                    cmd.Parameters["@DiaCaptura"].Value = zarpeRetornoNavePeruanaDTO.DiaCaptura;

                    cmd.Parameters.Add("@MesId", SqlDbType.Int);
                    cmd.Parameters["@MesId"].Value = zarpeRetornoNavePeruanaDTO.MesId;

                    cmd.Parameters.Add("@AnioCaptura", SqlDbType.Int);
                    cmd.Parameters["@AnioCaptura"].Value = zarpeRetornoNavePeruanaDTO.AnioCaptura;

                    cmd.Parameters.Add("@NombreNavePeruana", SqlDbType.VarChar, 150);
                    cmd.Parameters["@NombreNavePeruana"].Value = zarpeRetornoNavePeruanaDTO.NombreNavePeruana;

                    cmd.Parameters.Add("@MatriculaNavePeruana", SqlDbType.VarChar, 150);
                    cmd.Parameters["@MatriculaNavePeruana"].Value = zarpeRetornoNavePeruanaDTO.MatriculaNavePeruana;

                    cmd.Parameters.Add("@TipoNaveId", SqlDbType.Int);
                    cmd.Parameters["@TipoNaveId"].Value = zarpeRetornoNavePeruanaDTO.TipoNaveId;

                    cmd.Parameters.Add("@AutoridadEmiteZarpeId", SqlDbType.Int);
                    cmd.Parameters["@AutoridadEmiteZarpeId"].Value = zarpeRetornoNavePeruanaDTO.AutoridadEmiteZarpeId;

                    cmd.Parameters.Add("@HoraArribo", SqlDbType.Time);
                    cmd.Parameters["@HoraArribo"].Value = zarpeRetornoNavePeruanaDTO.HoraArribo;

                    cmd.Parameters.Add("@DiaArribo", SqlDbType.Int);
                    cmd.Parameters["@DiaArribo"].Value = zarpeRetornoNavePeruanaDTO.DiaArribo;

                    cmd.Parameters.Add("@MesArribo", SqlDbType.Int);
                    cmd.Parameters["@MesArribo"].Value = zarpeRetornoNavePeruanaDTO.MesArribo;

                    cmd.Parameters.Add("@AnioArribo", SqlDbType.Int);
                    cmd.Parameters["@AnioArribo"].Value = zarpeRetornoNavePeruanaDTO.AnioArribo;

                    cmd.Parameters.Add("@PuertoPeruId", SqlDbType.Int);
                    cmd.Parameters["@PuertoPeruId"].Value = zarpeRetornoNavePeruanaDTO.PuertoPeruId;

                    cmd.Parameters.Add("@JefaturaCapitaniaId", SqlDbType.Int);
                    cmd.Parameters["@JefaturaCapitaniaId"].Value = zarpeRetornoNavePeruanaDTO.JefaturaCapitaniaId;

                    cmd.Parameters.Add("@Observaciones", SqlDbType.VarChar, 200);
                    cmd.Parameters["@Observaciones"].Value = zarpeRetornoNavePeruanaDTO.Observaciones;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = zarpeRetornoNavePeruanaDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(ZarpeRetornoNavePeruanaDTO zarpeRetornoNavePeruanaDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ZarpeRetornoNavePeruanaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ZarpeRetornoNavePeruanaId", SqlDbType.Int);
                    cmd.Parameters["@ZarpeRetornoNavePeruanaId"].Value = zarpeRetornoNavePeruanaDTO.ZarpeRetornoNavePeruanaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = zarpeRetornoNavePeruanaDTO.UsuarioIngresoRegistro;

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
        public bool InsercionMasiva(IEnumerable<ZarpeRetornoNavePeruanaDTO> zarpeRetornoNavePeruanaDTO)
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
                            foreach (var item in zarpeRetornoNavePeruanaDTO)
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
