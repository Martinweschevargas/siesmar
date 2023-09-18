using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Bienestar;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Utilitarios;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Bienestar
{
    public class SolicitudPrestamoConvenioDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<SolicitudPrestamoConvenioDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<SolicitudPrestamoConvenioDTO> lista = new List<SolicitudPrestamoConvenioDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_SolicitudPrestamoConvenioListar", conexion);
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
                        lista.Add(new SolicitudPrestamoConvenioDTO()
                        {
                            SolicitudPrestamoConvenioId = Convert.ToInt32(dr["SolicitudPrestamoConvenioId"]),
                            FechaSolicitud = (dr["FechaSolicitud"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            DNIBeneficiario = dr["DNIBeneficiario"].ToString(),
                            CIPBeneficiario = dr["CIPBeneficiario"].ToString(),
                            DescTipoPersonalMilitar = dr["DescTipoPersonalMilitar"].ToString(),
                            DescGrado = dr["DescGrado"].ToString(),
                            AnioServicio = Convert.ToInt32(dr["AnioServicio"]),
                            ResultadoSolicitud = dr["ResultadoSolicitud"].ToString(),
                            DescEntidadFinanciera = dr["DescEntidadFinanciera"].ToString(),
                            DescTipoPrestamoConvenio = dr["DescTipoPrestamoConvenio"].ToString(),
                            TasaInteresPrestamo = Convert.ToDecimal(dr["TasaInteresPrestamo"]),
                            ImporteCreditoSoles = Convert.ToDecimal(dr["ImporteCreditoSoles"]),
                            NumeroCuotas = Convert.ToInt32(dr["NumeroCuotas"]),
                            CargaId = Convert.ToInt32(dr["CargaId"]),

                        });
                    }
                }
            }
            return lista;
        }

        public List<SolicitudPrestamoConvenioDTO> BienestarVisualizacionSolicitudPrestamoConsumo(int? CargaId = null, string? fechaInicio = null, string? fechaFin = null)
        {
            List<SolicitudPrestamoConvenioDTO> lista = new List<SolicitudPrestamoConvenioDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Reporte.usp_BienestarVisualizacionSolicitudPrestamoConsumo", conexion);
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
                        lista.Add(new SolicitudPrestamoConvenioDTO()
                        {
                            FechaSolicitud = dr["FechaSolicitud"].ToString(),
                            DNIBeneficiario = dr["DNIBeneficiario"].ToString(),
                            CIPBeneficiario = dr["CIPBeneficiario"].ToString(),
                            DescTipoPersonalMilitar = dr["DescTipoPersonalMilitar"].ToString(),
                            DescGrado = dr["DescGrado"].ToString(),
                            AnioServicio = Convert.ToInt32(dr["AnioServicio"]),
                            ResultadoSolicitud = dr["ResultadoSolicitud"].ToString(),
                            DescEntidadFinanciera = dr["DescEntidadFinanciera"].ToString(),
                            DescTipoPrestamoConvenio = dr["DescTipoPrestamoConvenio"].ToString(),
                            TasaInteresPrestamo = Convert.ToDecimal(dr["TasaInteresPrestamo"]),
                            ImporteCreditoSoles = Convert.ToDecimal(dr["ImporteCreditoSoles"]),
                            NumeroCuotas = Convert.ToInt32(dr["NumeroCuotas"]),

                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(SolicitudPrestamoConvenioDTO solicitudPrestamoConvenioDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_SolicitudPrestamoConvenioRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FechaSolicitud", SqlDbType.Date);
                    cmd.Parameters["@FechaSolicitud"].Value = solicitudPrestamoConvenioDTO.FechaSolicitud;

                    cmd.Parameters.Add("@DNIBeneficiario", SqlDbType.VarChar, 8);
                    cmd.Parameters["@DNIBeneficiario"].Value = solicitudPrestamoConvenioDTO.DNIBeneficiario;

                    cmd.Parameters.Add("@CIPBeneficiario", SqlDbType.VarChar, 8);
                    cmd.Parameters["@CIPBeneficiario"].Value = solicitudPrestamoConvenioDTO.CIPBeneficiario;

                    cmd.Parameters.Add("@CodigoTipoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoPersonalMilitar"].Value = solicitudPrestamoConvenioDTO.CodigoTipoPersonalMilitar;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitar"].Value = solicitudPrestamoConvenioDTO.CodigoGradoPersonalMilitar;

                    cmd.Parameters.Add("@AnioServicio", SqlDbType.Int);
                    cmd.Parameters["@AnioServicio"].Value = solicitudPrestamoConvenioDTO.AnioServicio;

                    cmd.Parameters.Add("@ResultadoSolicitud", SqlDbType.VarChar,50);
                    cmd.Parameters["@ResultadoSolicitud"].Value = solicitudPrestamoConvenioDTO.ResultadoSolicitud;

                    cmd.Parameters.Add("@CodigoEntidadFinanciera", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEntidadFinanciera"].Value = solicitudPrestamoConvenioDTO.CodigoEntidadFinanciera;

                    cmd.Parameters.Add("@CodigoTipoPrestamoConvenio", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoPrestamoConvenio"].Value = solicitudPrestamoConvenioDTO.CodigoTipoPrestamoConvenio;

                    cmd.Parameters.Add("@TasaInteresPrestamo", SqlDbType.Decimal);
                    cmd.Parameters["@TasaInteresPrestamo"].Value = solicitudPrestamoConvenioDTO.TasaInteresPrestamo;

                    cmd.Parameters.Add("@ImporteCreditoSoles", SqlDbType.Decimal);
                    cmd.Parameters["@ImporteCreditoSoles"].Value = solicitudPrestamoConvenioDTO.ImporteCreditoSoles;

                    cmd.Parameters.Add("@NumeroCuotas", SqlDbType.Int);
                    cmd.Parameters["@NumeroCuotas"].Value = solicitudPrestamoConvenioDTO.NumeroCuotas;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = solicitudPrestamoConvenioDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = solicitudPrestamoConvenioDTO.UsuarioIngresoRegistro;

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

        public SolicitudPrestamoConvenioDTO BuscarFormato(int Codigo)
        {
            SolicitudPrestamoConvenioDTO solicitudPrestamoConvenioDTO = new SolicitudPrestamoConvenioDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_SolicitudPrestamoConvenioEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SolicitudPrestamoConvenioId", SqlDbType.Int);
                    cmd.Parameters["@SolicitudPrestamoConvenioId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        solicitudPrestamoConvenioDTO.SolicitudPrestamoConvenioId = Convert.ToInt32(dr["SolicitudPrestamoConvenioId"]);
                        solicitudPrestamoConvenioDTO.FechaSolicitud = Convert.ToDateTime(dr["FechaSolicitud"]).ToString("yyy-MM-dd");
                        solicitudPrestamoConvenioDTO.DNIBeneficiario = dr["DNIBeneficiario"].ToString();
                        solicitudPrestamoConvenioDTO.CIPBeneficiario = dr["CIPBeneficiario"].ToString();
                        solicitudPrestamoConvenioDTO.CodigoTipoPersonalMilitar = dr["CodigoTipoPersonalMilitar"].ToString();
                        solicitudPrestamoConvenioDTO.CodigoGradoPersonalMilitar = dr["CodigoGradoPersonalMilitar"].ToString();
                        solicitudPrestamoConvenioDTO.AnioServicio = Convert.ToInt32(dr["AnioServicio"]);
                        solicitudPrestamoConvenioDTO.ResultadoSolicitud = dr["ResultadoSolicitud"].ToString();
                        solicitudPrestamoConvenioDTO.CodigoEntidadFinanciera = dr["CodigoEntidadFinanciera"].ToString();
                        solicitudPrestamoConvenioDTO.CodigoTipoPrestamoConvenio = dr["CodigoTipoPrestamoConvenio"].ToString();
                        solicitudPrestamoConvenioDTO.TasaInteresPrestamo = Convert.ToDecimal(dr["TasaInteresPrestamo"]);
                        solicitudPrestamoConvenioDTO.ImporteCreditoSoles = Convert.ToDecimal(dr["ImporteCreditoSoles"]);
                        solicitudPrestamoConvenioDTO.NumeroCuotas = Convert.ToInt32(dr["NumeroCuotas"]); 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return solicitudPrestamoConvenioDTO;
        }

        public string ActualizaFormato(SolicitudPrestamoConvenioDTO solicitudPrestamoConvenioDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_SolicitudPrestamoConvenioActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@SolicitudPrestamoConvenioId", SqlDbType.Int);
                    cmd.Parameters["@SolicitudPrestamoConvenioId"].Value = solicitudPrestamoConvenioDTO.SolicitudPrestamoConvenioId;

                    cmd.Parameters.Add("@FechaSolicitud", SqlDbType.Date);
                    cmd.Parameters["@FechaSolicitud"].Value = solicitudPrestamoConvenioDTO.FechaSolicitud;

                    cmd.Parameters.Add("@DNIBeneficiario", SqlDbType.VarChar, 8);
                    cmd.Parameters["@DNIBeneficiario"].Value = solicitudPrestamoConvenioDTO.DNIBeneficiario;

                    cmd.Parameters.Add("@CIPBeneficiario", SqlDbType.VarChar, 8);
                    cmd.Parameters["@CIPBeneficiario"].Value = solicitudPrestamoConvenioDTO.CIPBeneficiario;

                    cmd.Parameters.Add("@CodigoTipoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoPersonalMilitar"].Value = solicitudPrestamoConvenioDTO.CodigoTipoPersonalMilitar;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitar"].Value = solicitudPrestamoConvenioDTO.CodigoGradoPersonalMilitar;

                    cmd.Parameters.Add("@AnioServicio", SqlDbType.Int);
                    cmd.Parameters["@AnioServicio"].Value = solicitudPrestamoConvenioDTO.AnioServicio;

                    cmd.Parameters.Add("@ResultadoSolicitud", SqlDbType.VarChar, 50);
                    cmd.Parameters["@ResultadoSolicitud"].Value = solicitudPrestamoConvenioDTO.ResultadoSolicitud;

                    cmd.Parameters.Add("@CodigoEntidadFinanciera", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEntidadFinanciera"].Value = solicitudPrestamoConvenioDTO.CodigoEntidadFinanciera;

                    cmd.Parameters.Add("@CodigoTipoPrestamoConvenio", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoPrestamoConvenio"].Value = solicitudPrestamoConvenioDTO.CodigoTipoPrestamoConvenio;

                    cmd.Parameters.Add("@TasaInteresPrestamo", SqlDbType.Decimal);
                    cmd.Parameters["@TasaInteresPrestamo"].Value = solicitudPrestamoConvenioDTO.TasaInteresPrestamo;

                    cmd.Parameters.Add("@ImporteCreditoSoles", SqlDbType.Decimal);
                    cmd.Parameters["@ImporteCreditoSoles"].Value = solicitudPrestamoConvenioDTO.ImporteCreditoSoles;

                    cmd.Parameters.Add("@NumeroCuotas", SqlDbType.Int);
                    cmd.Parameters["@NumeroCuotas"].Value = solicitudPrestamoConvenioDTO.NumeroCuotas;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = solicitudPrestamoConvenioDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(SolicitudPrestamoConvenioDTO solicitudPrestamoConvenioDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_SolicitudPrestamoConvenioEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SolicitudPrestamoConvenioId", SqlDbType.Int);
                    cmd.Parameters["@SolicitudPrestamoConvenioId"].Value = solicitudPrestamoConvenioDTO.SolicitudPrestamoConvenioId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = solicitudPrestamoConvenioDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(SolicitudPrestamoConvenioDTO solicitudPrestamoConvenioDTO)
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
                    cmd.Parameters["@Formato"].Value = "SolicitudPrestamoConvenio";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = solicitudPrestamoConvenioDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = solicitudPrestamoConvenioDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_SolicitudPrestamoConvenioRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SolicitudPrestamoConvenio", SqlDbType.Structured);
                    cmd.Parameters["@SolicitudPrestamoConvenio"].TypeName = "Formato.SolicitudPrestamoConvenio";
                    cmd.Parameters["@SolicitudPrestamoConvenio"].Value = datos;

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
