using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Bienestar;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Utilitarios;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Bienestar
{
    public class ServicioViviendaPrestadaDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<ServicioViviendaPrestadaDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<ServicioViviendaPrestadaDTO> lista = new List<ServicioViviendaPrestadaDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_ServicioViviendaPrestadaListar", conexion);
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
                        lista.Add(new ServicioViviendaPrestadaDTO()
                        {
                            ServicioViviendaPrestadaId = Convert.ToInt32(dr["ServicioViviendaPrestadaId"]),
                            CIPBeneficiario = dr["CIPBeneficiario"].ToString(),
                            DNIBeneficiario = dr["DNIBeneficiario"].ToString(),
                            DescGrado = dr["DescGrado"].ToString(),
                            FechaSolicitud = (dr["FechaSolicitud"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            EstadoSolicitud = dr["EstadoSolicitud"].ToString(),
                            DescVillaNaval = dr["DescVillaNaval"].ToString(),
                            DescBlockVillaNaval = dr["DescBlockVillaNaval"].ToString(),
                            NumeroDepartamento = Convert.ToInt32(dr["NumeroDepartamento"]),
                            FechaEntregaVivienda = (dr["FechaEntregaVivienda"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            DescTipoAsignacionCasaServicio = dr["DescTipoAsignacionCasaServicio"].ToString(),
                            PeriodoPermanencia = dr["PeriodoPermanencia"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"]),
                        });
                    }
                }
            }
            return lista;
        }

        public List<ServicioViviendaPrestadaDTO> BienestarVisualizacionServicioViviendaPrestada(int? CargaId=null, string fechaInicio=null, string fechaFin=null)
        {
            List<ServicioViviendaPrestadaDTO> lista = new List<ServicioViviendaPrestadaDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Reporte.usp_BienestarVisualizacionServicioViviendaPrestada", conexion);
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
                        lista.Add(new ServicioViviendaPrestadaDTO()
                        {
                            CIPBeneficiario = dr["CIPBeneficiario"].ToString(),
                            DNIBeneficiario = dr["DNIBeneficiario"].ToString(),
                            DescGrado = dr["DescGrado"].ToString(),
                            FechaSolicitud = dr["FechaSolicitud"].ToString(),
                            EstadoSolicitud = dr["EstadoSolicitud"].ToString(),
                            DescVillaNaval = dr["DescVillaNaval"].ToString(),
                            DescBlockVillaNaval = dr["DescBlockVillaNaval"].ToString(),
                            NumeroDepartamento = Convert.ToInt32(dr["NumeroDepartamento"]),
                            FechaEntregaVivienda = dr["FechaEntregaVivienda"].ToString(),
                            DescTipoAsignacionCasaServicio = dr["DescTipoAsignacionCasaServicio"].ToString(),
                            PeriodoPermanencia = dr["PeriodoPermanencia"].ToString(),

                        });
                    }
                }
            }
            return lista;
        }
        public string AgregarRegistro(ServicioViviendaPrestadaDTO servicioViviendaPrestadaDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ServicioViviendaPrestadaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CIPBeneficiario", SqlDbType.VarChar, 8);
                    cmd.Parameters["@CIPBeneficiario"].Value = servicioViviendaPrestadaDTO.CIPBeneficiario;

                    cmd.Parameters.Add("@DNIBeneficiario", SqlDbType.VarChar, 8);
                    cmd.Parameters["@DNIBeneficiario"].Value = servicioViviendaPrestadaDTO.DNIBeneficiario;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitar"].Value = servicioViviendaPrestadaDTO.CodigoGradoPersonalMilitar;

                    cmd.Parameters.Add("@FechaSolicitud", SqlDbType.Date);
                    cmd.Parameters["@FechaSolicitud"].Value = servicioViviendaPrestadaDTO.FechaSolicitud;

                    cmd.Parameters.Add("@EstadoSolicitud", SqlDbType.VarChar,20);
                    cmd.Parameters["@EstadoSolicitud"].Value = servicioViviendaPrestadaDTO.EstadoSolicitud;

                    cmd.Parameters.Add("@CodigoVillaNaval", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoVillaNaval"].Value = servicioViviendaPrestadaDTO.CodigoVillaNaval;

                    cmd.Parameters.Add("@CodigoBlockVillaNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoBlockVillaNaval"].Value = servicioViviendaPrestadaDTO.CodigoBlockVillaNaval;

                    cmd.Parameters.Add("@NumeroDepartamento", SqlDbType.Int);
                    cmd.Parameters["@NumeroDepartamento"].Value = servicioViviendaPrestadaDTO.NumeroDepartamento;

                    cmd.Parameters.Add("@FechaEntregaVivienda", SqlDbType.Date);
                    cmd.Parameters["@FechaEntregaVivienda"].Value = servicioViviendaPrestadaDTO.FechaEntregaVivienda;

                    cmd.Parameters.Add("@CodigoTipoAsignacionCasaServicio", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoAsignacionCasaServicio"].Value = servicioViviendaPrestadaDTO.CodigoTipoAsignacionCasaServicio;

                    cmd.Parameters.Add("@PeriodoPermanencia", SqlDbType.VarChar);
                    cmd.Parameters["@PeriodoPermanencia"].Value = servicioViviendaPrestadaDTO.PeriodoPermanencia;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = servicioViviendaPrestadaDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = servicioViviendaPrestadaDTO.UsuarioIngresoRegistro;

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

        public ServicioViviendaPrestadaDTO BuscarFormato(int Codigo)
        {
            ServicioViviendaPrestadaDTO servicioViviendaPrestadaDTO = new ServicioViviendaPrestadaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ServicioViviendaPrestadaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ServicioViviendaPrestadaId", SqlDbType.Int);
                    cmd.Parameters["@ServicioViviendaPrestadaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        servicioViviendaPrestadaDTO.ServicioViviendaPrestadaId = Convert.ToInt32(dr["ServicioViviendaPrestadaId"]);
                        servicioViviendaPrestadaDTO.CIPBeneficiario = dr["CIPBeneficiario"].ToString();
                        servicioViviendaPrestadaDTO.DNIBeneficiario = dr["DNIBeneficiario"].ToString();
                        servicioViviendaPrestadaDTO.CodigoGradoPersonalMilitar = dr["CodigoGradoPersonalMilitar"].ToString();
                        servicioViviendaPrestadaDTO.FechaSolicitud = Convert.ToDateTime(dr["FechaSolicitud"]).ToString("yyy-MM-dd");
                        servicioViviendaPrestadaDTO.EstadoSolicitud = dr["EstadoSolicitud"].ToString();
                        servicioViviendaPrestadaDTO.CodigoVillaNaval = dr["CodigoVillaNaval"].ToString();
                        servicioViviendaPrestadaDTO.CodigoBlockVillaNaval = dr["CodigoBlockVillaNaval"].ToString();
                        servicioViviendaPrestadaDTO.NumeroDepartamento = Convert.ToInt32(dr["NumeroDepartamento"]);
                        servicioViviendaPrestadaDTO.FechaEntregaVivienda = Convert.ToDateTime(dr["FechaEntregaVivienda"]).ToString("yyy-MM-dd");
                        servicioViviendaPrestadaDTO.CodigoTipoAsignacionCasaServicio = dr["CodigoTipoAsignacionCasaServicio"].ToString();
                        servicioViviendaPrestadaDTO.PeriodoPermanencia = dr["PeriodoPermanencia"].ToString();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return servicioViviendaPrestadaDTO;
        }

        public string ActualizaFormato(ServicioViviendaPrestadaDTO servicioViviendaPrestadaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_ServicioViviendaPrestadaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ServicioViviendaPrestadaId", SqlDbType.Int);
                    cmd.Parameters["@ServicioViviendaPrestadaId"].Value = servicioViviendaPrestadaDTO.ServicioViviendaPrestadaId;

                    cmd.Parameters.Add("@CIPBeneficiario", SqlDbType.VarChar, 8);
                    cmd.Parameters["@CIPBeneficiario"].Value = servicioViviendaPrestadaDTO.CIPBeneficiario;

                    cmd.Parameters.Add("@DNIBeneficiario", SqlDbType.VarChar, 8);
                    cmd.Parameters["@DNIBeneficiario"].Value = servicioViviendaPrestadaDTO.DNIBeneficiario;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitar", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoGradoPersonalMilitar"].Value = servicioViviendaPrestadaDTO.CodigoGradoPersonalMilitar;

                    cmd.Parameters.Add("@FechaSolicitud", SqlDbType.Date);
                    cmd.Parameters["@FechaSolicitud"].Value = servicioViviendaPrestadaDTO.FechaSolicitud;

                    cmd.Parameters.Add("@EstadoSolicitud", SqlDbType.VarChar,20);
                    cmd.Parameters["@EstadoSolicitud"].Value = servicioViviendaPrestadaDTO.EstadoSolicitud;

                    cmd.Parameters.Add("@CodigoVillaNaval", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoVillaNaval"].Value = servicioViviendaPrestadaDTO.CodigoVillaNaval;

                    cmd.Parameters.Add("@CodigoBlockVillaNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoBlockVillaNaval"].Value = servicioViviendaPrestadaDTO.CodigoBlockVillaNaval;

                    cmd.Parameters.Add("@NumeroDepartamento", SqlDbType.Int);
                    cmd.Parameters["@NumeroDepartamento"].Value = servicioViviendaPrestadaDTO.NumeroDepartamento;

                    cmd.Parameters.Add("@FechaEntregaVivienda", SqlDbType.Date);
                    cmd.Parameters["@FechaEntregaVivienda"].Value = servicioViviendaPrestadaDTO.FechaEntregaVivienda;

                    cmd.Parameters.Add("@CodigoTipoAsignacionCasaServicio", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoAsignacionCasaServicio"].Value = servicioViviendaPrestadaDTO.CodigoTipoAsignacionCasaServicio;

                    cmd.Parameters.Add("@PeriodoPermanencia", SqlDbType.VarChar);
                    cmd.Parameters["@PeriodoPermanencia"].Value = servicioViviendaPrestadaDTO.PeriodoPermanencia;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = servicioViviendaPrestadaDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(ServicioViviendaPrestadaDTO servicioViviendaPrestadaDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ServicioViviendaPrestadaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ServicioViviendaPrestadaId", SqlDbType.Int);
                    cmd.Parameters["@ServicioViviendaPrestadaId"].Value = servicioViviendaPrestadaDTO.ServicioViviendaPrestadaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = servicioViviendaPrestadaDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(ServicioViviendaPrestadaDTO servicioViviendaPrestadaDTO)
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
                    cmd.Parameters["@Formato"].Value = "ServicioViviendaPrestada";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = servicioViviendaPrestadaDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = servicioViviendaPrestadaDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_ServicioViviendaPrestadaRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ServicioViviendaPrestada", SqlDbType.Structured);
                    cmd.Parameters["@ServicioViviendaPrestada"].TypeName = "Formato.ServicioViviendaPrestada";
                    cmd.Parameters["@ServicioViviendaPrestada"].Value = datos;

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
