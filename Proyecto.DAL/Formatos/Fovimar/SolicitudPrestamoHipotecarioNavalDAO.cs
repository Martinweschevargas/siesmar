using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Fovimar;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Fovimar
{
    public class SolicitudPrestamoHipotecarioNavalDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<SolicitudPrestamoHipotecarioNavalDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<SolicitudPrestamoHipotecarioNavalDTO> lista = new List<SolicitudPrestamoHipotecarioNavalDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_SolicitudPrestamoHipotecariosNavalListar", conexion);
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
                        lista.Add(new SolicitudPrestamoHipotecarioNavalDTO()
                        {
                            SolicitudPrestamoHipotecarioNavalId = Convert.ToInt32(dr["SolicitudPrestamoHipotecarioNavalId"]),
                            DNIPersonalNaval = dr["DNIPersonalNaval"].ToString(),
                            DescGrado = dr["DescGrado"].ToString(),
                            DescSituacionPersonalNaval = dr["DescSituacionPersonalNaval"].ToString(),
                            Prestario = dr["Prestario"].ToString(),
                            MontoSolicitado = Convert.ToDecimal(dr["MontoSolicitado"]),
                            DescMoneda = dr["DescMoneda"].ToString(),
                            FechaSolicitud = (dr["FechaSolicitud"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            AprobacionSolicitud = dr["AprobacionSolicitud"].ToString(),
                            FechaAprobacion = (dr["FechaAprobacion"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            FechaDesembolso = (dr["FechaDesembolso"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            NroCuota = Convert.ToInt32(dr["NroCuota"]),
                            DescModalidadPrestamo = dr["DescModalidadPrestamo"].ToString(),
                            DescFinalidadPrestamo = dr["DescFinalidadPrestamo"].ToString(),
                            DescEntidadFinanciera = dr["DescEntidadFinanciera"].ToString(),
                            RentabilidadFinanciera = Convert.ToDecimal(dr["RentabilidadFinanciera"]),
                            DescProyectoFovimar = dr["DescProyectoFovimar"].ToString(),
                            EstadoSolicitudPrestamo = dr["EstadoSolicitudPrestamo"].ToString(),
                            GarantiaConstituida = dr["GarantiaConstituida"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"])
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(SolicitudPrestamoHipotecarioNavalDTO solicitudPrestamoHipotecarioNavalDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_SolicitudPrestamoHipotecariosNavalRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DNIPersonalNaval", SqlDbType.VarChar,8);
                    cmd.Parameters["@DNIPersonalNaval"].Value = solicitudPrestamoHipotecarioNavalDTO.DNIPersonalNaval;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitar", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoGradoPersonalMilitar"].Value = solicitudPrestamoHipotecarioNavalDTO.CodigoGradoPersonalMilitar;

                    cmd.Parameters.Add("@CodigoSituacionPersonalNaval", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoSituacionPersonalNaval"].Value = solicitudPrestamoHipotecarioNavalDTO.CodigoSituacionPersonalNaval;

                    cmd.Parameters.Add("@Prestario", SqlDbType.VarChar,1);
                    cmd.Parameters["@Prestario"].Value = solicitudPrestamoHipotecarioNavalDTO.Prestario;

                    cmd.Parameters.Add("@MontoSolicitado", SqlDbType.Decimal);
                    cmd.Parameters["@MontoSolicitado"].Value = solicitudPrestamoHipotecarioNavalDTO.MontoSolicitado;

                    cmd.Parameters.Add("@CodigoMoneda", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoMoneda"].Value = solicitudPrestamoHipotecarioNavalDTO.CodigoMoneda;

                    cmd.Parameters.Add("@FechaSolicitud", SqlDbType.Date);
                    cmd.Parameters["@FechaSolicitud"].Value = solicitudPrestamoHipotecarioNavalDTO.FechaSolicitud;

                    cmd.Parameters.Add("@AprobacionSolicitud", SqlDbType.VarChar,1);
                    cmd.Parameters["@AprobacionSolicitud"].Value = solicitudPrestamoHipotecarioNavalDTO.AprobacionSolicitud;

                    cmd.Parameters.Add("@FechaAprobacion", SqlDbType.Date);
                    cmd.Parameters["@FechaAprobacion"].Value = solicitudPrestamoHipotecarioNavalDTO.FechaAprobacion;

                    cmd.Parameters.Add("@FechaDesembolso", SqlDbType.Date);
                    cmd.Parameters["@FechaDesembolso"].Value = solicitudPrestamoHipotecarioNavalDTO.FechaDesembolso;

                    cmd.Parameters.Add("@NroCuota", SqlDbType.Int);
                    cmd.Parameters["@NroCuota"].Value = solicitudPrestamoHipotecarioNavalDTO.NroCuota;

                    cmd.Parameters.Add("@CodigoModalidadPrestamo", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoModalidadPrestamo"].Value = solicitudPrestamoHipotecarioNavalDTO.CodigoModalidadPrestamo;

                    cmd.Parameters.Add("@CodigoFinalidadPrestamo", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoFinalidadPrestamo"].Value = solicitudPrestamoHipotecarioNavalDTO.CodigoFinalidadPrestamo;

                    cmd.Parameters.Add("@CodigoEntidadFinanciera", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoEntidadFinanciera"].Value = solicitudPrestamoHipotecarioNavalDTO.CodigoEntidadFinanciera;

                    cmd.Parameters.Add("@RentabilidadFinanciera", SqlDbType.Decimal);
                    cmd.Parameters["@RentabilidadFinanciera"].Value = solicitudPrestamoHipotecarioNavalDTO.RentabilidadFinanciera;

                    cmd.Parameters.Add("@CodigoProyectoFovimar", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoProyectoFovimar"].Value = solicitudPrestamoHipotecarioNavalDTO.CodigoProyectoFovimar;

                    cmd.Parameters.Add("@EstadoSolicitudPrestamo", SqlDbType.VarChar,20);
                    cmd.Parameters["@EstadoSolicitudPrestamo"].Value = solicitudPrestamoHipotecarioNavalDTO.EstadoSolicitudPrestamo;

                    cmd.Parameters.Add("@GarantiaConstituida", SqlDbType.VarChar);
                    cmd.Parameters["@GarantiaConstituida"].Value = solicitudPrestamoHipotecarioNavalDTO.GarantiaConstituida;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = solicitudPrestamoHipotecarioNavalDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = solicitudPrestamoHipotecarioNavalDTO.UsuarioIngresoRegistro;

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

        public SolicitudPrestamoHipotecarioNavalDTO BuscarFormato(int Codigo)
        {
            SolicitudPrestamoHipotecarioNavalDTO solicitudPrestamoHipotecarioNavalDTO = new SolicitudPrestamoHipotecarioNavalDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_SolicitudPrestamoHipotecariosNavalEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SolicitudPrestamoHipotecarioNavalId", SqlDbType.Int);
                    cmd.Parameters["@SolicitudPrestamoHipotecarioNavalId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        solicitudPrestamoHipotecarioNavalDTO.SolicitudPrestamoHipotecarioNavalId = Convert.ToInt32(dr["SolicitudPrestamoHipotecarioNavalId"]);
                        solicitudPrestamoHipotecarioNavalDTO.DNIPersonalNaval = dr["DNIPersonalNaval"].ToString();
                        solicitudPrestamoHipotecarioNavalDTO.CodigoGradoPersonalMilitar = dr["CodigoGradoPersonalMilitar"].ToString();
                        solicitudPrestamoHipotecarioNavalDTO.CodigoSituacionPersonalNaval = dr["CodigoSituacionPersonalNaval"].ToString();
                        solicitudPrestamoHipotecarioNavalDTO.Prestario = dr["Prestario"].ToString();
                        solicitudPrestamoHipotecarioNavalDTO.MontoSolicitado = Convert.ToDecimal(dr["MontoSolicitado"]);
                        solicitudPrestamoHipotecarioNavalDTO.CodigoMoneda = dr["CodigoMoneda"].ToString();
                        solicitudPrestamoHipotecarioNavalDTO.FechaSolicitud = Convert.ToDateTime(dr["FechaSolicitud"]).ToString("yyy-MM-dd");
                        solicitudPrestamoHipotecarioNavalDTO.AprobacionSolicitud = dr["AprobacionSolicitud"].ToString();
                        solicitudPrestamoHipotecarioNavalDTO.FechaAprobacion = Convert.ToDateTime(dr["FechaAprobacion"]).ToString("yyy-MM-dd");
                        solicitudPrestamoHipotecarioNavalDTO.FechaDesembolso = Convert.ToDateTime(dr["FechaDesembolso"]).ToString("yyy-MM-dd");
                        solicitudPrestamoHipotecarioNavalDTO.NroCuota = Convert.ToInt32(dr["NroCuota"]);
                        solicitudPrestamoHipotecarioNavalDTO.CodigoModalidadPrestamo = dr["CodigoModalidadPrestamo"].ToString();
                        solicitudPrestamoHipotecarioNavalDTO.CodigoFinalidadPrestamo = dr["CodigoFinalidadPrestamo"].ToString();
                        solicitudPrestamoHipotecarioNavalDTO.CodigoEntidadFinanciera = dr["CodigoEntidadFinanciera"].ToString();
                        solicitudPrestamoHipotecarioNavalDTO.RentabilidadFinanciera = Convert.ToDecimal(dr["RentabilidadFinanciera"]);
                        solicitudPrestamoHipotecarioNavalDTO.CodigoProyectoFovimar = dr["CodigoProyectoFovimar"].ToString();
                        solicitudPrestamoHipotecarioNavalDTO.EstadoSolicitudPrestamo = dr["EstadoSolicitudPrestamo"].ToString();
                        solicitudPrestamoHipotecarioNavalDTO.GarantiaConstituida = dr["GarantiaConstituida"].ToString(); 
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return solicitudPrestamoHipotecarioNavalDTO;
        }

        public string ActualizaFormato(SolicitudPrestamoHipotecarioNavalDTO solicitudPrestamoHipotecarioNavalDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_SolicitudPrestamoHipotecariosNavalActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SolicitudPrestamoHipotecarioNavalId", SqlDbType.Int);
                    cmd.Parameters["@SolicitudPrestamoHipotecarioNavalId"].Value = solicitudPrestamoHipotecarioNavalDTO.SolicitudPrestamoHipotecarioNavalId;

                    cmd.Parameters.Add("@DNIPersonalNaval", SqlDbType.VarChar,8);
                    cmd.Parameters["@DNIPersonalNaval"].Value = solicitudPrestamoHipotecarioNavalDTO.DNIPersonalNaval;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitar"].Value = solicitudPrestamoHipotecarioNavalDTO.CodigoGradoPersonalMilitar;

                    cmd.Parameters.Add("@CodigoSituacionPersonalNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoSituacionPersonalNaval"].Value = solicitudPrestamoHipotecarioNavalDTO.CodigoSituacionPersonalNaval;

                    cmd.Parameters.Add("@Prestario", SqlDbType.VarChar, 1);
                    cmd.Parameters["@Prestario"].Value = solicitudPrestamoHipotecarioNavalDTO.Prestario;

                    cmd.Parameters.Add("@MontoSolicitado", SqlDbType.Decimal);
                    cmd.Parameters["@MontoSolicitado"].Value = solicitudPrestamoHipotecarioNavalDTO.MontoSolicitado;

                    cmd.Parameters.Add("@CodigoMoneda", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoMoneda"].Value = solicitudPrestamoHipotecarioNavalDTO.CodigoMoneda;

                    cmd.Parameters.Add("@FechaSolicitud", SqlDbType.Date);
                    cmd.Parameters["@FechaSolicitud"].Value = solicitudPrestamoHipotecarioNavalDTO.FechaSolicitud;

                    cmd.Parameters.Add("@AprobacionSolicitud", SqlDbType.VarChar, 1);
                    cmd.Parameters["@AprobacionSolicitud"].Value = solicitudPrestamoHipotecarioNavalDTO.AprobacionSolicitud;

                    cmd.Parameters.Add("@FechaAprobacion", SqlDbType.Date);
                    cmd.Parameters["@FechaAprobacion"].Value = solicitudPrestamoHipotecarioNavalDTO.FechaAprobacion;

                    cmd.Parameters.Add("@FechaDesembolso", SqlDbType.Date);
                    cmd.Parameters["@FechaDesembolso"].Value = solicitudPrestamoHipotecarioNavalDTO.FechaDesembolso;

                    cmd.Parameters.Add("@NroCuota", SqlDbType.Int);
                    cmd.Parameters["@NroCuota"].Value = solicitudPrestamoHipotecarioNavalDTO.NroCuota;

                    cmd.Parameters.Add("@CodigoModalidadPrestamo", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoModalidadPrestamo"].Value = solicitudPrestamoHipotecarioNavalDTO.CodigoModalidadPrestamo;

                    cmd.Parameters.Add("@CodigoFinalidadPrestamo", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoFinalidadPrestamo"].Value = solicitudPrestamoHipotecarioNavalDTO.CodigoFinalidadPrestamo;

                    cmd.Parameters.Add("@CodigoEntidadFinanciera", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEntidadFinanciera"].Value = solicitudPrestamoHipotecarioNavalDTO.CodigoEntidadFinanciera;

                    cmd.Parameters.Add("@RentabilidadFinanciera", SqlDbType.Decimal);
                    cmd.Parameters["@RentabilidadFinanciera"].Value = solicitudPrestamoHipotecarioNavalDTO.RentabilidadFinanciera;

                    cmd.Parameters.Add("@CodigoProyectoFovimar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoProyectoFovimar"].Value = solicitudPrestamoHipotecarioNavalDTO.CodigoProyectoFovimar;

                    cmd.Parameters.Add("@EstadoSolicitudPrestamo", SqlDbType.VarChar, 20);
                    cmd.Parameters["@EstadoSolicitudPrestamo"].Value = solicitudPrestamoHipotecarioNavalDTO.EstadoSolicitudPrestamo;

                    cmd.Parameters.Add("@GarantiaConstituida", SqlDbType.VarChar);
                    cmd.Parameters["@GarantiaConstituida"].Value = solicitudPrestamoHipotecarioNavalDTO.GarantiaConstituida;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = solicitudPrestamoHipotecarioNavalDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(SolicitudPrestamoHipotecarioNavalDTO solicitudPrestamoHipotecarioNavalDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_SolicitudPrestamoHipotecariosNavalEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SolicitudPrestamoHipotecarioNavalId", SqlDbType.Int);
                    cmd.Parameters["@SolicitudPrestamoHipotecarioNavalId"].Value = solicitudPrestamoHipotecarioNavalDTO.SolicitudPrestamoHipotecarioNavalId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = solicitudPrestamoHipotecarioNavalDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(SolicitudPrestamoHipotecarioNavalDTO solicitudPrestamoHipotecarioNavalDTO)
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
                    cmd.Parameters["@Formato"].Value = "SolicitudPrestamoHipotecariosNaval";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = solicitudPrestamoHipotecarioNavalDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = solicitudPrestamoHipotecarioNavalDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_SolicitudPrestamoHipotecariosNavalRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SolicitudPrestamoHipotecariosNaval", SqlDbType.Structured);
                    cmd.Parameters["@SolicitudPrestamoHipotecariosNaval"].TypeName = "Formato.SolicitudPrestamoHipotecariosNaval";
                    cmd.Parameters["@SolicitudPrestamoHipotecariosNaval"].Value = datos;

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
