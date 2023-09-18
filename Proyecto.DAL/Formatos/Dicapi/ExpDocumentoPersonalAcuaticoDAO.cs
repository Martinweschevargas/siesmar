using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Dicapi;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dicapi
{
    public class ExpDocumentoPersonalAcuaticoDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<ExpDocumentoPersonalAcuaticoDTO> ObtenerLista(int? CargaId = null)
        {
            List<ExpDocumentoPersonalAcuaticoDTO> lista = new List<ExpDocumentoPersonalAcuaticoDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_ExpDocumentoPersonalAcuaticoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ExpDocumentoPersonalAcuaticoDTO()
                        {
                            ExpDocumentoPersonalAcuaticoId = Convert.ToInt32(dr["ExpDocumentoPersonalAcuaticoId"]),
                            NumeroDocumento = Convert.ToInt32(dr["NumeroDocumento"]),
                            FechaIngresoSolicitud = (dr["FechaIngresoSolicitud"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            DescDptoPersonalAcuatico = dr["DescDptoPersonalAcuatico"].ToString(),
                            DocumentoExpedido = Convert.ToInt32(dr["DocumentoExpedido"]),
                            ExpedidoA = dr["ExpedidoA"].ToString(),
                            NombreApellidoAcuatico = dr["NombreApellidoAcuatico"].ToString(),
                            DescTipoPersonalAcuatico = dr["DescTipoPersonalAcuatico"].ToString(),
                            DescTipoActividadEmpresa = dr["DescTipoActividadEmpresa"].ToString(),
                            FechaAtencionSolicitud = (dr["FechaAtencionSolicitud"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            CargaId = Convert.ToInt32(dr["CargaId"])

                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(ExpDocumentoPersonalAcuaticoDTO expDocumentoPersonalAcuaticoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ExpDocumentoPersonalAcuaticoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@NumeroDocumento", SqlDbType.Int);
                    cmd.Parameters["@NumeroDocumento"].Value = expDocumentoPersonalAcuaticoDTO.NumeroDocumento;

                    cmd.Parameters.Add("@FechaIngresoSolicitud", SqlDbType.Date);
                    cmd.Parameters["@FechaIngresoSolicitud"].Value = expDocumentoPersonalAcuaticoDTO.FechaIngresoSolicitud;

                    cmd.Parameters.Add("@CodigoDptoPersonalAcuatico", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoDptoPersonalAcuatico"].Value = expDocumentoPersonalAcuaticoDTO.CodigoDptoPersonalAcuatico;

                    cmd.Parameters.Add("@DocumentoExpedido", SqlDbType.Int);
                    cmd.Parameters["@DocumentoExpedido"].Value = expDocumentoPersonalAcuaticoDTO.DocumentoExpedido;

                    cmd.Parameters.Add("@ExpedidoA", SqlDbType.VarChar,50);
                    cmd.Parameters["@ExpedidoA"].Value = expDocumentoPersonalAcuaticoDTO.ExpedidoA;

                    cmd.Parameters.Add("@NombreApellidoAcuatico", SqlDbType.VarChar,200);
                    cmd.Parameters["@NombreApellidoAcuatico"].Value = expDocumentoPersonalAcuaticoDTO.NombreApellidoAcuatico;

                    cmd.Parameters.Add("@CodigoTipoPersonalAcuatico", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoPersonalAcuatico"].Value = expDocumentoPersonalAcuaticoDTO.CodigoTipoPersonalAcuatico;

                    cmd.Parameters.Add("@CodigoTipoActividadEmpresa", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoActividadEmpresa"].Value = expDocumentoPersonalAcuaticoDTO.CodigoTipoActividadEmpresa;

                    cmd.Parameters.Add("@FechaAtencionSolicitud", SqlDbType.Date);
                    cmd.Parameters["@FechaAtencionSolicitud"].Value = expDocumentoPersonalAcuaticoDTO.FechaAtencionSolicitud;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = expDocumentoPersonalAcuaticoDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = expDocumentoPersonalAcuaticoDTO.UsuarioIngresoRegistro;

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
                catch (Exception ex)
                {
                    IND_OPERACION = ex.Message;
                }
            }
            return IND_OPERACION;
        }

        public ExpDocumentoPersonalAcuaticoDTO BuscarFormato(int Codigo)
        {
            ExpDocumentoPersonalAcuaticoDTO expDocumentoPersonalAcuaticoDTO = new ExpDocumentoPersonalAcuaticoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ExpDocumentoPersonalAcuaticoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ExpDocumentoPersonalAcuaticoId", SqlDbType.Int);
                    cmd.Parameters["@ExpDocumentoPersonalAcuaticoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        expDocumentoPersonalAcuaticoDTO.ExpDocumentoPersonalAcuaticoId = Convert.ToInt32(dr["ExpDocumentoPersonalAcuaticoId"]);
                        expDocumentoPersonalAcuaticoDTO.NumeroDocumento = Convert.ToInt32(dr["NumeroDocumento"]);
                        expDocumentoPersonalAcuaticoDTO.FechaIngresoSolicitud = Convert.ToDateTime(dr["FechaIngresoSolicitud"]).ToString("yyy-MM-dd");
                        expDocumentoPersonalAcuaticoDTO.CodigoDptoPersonalAcuatico = dr["CodigoDptoPersonalAcuatico"].ToString();
                        expDocumentoPersonalAcuaticoDTO.DocumentoExpedido = Convert.ToInt32(dr["DocumentoExpedido"]);
                        expDocumentoPersonalAcuaticoDTO.ExpedidoA = dr["ExpedidoA"].ToString();
                        expDocumentoPersonalAcuaticoDTO.NombreApellidoAcuatico = dr["NombreApellidoAcuatico"].ToString();
                        expDocumentoPersonalAcuaticoDTO.CodigoTipoPersonalAcuatico = dr["CodigoTipoPersonalAcuatico"].ToString();
                        expDocumentoPersonalAcuaticoDTO.CodigoTipoActividadEmpresa = dr["CodigoTipoActividadEmpresa"].ToString();
                        expDocumentoPersonalAcuaticoDTO.FechaAtencionSolicitud = Convert.ToDateTime(dr["FechaAtencionSolicitud"]).ToString("yyy-MM-dd"); 


                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return expDocumentoPersonalAcuaticoDTO;
        }

        public string ActualizaFormato(ExpDocumentoPersonalAcuaticoDTO expDocumentoPersonalAcuaticoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_ExpDocumentoPersonalAcuaticoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ExpDocumentoPersonalAcuaticoId", SqlDbType.Int);
                    cmd.Parameters["@ExpDocumentoPersonalAcuaticoId"].Value = expDocumentoPersonalAcuaticoDTO.ExpDocumentoPersonalAcuaticoId;

                    cmd.Parameters.Add("@NumeroDocumento", SqlDbType.Int);
                    cmd.Parameters["@NumeroDocumento"].Value = expDocumentoPersonalAcuaticoDTO.NumeroDocumento;

                    cmd.Parameters.Add("@FechaIngresoSolicitud", SqlDbType.Date);
                    cmd.Parameters["@FechaIngresoSolicitud"].Value = expDocumentoPersonalAcuaticoDTO.FechaIngresoSolicitud;

                    cmd.Parameters.Add("@CodigoDptoPersonalAcuatico", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoDptoPersonalAcuatico"].Value = expDocumentoPersonalAcuaticoDTO.CodigoDptoPersonalAcuatico;

                    cmd.Parameters.Add("@DocumentoExpedido", SqlDbType.Int);
                    cmd.Parameters["@DocumentoExpedido"].Value = expDocumentoPersonalAcuaticoDTO.DocumentoExpedido;

                    cmd.Parameters.Add("@ExpedidoA", SqlDbType.VarChar, 50);
                    cmd.Parameters["@ExpedidoA"].Value = expDocumentoPersonalAcuaticoDTO.ExpedidoA;

                    cmd.Parameters.Add("@NombreApellidoAcuatico", SqlDbType.VarChar, 200);
                    cmd.Parameters["@NombreApellidoAcuatico"].Value = expDocumentoPersonalAcuaticoDTO.NombreApellidoAcuatico;

                    cmd.Parameters.Add("@CodigoTipoPersonalAcuatico", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoPersonalAcuatico"].Value = expDocumentoPersonalAcuaticoDTO.CodigoTipoPersonalAcuatico;

                    cmd.Parameters.Add("@CodigoTipoActividadEmpresa", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoActividadEmpresa"].Value = expDocumentoPersonalAcuaticoDTO.CodigoTipoActividadEmpresa;

                    cmd.Parameters.Add("@FechaAtencionSolicitud", SqlDbType.Date);
                    cmd.Parameters["@FechaAtencionSolicitud"].Value = expDocumentoPersonalAcuaticoDTO.FechaAtencionSolicitud;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = expDocumentoPersonalAcuaticoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(ExpDocumentoPersonalAcuaticoDTO expDocumentoPersonalAcuaticoDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ExpDocumentoPersonalAcuaticoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ExpDocumentoPersonalAcuaticoId", SqlDbType.Int);
                    cmd.Parameters["@ExpDocumentoPersonalAcuaticoId"].Value = expDocumentoPersonalAcuaticoDTO.ExpDocumentoPersonalAcuaticoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = expDocumentoPersonalAcuaticoDTO.UsuarioIngresoRegistro;

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

        public string InsertarDatos(DataTable datos)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("Formato.usp_ExpDocumentoPersonalAcuaticoRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ExpDocumentoPersonalAcuatico", SqlDbType.Structured);
                    cmd.Parameters["@ExpDocumentoPersonalAcuatico"].TypeName = "Formato.ExpDocumentoPersonalAcuatico";
                    cmd.Parameters["@ExpDocumentoPersonalAcuatico"].Value = datos;

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
    }
}
