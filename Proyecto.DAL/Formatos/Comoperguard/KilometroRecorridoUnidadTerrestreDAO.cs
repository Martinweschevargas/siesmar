using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comoperguard;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comoperguard
{
    public class KilometroRecorridoUnidadTerrestreDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<KilometroRecorridoUnidadTerrestreDTO> ObtenerLista()
        {
            List<KilometroRecorridoUnidadTerrestreDTO> lista = new List<KilometroRecorridoUnidadTerrestreDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_KilometroRecorridoUnidadTerrestreListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new KilometroRecorridoUnidadTerrestreDTO()
                        {
                            KilometroRecorridoUnidadTerrestreId = Convert.ToInt32(dr["KilometroRecorridoUnidadTerrestreId"]),
                            DescJefaturaDistritoCapitania = dr["DescJefaturaDistritoCapitania"].ToString(),
                            NombreCapitania = dr["NombreCapitania"].ToString(),
                            DescTipoVehiculoMovil = dr["DescTipoVehiculoMovil"].ToString(),
                            DescMarcaVehiculo = dr["DescMarcaVehiculo"].ToString(),
                            DescUnidadMovilTerrestre = dr["DescUnidadMovilTerrestre"].ToString(),
                            KmRecorridos = Convert.ToInt32(dr["KmRecorridos"]),
                            CombustibleConsumido = Convert.ToInt32(dr["CombustibleConsumido"]),
                            FechaInicio = (dr["FechaInicio"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            FechaTermino = (dr["FechaTermino"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            Observaciones = dr["Observaciones"].ToString(),

                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(KilometroRecorridoUnidadTerrestreDTO kilometroRecorridoUnidadTerrestreDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_KilometroRecorridoUnidadTerrestreRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@JefaturaDistritoCapitaniaId", SqlDbType.Int);
                    cmd.Parameters["@JefaturaDistritoCapitaniaId"].Value = kilometroRecorridoUnidadTerrestreDTO.JefaturaDistritoCapitaniaId;

                    cmd.Parameters.Add("@CapitaniaId", SqlDbType.Int);
                    cmd.Parameters["@CapitaniaId"].Value = kilometroRecorridoUnidadTerrestreDTO.CapitaniaId;

                    cmd.Parameters.Add("@TipoVehiculoMovilId", SqlDbType.Int);
                    cmd.Parameters["@TipoVehiculoMovilId"].Value = kilometroRecorridoUnidadTerrestreDTO.TipoVehiculoMovilId;

                    cmd.Parameters.Add("@MarcaVehiculoId", SqlDbType.Int);
                    cmd.Parameters["@MarcaVehiculoId"].Value = kilometroRecorridoUnidadTerrestreDTO.MarcaVehiculoId;

                    cmd.Parameters.Add("@UnidadMovilTerrestreId", SqlDbType.Int);
                    cmd.Parameters["@UnidadMovilTerrestreId"].Value = kilometroRecorridoUnidadTerrestreDTO.UnidadMovilTerrestreId;

                    cmd.Parameters.Add("@KmRecorridos", SqlDbType.Int);
                    cmd.Parameters["@KmRecorridos"].Value = kilometroRecorridoUnidadTerrestreDTO.KmRecorridos;

                    cmd.Parameters.Add("@CombustibleConsumido", SqlDbType.Int);
                    cmd.Parameters["@CombustibleConsumido"].Value = kilometroRecorridoUnidadTerrestreDTO.CombustibleConsumido;

                    cmd.Parameters.Add("@FechaInicio", SqlDbType.Date);
                    cmd.Parameters["@FechaInicio"].Value = kilometroRecorridoUnidadTerrestreDTO.FechaInicio;

                    cmd.Parameters.Add("@FechaTermino", SqlDbType.Date);
                    cmd.Parameters["@FechaTermino"].Value = kilometroRecorridoUnidadTerrestreDTO.FechaTermino;

                    cmd.Parameters.Add("@Observaciones", SqlDbType.VarChar,200);
                    cmd.Parameters["@Observaciones"].Value = kilometroRecorridoUnidadTerrestreDTO.Observaciones;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = kilometroRecorridoUnidadTerrestreDTO.UsuarioIngresoRegistro;

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

        public KilometroRecorridoUnidadTerrestreDTO BuscarFormato(int Codigo)
        {
            KilometroRecorridoUnidadTerrestreDTO kilometroRecorridoUnidadTerrestreDTO = new KilometroRecorridoUnidadTerrestreDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_KilometroRecorridoUnidadTerrestreEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@KilometroRecorridoUnidadTerrestreId", SqlDbType.Int);
                    cmd.Parameters["@KilometroRecorridoUnidadTerrestreId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        kilometroRecorridoUnidadTerrestreDTO.KilometroRecorridoUnidadTerrestreId = Convert.ToInt32(dr["KilometroRecorridoUnidadTerrestreId"]);
                        kilometroRecorridoUnidadTerrestreDTO.JefaturaDistritoCapitaniaId = Convert.ToInt32(dr["JefaturaDistritoCapitaniaId"]);
                        kilometroRecorridoUnidadTerrestreDTO.CapitaniaId = Convert.ToInt32(dr["CapitaniaId"]);
                        kilometroRecorridoUnidadTerrestreDTO.TipoVehiculoMovilId = Convert.ToInt32(dr["TipoVehiculoMovilId"]);
                        kilometroRecorridoUnidadTerrestreDTO.MarcaVehiculoId = Convert.ToInt32(dr["MarcaVehiculoId"]);
                        kilometroRecorridoUnidadTerrestreDTO.UnidadMovilTerrestreId = Convert.ToInt32(dr["UnidadMovilTerrestreId"]);
                        kilometroRecorridoUnidadTerrestreDTO.KmRecorridos = Convert.ToInt32(dr["KmRecorridos"]);
                        kilometroRecorridoUnidadTerrestreDTO.CombustibleConsumido = Convert.ToInt32(dr["CombustibleConsumido"]);
                        kilometroRecorridoUnidadTerrestreDTO.FechaInicio = Convert.ToDateTime(dr["FechaInicio"]).ToString("yyy-MM-dd");
                        kilometroRecorridoUnidadTerrestreDTO.FechaTermino = Convert.ToDateTime(dr["FechaTermino"]).ToString("yyy-MM-dd");
                        kilometroRecorridoUnidadTerrestreDTO.Observaciones = dr["Observaciones"].ToString(); 
 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return kilometroRecorridoUnidadTerrestreDTO;
        }

        public string ActualizaFormato(KilometroRecorridoUnidadTerrestreDTO kilometroRecorridoUnidadTerrestreDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_KilometroRecorridoUnidadTerrestreActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@KilometroRecorridoUnidadTerrestreId", SqlDbType.Int);
                    cmd.Parameters["@KilometroRecorridoUnidadTerrestreId"].Value = kilometroRecorridoUnidadTerrestreDTO.KilometroRecorridoUnidadTerrestreId;

                    cmd.Parameters.Add("@JefaturaDistritoCapitaniaId", SqlDbType.Int);
                    cmd.Parameters["@JefaturaDistritoCapitaniaId"].Value = kilometroRecorridoUnidadTerrestreDTO.JefaturaDistritoCapitaniaId;

                    cmd.Parameters.Add("@CapitaniaId", SqlDbType.Int);
                    cmd.Parameters["@CapitaniaId"].Value = kilometroRecorridoUnidadTerrestreDTO.CapitaniaId;

                    cmd.Parameters.Add("@TipoVehiculoMovilId", SqlDbType.Int);
                    cmd.Parameters["@TipoVehiculoMovilId"].Value = kilometroRecorridoUnidadTerrestreDTO.TipoVehiculoMovilId;

                    cmd.Parameters.Add("@MarcaVehiculoId", SqlDbType.Int);
                    cmd.Parameters["@MarcaVehiculoId"].Value = kilometroRecorridoUnidadTerrestreDTO.MarcaVehiculoId;

                    cmd.Parameters.Add("@UnidadMovilTerrestreId", SqlDbType.Int);
                    cmd.Parameters["@UnidadMovilTerrestreId"].Value = kilometroRecorridoUnidadTerrestreDTO.UnidadMovilTerrestreId;

                    cmd.Parameters.Add("@KmRecorridos", SqlDbType.Int);
                    cmd.Parameters["@KmRecorridos"].Value = kilometroRecorridoUnidadTerrestreDTO.KmRecorridos;

                    cmd.Parameters.Add("@CombustibleConsumido", SqlDbType.Int);
                    cmd.Parameters["@CombustibleConsumido"].Value = kilometroRecorridoUnidadTerrestreDTO.CombustibleConsumido;

                    cmd.Parameters.Add("@FechaInicio", SqlDbType.Date);
                    cmd.Parameters["@FechaInicio"].Value = kilometroRecorridoUnidadTerrestreDTO.FechaInicio;

                    cmd.Parameters.Add("@FechaTermino", SqlDbType.Date);
                    cmd.Parameters["@FechaTermino"].Value = kilometroRecorridoUnidadTerrestreDTO.FechaTermino;

                    cmd.Parameters.Add("@Observaciones", SqlDbType.VarChar,200);
                    cmd.Parameters["@Observaciones"].Value = kilometroRecorridoUnidadTerrestreDTO.Observaciones;


                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = kilometroRecorridoUnidadTerrestreDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(KilometroRecorridoUnidadTerrestreDTO kilometroRecorridoUnidadTerrestreDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_KilometroRecorridoUnidadTerrestreEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@KilometroRecorridoUnidadTerrestreId", SqlDbType.Int);
                    cmd.Parameters["@KilometroRecorridoUnidadTerrestreId"].Value = kilometroRecorridoUnidadTerrestreDTO.KilometroRecorridoUnidadTerrestreId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = kilometroRecorridoUnidadTerrestreDTO.UsuarioIngresoRegistro;

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
        public bool InsercionMasiva(IEnumerable<KilometroRecorridoUnidadTerrestreDTO> kilometroRecorridoUnidadTerrestreDTO)
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
                            foreach (var item in kilometroRecorridoUnidadTerrestreDTO)
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
