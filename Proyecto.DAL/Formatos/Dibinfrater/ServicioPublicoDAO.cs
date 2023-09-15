using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Dibinfrater;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dibinfrater
{
    public class ServicioPublicoDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<ServicioPublicoDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<ServicioPublicoDTO> lista = new List<ServicioPublicoDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_ServicioPublicoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                cmd.Parameters.Add("@FechaInicio", SqlDbType.Date);
                cmd.Parameters["@FechaInicio"].Value = fechainicio;

                cmd.Parameters.Add("@FechaFin", SqlDbType.Date);
                cmd.Parameters["@FechaFin"].Value = fechafin;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ServicioPublicoDTO()
                        {
                            ServicioPublicoId = Convert.ToInt32(dr["ServicioPublicoId"]),
                            AnioPagoServicio = Convert.ToInt32(dr["AnioPagoServicio"]),
                            DescMes = dr["DescMes"].ToString(),
                            DescFuenteFinanciamiento = dr["DescFuenteFinanciamiento"].ToString(),
                            DescZonaNaval = dr["DescZonaNaval"].ToString(),
                            DescDependencia = dr["DescDependencia"].ToString(),
                            DescTipoServicioPublico = dr["DescTipoServicioPublico"].ToString(),
                            SuministroUnico = Convert.ToInt32(dr["SuministroUnico"]),
                            AsignacionMensual = Convert.ToDecimal(dr["AsignacionMensual"]),
                            ConsumoMensual = Convert.ToDecimal(dr["ConsumoMensual"]),
                            ConsumoUnidadMedida = dr["ConsumoUnidadMedida"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"])


                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(ServicioPublicoDTO servicioPublicoDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ServicioPublicoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AnioPagoServicio", SqlDbType.Int);
                    cmd.Parameters["@AnioPagoServicio"].Value = servicioPublicoDTO.AnioPagoServicio;

                    cmd.Parameters.Add("@NumeroMes", SqlDbType.VarChar, 20);
                    cmd.Parameters["@NumeroMes"].Value = servicioPublicoDTO.NumericoMes;

                    cmd.Parameters.Add("@CodigoFuenteFinanciamiento", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoFuenteFinanciamiento"].Value = servicioPublicoDTO.CodigoFuenteFinanciamiento;

                    cmd.Parameters.Add("@CodigoZonaNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoZonaNaval"].Value = servicioPublicoDTO.CodigoZonaNaval;

                    cmd.Parameters.Add("@CodigoDependenciasSuministro", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDependenciasSuministro"].Value = servicioPublicoDTO.CodigoDependencia;

                    cmd.Parameters.Add("@CodigoTipoServicioPublico", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoServicioPublico"].Value = servicioPublicoDTO.CodigoTipoServicioPublico;

                    cmd.Parameters.Add("@SuministroUnico", SqlDbType.Int);
                    cmd.Parameters["@SuministroUnico"].Value = servicioPublicoDTO.SuministroUnico;

                    cmd.Parameters.Add("@AsignacionMensual", SqlDbType.Decimal);
                    cmd.Parameters["@AsignacionMensual"].Value = servicioPublicoDTO.AsignacionMensual;

                    cmd.Parameters.Add("@ConsumoMensual", SqlDbType.Decimal);
                    cmd.Parameters["@ConsumoMensual"].Value = servicioPublicoDTO.ConsumoMensual;

                    cmd.Parameters.Add("@ConsumoUnidadMedida", SqlDbType.VarChar,10);
                    cmd.Parameters["@ConsumoUnidadMedida"].Value = servicioPublicoDTO.ConsumoUnidadMedida;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = servicioPublicoDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = servicioPublicoDTO.UsuarioIngresoRegistro;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Mac"].Value = UtilitariosGlobales.obtenerDireccionMac();

                    cmd.Parameters.Add("@FechaCarga", SqlDbType.Date);
                    cmd.Parameters["@FechaCarga"].Value = fecha;

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

        public ServicioPublicoDTO BuscarFormato(int Codigo)
        {
            ServicioPublicoDTO servicioPublicoDTO = new ServicioPublicoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ServicioPublicoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ServicioPublicoId", SqlDbType.Int);
                    cmd.Parameters["@ServicioPublicoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        servicioPublicoDTO.ServicioPublicoId = Convert.ToInt32(dr["ServicioPublicoId"]);
                        servicioPublicoDTO.AnioPagoServicio = Convert.ToInt32(dr["AnioPagoServicio"]);
                        servicioPublicoDTO.NumericoMes = dr["NumeroMes"].ToString();
                        servicioPublicoDTO.CodigoFuenteFinanciamiento = dr["CodigoFuenteFinanciamiento"].ToString();
                        servicioPublicoDTO.CodigoZonaNaval = dr["CodigoZonaNaval"].ToString();
                        servicioPublicoDTO.CodigoDependencia = dr["CodigoDependenciasSuministro"].ToString();
                        servicioPublicoDTO.CodigoTipoServicioPublico = dr["CodigoTipoServicioPublico"].ToString();
                        servicioPublicoDTO.SuministroUnico = Convert.ToInt32(dr["SuministroUnico"]);
                        servicioPublicoDTO.AsignacionMensual = Convert.ToDecimal(dr["AsignacionMensual"]);
                        servicioPublicoDTO.ConsumoMensual = Convert.ToDecimal(dr["ConsumoMensual"]);
                        servicioPublicoDTO.ConsumoUnidadMedida = dr["ConsumoUnidadMedida"].ToString(); 


                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return servicioPublicoDTO;
        }

        public string ActualizaFormato(ServicioPublicoDTO servicioPublicoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_ServicioPublicoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@ServicioPublicoId", SqlDbType.Int);
                    cmd.Parameters["@ServicioPublicoId"].Value = servicioPublicoDTO.ServicioPublicoId;

                    cmd.Parameters.Add("@AnioPagoServicio", SqlDbType.Int);
                    cmd.Parameters["@AnioPagoServicio"].Value = servicioPublicoDTO.AnioPagoServicio;

                    cmd.Parameters.Add("@NumeroMes", SqlDbType.VarChar,20);
                    cmd.Parameters["@NumeroMes"].Value = servicioPublicoDTO.NumericoMes;

                    cmd.Parameters.Add("@CodigoFuenteFinanciamiento", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoFuenteFinanciamiento"].Value = servicioPublicoDTO.CodigoFuenteFinanciamiento;

                    cmd.Parameters.Add("@CodigoZonaNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoZonaNaval"].Value = servicioPublicoDTO.CodigoZonaNaval;

                    cmd.Parameters.Add("@CodigoDependenciasSuministro", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDependenciasSuministro"].Value = servicioPublicoDTO.CodigoDependencia;

                    cmd.Parameters.Add("@CodigoTipoServicioPublico", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoServicioPublico"].Value = servicioPublicoDTO.CodigoTipoServicioPublico;

                    cmd.Parameters.Add("@SuministroUnico", SqlDbType.Int);
                    cmd.Parameters["@SuministroUnico"].Value = servicioPublicoDTO.SuministroUnico;

                    cmd.Parameters.Add("@AsignacionMensual", SqlDbType.Decimal);
                    cmd.Parameters["@AsignacionMensual"].Value = servicioPublicoDTO.AsignacionMensual;

                    cmd.Parameters.Add("@ConsumoMensual", SqlDbType.Decimal);
                    cmd.Parameters["@ConsumoMensual"].Value = servicioPublicoDTO.ConsumoMensual;

                    cmd.Parameters.Add("@ConsumoUnidadMedida", SqlDbType.VarChar,10);
                    cmd.Parameters["@ConsumoUnidadMedida"].Value = servicioPublicoDTO.ConsumoUnidadMedida;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = servicioPublicoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(ServicioPublicoDTO servicioPublicoDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ServicioPublicoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ServicioPublicoId", SqlDbType.Int);
                    cmd.Parameters["@ServicioPublicoId"].Value = servicioPublicoDTO.ServicioPublicoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = servicioPublicoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(ServicioPublicoDTO servicioPublicoDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Seguridad.usp_CargaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Formato", SqlDbType.NVarChar, 200);
                    cmd.Parameters["@Formato"].Value = "ServicioPublico";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = servicioPublicoDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = servicioPublicoDTO.UsuarioIngresoRegistro;

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

        public string InsertarDatos(DataTable datos, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("Formato.usp_ServicioPublicoRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ServicioPublico", SqlDbType.Structured);
                    cmd.Parameters["@ServicioPublico"].TypeName = "Formato.ServicioPublico";
                    cmd.Parameters["@ServicioPublico"].Value = datos;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Mac"].Value = UtilitariosGlobales.obtenerDireccionMac();

                    cmd.Parameters.Add("@FechaCarga", SqlDbType.Date);
                    cmd.Parameters["@FechaCarga"].Value = fecha;

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
    }
}
