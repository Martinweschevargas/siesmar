using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comoperguard;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comoperguard
{
    public class OperacionesBusquedasSalvamentoDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<OperacionesBusquedasSalvamentoDTO> ObtenerLista()
        {
            List<OperacionesBusquedasSalvamentoDTO> lista = new List<OperacionesBusquedasSalvamentoDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_OperacionesBusquedasSalvamentoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new OperacionesBusquedasSalvamentoDTO()
                        {
                            OperacionBusquedaSalvamentoId = Convert.ToInt32(dr["OperacionBusquedaSalvamentoId"]),
                            DescJefaturaDistritoCapitania = dr["DescJefaturaDistritoCapitania"].ToString(),
                            NombreCapitania = dr["NombreCapitania"].ToString(),
                            HoraSiniestro = dr["HoraSiniestro"].ToString(),
                            FechaSiniestro = (dr["FechaSiniestro"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            DescTipoSiniestro = dr["DescTipoSiniestro"].ToString(),
                            MensajeActivacionRSC = dr["MensajeActivacionRSC"].ToString(),
                            MensajeDesactivacionRSC = dr["MensajeDesactivacionRSC"].ToString(),
                            NombreNaveSiniestrada = dr["NombreNaveSiniestrada"].ToString(),
                            MatriculaNaveSiniestrada = dr["MatriculaNaveSiniestrada"].ToString(),
                            ABEdad = Convert.ToInt32(dr["ABEdad"]),
                            NombrePais = dr["NombrePais"].ToString(),
                            PersonasRescatadasVida = Convert.ToInt32(dr["PersonasRescatadasVida"]),
                            PersonasFallecidas = Convert.ToInt32(dr["PersonasFallecidas"]),
                            PersonasDesaparecidas = Convert.ToInt32(dr["PersonasDesaparecidas"]),
                            PersonasEvacuadas = Convert.ToInt32(dr["PersonasEvacuadas"]),
                            LatitudUbicacionNave = dr["LatitudUbicacionNave"].ToString(),
                            LongitudUbicacionNave = dr["LongitudUbicacionNave"].ToString(),
                            ZonaSiniestro = dr["ZonaSiniestro"].ToString(),
                            DescDistrito = dr["DescDistrito"].ToString(),
                            DescProvincia = dr["DescProvincia"].ToString(),
                            DescDepartamento = dr["DescDepartamento"].ToString(),
                            DescAmbitoNave = dr["DescAmbitoNave"].ToString(),
                            DescUnidadNaval = dr["DescUnidadNaval"].ToString(),
                            DescTipoVehiculoMovil = dr["DescTipoVehiculoMovil"].ToString(),
                            DescMarcaVehiculo = dr["DescMarcaVehiculo"].ToString(),
                            Millas = Convert.ToInt32(dr["Millas"]),
                            Kilometro = Convert.ToInt32(dr["Kilometro"]),
                            Galones = Convert.ToInt32(dr["Galones"]),
                            ResultadoTerminoOperaciones = dr["ResultadoTerminoOperaciones"].ToString(),
                            ObservacionesSiniestro = dr["ObservacionesSiniestro"].ToString(),

                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(OperacionesBusquedasSalvamentoDTO operacionesBusquedasSalvamentoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_OperacionesBusquedasSalvamentoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@JefaturaDistritoCapitaniaId", SqlDbType.Int);
                    cmd.Parameters["@JefaturaDistritoCapitaniaId"].Value = operacionesBusquedasSalvamentoDTO.JefaturaDistritoCapitaniaId;

                    cmd.Parameters.Add("@CapitaniaId", SqlDbType.Int);
                    cmd.Parameters["@CapitaniaId"].Value = operacionesBusquedasSalvamentoDTO.CapitaniaId;

                    cmd.Parameters.Add("@HoraSiniestro", SqlDbType.Time);
                    cmd.Parameters["@HoraSiniestro"].Value = operacionesBusquedasSalvamentoDTO.HoraSiniestro;

                    cmd.Parameters.Add("@FechaSiniestro", SqlDbType.Date);
                    cmd.Parameters["@FechaSiniestro"].Value = operacionesBusquedasSalvamentoDTO.FechaSiniestro;

                    cmd.Parameters.Add("@TipoSiniestroId", SqlDbType.Int);
                    cmd.Parameters["@TipoSiniestroId"].Value = operacionesBusquedasSalvamentoDTO.TipoSiniestroId;

                    cmd.Parameters.Add("@MensajeActivacionRSC", SqlDbType.VarChar,200);
                    cmd.Parameters["@MensajeActivacionRSC"].Value = operacionesBusquedasSalvamentoDTO.MensajeActivacionRSC;

                    cmd.Parameters.Add("@MensajeDesactivacionRSC", SqlDbType.VarChar,200);
                    cmd.Parameters["@MensajeDesactivacionRSC"].Value = operacionesBusquedasSalvamentoDTO.MensajeDesactivacionRSC;

                    cmd.Parameters.Add("@NombreNaveSiniestrada", SqlDbType.VarChar,150);
                    cmd.Parameters["@NombreNaveSiniestrada"].Value = operacionesBusquedasSalvamentoDTO.NombreNaveSiniestrada;

                    cmd.Parameters.Add("@MatriculaNaveSiniestrada", SqlDbType.VarChar,15);
                    cmd.Parameters["@MatriculaNaveSiniestrada"].Value = operacionesBusquedasSalvamentoDTO.MatriculaNaveSiniestrada;

                    cmd.Parameters.Add("@ABEdad", SqlDbType.Int);
                    cmd.Parameters["@ABEdad"].Value = operacionesBusquedasSalvamentoDTO.ABEdad;

                    cmd.Parameters.Add("@PaisUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@PaisUbigeoId"].Value = operacionesBusquedasSalvamentoDTO.PaisUbigeoId;

                    cmd.Parameters.Add("@PersonasRescatadasVida", SqlDbType.Int);
                    cmd.Parameters["@PersonasRescatadasVida"].Value = operacionesBusquedasSalvamentoDTO.PersonasRescatadasVida;

                    cmd.Parameters.Add("@PersonasFallecidas", SqlDbType.Int);
                    cmd.Parameters["@PersonasFallecidas"].Value = operacionesBusquedasSalvamentoDTO.PersonasFallecidas;

                    cmd.Parameters.Add("@PersonasDesaparecidas", SqlDbType.Int);
                    cmd.Parameters["@PersonasDesaparecidas"].Value = operacionesBusquedasSalvamentoDTO.PersonasDesaparecidas;

                    cmd.Parameters.Add("@PersonasEvacuadas", SqlDbType.Int);
                    cmd.Parameters["@PersonasEvacuadas"].Value = operacionesBusquedasSalvamentoDTO.PersonasEvacuadas;

                    cmd.Parameters.Add("@LatitudUbicacionNave", SqlDbType.VarChar,15);
                    cmd.Parameters["@LatitudUbicacionNave"].Value = operacionesBusquedasSalvamentoDTO.LatitudUbicacionNave;

                    cmd.Parameters.Add("@LongitudUbicacionNave", SqlDbType.VarChar,15);
                    cmd.Parameters["@LongitudUbicacionNave"].Value = operacionesBusquedasSalvamentoDTO.LongitudUbicacionNave;

                    cmd.Parameters.Add("@ZonaSiniestro", SqlDbType.VarChar,100);
                    cmd.Parameters["@ZonaSiniestro"].Value = operacionesBusquedasSalvamentoDTO.ZonaSiniestro;

                    cmd.Parameters.Add("@DistritoUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@DistritoUbigeoId"].Value = operacionesBusquedasSalvamentoDTO.DistritoUbigeoId;

                    cmd.Parameters.Add("@ProvinciaUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@ProvinciaUbigeoId"].Value = operacionesBusquedasSalvamentoDTO.ProvinciaUbigeoId;

                    cmd.Parameters.Add("@DepartamentoUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@DepartamentoUbigeoId"].Value = operacionesBusquedasSalvamentoDTO.DepartamentoUbigeoId;

                    cmd.Parameters.Add("@AmbitoNaveId", SqlDbType.Int);
                    cmd.Parameters["@AmbitoNaveId"].Value = operacionesBusquedasSalvamentoDTO.AmbitoNaveId;

                    cmd.Parameters.Add("@UnidadNavalId", SqlDbType.Int);
                    cmd.Parameters["@UnidadNavalId"].Value = operacionesBusquedasSalvamentoDTO.UnidadNavalId;

                    cmd.Parameters.Add("@TipoVehiculoMovilId", SqlDbType.Int);
                    cmd.Parameters["@TipoVehiculoMovilId"].Value = operacionesBusquedasSalvamentoDTO.TipoVehiculoMovilId;

                    cmd.Parameters.Add("@MarcaVehiculoId", SqlDbType.Int);
                    cmd.Parameters["@MarcaVehiculoId"].Value = operacionesBusquedasSalvamentoDTO.MarcaVehiculoId;

                    cmd.Parameters.Add("@Millas", SqlDbType.Int);
                    cmd.Parameters["@Millas"].Value = operacionesBusquedasSalvamentoDTO.Millas;

                    cmd.Parameters.Add("@Kilometro", SqlDbType.Int);
                    cmd.Parameters["@Kilometro"].Value = operacionesBusquedasSalvamentoDTO.Kilometro;

                    cmd.Parameters.Add("@Galones", SqlDbType.Int);
                    cmd.Parameters["@Galones"].Value = operacionesBusquedasSalvamentoDTO.Galones;

                    cmd.Parameters.Add("@ResultadoTerminoOperaciones", SqlDbType.VarChar,200);
                    cmd.Parameters["@ResultadoTerminoOperaciones"].Value = operacionesBusquedasSalvamentoDTO.ResultadoTerminoOperaciones;

                    cmd.Parameters.Add("@ObservacionesSiniestro", SqlDbType.VarChar,500);
                    cmd.Parameters["@ObservacionesSiniestro"].Value = operacionesBusquedasSalvamentoDTO.ObservacionesSiniestro;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = operacionesBusquedasSalvamentoDTO.UsuarioIngresoRegistro;

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

        public OperacionesBusquedasSalvamentoDTO BuscarFormato(int Codigo)
        {
            OperacionesBusquedasSalvamentoDTO operacionesBusquedasSalvamentoDTO = new OperacionesBusquedasSalvamentoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_OperacionesBusquedasSalvamentoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@OperacionesBusquedasSalvamentoId", SqlDbType.Int);
                    cmd.Parameters["@OperacionesBusquedasSalvamentoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        operacionesBusquedasSalvamentoDTO.OperacionBusquedaSalvamentoId = Convert.ToInt32(dr["OperacionBusquedaSalvamentoId"]);
                        operacionesBusquedasSalvamentoDTO.JefaturaDistritoCapitaniaId = Convert.ToInt32(dr["JefaturaDistritoCapitaniaId"]);
                        operacionesBusquedasSalvamentoDTO.CapitaniaId = Convert.ToInt32(dr["CapitaniaId"]);
                        operacionesBusquedasSalvamentoDTO.HoraSiniestro = dr["HoraSiniestro"].ToString();
                        operacionesBusquedasSalvamentoDTO.FechaSiniestro = Convert.ToDateTime(dr["FechaSiniestro"]).ToString("yyy-MM-dd");
                        operacionesBusquedasSalvamentoDTO.TipoSiniestroId = Convert.ToInt32(dr["TipoSiniestroId"]);
                        operacionesBusquedasSalvamentoDTO.MensajeActivacionRSC = dr["MensajeActivacionRSC"].ToString();
                        operacionesBusquedasSalvamentoDTO.MensajeDesactivacionRSC = dr["MensajeDesactivacionRSC"].ToString();
                        operacionesBusquedasSalvamentoDTO.NombreNaveSiniestrada = dr["NombreNaveSiniestrada"].ToString();
                        operacionesBusquedasSalvamentoDTO.MatriculaNaveSiniestrada = dr["MatriculaNaveSiniestrada"].ToString();
                        operacionesBusquedasSalvamentoDTO.ABEdad = Convert.ToInt32(dr["ABEdad"]);
                        operacionesBusquedasSalvamentoDTO.PaisUbigeoId = Convert.ToInt32(dr["PaisUbigeoId"]);
                        operacionesBusquedasSalvamentoDTO.PersonasRescatadasVida = Convert.ToInt32(dr["PersonasRescatadasVida"]);
                        operacionesBusquedasSalvamentoDTO.PersonasFallecidas = Convert.ToInt32(dr["PersonasFallecidas"]);
                        operacionesBusquedasSalvamentoDTO.PersonasDesaparecidas = Convert.ToInt32(dr["PersonasDesaparecidas"]);
                        operacionesBusquedasSalvamentoDTO.PersonasEvacuadas = Convert.ToInt32(dr["PersonasEvacuadas"]);
                        operacionesBusquedasSalvamentoDTO.LatitudUbicacionNave = dr["LatitudUbicacionNave"].ToString();
                        operacionesBusquedasSalvamentoDTO.LongitudUbicacionNave = dr["LongitudUbicacionNave"].ToString();
                        operacionesBusquedasSalvamentoDTO.ZonaSiniestro = dr["ZonaSiniestro"].ToString();
                        operacionesBusquedasSalvamentoDTO.DistritoUbigeoId = Convert.ToInt32(dr["DistritoUbigeoId"]);
                        operacionesBusquedasSalvamentoDTO.ProvinciaUbigeoId = Convert.ToInt32(dr["ProvinciaUbigeoId"]);
                        operacionesBusquedasSalvamentoDTO.DepartamentoUbigeoId = Convert.ToInt32(dr["DepartamentoUbigeoId"]);
                        operacionesBusquedasSalvamentoDTO.AmbitoNaveId = Convert.ToInt32(dr["AmbitoNaveId"]);
                        operacionesBusquedasSalvamentoDTO.UnidadNavalId = Convert.ToInt32(dr["UnidadNavalId"]);
                        operacionesBusquedasSalvamentoDTO.TipoVehiculoMovilId = Convert.ToInt32(dr["TipoVehiculoMovilId"]);
                        operacionesBusquedasSalvamentoDTO.MarcaVehiculoId = Convert.ToInt32(dr["MarcaVehiculoId"]);
                        operacionesBusquedasSalvamentoDTO.Millas = Convert.ToInt32(dr["Millas"]);
                        operacionesBusquedasSalvamentoDTO.Kilometro = Convert.ToInt32(dr["Kilometro"]); 
 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return operacionesBusquedasSalvamentoDTO;
        }

        public string ActualizaFormato(OperacionesBusquedasSalvamentoDTO operacionesBusquedasSalvamentoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_OperacionesBusquedasSalvamentoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@OperacionBusquedaSalvamentoId", SqlDbType.Int);
                    cmd.Parameters["@OperacionBusquedaSalvamentoId"].Value = operacionesBusquedasSalvamentoDTO.OperacionBusquedaSalvamentoId;

                    cmd.Parameters.Add("@JefaturaDistritoCapitaniaId", SqlDbType.Int);
                    cmd.Parameters["@JefaturaDistritoCapitaniaId"].Value = operacionesBusquedasSalvamentoDTO.JefaturaDistritoCapitaniaId;

                    cmd.Parameters.Add("@CapitaniaId", SqlDbType.Int);
                    cmd.Parameters["@CapitaniaId"].Value = operacionesBusquedasSalvamentoDTO.CapitaniaId;

                    cmd.Parameters.Add("@HoraSiniestro", SqlDbType.Time);
                    cmd.Parameters["@HoraSiniestro"].Value = operacionesBusquedasSalvamentoDTO.HoraSiniestro;

                    cmd.Parameters.Add("@FechaSiniestro", SqlDbType.Date);
                    cmd.Parameters["@FechaSiniestro"].Value = operacionesBusquedasSalvamentoDTO.FechaSiniestro;

                    cmd.Parameters.Add("@TipoSiniestroId", SqlDbType.Int);
                    cmd.Parameters["@TipoSiniestroId"].Value = operacionesBusquedasSalvamentoDTO.TipoSiniestroId;

                    cmd.Parameters.Add("@MensajeActivacionRSC", SqlDbType.VarChar, 200);
                    cmd.Parameters["@MensajeActivacionRSC"].Value = operacionesBusquedasSalvamentoDTO.MensajeActivacionRSC;

                    cmd.Parameters.Add("@MensajeDesactivacionRSC", SqlDbType.VarChar, 200);
                    cmd.Parameters["@MensajeDesactivacionRSC"].Value = operacionesBusquedasSalvamentoDTO.MensajeDesactivacionRSC;

                    cmd.Parameters.Add("@NombreNaveSiniestrada", SqlDbType.VarChar, 150);
                    cmd.Parameters["@NombreNaveSiniestrada"].Value = operacionesBusquedasSalvamentoDTO.NombreNaveSiniestrada;

                    cmd.Parameters.Add("@MatriculaNaveSiniestrada", SqlDbType.VarChar, 15);
                    cmd.Parameters["@MatriculaNaveSiniestrada"].Value = operacionesBusquedasSalvamentoDTO.MatriculaNaveSiniestrada;

                    cmd.Parameters.Add("@ABEdad", SqlDbType.Int);
                    cmd.Parameters["@ABEdad"].Value = operacionesBusquedasSalvamentoDTO.ABEdad;

                    cmd.Parameters.Add("@PaisUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@PaisUbigeoId"].Value = operacionesBusquedasSalvamentoDTO.PaisUbigeoId;

                    cmd.Parameters.Add("@PersonasRescatadasVida", SqlDbType.Int);
                    cmd.Parameters["@PersonasRescatadasVida"].Value = operacionesBusquedasSalvamentoDTO.PersonasRescatadasVida;

                    cmd.Parameters.Add("@PersonasFallecidas", SqlDbType.Int);
                    cmd.Parameters["@PersonasFallecidas"].Value = operacionesBusquedasSalvamentoDTO.PersonasFallecidas;

                    cmd.Parameters.Add("@PersonasDesaparecidas", SqlDbType.Int);
                    cmd.Parameters["@PersonasDesaparecidas"].Value = operacionesBusquedasSalvamentoDTO.PersonasDesaparecidas;

                    cmd.Parameters.Add("@PersonasEvacuadas", SqlDbType.Int);
                    cmd.Parameters["@PersonasEvacuadas"].Value = operacionesBusquedasSalvamentoDTO.PersonasEvacuadas;

                    cmd.Parameters.Add("@LatitudUbicacionNave", SqlDbType.VarChar, 15);
                    cmd.Parameters["@LatitudUbicacionNave"].Value = operacionesBusquedasSalvamentoDTO.LatitudUbicacionNave;

                    cmd.Parameters.Add("@LongitudUbicacionNave", SqlDbType.VarChar, 15);
                    cmd.Parameters["@LongitudUbicacionNave"].Value = operacionesBusquedasSalvamentoDTO.LongitudUbicacionNave;

                    cmd.Parameters.Add("@ZonaSiniestro", SqlDbType.VarChar, 100);
                    cmd.Parameters["@ZonaSiniestro"].Value = operacionesBusquedasSalvamentoDTO.ZonaSiniestro;

                    cmd.Parameters.Add("@DistritoUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@DistritoUbigeoId"].Value = operacionesBusquedasSalvamentoDTO.DistritoUbigeoId;

                    cmd.Parameters.Add("@ProvinciaUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@ProvinciaUbigeoId"].Value = operacionesBusquedasSalvamentoDTO.ProvinciaUbigeoId;

                    cmd.Parameters.Add("@DepartamentoUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@DepartamentoUbigeoId"].Value = operacionesBusquedasSalvamentoDTO.DepartamentoUbigeoId;

                    cmd.Parameters.Add("@AmbitoNaveId", SqlDbType.Int);
                    cmd.Parameters["@AmbitoNaveId"].Value = operacionesBusquedasSalvamentoDTO.AmbitoNaveId;

                    cmd.Parameters.Add("@UnidadNavalId", SqlDbType.Int);
                    cmd.Parameters["@UnidadNavalId"].Value = operacionesBusquedasSalvamentoDTO.UnidadNavalId;

                    cmd.Parameters.Add("@TipoVehiculoMovilId", SqlDbType.Int);
                    cmd.Parameters["@TipoVehiculoMovilId"].Value = operacionesBusquedasSalvamentoDTO.TipoVehiculoMovilId;

                    cmd.Parameters.Add("@MarcaVehiculoId", SqlDbType.Int);
                    cmd.Parameters["@MarcaVehiculoId"].Value = operacionesBusquedasSalvamentoDTO.MarcaVehiculoId;

                    cmd.Parameters.Add("@Millas", SqlDbType.Int);
                    cmd.Parameters["@Millas"].Value = operacionesBusquedasSalvamentoDTO.Millas;

                    cmd.Parameters.Add("@Kilometro", SqlDbType.Int);
                    cmd.Parameters["@Kilometro"].Value = operacionesBusquedasSalvamentoDTO.Kilometro;

                    cmd.Parameters.Add("@Galones", SqlDbType.Int);
                    cmd.Parameters["@Galones"].Value = operacionesBusquedasSalvamentoDTO.Galones;

                    cmd.Parameters.Add("@ResultadoTerminoOperaciones", SqlDbType.VarChar, 200);
                    cmd.Parameters["@ResultadoTerminoOperaciones"].Value = operacionesBusquedasSalvamentoDTO.ResultadoTerminoOperaciones;

                    cmd.Parameters.Add("@ObservacionesSiniestro", SqlDbType.VarChar, 500);
                    cmd.Parameters["@ObservacionesSiniestro"].Value = operacionesBusquedasSalvamentoDTO.ObservacionesSiniestro;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = operacionesBusquedasSalvamentoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(OperacionesBusquedasSalvamentoDTO operacionesBusquedasSalvamentoDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_OperacionesBusquedasSalvamentoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@OperacionBusquedaSalvamentoId", SqlDbType.Int);
                    cmd.Parameters["@OperacionBusquedaSalvamentoId"].Value = operacionesBusquedasSalvamentoDTO.OperacionBusquedaSalvamentoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = operacionesBusquedasSalvamentoDTO.UsuarioIngresoRegistro;

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
        public bool InsercionMasiva(IEnumerable<OperacionesBusquedasSalvamentoDTO> operacionesBusquedasSalvamentoDTO)
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
                            foreach (var item in operacionesBusquedasSalvamentoDTO)
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
