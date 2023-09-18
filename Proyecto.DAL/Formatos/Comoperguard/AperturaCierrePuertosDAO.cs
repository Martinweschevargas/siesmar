using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comoperguard;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comoperguard
{
    public class AperturaCierrePuertosDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<AperturaCierrePuertosDTO> ObtenerLista()
        {
            List<AperturaCierrePuertosDTO> lista = new List<AperturaCierrePuertosDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_AperturaCierrePuertosListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new AperturaCierrePuertosDTO()
                        {
                            AperturaCierrePuertoId = Convert.ToInt32(dr["AperturaCierrePuertoId"]),
                            DescJefaturaDistritoCapitania = dr["DescJefaturaDistritoCapitania"].ToString(),
                            NombreCapitania = dr["NombreCapitania"].ToString(),
                            Condicion = dr["Condicion"].ToString(),
                            DescTipoPuertoPeru = dr["DescTipoPuertoPeru"].ToString(),
                            FechaInicio = (dr["FechaInicio"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            FechaTermino = (dr["FechaTermino"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            ResolucionCapitania = dr["ResolucionCapitania"].ToString(),
                            FechaResolucion = (dr["FechaResolucion"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            GFHMensajeNaval = dr["GFHMensajeNaval"].ToString(),


                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(AperturaCierrePuertosDTO aperturaCierrePuertosDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AperturaCierrePuertosRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@JefaturaDistritoCapitaniaId", SqlDbType.Int);
                    cmd.Parameters["@JefaturaDistritoCapitaniaId"].Value = aperturaCierrePuertosDTO.JefaturaDistritoCapitaniaId;

                    cmd.Parameters.Add("@CapitaniaId", SqlDbType.Int);
                    cmd.Parameters["@CapitaniaId"].Value = aperturaCierrePuertosDTO.CapitaniaId;

                    cmd.Parameters.Add("@Condicion", SqlDbType.VarChar,10);
                    cmd.Parameters["@Condicion"].Value = aperturaCierrePuertosDTO.Condicion;

                    cmd.Parameters.Add("@TipoPuertoPeruId", SqlDbType.Int);
                    cmd.Parameters["@TipoPuertoPeruId"].Value = aperturaCierrePuertosDTO.TipoPuertoPeruId;

                    cmd.Parameters.Add("@FechaInicio", SqlDbType.Date);
                    cmd.Parameters["@FechaInicio"].Value = aperturaCierrePuertosDTO.FechaInicio;

                    cmd.Parameters.Add("@FechaTermino", SqlDbType.Date);
                    cmd.Parameters["@FechaTermino"].Value = aperturaCierrePuertosDTO.FechaTermino;

                    cmd.Parameters.Add("@ResolucionCapitania", SqlDbType.VarChar, 10);
                    cmd.Parameters["@ResolucionCapitania"].Value = aperturaCierrePuertosDTO.ResolucionCapitania;

                    cmd.Parameters.Add("@FechaResolucion", SqlDbType.Date);
                    cmd.Parameters["@FechaResolucion"].Value = aperturaCierrePuertosDTO.FechaResolucion;

                    cmd.Parameters.Add("@GFHMensajeNaval", SqlDbType.VarChar, 10);
                    cmd.Parameters["@GFHMensajeNaval"].Value = aperturaCierrePuertosDTO.GFHMensajeNaval;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = aperturaCierrePuertosDTO.UsuarioIngresoRegistro;

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

        public AperturaCierrePuertosDTO BuscarFormato(int Codigo)
        {
            AperturaCierrePuertosDTO aperturaCierrePuertosDTO = new AperturaCierrePuertosDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AperturaCierrePuertosEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AperturaCierrePuertoId", SqlDbType.Int);
                    cmd.Parameters["@AperturaCierrePuertoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        aperturaCierrePuertosDTO.AperturaCierrePuertoId = Convert.ToInt32(dr["AperturaCierrePuertoId"]);
                        aperturaCierrePuertosDTO.JefaturaDistritoCapitaniaId = Convert.ToInt32(dr["JefaturaDistritoCapitaniaId"]);
                        aperturaCierrePuertosDTO.CapitaniaId = Convert.ToInt32(dr["CapitaniaId"]);
                        aperturaCierrePuertosDTO.Condicion = dr["Condicion"].ToString();
                        aperturaCierrePuertosDTO.TipoPuertoPeruId = Convert.ToInt32(dr["TipoPuertoPeruId"]);
                        aperturaCierrePuertosDTO.FechaInicio = Convert.ToDateTime(dr["FechaInicio"]).ToString("yyy-MM-dd");
                        aperturaCierrePuertosDTO.FechaTermino = Convert.ToDateTime(dr["FechaTermino"]).ToString("yyy-MM-dd");
                        aperturaCierrePuertosDTO.ResolucionCapitania = dr["ResolucionCapitania"].ToString();
                        aperturaCierrePuertosDTO.FechaResolucion = Convert.ToDateTime(dr["FechaResolucion"]).ToString("yyy-MM-dd");
                        aperturaCierrePuertosDTO.GFHMensajeNaval = dr["GFHMensajeNaval"].ToString(); 
 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return aperturaCierrePuertosDTO;
        }

        public string ActualizaFormato(AperturaCierrePuertosDTO aperturaCierrePuertosDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_AperturaCierrePuertosActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@AperturaCierrePuertoId", SqlDbType.Int);
                    cmd.Parameters["@AperturaCierrePuertoId"].Value = aperturaCierrePuertosDTO.AperturaCierrePuertoId;

                    cmd.Parameters.Add("@JefaturaDistritoCapitaniaId", SqlDbType.Int);
                    cmd.Parameters["@JefaturaDistritoCapitaniaId"].Value = aperturaCierrePuertosDTO.JefaturaDistritoCapitaniaId;

                    cmd.Parameters.Add("@CapitaniaId", SqlDbType.Int);
                    cmd.Parameters["@CapitaniaId"].Value = aperturaCierrePuertosDTO.CapitaniaId;

                    cmd.Parameters.Add("@Condicion", SqlDbType.VarChar, 10);
                    cmd.Parameters["@Condicion"].Value = aperturaCierrePuertosDTO.Condicion;

                    cmd.Parameters.Add("@TipoPuertoPeruId", SqlDbType.Int);
                    cmd.Parameters["@TipoPuertoPeruId"].Value = aperturaCierrePuertosDTO.TipoPuertoPeruId;

                    cmd.Parameters.Add("@FechaInicio", SqlDbType.Date);
                    cmd.Parameters["@FechaInicio"].Value = aperturaCierrePuertosDTO.FechaInicio;

                    cmd.Parameters.Add("@FechaTermino", SqlDbType.Date);
                    cmd.Parameters["@FechaTermino"].Value = aperturaCierrePuertosDTO.FechaTermino;

                    cmd.Parameters.Add("@ResolucionCapitania", SqlDbType.VarChar, 10);
                    cmd.Parameters["@ResolucionCapitania"].Value = aperturaCierrePuertosDTO.ResolucionCapitania;

                    cmd.Parameters.Add("@FechaResolucion", SqlDbType.Date);
                    cmd.Parameters["@FechaResolucion"].Value = aperturaCierrePuertosDTO.FechaResolucion;

                    cmd.Parameters.Add("@GFHMensajeNaval", SqlDbType.VarChar, 10);
                    cmd.Parameters["@GFHMensajeNaval"].Value = aperturaCierrePuertosDTO.GFHMensajeNaval;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = aperturaCierrePuertosDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(AperturaCierrePuertosDTO aperturaCierrePuertosDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AperturaCierrePuertosEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AperturaCierrePuertoId", SqlDbType.Int);
                    cmd.Parameters["@AperturaCierrePuertoId"].Value = aperturaCierrePuertosDTO.AperturaCierrePuertoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = aperturaCierrePuertosDTO.UsuarioIngresoRegistro;

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
        public bool InsercionMasiva(IEnumerable<AperturaCierrePuertosDTO> aperturaCierrePuertosDTO)
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
                            foreach (var item in aperturaCierrePuertosDTO)
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
