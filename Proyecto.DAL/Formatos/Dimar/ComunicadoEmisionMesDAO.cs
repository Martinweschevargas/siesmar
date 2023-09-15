using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Dimar;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dimar
{
    public class ComunicadoEmisionMesDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<ComunicadoEmisionMesDTO> ObtenerLista(int? CargaId = null)
        {
            List<ComunicadoEmisionMesDTO> lista = new List<ComunicadoEmisionMesDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_ComunicadoEmisionMesListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ComunicadoEmisionMesDTO()
                        {
                            ComunicadoEmisionMesId = Convert.ToInt32(dr["ComunicadoEmisionMesId"]),
                            FechaEmisionComunicado = (dr["FechaEmisionComunicado"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            NumeroComunicados = Convert.ToInt32(dr["NumeroComunicados"]),
                            DescTipoInformacionEmitida = dr["DescTipoInformacionEmitida"].ToString(),
                            DescPublicoObjetivo = dr["DescPublicoObjetivo"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"]),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(ComunicadoEmisionMesDTO comunicadoEmisionMesDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ComunicadoEmisionMesRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FechaEmisionComunicado", SqlDbType.Date);
                    cmd.Parameters["@FechaEmisionComunicado"].Value = comunicadoEmisionMesDTO.FechaEmisionComunicado;

                    cmd.Parameters.Add("@NumeroComunicados", SqlDbType.Int);
                    cmd.Parameters["@NumeroComunicados"].Value = comunicadoEmisionMesDTO.NumeroComunicados;

                    cmd.Parameters.Add("@CodigoTipoInformacionEmitida ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoInformacionEmitida "].Value = comunicadoEmisionMesDTO.CodigoTipoInformacionEmitida;

                    cmd.Parameters.Add("@CodigoPublicoObjetivo ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoPublicoObjetivo "].Value = comunicadoEmisionMesDTO.CodigoPublicoObjetivo;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = comunicadoEmisionMesDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = comunicadoEmisionMesDTO.UsuarioIngresoRegistro;

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

        public ComunicadoEmisionMesDTO BuscarFormato(int Codigo)
        {
            ComunicadoEmisionMesDTO comunicadoEmisionMesDTO = new ComunicadoEmisionMesDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ComunicadoEmisionMesEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ComunicadoEmisionMesId", SqlDbType.Int);
                    cmd.Parameters["@ComunicadoEmisionMesId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        comunicadoEmisionMesDTO.ComunicadoEmisionMesId = Convert.ToInt32(dr["ComunicadoEmisionMesId"]);
                        comunicadoEmisionMesDTO.FechaEmisionComunicado = Convert.ToDateTime(dr["FechaEmisionComunicado"]).ToString("yyy-MM-dd");
                        comunicadoEmisionMesDTO.NumeroComunicados = Convert.ToInt32(dr["NumeroComunicados"]);
                        comunicadoEmisionMesDTO.CodigoTipoInformacionEmitida = dr["CodigoTipoInformacionEmitida "].ToString();
                        comunicadoEmisionMesDTO.CodigoPublicoObjetivo = dr["CodigoPublicoObjetivo"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return comunicadoEmisionMesDTO;
        }

        public string ActualizaFormato(ComunicadoEmisionMesDTO comunicadoEmisionMesDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_ComunicadoEmisionMesActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@ComunicadoEmisionMesId", SqlDbType.Int);
                    cmd.Parameters["@ComunicadoEmisionMesId"].Value = comunicadoEmisionMesDTO.ComunicadoEmisionMesId;

                    cmd.Parameters.Add("@FechaEmisionComunicado", SqlDbType.Date);
                    cmd.Parameters["@FechaEmisionComunicado"].Value = comunicadoEmisionMesDTO.FechaEmisionComunicado;

                    cmd.Parameters.Add("@NumeroComunicados", SqlDbType.Int);
                    cmd.Parameters["@NumeroComunicados"].Value = comunicadoEmisionMesDTO.NumeroComunicados;

                    cmd.Parameters.Add("@CodigoTipoInformacionEmitida ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoInformacionEmitida "].Value = comunicadoEmisionMesDTO.CodigoTipoInformacionEmitida;

                    cmd.Parameters.Add("@CodigoPublicoObjetivo ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoPublicoObjetivo "].Value = comunicadoEmisionMesDTO.CodigoPublicoObjetivo;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = comunicadoEmisionMesDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(ComunicadoEmisionMesDTO comunicadoEmisionMesDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ComunicadoEmisionMesEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ComunicadoEmisionMesId", SqlDbType.Int);
                    cmd.Parameters["@ComunicadoEmisionMesId"].Value = comunicadoEmisionMesDTO.ComunicadoEmisionMesId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = comunicadoEmisionMesDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_ComunicadoEmisionMesRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ComunicadoEmisionMes", SqlDbType.Structured);
                    cmd.Parameters["@ComunicadoEmisionMes"].TypeName = "Formato.ComunicadoEmisionMes";
                    cmd.Parameters["@ComunicadoEmisionMes"].Value = datos;

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