using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Direcomar;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Direcomar
{
    public class EvaluacionPresupuestalDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<EvaluacionPresupuestalDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<EvaluacionPresupuestalDTO> lista = new List<EvaluacionPresupuestalDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_EvaluacionPresupuestalListar", conexion);
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
                        lista.Add(new EvaluacionPresupuestalDTO()
                        {
                            EvaluacionPresupuestalId = Convert.ToInt32(dr["EvaluacionPresupuestalId"]),
                            AnioEvaluacionPresupuesta = Convert.ToInt32(dr["AnioEvaluacionPresupuesta"]),
                            DescMes = dr["DescMes"].ToString(),
                            DescSubUnidadEjecutora = dr["DescSubUnidadEjecutora"].ToString(),
                            DescFuenteFinanciamiento = dr["DescFuenteFinanciamiento"].ToString(),
                            DescClasificacionGenericaGasto = dr["DescClasificacionGenericaGasto"].ToString(),
                            ASIGPIMPresupuestal = Convert.ToDecimal(dr["ASIGPIMPresupuestal"]),
                            PCAPresupuestal = Convert.ToDecimal(dr["PCAPresupuestal"]),
                            CertificadoPresupuestal = Convert.ToDecimal(dr["CertificadoPresupuestal"]),
                            CompromisoPresupuestal = Convert.ToDecimal(dr["CompromisoPresupuestal"]),
                            DevengadoPresupuestal = Convert.ToDecimal(dr["DevengadoPresupuestal"]),
                            GiradoPresupuestal = Convert.ToDecimal(dr["GiradoPresupuestal"]),
                            AvancePresupuestal = Convert.ToInt32(dr["AvancePresupuestal"]),
                            CargaId = Convert.ToInt32(dr["CargaId"]),
                        });
                    }
                }
            }
            return lista;
        }

        public List<EvaluacionPresupuestalDTO> DirecomarVisualizacionEvaluacionPresupuestal(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<EvaluacionPresupuestalDTO> lista = new List<EvaluacionPresupuestalDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Reporte.DirecomarVisualizacionPlanAnualAdquisicionContratacionesSUE", conexion);
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
                        lista.Add(new EvaluacionPresupuestalDTO()
                        {
                            AnioEvaluacionPresupuesta = Convert.ToInt32(dr["AnioEvaluacionPresupuesta"]),
                            NumeroMes = dr["NumeroMes"].ToString(),
                            DescSubUnidadEjecutora = dr["DescSubUnidadEjecutora"].ToString(),
                            DescFuenteFinanciamiento = dr["DescFuenteFinanciamiento"].ToString(),
                            DescClasificacionGenericaGasto = dr["DescClasificacionGenericaGasto"].ToString(),
                            ASIGPIMPresupuestal = Convert.ToDecimal(dr["ASIGPIMPresupuestal"]),
                            PCAPresupuestal = Convert.ToDecimal(dr["PCAPresupuestal"]),
                            CertificadoPresupuestal = Convert.ToDecimal(dr["CertificadoPresupuestal"]),
                            CompromisoPresupuestal = Convert.ToDecimal(dr["CompromisoPresupuestal"]),
                            DevengadoPresupuestal = Convert.ToDecimal(dr["DevengadoPresupuestal"]),
                            GiradoPresupuestal = Convert.ToDecimal(dr["GiradoPresupuestal"]),
                            AvancePresupuestal = Convert.ToInt32(dr["AvancePresupuestal"]),
                        });
                    }
                }
            }
            return lista;
        }


        public string AgregarRegistro(EvaluacionPresupuestalDTO evaluacionPresupuestalDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EvaluacionPresupuestalRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AnioEvaluacionPresupuesta", SqlDbType.Int);
                    cmd.Parameters["@AnioEvaluacionPresupuesta"].Value = evaluacionPresupuestalDTO.AnioEvaluacionPresupuesta;

                    cmd.Parameters.Add("@NumeroMes", SqlDbType.VarChar,20);
                    cmd.Parameters["@NumeroMes"].Value = evaluacionPresupuestalDTO.NumeroMes;

                    cmd.Parameters.Add("@CodigoSubunidadEjecutora", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoSubunidadEjecutora"].Value = evaluacionPresupuestalDTO.CodigoSubunidadEjecutora;

                    cmd.Parameters.Add("@CodigoFuenteFinanciamiento", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoFuenteFinanciamiento"].Value = evaluacionPresupuestalDTO.CodigoFuenteFinanciamiento;

                    cmd.Parameters.Add("@ClasificacionGenericaGasto", SqlDbType.VarChar, 20);
                    cmd.Parameters["@ClasificacionGenericaGasto"].Value = evaluacionPresupuestalDTO.ClasificacionGenericaGasto;

                    cmd.Parameters.Add("@ASIGPIMPresupuestal", SqlDbType.Decimal);
                    cmd.Parameters["@ASIGPIMPresupuestal"].Value = evaluacionPresupuestalDTO.ASIGPIMPresupuestal;

                    cmd.Parameters.Add("@PCAPresupuestal", SqlDbType.Decimal);
                    cmd.Parameters["@PCAPresupuestal"].Value = evaluacionPresupuestalDTO.PCAPresupuestal;

                    cmd.Parameters.Add("@CertificadoPresupuestal", SqlDbType.Decimal);
                    cmd.Parameters["@CertificadoPresupuestal"].Value = evaluacionPresupuestalDTO.CertificadoPresupuestal;

                    cmd.Parameters.Add("@CompromisoPresupuestal", SqlDbType.Decimal);
                    cmd.Parameters["@CompromisoPresupuestal"].Value = evaluacionPresupuestalDTO.CompromisoPresupuestal;

                    cmd.Parameters.Add("@DevengadoPresupuestal", SqlDbType.Decimal);
                    cmd.Parameters["@DevengadoPresupuestal"].Value = evaluacionPresupuestalDTO.DevengadoPresupuestal;

                    cmd.Parameters.Add("@GiradoPresupuestal", SqlDbType.Decimal);
                    cmd.Parameters["@GiradoPresupuestal"].Value = evaluacionPresupuestalDTO.GiradoPresupuestal;

                    cmd.Parameters.Add("@AvancePresupuestal", SqlDbType.Int);
                    cmd.Parameters["@AvancePresupuestal"].Value = evaluacionPresupuestalDTO.AvancePresupuestal;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = evaluacionPresupuestalDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = evaluacionPresupuestalDTO.UsuarioIngresoRegistro;

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

        public EvaluacionPresupuestalDTO BuscarFormato(int Codigo)
        {
            EvaluacionPresupuestalDTO evaluacionPresupuestalDTO = new EvaluacionPresupuestalDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EvaluacionPresupuestalEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EvaluacionPresupuestalId", SqlDbType.Int);
                    cmd.Parameters["@EvaluacionPresupuestalId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        evaluacionPresupuestalDTO.EvaluacionPresupuestalId = Convert.ToInt32(dr["EvaluacionPresupuestalId"]);
                        evaluacionPresupuestalDTO.AnioEvaluacionPresupuesta = Convert.ToInt32(dr["AnioEvaluacionPresupuesta"]);
                        evaluacionPresupuestalDTO.NumeroMes = dr["NumeroMes"].ToString();
                        evaluacionPresupuestalDTO.CodigoSubunidadEjecutora = dr["CodigoSubunidadEjecutora"].ToString();
                        evaluacionPresupuestalDTO.CodigoFuenteFinanciamiento = dr["CodigoFuenteFinanciamiento"].ToString();
                        evaluacionPresupuestalDTO.ClasificacionGenericaGasto = dr["ClasificacionGenericaGasto"].ToString();
                        evaluacionPresupuestalDTO.ASIGPIMPresupuestal = Convert.ToDecimal(dr["ASIGPIMPresupuestal"]);
                        evaluacionPresupuestalDTO.PCAPresupuestal = Convert.ToDecimal(dr["PCAPresupuestal"]);
                        evaluacionPresupuestalDTO.CertificadoPresupuestal = Convert.ToDecimal(dr["CertificadoPresupuestal"]);
                        evaluacionPresupuestalDTO.CompromisoPresupuestal = Convert.ToDecimal(dr["CompromisoPresupuestal"]);
                        evaluacionPresupuestalDTO.DevengadoPresupuestal = Convert.ToDecimal(dr["DevengadoPresupuestal"]);
                        evaluacionPresupuestalDTO.GiradoPresupuestal = Convert.ToDecimal(dr["GiradoPresupuestal"]);
                        evaluacionPresupuestalDTO.AvancePresupuestal = Convert.ToInt32(dr["AvancePresupuestal"]); 
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return evaluacionPresupuestalDTO;
        }

        public string ActualizaFormato(EvaluacionPresupuestalDTO evaluacionPresupuestalDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_EvaluacionPresupuestalActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@EvaluacionPresupuestalId", SqlDbType.Int);
                    cmd.Parameters["@EvaluacionPresupuestalId"].Value = evaluacionPresupuestalDTO.EvaluacionPresupuestalId;

                    cmd.Parameters.Add("@AnioEvaluacionPresupuesta", SqlDbType.Int);
                    cmd.Parameters["@AnioEvaluacionPresupuesta"].Value = evaluacionPresupuestalDTO.AnioEvaluacionPresupuesta;

                    cmd.Parameters.Add("@NumeroMes", SqlDbType.VarChar,20);
                    cmd.Parameters["@NumeroMes"].Value = evaluacionPresupuestalDTO.NumeroMes;

                    cmd.Parameters.Add("@CodigoSubunidadEjecutora", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoSubunidadEjecutora"].Value = evaluacionPresupuestalDTO.CodigoSubunidadEjecutora;

                    cmd.Parameters.Add("@CodigoFuenteFinanciamiento", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoFuenteFinanciamiento"].Value = evaluacionPresupuestalDTO.CodigoFuenteFinanciamiento;

                    cmd.Parameters.Add("@ClasificacionGenericaGasto", SqlDbType.VarChar, 20);
                    cmd.Parameters["@ClasificacionGenericaGasto"].Value = evaluacionPresupuestalDTO.ClasificacionGenericaGasto;

                    cmd.Parameters.Add("@ASIGPIMPresupuestal", SqlDbType.Decimal);
                    cmd.Parameters["@ASIGPIMPresupuestal"].Value = evaluacionPresupuestalDTO.ASIGPIMPresupuestal;

                    cmd.Parameters.Add("@PCAPresupuestal", SqlDbType.Decimal);
                    cmd.Parameters["@PCAPresupuestal"].Value = evaluacionPresupuestalDTO.PCAPresupuestal;

                    cmd.Parameters.Add("@CertificadoPresupuestal", SqlDbType.Decimal);
                    cmd.Parameters["@CertificadoPresupuestal"].Value = evaluacionPresupuestalDTO.CertificadoPresupuestal;

                    cmd.Parameters.Add("@CompromisoPresupuestal", SqlDbType.Decimal);
                    cmd.Parameters["@CompromisoPresupuestal"].Value = evaluacionPresupuestalDTO.CompromisoPresupuestal;

                    cmd.Parameters.Add("@DevengadoPresupuestal", SqlDbType.Decimal);
                    cmd.Parameters["@DevengadoPresupuestal"].Value = evaluacionPresupuestalDTO.DevengadoPresupuestal;

                    cmd.Parameters.Add("@GiradoPresupuestal", SqlDbType.Decimal);
                    cmd.Parameters["@GiradoPresupuestal"].Value = evaluacionPresupuestalDTO.GiradoPresupuestal;

                    cmd.Parameters.Add("@AvancePresupuestal", SqlDbType.Int);
                    cmd.Parameters["@AvancePresupuestal"].Value = evaluacionPresupuestalDTO.AvancePresupuestal;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = evaluacionPresupuestalDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(EvaluacionPresupuestalDTO evaluacionPresupuestalDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EvaluacionPresupuestalEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EvaluacionPresupuestalId", SqlDbType.Int);
                    cmd.Parameters["@EvaluacionPresupuestalId"].Value = evaluacionPresupuestalDTO.EvaluacionPresupuestalId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = evaluacionPresupuestalDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(EvaluacionPresupuestalDTO evaluacionPresupuestalDTO)
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
                    cmd.Parameters["@Formato"].Value = "EvaluacionPresupuestal";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = evaluacionPresupuestalDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = evaluacionPresupuestalDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_EvaluacionPresupuestalRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EvaluacionPresupuestal", SqlDbType.Structured);
                    cmd.Parameters["@EvaluacionPresupuestal"].TypeName = "Formato.EvaluacionPresupuestal";
                    cmd.Parameters["@EvaluacionPresupuestal"].Value = datos;

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
