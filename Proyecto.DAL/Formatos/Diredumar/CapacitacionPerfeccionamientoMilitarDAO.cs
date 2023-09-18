using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Diredumar;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Diredumar
{
    public class CapacitacionPerfeccionamientoMilitarDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<CapacitacionPerfeccionamientoMilitarDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<CapacitacionPerfeccionamientoMilitarDTO> lista = new List<CapacitacionPerfeccionamientoMilitarDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_CapacitacionPerfeccionamientoMilitarListar", conexion);
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
                        lista.Add(new CapacitacionPerfeccionamientoMilitarDTO()
                        {
                            CapacitacionPerfeccionamientoMilitarId = Convert.ToInt32(dr["CapacitacionPerfeccionamientoMilitarId"]),
                            CIPCapPerf = dr["CIPCapPerf"].ToString(),
                            DNICapPerf = dr["DNICapPerf"].ToString(),
                            DescTipoPersonalMilitar = dr["DescTipoPersonalMilitar"].ToString(),
                            DescGrado = dr["DescGrado"].ToString(),
                            NombrePais = dr["NombrePais"].ToString(),
                            DescEntidadMilitar = dr["DescEntidadMilitar"].ToString(),
                            DescCodigoEscuela = dr["DescCodigoEscuela"].ToString(),
                            MensionCurso = dr["MensionCurso"].ToString(),
                            HorasCurso = Convert.ToInt32(dr["HorasCurso"]),
                            CargaId = Convert.ToInt32(dr["CargaId"])
                        });
                    }
                }
            }
            return lista;
        }


        public List<CapacitacionPerfeccionamientoMilitarDTO> DiredumarVisualizacionCapacitacionPerfeccionamientoMilitarPSuperior(int? CargaId = null)
        {
            List<CapacitacionPerfeccionamientoMilitarDTO> lista = new List<CapacitacionPerfeccionamientoMilitarDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Reporte.usp_DiredumarVisualizacionCapacitacionPerfeccionamientoMilitarPSuperior", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;


                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new CapacitacionPerfeccionamientoMilitarDTO()
                        {
                            DNICapPerf = dr["DNICapPerf"].ToString(),
                            DescTipoPersonalMilitar = dr["DescTipoPersonalMilitar"].ToString(),
                            CodigoGradoPersonalMilitar = dr["CodigoGradoPersonalMilitar"].ToString(),
                            NumericoPais = dr["NumericoPais "].ToString(),
                            DescEntidadMilitar = dr["DescEntidadMilitar"].ToString(),
                            DescCodigoEscuela = dr["DescCodigoEscuela"].ToString(),
                            MensionCurso = dr["MensionCurso"].ToString(),
                            HorasCurso = Convert.ToInt32(dr["HorasCurso"]),
                        });
                    }
                }
            }
            return lista;
        }


        public string AgregarRegistro(CapacitacionPerfeccionamientoMilitarDTO capacitacionPerfecMilitarDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_CapacitacionPerfeccionamientoMilitarRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CIPCapPerf", SqlDbType.VarChar, 8);
                    cmd.Parameters["@CIPCapPerf"].Value = capacitacionPerfecMilitarDTO.CIPCapPerf;

                    cmd.Parameters.Add("@DNICapPerf", SqlDbType.VarChar, 8);
                    cmd.Parameters["@DNICapPerf"].Value = capacitacionPerfecMilitarDTO.DNICapPerf;

                    cmd.Parameters.Add("@CodigoTipoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoPersonalMilitar"].Value = capacitacionPerfecMilitarDTO.CodigoTipoPersonalMilitar;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitar"].Value = capacitacionPerfecMilitarDTO.CodigoGradoPersonalMilitar;

                    cmd.Parameters.Add("@NumericoPais ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@NumericoPais "].Value = capacitacionPerfecMilitarDTO.NumericoPais;

                    cmd.Parameters.Add("@CodigoEntidadMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEntidadMilitar"].Value = capacitacionPerfecMilitarDTO.CodigoEntidadMilitar;

                    cmd.Parameters.Add("@CodigoCodigoEscuela", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCodigoEscuela"].Value = capacitacionPerfecMilitarDTO.CodigoCodigoEscuela;

                    cmd.Parameters.Add("@MensionCurso", SqlDbType.VarChar, 200);
                    cmd.Parameters["@MensionCurso"].Value = capacitacionPerfecMilitarDTO.MensionCurso;

                    cmd.Parameters.Add("@HorasCurso", SqlDbType.Int);
                    cmd.Parameters["@HorasCurso"].Value = capacitacionPerfecMilitarDTO.HorasCurso;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = capacitacionPerfecMilitarDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = capacitacionPerfecMilitarDTO.UsuarioIngresoRegistro;

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

        public CapacitacionPerfeccionamientoMilitarDTO BuscarFormato(int Codigo)
        {
            CapacitacionPerfeccionamientoMilitarDTO capacitacionPerfecMilitarDTO = new CapacitacionPerfeccionamientoMilitarDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_CapacitacionPerfeccionamientoMilitarEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CapacitacionPerfeccionamientoMilitarId", SqlDbType.Int);
                    cmd.Parameters["@CapacitacionPerfeccionamientoMilitarId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        capacitacionPerfecMilitarDTO.CapacitacionPerfeccionamientoMilitarId = Convert.ToInt32(dr["CapacitacionPerfeccionamientoMilitarId"]);
                        capacitacionPerfecMilitarDTO.CIPCapPerf = dr["CIPCapPerf"].ToString();
                        capacitacionPerfecMilitarDTO.DNICapPerf = dr["DNICapPerf"].ToString();
                        capacitacionPerfecMilitarDTO.CodigoTipoPersonalMilitar = dr["CodigoTipoPersonalMilitar"].ToString();
                        capacitacionPerfecMilitarDTO.CodigoGradoPersonalMilitar = dr["CodigoGradoPersonalMilitar"].ToString();
                        capacitacionPerfecMilitarDTO.NumericoPais = dr["NumericoPais"].ToString();
                        capacitacionPerfecMilitarDTO.CodigoEntidadMilitar = dr["CodigoEntidadMilitar"].ToString();
                        capacitacionPerfecMilitarDTO.CodigoCodigoEscuela = dr["CodigoEscuela"].ToString();
                        capacitacionPerfecMilitarDTO.MensionCurso = dr["MensionCurso"].ToString();
                        capacitacionPerfecMilitarDTO.HorasCurso = Convert.ToInt32(dr["HorasCurso"]);


                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return capacitacionPerfecMilitarDTO;
        }

        public string ActualizaFormato(CapacitacionPerfeccionamientoMilitarDTO capacitacionPerfecMilitarDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_CapacitacionPerfeccionamientoMilitarActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CapacitacionPerfeccionamientoMilitarId", SqlDbType.Int);
                    cmd.Parameters["@CapacitacionPerfeccionamientoMilitarId"].Value = capacitacionPerfecMilitarDTO.CapacitacionPerfeccionamientoMilitarId;

                    cmd.Parameters.Add("@CIPCapPerf", SqlDbType.VarChar, 8);
                    cmd.Parameters["@CIPCapPerf"].Value = capacitacionPerfecMilitarDTO.CIPCapPerf;

                    cmd.Parameters.Add("@DNICapPerf", SqlDbType.VarChar, 8);
                    cmd.Parameters["@DNICapPerf"].Value = capacitacionPerfecMilitarDTO.DNICapPerf;

                    cmd.Parameters.Add("@CodigoTipoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoPersonalMilitar"].Value = capacitacionPerfecMilitarDTO.CodigoTipoPersonalMilitar;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitar"].Value = capacitacionPerfecMilitarDTO.CodigoGradoPersonalMilitar;

                    cmd.Parameters.Add("@NumericoPais", SqlDbType.VarChar, 20);
                    cmd.Parameters["@NumericoPais"].Value = capacitacionPerfecMilitarDTO.NumericoPais;

                    cmd.Parameters.Add("@CodigoEntidadMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEntidadMilitar"].Value = capacitacionPerfecMilitarDTO.CodigoEntidadMilitar;

                    cmd.Parameters.Add("@CodigoCodigoEscuela", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCodigoEscuela"].Value = capacitacionPerfecMilitarDTO.CodigoCodigoEscuela;

                    cmd.Parameters.Add("@MensionCurso", SqlDbType.VarChar, 200);
                    cmd.Parameters["@MensionCurso"].Value = capacitacionPerfecMilitarDTO.MensionCurso;

                    cmd.Parameters.Add("@HorasCurso", SqlDbType.Int);
                    cmd.Parameters["@HorasCurso"].Value = capacitacionPerfecMilitarDTO.HorasCurso;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = capacitacionPerfecMilitarDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(CapacitacionPerfeccionamientoMilitarDTO capacitacionPerfecMilitarDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_CapacitacionPerfeccionamientoMilitarEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CapacitacionPerfeccionamientoMilitarId", SqlDbType.Int);
                    cmd.Parameters["@CapacitacionPerfeccionamientoMilitarId"].Value = capacitacionPerfecMilitarDTO.CapacitacionPerfeccionamientoMilitarId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = capacitacionPerfecMilitarDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(CapacitacionPerfeccionamientoMilitarDTO capacitacionPerfecMilitarDTO)
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
                    cmd.Parameters["@Formato"].Value = "CapacitacionPerfeccionamientoMilitar";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = capacitacionPerfecMilitarDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = capacitacionPerfecMilitarDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_CapacitacionPerfeccionamientoMilitarRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CapacitacionPerfeccionamientoMilitar", SqlDbType.Structured);
                    cmd.Parameters["@CapacitacionPerfeccionamientoMilitar"].TypeName = "Formato.CapacitacionPerfeccionamientoMilitar";
                    cmd.Parameters["@CapacitacionPerfeccionamientoMilitar"].Value = datos;

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