using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Dintemar;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dintemar
{
    public class EstudioContrainteligenciaPersonaNavalDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<EstudioContrainteligenciaPersonaNavalDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<EstudioContrainteligenciaPersonaNavalDTO> lista = new List<EstudioContrainteligenciaPersonaNavalDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_EstudioContrainteligenciaPersonaNavalListar", conexion);
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
                        lista.Add(new EstudioContrainteligenciaPersonaNavalDTO()
                        {
                            EstudioContrainteligenciaPersonaNavalId = Convert.ToInt32(dr["EstudioContrainteligenciaPersonaNavalId"]),
                            DescDependencia = dr["DescDependencia"].ToString(),
                            DescComandanciaDependencia = dr["DescComandanciaDependencia"].ToString(),
                            DescZonaNaval = dr["DescZonaNaval"].ToString(),
                            EstudioContrainteligenciaProducida = Convert.ToInt32(dr["EstudioContrainteligenciaProducida"]),
                            DescTipoContrainteligencia = dr["DescTipoEstudioContrainteligencia"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"])
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(EstudioContrainteligenciaPersonaNavalDTO estudioContraintelPersonaNavalDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EstudioContrainteligenciaPersonaNavalRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoDependencia", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoDependencia"].Value = estudioContraintelPersonaNavalDTO.CodigoDependencia;

                    cmd.Parameters.Add("@CodigoComandanciaDependencia", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoComandanciaDependencia"].Value = estudioContraintelPersonaNavalDTO.CodigoComandanciaDependencia;

                    cmd.Parameters.Add("@CodigoZonaNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoZonaNaval"].Value = estudioContraintelPersonaNavalDTO.CodigoZonaNaval;

                    cmd.Parameters.Add("@EstudioContrainteligenciaProducida", SqlDbType.Int);
                    cmd.Parameters["@EstudioContrainteligenciaProducida"].Value = estudioContraintelPersonaNavalDTO.EstudioContrainteligenciaProducida;

                    cmd.Parameters.Add("@CodigoTipoEstudioContrainteligencia", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoEstudioContrainteligencia"].Value = estudioContraintelPersonaNavalDTO.CodigoTipoEstudioContrainteligencia;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = estudioContraintelPersonaNavalDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = estudioContraintelPersonaNavalDTO.UsuarioIngresoRegistro;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Mac"].Value = UtilitariosGlobales.obtenerDireccionMac();

                    cmd.Parameters.Add("@FechaCarga", SqlDbType.Date);
                    cmd.Parameters["@FechaCarga"].Value = estudioContraintelPersonaNavalDTO.Fecha;


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

        public EstudioContrainteligenciaPersonaNavalDTO BuscarFormato(int Codigo)
        {
            EstudioContrainteligenciaPersonaNavalDTO estudioContraintelPersonaNavalDTO = new EstudioContrainteligenciaPersonaNavalDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EstudioContrainteligenciaPersonaNavalEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EstudioContrainteligenciaPersonaNavalId", SqlDbType.Int);
                    cmd.Parameters["@EstudioContrainteligenciaPersonaNavalId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        estudioContraintelPersonaNavalDTO.EstudioContrainteligenciaPersonaNavalId = Convert.ToInt32(dr["EstudioContrainteligenciaPersonaNavalId"]);
                        estudioContraintelPersonaNavalDTO.CodigoDependencia = dr["CodigoDependencia"].ToString();
                        estudioContraintelPersonaNavalDTO.CodigoComandanciaDependencia = dr["CodigoComandanciaDependencia"].ToString();
                        estudioContraintelPersonaNavalDTO.CodigoZonaNaval = dr["CodigoZonaNaval"].ToString();
                        estudioContraintelPersonaNavalDTO.EstudioContrainteligenciaProducida = Convert.ToInt32(dr["EstudioContrainteligenciaProducida"]);
                        estudioContraintelPersonaNavalDTO.CodigoTipoEstudioContrainteligencia = dr["CodigoTipoEstudioContrainteligencia"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return estudioContraintelPersonaNavalDTO;
        }

        public string ActualizaFormato(EstudioContrainteligenciaPersonaNavalDTO estudioContraintelPersonaNavalDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_EstudioContrainteligenciaPersonaNavalActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EstudioContrainteligenciaPersonaNavalId", SqlDbType.Int);
                    cmd.Parameters["@EstudioContrainteligenciaPersonaNavalId"].Value = estudioContraintelPersonaNavalDTO.EstudioContrainteligenciaPersonaNavalId;

                    cmd.Parameters.Add("@CodigoDependencia", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDependencia"].Value = estudioContraintelPersonaNavalDTO.CodigoDependencia;

                    cmd.Parameters.Add("@CodigoComandanciaDependencia", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoComandanciaDependencia"].Value = estudioContraintelPersonaNavalDTO.CodigoComandanciaDependencia;

                    cmd.Parameters.Add("@CodigoZonaNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoZonaNaval"].Value = estudioContraintelPersonaNavalDTO.CodigoZonaNaval;

                    cmd.Parameters.Add("@EstudioContrainteligenciaProducida", SqlDbType.Int);
                    cmd.Parameters["@EstudioContrainteligenciaProducida"].Value = estudioContraintelPersonaNavalDTO.EstudioContrainteligenciaProducida;

                    cmd.Parameters.Add("@CodigoTipoEstudioContrainteligencia", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoEstudioContrainteligencia"].Value = estudioContraintelPersonaNavalDTO.CodigoTipoEstudioContrainteligencia;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = estudioContraintelPersonaNavalDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(EstudioContrainteligenciaPersonaNavalDTO estudioContraintelPersonaNavalDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EstudioContrainteligenciaPersonaNavalEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EstudioContrainteligenciaPersonaNavalId", SqlDbType.Int);
                    cmd.Parameters["@EstudioContrainteligenciaPersonaNavalId"].Value = estudioContraintelPersonaNavalDTO.EstudioContrainteligenciaPersonaNavalId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = estudioContraintelPersonaNavalDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(EstudioContrainteligenciaPersonaNavalDTO estudioContraintelPersonaNavalDTO)
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
                    cmd.Parameters["@Formato"].Value = "EstudioContrainteligenciaPersonaNaval";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = estudioContraintelPersonaNavalDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = estudioContraintelPersonaNavalDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_EstudioContrainteligenciaPersonaNavalRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EstudioContrainteligenciaPersonaNaval", SqlDbType.Structured);
                    cmd.Parameters["@EstudioContrainteligenciaPersonaNaval"].TypeName = "Formato.EstudioContrainteligenciaPersonaNaval";
                    cmd.Parameters["@EstudioContrainteligenciaPersonaNaval"].Value = datos;

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
