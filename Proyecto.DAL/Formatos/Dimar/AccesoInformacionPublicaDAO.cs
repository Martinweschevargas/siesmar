using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Dimar;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dimar
{
    public class AccesoInformacionPublicaDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<AccesoInformacionPublicaDTO> ObtenerLista(int? CargaId = null)
        {
            List<AccesoInformacionPublicaDTO> lista = new List<AccesoInformacionPublicaDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_AccesoInformacionPublicaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new AccesoInformacionPublicaDTO()
                        {
                            AccesoInformacionPublicaId = Convert.ToInt32(dr["AccesoInformacionPublicaId"]),
                            FechaRecepcion = (dr["FechaRecepcion"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            NumeroDocumento = dr["NumeroDocumento"].ToString(),
                            FechaDocumento = (dr["FechaDocumento"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            Administrado = dr["Administrado"].ToString(),
                            Asunto = dr["Asunto"].ToString(),
                            DocumentoRespuesta = dr["DocumentoRespuesta"].ToString(),
                            FechaUsuario = (dr["FechaUsuario"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            MontoRecaudado = Convert.ToDecimal(dr["MontoRecaudado"]),
                            TiempoRespuestaDias = Convert.ToInt32(dr["TiempoRespuestaDias"]),
                            CargaId = Convert.ToInt32(dr["CargaId"]),

                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(AccesoInformacionPublicaDTO acesoInformacionPublicaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AccesoInformacionPublicaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FechaRecepcion", SqlDbType.Date);
                    cmd.Parameters["@FechaRecepcion"].Value = acesoInformacionPublicaDTO.FechaRecepcion;

                    cmd.Parameters.Add("@NumeroDocumento", SqlDbType.VarChar, 20);
                    cmd.Parameters["@NumeroDocumento"].Value = acesoInformacionPublicaDTO.NumeroDocumento;

                    cmd.Parameters.Add("@FechaDocumento", SqlDbType.Date);
                    cmd.Parameters["@FechaDocumento"].Value = acesoInformacionPublicaDTO.FechaDocumento;

                    cmd.Parameters.Add("@Administrado", SqlDbType.VarChar, 200);
                    cmd.Parameters["@Administrado"].Value = acesoInformacionPublicaDTO.Administrado;

                    cmd.Parameters.Add("@Asunto", SqlDbType.VarChar, 500);
                    cmd.Parameters["@Asunto"].Value = acesoInformacionPublicaDTO.Asunto;

                    cmd.Parameters.Add("@DocumentoRespuesta", SqlDbType.VarChar, 500);
                    cmd.Parameters["@DocumentoRespuesta"].Value = acesoInformacionPublicaDTO.DocumentoRespuesta;

                    cmd.Parameters.Add("@FechaUsuario", SqlDbType.Date);
                    cmd.Parameters["@FechaUsuario"].Value = acesoInformacionPublicaDTO.FechaUsuario;

                    cmd.Parameters.Add("@MontoRecaudado", SqlDbType.Decimal);
                    cmd.Parameters["@MontoRecaudado"].Value = acesoInformacionPublicaDTO.MontoRecaudado;

                    cmd.Parameters.Add("@TiempoRespuestaDias", SqlDbType.Int);
                    cmd.Parameters["@TiempoRespuestaDias"].Value = acesoInformacionPublicaDTO.TiempoRespuestaDias;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = acesoInformacionPublicaDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = acesoInformacionPublicaDTO.UsuarioIngresoRegistro;

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

        public AccesoInformacionPublicaDTO BuscarFormato(int Codigo)
        {
            AccesoInformacionPublicaDTO acesoInformacionPublicaDTO = new AccesoInformacionPublicaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AccesoInformacionPublicaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AccesoInformacionPublicaId", SqlDbType.Int);
                    cmd.Parameters["@AccesoInformacionPublicaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        acesoInformacionPublicaDTO.AccesoInformacionPublicaId = Convert.ToInt32(dr["AccesoInformacionPublicaId"]);
                        acesoInformacionPublicaDTO.FechaRecepcion = Convert.ToDateTime(dr["FechaRecepcion"]).ToString("yyy-MM-dd");
                        acesoInformacionPublicaDTO.NumeroDocumento = dr["NumeroDocumento"].ToString();
                        acesoInformacionPublicaDTO.FechaDocumento = Convert.ToDateTime(dr["FechaDocumento"]).ToString("yyy-MM-dd");
                        acesoInformacionPublicaDTO.Administrado = dr["Administrado"].ToString();
                        acesoInformacionPublicaDTO.Asunto = dr["Asunto"].ToString();
                        acesoInformacionPublicaDTO.DocumentoRespuesta = dr["DocumentoRespuesta"].ToString();
                        acesoInformacionPublicaDTO.FechaUsuario = Convert.ToDateTime(dr["FechaUsuario"]).ToString("yyy-MM-dd");
                        acesoInformacionPublicaDTO.MontoRecaudado = Convert.ToDecimal(dr["MontoRecaudado"]);
                        acesoInformacionPublicaDTO.TiempoRespuestaDias = Convert.ToInt32(dr["TiempoRespuestaDias"]); 
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return acesoInformacionPublicaDTO;
        }

        public string ActualizaFormato(AccesoInformacionPublicaDTO acesoInformacionPublicaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_AccesoInformacionPublicaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@AccesoInformacionPublicaId", SqlDbType.Int);
                    cmd.Parameters["@AccesoInformacionPublicaId"].Value = acesoInformacionPublicaDTO.AccesoInformacionPublicaId;

                    cmd.Parameters.Add("@FechaRecepcion", SqlDbType.Date);
                    cmd.Parameters["@FechaRecepcion"].Value = acesoInformacionPublicaDTO.FechaRecepcion;

                    cmd.Parameters.Add("@NumeroDocumento", SqlDbType.VarChar, 20);
                    cmd.Parameters["@NumeroDocumento"].Value = acesoInformacionPublicaDTO.NumeroDocumento;

                    cmd.Parameters.Add("@FechaDocumento", SqlDbType.Date);
                    cmd.Parameters["@FechaDocumento"].Value = acesoInformacionPublicaDTO.FechaDocumento;

                    cmd.Parameters.Add("@Administrado", SqlDbType.VarChar, 200);
                    cmd.Parameters["@Administrado"].Value = acesoInformacionPublicaDTO.Administrado;

                    cmd.Parameters.Add("@Asunto", SqlDbType.VarChar, 500);
                    cmd.Parameters["@Asunto"].Value = acesoInformacionPublicaDTO.Asunto;

                    cmd.Parameters.Add("@DocumentoRespuesta", SqlDbType.VarChar, 500);
                    cmd.Parameters["@DocumentoRespuesta"].Value = acesoInformacionPublicaDTO.DocumentoRespuesta;

                    cmd.Parameters.Add("@FechaUsuario", SqlDbType.Date);
                    cmd.Parameters["@FechaUsuario"].Value = acesoInformacionPublicaDTO.FechaUsuario;

                    cmd.Parameters.Add("@MontoRecaudado", SqlDbType.Decimal);
                    cmd.Parameters["@MontoRecaudado"].Value = acesoInformacionPublicaDTO.MontoRecaudado;

                    cmd.Parameters.Add("@TiempoRespuestaDias", SqlDbType.Int);
                    cmd.Parameters["@TiempoRespuestaDias"].Value = acesoInformacionPublicaDTO.TiempoRespuestaDias;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = acesoInformacionPublicaDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(AccesoInformacionPublicaDTO acesoInformacionPublicaDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AccesoInformacionPublicaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AccesoInformacionPublicaId", SqlDbType.Int);
                    cmd.Parameters["@AccesoInformacionPublicaId"].Value = acesoInformacionPublicaDTO.AccesoInformacionPublicaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = acesoInformacionPublicaDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_AccesoInformacionPublicaRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AccesoInformacionPublica", SqlDbType.Structured);
                    cmd.Parameters["@AccesoInformacionPublica"].TypeName = "Formato.AccesoInformacionPublica";
                    cmd.Parameters["@AccesoInformacionPublica"].Value = datos;

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
