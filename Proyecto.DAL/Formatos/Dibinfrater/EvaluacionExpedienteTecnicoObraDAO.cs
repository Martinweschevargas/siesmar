using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Dibinfrater;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dibinfrater
{
    public class EvaluacionExpedienteTecnicoObraDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<EvaluacionExpedienteTecnicoObraDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<EvaluacionExpedienteTecnicoObraDTO> lista = new List<EvaluacionExpedienteTecnicoObraDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_EvaluacionExpedienteTecnicoObraListar", conexion);
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
                        lista.Add(new EvaluacionExpedienteTecnicoObraDTO()
                        {
                            EvaluacionExpedienteTecnicoObraId = Convert.ToInt32(dr["EvaluacionExpedienteTecnicoObraId"]),
                            NombreProyecto = dr["NombreProyecto"].ToString(),
                            DescSituacionExpedienteTecnico = dr["DescSituacionExpedienteTecnico"].ToString(),
                            DescTipoProceso = dr["DescTipoProceso"].ToString(),
                            DescTipoProyecto = dr["DescTipoProyecto"].ToString(),
                            DescZonaNaval = dr["DescZonaNaval"].ToString(),
                            DescAreaDiperadmon = dr["DescAreaDiperadmon"].ToString(),
                            MontoContractual = Convert.ToDecimal(dr["MontoContractual"]),
                            FechaInicioEvaluacionProyecto = (dr["FechaInicioEvaluacionProyecto"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            PorcentajeAvanceProyecto = Convert.ToInt32(dr["PorcentajeAvanceProyecto"]),
                            CargaId = Convert.ToInt32(dr["CargaId"])

                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(EvaluacionExpedienteTecnicoObraDTO evaluacionExpedienteTecnicoObraDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EvaluacionExpedienteTecnicoObraRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@NombreProyecto", SqlDbType.VarChar,500);
                    cmd.Parameters["@NombreProyecto"].Value = evaluacionExpedienteTecnicoObraDTO.NombreProyecto;

                    cmd.Parameters.Add("@CodigoSituacionExpedienteTecnico", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoSituacionExpedienteTecnico"].Value = evaluacionExpedienteTecnicoObraDTO.CodigoSituacionExpedienteTecnico;

                    cmd.Parameters.Add("@CodigoTipoProceso", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoProceso"].Value = evaluacionExpedienteTecnicoObraDTO.CodigoTipoProceso;

                    cmd.Parameters.Add("@CodigoTipoProyecto", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoProyecto"].Value = evaluacionExpedienteTecnicoObraDTO.CodigoTipoProyecto;

                    cmd.Parameters.Add("@CodigoZonaNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoZonaNaval"].Value = evaluacionExpedienteTecnicoObraDTO.CodigoZonaNaval;

                    cmd.Parameters.Add("@CodigoAreaDiperadmon", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoAreaDiperadmon"].Value = evaluacionExpedienteTecnicoObraDTO.CodigoAreaDiperadmon;

                    cmd.Parameters.Add("@MontoContractual", SqlDbType.Decimal);
                    cmd.Parameters["@MontoContractual"].Value = evaluacionExpedienteTecnicoObraDTO.MontoContractual;

                    cmd.Parameters.Add("@FechaInicioEvaluacionProyecto", SqlDbType.Date);
                    cmd.Parameters["@FechaInicioEvaluacionProyecto"].Value = evaluacionExpedienteTecnicoObraDTO.FechaInicioEvaluacionProyecto;

                    cmd.Parameters.Add("@PorcentajeAvanceProyecto", SqlDbType.Int);
                    cmd.Parameters["@PorcentajeAvanceProyecto"].Value = evaluacionExpedienteTecnicoObraDTO.PorcentajeAvanceProyecto;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = evaluacionExpedienteTecnicoObraDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = evaluacionExpedienteTecnicoObraDTO.UsuarioIngresoRegistro;

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

        public EvaluacionExpedienteTecnicoObraDTO BuscarFormato(int Codigo)
        {
            EvaluacionExpedienteTecnicoObraDTO evaluacionExpedienteTecnicoObraDTO = new EvaluacionExpedienteTecnicoObraDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EvaluacionExpedienteTecnicoObraEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EvaluacionExpedienteTecnicoObraId", SqlDbType.Int);
                    cmd.Parameters["@EvaluacionExpedienteTecnicoObraId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        evaluacionExpedienteTecnicoObraDTO.EvaluacionExpedienteTecnicoObraId = Convert.ToInt32(dr["EvaluacionExpedienteTecnicoObraId"]);
                        evaluacionExpedienteTecnicoObraDTO.NombreProyecto = dr["NombreProyecto"].ToString();
                        evaluacionExpedienteTecnicoObraDTO.CodigoSituacionExpedienteTecnico =dr["CodigoSituacionExpedienteTecnico"].ToString();
                        evaluacionExpedienteTecnicoObraDTO.CodigoTipoProceso = dr["CodigoTipoProceso"].ToString();
                        evaluacionExpedienteTecnicoObraDTO.CodigoTipoProyecto = dr["CodigoTipoProyecto"].ToString();
                        evaluacionExpedienteTecnicoObraDTO.CodigoZonaNaval = dr["CodigoZonaNaval"].ToString();
                        evaluacionExpedienteTecnicoObraDTO.CodigoAreaDiperadmon = dr["CodigoAreaDiperadmon"].ToString();
                        evaluacionExpedienteTecnicoObraDTO.MontoContractual = Convert.ToDecimal(dr["MontoContractual"]);
                        evaluacionExpedienteTecnicoObraDTO.FechaInicioEvaluacionProyecto = Convert.ToDateTime(dr["FechaInicioEvaluacionProyecto"]).ToString("yyy-MM-dd");
                        evaluacionExpedienteTecnicoObraDTO.PorcentajeAvanceProyecto = Convert.ToInt32(dr["PorcentajeAvanceProyecto"]); 
   

                        }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return evaluacionExpedienteTecnicoObraDTO;
        }

        public string ActualizaFormato(EvaluacionExpedienteTecnicoObraDTO evaluacionExpedienteTecnicoObraDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_EvaluacionExpedienteTecnicoObraActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@EvaluacionExpedienteTecnicoObraId", SqlDbType.Int);
                    cmd.Parameters["@EvaluacionExpedienteTecnicoObraId"].Value = evaluacionExpedienteTecnicoObraDTO.EvaluacionExpedienteTecnicoObraId;

                    cmd.Parameters.Add("@NombreProyecto", SqlDbType.VarChar,500);
                    cmd.Parameters["@NombreProyecto"].Value = evaluacionExpedienteTecnicoObraDTO.NombreProyecto;

                    cmd.Parameters.Add("@CodigoSituacionExpedienteTecnico", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoSituacionExpedienteTecnico"].Value = evaluacionExpedienteTecnicoObraDTO.CodigoSituacionExpedienteTecnico;

                    cmd.Parameters.Add("@CodigoTipoProceso", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoProceso"].Value = evaluacionExpedienteTecnicoObraDTO.CodigoTipoProceso;

                    cmd.Parameters.Add("@CodigoTipoProyecto", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoProyecto"].Value = evaluacionExpedienteTecnicoObraDTO.CodigoTipoProyecto;

                    cmd.Parameters.Add("@CodigoZonaNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoZonaNaval"].Value = evaluacionExpedienteTecnicoObraDTO.CodigoZonaNaval;

                    cmd.Parameters.Add("@CodigoAreaDiperadmon", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoAreaDiperadmon"].Value = evaluacionExpedienteTecnicoObraDTO.CodigoAreaDiperadmon;

                    cmd.Parameters.Add("@MontoContractual", SqlDbType.Decimal);
                    cmd.Parameters["@MontoContractual"].Value = evaluacionExpedienteTecnicoObraDTO.MontoContractual;

                    cmd.Parameters.Add("@FechaInicioEvaluacionProyecto", SqlDbType.Date);
                    cmd.Parameters["@FechaInicioEvaluacionProyecto"].Value = evaluacionExpedienteTecnicoObraDTO.FechaInicioEvaluacionProyecto;

                    cmd.Parameters.Add("@PorcentajeAvanceProyecto", SqlDbType.Int);
                    cmd.Parameters["@PorcentajeAvanceProyecto"].Value = evaluacionExpedienteTecnicoObraDTO.PorcentajeAvanceProyecto;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = evaluacionExpedienteTecnicoObraDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(EvaluacionExpedienteTecnicoObraDTO evaluacionExpedienteTecnicoObraDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EvaluacionExpedienteTecnicoObraEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EvaluacionExpedienteTecnicoObraId", SqlDbType.Int);
                    cmd.Parameters["@EvaluacionExpedienteTecnicoObraId"].Value = evaluacionExpedienteTecnicoObraDTO.EvaluacionExpedienteTecnicoObraId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = evaluacionExpedienteTecnicoObraDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(EvaluacionExpedienteTecnicoObraDTO evaluacionExpedienteTecnicoObraDTO)
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
                    cmd.Parameters["@Formato"].Value = "EvaluacionExpedienteTecnicoObra";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = evaluacionExpedienteTecnicoObraDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = evaluacionExpedienteTecnicoObraDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_EvaluacionExpedienteTecnicoObraRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EvaluacionExpedienteTecnicoObra", SqlDbType.Structured);
                    cmd.Parameters["@EvaluacionExpedienteTecnicoObra"].TypeName = "Formato.EvaluacionExpedienteTecnicoObra";
                    cmd.Parameters["@EvaluacionExpedienteTecnicoObra"].Value = datos;

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
