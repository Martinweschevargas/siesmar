using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Dipermar;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dipermar
{
    public class JuntaPermanenteTecnicoLegalDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<JuntaPermanenteTecnicoLegalDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<JuntaPermanenteTecnicoLegalDTO> lista = new List<JuntaPermanenteTecnicoLegalDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_JuntaPermanenteTecnicoLegalListar", conexion);
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
                        lista.Add(new JuntaPermanenteTecnicoLegalDTO()
                        {
                            JuntaPermanenteTecnicoLegalId = Convert.ToInt32(dr["JuntaPermanenteTecnicoLegalId"]),
                            NroDocumentoJunta = dr["NroDocumentoJunta"].ToString(),
                            FechaDocumentoJunta = (dr["FechaDocumentoJunta"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            DocumentacionCompleta = dr["DocumentacionCompleta"].ToString(),
                            FechaIngresoDocumento = (dr["FechaIngresoDocumento"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            DescTipoPersonalMilitar = dr["DescTipoPersonalMilitar"].ToString(),
                            DescGrado = dr["DescGrado"].ToString(),
                            SexoPersonal = dr["SexoPersonal"].ToString(),
                            DescAfeccion = dr["DescAfeccion"].ToString(),
                            SituacionActualJunta = dr["SituacionActualJunta"].ToString(),
                            NroActa = dr["NroActa"].ToString(),
                            FechaActa = (dr["FechaActa"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            ConclusionJunta = dr["ConclusionJunta"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"])


                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(JuntaPermanenteTecnicoLegalDTO juntaPermanenteTecnicoLegalDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_JuntaPermanenteTecnicoLegalRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@NroDocumentoJunta", SqlDbType.VarChar,50);
                    cmd.Parameters["@NroDocumentoJunta"].Value = juntaPermanenteTecnicoLegalDTO.NroDocumentoJunta;

                    cmd.Parameters.Add("@FechaDocumentoJunta", SqlDbType.Date);
                    cmd.Parameters["@FechaDocumentoJunta"].Value = juntaPermanenteTecnicoLegalDTO.FechaDocumentoJunta;

                    cmd.Parameters.Add("@DocumentacionCompleta", SqlDbType.NChar,1);
                    cmd.Parameters["@DocumentacionCompleta"].Value = juntaPermanenteTecnicoLegalDTO.DocumentacionCompleta;

                    cmd.Parameters.Add("@FechaIngresoDocumento", SqlDbType.Date);
                    cmd.Parameters["@FechaIngresoDocumento"].Value = juntaPermanenteTecnicoLegalDTO.FechaIngresoDocumento;

                    cmd.Parameters.Add("@CodigoTipoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoPersonalMilitar"].Value = juntaPermanenteTecnicoLegalDTO.CodigoTipoPersonalMilitar;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitar"].Value = juntaPermanenteTecnicoLegalDTO.CodigoGradoPersonalMilitar;

                    cmd.Parameters.Add("@SexoPersonal", SqlDbType.VarChar, 20);
                    cmd.Parameters["@SexoPersonal"].Value = juntaPermanenteTecnicoLegalDTO.SexoPersonal;

                    cmd.Parameters.Add("@CodigoAfeccion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoAfeccion"].Value = juntaPermanenteTecnicoLegalDTO.CodigoAfeccion;

                    cmd.Parameters.Add("@SituacionActualJunta", SqlDbType.VarChar,15);
                    cmd.Parameters["@SituacionActualJunta"].Value = juntaPermanenteTecnicoLegalDTO.SituacionActualJunta;

                    cmd.Parameters.Add("@NroActa", SqlDbType.VarChar,10);
                    cmd.Parameters["@NroActa"].Value = juntaPermanenteTecnicoLegalDTO.NroActa;

                    cmd.Parameters.Add("@FechaActa", SqlDbType.Date);
                    cmd.Parameters["@FechaActa"].Value = juntaPermanenteTecnicoLegalDTO.FechaActa;

                    cmd.Parameters.Add("@ConclusionJunta", SqlDbType.VarChar,50);
                    cmd.Parameters["@ConclusionJunta"].Value = juntaPermanenteTecnicoLegalDTO.ConclusionJunta;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = juntaPermanenteTecnicoLegalDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = juntaPermanenteTecnicoLegalDTO.UsuarioIngresoRegistro;

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
        public JuntaPermanenteTecnicoLegalDTO BuscarFormato(int Codigo)
        {
            JuntaPermanenteTecnicoLegalDTO juntaPermanenteTecnicoLegalDTO = new JuntaPermanenteTecnicoLegalDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_JuntaPermanenteTecnicoLegalEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@JuntaPermanenteTecnicoLegalId", SqlDbType.Int);
                    cmd.Parameters["@JuntaPermanenteTecnicoLegalId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        juntaPermanenteTecnicoLegalDTO.JuntaPermanenteTecnicoLegalId = Convert.ToInt32(dr["JuntaPermanenteTecnicoLegalId"]);
                        juntaPermanenteTecnicoLegalDTO.NroDocumentoJunta = dr["NroDocumentoJunta"].ToString();
                        juntaPermanenteTecnicoLegalDTO.FechaDocumentoJunta = Convert.ToDateTime(dr["FechaDocumentoJunta"]).ToString("yyy-MM-dd");
                        juntaPermanenteTecnicoLegalDTO.DocumentacionCompleta = dr["DocumentacionCompleta"].ToString();
                        juntaPermanenteTecnicoLegalDTO.FechaIngresoDocumento = Convert.ToDateTime(dr["FechaIngresoDocumento"]).ToString("yyy-MM-dd");
                        juntaPermanenteTecnicoLegalDTO.CodigoTipoPersonalMilitar = dr["CodigoTipoPersonalMilitar"].ToString();
                        juntaPermanenteTecnicoLegalDTO.CodigoGradoPersonalMilitar = dr["CodigoGradoPersonalMilitar"].ToString();
                        juntaPermanenteTecnicoLegalDTO.SexoPersonal = dr["SexoPersonal"].ToString();
                        juntaPermanenteTecnicoLegalDTO.CodigoAfeccion = dr["CodigoAfeccion"].ToString();
                        juntaPermanenteTecnicoLegalDTO.SituacionActualJunta = dr["SituacionActualJunta"].ToString();
                        juntaPermanenteTecnicoLegalDTO.NroActa = dr["NroActa"].ToString();
                        juntaPermanenteTecnicoLegalDTO.FechaActa = Convert.ToDateTime(dr["FechaActa"]).ToString("yyy-MM-dd");
                        juntaPermanenteTecnicoLegalDTO.ConclusionJunta = dr["ConclusionJunta"].ToString(); 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return juntaPermanenteTecnicoLegalDTO;
        }

        public string ActualizaFormato(JuntaPermanenteTecnicoLegalDTO juntaPermanenteTecnicoLegalDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_JuntaPermanenteTecnicoLegalActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@JuntaPermanenteTecnicoLegalId", SqlDbType.Int);
                    cmd.Parameters["@JuntaPermanenteTecnicoLegalId"].Value = juntaPermanenteTecnicoLegalDTO.JuntaPermanenteTecnicoLegalId;

                    cmd.Parameters.Add("@NroDocumentoJunta", SqlDbType.VarChar, 10);
                    cmd.Parameters["@NroDocumentoJunta"].Value = juntaPermanenteTecnicoLegalDTO.NroDocumentoJunta;

                    cmd.Parameters.Add("@FechaDocumentoJunta", SqlDbType.Date);
                    cmd.Parameters["@FechaDocumentoJunta"].Value = juntaPermanenteTecnicoLegalDTO.FechaDocumentoJunta;

                    cmd.Parameters.Add("@DocumentacionCompleta", SqlDbType.NChar, 1);
                    cmd.Parameters["@DocumentacionCompleta"].Value = juntaPermanenteTecnicoLegalDTO.DocumentacionCompleta;

                    cmd.Parameters.Add("@FechaIngresoDocumento", SqlDbType.Date);
                    cmd.Parameters["@FechaIngresoDocumento"].Value = juntaPermanenteTecnicoLegalDTO.FechaIngresoDocumento;

                    cmd.Parameters.Add("@CodigoTipoPersonalMilitar", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoTipoPersonalMilitar"].Value = juntaPermanenteTecnicoLegalDTO.CodigoTipoPersonalMilitar;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitar"].Value = juntaPermanenteTecnicoLegalDTO.CodigoGradoPersonalMilitar;

                    cmd.Parameters.Add("@SexoPersonal", SqlDbType.VarChar, 10);
                    cmd.Parameters["@SexoPersonal"].Value = juntaPermanenteTecnicoLegalDTO.SexoPersonal;

                    cmd.Parameters.Add("@CodigoAfeccion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoAfeccion"].Value = juntaPermanenteTecnicoLegalDTO.CodigoAfeccion;

                    cmd.Parameters.Add("@SituacionActualJunta", SqlDbType.VarChar, 15);
                    cmd.Parameters["@SituacionActualJunta"].Value = juntaPermanenteTecnicoLegalDTO.SituacionActualJunta;

                    cmd.Parameters.Add("@NroActa", SqlDbType.VarChar, 10);
                    cmd.Parameters["@NroActa"].Value = juntaPermanenteTecnicoLegalDTO.NroActa;

                    cmd.Parameters.Add("@FechaActa", SqlDbType.Date);
                    cmd.Parameters["@FechaActa"].Value = juntaPermanenteTecnicoLegalDTO.FechaActa;

                    cmd.Parameters.Add("@ConclusionJunta", SqlDbType.VarChar, 50);
                    cmd.Parameters["@ConclusionJunta"].Value = juntaPermanenteTecnicoLegalDTO.ConclusionJunta;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = juntaPermanenteTecnicoLegalDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(JuntaPermanenteTecnicoLegalDTO juntaPermanenteTecnicoLegalDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_JuntaPermanenteTecnicoLegalEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@JuntaPermanenteTecnicoLegalId", SqlDbType.Int);
                    cmd.Parameters["@JuntaPermanenteTecnicoLegalId"].Value = juntaPermanenteTecnicoLegalDTO.JuntaPermanenteTecnicoLegalId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = juntaPermanenteTecnicoLegalDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(JuntaPermanenteTecnicoLegalDTO juntaPermanenteTecnicoLegalDTO)
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
                    cmd.Parameters["@Formato"].Value = "JuntaPermanenteTecnicoLegal";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = juntaPermanenteTecnicoLegalDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = juntaPermanenteTecnicoLegalDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_JuntaPermanenteTecnicoLegalRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@JuntaPermanenteTecnicoLegal", SqlDbType.Structured);
                    cmd.Parameters["@JuntaPermanenteTecnicoLegal"].TypeName = "Formato.JuntaPermanenteTecnicoLegal";
                    cmd.Parameters["@JuntaPermanenteTecnicoLegal"].Value = datos;

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
