using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Bienestar;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Bienestar
{
    public class ConvenioUniversidadInstitutoDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<ConvenioUniversidadInstitutoDTO> ObtenerLista(int? CargaId = null, string? fechaInicio = null, string? fechaFin = null)
        {
            List<ConvenioUniversidadInstitutoDTO> lista = new List<ConvenioUniversidadInstitutoDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_ConvenioUniversidadInstitutoListar", conexion);
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
                        lista.Add(new ConvenioUniversidadInstitutoDTO()
                        {
                            ConvenioUniversidadInstitutoId = Convert.ToInt32(dr["ConvenioUniversidadInstitutoId"]),
                            FechaSolicitudConvenio = (dr["FechaSolicitudConvenio"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            DNISolicitante = dr["DNISolicitante"].ToString(),
                            DescPersonalSolicitante = dr["DescPersonalSolicitante"].ToString(),
                            DescCondicionSolicitante = dr["DescCondicionSolicitante"].ToString(),
                            DescGrado = dr["DescGrado"].ToString(),
                            DescPersonalBeneficiado = dr["DescPersonalBeneficiado"].ToString(),
                            NivelEstudioConvenio = dr["NivelEstudioConvenio"].ToString(),
                            TipoEntidadAcademica = dr["TipoEntidadAcademica"].ToString(),
                            DescInstitucionEducativaSuperior = dr["DescInstitucionEducativaSuperior"].ToString(),
                            ResultadoSolicitud = dr["ResultadoSolicitud"].ToString(),
                            FechaResultadoSolicitud = (dr["FechaResultadoSolicitud"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            CargaId = Convert.ToInt32(dr["CargaId"]),
                        });
                    }
                }
            }
            return lista;
        }

        public List<ConvenioUniversidadInstitutoDTO> BienestarVisualizacionConvenioUniversidadInstituto(int? CargaId=null, string? fechaInicio = null, string? fechaFin = null)
        {
            List<ConvenioUniversidadInstitutoDTO> lista = new List<ConvenioUniversidadInstitutoDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Reporte.usp_BienestarVisualizacionConvenioUniversidadInstituto", conexion);
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
                        lista.Add(new ConvenioUniversidadInstitutoDTO()
                        {
                            FechaSolicitudConvenio = dr["FechaSolicitudConvenio"].ToString(),
                            DNISolicitante = dr["DNISolicitante"].ToString(),
                            DescPersonalSolicitante = dr["DescPersonalSolicitante"].ToString(),
                            NivelEstudioConvenio = dr["NivelEstudioConvenio"].ToString(),
                            TipoEntidadAcademica = dr["TipoEntidadAcademica"].ToString(),
                            DescInstitucionEducativaSuperior = dr["DescInstitucionEducativaSuperior"].ToString(),
                            ResultadoSolicitud = dr["ResultadoSolicitud"].ToString(),
                            FechaResultadoSolicitud = dr["FechaResultadoSolicitud"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(ConvenioUniversidadInstitutoDTO conveniosUniversidadesInstitutosDTO, string fechaCarga)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ConvenioUniversidadInstitutoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FechaSolicitudConvenio", SqlDbType.Date);
                    cmd.Parameters["@FechaSolicitudConvenio"].Value = conveniosUniversidadesInstitutosDTO.FechaSolicitudConvenio;

                    cmd.Parameters.Add("@DNISolicitante", SqlDbType.VarChar, 8);
                    cmd.Parameters["@DNISolicitante"].Value = conveniosUniversidadesInstitutosDTO.DNISolicitante;

                    cmd.Parameters.Add("@CodigoPersonalSolicitante", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoPersonalSolicitante"].Value = conveniosUniversidadesInstitutosDTO.CodigoPersonalSolicitante;

                    cmd.Parameters.Add("@CodigoCondicionSolicitante", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCondicionSolicitante"].Value = conveniosUniversidadesInstitutosDTO.CodigoCondicionSolicitante;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitar"].Value = conveniosUniversidadesInstitutosDTO.CodigoGradoPersonalMilitar;

                    cmd.Parameters.Add("@CodigoPersonalBeneficiado", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoPersonalBeneficiado"].Value = conveniosUniversidadesInstitutosDTO.CodigoPersonalBeneficiado;

                    cmd.Parameters.Add("@NivelEstudioConvenio", SqlDbType.VarChar,20);
                    cmd.Parameters["@NivelEstudioConvenio"].Value = conveniosUniversidadesInstitutosDTO.NivelEstudioConvenio;

                    cmd.Parameters.Add("@TipoEntidadAcademica", SqlDbType.VarChar,20);
                    cmd.Parameters["@TipoEntidadAcademica"].Value = conveniosUniversidadesInstitutosDTO.TipoEntidadAcademica;

                    cmd.Parameters.Add("@CodigoInstitucionEducativaSuperior", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoInstitucionEducativaSuperior"].Value = conveniosUniversidadesInstitutosDTO.CodigoInstitucionEducativaSuperior;

                    cmd.Parameters.Add("@ResultadoSolicitud", SqlDbType.VarChar,50);
                    cmd.Parameters["@ResultadoSolicitud"].Value = conveniosUniversidadesInstitutosDTO.ResultadoSolicitud;

                    cmd.Parameters.Add("@FechaResultadoSolicitud", SqlDbType.Date);
                    cmd.Parameters["@FechaResultadoSolicitud"].Value = conveniosUniversidadesInstitutosDTO.FechaResultadoSolicitud;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = conveniosUniversidadesInstitutosDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = conveniosUniversidadesInstitutosDTO.UsuarioIngresoRegistro;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Mac"].Value = UtilitariosGlobales.obtenerDireccionMac();

                    cmd.Parameters.Add("@FechaCarga", SqlDbType.Date);
                    cmd.Parameters["@FechaCarga"].Value = fechaCarga;

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

        public ConvenioUniversidadInstitutoDTO BuscarFormato(int Codigo)
        {
            ConvenioUniversidadInstitutoDTO conveniosUniversidadesInstitutosDTO = new ConvenioUniversidadInstitutoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ConvenioUniversidadInstitutoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ConvenioUniversidadInstitutoId", SqlDbType.Int);
                    cmd.Parameters["@ConvenioUniversidadInstitutoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        conveniosUniversidadesInstitutosDTO.ConvenioUniversidadInstitutoId = Convert.ToInt32(dr["ConvenioUniversidadInstitutoId"]);
                        conveniosUniversidadesInstitutosDTO.FechaSolicitudConvenio = Convert.ToDateTime(dr["FechaSolicitudConvenio"]).ToString("yyy-MM-dd");
                        conveniosUniversidadesInstitutosDTO.DNISolicitante = dr["DNISolicitante"].ToString();
                        conveniosUniversidadesInstitutosDTO.CodigoPersonalSolicitante = dr["CodigoPersonalSolicitante"].ToString();
                        conveniosUniversidadesInstitutosDTO.CodigoCondicionSolicitante = dr["CodigoCondicionSolicitante"].ToString();
                        conveniosUniversidadesInstitutosDTO.CodigoGradoPersonalMilitar = dr["CodigoGradoPersonalMilitar"].ToString();
                        conveniosUniversidadesInstitutosDTO.CodigoPersonalBeneficiado = dr["CodigoPersonalBeneficiado"].ToString();
                        conveniosUniversidadesInstitutosDTO.NivelEstudioConvenio = dr["NivelEstudioConvenio"].ToString();
                        conveniosUniversidadesInstitutosDTO.TipoEntidadAcademica = dr["TipoEntidadAcademica"].ToString();
                        conveniosUniversidadesInstitutosDTO.CodigoInstitucionEducativaSuperior = dr["CodigoInstitucionEducativaSuperior"].ToString();
                        conveniosUniversidadesInstitutosDTO.ResultadoSolicitud = dr["ResultadoSolicitud"].ToString();
                        conveniosUniversidadesInstitutosDTO.FechaResultadoSolicitud = Convert.ToDateTime(dr["FechaResultadoSolicitud"]).ToString("yyy-MM-dd"); 


                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return conveniosUniversidadesInstitutosDTO;
        }

        public string ActualizaFormato(ConvenioUniversidadInstitutoDTO conveniosUniversidadesInstitutosDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_ConvenioUniversidadInstitutoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@ConvenioUniversidadInstitutoId", SqlDbType.Int);
                    cmd.Parameters["@ConvenioUniversidadInstitutoId"].Value = conveniosUniversidadesInstitutosDTO.ConvenioUniversidadInstitutoId;

                    cmd.Parameters.Add("@FechaSolicitudConvenio", SqlDbType.Date);
                    cmd.Parameters["@FechaSolicitudConvenio"].Value = conveniosUniversidadesInstitutosDTO.FechaSolicitudConvenio;

                    cmd.Parameters.Add("@DNISolicitante", SqlDbType.VarChar, 8);
                    cmd.Parameters["@DNISolicitante"].Value = conveniosUniversidadesInstitutosDTO.DNISolicitante;

                    cmd.Parameters.Add("@CodigoPersonalSolicitante", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoPersonalSolicitante"].Value = conveniosUniversidadesInstitutosDTO.CodigoPersonalSolicitante;

                    cmd.Parameters.Add("@CodigoCondicionSolicitante", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCondicionSolicitante"].Value = conveniosUniversidadesInstitutosDTO.CodigoCondicionSolicitante;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitar"].Value = conveniosUniversidadesInstitutosDTO.CodigoGradoPersonalMilitar;

                    cmd.Parameters.Add("@CodigoPersonalBeneficiado", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoPersonalBeneficiado"].Value = conveniosUniversidadesInstitutosDTO.CodigoPersonalBeneficiado;

                    cmd.Parameters.Add("@NivelEstudioConvenio", SqlDbType.VarChar, 20);
                    cmd.Parameters["@NivelEstudioConvenio"].Value = conveniosUniversidadesInstitutosDTO.NivelEstudioConvenio;

                    cmd.Parameters.Add("@TipoEntidadAcademica", SqlDbType.VarChar, 20);
                    cmd.Parameters["@TipoEntidadAcademica"].Value = conveniosUniversidadesInstitutosDTO.TipoEntidadAcademica;

                    cmd.Parameters.Add("@CodigoInstitucionEducativaSuperior", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoInstitucionEducativaSuperior"].Value = conveniosUniversidadesInstitutosDTO.CodigoInstitucionEducativaSuperior;

                    cmd.Parameters.Add("@ResultadoSolicitud", SqlDbType.VarChar,50);
                    cmd.Parameters["@ResultadoSolicitud"].Value = conveniosUniversidadesInstitutosDTO.ResultadoSolicitud;

                    cmd.Parameters.Add("@FechaResultadoSolicitud", SqlDbType.Date);
                    cmd.Parameters["@FechaResultadoSolicitud"].Value = conveniosUniversidadesInstitutosDTO.FechaResultadoSolicitud;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = conveniosUniversidadesInstitutosDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(ConvenioUniversidadInstitutoDTO conveniosUniversidadesInstitutosDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ConvenioUniversidadInstitutoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ConvenioUniversidadInstitutoId", SqlDbType.Int);
                    cmd.Parameters["@ConvenioUniversidadInstitutoId"].Value = conveniosUniversidadesInstitutosDTO.ConvenioUniversidadInstitutoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = conveniosUniversidadesInstitutosDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(ConvenioUniversidadInstitutoDTO conveniosUniversidadesInstitutosDTO)
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
                    cmd.Parameters["@Formato"].Value = "ConvenioUniversidadInstituto";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = conveniosUniversidadesInstitutosDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = conveniosUniversidadesInstitutosDTO.UsuarioIngresoRegistro;

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

        public string InsertarDatos(DataTable datos, string fechaCarga)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("Formato.usp_ConvenioUniversidadInstitutoRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ConvenioUniversidadInstituto", SqlDbType.Structured);
                    cmd.Parameters["@ConvenioUniversidadInstituto"].TypeName = "Formato.ConvenioUniversidadInstituto";
                    cmd.Parameters["@ConvenioUniversidadInstituto"].Value = datos;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Mac"].Value = UtilitariosGlobales.obtenerDireccionMac();

                    cmd.Parameters.Add("@FechaCarga", SqlDbType.Date);
                    cmd.Parameters["@FechaCarga"].Value = fechaCarga;

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
