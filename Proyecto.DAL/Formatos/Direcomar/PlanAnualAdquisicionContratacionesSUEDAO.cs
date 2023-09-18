using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Direcomar;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Direcomar
{
    public class PlanAnualAdquisicionContratacionesSUEDAO
    { 
        SqlCommand cmd = new SqlCommand();

        public List<PlanAnualAdquisicionContratacionesSUEDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<PlanAnualAdquisicionContratacionesSUEDTO> lista = new List<PlanAnualAdquisicionContratacionesSUEDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_PlanAnualAdquisicionContratacionSUEListar", conexion);
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
                        lista.Add(new PlanAnualAdquisicionContratacionesSUEDTO()
                        {
                            PlanAnualAdquisicionContratacionId = Convert.ToInt32(dr["PlanAnualAdquisicionContratacionId"]),
                            AnioAdquisicion = Convert.ToInt32(dr["AnioAdquisicion"]),
                            DescMes = dr["DescMes"].ToString(),
                            DescSubUnidadEjecutora = dr["DescSubUnidadEjecutora"].ToString(),
                            IncluidosAdquisicion = Convert.ToInt32(dr["IncluidosAdquisicion"]),
                            ImporteIncluidosAdquisicion = Convert.ToDecimal(dr["ImporteIncluidosAdquisicion"]),
                            ConvocadosAdquisicion = Convert.ToInt32(dr["ConvocadosAdquisicion"]),
                            ImporteConvocadosAdquisicion = Convert.ToDecimal(dr["ImporteConvocadosAdquisicion"]),
                            ExcluidosAdquisicion = Convert.ToInt32(dr["ExcluidosAdquisicion"]),
                            ImporteExcluidoAdquisicion = Convert.ToDecimal(dr["ImporteExcluidoAdquisicion"]),
                            CargaId = Convert.ToInt32(dr["CargaId"]),
                        });
                    }
                }
            }
            return lista;
        }

        public List<PlanAnualAdquisicionContratacionesSUEDTO> DirecomarVisualizacionPlanAnualAdquisicionContratacionesSUE(int? CargaId = null, string? fechaInicio = null, string? fechaFin = null)
        {
            List<PlanAnualAdquisicionContratacionesSUEDTO> lista = new List<PlanAnualAdquisicionContratacionesSUEDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Reporte.DirecomarVisualizacionPlanAnualAdquisicionContratacionesSUE", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                cmd.Parameters.Add("@FechaInicio", SqlDbType.Date);
                cmd.Parameters["@FechaInicio"].Value = CargaId;

                cmd.Parameters.Add("@FechaFin", SqlDbType.Date);
                cmd.Parameters["@FechaFin"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new PlanAnualAdquisicionContratacionesSUEDTO()
                        {
                            AnioAdquisicion = Convert.ToInt32(dr["AnioAdquisicion"]),
                            DescMes = dr["DescMes"].ToString(),
                            DescSubUnidadEjecutora = dr["DescSubUnidadEjecutora"].ToString(),
                            IncluidosAdquisicion = Convert.ToInt32(dr["IncluidosAdquisicion"]),
                            ImporteIncluidosAdquisicion = Convert.ToDecimal(dr["ImporteIncluidosAdquisicion"]),
                            ConvocadosAdquisicion = Convert.ToInt32(dr["ConvocadosAdquisicion"]),
                            ImporteConvocadosAdquisicion = Convert.ToDecimal(dr["ImporteConvocadosAdquisicion"]),
                            ExcluidosAdquisicion = Convert.ToInt32(dr["ExcluidosAdquisicion"]),
                            ImporteExcluidoAdquisicion = Convert.ToDecimal(dr["ImporteExcluidoAdquisicion"]),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(PlanAnualAdquisicionContratacionesSUEDTO planAnualAdquisicionContratacionSUEDTO, string fechaCarga)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_PlanAnualAdquisicionContratacionSUERegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AnioAdquisicion", SqlDbType.Int);
                    cmd.Parameters["@AnioAdquisicion"].Value = planAnualAdquisicionContratacionSUEDTO.AnioAdquisicion;

                    cmd.Parameters.Add("@NumeroMes", SqlDbType.VarChar, 20);
                    cmd.Parameters["@NumeroMes"].Value = planAnualAdquisicionContratacionSUEDTO.NumeroMes;

                    cmd.Parameters.Add("@CodigoSubunidadEjecutora", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoSubunidadEjecutora"].Value = planAnualAdquisicionContratacionSUEDTO.CodigoSubunidadEjecutora;

                    cmd.Parameters.Add("@IncluidosAdquisicion", SqlDbType.Int);
                    cmd.Parameters["@IncluidosAdquisicion"].Value = planAnualAdquisicionContratacionSUEDTO.IncluidosAdquisicion;

                    cmd.Parameters.Add("@ImporteIncluidosAdquisicion", SqlDbType.Decimal);
                    cmd.Parameters["@ImporteIncluidosAdquisicion"].Value = planAnualAdquisicionContratacionSUEDTO.ImporteIncluidosAdquisicion;

                    cmd.Parameters.Add("@ConvocadosAdquisicion", SqlDbType.Int);
                    cmd.Parameters["@ConvocadosAdquisicion"].Value = planAnualAdquisicionContratacionSUEDTO.ConvocadosAdquisicion;

                    cmd.Parameters.Add("@ImporteConvocadosAdquisicion", SqlDbType.Decimal);
                    cmd.Parameters["@ImporteConvocadosAdquisicion"].Value = planAnualAdquisicionContratacionSUEDTO.ImporteConvocadosAdquisicion;

                    cmd.Parameters.Add("@ExcluidosAdquisicion", SqlDbType.Int);
                    cmd.Parameters["@ExcluidosAdquisicion"].Value = planAnualAdquisicionContratacionSUEDTO.ExcluidosAdquisicion;

                    cmd.Parameters.Add("@ImporteExcluidoAdquisicion", SqlDbType.Decimal);
                    cmd.Parameters["@ImporteExcluidoAdquisicion"].Value = planAnualAdquisicionContratacionSUEDTO.ImporteExcluidoAdquisicion;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = planAnualAdquisicionContratacionSUEDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = planAnualAdquisicionContratacionSUEDTO.UsuarioIngresoRegistro;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Mac"].Value = UtilitariosGlobales.obtenerDireccionMac();

                    cmd.Parameters.Add("@FechaCarga", SqlDbType.Date);
                    cmd.Parameters["@FechaCarga"].Value = fechaCarga;

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

        public PlanAnualAdquisicionContratacionesSUEDTO BuscarFormato(int Codigo)
        {
            PlanAnualAdquisicionContratacionesSUEDTO planAnualAdquisicionContratacionSUEDTO = new PlanAnualAdquisicionContratacionesSUEDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_PlanAnualAdquisicionContratacionSUEEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PlanAnualAdquisicionContratacionId", SqlDbType.Int);
                    cmd.Parameters["@PlanAnualAdquisicionContratacionId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        planAnualAdquisicionContratacionSUEDTO.PlanAnualAdquisicionContratacionId = Convert.ToInt32(dr["PlanAnualAdquisicionContratacionId"]);
                        planAnualAdquisicionContratacionSUEDTO.AnioAdquisicion = Convert.ToInt32(dr["AnioAdquisicion"]);
                        planAnualAdquisicionContratacionSUEDTO.NumeroMes = dr["NumeroMes"].ToString();
                        planAnualAdquisicionContratacionSUEDTO.CodigoSubunidadEjecutora = dr["CodigoSubunidadEjecutora"].ToString();
                        planAnualAdquisicionContratacionSUEDTO.IncluidosAdquisicion = Convert.ToInt32(dr["IncluidosAdquisicion"]);
                        planAnualAdquisicionContratacionSUEDTO.ImporteIncluidosAdquisicion = Convert.ToDecimal(dr["ImporteIncluidosAdquisicion"]);
                        planAnualAdquisicionContratacionSUEDTO.ConvocadosAdquisicion = Convert.ToInt32(dr["ConvocadosAdquisicion"]);
                        planAnualAdquisicionContratacionSUEDTO.ImporteConvocadosAdquisicion = Convert.ToDecimal(dr["ImporteConvocadosAdquisicion"]);
                        planAnualAdquisicionContratacionSUEDTO.ExcluidosAdquisicion = Convert.ToInt32(dr["ExcluidosAdquisicion"]);
                        planAnualAdquisicionContratacionSUEDTO.ImporteExcluidoAdquisicion = Convert.ToDecimal(dr["ImporteExcluidoAdquisicion"]);

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return planAnualAdquisicionContratacionSUEDTO;
        }

        public string ActualizaFormato(PlanAnualAdquisicionContratacionesSUEDTO planAnualAdquisicionContratacionSUEDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_PlanAnualAdquisicionContratacionSUEActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PlanAnualAdquisicionContratacionId", SqlDbType.Int);
                    cmd.Parameters["@PlanAnualAdquisicionContratacionId"].Value = planAnualAdquisicionContratacionSUEDTO.PlanAnualAdquisicionContratacionId;

                    cmd.Parameters.Add("@AnioAdquisicion", SqlDbType.Int);
                    cmd.Parameters["@AnioAdquisicion"].Value = planAnualAdquisicionContratacionSUEDTO.AnioAdquisicion;

                    cmd.Parameters.Add("@NumeroMes", SqlDbType.VarChar, 20);
                    cmd.Parameters["@NumeroMes"].Value = planAnualAdquisicionContratacionSUEDTO.NumeroMes;

                    cmd.Parameters.Add("@CodigoSubunidadEjecutora", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoSubunidadEjecutora"].Value = planAnualAdquisicionContratacionSUEDTO.CodigoSubunidadEjecutora;

                    cmd.Parameters.Add("@IncluidosAdquisicion", SqlDbType.Int);
                    cmd.Parameters["@IncluidosAdquisicion"].Value = planAnualAdquisicionContratacionSUEDTO.IncluidosAdquisicion;

                    cmd.Parameters.Add("@ImporteIncluidosAdquisicion", SqlDbType.Decimal);
                    cmd.Parameters["@ImporteIncluidosAdquisicion"].Value = planAnualAdquisicionContratacionSUEDTO.ImporteIncluidosAdquisicion;

                    cmd.Parameters.Add("@ConvocadosAdquisicion", SqlDbType.Int);
                    cmd.Parameters["@ConvocadosAdquisicion"].Value = planAnualAdquisicionContratacionSUEDTO.ConvocadosAdquisicion;

                    cmd.Parameters.Add("@ImporteConvocadosAdquisicion", SqlDbType.Decimal);
                    cmd.Parameters["@ImporteConvocadosAdquisicion"].Value = planAnualAdquisicionContratacionSUEDTO.ImporteConvocadosAdquisicion;

                    cmd.Parameters.Add("@ExcluidosAdquisicion", SqlDbType.Int);
                    cmd.Parameters["@ExcluidosAdquisicion"].Value = planAnualAdquisicionContratacionSUEDTO.ExcluidosAdquisicion;

                    cmd.Parameters.Add("@ImporteExcluidoAdquisicion", SqlDbType.Decimal);
                    cmd.Parameters["@ImporteExcluidoAdquisicion"].Value = planAnualAdquisicionContratacionSUEDTO.ImporteExcluidoAdquisicion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = planAnualAdquisicionContratacionSUEDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(PlanAnualAdquisicionContratacionesSUEDTO planAnualAdquisicionContratacionSUEDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_PlanAnualAdquisicionContratacionSUEEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PlanAnualAdquisicionContratacionId", SqlDbType.Int);
                    cmd.Parameters["@PlanAnualAdquisicionContratacionId"].Value = planAnualAdquisicionContratacionSUEDTO.PlanAnualAdquisicionContratacionId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = planAnualAdquisicionContratacionSUEDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(PlanAnualAdquisicionContratacionesSUEDTO planAnualAdquisicionContratacionSUEDTO)
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
                    cmd.Parameters["@Formato"].Value = "PlanAnualAdquisicionContratacionSUE";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = planAnualAdquisicionContratacionSUEDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = planAnualAdquisicionContratacionSUEDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_PlanAnualAdquisicionContratacionSUERegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PlanAnualAdquisicionContratacionSUE", SqlDbType.Structured);
                    cmd.Parameters["@PlanAnualAdquisicionContratacionSUE"].TypeName = "Formato.PlanAnualAdquisicionContratacionSUE";
                    cmd.Parameters["@PlanAnualAdquisicionContratacionSUE"].Value = datos;

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
