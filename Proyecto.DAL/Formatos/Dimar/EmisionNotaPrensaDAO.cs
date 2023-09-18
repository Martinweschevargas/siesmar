using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Dimar;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dimar
{
    public class EmisionNotaPrensaDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<EmisionNotaPrensaDTO> ObtenerLista(int? CargaId = null)
        {
            List<EmisionNotaPrensaDTO> lista = new List<EmisionNotaPrensaDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_EmisionNotaPrensaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new EmisionNotaPrensaDTO()
                        {
                            EmisionNotaPrensaId = Convert.ToInt32(dr["EmisionNotaPrensaId"]),
                            FechaEmision = (dr["FechaEmision"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            NumeroNotasProducidas = Convert.ToInt32(dr["NumeroNotasProducidas"]),
                            DescTipoInformacionEmitida = dr["DescTipoInformacionEmitida"].ToString(),
                            DescPlataformaMedioComunicacion = dr["DescPlataformaMedioComunicacion"].ToString(),
                            DescPublicoObjetivo = dr["DescPublicoObjetivo"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"])
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(EmisionNotaPrensaDTO emisionNotaPrensaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EmisionNotaPrensaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FechaEmision", SqlDbType.Date);
                    cmd.Parameters["@FechaEmision"].Value = emisionNotaPrensaDTO.FechaEmision;

                    cmd.Parameters.Add("@NumeroNotasProducidas", SqlDbType.Int);
                    cmd.Parameters["@NumeroNotasProducidas"].Value = emisionNotaPrensaDTO.NumeroNotasProducidas;

                    cmd.Parameters.Add("@CodigoTipoInformacionEmitida ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoInformacionEmitida "].Value = emisionNotaPrensaDTO.CodigoTipoInformacionEmitida;

                    cmd.Parameters.Add("@CodigoPlataformaMedioComunicacion ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoPlataformaMedioComunicacion "].Value = emisionNotaPrensaDTO.CodigoPlataformaMedioComunicacion;

                    cmd.Parameters.Add("@CodigoPublicoObjetivo ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoPublicoObjetivo "].Value = emisionNotaPrensaDTO.CodigoPublicoObjetivo;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = emisionNotaPrensaDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = emisionNotaPrensaDTO.UsuarioIngresoRegistro;

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

        public EmisionNotaPrensaDTO BuscarFormato(int Codigo)
        {
            EmisionNotaPrensaDTO emisionNotaPrensaDTO = new EmisionNotaPrensaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EmisionNotaPrensaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EmisionNotaPrensaId", SqlDbType.Int);
                    cmd.Parameters["@EmisionNotaPrensaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        emisionNotaPrensaDTO.EmisionNotaPrensaId = Convert.ToInt32(dr["EmisionNotaPrensaId"]);
                        emisionNotaPrensaDTO.FechaEmision = Convert.ToDateTime(dr["FechaEmision"]).ToString("yyy-MM-dd");
                        emisionNotaPrensaDTO.NumeroNotasProducidas = Convert.ToInt32(dr["NumeroNotasProducidas"]);
                        emisionNotaPrensaDTO.CodigoTipoInformacionEmitida = dr["CodigoTipoInformacionEmitida"].ToString();
                        emisionNotaPrensaDTO.CodigoPlataformaMedioComunicacion = dr["CodigoPlataformaMedioComunicacion"].ToString();
                        emisionNotaPrensaDTO.CodigoPublicoObjetivo = dr["CodigoPublicoObjetivo"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return emisionNotaPrensaDTO;
        }

        public string ActualizaFormato(EmisionNotaPrensaDTO emisionNotaPrensaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_EmisionNotaPrensaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@EmisionNotaPrensaId", SqlDbType.Int);
                    cmd.Parameters["@EmisionNotaPrensaId"].Value = emisionNotaPrensaDTO.EmisionNotaPrensaId;

                    cmd.Parameters.Add("@FechaEmision", SqlDbType.Date);
                    cmd.Parameters["@FechaEmision"].Value = emisionNotaPrensaDTO.FechaEmision;

                    cmd.Parameters.Add("@NumeroNotasProducidas", SqlDbType.Int);
                    cmd.Parameters["@NumeroNotasProducidas"].Value = emisionNotaPrensaDTO.NumeroNotasProducidas;

                    cmd.Parameters.Add("@CodigoTipoInformacionEmitida ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoInformacionEmitida "].Value = emisionNotaPrensaDTO.CodigoTipoInformacionEmitida;

                    cmd.Parameters.Add("@CodigoPlataformaMedioComunicacion ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoPlataformaMedioComunicacion "].Value = emisionNotaPrensaDTO.CodigoPlataformaMedioComunicacion;

                    cmd.Parameters.Add("@CodigoPublicoObjetivo ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoPublicoObjetivo "].Value = emisionNotaPrensaDTO.CodigoPublicoObjetivo;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = emisionNotaPrensaDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(EmisionNotaPrensaDTO emisionNotaPrensaDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EmisionNotaPrensaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EmisionNotaPrensaId", SqlDbType.Int);
                    cmd.Parameters["@EmisionNotaPrensaId"].Value = emisionNotaPrensaDTO.EmisionNotaPrensaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = emisionNotaPrensaDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_EmisionNotaPrensaRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EmisionNotaPrensa", SqlDbType.Structured);
                    cmd.Parameters["@EmisionNotaPrensa"].TypeName = "Formato.EmisionNotaPrensa";
                    cmd.Parameters["@EmisionNotaPrensa"].Value = datos;

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

