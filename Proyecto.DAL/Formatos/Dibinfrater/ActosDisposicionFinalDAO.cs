using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Dibinfrater;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dibinfrater
{
    public class ActosDisposicionFinalDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<ActosDisposicionFinalDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<ActosDisposicionFinalDTO> lista = new List<ActosDisposicionFinalDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_ActoDisposicionFinalListar", conexion);
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
                        lista.Add(new ActosDisposicionFinalDTO()
                        {
                            ActoDisposicionFinalId = Convert.ToInt32(dr["ActoDisposicionFinalId"]),
                            AnioActoDisposicionFinal = Convert.ToInt32(dr["AnioActoDisposicionFinal"]),
                            DescMes = dr["DescMes"].ToString(),
                            IdentificacionDisposicionFinal = dr["IdentificacionDisposicionFinal"].ToString(),
                            DescAreaDiperadmon = dr["DescAreaDiperadmon"].ToString(),
                            DescZonaNaval = dr["DescZonaNaval"].ToString(),
                            EstadoTramiteSolicitud = dr["EstadoTramiteSolicitud"].ToString(),
                            DescTipoBien = dr["DescTipoBien"].ToString(),
                            DescMedidaAdaptadaDisposicionFinal = dr["DescMedidaAdaptadaDisposicionFinal"].ToString(),
                            CantidadBienes = Convert.ToInt32(dr["CantidadBienes"]),
                            Monto = Convert.ToDecimal(dr["Monto"]),
                            CargaId = Convert.ToInt32(dr["CargaId"]),

                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(ActosDisposicionFinalDTO actosDisposicionFinalDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ActoDisposicionFinalRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@AnioActoDisposicionFinal", SqlDbType.Int);
                    cmd.Parameters["@AnioActoDisposicionFinal"].Value = actosDisposicionFinalDTO.AnioActoDisposicionFinal;

                    cmd.Parameters.Add("@NumeroMes", SqlDbType.Int);
                    cmd.Parameters["@NumeroMes"].Value = actosDisposicionFinalDTO.NumeroMes;

                    cmd.Parameters.Add("@IdentificacionDisposicionFinal", SqlDbType.VarChar,20);
                    cmd.Parameters["@IdentificacionDisposicionFinal"].Value = actosDisposicionFinalDTO.IdentificacionDisposicionFinal;

                    cmd.Parameters.Add("@CodigoAreaDiperadmon", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoAreaDiperadmon"].Value = actosDisposicionFinalDTO.CodigoAreaDiperadmon;

                    cmd.Parameters.Add("@CodigoZonaNaval", SqlDbType.Int);
                    cmd.Parameters["@CodigoZonaNaval"].Value = actosDisposicionFinalDTO.CodigoZonaNaval;

                    cmd.Parameters.Add("@EstadoTramiteSolicitud", SqlDbType.VarChar,20);
                    cmd.Parameters["@EstadoTramiteSolicitud"].Value = actosDisposicionFinalDTO.EstadoTramiteSolicitud;

                    cmd.Parameters.Add("@CodigoTipoBien", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoBien"].Value = actosDisposicionFinalDTO.CodigoTipoBien;

                    cmd.Parameters.Add("@CodigoMedidaAdaptadaDisposicionFinal", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoMedidaAdaptadaDisposicionFinal"].Value = actosDisposicionFinalDTO.CodigoMedidaAdaptadaDisposicionFinal;

                    cmd.Parameters.Add("@CantidadBienes", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CantidadBienes"].Value = actosDisposicionFinalDTO.CantidadBienes;

                    cmd.Parameters.Add("@Monto", SqlDbType.Decimal);
                    cmd.Parameters["@Monto"].Value = actosDisposicionFinalDTO.Monto;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = actosDisposicionFinalDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = actosDisposicionFinalDTO.UsuarioIngresoRegistro;

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

        public ActosDisposicionFinalDTO BuscarFormato(int Codigo)
        {
            ActosDisposicionFinalDTO actosDisposicionFinalDTO = new ActosDisposicionFinalDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ActoDisposicionFinalEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ActoDisposicionFinalId", SqlDbType.Int);
                    cmd.Parameters["@ActoDisposicionFinalId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        actosDisposicionFinalDTO.ActoDisposicionFinalId = Convert.ToInt32(dr["ActoDisposicionFinalId"]);
                        actosDisposicionFinalDTO.AnioActoDisposicionFinal = Convert.ToInt32(dr["AnioActoDisposicionFinal"]);
                        actosDisposicionFinalDTO.NumeroMes = dr["NumeroMes"].ToString();
                        actosDisposicionFinalDTO.IdentificacionDisposicionFinal = dr["IdentificacionDisposicionFinal"].ToString();
                        actosDisposicionFinalDTO.CodigoAreaDiperadmon = dr["CodigoAreaDiperadmon"].ToString();
                        actosDisposicionFinalDTO.CodigoZonaNaval = dr["CodigoZonaNaval"].ToString();
                        actosDisposicionFinalDTO.EstadoTramiteSolicitud = dr["EstadoTramiteSolicitud"].ToString();
                        actosDisposicionFinalDTO.CodigoTipoBien = dr["CodigoTipoBien"].ToString();
                        actosDisposicionFinalDTO.CodigoMedidaAdaptadaDisposicionFinal = dr["CodigoMedidaAdaptadaDisposicionFinal"].ToString();
                        actosDisposicionFinalDTO.CantidadBienes = Convert.ToInt32(dr["CantidadBienes"]);
                        actosDisposicionFinalDTO.Monto = Convert.ToDecimal(dr["Monto"]); 


                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return actosDisposicionFinalDTO;
        }

        public string ActualizaFormato(ActosDisposicionFinalDTO actosDisposicionFinalDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_ActoDisposicionFinalActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@ActoDisposicionFinalId", SqlDbType.Int);
                    cmd.Parameters["@ActoDisposicionFinalId"].Value = actosDisposicionFinalDTO.ActoDisposicionFinalId;

                    cmd.Parameters.Add("@AnioActoDisposicionFinal", SqlDbType.Int);
                    cmd.Parameters["@AnioActoDisposicionFinal"].Value = actosDisposicionFinalDTO.AnioActoDisposicionFinal;

                    cmd.Parameters.Add("@NumeroMes", SqlDbType.Int);
                    cmd.Parameters["@NumeroMes"].Value = actosDisposicionFinalDTO.NumeroMes;

                    cmd.Parameters.Add("@IdentificacionDisposicionFinal", SqlDbType.VarChar,20);
                    cmd.Parameters["@IdentificacionDisposicionFinal"].Value = actosDisposicionFinalDTO.IdentificacionDisposicionFinal;

                    cmd.Parameters.Add("@CodigoAreaDiperadmon", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoAreaDiperadmon"].Value = actosDisposicionFinalDTO.CodigoAreaDiperadmon;

                    cmd.Parameters.Add("@CodigoZonaNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoZonaNaval"].Value = actosDisposicionFinalDTO.CodigoZonaNaval;

                    cmd.Parameters.Add("@EstadoTramiteSolicitud", SqlDbType.VarChar,20);
                    cmd.Parameters["@EstadoTramiteSolicitud"].Value = actosDisposicionFinalDTO.EstadoTramiteSolicitud;

                    cmd.Parameters.Add("@CodigoTipoBien", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoBien"].Value = actosDisposicionFinalDTO.CodigoTipoBien;

                    cmd.Parameters.Add("@CodigoMedidaAdaptadaDisposicionFinal", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoMedidaAdaptadaDisposicionFinal"].Value = actosDisposicionFinalDTO.CodigoMedidaAdaptadaDisposicionFinal;

                    cmd.Parameters.Add("@CantidadBienes", SqlDbType.Int);
                    cmd.Parameters["@CantidadBienes"].Value = actosDisposicionFinalDTO.CantidadBienes;

                    cmd.Parameters.Add("@Monto", SqlDbType.Decimal);
                    cmd.Parameters["@Monto"].Value = actosDisposicionFinalDTO.Monto;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = actosDisposicionFinalDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(ActosDisposicionFinalDTO actosDisposicionFinalDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ActoDisposicionFinalEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ActoDisposicionFinalId", SqlDbType.Int);
                    cmd.Parameters["@ActoDisposicionFinalId"].Value = actosDisposicionFinalDTO.ActoDisposicionFinalId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = actosDisposicionFinalDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(ActosDisposicionFinalDTO actosDisposicionFinalDTO)
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
                    cmd.Parameters["@Formato"].Value = "ActoDisposicionFinal";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = actosDisposicionFinalDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = actosDisposicionFinalDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_ActoDisposicionFinalRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ActoDisposicionFinal", SqlDbType.Structured);
                    cmd.Parameters["@ActoDisposicionFinal"].TypeName = "Formato.ActoDisposicionFinal";
                    cmd.Parameters["@ActoDisposicionFinal"].Value = datos;

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
