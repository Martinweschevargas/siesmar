using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Bienestar;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Bienestar
{
    public class ServicioSocialBrindadoDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<ServicioSocialBrindadoDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<ServicioSocialBrindadoDTO> lista = new List<ServicioSocialBrindadoDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_ServicioSocialBrindadoListar", conexion);
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
                        lista.Add(new ServicioSocialBrindadoDTO()
                        {
                            ServicioSocialBrindadoId = Convert.ToInt32(dr["ServicioSocialBrindadoId"]),
                            FechaSolicitud = (dr["FechaSolicitud"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            DNIPersonal = dr["DNIPersonal"].ToString(),
                            DescPersonalSolicitante = dr["DescPersonalSolicitante"].ToString(),
                            DescCondicionSolicitante = dr["DescCondicionSolicitante"].ToString(),
                            DescPersonalBeneficiado = dr["DescPersonalBeneficiado"].ToString(),
                            DescTipoApoyoSocial = dr["DescTipoApoyoSocial"].ToString(),
                            DescTipoAtencion = dr["DescTipoAtencion"].ToString(),
                            DescTipoEvaluacionSocial = dr["DescTipoEvaluacionSocial"].ToString(),
                            OtroTipoApoyo = dr["OtroTipoApoyo"].ToString(),
                            ResultadoSolicitud = dr["ResultadoSolicitud"].ToString(),
                            FechaResultadoSolicitud = (dr["FechaResultadoSolicitud"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            CargaId = Convert.ToInt32(dr["CargaId"]),

                        });
                    }
                }
            }
            return lista;
        }

        public List<ServicioSocialBrindadoDTO> BienestarVisualizacionServicioSocialBrindadoPersonal(int? CargaId=null, string? fechaInicio=null, string? fechafin=null)
        {
            List<ServicioSocialBrindadoDTO> lista = new List<ServicioSocialBrindadoDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Reporte.usp_BienestarVisualizacionServicioSocialBrindadoPersonal", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                cmd.Parameters.Add("@FechaInicio", SqlDbType.Date);
                cmd.Parameters["@FechaInicio"].Value = fechaInicio;

                cmd.Parameters.Add("@FechaFin", SqlDbType.Date);
                cmd.Parameters["@FechaFin"].Value = fechafin;


                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ServicioSocialBrindadoDTO()
                        {
                            FechaSolicitud = dr["FechaSolicitud"].ToString(),
                            DNIPersonal = dr["DNIPersonal"].ToString(),
                            DescPersonalSolicitante = dr["DescPersonalSolicitante"].ToString(),
                            DescCondicionSolicitante = dr["DescCondicionSolicitante"].ToString(),
                            DescPersonalBeneficiado = dr["DescPersonalBeneficiado"].ToString(),
                            DescTipoApoyoSocial = dr["DescTipoApoyoSocial"].ToString(),
                            DescTipoAtencion = dr["DescTipoAtencion"].ToString(),
                            DescTipoEvaluacionSocial = dr["DescTipoEvaluacionSocial"].ToString(),
                            OtroTipoApoyo = dr["OtroTipoApoyo"].ToString(),
                            ResultadoSolicitud = dr["ResultadoSolicitud"].ToString(),
                            FechaResultadoSolicitud = dr["FechaResultadoSolicitud"].ToString(),

                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(ServicioSocialBrindadoDTO servicioSocialBrindadoDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ServicioSocialBrindadoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FechaSolicitud", SqlDbType.Date);
                    cmd.Parameters["@FechaSolicitud"].Value = servicioSocialBrindadoDTO.FechaSolicitud;

                    cmd.Parameters.Add("@DNIPersonal", SqlDbType.VarChar, 8);
                    cmd.Parameters["@DNIPersonal"].Value = servicioSocialBrindadoDTO.DNIPersonal;

                    cmd.Parameters.Add("@CodigoPersonalSolicitante", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoPersonalSolicitante"].Value = servicioSocialBrindadoDTO.CodigoPersonalSolicitante;

                    cmd.Parameters.Add("@CodigoCondicionSolicitante", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCondicionSolicitante"].Value = servicioSocialBrindadoDTO.CodigoCondicionSolicitante;

                    cmd.Parameters.Add("@CodigoPersonalBeneficiado", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoPersonalBeneficiado"].Value = servicioSocialBrindadoDTO.CodigoPersonalBeneficiado;

                    cmd.Parameters.Add("@CodigoTipoApoyoSocial", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoApoyoSocial"].Value = servicioSocialBrindadoDTO.CodigoTipoApoyoSocial;

                    cmd.Parameters.Add("@CodigoTipoAtencion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoAtencion"].Value = servicioSocialBrindadoDTO.CodigoTipoAtencion;

                    cmd.Parameters.Add("@CodigoTipoEvaluacionSocial", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoEvaluacionSocial"].Value = servicioSocialBrindadoDTO.CodigoTipoEvaluacionSocial;

                    cmd.Parameters.Add("@OtroTipoApoyo", SqlDbType.VarChar,200);
                    cmd.Parameters["@OtroTipoApoyo"].Value = servicioSocialBrindadoDTO.OtroTipoApoyo;

                    cmd.Parameters.Add("@ResultadoSolicitud", SqlDbType.VarChar,100);
                    cmd.Parameters["@ResultadoSolicitud"].Value = servicioSocialBrindadoDTO.ResultadoSolicitud;

                    cmd.Parameters.Add("@FechaResultadoSolicitud", SqlDbType.Date);
                    cmd.Parameters["@FechaResultadoSolicitud"].Value = servicioSocialBrindadoDTO.FechaResultadoSolicitud;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = servicioSocialBrindadoDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = servicioSocialBrindadoDTO.UsuarioIngresoRegistro;

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

        public ServicioSocialBrindadoDTO BuscarFormato(int Codigo)
        {
            ServicioSocialBrindadoDTO servicioSocialBrindadoDTO = new ServicioSocialBrindadoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ServicioSocialBrindadoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ServicioSocialBrindadoId", SqlDbType.Int);
                    cmd.Parameters["@ServicioSocialBrindadoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        servicioSocialBrindadoDTO.ServicioSocialBrindadoId = Convert.ToInt32(dr["ServicioSocialBrindadoId"]);
                        servicioSocialBrindadoDTO.FechaSolicitud = Convert.ToDateTime(dr["FechaSolicitud"]).ToString("yyy-MM-dd");
                        servicioSocialBrindadoDTO.DNIPersonal = dr["DNIPersonal"].ToString();
                        servicioSocialBrindadoDTO.CodigoPersonalSolicitante = dr["CodigoPersonalSolicitante"].ToString();
                        servicioSocialBrindadoDTO.CodigoCondicionSolicitante = dr["CodigoCondicionSolicitante"].ToString();
                        servicioSocialBrindadoDTO.CodigoPersonalBeneficiado = dr["CodigoPersonalBeneficiado"].ToString();
                        servicioSocialBrindadoDTO.CodigoTipoApoyoSocial = dr["CodigoTipoApoyoSocial"].ToString();
                        servicioSocialBrindadoDTO.CodigoTipoAtencion = dr["CodigoTipoAtencion"].ToString();
                        servicioSocialBrindadoDTO.CodigoTipoEvaluacionSocial = dr["CodigoTipoEvaluacionSocial"].ToString();
                        servicioSocialBrindadoDTO.OtroTipoApoyo = dr["OtroTipoApoyo"].ToString();
                        servicioSocialBrindadoDTO.ResultadoSolicitud = dr["ResultadoSolicitud"].ToString();
                        servicioSocialBrindadoDTO.FechaResultadoSolicitud = Convert.ToDateTime(dr["FechaResultadoSolicitud"]).ToString("yyy-MM-dd"); 


                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return servicioSocialBrindadoDTO;
        }

        public string ActualizaFormato(ServicioSocialBrindadoDTO servicioSocialBrindadoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_ServicioSocialBrindadoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@ServicioSocialBrindadoId", SqlDbType.Int);
                    cmd.Parameters["@ServicioSocialBrindadoId"].Value = servicioSocialBrindadoDTO.ServicioSocialBrindadoId;

                    cmd.Parameters.Add("@FechaSolicitud", SqlDbType.Date);
                    cmd.Parameters["@FechaSolicitud"].Value = servicioSocialBrindadoDTO.FechaSolicitud;

                    cmd.Parameters.Add("@DNIPersonal", SqlDbType.VarChar, 8);
                    cmd.Parameters["@DNIPersonal"].Value = servicioSocialBrindadoDTO.DNIPersonal;

                    cmd.Parameters.Add("@CodigoPersonalSolicitante", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoPersonalSolicitante"].Value = servicioSocialBrindadoDTO.CodigoPersonalSolicitante;

                    cmd.Parameters.Add("@CodigoCondicionSolicitante", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCondicionSolicitante"].Value = servicioSocialBrindadoDTO.CodigoCondicionSolicitante;

                    cmd.Parameters.Add("@CodigoPersonalBeneficiado", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoPersonalBeneficiado"].Value = servicioSocialBrindadoDTO.CodigoPersonalBeneficiado;

                    cmd.Parameters.Add("@CodigoTipoApoyoSocial", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoApoyoSocial"].Value = servicioSocialBrindadoDTO.CodigoTipoApoyoSocial;

                    cmd.Parameters.Add("@CodigoTipoAtencion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoAtencion"].Value = servicioSocialBrindadoDTO.CodigoTipoAtencion;

                    cmd.Parameters.Add("@CodigoTipoEvaluacionSocial", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoEvaluacionSocial"].Value = servicioSocialBrindadoDTO.CodigoTipoEvaluacionSocial;

                    cmd.Parameters.Add("@OtroTipoApoyo", SqlDbType.VarChar,200);
                    cmd.Parameters["@OtroTipoApoyo"].Value = servicioSocialBrindadoDTO.OtroTipoApoyo;

                    cmd.Parameters.Add("@ResultadoSolicitud", SqlDbType.VarChar,100);
                    cmd.Parameters["@ResultadoSolicitud"].Value = servicioSocialBrindadoDTO.ResultadoSolicitud;

                    cmd.Parameters.Add("@FechaResultadoSolicitud", SqlDbType.Date);
                    cmd.Parameters["@FechaResultadoSolicitud"].Value = servicioSocialBrindadoDTO.FechaResultadoSolicitud;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = servicioSocialBrindadoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(ServicioSocialBrindadoDTO servicioSocialBrindadoDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ServicioSocialBrindadoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ServicioSocialBrindadoId", SqlDbType.Int);
                    cmd.Parameters["@ServicioSocialBrindadoId"].Value = servicioSocialBrindadoDTO.ServicioSocialBrindadoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = servicioSocialBrindadoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(ServicioSocialBrindadoDTO servicioSocialBrindadoDTO)
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
                    cmd.Parameters["@Formato"].Value = "ServicioSocialBrindado";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = servicioSocialBrindadoDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = servicioSocialBrindadoDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_ServicioSocialBrindadoRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ServicioSocialBrindado", SqlDbType.Structured);
                    cmd.Parameters["@ServicioSocialBrindado"].TypeName = "Formato.ServicioSocialBrindado";
                    cmd.Parameters["@ServicioSocialBrindado"].Value = datos;

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
