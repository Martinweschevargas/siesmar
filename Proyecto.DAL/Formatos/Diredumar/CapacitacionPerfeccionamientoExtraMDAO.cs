using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Diredumar;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Diredumar
{
    public class CapacitacionPerfeccionamientoExtraMDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<CapacitacionPerfeccionamientoExtraMDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<CapacitacionPerfeccionamientoExtraMDTO> lista = new List<CapacitacionPerfeccionamientoExtraMDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_CapacitacionPerfeccionamientoExtraMListar", conexion);
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
                        lista.Add(new CapacitacionPerfeccionamientoExtraMDTO()
                        {
                            CapacitacionPerfeccionamientoExtraMId = Convert.ToInt32(dr["CapacitacionPerfeccionamientoExtraMId"]),
                            CIPCapaPerf = dr["CIPCapaPerf"].ToString(),
                            DNICapaPerf = dr["DNICapaPerf"].ToString(),
                            DescTipoPersonalMilitar = dr["DescTipoPersonalMilitar"].ToString(),
                            DescGrado = dr["DescGrado"].ToString(),
                            DescNivelEstudio = dr["DescNivelEstudio"].ToString(),
                            DescInstitucionEducativaSuperior = dr["DescInstitucionEducativaSuperior"].ToString(),
                            MencionCapacitacion = dr["MencionCapacitacion"].ToString(),
                            FinanciamientoCapacitacion = dr["FinanciamientoCapacitacion"].ToString(),
                            NombrePais = dr["NombrePais"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"]),
                        });
                    }
                }
            }
            return lista;
        }

        public List<CapacitacionPerfeccionamientoExtraMDTO> DiredumarVisualizacionCapacitacionPerfeccionamientoExtraPSubalterno(int? CargaId = null)
        {
            List<CapacitacionPerfeccionamientoExtraMDTO> lista = new List<CapacitacionPerfeccionamientoExtraMDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Reporte.usp_DiredumarVisualizacionCapacitacionPerfeccionamientoExtraPSubalterno", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;


                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new CapacitacionPerfeccionamientoExtraMDTO()
                        {
                            DNICapaPerf = dr["DNICapaPerf"].ToString(),
                            DescTipoPersonalMilitar = dr["DescTipoPersonalMilitar"].ToString(),
                            CodigoGradoPersonalMilitar = dr["CodigoGradoPersonalMilitar"].ToString(),
                            CodigoNivelEstudio = dr["CodigoNivelEstudio"].ToString(),
                            DescInstitucionEducativaSuperior = dr["DescInstitucionEducativaSuperior"].ToString(),
                            MencionCapacitacion = dr["MencionCapacitacion"].ToString(),
                            FinanciamientoCapacitacion = dr["FinanciamientoCapacitacion"].ToString(),
                            NumericoPais = dr["NumericoPais"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(CapacitacionPerfeccionamientoExtraMDTO capacitacionPerfecExtraDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_CapacitacionPerfeccionamientoExtraMRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CIPCapaPerf", SqlDbType.VarChar,8);
                    cmd.Parameters["@CIPCapaPerf"].Value = capacitacionPerfecExtraDTO.CIPCapaPerf;

                    cmd.Parameters.Add("@DNICapaPerf", SqlDbType.VarChar,8);
                    cmd.Parameters["@DNICapaPerf"].Value = capacitacionPerfecExtraDTO.DNICapaPerf;

                    cmd.Parameters.Add("@CodigoTipoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoPersonalMilitar"].Value = capacitacionPerfecExtraDTO.CodigoTipoPersonalMilitar;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitar"].Value = capacitacionPerfecExtraDTO.CodigoGradoPersonalMilitar;

                    cmd.Parameters.Add("@CodigoNivelEstudio", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoNivelEstudio"].Value = capacitacionPerfecExtraDTO.CodigoNivelEstudio;

                    cmd.Parameters.Add("@CodigoInstitucionEducativaSuperior", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoInstitucionEducativaSuperior"].Value = capacitacionPerfecExtraDTO.CodigoInstitucionEducativaSuperior;

                    cmd.Parameters.Add("@MencionCapacitacion", SqlDbType.VarChar, 200);
                    cmd.Parameters["@MencionCapacitacion"].Value = capacitacionPerfecExtraDTO.MencionCapacitacion;

                    cmd.Parameters.Add("@FinanciamientoCapacitacion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@FinanciamientoCapacitacion"].Value = capacitacionPerfecExtraDTO.FinanciamientoCapacitacion;

                    cmd.Parameters.Add("@NumericoPais", SqlDbType.VarChar, 20);
                    cmd.Parameters["@NumericoPais"].Value = capacitacionPerfecExtraDTO.NumericoPais;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = capacitacionPerfecExtraDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = capacitacionPerfecExtraDTO.UsuarioIngresoRegistro;

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

        public CapacitacionPerfeccionamientoExtraMDTO BuscarFormato(int Codigo)
        {
            CapacitacionPerfeccionamientoExtraMDTO capacitacionPerfecExtraDTO = new CapacitacionPerfeccionamientoExtraMDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_CapacitacionPerfeccionamientoExtraMEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CapacitacionPerfeccionamientoExtraMId", SqlDbType.Int);
                    cmd.Parameters["@CapacitacionPerfeccionamientoExtraMId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        capacitacionPerfecExtraDTO.CapacitacionPerfeccionamientoExtraMId = Convert.ToInt32(dr["CapacitacionPerfeccionamientoExtraMId"]);
                        capacitacionPerfecExtraDTO.CIPCapaPerf = dr["CIPCapaPerf"].ToString();
                        capacitacionPerfecExtraDTO.DNICapaPerf = dr["DNICapaPerf"].ToString();
                        capacitacionPerfecExtraDTO.CodigoTipoPersonalMilitar = dr["CodigoTipoPersonalMilitar"].ToString();
                        capacitacionPerfecExtraDTO.CodigoGradoPersonalMilitar = dr["CodigoGradoPersonalMilitar"].ToString();
                        capacitacionPerfecExtraDTO.CodigoNivelEstudio = dr["CodigoNivelEstudio"].ToString();
                        capacitacionPerfecExtraDTO.CodigoInstitucionEducativaSuperior = dr["CodigoInstitucionEducativaSuperior"].ToString();
                        capacitacionPerfecExtraDTO.MencionCapacitacion = dr["MencionCapacitacion"].ToString();
                        capacitacionPerfecExtraDTO.FinanciamientoCapacitacion = dr["FinanciamientoCapacitacion"].ToString();
                        capacitacionPerfecExtraDTO.NumericoPais = dr["NumericoPais"].ToString();


                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return capacitacionPerfecExtraDTO;
        }

        public string ActualizaFormato(CapacitacionPerfeccionamientoExtraMDTO capacitacionPerfecExtraDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_CapacitacionPerfeccionamientoExtraMActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@CapacitacionPerfeccionamientoExtraMId", SqlDbType.Int);
                    cmd.Parameters["@CapacitacionPerfeccionamientoExtraMId"].Value = capacitacionPerfecExtraDTO.CapacitacionPerfeccionamientoExtraMId;

                    cmd.Parameters.Add("@CIPCapaPerf", SqlDbType.VarChar, 8);
                    cmd.Parameters["@CIPCapaPerf"].Value = capacitacionPerfecExtraDTO.CIPCapaPerf;

                    cmd.Parameters.Add("@DNICapaPerf", SqlDbType.VarChar, 8);
                    cmd.Parameters["@DNICapaPerf"].Value = capacitacionPerfecExtraDTO.DNICapaPerf;

                    cmd.Parameters.Add("@CodigoTipoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoPersonalMilitar"].Value = capacitacionPerfecExtraDTO.CodigoTipoPersonalMilitar;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitar"].Value = capacitacionPerfecExtraDTO.CodigoGradoPersonalMilitar;

                    cmd.Parameters.Add("@CodigoNivelEstudio", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoNivelEstudio"].Value = capacitacionPerfecExtraDTO.CodigoNivelEstudio;

                    cmd.Parameters.Add("@CodigoInstitucionEducativaSuperior", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoInstitucionEducativaSuperior"].Value = capacitacionPerfecExtraDTO.CodigoInstitucionEducativaSuperior;

                    cmd.Parameters.Add("@MencionCapacitacion", SqlDbType.VarChar, 200);
                    cmd.Parameters["@MencionCapacitacion"].Value = capacitacionPerfecExtraDTO.MencionCapacitacion;

                    cmd.Parameters.Add("@FinanciamientoCapacitacion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@FinanciamientoCapacitacion"].Value = capacitacionPerfecExtraDTO.FinanciamientoCapacitacion;

                    cmd.Parameters.Add("@NumericoPais", SqlDbType.VarChar, 20);
                    cmd.Parameters["@NumericoPais"].Value = capacitacionPerfecExtraDTO.NumericoPais;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = capacitacionPerfecExtraDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(CapacitacionPerfeccionamientoExtraMDTO capacitacionPerfecExtraDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_CapacitacionPerfeccionamientoExtraMEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CapacitacionPerfeccionamientoExtraMId", SqlDbType.Int);
                    cmd.Parameters["@CapacitacionPerfeccionamientoExtraMId"].Value = capacitacionPerfecExtraDTO.CapacitacionPerfeccionamientoExtraMId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = capacitacionPerfecExtraDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(CapacitacionPerfeccionamientoExtraMDTO capacitacionPerfecExtraDTO)
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
                    cmd.Parameters["@Formato"].Value = "CapacitacionPerfeccionamientoExtraM";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = capacitacionPerfecExtraDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = capacitacionPerfecExtraDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_CapacitacionPerfeccionamientoExtraMRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CapacitacionPerfeccionamientoExtraM", SqlDbType.Structured);
                    cmd.Parameters["@CapacitacionPerfeccionamientoExtraM"].TypeName = "Formato.CapacitacionPerfeccionamientoExtraM";
                    cmd.Parameters["@CapacitacionPerfeccionamientoExtraM"].Value = datos;

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
