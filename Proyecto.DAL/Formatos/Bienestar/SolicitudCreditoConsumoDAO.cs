using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Bienestar;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Bienestar
{
    public class SolicitudCreditoConsumoDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<SolicitudCreditoConsumoDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<SolicitudCreditoConsumoDTO> lista = new List<SolicitudCreditoConsumoDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_SolicitudCreditoConsumoListar", conexion);
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
                        lista.Add(new SolicitudCreditoConsumoDTO()
                        {
                            SolicitudCreditoConsumoId = Convert.ToInt32(dr["SolicitudCreditoConsumoId"]),
                            FechaSolicitudCredito = (dr["FechaSolicitudCredito"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            DNISolicitante = dr["DNISolicitante"].ToString(),
                            CIPSolicitante = dr["CIPSolicitante"].ToString(),
                            DescTipoPersonalMilitar = dr["DescTipoPersonalMilitar"].ToString(),
                            DescGrado = dr["DescGrado"].ToString(),
                            AnioServicio = Convert.ToInt32(dr["AnioServicio"]),
                            ResultadoSolicitud = dr["ResultadoSolicitud"].ToString(),
                            DescEntidadFinanciera = dr["DescEntidadFinanciera"].ToString(),
                            NumeroCuotas = Convert.ToInt32(dr["NumeroCuotas"]),
                            ImporteCredito = Convert.ToDecimal(dr["ImporteCredito"]),
                            TasaInteresCredito = Convert.ToDecimal(dr["TasaInteresCredito"]),
                            CargaId = Convert.ToInt32(dr["CargaId"]),


                        });
                    }
                }
            }
            return lista;
        }

        public List<SolicitudCreditoConsumoDTO> BienestarVisualizacionSolicitudCreditoConsumo(int? CargaId=null, string fechaInicio=null, string fechaFin=null)
        {
            List<SolicitudCreditoConsumoDTO> lista = new List<SolicitudCreditoConsumoDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Reporte.usp_BienestarVisualizacionSolicitudCreditoConsumo", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                cmd.Parameters.Add("@FechaInicio", SqlDbType.Date);
                cmd.Parameters["@FechaInicio"].Value = fechaInicio;

                cmd.Parameters.Add("@FechaFin", SqlDbType.Date);
                cmd.Parameters["@FechaFin"].Value = fechaFin;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new SolicitudCreditoConsumoDTO()
                        {
                            FechaSolicitudCredito = dr["FechaSolicitudCredito"].ToString(),
                            DNISolicitante = dr["DNISolicitante"].ToString(),
                            CIPSolicitante = dr["CIPSolicitante"].ToString(),
                            DescTipoPersonalMilitar = dr["DescTipoPersonalMilitar"].ToString(),
                            DescGrado = dr["DescGrado"].ToString(),
                            AnioServicio = Convert.ToInt32(dr["AnioServicio"]),
                            ResultadoSolicitud = dr["ResultadoSolicitud"].ToString(),
                            DescEntidadFinanciera = dr["DescEntidadFinanciera"].ToString(),
                            NumeroCuotas = Convert.ToInt32(dr["NumeroCuotas"]),
                            ImporteCredito = Convert.ToDecimal(dr["ImporteCredito"]),
                            TasaInteresCredito = Convert.ToDecimal(dr["TasaInteresCredito"]),

                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(SolicitudCreditoConsumoDTO solicitudCreditoConsumoDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_SolicitudCreditoConsumoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FechaSolicitudCredito", SqlDbType.Date);
                    cmd.Parameters["@FechaSolicitudCredito"].Value = solicitudCreditoConsumoDTO.FechaSolicitudCredito;

                    cmd.Parameters.Add("@DNISolicitante", SqlDbType.VarChar, 8);
                    cmd.Parameters["@DNISolicitante"].Value = solicitudCreditoConsumoDTO.DNISolicitante;

                    cmd.Parameters.Add("@CIPSolicitante", SqlDbType.VarChar, 8);
                    cmd.Parameters["@CIPSolicitante"].Value = solicitudCreditoConsumoDTO.CIPSolicitante;

                    cmd.Parameters.Add("@CodigoTipoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoPersonalMilitar"].Value = solicitudCreditoConsumoDTO.CodigoTipoPersonalMilitar;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitar"].Value = solicitudCreditoConsumoDTO.CodigoGradoPersonalMilitar;

                    cmd.Parameters.Add("@AnioServicio", SqlDbType.Int);
                    cmd.Parameters["@AnioServicio"].Value = solicitudCreditoConsumoDTO.AnioServicio;

                    cmd.Parameters.Add("@ResultadoSolicitud", SqlDbType.VarChar, 50);
                    cmd.Parameters["@ResultadoSolicitud"].Value = solicitudCreditoConsumoDTO.ResultadoSolicitud;

                    cmd.Parameters.Add("@CodigoEntidadFinanciera", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEntidadFinanciera"].Value = solicitudCreditoConsumoDTO.CodigoEntidadFinanciera;

                    cmd.Parameters.Add("@NumeroCuotas", SqlDbType.Int);
                    cmd.Parameters["@NumeroCuotas"].Value = solicitudCreditoConsumoDTO.NumeroCuotas;

                    cmd.Parameters.Add("@ImporteCredito", SqlDbType.Decimal);
                    cmd.Parameters["@ImporteCredito"].Value = solicitudCreditoConsumoDTO.ImporteCredito;

                    cmd.Parameters.Add("@TasaInteresCredito", SqlDbType.Decimal);
                    cmd.Parameters["@TasaInteresCredito"].Value = solicitudCreditoConsumoDTO.TasaInteresCredito;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = solicitudCreditoConsumoDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = solicitudCreditoConsumoDTO.UsuarioIngresoRegistro;

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

        public SolicitudCreditoConsumoDTO BuscarFormato(int Codigo)
        {
            SolicitudCreditoConsumoDTO solicitudCreditoConsumoDTO = new SolicitudCreditoConsumoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_SolicitudCreditoConsumoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SolicitudCreditoConsumoId", SqlDbType.Int);
                    cmd.Parameters["@SolicitudCreditoConsumoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        solicitudCreditoConsumoDTO.SolicitudCreditoConsumoId = Convert.ToInt32(dr["SolicitudCreditoConsumoId"]);
                        solicitudCreditoConsumoDTO.FechaSolicitudCredito = Convert.ToDateTime(dr["FechaSolicitudCredito"]).ToString("yyy-MM-dd");
                        solicitudCreditoConsumoDTO.DNISolicitante = dr["DNISolicitante"].ToString();
                        solicitudCreditoConsumoDTO.CIPSolicitante = dr["CIPSolicitante"].ToString();
                        solicitudCreditoConsumoDTO.CodigoTipoPersonalMilitar = dr["CodigoTipoPersonalMilitar"].ToString();
                        solicitudCreditoConsumoDTO.CodigoGradoPersonalMilitar = dr["CodigoGradoPersonalMilitar"].ToString();
                        solicitudCreditoConsumoDTO.AnioServicio = Convert.ToInt32(dr["AnioServicio"]);
                        solicitudCreditoConsumoDTO.ResultadoSolicitud = dr["ResultadoSolicitud"].ToString();
                        solicitudCreditoConsumoDTO.CodigoEntidadFinanciera = dr["CodigoEntidadFinanciera"].ToString();
                        solicitudCreditoConsumoDTO.NumeroCuotas = Convert.ToInt32(dr["NumeroCuotas"]);
                        solicitudCreditoConsumoDTO.ImporteCredito = Convert.ToDecimal(dr["ImporteCredito"]);
                        solicitudCreditoConsumoDTO.TasaInteresCredito = Convert.ToDecimal(dr["TasaInteresCredito"]);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return solicitudCreditoConsumoDTO;
        }

        public string ActualizaFormato(SolicitudCreditoConsumoDTO solicitudCreditoConsumoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_SolicitudCreditoConsumoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@SolicitudCreditoConsumoId", SqlDbType.Int);
                    cmd.Parameters["@SolicitudCreditoConsumoId"].Value = solicitudCreditoConsumoDTO.SolicitudCreditoConsumoId;

                    cmd.Parameters.Add("@FechaSolicitudCredito", SqlDbType.Date);
                    cmd.Parameters["@FechaSolicitudCredito"].Value = solicitudCreditoConsumoDTO.FechaSolicitudCredito;

                    cmd.Parameters.Add("@DNISolicitante", SqlDbType.VarChar, 8);
                    cmd.Parameters["@DNISolicitante"].Value = solicitudCreditoConsumoDTO.DNISolicitante;

                    cmd.Parameters.Add("@CIPSolicitante", SqlDbType.VarChar, 8);
                    cmd.Parameters["@CIPSolicitante"].Value = solicitudCreditoConsumoDTO.CIPSolicitante;

                    cmd.Parameters.Add("@CodigoTipoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoPersonalMilitar"].Value = solicitudCreditoConsumoDTO.CodigoTipoPersonalMilitar;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitar"].Value = solicitudCreditoConsumoDTO.CodigoGradoPersonalMilitar;

                    cmd.Parameters.Add("@AnioServicio", SqlDbType.Int);
                    cmd.Parameters["@AnioServicio"].Value = solicitudCreditoConsumoDTO.AnioServicio;

                    cmd.Parameters.Add("@ResultadoSolicitud", SqlDbType.VarChar, 50);
                    cmd.Parameters["@ResultadoSolicitud"].Value = solicitudCreditoConsumoDTO.ResultadoSolicitud;

                    cmd.Parameters.Add("@CodigoEntidadFinanciera", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEntidadFinanciera"].Value = solicitudCreditoConsumoDTO.CodigoEntidadFinanciera;

                    cmd.Parameters.Add("@NumeroCuotas", SqlDbType.Int);
                    cmd.Parameters["@NumeroCuotas"].Value = solicitudCreditoConsumoDTO.NumeroCuotas;

                    cmd.Parameters.Add("@ImporteCredito", SqlDbType.Decimal);
                    cmd.Parameters["@ImporteCredito"].Value = solicitudCreditoConsumoDTO.ImporteCredito;

                    cmd.Parameters.Add("@TasaInteresCredito", SqlDbType.Decimal);
                    cmd.Parameters["@TasaInteresCredito"].Value = solicitudCreditoConsumoDTO.TasaInteresCredito;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = solicitudCreditoConsumoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(SolicitudCreditoConsumoDTO solicitudCreditoConsumoDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_SolicitudCreditoConsumoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SolicitudCreditoConsumoId", SqlDbType.Int);
                    cmd.Parameters["@SolicitudCreditoConsumoId"].Value = solicitudCreditoConsumoDTO.SolicitudCreditoConsumoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = solicitudCreditoConsumoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(SolicitudCreditoConsumoDTO solicitudCreditoConsumoDTO)
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
                    cmd.Parameters["@Formato"].Value = "SolicitudCreditoConsumo";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = solicitudCreditoConsumoDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = solicitudCreditoConsumoDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_SolicitudCreditoConsumoRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SolicitudCreditoConsumo", SqlDbType.Structured);
                    cmd.Parameters["@SolicitudCreditoConsumo"].TypeName = "Formato.SolicitudCreditoConsumo";
                    cmd.Parameters["@SolicitudCreditoConsumo"].Value = datos;

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
