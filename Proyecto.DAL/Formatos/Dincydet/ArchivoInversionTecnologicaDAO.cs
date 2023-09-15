using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Dincydet;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dincydet
{
    public class ArchivoInversionTecnologicaDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<ArchivoInversionTecnologicaDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<ArchivoInversionTecnologicaDTO> lista = new List<ArchivoInversionTecnologicaDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {

                conexion.Open();
                cmd = new SqlCommand("Formato.usp_ArchivoInversionTecnologicaListar", conexion);
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
                        lista.Add(new ArchivoInversionTecnologicaDTO()
                        {
                            ArchivoInversionTecnologicaId = Convert.ToInt32(dr["ArchivoInversionTecnologicaId"]),
                            DescAreaCT = dr["DescAreaCT"].ToString(),
                            TipoActividadInversionTec = dr["TipoActividadInversionTec"].ToString(),
                            FinanciamientoTPInversionTec = Convert.ToDecimal(dr["FinanciamientoTPInversionTec"]),
                            FinanciamientoRDRInversionTec = Convert.ToDecimal(dr["FinanciamientoRDRInversionTec"]),
                            FinanciamientoTransferenciaInversionTec = Convert.ToDecimal(dr["FinanciamientoTransferenciaInversionTec"]),
                            CargaId = Convert.ToInt32(dr["CargaId"]),

                        });

                    }

                }
            }
            return lista;
        }

        public string AgregarRegistro(ArchivoInversionTecnologicaDTO archivoInversionTecnologicaDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_ArchivoInversionTecnologicaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoAreaCT", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoAreaCT"].Value = archivoInversionTecnologicaDTO.CodigoAreaCT;

                    cmd.Parameters.Add("@TipoActividadInversionTec", SqlDbType.VarChar, 15);
                    cmd.Parameters["@TipoActividadInversionTec"].Value = archivoInversionTecnologicaDTO.TipoActividadInversionTec;

                    cmd.Parameters.Add("@FinanciamientoTPInversionTec", SqlDbType.Decimal);
                    cmd.Parameters["@FinanciamientoTPInversionTec"].Value = archivoInversionTecnologicaDTO.FinanciamientoTPInversionTec;

                    cmd.Parameters.Add("@FinanciamientoRDRInversionTec", SqlDbType.Decimal);
                    cmd.Parameters["@FinanciamientoRDRInversionTec"].Value = archivoInversionTecnologicaDTO.FinanciamientoRDRInversionTec;

                    cmd.Parameters.Add("@FinanciamientoTransferenciaInversionTec", SqlDbType.Decimal);
                    cmd.Parameters["@FinanciamientoTransferenciaInversionTec"].Value = archivoInversionTecnologicaDTO.FinanciamientoTransferenciaInversionTec;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = archivoInversionTecnologicaDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = archivoInversionTecnologicaDTO.UsuarioIngresoRegistro;

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

        public ArchivoInversionTecnologicaDTO BuscarFormato(int Codigo)
        {
            ArchivoInversionTecnologicaDTO archivoPersonalCTDocenteDTO = new ArchivoInversionTecnologicaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ArchivoInversionTecnologicaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ArchivoInversionTecnologicaId", SqlDbType.Int);
                    cmd.Parameters["@ArchivoInversionTecnologicaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        archivoPersonalCTDocenteDTO.ArchivoInversionTecnologicaId = Convert.ToInt32(dr["ArchivoInversionTecnologicaId"]);
                        archivoPersonalCTDocenteDTO.CodigoAreaCT = dr["CodigoAreaCT"].ToString();
                        archivoPersonalCTDocenteDTO.TipoActividadInversionTec = Regex.Replace(dr["TipoActividadInversionTec"].ToString(), @"\s", "");
                        archivoPersonalCTDocenteDTO.FinanciamientoTPInversionTec = Convert.ToDecimal(dr["FinanciamientoTPInversionTec"]);
                        archivoPersonalCTDocenteDTO.FinanciamientoRDRInversionTec = Convert.ToDecimal(dr["FinanciamientoRDRInversionTec"]);
                        archivoPersonalCTDocenteDTO.FinanciamientoTransferenciaInversionTec = Convert.ToDecimal(dr["FinanciamientoTransferenciaInversionTec"]);
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return archivoPersonalCTDocenteDTO;
        }

        public string ActualizaFormato(ArchivoInversionTecnologicaDTO archivoInversionTecnologicaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_ArchivoInversionTecnologicaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ArchivoInversionTecnologicaId", SqlDbType.Int);
                    cmd.Parameters["@ArchivoInversionTecnologicaId"].Value = archivoInversionTecnologicaDTO.ArchivoInversionTecnologicaId;

                    cmd.Parameters.Add("@CodigoAreaCT", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoAreaCT"].Value = archivoInversionTecnologicaDTO.CodigoAreaCT;

                    cmd.Parameters.Add("@TipoActividadInversionTec", SqlDbType.VarChar, 15);
                    cmd.Parameters["@TipoActividadInversionTec"].Value = archivoInversionTecnologicaDTO.TipoActividadInversionTec;

                    cmd.Parameters.Add("@FinanciamientoTPInversionTec", SqlDbType.Decimal);
                    cmd.Parameters["@FinanciamientoTPInversionTec"].Value = archivoInversionTecnologicaDTO.FinanciamientoTPInversionTec;

                    cmd.Parameters.Add("@FinanciamientoRDRInversionTec", SqlDbType.Decimal);
                    cmd.Parameters["@FinanciamientoRDRInversionTec"].Value = archivoInversionTecnologicaDTO.FinanciamientoRDRInversionTec;

                    cmd.Parameters.Add("@FinanciamientoTransferenciaInversionTec", SqlDbType.Decimal);
                    cmd.Parameters["@FinanciamientoTransferenciaInversionTec"].Value = archivoInversionTecnologicaDTO.FinanciamientoTransferenciaInversionTec;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = archivoInversionTecnologicaDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(ArchivoInversionTecnologicaDTO archivoInversionTecnologicaDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ArchivoInversionTecnologicaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ArchivoInversionTecnologicaId", SqlDbType.Int);
                    cmd.Parameters["@ArchivoInversionTecnologicaId"].Value= archivoInversionTecnologicaDTO.ArchivoInversionTecnologicaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = archivoInversionTecnologicaDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(ArchivoInversionTecnologicaDTO archivoInversionTecnologicaDTO)
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
                    cmd.Parameters["@Formato"].Value = "ArchivoInversionTecnologica";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = archivoInversionTecnologicaDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = archivoInversionTecnologicaDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_ArchivoInversionTecnologicaRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ArchivoInversionTecnologica", SqlDbType.Structured);
                    cmd.Parameters["@ArchivoInversionTecnologica"].TypeName = "Formato.ArchivoInversionTecnologica";
                    cmd.Parameters["@ArchivoInversionTecnologica"].Value = datos;

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
