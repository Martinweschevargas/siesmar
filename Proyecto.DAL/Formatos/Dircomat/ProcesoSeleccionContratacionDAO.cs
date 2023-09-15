using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Dircomat;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;


namespace Marina.Siesmar.AccesoDatos.Formatos.Dircomat
{
    public class ProcesoSeleccionContratacionDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<ProcesoSeleccionContratacionDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<ProcesoSeleccionContratacionDTO> lista = new List<ProcesoSeleccionContratacionDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_ProcesoSeleccionContratacionListar", conexion);
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
                        lista.Add(new ProcesoSeleccionContratacionDTO()
                        {
                            ProcesoSeleccionContratacionId = Convert.ToInt32(dr["ProcesoSeleccionContratacionId"]),
                            DescMes = dr["DescMes"].ToString(),
                            NroPAC = dr["NroPAC"].ToString(),
                            DescTipoSeleccion = dr["DescTipoSeleccion"].ToString(),
                            DescEntidadConvocante = dr["DescEntidadConvocante"].ToString(),
                            DescFuenteFinanciamiento = dr["DescFuenteFinanciamiento"].ToString(),
                            DescObjetoContratacion = dr["DescObjetoContratacion"].ToString(),
                            DescMoneda = dr["DescMoneda"].ToString(),
                            MontoProcesoSiacomar = Convert.ToDecimal(dr["MontoProcesoSiacomar"]),
                            DescSubUnidadEjecutora = dr["DescSubUnidadEjecutora"].ToString(),
                            DescAreaTecnica = dr["DescAreaTecnica"].ToString(),
                            DescAreaDiperadmon = dr["DescAreaDiperadmon"].ToString(),
                            CodigoMonedaReferencia = dr["DescMoneda"].ToString(),
                            ValorReferencia = Convert.ToDecimal(dr["ValorReferencia"]),
                            DescObservacionProceso = dr["DescObservacionProceso"].ToString(),
                            FechaConvocatoria = (dr["FechaConvocatoria"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            FechaBuenaPro = (dr["FechaBuenaPro"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            CodigoMonedaAdjudicado = dr["DescMoneda"].ToString(),
                            MontoAdjudicado = Convert.ToDecimal(dr["MontoAdjudicado"]),
                            CargaId = Convert.ToInt32(dr["CargaId"])

                        });

                    }

                }
            }
            return lista;
        }

        public string AgregarRegistro(ProcesoSeleccionContratacionDTO procesoSeleccionContratacionDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_ProcesoSeleccionContratacionRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@NumeroMes", SqlDbType.VarChar,20);
                    cmd.Parameters["@NumeroMes"].Value = procesoSeleccionContratacionDTO.NumeroMes;

                    cmd.Parameters.Add("@NroPAC", SqlDbType.NChar,4);
                    cmd.Parameters["@NroPAC"].Value = procesoSeleccionContratacionDTO.NroPAC;

                    cmd.Parameters.Add("@CodigoTipoSeleccion", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoTipoSeleccion"].Value = procesoSeleccionContratacionDTO.CodigoTipoSeleccion;

                    cmd.Parameters.Add("@CodigoEntidadConvocante", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoEntidadConvocante"].Value = procesoSeleccionContratacionDTO.CodigoEntidadConvocante;

                    cmd.Parameters.Add("@CodigoFuenteFinanciamiento", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoFuenteFinanciamiento"].Value = procesoSeleccionContratacionDTO.CodigoFuenteFinanciamiento;

                    cmd.Parameters.Add("@CodigoObjetoContratacion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoObjetoContratacion"].Value = procesoSeleccionContratacionDTO.CodigoObjetoContratacion;

                    cmd.Parameters.Add("@CodigoMoneda", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoMoneda"].Value = procesoSeleccionContratacionDTO.CodigoMoneda;

                    cmd.Parameters.Add("@MontoProcesoSiacomar", SqlDbType.Decimal);
                    cmd.Parameters["@MontoProcesoSiacomar"].Value = procesoSeleccionContratacionDTO.MontoProcesoSiacomar;

                    cmd.Parameters.Add("@CodigoSubUnidadEjecutora", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoSubUnidadEjecutora"].Value = procesoSeleccionContratacionDTO.CodigoSubUnidadEjecutora;

                    cmd.Parameters.Add("@CodigoAreaTecnica", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoAreaTecnica"].Value = procesoSeleccionContratacionDTO.CodigoAreaTecnica;

                    cmd.Parameters.Add("@CodigoAreaDiperadmon", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoAreaDiperadmon"].Value = procesoSeleccionContratacionDTO.CodigoAreaDiperadmon;

                    cmd.Parameters.Add("@CodigoMonedaReferencia", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoMonedaReferencia"].Value = procesoSeleccionContratacionDTO.CodigoMonedaReferencia;

                    cmd.Parameters.Add("@ValorReferencia", SqlDbType.Decimal);
                    cmd.Parameters["@ValorReferencia"].Value = procesoSeleccionContratacionDTO.ValorReferencia;

                    cmd.Parameters.Add("@CodigoObservacionProceso", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoObservacionProceso"].Value = procesoSeleccionContratacionDTO.CodigoObservacionProceso;

                    cmd.Parameters.Add("@FechaConvocatoria", SqlDbType.Date);
                    cmd.Parameters["@FechaConvocatoria"].Value = procesoSeleccionContratacionDTO.FechaConvocatoria;

                    cmd.Parameters.Add("@FechaBuenaPro", SqlDbType.Date);
                    cmd.Parameters["@FechaBuenaPro"].Value = procesoSeleccionContratacionDTO.FechaBuenaPro;

                    cmd.Parameters.Add("@CodigoMonedaAdjudicado", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoMonedaAdjudicado"].Value = procesoSeleccionContratacionDTO.CodigoMonedaAdjudicado;

                    cmd.Parameters.Add("@MontoAdjudicado", SqlDbType.Decimal);
                    cmd.Parameters["@MontoAdjudicado"].Value = procesoSeleccionContratacionDTO.MontoAdjudicado;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = procesoSeleccionContratacionDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = procesoSeleccionContratacionDTO.UsuarioIngresoRegistro;

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

        public ProcesoSeleccionContratacionDTO BuscarFormato(int Codigo)
        {
            ProcesoSeleccionContratacionDTO procesoSeleccionContratacionDTO = new ProcesoSeleccionContratacionDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ProcesoSeleccionContratacionEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProcesoSeleccionContratacionId", SqlDbType.Int);
                    cmd.Parameters["@ProcesoSeleccionContratacionId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        procesoSeleccionContratacionDTO.ProcesoSeleccionContratacionId = Convert.ToInt32(dr["ProcesoSeleccionContratacionId"]);
                        procesoSeleccionContratacionDTO.NumeroMes = dr["NumeroMes"].ToString();
                        procesoSeleccionContratacionDTO.NroPAC = dr["NroPAC"].ToString();
                        procesoSeleccionContratacionDTO.CodigoTipoSeleccion = dr["CodigoTipoSeleccion"].ToString();
                        procesoSeleccionContratacionDTO.CodigoEntidadConvocante = dr["CodigoEntidadConvocante"].ToString();
                        procesoSeleccionContratacionDTO.CodigoFuenteFinanciamiento = dr["CodigoFuenteFinanciamiento"].ToString();
                        procesoSeleccionContratacionDTO.CodigoObjetoContratacion = dr["CodigoObjetoContratacion"].ToString();
                        procesoSeleccionContratacionDTO.CodigoMoneda = dr["CodigoMoneda"].ToString();
                        procesoSeleccionContratacionDTO.MontoProcesoSiacomar = Convert.ToDecimal(dr["MontoProcesoSiacomar"]);
                        procesoSeleccionContratacionDTO.CodigoSubUnidadEjecutora = dr["CodigoSubUnidadEjecutora"].ToString();
                        procesoSeleccionContratacionDTO.CodigoAreaTecnica = dr["CodigoAreaTecnica"].ToString();
                        procesoSeleccionContratacionDTO.CodigoAreaDiperadmon = dr["CodigoAreaDiperadmon"].ToString();
                        procesoSeleccionContratacionDTO.CodigoMonedaReferencia = dr["CodigoMonedaReferencia"].ToString();
                        procesoSeleccionContratacionDTO.ValorReferencia = Convert.ToDecimal(dr["ValorReferencia"]);
                        procesoSeleccionContratacionDTO.CodigoObservacionProceso = dr["CodigoObservacionProceso"].ToString();
                        procesoSeleccionContratacionDTO.FechaConvocatoria = Convert.ToDateTime(dr["FechaConvocatoria"]).ToString("yyy-MM-dd");
                        procesoSeleccionContratacionDTO.FechaBuenaPro = Convert.ToDateTime(dr["FechaBuenaPro"]).ToString("yyy-MM-dd");
                        procesoSeleccionContratacionDTO.CodigoMonedaAdjudicado = dr["CodigoMonedaAdjudicado"].ToString();
                        procesoSeleccionContratacionDTO.MontoAdjudicado = Convert.ToDecimal(dr["MontoAdjudicado"]);
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return procesoSeleccionContratacionDTO;
        }

        public string ActualizaFormato(ProcesoSeleccionContratacionDTO procesoSeleccionContratacionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_ProcesoSeleccionContratacionActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProcesoSeleccionContratacionId", SqlDbType.Int);
                    cmd.Parameters["@ProcesoSeleccionContratacionId"].Value = procesoSeleccionContratacionDTO.ProcesoSeleccionContratacionId;

                    cmd.Parameters.Add("@NumeroMes", SqlDbType.VarChar, 20);
                    cmd.Parameters["@NumeroMes"].Value = procesoSeleccionContratacionDTO.NumeroMes;

                    cmd.Parameters.Add("@NroPAC", SqlDbType.NChar, 4);
                    cmd.Parameters["@NroPAC"].Value = procesoSeleccionContratacionDTO.NroPAC;

                    cmd.Parameters.Add("@CodigoTipoSeleccion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoSeleccion"].Value = procesoSeleccionContratacionDTO.CodigoTipoSeleccion;

                    cmd.Parameters.Add("@CodigoEntidadConvocante", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEntidadConvocante"].Value = procesoSeleccionContratacionDTO.CodigoEntidadConvocante;

                    cmd.Parameters.Add("@CodigoFuenteFinanciamiento", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoFuenteFinanciamiento"].Value = procesoSeleccionContratacionDTO.CodigoFuenteFinanciamiento;

                    cmd.Parameters.Add("@CodigoObjetoContratacion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoObjetoContratacion"].Value = procesoSeleccionContratacionDTO.CodigoObjetoContratacion;

                    cmd.Parameters.Add("@CodigoMoneda", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoMoneda"].Value = procesoSeleccionContratacionDTO.CodigoMoneda;

                    cmd.Parameters.Add("@MontoProcesoSiacomar", SqlDbType.Decimal);
                    cmd.Parameters["@MontoProcesoSiacomar"].Value = procesoSeleccionContratacionDTO.MontoProcesoSiacomar;

                    cmd.Parameters.Add("@CodigoSubUnidadEjecutora", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoSubUnidadEjecutora"].Value = procesoSeleccionContratacionDTO.CodigoSubUnidadEjecutora;

                    cmd.Parameters.Add("@CodigoAreaTecnica", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoAreaTecnica"].Value = procesoSeleccionContratacionDTO.CodigoAreaTecnica;

                    cmd.Parameters.Add("@CodigoAreaDiperadmon", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoAreaDiperadmon"].Value = procesoSeleccionContratacionDTO.CodigoAreaDiperadmon;

                    cmd.Parameters.Add("@CodigoMonedaReferencia", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoMonedaReferencia"].Value = procesoSeleccionContratacionDTO.CodigoMonedaReferencia;

                    cmd.Parameters.Add("@ValorReferencia", SqlDbType.Decimal);
                    cmd.Parameters["@ValorReferencia"].Value = procesoSeleccionContratacionDTO.ValorReferencia;

                    cmd.Parameters.Add("@CodigoObservacionProceso", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoObservacionProceso"].Value = procesoSeleccionContratacionDTO.CodigoObservacionProceso;

                    cmd.Parameters.Add("@FechaConvocatoria", SqlDbType.Date);
                    cmd.Parameters["@FechaConvocatoria"].Value = procesoSeleccionContratacionDTO.FechaConvocatoria;

                    cmd.Parameters.Add("@FechaBuenaPro", SqlDbType.Date);
                    cmd.Parameters["@FechaBuenaPro"].Value = procesoSeleccionContratacionDTO.FechaBuenaPro;

                    cmd.Parameters.Add("@CodigoMonedaAdjudicado", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoMonedaAdjudicado"].Value = procesoSeleccionContratacionDTO.CodigoMonedaAdjudicado;

                    cmd.Parameters.Add("@MontoAdjudicado", SqlDbType.Decimal);
                    cmd.Parameters["@MontoAdjudicado"].Value = procesoSeleccionContratacionDTO.MontoAdjudicado;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = procesoSeleccionContratacionDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(ProcesoSeleccionContratacionDTO procesoSeleccionContratacionDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ProcesoSeleccionContratacionEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProcesoSeleccionContratacionId", SqlDbType.Int);
                    cmd.Parameters["@ProcesoSeleccionContratacionId"].Value= procesoSeleccionContratacionDTO.ProcesoSeleccionContratacionId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = procesoSeleccionContratacionDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(ProcesoSeleccionContratacionDTO procesoSeleccionContratacionDTO)
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
                    cmd.Parameters["@Formato"].Value = "ProcesoSeleccionContratacion";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = procesoSeleccionContratacionDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = procesoSeleccionContratacionDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_ProcesoSeleccionContratacionRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProcesoSeleccionContratacion", SqlDbType.Structured);
                    cmd.Parameters["@ProcesoSeleccionContratacion"].TypeName = "Formato.ProcesoSeleccionContratacion";
                    cmd.Parameters["@ProcesoSeleccionContratacion"].Value = datos;

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
