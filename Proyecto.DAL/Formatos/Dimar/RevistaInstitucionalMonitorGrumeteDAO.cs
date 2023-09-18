using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Dimar;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dimar
{
    public class RevistaInstitucionalMonitorGrumeteDAO
    {

        SqlCommand cmd = new SqlCommand();


        public List<RevistaInstitucionalMonitorGrumeteDTO> ObtenerLista(int? CargaId = null)
        {
            List<RevistaInstitucionalMonitorGrumeteDTO> lista = new List<RevistaInstitucionalMonitorGrumeteDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_RevistaInstitucionalMonitorGrumeteListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new RevistaInstitucionalMonitorGrumeteDTO()
                        {
                            RevistaInstitucionalMonitorGrumeteId = Convert.ToInt32(dr["RevistaInstitucionalMonitorGrumeteId"]),
                            DescProductoDimar = dr["DescProductoDimar"].ToString(),
                            DescFrecuenciaDifusion = dr["DescFrecuenciaDifusion"].ToString(),
                            FechaPublicacion = (dr["FechaPublicacion"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            NroEdicion = Convert.ToInt32(dr["NroEdicion"]),
                            DescTipoInformacionEmitida = dr["DescTipoInformacionEmitida"].ToString(),
                            DescPlataformaMedioComunicacion = dr["DescPlataformaMedioComunicacion"].ToString(),
                            DescPublicoObjetivo = dr["DescPublicoObjetivo"].ToString(),
                            CantidadProducida = Convert.ToInt32(dr["CantidadProducida"]),
                            CargaId = Convert.ToInt32(dr["CargaId"])

                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(RevistaInstitucionalMonitorGrumeteDTO revistaInstitucionalMonitorGrumeteDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_RevistaInstitucionalMonitorGrumeteRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoProductoDimar ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoProductoDimar "].Value = revistaInstitucionalMonitorGrumeteDTO.CodigoProductoDimar;

                    cmd.Parameters.Add("@CodigoFrecuenciaDifusion ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoFrecuenciaDifusion "].Value = revistaInstitucionalMonitorGrumeteDTO.CodigoFrecuenciaDifusion;

                    cmd.Parameters.Add("@FechaPublicacion", SqlDbType.Date);
                    cmd.Parameters["@FechaPublicacion"].Value = revistaInstitucionalMonitorGrumeteDTO.FechaPublicacion;

                    cmd.Parameters.Add("@NroEdicion", SqlDbType.Int);
                    cmd.Parameters["@NroEdicion"].Value = revistaInstitucionalMonitorGrumeteDTO.NroEdicion;

                    cmd.Parameters.Add("@CodigoTipoInformacionEmitida ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoInformacionEmitida "].Value = revistaInstitucionalMonitorGrumeteDTO.CodigoTipoInformacionEmitida;

                    cmd.Parameters.Add("@CodigoPlataformaMedioComunicacion ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoPlataformaMedioComunicacion "].Value = revistaInstitucionalMonitorGrumeteDTO.CodigoPlataformaMedioComunicacion;

                    cmd.Parameters.Add("@CodigoPublicoObjetivo ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoPublicoObjetivo "].Value = revistaInstitucionalMonitorGrumeteDTO.CodigoPublicoObjetivo;

                    cmd.Parameters.Add("@CantidadProducida", SqlDbType.Int);
                    cmd.Parameters["@CantidadProducida"].Value = revistaInstitucionalMonitorGrumeteDTO.CantidadProducida;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = revistaInstitucionalMonitorGrumeteDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = revistaInstitucionalMonitorGrumeteDTO.UsuarioIngresoRegistro;

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

        public RevistaInstitucionalMonitorGrumeteDTO BuscarFormato(int Codigo)
        {
            RevistaInstitucionalMonitorGrumeteDTO revistaInstitucionalMonitorGrumeteDTO = new RevistaInstitucionalMonitorGrumeteDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_RevistaInstitucionalMonitorGrumeteEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RevistaInstitucionalMonitorGrumeteId", SqlDbType.Int);
                    cmd.Parameters["@RevistaInstitucionalMonitorGrumeteId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        revistaInstitucionalMonitorGrumeteDTO.RevistaInstitucionalMonitorGrumeteId = Convert.ToInt32(dr["RevistaInstitucionalMonitorGrumeteId"]);
                        revistaInstitucionalMonitorGrumeteDTO.CodigoProductoDimar = dr["CodigoProductoDimar"].ToString();
                        revistaInstitucionalMonitorGrumeteDTO.CodigoFrecuenciaDifusion = dr["CodigoFrecuenciaDifusion"].ToString();
                        revistaInstitucionalMonitorGrumeteDTO.FechaPublicacion = Convert.ToDateTime(dr["FechaPublicacion"]).ToString("yyy-MM-dd");
                        revistaInstitucionalMonitorGrumeteDTO.NroEdicion = Convert.ToInt32(dr["NroEdicion"]);
                        revistaInstitucionalMonitorGrumeteDTO.CodigoTipoInformacionEmitida = dr["CodigoTipoInformacionEmitida"].ToString();
                        revistaInstitucionalMonitorGrumeteDTO.CodigoPlataformaMedioComunicacion = dr["CodigoPlataformaMedioComunicacion"].ToString();
                        revistaInstitucionalMonitorGrumeteDTO.CodigoPublicoObjetivo = dr["CodigoPublicoObjetivo"].ToString();
                        revistaInstitucionalMonitorGrumeteDTO.CantidadProducida = Convert.ToInt32(dr["CantidadProducida"]);

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return revistaInstitucionalMonitorGrumeteDTO;
        }

        public string ActualizaFormato(RevistaInstitucionalMonitorGrumeteDTO revistaInstitucionalMonitorGrumeteDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_RevistaInstitucionalMonitorGrumeteActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@RevistaInstitucionalMonitorGrumeteId", SqlDbType.Int);
                    cmd.Parameters["@RevistaInstitucionalMonitorGrumeteId"].Value = revistaInstitucionalMonitorGrumeteDTO.RevistaInstitucionalMonitorGrumeteId;
                    
                    cmd.Parameters.Add("@CodigoProductoDimar ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoProductoDimar "].Value = revistaInstitucionalMonitorGrumeteDTO.CodigoProductoDimar;

                    cmd.Parameters.Add("@CodigoFrecuenciaDifusion ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoFrecuenciaDifusion "].Value = revistaInstitucionalMonitorGrumeteDTO.CodigoFrecuenciaDifusion;

                    cmd.Parameters.Add("@FechaPublicacion", SqlDbType.Date);
                    cmd.Parameters["@FechaPublicacion"].Value = revistaInstitucionalMonitorGrumeteDTO.FechaPublicacion;

                    cmd.Parameters.Add("@NroEdicion", SqlDbType.Int);
                    cmd.Parameters["@NroEdicion"].Value = revistaInstitucionalMonitorGrumeteDTO.NroEdicion;

                    cmd.Parameters.Add("@CodigoTipoInformacionEmitida ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoInformacionEmitida "].Value = revistaInstitucionalMonitorGrumeteDTO.CodigoTipoInformacionEmitida;

                    cmd.Parameters.Add("@CodigoPlataformaMedioComunicacion ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoPlataformaMedioComunicacion "].Value = revistaInstitucionalMonitorGrumeteDTO.CodigoPlataformaMedioComunicacion;

                    cmd.Parameters.Add("@CodigoPublicoObjetivo ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoPublicoObjetivo "].Value = revistaInstitucionalMonitorGrumeteDTO.CodigoPublicoObjetivo;

                    cmd.Parameters.Add("@CantidadProducida", SqlDbType.Int);
                    cmd.Parameters["@CantidadProducida"].Value = revistaInstitucionalMonitorGrumeteDTO.CantidadProducida;


                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = revistaInstitucionalMonitorGrumeteDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(RevistaInstitucionalMonitorGrumeteDTO revistaInstitucionalMonitorGrumeteDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_RevistaInstitucionalMonitorGrumeteEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RevistaInstitucionalMonitorGrumeteId", SqlDbType.Int);
                    cmd.Parameters["@RevistaInstitucionalMonitorGrumeteId"].Value = revistaInstitucionalMonitorGrumeteDTO.RevistaInstitucionalMonitorGrumeteId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = revistaInstitucionalMonitorGrumeteDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_RevistaInstitucionalMonitorGrumeteRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RevistaInstitucionalMonitorGrumete", SqlDbType.Structured);
                    cmd.Parameters["@RevistaInstitucionalMonitorGrumete"].TypeName = "Formato.RevistaInstitucionalMonitorGrumete";
                    cmd.Parameters["@RevistaInstitucionalMonitorGrumete"].Value = datos;

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


