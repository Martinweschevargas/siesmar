using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Dimar;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dimar
{
    public class CampañaComunicacionalDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<CampañaComunicacionalDTO> ObtenerLista(int? CargaId = null)
        {
            List<CampañaComunicacionalDTO> lista = new List<CampañaComunicacionalDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_CampaniaComunicacionalListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new CampañaComunicacionalDTO()
                        {
                            CampaniaComunicacionalId = Convert.ToInt32(dr["CampaniaComunicacionalId"]),
                            DescProductoDimar = dr["DescProductoDimar"].ToString(),
                            FechaPublicacion = (dr["FechaPublicacion"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            NombreDependencia = dr["NombreDependencia"].ToString(),
                            PlataformaMedioPublicacion = dr["PlataformaMedioPublicacion"].ToString(),
                            DescTipoInformacionEmitida = dr["DescTipoInformacionEmitida"].ToString(),
                            DescPublicoObjetivo = dr["DescPublicoObjetivo"].ToString(),
                            CantidadProducida = Convert.ToInt32(dr["CantidadProducida"]),
                            DescFrecuenciaDifusion = dr["DescFrecuenciaDifusion"].ToString(),
                            CostoCampania = Convert.ToDecimal(dr["CostoCampania"]),
                            CargaId = Convert.ToInt32(dr["CargaId"]),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(CampañaComunicacionalDTO campaniaComunicacionalDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_CampaniaComunicacionalRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoProductoDimar ", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoProductoDimar"].Value = campaniaComunicacionalDTO.CodigoProductoDimar;

                    cmd.Parameters.Add("@FechaPublicacion", SqlDbType.Date);
                    cmd.Parameters["@FechaPublicacion"].Value = campaniaComunicacionalDTO.FechaPublicacion;

                    cmd.Parameters.Add("@CodigoDependencia ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDependencia "].Value = campaniaComunicacionalDTO.CodigoDependencia;

                    cmd.Parameters.Add("@PlataformaMedioPublicacion", SqlDbType.VarChar, 100);
                    cmd.Parameters["@PlataformaMedioPublicacion"].Value = campaniaComunicacionalDTO.PlataformaMedioPublicacion;

                    cmd.Parameters.Add("@CodigoTipoInformacionEmitida ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoInformacionEmitida "].Value = campaniaComunicacionalDTO.CodigoTipoInformacionEmitida;

                    cmd.Parameters.Add("@CodigoPublicoObjetivo ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoPublicoObjetivo "].Value = campaniaComunicacionalDTO.CodigoPublicoObjetivo;

                    cmd.Parameters.Add("@CantidadProducida", SqlDbType.Int);
                    cmd.Parameters["@CantidadProducida"].Value = campaniaComunicacionalDTO.CantidadProducida;

                    cmd.Parameters.Add("@CodigoFrecuenciaDifusion ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoFrecuenciaDifusion "].Value = campaniaComunicacionalDTO.CodigoFrecuenciaDifusion;

                    cmd.Parameters.Add("@CostoCampania", SqlDbType.Decimal);
                    cmd.Parameters["@CostoCampania"].Value = campaniaComunicacionalDTO.CostoCampania;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = campaniaComunicacionalDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = campaniaComunicacionalDTO.UsuarioIngresoRegistro;

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

        public CampañaComunicacionalDTO BuscarFormato(int Codigo)
        {
            CampañaComunicacionalDTO campaniaComunicacionalDTO = new CampañaComunicacionalDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_CampaniaComunicacionalEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CampaniaComunicacionalId", SqlDbType.Int);
                    cmd.Parameters["@CampaniaComunicacionalId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        campaniaComunicacionalDTO.CampaniaComunicacionalId = Convert.ToInt32(dr["CampaniaComunicacionalId"]);
                        campaniaComunicacionalDTO.CodigoProductoDimar = dr["CodigoProductoDimar"].ToString();
                        campaniaComunicacionalDTO.FechaPublicacion = Convert.ToDateTime(dr["FechaPublicacion"]).ToString("yyy-MM-dd");
                        campaniaComunicacionalDTO.CodigoDependencia = dr["CodigoDependencia"].ToString();
                        campaniaComunicacionalDTO.PlataformaMedioPublicacion = dr["PlataformaMedioPublicacion"].ToString();
                        campaniaComunicacionalDTO.CodigoTipoInformacionEmitida = dr["CodigoTipoInformacionEmitida"].ToString();
                        campaniaComunicacionalDTO.CodigoPublicoObjetivo = dr["CodigoPublicoObjetivo"].ToString();
                        campaniaComunicacionalDTO.CantidadProducida = Convert.ToInt32(dr["CantidadProducida"]);
                        campaniaComunicacionalDTO.CodigoFrecuenciaDifusion = dr["CodigoFrecuenciaDifusion"].ToString();
                        campaniaComunicacionalDTO.CostoCampania = Convert.ToDecimal(dr["CostoCampania"]); 
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return campaniaComunicacionalDTO;
        }

        public string ActualizaFormato(CampañaComunicacionalDTO campaniaComunicacionalDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_CampaniaComunicacionalActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@CampaniaComunicacionalId", SqlDbType.Int);
                    cmd.Parameters["@CampaniaComunicacionalId"].Value = campaniaComunicacionalDTO.CampaniaComunicacionalId;

                    cmd.Parameters.Add("@CodigoProductoDimar ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoProductoDimar"].Value = campaniaComunicacionalDTO.CodigoProductoDimar;

                    cmd.Parameters.Add("@FechaPublicacion", SqlDbType.Date);
                    cmd.Parameters["@FechaPublicacion"].Value = campaniaComunicacionalDTO.FechaPublicacion;

                    cmd.Parameters.Add("@CodigoDependencia ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDependencia "].Value = campaniaComunicacionalDTO.CodigoDependencia;

                    cmd.Parameters.Add("@PlataformaMedioPublicacion", SqlDbType.VarChar, 100);
                    cmd.Parameters["@PlataformaMedioPublicacion"].Value = campaniaComunicacionalDTO.PlataformaMedioPublicacion;

                    cmd.Parameters.Add("@CodigoTipoInformacionEmitida ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoInformacionEmitida "].Value = campaniaComunicacionalDTO.CodigoTipoInformacionEmitida;

                    cmd.Parameters.Add("@CodigoPublicoObjetivo ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoPublicoObjetivo "].Value = campaniaComunicacionalDTO.CodigoPublicoObjetivo;

                    cmd.Parameters.Add("@CantidadProducida", SqlDbType.Int);
                    cmd.Parameters["@CantidadProducida"].Value = campaniaComunicacionalDTO.CantidadProducida;

                    cmd.Parameters.Add("@CodigoFrecuenciaDifusion ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoFrecuenciaDifusion "].Value = campaniaComunicacionalDTO.CodigoFrecuenciaDifusion;

                    cmd.Parameters.Add("@CostoCampania", SqlDbType.Decimal);
                    cmd.Parameters["@CostoCampania"].Value = campaniaComunicacionalDTO.CostoCampania;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = campaniaComunicacionalDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(CampañaComunicacionalDTO campaniaComunicacionalDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_CampaniaComunicacionalEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CampaniaComunicacionalId", SqlDbType.Int);
                    cmd.Parameters["@CampaniaComunicacionalId"].Value = campaniaComunicacionalDTO.CampaniaComunicacionalId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = campaniaComunicacionalDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_CampaniaComunicacionalRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CampaniaComunicacional", SqlDbType.Structured);
                    cmd.Parameters["@CampaniaComunicacional"].TypeName = "Formato.CampaniaComunicacional";
                    cmd.Parameters["@CampaniaComunicacional"].Value = datos;

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
