using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Diredumar;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Marina.Siesmar.AccesoDatos.Formatos.Diredumar
{
    public class CapacitacionPerfecDeberPSupSubDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<CapacitacionPerfecDeberPSupSubDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<CapacitacionPerfecDeberPSupSubDTO> lista = new List<CapacitacionPerfecDeberPSupSubDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_CapacitacionPerfeccionamientoDeberListar", conexion);
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
                        lista.Add(new CapacitacionPerfecDeberPSupSubDTO()
                        {
                            CapacitacionPerfeccionamientoDeberId = Convert.ToInt32(dr["CapacitacionPerfeccionamientoDeberId"]),
                            CIPCapaPerfDeber = dr["CIPCapaPerfDeber"].ToString(),
                            DNICapaPerfDeber = dr["DNICapaPerfDeber"].ToString(),
                            NombreCapaPerfDeber = dr["NombreCapaPerfDeber"].ToString(),
                            FechaNacimientoCapaPerfDeber = (dr["FechaNacimientoCapaPerfDeber"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            SexoCapaPerfDeber = dr["SexoCapaPerfDeber"].ToString(),
                            DescDependencia = dr["DescDependencia"].ToString(),
                            DescTipoPersonalMilitar = dr["DescTipoPersonalMilitar"].ToString(),
                            DescGrado = dr["DescGrado"].ToString(),
                            DescEspecialidad = dr["DescEspecialidad"].ToString(),
                            CapacitacioLineaCapaPerfDeber = dr["CapacitacioLineaCapaPerfDeber"].ToString(),
                            InscripcionCapaPerfDeber = dr["InscripcionCapaPerfDeber"].ToString(),
                            TipoProgramaCapaPerfDeber = dr["TipoProgramaCapaPerfDeber"].ToString(),
                            NombrePais = dr["NombrePais"].ToString(),
                            DescEntidadMilitar = dr["DescEntidadMilitar"].ToString(),
                            DescCodigoEscuela = dr["DescCodigoEscuela"].ToString(),
                            MencionCursoCapacitacion = dr["MencionCursoCapacitacion"].ToString(),
                            DescClasificacionCurso = dr["DescClasificacionCurso"].ToString(),
                            FinanciamientoCapaPerfDeber = dr["FinanciamientoCapaPerfDeber"].ToString(),
                            FechaInicioCapaPerfDeber = (dr["FechaInicioCapaPerfDeber"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            FechaTerminoCapaPerfDeber = (dr["FechaTerminoCapaPerfDeber"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            FechaRegistroCapaPerfDeber = (dr["FechaRegistroCapaPerfDeber"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            HoraCapacitacionCapaPerfDeber = Convert.ToInt32(dr["HoraCapacitacionCapaPerfDeber"]),
                            DescMotivoTerminoCurso = dr["DescMotivoTerminoCurso"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"]),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(CapacitacionPerfecDeberPSupSubDTO capacitacionPerfecDeberPSupSubDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_CapacitacionPerfeccionamientoDeberRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CIPCapaPerfDeber", SqlDbType.VarChar,8);
                    cmd.Parameters["@CIPCapaPerfDeber"].Value = capacitacionPerfecDeberPSupSubDTO.CIPCapaPerfDeber;

                    cmd.Parameters.Add("@DNICapaPerfDeber", SqlDbType.VarChar,8);
                    cmd.Parameters["@DNICapaPerfDeber"].Value = capacitacionPerfecDeberPSupSubDTO.DNICapaPerfDeber;

                    cmd.Parameters.Add("@NombreCapaPerfDeber", SqlDbType.VarChar,50);
                    cmd.Parameters["@NombreCapaPerfDeber"].Value = capacitacionPerfecDeberPSupSubDTO.NombreCapaPerfDeber;

                    cmd.Parameters.Add("@FechaNacimientoCapaPerfDeber", SqlDbType.Date);
                    cmd.Parameters["@FechaNacimientoCapaPerfDeber"].Value = capacitacionPerfecDeberPSupSubDTO.FechaNacimientoCapaPerfDeber;

                    cmd.Parameters.Add("@SexoCapaPerfDeber", SqlDbType.VarChar,10);
                    cmd.Parameters["@SexoCapaPerfDeber"].Value = capacitacionPerfecDeberPSupSubDTO.SexoCapaPerfDeber;

                    cmd.Parameters.Add("@CodigoDependencia ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDependencia "].Value = capacitacionPerfecDeberPSupSubDTO.CodigoDependencia;

                    cmd.Parameters.Add("@CodigoTipoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoPersonalMilitar"].Value = capacitacionPerfecDeberPSupSubDTO.CodigoTipoPersonalMilitar;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitar"].Value = capacitacionPerfecDeberPSupSubDTO.CodigoGradoPersonalMilitar;

                    cmd.Parameters.Add("@CodigoEspecialidadGenericaPersonal", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEspecialidadGenericaPersonal"].Value = capacitacionPerfecDeberPSupSubDTO.CodigoEspecialidadGenericaPersonal;

                    cmd.Parameters.Add("@CapacitacioLineaCapaPerfDeber", SqlDbType.VarChar,50);
                    cmd.Parameters["@CapacitacioLineaCapaPerfDeber"].Value = capacitacionPerfecDeberPSupSubDTO.CapacitacioLineaCapaPerfDeber;

                    cmd.Parameters.Add("@InscripcionCapaPerfDeber", SqlDbType.VarChar, 50);
                    cmd.Parameters["@InscripcionCapaPerfDeber"].Value = capacitacionPerfecDeberPSupSubDTO.InscripcionCapaPerfDeber;

                    cmd.Parameters.Add("@TipoProgramaCapaPerfDeber", SqlDbType.VarChar, 50);
                    cmd.Parameters["@TipoProgramaCapaPerfDeber"].Value = capacitacionPerfecDeberPSupSubDTO.TipoProgramaCapaPerfDeber;

                    cmd.Parameters.Add("@NumericoPais", SqlDbType.VarChar, 20);
                    cmd.Parameters["@NumericoPais"].Value = capacitacionPerfecDeberPSupSubDTO.NumericoPais;

                    cmd.Parameters.Add("@CodigoEntidadMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEntidadMilitar"].Value = capacitacionPerfecDeberPSupSubDTO.CodigoEntidadMilitar;

                    cmd.Parameters.Add("@CodigoEscuela", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEscuela"].Value = capacitacionPerfecDeberPSupSubDTO.CodigoCodigoEscuela;

                    cmd.Parameters.Add("@MencionCursoCapacitacion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@MencionCursoCapacitacion"].Value = capacitacionPerfecDeberPSupSubDTO.MencionCursoCapacitacion;

                    cmd.Parameters.Add("@CodigoClasificacionCurso", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoClasificacionCurso"].Value = capacitacionPerfecDeberPSupSubDTO.CodigoClasificacionCurso;

                    cmd.Parameters.Add("@FinanciamientoCapaPerfDeber", SqlDbType.VarChar,20);
                    cmd.Parameters["@FinanciamientoCapaPerfDeber"].Value = capacitacionPerfecDeberPSupSubDTO.FinanciamientoCapaPerfDeber;

                    cmd.Parameters.Add("@FechaInicioCapaPerfDeber", SqlDbType.Date);
                    cmd.Parameters["@FechaInicioCapaPerfDeber"].Value = capacitacionPerfecDeberPSupSubDTO.FechaInicioCapaPerfDeber;

                    cmd.Parameters.Add("@FechaTerminoCapaPerfDeber", SqlDbType.Date);
                    cmd.Parameters["@FechaTerminoCapaPerfDeber"].Value = capacitacionPerfecDeberPSupSubDTO.FechaTerminoCapaPerfDeber;

                    cmd.Parameters.Add("@FechaRegistroCapaPerfDeber", SqlDbType.Date);
                    cmd.Parameters["@FechaRegistroCapaPerfDeber"].Value = capacitacionPerfecDeberPSupSubDTO.FechaRegistroCapaPerfDeber;

                    cmd.Parameters.Add("@HoraCapacitacionCapaPerfDeber", SqlDbType.Int);
                    cmd.Parameters["@HoraCapacitacionCapaPerfDeber"].Value = capacitacionPerfecDeberPSupSubDTO.HoraCapacitacionCapaPerfDeber;

                    cmd.Parameters.Add("@CodigoMotivoTerminoCurso", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoMotivoTerminoCurso"].Value = capacitacionPerfecDeberPSupSubDTO.CodigoMotivoTerminoCurso;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = capacitacionPerfecDeberPSupSubDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = capacitacionPerfecDeberPSupSubDTO.UsuarioIngresoRegistro;

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

        public CapacitacionPerfecDeberPSupSubDTO BuscarFormato(int Codigo)
        {
            CapacitacionPerfecDeberPSupSubDTO capacitacionPerfecDeberPSupSubDTO = new CapacitacionPerfecDeberPSupSubDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_CapacitacionPerfeccionamientoDeberEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CapaPerfDeberPSupSubId", SqlDbType.Int);
                    cmd.Parameters["@CapaPerfDeberPSupSubId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        capacitacionPerfecDeberPSupSubDTO.CapacitacionPerfeccionamientoDeberId = Convert.ToInt32(dr["CapacitacionPerfeccionamientoDeberId"]);
                        capacitacionPerfecDeberPSupSubDTO.CIPCapaPerfDeber = dr["CIPCapaPerfDeber"].ToString();
                        capacitacionPerfecDeberPSupSubDTO.DNICapaPerfDeber = dr["DNICapaPerfDeber"].ToString();
                        capacitacionPerfecDeberPSupSubDTO.NombreCapaPerfDeber = dr["NombreCapaPerfDeber"].ToString();
                        capacitacionPerfecDeberPSupSubDTO.FechaNacimientoCapaPerfDeber = Convert.ToDateTime(dr["FechaNacimientoCapaPerfDeber"]).ToString("yyy-MM-dd");
                        capacitacionPerfecDeberPSupSubDTO.SexoCapaPerfDeber = Regex.Replace(dr["SexoCapaPerfDeber"].ToString(), @"\s", "");
                        capacitacionPerfecDeberPSupSubDTO.CodigoDependencia = dr["CodigoDependencia"].ToString();
                        capacitacionPerfecDeberPSupSubDTO.CodigoTipoPersonalMilitar = dr["CodigoTipoPersonalMilitar"].ToString();
                        capacitacionPerfecDeberPSupSubDTO.CodigoGradoPersonalMilitar = dr["CodigoGradoPersonalMilitar"].ToString();
                        capacitacionPerfecDeberPSupSubDTO.CodigoEspecialidadGenericaPersonal = dr["CodigoEspecialidadGenericaPersonal"].ToString();
                        capacitacionPerfecDeberPSupSubDTO.CapacitacioLineaCapaPerfDeber = dr["CapacitacioLineaCapaPerfDeber"].ToString();
                        capacitacionPerfecDeberPSupSubDTO.InscripcionCapaPerfDeber = dr["InscripcionCapaPerfDeber"].ToString();
                        capacitacionPerfecDeberPSupSubDTO.TipoProgramaCapaPerfDeber = dr["TipoProgramaCapaPerfDeber"].ToString();
                        capacitacionPerfecDeberPSupSubDTO.NumericoPais = dr["NumericoPais"].ToString();
                        capacitacionPerfecDeberPSupSubDTO.CodigoEntidadMilitar = dr["CodigoEntidadMilitar"].ToString();
                        capacitacionPerfecDeberPSupSubDTO.CodigoCodigoEscuela = dr["CodigoEscuela"].ToString();
                        capacitacionPerfecDeberPSupSubDTO.MencionCursoCapacitacion = dr["MencionCursoCapacitacion"].ToString();
                        capacitacionPerfecDeberPSupSubDTO.CodigoClasificacionCurso = dr["CodigoClasificacionCurso"].ToString();
                        capacitacionPerfecDeberPSupSubDTO.FinanciamientoCapaPerfDeber = dr["FinanciamientoCapaPerfDeber"].ToString();
                        capacitacionPerfecDeberPSupSubDTO.FechaInicioCapaPerfDeber = Convert.ToDateTime(dr["FechaInicioCapaPerfDeber"]).ToString("yyy-MM-dd");
                        capacitacionPerfecDeberPSupSubDTO.FechaTerminoCapaPerfDeber = Convert.ToDateTime(dr["FechaTerminoCapaPerfDeber"]).ToString("yyy-MM-dd");
                        capacitacionPerfecDeberPSupSubDTO.FechaRegistroCapaPerfDeber = Convert.ToDateTime(dr["FechaRegistroCapaPerfDeber"]).ToString("yyy-MM-dd");
                        capacitacionPerfecDeberPSupSubDTO.HoraCapacitacionCapaPerfDeber = Convert.ToInt32(dr["HoraCapacitacionCapaPerfDeber"]);
                        capacitacionPerfecDeberPSupSubDTO.CodigoMotivoTerminoCurso = dr["CodigoMotivoTerminoCurso"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return capacitacionPerfecDeberPSupSubDTO;
        }

        public string ActualizaFormato(CapacitacionPerfecDeberPSupSubDTO capacitacionPerfecDeberPSupSubDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_CapacitacionPerfeccionamientoDeberActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CapaPerfDeberPSupSubId", SqlDbType.Int);
                    cmd.Parameters["@CapaPerfDeberPSupSubId"].Value = capacitacionPerfecDeberPSupSubDTO.CapacitacionPerfeccionamientoDeberId;

                    cmd.Parameters.Add("@CIPCapaPerfDeber", SqlDbType.VarChar, 8);
                    cmd.Parameters["@CIPCapaPerfDeber"].Value = capacitacionPerfecDeberPSupSubDTO.CIPCapaPerfDeber;

                    cmd.Parameters.Add("@DNICapaPerfDeber", SqlDbType.VarChar, 8);
                    cmd.Parameters["@DNICapaPerfDeber"].Value = capacitacionPerfecDeberPSupSubDTO.DNICapaPerfDeber;

                    cmd.Parameters.Add("@NombreCapaPerfDeber", SqlDbType.VarChar,50);
                    cmd.Parameters["@NombreCapaPerfDeber"].Value = capacitacionPerfecDeberPSupSubDTO.NombreCapaPerfDeber;

                    cmd.Parameters.Add("@FechaNacimientoCapaPerfDeber", SqlDbType.VarChar, 50);
                    cmd.Parameters["@FechaNacimientoCapaPerfDeber"].Value = capacitacionPerfecDeberPSupSubDTO.FechaNacimientoCapaPerfDeber;

                    cmd.Parameters.Add("@SexoCapaPerfDeber", SqlDbType.VarChar, 10);
                    cmd.Parameters["@SexoCapaPerfDeber"].Value = capacitacionPerfecDeberPSupSubDTO.SexoCapaPerfDeber;

                    cmd.Parameters.Add("@CodigoDependencia", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDependencia"].Value = capacitacionPerfecDeberPSupSubDTO.CodigoDependencia;

                    cmd.Parameters.Add("@CodigoTipoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoPersonalMilitar"].Value = capacitacionPerfecDeberPSupSubDTO.CodigoTipoPersonalMilitar;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitar"].Value = capacitacionPerfecDeberPSupSubDTO.CodigoGradoPersonalMilitar;

                    cmd.Parameters.Add("@CodigoEspecialidadGenericaPersonal", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEspecialidadGenericaPersonal"].Value = capacitacionPerfecDeberPSupSubDTO.CodigoEspecialidadGenericaPersonal;

                    cmd.Parameters.Add("@CapacitacioLineaCapaPerfDeber", SqlDbType.VarChar, 50);
                    cmd.Parameters["@CapacitacioLineaCapaPerfDeber"].Value = capacitacionPerfecDeberPSupSubDTO.CapacitacioLineaCapaPerfDeber;

                    cmd.Parameters.Add("@InscripcionCapaPerfDeber", SqlDbType.VarChar, 50);
                    cmd.Parameters["@InscripcionCapaPerfDeber"].Value = capacitacionPerfecDeberPSupSubDTO.InscripcionCapaPerfDeber;

                    cmd.Parameters.Add("@TipoProgramaCapaPerfDeber", SqlDbType.VarChar, 50);
                    cmd.Parameters["@TipoProgramaCapaPerfDeber"].Value = capacitacionPerfecDeberPSupSubDTO.TipoProgramaCapaPerfDeber;

                    cmd.Parameters.Add("@NumericoPais", SqlDbType.VarChar, 20);
                    cmd.Parameters["@NumericoPais"].Value = capacitacionPerfecDeberPSupSubDTO.NumericoPais;

                    cmd.Parameters.Add("@CodigoEntidadMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEntidadMilitar"].Value = capacitacionPerfecDeberPSupSubDTO.CodigoEntidadMilitar;

                    cmd.Parameters.Add("@CodigoCodigoEscuela", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCodigoEscuela"].Value = capacitacionPerfecDeberPSupSubDTO.CodigoCodigoEscuela;

                    cmd.Parameters.Add("@MencionCursoCapacitacion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@MencionCursoCapacitacion"].Value = capacitacionPerfecDeberPSupSubDTO.MencionCursoCapacitacion;

                    cmd.Parameters.Add("@CodigoClasificacionCurso", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoClasificacionCurso"].Value = capacitacionPerfecDeberPSupSubDTO.CodigoClasificacionCurso;

                    cmd.Parameters.Add("@FinanciamientoCapaPerfDeber", SqlDbType.VarChar, 20);
                    cmd.Parameters["@FinanciamientoCapaPerfDeber"].Value = capacitacionPerfecDeberPSupSubDTO.FinanciamientoCapaPerfDeber;

                    cmd.Parameters.Add("@FechaInicioCapaPerfDeber", SqlDbType.Date);
                    cmd.Parameters["@FechaInicioCapaPerfDeber"].Value = capacitacionPerfecDeberPSupSubDTO.FechaInicioCapaPerfDeber;

                    cmd.Parameters.Add("@FechaTerminoCapaPerfDeber", SqlDbType.Date);
                    cmd.Parameters["@FechaTerminoCapaPerfDeber"].Value = capacitacionPerfecDeberPSupSubDTO.FechaTerminoCapaPerfDeber;

                    cmd.Parameters.Add("@FechaRegistroCapaPerfDeber", SqlDbType.Date);
                    cmd.Parameters["@FechaRegistroCapaPerfDeber"].Value = capacitacionPerfecDeberPSupSubDTO.FechaRegistroCapaPerfDeber;

                    cmd.Parameters.Add("@HoraCapacitacionCapaPerfDeber", SqlDbType.Int);
                    cmd.Parameters["@HoraCapacitacionCapaPerfDeber"].Value = capacitacionPerfecDeberPSupSubDTO.HoraCapacitacionCapaPerfDeber;

                    cmd.Parameters.Add("@CodigoMotivoTerminoCurso", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoMotivoTerminoCurso"].Value = capacitacionPerfecDeberPSupSubDTO.CodigoMotivoTerminoCurso;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = capacitacionPerfecDeberPSupSubDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(CapacitacionPerfecDeberPSupSubDTO capacitacionPerfecDeberPSupSubDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_CapacitacionPerfeccionamientoDeberEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CapaPerfDeberPSupSubId", SqlDbType.Int);
                    cmd.Parameters["@CapaPerfDeberPSupSubId"].Value = capacitacionPerfecDeberPSupSubDTO.CapacitacionPerfeccionamientoDeberId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = capacitacionPerfecDeberPSupSubDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(CapacitacionPerfecDeberPSupSubDTO capacitacionPerfecDeberPSupSubDTO)
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
                    cmd.Parameters["@Formato"].Value = "CapacitacionPerfeccionamientoDeber";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = capacitacionPerfecDeberPSupSubDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = capacitacionPerfecDeberPSupSubDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_CapacitacionPerfeccionamientoDeberRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CapacitacionPerfeccionamientoDeber", SqlDbType.Structured);
                    cmd.Parameters["@CapacitacionPerfeccionamientoDeber"].TypeName = "Formato.CapacitacionPerfeccionamientoDeber";
                    cmd.Parameters["@CapacitacionPerfeccionamientoDeber"].Value = datos;

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
