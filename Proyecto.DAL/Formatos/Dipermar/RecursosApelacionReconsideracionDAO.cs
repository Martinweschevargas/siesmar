using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Dipermar;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dipermar
{
    public class RecursosApelacionReconsideracionDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<RecursosApelacionReconsideracionDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<RecursosApelacionReconsideracionDTO> lista = new List<RecursosApelacionReconsideracionDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_RecursosApelacionReconsideracionListar", conexion);
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
                        lista.Add(new RecursosApelacionReconsideracionDTO()
                        {
                            RecursoApelacionReconsideracionId = Convert.ToInt32(dr["RecursoApelacionReconsideracionId"]),
                            NroDocumento = dr["NroDocumento"].ToString(),
                            FechaDocumento = (dr["FechaDocumento"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            NombreDependencia = dr["NombreDependencia"].ToString(),
                            FechaIngresoDocumento = (dr["FechaIngresoDocumento"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            DescGrado = dr["DescGrado"].ToString(),
                            TipoRecurso = dr["TipoRecurso"].ToString(),
                            DescAsuntoApelacionReconsideracion = dr["DescAsuntoApelacionReconsideracion"].ToString(),
                            DescripcionApelacion = dr["DescripcionApelacion"].ToString(),
                            DescResultadoApelacionReconsideracion = dr["DescResultadoApelacionReconsideracion"].ToString(),
                            DocumentoResolutivo = dr["DocumentoResolutivo"].ToString(),
                            FechaDocumentoResolutivo = (dr["FechaDocumentoResolutivo"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            FechaNotificacion = (dr["FechaNotificacion"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            CargaId = Convert.ToInt32(dr["CargaId"])


                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(RecursosApelacionReconsideracionDTO recursosApelacionReconsideracionDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_RecursosApelacionReconsideracionRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@NroDocumento", SqlDbType.VarChar,10);
                    cmd.Parameters["@NroDocumento"].Value = recursosApelacionReconsideracionDTO.NroDocumento;

                    cmd.Parameters.Add("@FechaDocumento", SqlDbType.Date);
                    cmd.Parameters["@FechaDocumento"].Value = recursosApelacionReconsideracionDTO.FechaDocumento;

                    cmd.Parameters.Add("@CodigoDependencia", SqlDbType.VarChar,20); 
                    cmd.Parameters["@CodigoDependencia"].Value = recursosApelacionReconsideracionDTO.CodigoDependencia;

                    cmd.Parameters.Add("@FechaIngresoDocumento", SqlDbType.Date);
                    cmd.Parameters["@FechaIngresoDocumento"].Value = recursosApelacionReconsideracionDTO.FechaIngresoDocumento;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitar"].Value = recursosApelacionReconsideracionDTO.CodigoGradoPersonalMilitar;

                    cmd.Parameters.Add("@TipoRecurso", SqlDbType.VarChar,50);
                    cmd.Parameters["@TipoRecurso"].Value = recursosApelacionReconsideracionDTO.TipoRecurso;

                    cmd.Parameters.Add("@CodigoAsuntoApelacionReconsideracion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoAsuntoApelacionReconsideracion"].Value = recursosApelacionReconsideracionDTO.CodigoAsuntoApelacionReconsideracion;

                    cmd.Parameters.Add("@DescripcionApelacion", SqlDbType.VarChar,260);
                    cmd.Parameters["@DescripcionApelacion"].Value = recursosApelacionReconsideracionDTO.DescripcionApelacion;

                    cmd.Parameters.Add("@CodigoResultadoApelacionReconsideracion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoResultadoApelacionReconsideracion"].Value = recursosApelacionReconsideracionDTO.CodigoResultadoApelacionReconsideracion;

                    cmd.Parameters.Add("@DocumentoResolutivo", SqlDbType.VarChar,50);
                    cmd.Parameters["@DocumentoResolutivo"].Value = recursosApelacionReconsideracionDTO.DocumentoResolutivo;

                    cmd.Parameters.Add("@FechaDocumentoResolutivo", SqlDbType.Date);
                    cmd.Parameters["@FechaDocumentoResolutivo"].Value = recursosApelacionReconsideracionDTO.FechaDocumentoResolutivo;

                    cmd.Parameters.Add("@FechaNotificacion", SqlDbType.Date);
                    cmd.Parameters["@FechaNotificacion"].Value = recursosApelacionReconsideracionDTO.FechaNotificacion;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = recursosApelacionReconsideracionDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = recursosApelacionReconsideracionDTO.UsuarioIngresoRegistro;

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
        public RecursosApelacionReconsideracionDTO BuscarFormato(int Codigo)
        {
            RecursosApelacionReconsideracionDTO recursosApelacionReconsideracionDTO = new RecursosApelacionReconsideracionDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_RecursosApelacionReconsideracionEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RecursoApelacionReconsideracionId", SqlDbType.Int);
                    cmd.Parameters["@RecursoApelacionReconsideracionId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        recursosApelacionReconsideracionDTO.RecursoApelacionReconsideracionId = Convert.ToInt32(dr["RecursoApelacionReconsideracionId"]);
                        recursosApelacionReconsideracionDTO.NroDocumento = dr["NroDocumento"].ToString();
                        recursosApelacionReconsideracionDTO.FechaDocumento = Convert.ToDateTime(dr["FechaDocumento"]).ToString("yyy-MM-dd");
                        recursosApelacionReconsideracionDTO.CodigoDependencia = dr["CodigoDependencia"].ToString();
                        recursosApelacionReconsideracionDTO.FechaIngresoDocumento = Convert.ToDateTime(dr["FechaIngresoDocumento"]).ToString("yyy-MM-dd");
                        recursosApelacionReconsideracionDTO.CodigoGradoPersonalMilitar = dr["CodigoGradoPersonalMilitar"].ToString();
                        recursosApelacionReconsideracionDTO.TipoRecurso = dr["TipoRecurso"].ToString();
                        recursosApelacionReconsideracionDTO.CodigoAsuntoApelacionReconsideracion = dr["CodigoAsuntoApelacionReconsideracion"].ToString();
                        recursosApelacionReconsideracionDTO.DescripcionApelacion = dr["DescripcionApelacion"].ToString();
                        recursosApelacionReconsideracionDTO.CodigoResultadoApelacionReconsideracion = dr["CodigoResultadoApelacionReconsideracion"].ToString();
                        recursosApelacionReconsideracionDTO.DocumentoResolutivo = dr["DocumentoResolutivo"].ToString();
                        recursosApelacionReconsideracionDTO.FechaDocumentoResolutivo = Convert.ToDateTime(dr["FechaDocumentoResolutivo"]).ToString("yyy-MM-dd");
                        recursosApelacionReconsideracionDTO.FechaNotificacion = Convert.ToDateTime(dr["FechaNotificacion"]).ToString("yyy-MM-dd"); 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return recursosApelacionReconsideracionDTO;
        }

        public string ActualizaFormato(RecursosApelacionReconsideracionDTO recursosApelacionReconsideracionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_RecursosApelacionReconsideracionActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@RecursoApelacionReconsideracionId", SqlDbType.Int);
                    cmd.Parameters["@RecursoApelacionReconsideracionId"].Value = recursosApelacionReconsideracionDTO.RecursoApelacionReconsideracionId;

                    cmd.Parameters.Add("@NroDocumento", SqlDbType.VarChar, 10);
                    cmd.Parameters["@NroDocumento"].Value = recursosApelacionReconsideracionDTO.NroDocumento;

                    cmd.Parameters.Add("@FechaDocumento", SqlDbType.Date);
                    cmd.Parameters["@FechaDocumento"].Value = recursosApelacionReconsideracionDTO.FechaDocumento;

                    cmd.Parameters.Add("@CodigoDependencia", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDependencia"].Value = recursosApelacionReconsideracionDTO.CodigoDependencia;

                    cmd.Parameters.Add("@FechaIngresoDocumento", SqlDbType.Date);
                    cmd.Parameters["@FechaIngresoDocumento"].Value = recursosApelacionReconsideracionDTO.FechaIngresoDocumento;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitar"].Value = recursosApelacionReconsideracionDTO.CodigoGradoPersonalMilitar;

                    cmd.Parameters.Add("@TipoRecurso", SqlDbType.VarChar, 50);
                    cmd.Parameters["@TipoRecurso"].Value = recursosApelacionReconsideracionDTO.TipoRecurso;

                    cmd.Parameters.Add("@CodigoAsuntoApelacionReconsideracion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoAsuntoApelacionReconsideracion"].Value = recursosApelacionReconsideracionDTO.CodigoAsuntoApelacionReconsideracion;

                    cmd.Parameters.Add("@DescripcionApelacion", SqlDbType.VarChar, 260);
                    cmd.Parameters["@DescripcionApelacion"].Value = recursosApelacionReconsideracionDTO.DescripcionApelacion;

                    cmd.Parameters.Add("@CodigoResultadoApelacionReconsideracion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoResultadoApelacionReconsideracion"].Value = recursosApelacionReconsideracionDTO.CodigoResultadoApelacionReconsideracion;

                    cmd.Parameters.Add("@DocumentoResolutivo", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DocumentoResolutivo"].Value = recursosApelacionReconsideracionDTO.DocumentoResolutivo;

                    cmd.Parameters.Add("@FechaDocumentoResolutivo", SqlDbType.Date);
                    cmd.Parameters["@FechaDocumentoResolutivo"].Value = recursosApelacionReconsideracionDTO.FechaDocumentoResolutivo;

                    cmd.Parameters.Add("@FechaNotificacion", SqlDbType.Date);
                    cmd.Parameters["@FechaNotificacion"].Value = recursosApelacionReconsideracionDTO.FechaNotificacion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = recursosApelacionReconsideracionDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(RecursosApelacionReconsideracionDTO recursosApelacionReconsideracionDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_RecursosApelacionReconsideracionEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RecursoApelacionReconsideracionId", SqlDbType.Int);
                    cmd.Parameters["@RecursoApelacionReconsideracionId"].Value = recursosApelacionReconsideracionDTO.RecursoApelacionReconsideracionId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = recursosApelacionReconsideracionDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(RecursosApelacionReconsideracionDTO recursosApelacionReconsideracionDTO)
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
                    cmd.Parameters["@Formato"].Value = "RecursosApelacionReconsideracion";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = recursosApelacionReconsideracionDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = recursosApelacionReconsideracionDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_RecursosApelacionReconsideracionRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RecursosApelacionReconsideracion", SqlDbType.Structured);
                    cmd.Parameters["@RecursosApelacionReconsideracion"].TypeName = "Formato.RecursosApelacionReconsideracion";
                    cmd.Parameters["@RecursosApelacionReconsideracion"].Value = datos;

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
