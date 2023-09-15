using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Diredumar;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Diredumar
{
    public class CapacitacionPerfeccionamientoExtraCDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<CapacitacionPerfeccionamientoExtraCDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<CapacitacionPerfeccionamientoExtraCDTO> lista = new List<CapacitacionPerfeccionamientoExtraCDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_CapacitacionPerfeccionamientoExtraCListar", conexion);
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
                        lista.Add(new CapacitacionPerfeccionamientoExtraCDTO()
                        {
                            CapacitacionPerfeccionamientoExtraCId = Convert.ToInt32(dr["CapacitacionPerfeccionamientoExtraCId"]),
                            CIPCapaPerfPCivil = dr["CIPCapaPerfPCivil"].ToString(),
                            TipoDocumento = dr["TipoDocumento"].ToString(),
                            DNICapaPerfPCivil = dr["DNICapaPerfPCivil"].ToString(),
                            DescGrupoOcupacionalCivil = dr["DescGrupoOcupacionalCivil"].ToString(),
                            DescNivelEstudio = dr["DescNivelEstudio"].ToString(),
                            DescInstitucionEducativaSuperior = dr["DescInstitucionEducativaSuperior"].ToString(),
                            MencionCapacitacion = dr["MencionCapacitacion"].ToString(),
                            FinanciamientoCapacitacion = dr["FinanciamientoCapacitacion"].ToString(),
                            DescCondicionLaboralCivil = dr["DescCondicionLaboralCivil"].ToString(),
                            NombrePais = dr["NombrePais"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"]),

                        });
                    }
                }
            }
            return lista;
        }

        public List<CapacitacionPerfeccionamientoExtraCDTO> DiredumarVisualizacionCapacitacionPerfeccionamientoExtraPCivil(int? CargaId = null)
        {
            List<CapacitacionPerfeccionamientoExtraCDTO> lista = new List<CapacitacionPerfeccionamientoExtraCDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Reporte.usp_DiredumarVisualizacionCapacitacionPerfeccionamientoExtraPCivil", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;


                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new CapacitacionPerfeccionamientoExtraCDTO()
                        {
                            TipoDocumento = dr["TipoDocumento"].ToString(),
                            DNICapaPerfPCivil = dr["DNICapaPerfPCivil"].ToString(),
                            CodigoGrupoOcupacionalCivil = dr["CodigoGrupoOcupacionalCivil"].ToString(),
                            CodigoNivelEstudio = dr["CodigoNivelEstudio"].ToString(),
                            DescInstitucionEducativaSuperior = dr["DescInstitucionEducativaSuperior"].ToString(),
                            MencionCapacitacion = dr["MencionCapacitacion"].ToString(),
                            FinanciamientoCapacitacion = dr["FinanciamientoCapacitacion"].ToString(),
                            DescCondicionLaboralCivil = dr["DescCondicionLaboralCivil"].ToString(),
                            NumericoPais = dr["NumericoPais"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(CapacitacionPerfeccionamientoExtraCDTO capacitacionPerfeccionamientoExtraCDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_CapacitacionPerfeccionamientoExtraCRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

      

                    cmd.Parameters.Add("@CIPCapaPerfPCivil", SqlDbType.VarChar, 8);
                    cmd.Parameters["@CIPCapaPerfPCivil"].Value = capacitacionPerfeccionamientoExtraCDTO.CIPCapaPerfPCivil;

                    cmd.Parameters.Add("@TipoDocumento", SqlDbType.VarChar, 20);
                    cmd.Parameters["@TipoDocumento"].Value = capacitacionPerfeccionamientoExtraCDTO.TipoDocumento;

                    cmd.Parameters.Add("@DNICapaPerfPCivil", SqlDbType.VarChar, 8);
                    cmd.Parameters["@DNICapaPerfPCivil"].Value = capacitacionPerfeccionamientoExtraCDTO.DNICapaPerfPCivil;

                    cmd.Parameters.Add("@CodigoGrupoOcupacionalCivil", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGrupoOcupacionalCivil"].Value = capacitacionPerfeccionamientoExtraCDTO.CodigoGrupoOcupacionalCivil;

                    cmd.Parameters.Add("@CodigoNivelEstudio", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoNivelEstudio"].Value = capacitacionPerfeccionamientoExtraCDTO.CodigoNivelEstudio;

                    cmd.Parameters.Add("@CodigoInstitucionEducativaSuperior", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoInstitucionEducativaSuperior"].Value = capacitacionPerfeccionamientoExtraCDTO.CodigoInstitucionEducativaSuperior;

                    cmd.Parameters.Add("@MencionCapacitacion", SqlDbType.VarChar, 200);
                    cmd.Parameters["@MencionCapacitacion"].Value = capacitacionPerfeccionamientoExtraCDTO.MencionCapacitacion;

                    cmd.Parameters.Add("@FinanciamientoCapacitacion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@FinanciamientoCapacitacion"].Value = capacitacionPerfeccionamientoExtraCDTO.FinanciamientoCapacitacion;

                    cmd.Parameters.Add("@CodigoCondicionLaboralCivil", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCondicionLaboralCivil"].Value = capacitacionPerfeccionamientoExtraCDTO.CodigoCondicionLaboralCivil;

                    cmd.Parameters.Add("@NumericoPais", SqlDbType.VarChar, 20);
                    cmd.Parameters["@NumericoPais"].Value = capacitacionPerfeccionamientoExtraCDTO.NumericoPais;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = capacitacionPerfeccionamientoExtraCDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = capacitacionPerfeccionamientoExtraCDTO.UsuarioIngresoRegistro;

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

        public CapacitacionPerfeccionamientoExtraCDTO BuscarFormato(int Codigo)
        {
            CapacitacionPerfeccionamientoExtraCDTO capacitacionPerfeccionamientoExtraCDTO = new CapacitacionPerfeccionamientoExtraCDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_CapacitacionPerfeccionamientoExtraCEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CapacitacionPerfeccionamientoExtraCId", SqlDbType.Int);
                    cmd.Parameters["@CapacitacionPerfeccionamientoExtraCId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        capacitacionPerfeccionamientoExtraCDTO.CapacitacionPerfeccionamientoExtraCId = Convert.ToInt32(dr["CapacitacionPerfeccionamientoExtraCId"]);
                        capacitacionPerfeccionamientoExtraCDTO.CIPCapaPerfPCivil = dr["CIPCapaPerfPCivil"].ToString();
                        capacitacionPerfeccionamientoExtraCDTO.TipoDocumento = dr["TipoDocumento"].ToString();
                        capacitacionPerfeccionamientoExtraCDTO.DNICapaPerfPCivil = dr["DNICapaPerfPCivil"].ToString();
                        capacitacionPerfeccionamientoExtraCDTO.CodigoGrupoOcupacionalCivil = dr["CodigoGrupoOcupacionalCivil"].ToString();
                        capacitacionPerfeccionamientoExtraCDTO.CodigoNivelEstudio = dr["CodigoNivelEstudio"].ToString(); 
                        capacitacionPerfeccionamientoExtraCDTO.CodigoInstitucionEducativaSuperior = dr["CodigoInstitucionEducativaSuperior"].ToString();
                        capacitacionPerfeccionamientoExtraCDTO.MencionCapacitacion = dr["MencionCapacitacion"].ToString();
                        capacitacionPerfeccionamientoExtraCDTO.FinanciamientoCapacitacion = dr["FinanciamientoCapacitacion"].ToString();
                        capacitacionPerfeccionamientoExtraCDTO.CodigoCondicionLaboralCivil = dr["CodigoCondicionLaboralCivil"].ToString();
                        capacitacionPerfeccionamientoExtraCDTO.NumericoPais = dr["NumericoPais"].ToString(); 


                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return capacitacionPerfeccionamientoExtraCDTO;
        }

        public string ActualizaFormato(CapacitacionPerfeccionamientoExtraCDTO capacitacionPerfeccionamientoExtraCDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_CapacitacionPerfeccionamientoExtraCActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@CapacitacionPerfeccionamientoExtraCId", SqlDbType.Int);
                    cmd.Parameters["@CapacitacionPerfeccionamientoExtraCId"].Value = capacitacionPerfeccionamientoExtraCDTO.CapacitacionPerfeccionamientoExtraCId;

                    cmd.Parameters.Add("@CIPCapaPerfPCivil", SqlDbType.VarChar, 8);
                    cmd.Parameters["@CIPCapaPerfPCivil"].Value = capacitacionPerfeccionamientoExtraCDTO.CIPCapaPerfPCivil;

                    cmd.Parameters.Add("@TipoDocumento", SqlDbType.VarChar, 20);
                    cmd.Parameters["@TipoDocumento"].Value = capacitacionPerfeccionamientoExtraCDTO.TipoDocumento;

                    cmd.Parameters.Add("@DNICapaPerfPCivil", SqlDbType.VarChar, 8);
                    cmd.Parameters["@DNICapaPerfPCivil"].Value = capacitacionPerfeccionamientoExtraCDTO.DNICapaPerfPCivil;

                    cmd.Parameters.Add("@CodigoGrupoOcupacionalCivil", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGrupoOcupacionalCivil"].Value = capacitacionPerfeccionamientoExtraCDTO.CodigoGrupoOcupacionalCivil;

                    cmd.Parameters.Add("@CodigoNivelEstudio", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoNivelEstudio"].Value = capacitacionPerfeccionamientoExtraCDTO.CodigoNivelEstudio;

                    cmd.Parameters.Add("@CodigoInstitucionEducativaSuperior", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoInstitucionEducativaSuperior"].Value = capacitacionPerfeccionamientoExtraCDTO.CodigoInstitucionEducativaSuperior;

                    cmd.Parameters.Add("@MencionCapacitacion", SqlDbType.VarChar, 200);
                    cmd.Parameters["@MencionCapacitacion"].Value = capacitacionPerfeccionamientoExtraCDTO.MencionCapacitacion;

                    cmd.Parameters.Add("@FinanciamientoCapacitacion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@FinanciamientoCapacitacion"].Value = capacitacionPerfeccionamientoExtraCDTO.FinanciamientoCapacitacion;

                    cmd.Parameters.Add("@CodigoCondicionLaboralCivil", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCondicionLaboralCivil"].Value = capacitacionPerfeccionamientoExtraCDTO.CodigoCondicionLaboralCivil;

                    cmd.Parameters.Add("@NumericoPais", SqlDbType.VarChar, 20);
                    cmd.Parameters["@NumericoPais"].Value = capacitacionPerfeccionamientoExtraCDTO.NumericoPais;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = capacitacionPerfeccionamientoExtraCDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(CapacitacionPerfeccionamientoExtraCDTO capacitacionPerfeccionamientoExtraCDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_CapacitacionPerfeccionamientoExtraCEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CapacitacionPerfeccionamientoExtraCId", SqlDbType.Int);
                    cmd.Parameters["@CapacitacionPerfeccionamientoExtraCId"].Value = capacitacionPerfeccionamientoExtraCDTO.CapacitacionPerfeccionamientoExtraCId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = capacitacionPerfeccionamientoExtraCDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(CapacitacionPerfeccionamientoExtraCDTO capacitacionPerfeccionamientoExtraCDTO)
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
                    cmd.Parameters["@Formato"].Value = "CapacitacionPerfeccionamientoExtraC";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = capacitacionPerfeccionamientoExtraCDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = capacitacionPerfeccionamientoExtraCDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_CapacitacionPerfeccionamientoExtraCRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CapacitacionPerfeccionamientoExtraC", SqlDbType.Structured);
                    cmd.Parameters["@CapacitacionPerfeccionamientoExtraC"].TypeName = "Formato.CapacitacionPerfeccionamientoExtraC";
                    cmd.Parameters["@CapacitacionPerfeccionamientoExtraC"].Value = datos;

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
