using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Dirpronav;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dirpronav
{
    public class InversionPIeIOARRDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<InversionPIeIOARRDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<InversionPIeIOARRDTO> lista = new List<InversionPIeIOARRDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_InversionPIeIOARRListar", conexion);
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
                        lista.Add(new InversionPIeIOARRDTO()
                        {
                            InversionPIeIOARRId = Convert.ToInt32(dr["InversionPIeIOARRId"]),
                            CodigoUnificado = Convert.ToInt32(dr["CodigoUnificado"]),
                            NombreInversion = dr["NombreInversion"].ToString(),
                            DescClaseInversion = dr["DescClaseInversion"].ToString(),
                            MontoInversionInicial = Convert.ToDecimal(dr["MontoInversionInicial"]),
                            MontoInversionModificado = Convert.ToDecimal(dr["MontoInversionModificado"]),
                            FechaViabilidadProyecto = (dr["FechaViabilidadProyecto"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            DescFaseInversion = dr["DescFaseInversion"].ToString(),
                            UnidadFormuladora = dr["UnidadFormuladora"].ToString(),
                            UnidadEjecutora = dr["UnidadEjecutora"].ToString(),
                            DescUnidadNaval = dr["DescUnidadNaval"].ToString(),
                            DescEstadoFase1FormEval = dr["DescEstadoFase1FormEval"].ToString(),
                            DescEstadoFase2Ejecucion = dr["DescEstadoFase2Ejecucion"].ToString(),
                            DescEstadoFase3Funcionamiento = dr["DescEstadoFase3Funcionamiento"].ToString(),
                            DescFuenteFinanciamiento = dr["DescFuenteFinanciamiento"].ToString(),
                            FechaTerminoEjecucionInversion = (dr["FechaTerminoEjecucionInversion"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            FechaUltimaActualizacionProyecto = (dr["FechaUltimaActualizacionProyecto"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            CargaId = Convert.ToInt32(dr["CargaId"])
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(InversionPIeIOARRDTO inversionPIeIOARRDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_InversionPIeIOARRRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoUnificado", SqlDbType.Int);
                    cmd.Parameters["@CodigoUnificado"].Value = inversionPIeIOARRDTO.CodigoUnificado;

                    cmd.Parameters.Add("@NombreInversion", SqlDbType.VarChar, 500);
                    cmd.Parameters["@NombreInversion"].Value = inversionPIeIOARRDTO.NombreInversion;

                    cmd.Parameters.Add("@CodigoClaseInversion", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoClaseInversion"].Value = inversionPIeIOARRDTO.CodigoClaseInversion;

                    cmd.Parameters.Add("@MontoInversionInicial", SqlDbType.Decimal);
                    cmd.Parameters["@MontoInversionInicial"].Value = inversionPIeIOARRDTO.MontoInversionInicial;

                    cmd.Parameters.Add("@MontoInversionModificado", SqlDbType.Decimal);
                    cmd.Parameters["@MontoInversionModificado"].Value = inversionPIeIOARRDTO.MontoInversionModificado;

                    cmd.Parameters.Add("@FechaViabilidadProyecto", SqlDbType.Date);
                    cmd.Parameters["@FechaViabilidadProyecto"].Value = inversionPIeIOARRDTO.FechaViabilidadProyecto;

                    cmd.Parameters.Add("@CodigoFaseInversion", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoFaseInversion"].Value = inversionPIeIOARRDTO.CodigoFaseInversion;

                    cmd.Parameters.Add("@UnidadFormuladora", SqlDbType.VarChar, 100);
                    cmd.Parameters["@UnidadFormuladora"].Value = inversionPIeIOARRDTO.UnidadFormuladora;

                    cmd.Parameters.Add("@UnidadEjecutora", SqlDbType.VarChar, 100);
                    cmd.Parameters["@UnidadEjecutora"].Value = inversionPIeIOARRDTO.UnidadEjecutora;

                    cmd.Parameters.Add("@CodigoUnidadNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUnidadNaval"].Value = inversionPIeIOARRDTO.CodigoUnidadNaval;

                    cmd.Parameters.Add("@CodigoEstadoFase1FormEval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEstadoFase1FormEval"].Value = inversionPIeIOARRDTO.CodigoEstadoFase1FormEval;

                    cmd.Parameters.Add("@CodigoEstadoFase2Ejecucion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEstadoFase2Ejecucion"].Value = inversionPIeIOARRDTO.CodigoEstadoFase2Ejecucion;

                    cmd.Parameters.Add("@CodigoEstadoFase3Funcionamiento", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEstadoFase3Funcionamiento"].Value = inversionPIeIOARRDTO.CodigoEstadoFase3Funcionamiento;

                    cmd.Parameters.Add("@CodigoFuenteFinanciamiento", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoFuenteFinanciamiento"].Value = inversionPIeIOARRDTO.CodigoFuenteFinanciamiento;

                    cmd.Parameters.Add("@FechaTerminoEjecucionInversion", SqlDbType.Date);
                    cmd.Parameters["@FechaTerminoEjecucionInversion"].Value = inversionPIeIOARRDTO.FechaTerminoEjecucionInversion;

                    cmd.Parameters.Add("@FechaUltimaActualizacionProyecto", SqlDbType.Date);
                    cmd.Parameters["@FechaUltimaActualizacionProyecto"].Value = inversionPIeIOARRDTO.FechaUltimaActualizacionProyecto;                   

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = inversionPIeIOARRDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = inversionPIeIOARRDTO.UsuarioIngresoRegistro;

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

        public InversionPIeIOARRDTO BuscarFormato(int Codigo)
        {
            InversionPIeIOARRDTO inversionPIeIOARRDTO = new InversionPIeIOARRDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_InversionPIeIOARREncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@InversionPIeIOARRId", SqlDbType.Int);
                    cmd.Parameters["@InversionPIeIOARRId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        inversionPIeIOARRDTO.InversionPIeIOARRId = Convert.ToInt32(dr["InversionPIeIOARRId"]);
                        inversionPIeIOARRDTO.CodigoUnificado = Convert.ToInt32(dr["CodigoUnificado"]);
                        inversionPIeIOARRDTO.NombreInversion = dr["NombreInversion"].ToString();
                        inversionPIeIOARRDTO.CodigoClaseInversion = dr["CodigoClaseInversion"].ToString();
                        inversionPIeIOARRDTO.MontoInversionInicial = Convert.ToDecimal(dr["MontoInversionInicial"]);
                        inversionPIeIOARRDTO.MontoInversionModificado = Convert.ToDecimal(dr["MontoInversionModificado"]);
                        inversionPIeIOARRDTO.FechaViabilidadProyecto = Convert.ToDateTime(dr["FechaViabilidadProyecto"]).ToString("yyy-MM-dd");
                        inversionPIeIOARRDTO.CodigoFaseInversion = dr["CodigoFaseInversion"].ToString();
                        inversionPIeIOARRDTO.UnidadFormuladora = dr["UnidadFormuladora"].ToString();
                        inversionPIeIOARRDTO.UnidadEjecutora = dr["UnidadEjecutora"].ToString();
                        inversionPIeIOARRDTO.CodigoUnidadNaval = dr["CodigoUnidadNaval"].ToString();
                        inversionPIeIOARRDTO.CodigoEstadoFase1FormEval = dr["CodigoEstadoFase1FormEval"].ToString();
                        inversionPIeIOARRDTO.CodigoEstadoFase2Ejecucion = dr["CodigoEstadoFase2Ejecucion"].ToString();
                        inversionPIeIOARRDTO.CodigoEstadoFase3Funcionamiento = dr["CodigoEstadoFase3Funcionamiento"].ToString();
                        inversionPIeIOARRDTO.CodigoFuenteFinanciamiento = dr["CodigoFuenteFinanciamiento"].ToString();
                        inversionPIeIOARRDTO.FechaTerminoEjecucionInversion = Convert.ToDateTime(dr["FechaTerminoEjecucionInversion"]).ToString("yyy-MM-dd");
                        inversionPIeIOARRDTO.FechaUltimaActualizacionProyecto = Convert.ToDateTime(dr["FechaUltimaActualizacionProyecto"]).ToString("yyy-MM-dd"); 
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return inversionPIeIOARRDTO;
        }

        public string ActualizaFormato(InversionPIeIOARRDTO inversionPIeIOARRDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_InversionPIeIOARRActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@InversionPIeIOARRId", SqlDbType.Int);
                    cmd.Parameters["@InversionPIeIOARRId"].Value = inversionPIeIOARRDTO.InversionPIeIOARRId;

                    cmd.Parameters.Add("@CodigoUnificado", SqlDbType.Int);
                    cmd.Parameters["@CodigoUnificado"].Value = inversionPIeIOARRDTO.CodigoUnificado;

                    cmd.Parameters.Add("@NombreInversion", SqlDbType.VarChar, 500);
                    cmd.Parameters["@NombreInversion"].Value = inversionPIeIOARRDTO.NombreInversion;

                    cmd.Parameters.Add("@CodigoClaseInversion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoClaseInversion"].Value = inversionPIeIOARRDTO.CodigoClaseInversion;

                    cmd.Parameters.Add("@MontoInversionInicial", SqlDbType.Decimal);
                    cmd.Parameters["@MontoInversionInicial"].Value = inversionPIeIOARRDTO.MontoInversionInicial;

                    cmd.Parameters.Add("@MontoInversionModificado", SqlDbType.Decimal);
                    cmd.Parameters["@MontoInversionModificado"].Value = inversionPIeIOARRDTO.MontoInversionModificado;

                    cmd.Parameters.Add("@FechaViabilidadProyecto", SqlDbType.Date);
                    cmd.Parameters["@FechaViabilidadProyecto"].Value = inversionPIeIOARRDTO.FechaViabilidadProyecto;

                    cmd.Parameters.Add("@CodigoFaseInversion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoFaseInversion"].Value = inversionPIeIOARRDTO.CodigoFaseInversion;

                    cmd.Parameters.Add("@UnidadFormuladora", SqlDbType.VarChar, 100);
                    cmd.Parameters["@UnidadFormuladora"].Value = inversionPIeIOARRDTO.UnidadFormuladora;

                    cmd.Parameters.Add("@UnidadEjecutora", SqlDbType.VarChar, 100);
                    cmd.Parameters["@UnidadEjecutora"].Value = inversionPIeIOARRDTO.UnidadEjecutora;

                    cmd.Parameters.Add("@CodigoUnidadNaval", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoUnidadNaval"].Value = inversionPIeIOARRDTO.CodigoUnidadNaval;

                    cmd.Parameters.Add("@CodigoEstadoFase1FormEval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEstadoFase1FormEval"].Value = inversionPIeIOARRDTO.CodigoEstadoFase1FormEval;

                    cmd.Parameters.Add("@CodigoEstadoFase2Ejecucion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEstadoFase2Ejecucion"].Value = inversionPIeIOARRDTO.CodigoEstadoFase2Ejecucion;

                    cmd.Parameters.Add("@CodigoEstadoFase3Funcionamiento", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEstadoFase3Funcionamiento"].Value = inversionPIeIOARRDTO.CodigoEstadoFase3Funcionamiento;

                    cmd.Parameters.Add("@CodigoFuenteFinanciamiento", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoFuenteFinanciamiento"].Value = inversionPIeIOARRDTO.CodigoFuenteFinanciamiento;

                    cmd.Parameters.Add("@FechaTerminoEjecucionInversion", SqlDbType.Date);
                    cmd.Parameters["@FechaTerminoEjecucionInversion"].Value = inversionPIeIOARRDTO.FechaTerminoEjecucionInversion;

                    cmd.Parameters.Add("@FechaUltimaActualizacionProyecto", SqlDbType.Date);
                    cmd.Parameters["@FechaUltimaActualizacionProyecto"].Value = inversionPIeIOARRDTO.FechaUltimaActualizacionProyecto;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = inversionPIeIOARRDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(InversionPIeIOARRDTO inversionPIeIOARRDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_InversionPIeIOARREliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@InversionPIeIOARRId", SqlDbType.Int);
                    cmd.Parameters["@InversionPIeIOARRId"].Value = inversionPIeIOARRDTO.InversionPIeIOARRId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = inversionPIeIOARRDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(InversionPIeIOARRDTO inversionPIeIOARRDTO)
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
                    cmd.Parameters["@Formato"].Value = "InversionPIeIOARR";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = inversionPIeIOARRDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = inversionPIeIOARRDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_InversionPIeIOARRRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@InversionPIeIOARR", SqlDbType.Structured);
                    cmd.Parameters["@InversionPIeIOARR"].TypeName = "Formato.InversionPIeIOARR";
                    cmd.Parameters["@InversionPIeIOARR"].Value = datos;

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
