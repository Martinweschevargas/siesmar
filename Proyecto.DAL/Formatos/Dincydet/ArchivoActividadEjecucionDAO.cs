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
    public class ArchivoActividadEjecucionDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<ArchivoActividadEjecucionDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<ArchivoActividadEjecucionDTO> lista = new List<ArchivoActividadEjecucionDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_ArchivoActividadEjecucionListar", conexion);
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
                        lista.Add(new ArchivoActividadEjecucionDTO()
                        {
                            ArchivoActividadEjecucionId = Convert.ToInt32(dr["ArchivoActividadEjecucionId"]),
                            DenominacionActividadEjecucion = dr["DenominacionActividadEjecucion"].ToString(),
                            TipoTrabajoActividadEjecucion = dr["TipoTrabajoActividadEjecucion"].ToString(),
                            SituacionActualActividadEjecucion = Convert.ToInt32(dr["SituacionActualActividadEjecucion"]),
                            FinanciamientoTPActividadEjecucion = Convert.ToDecimal(dr["FinanciamientoTPActividadEjecucion"]),
                            FinanciamientoRDRActividadEjecucion = Convert.ToDecimal(dr["FinanciamientoRDRActividadEjecucion"]),
                            FinanciamientoTransferenciaActividadEjecucion = Convert.ToDecimal(dr["FinanciamientoTransferenciaActividadEjecucion"]),
                            CargaId = Convert.ToInt32(dr["CargaId"])

                        });

                    }

                }
            }
            return lista;
        }

        public string AgregarRegistro(ArchivoActividadEjecucionDTO archivoActividadEjecucionDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_ArchivoActividadEjecucionRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DenominacionActividadEjecucion", SqlDbType.VarChar,200);
                    cmd.Parameters["@DenominacionActividadEjecucion"].Value = archivoActividadEjecucionDTO.DenominacionActividadEjecucion;

                    cmd.Parameters.Add("@TipoTrabajoActividadEjecucion", SqlDbType.VarChar, 15);
                    cmd.Parameters["@TipoTrabajoActividadEjecucion"].Value = archivoActividadEjecucionDTO.TipoTrabajoActividadEjecucion;

                    cmd.Parameters.Add("@SituacionActualActividadEjecucion", SqlDbType.Int);
                    cmd.Parameters["@SituacionActualActividadEjecucion"].Value = archivoActividadEjecucionDTO.SituacionActualActividadEjecucion;

                    cmd.Parameters.Add("@FinanciamientoTPActividadEjecucion", SqlDbType.Decimal);
                    cmd.Parameters["@FinanciamientoTPActividadEjecucion"].Value = archivoActividadEjecucionDTO.FinanciamientoTPActividadEjecucion;

                    cmd.Parameters.Add("@FinanciamientoRDRActividadEjecucion", SqlDbType.Decimal);
                    cmd.Parameters["@FinanciamientoRDRActividadEjecucion"].Value = archivoActividadEjecucionDTO.FinanciamientoRDRActividadEjecucion;

                    cmd.Parameters.Add("@FinanciamientoTransferenciaActividadEjecucion", SqlDbType.Decimal);
                    cmd.Parameters["@FinanciamientoTransferenciaActividadEjecucion"].Value = archivoActividadEjecucionDTO.FinanciamientoTransferenciaActividadEjecucion;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = archivoActividadEjecucionDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = archivoActividadEjecucionDTO.UsuarioIngresoRegistro;

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

        public ArchivoActividadEjecucionDTO BuscarFormato(int Codigo)
        {
            ArchivoActividadEjecucionDTO archivoActividadEjecucionDTO = new ArchivoActividadEjecucionDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ArchivoActividadEjecucionEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ArchivoActividadEjecucionId", SqlDbType.Int);
                    cmd.Parameters["@ArchivoActividadEjecucionId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        archivoActividadEjecucionDTO.ArchivoActividadEjecucionId = Convert.ToInt32(dr["ArchivoActividadEjecucionId"]);
                        archivoActividadEjecucionDTO.DenominacionActividadEjecucion = dr["DenominacionActividadEjecucion"].ToString();
                        archivoActividadEjecucionDTO.TipoTrabajoActividadEjecucion = Regex.Replace(dr["TipoTrabajoActividadEjecucion"].ToString(), @"\s", "");
                        archivoActividadEjecucionDTO.SituacionActualActividadEjecucion = Convert.ToInt32(dr["SituacionActualActividadEjecucion"]);
                        archivoActividadEjecucionDTO.FinanciamientoTPActividadEjecucion = Convert.ToDecimal(dr["FinanciamientoTPActividadEjecucion"]);
                        archivoActividadEjecucionDTO.FinanciamientoRDRActividadEjecucion = Convert.ToDecimal(dr["FinanciamientoRDRActividadEjecucion"]);
                        archivoActividadEjecucionDTO.FinanciamientoTransferenciaActividadEjecucion = Convert.ToDecimal(dr["FinanciamientoTransferenciaActividadEjecucion"]);
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return archivoActividadEjecucionDTO;
        }

        public string ActualizaFormato(ArchivoActividadEjecucionDTO archivoActividadEjecucionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_ArchivoActividadEjecucionActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ArchivoActividadEjecucionId", SqlDbType.Int);
                    cmd.Parameters["@ArchivoActividadEjecucionId"].Value = archivoActividadEjecucionDTO.ArchivoActividadEjecucionId;

                    cmd.Parameters.Add("@DenominacionActividadEjecucion", SqlDbType.VarChar, 200);
                    cmd.Parameters["@DenominacionActividadEjecucion"].Value = archivoActividadEjecucionDTO.DenominacionActividadEjecucion;

                    cmd.Parameters.Add("@TipoTrabajoActividadEjecucion", SqlDbType.VarChar, 15);
                    cmd.Parameters["@TipoTrabajoActividadEjecucion"].Value = archivoActividadEjecucionDTO.TipoTrabajoActividadEjecucion;

                    cmd.Parameters.Add("@SituacionActualActividadEjecucion", SqlDbType.Int);
                    cmd.Parameters["@SituacionActualActividadEjecucion"].Value = archivoActividadEjecucionDTO.SituacionActualActividadEjecucion;

                    cmd.Parameters.Add("@FinanciamientoTPActividadEjecucion", SqlDbType.Decimal);
                    cmd.Parameters["@FinanciamientoTPActividadEjecucion"].Value = archivoActividadEjecucionDTO.FinanciamientoTPActividadEjecucion;

                    cmd.Parameters.Add("@FinanciamientoRDRActividadEjecucion", SqlDbType.Decimal);
                    cmd.Parameters["@FinanciamientoRDRActividadEjecucion"].Value = archivoActividadEjecucionDTO.FinanciamientoRDRActividadEjecucion;

                    cmd.Parameters.Add("@FinanciamientoTransferenciaActividadEjecucion", SqlDbType.Decimal);
                    cmd.Parameters["@FinanciamientoTransferenciaActividadEjecucion"].Value = archivoActividadEjecucionDTO.FinanciamientoTransferenciaActividadEjecucion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = archivoActividadEjecucionDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(ArchivoActividadEjecucionDTO archivoActividadEjecucionDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ArchivoActividadEjecucionEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ArchivoActividadEjecucionId", SqlDbType.Int);
                    cmd.Parameters["@ArchivoActividadEjecucionId"].Value= archivoActividadEjecucionDTO.ArchivoActividadEjecucionId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = archivoActividadEjecucionDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(ArchivoActividadEjecucionDTO archivoActividadEjecucionDTO)
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
                    cmd.Parameters["@Formato"].Value = "ArchivoActividadEjecucion";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = archivoActividadEjecucionDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = archivoActividadEjecucionDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_ArchivoActividadEjecucionRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ArchivoActividadEjecucion", SqlDbType.Structured);
                    cmd.Parameters["@ArchivoActividadEjecucion"].TypeName = "Formato.ArchivoActividadEjecucion";
                    cmd.Parameters["@ArchivoActividadEjecucion"].Value = datos;

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
