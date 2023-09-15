using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Dincydet;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dincydet
{
    public class ArchivoActividadCulminadoExitoDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<ArchivoActividadCulminadoExitoDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<ArchivoActividadCulminadoExitoDTO> lista = new List<ArchivoActividadCulminadoExitoDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_ArchivoActividadCulminadoExitoListar", conexion);
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
                        lista.Add(new ArchivoActividadCulminadoExitoDTO()
                        {
                            ArchivoActividadCulminadoExitoId = Convert.ToInt32(dr["ArchivoActividadCulminadoExitoId"]),
                            DenominacionActividadCulminado = dr["DenominacionActividadCulminado"].ToString(),
                            TipoTrabajoActividadCulminado = dr["TipoTrabajoActividadCulminado"].ToString(),
                            EtapaActividadCulminado = dr["EtapaActividadCulminado"].ToString(),
                            FinanciamientoTPActividadCulminado = Convert.ToDecimal(dr["FinanciamientoTPActividadCulminado"]),
                            FinanciamientoRDRActividadCulminado = Convert.ToDecimal(dr["FinanciamientoRDRActividadCulminado"]),
                            FinanciamientoTransferenciaActividadCulminado = Convert.ToDecimal(dr["FinanciamientoTransferenciaActividadCulminado"]),
                            DescAreaCT = dr["DescAreaCT"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"])

                        });

                    }

                }
            }
            return lista;
        }

        public string AgregarRegistro(ArchivoActividadCulminadoExitoDTO archivoActividadCulminadoExitoDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_ArchivoActividadCulminadoExitoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DenominacionActividadCulminado", SqlDbType.VarChar,200);
                    cmd.Parameters["@DenominacionActividadCulminado"].Value = archivoActividadCulminadoExitoDTO.DenominacionActividadCulminado;

                    cmd.Parameters.Add("@TipoTrabajoActividadCulminado", SqlDbType.VarChar, 15);
                    cmd.Parameters["@TipoTrabajoActividadCulminado"].Value = archivoActividadCulminadoExitoDTO.TipoTrabajoActividadCulminado;

                    cmd.Parameters.Add("@EtapaActividadCulminado", SqlDbType.VarChar, 15);
                    cmd.Parameters["@EtapaActividadCulminado"].Value = archivoActividadCulminadoExitoDTO.EtapaActividadCulminado;

                    cmd.Parameters.Add("@FinanciamientoTPActividadCulminado", SqlDbType.Decimal);
                    cmd.Parameters["@FinanciamientoTPActividadCulminado"].Value = archivoActividadCulminadoExitoDTO.FinanciamientoTPActividadCulminado;

                    cmd.Parameters.Add("@FinanciamientoRDRActividadCulminado", SqlDbType.Decimal);
                    cmd.Parameters["@FinanciamientoRDRActividadCulminado"].Value = archivoActividadCulminadoExitoDTO.FinanciamientoRDRActividadCulminado;

                    cmd.Parameters.Add("@FinanciamientoTransferenciaActividadCulminado", SqlDbType.Decimal);
                    cmd.Parameters["@FinanciamientoTransferenciaActividadCulminado"].Value = archivoActividadCulminadoExitoDTO.FinanciamientoTransferenciaActividadCulminado;

                    cmd.Parameters.Add("@CodigoAreaCT", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoAreaCT"].Value = archivoActividadCulminadoExitoDTO.CodigoAreaCT;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = archivoActividadCulminadoExitoDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = archivoActividadCulminadoExitoDTO.UsuarioIngresoRegistro;

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

        public ArchivoActividadCulminadoExitoDTO BuscarFormato(int Codigo)
        {
            ArchivoActividadCulminadoExitoDTO archivoActividadCulminadoExitoDTO = new ArchivoActividadCulminadoExitoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ArchivoActividadCulminadoExitoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ArchivoActividadCulminadoExitoId", SqlDbType.Int);
                    cmd.Parameters["@ArchivoActividadCulminadoExitoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        archivoActividadCulminadoExitoDTO.ArchivoActividadCulminadoExitoId = Convert.ToInt32(dr["ArchivoActividadCulminadoExitoId"]);
                        archivoActividadCulminadoExitoDTO.DenominacionActividadCulminado = dr["DenominacionActividadCulminado"].ToString();
                        archivoActividadCulminadoExitoDTO.TipoTrabajoActividadCulminado = Regex.Replace(dr["TipoTrabajoActividadCulminado"].ToString(), @"\s", "");
                        archivoActividadCulminadoExitoDTO.EtapaActividadCulminado = Regex.Replace(dr["EtapaActividadCulminado"].ToString(), @"\s", "");
                        archivoActividadCulminadoExitoDTO.FinanciamientoTPActividadCulminado = Convert.ToDecimal(dr["FinanciamientoTPActividadCulminado"]);
                        archivoActividadCulminadoExitoDTO.FinanciamientoRDRActividadCulminado = Convert.ToDecimal(dr["FinanciamientoRDRActividadCulminado"]);
                        archivoActividadCulminadoExitoDTO.FinanciamientoTransferenciaActividadCulminado = Convert.ToDecimal(dr["FinanciamientoTransferenciaActividadCulminado"]);
                        archivoActividadCulminadoExitoDTO.CodigoAreaCT = dr["CodigoAreaCT"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return archivoActividadCulminadoExitoDTO;
        }

        public string ActualizaFormato(ArchivoActividadCulminadoExitoDTO archivoActividadCulminadoExitoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_ArchivoActividadCulminadoExitoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ArchivoActividadCulminadoExitoId", SqlDbType.Int);
                    cmd.Parameters["@ArchivoActividadCulminadoExitoId"].Value = archivoActividadCulminadoExitoDTO.ArchivoActividadCulminadoExitoId;

                    cmd.Parameters.Add("@DenominacionActividadCulminado", SqlDbType.VarChar, 200);
                    cmd.Parameters["@DenominacionActividadCulminado"].Value = archivoActividadCulminadoExitoDTO.DenominacionActividadCulminado;

                    cmd.Parameters.Add("@TipoTrabajoActividadCulminado", SqlDbType.VarChar, 15);
                    cmd.Parameters["@TipoTrabajoActividadCulminado"].Value = archivoActividadCulminadoExitoDTO.TipoTrabajoActividadCulminado;

                    cmd.Parameters.Add("@EtapaActividadCulminado", SqlDbType.VarChar, 15);
                    cmd.Parameters["@EtapaActividadCulminado"].Value = archivoActividadCulminadoExitoDTO.EtapaActividadCulminado;

                    cmd.Parameters.Add("@FinanciamientoTPActividadCulminado", SqlDbType.Decimal);
                    cmd.Parameters["@FinanciamientoTPActividadCulminado"].Value = archivoActividadCulminadoExitoDTO.FinanciamientoTPActividadCulminado;

                    cmd.Parameters.Add("@FinanciamientoRDRActividadCulminado", SqlDbType.Decimal);
                    cmd.Parameters["@FinanciamientoRDRActividadCulminado"].Value = archivoActividadCulminadoExitoDTO.FinanciamientoRDRActividadCulminado;

                    cmd.Parameters.Add("@FinanciamientoTransferenciaActividadCulminado", SqlDbType.Decimal);
                    cmd.Parameters["@FinanciamientoTransferenciaActividadCulminado"].Value = archivoActividadCulminadoExitoDTO.FinanciamientoTransferenciaActividadCulminado;

                    cmd.Parameters.Add("@CodigoAreaCT", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoAreaCT"].Value = archivoActividadCulminadoExitoDTO.CodigoAreaCT;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = archivoActividadCulminadoExitoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(ArchivoActividadCulminadoExitoDTO archivoActividadCulminadoExitoDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ArchivoActividadCulminadoExitoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ArchivoActividadCulminadoExitoId", SqlDbType.Int);
                    cmd.Parameters["@ArchivoActividadCulminadoExitoId"].Value= archivoActividadCulminadoExitoDTO.ArchivoActividadCulminadoExitoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = archivoActividadCulminadoExitoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(ArchivoActividadCulminadoExitoDTO archivoActividadCulminadoExitoDTO)
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
                    cmd.Parameters["@Formato"].Value = "ArchivoActividadCulminadoExito";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = archivoActividadCulminadoExitoDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = archivoActividadCulminadoExitoDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_ArchivoActividadCulminadoExitoRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ArchivoActividadCulminadoExito", SqlDbType.Structured);
                    cmd.Parameters["@ArchivoActividadCulminadoExito"].TypeName = "Formato.ArchivoActividadCulminadoExito";
                    cmd.Parameters["@ArchivoActividadCulminadoExito"].Value = datos;

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
