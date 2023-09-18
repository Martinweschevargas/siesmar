using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Diredumar;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Marina.Siesmar.AccesoDatos.Formatos.Diredumar
{
    public class SegEspecialidadPersonalSupSubDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<SegEspecialidadPersonalSupSubDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<SegEspecialidadPersonalSupSubDTO> lista = new List<SegEspecialidadPersonalSupSubDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_SegEspecialidadPersonalSupSubListar", conexion);
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
                        lista.Add(new SegEspecialidadPersonalSupSubDTO()
                        {
                            SegEspecialidadPersonalSupSubId = Convert.ToInt32(dr["SegEspecialidadPersonalSupSubId"]),
                            CIPSegEspecialidad = dr["CIPSegEspecialidad"].ToString(),
                            DNISegEspecialidad = dr["DNISegEspecialidad"].ToString(),
                            NombreSegEspecialidad = dr["NombreSegEspecialidad"].ToString(),
                            FechaNacimientoSegEspecialidad = (dr["FechaNacimientoSegEspecialidad"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            SexoSegEspecialidad = dr["SexoSegEspecialidad"].ToString(),
                            DescDependencia = dr["DescDependencia"].ToString(),
                            DescTipoPersonalMilitar = dr["DescTipoPersonalMilitar"].ToString(),
                            DescGrado = dr["DescGrado"].ToString(),
                            DescEspecialidad = dr["DescEspecialidad"].ToString(),
                            TipoProgramaCapSegEspecialidad = dr["TipoProgramaCapSegEspecialidad"].ToString(),
                            NombrePais = dr["NombrePais"].ToString(),
                            DescEntidadMilitar = dr["DescEntidadMilitar"].ToString(),
                            DescCodigoEscuela = dr["DescCodigoEscuela"].ToString(),
                            MencionCursoSegEspecialidad = dr["MencionCursoSegEspecialidad"].ToString(),
                            FinanciamientoSegEspecialidad = dr["FinanciamientoSegEspecialidad"].ToString(),
                            FechaInicioSegEspecialidad = (dr["FechaInicioSegEspecialidad"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            FechaTerminoSegEspecialidad = (dr["FechaTerminoSegEspecialidad"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            FechaRegistroSegEspecialidad = (dr["FechaRegistroSegEspecialidad"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            HorasCapacitacionSegEspecialidad = Convert.ToInt32(dr["HorasCapacitacionSegEspecialidad"]),
                            CalificacionSegEspecialidad = dr["CalificacionSegEspecialidad"].ToString(),
                            DescMotivoTerminoCurso = dr["DescMotivoTerminoCurso"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"]),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(SegEspecialidadPersonalSupSubDTO segEspecialidadPersonalSupSubDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_SegEspecialidadPersonalSupSubRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CIPSegEspecialidad", SqlDbType.VarChar, 8);
                    cmd.Parameters["@CIPSegEspecialidad"].Value = segEspecialidadPersonalSupSubDTO.CIPSegEspecialidad;

                    cmd.Parameters.Add("@DNISegEspecialidad", SqlDbType.VarChar, 8);
                    cmd.Parameters["@DNISegEspecialidad"].Value = segEspecialidadPersonalSupSubDTO.DNISegEspecialidad;

                    cmd.Parameters.Add("@NombreSegEspecialidad", SqlDbType.VarChar, 256);
                    cmd.Parameters["@NombreSegEspecialidad"].Value = segEspecialidadPersonalSupSubDTO.NombreSegEspecialidad;

                    cmd.Parameters.Add("@FechaNacimientoSegEspecialidad", SqlDbType.Date);
                    cmd.Parameters["@FechaNacimientoSegEspecialidad"].Value = segEspecialidadPersonalSupSubDTO.FechaNacimientoSegEspecialidad;

                    cmd.Parameters.Add("@SexoSegEspecialidad", SqlDbType.VarChar, 10);
                    cmd.Parameters["@SexoSegEspecialidad"].Value = segEspecialidadPersonalSupSubDTO.SexoSegEspecialidad;

                    cmd.Parameters.Add("@CodigoDependencia ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDependencia "].Value = segEspecialidadPersonalSupSubDTO.CodigoDependencia;

                    cmd.Parameters.Add("@CodigoTipoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoPersonalMilitar"].Value = segEspecialidadPersonalSupSubDTO.CodigoTipoPersonalMilitar;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitar"].Value = segEspecialidadPersonalSupSubDTO.CodigoGradoPersonalMilitar;

                    cmd.Parameters.Add("@CodigoEspecialidadGenericaPersonal", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEspecialidadGenericaPersonal"].Value = segEspecialidadPersonalSupSubDTO.CodigoEspecialidadGenericaPersonal;

                    cmd.Parameters.Add("@TipoProgramaCapSegEspecialidad", SqlDbType.VarChar, 256);
                    cmd.Parameters["@TipoProgramaCapSegEspecialidad"].Value = segEspecialidadPersonalSupSubDTO.TipoProgramaCapSegEspecialidad;

                    cmd.Parameters.Add("@NumericoPais ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@NumericoPais "].Value = segEspecialidadPersonalSupSubDTO.NumericoPais;

                    cmd.Parameters.Add("@CodigoEntidadMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEntidadMilitar"].Value = segEspecialidadPersonalSupSubDTO.CodigoEntidadMilitar;

                    cmd.Parameters.Add("@CodigoCodigoEscuela", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCodigoEscuela"].Value = segEspecialidadPersonalSupSubDTO.CodigoEscuela;

                    cmd.Parameters.Add("@MencionCursoSegEspecialidad", SqlDbType.VarChar, 200);
                    cmd.Parameters["@MencionCursoSegEspecialidad"].Value = segEspecialidadPersonalSupSubDTO.MencionCursoSegEspecialidad;

                    cmd.Parameters.Add("@FinanciamientoSegEspecialidad", SqlDbType.VarChar, 20);
                    cmd.Parameters["@FinanciamientoSegEspecialidad"].Value = segEspecialidadPersonalSupSubDTO.FinanciamientoSegEspecialidad;

                    cmd.Parameters.Add("@FechaInicioSegEspecialidad", SqlDbType.Date);
                    cmd.Parameters["@FechaInicioSegEspecialidad"].Value = segEspecialidadPersonalSupSubDTO.FechaInicioSegEspecialidad;

                    cmd.Parameters.Add("@FechaTerminoSegEspecialidad", SqlDbType.Date);
                    cmd.Parameters["@FechaTerminoSegEspecialidad"].Value = segEspecialidadPersonalSupSubDTO.FechaTerminoSegEspecialidad;

                    cmd.Parameters.Add("@FechaRegistroSegEspecialidad", SqlDbType.Date);
                    cmd.Parameters["@FechaRegistroSegEspecialidad"].Value = segEspecialidadPersonalSupSubDTO.FechaRegistroSegEspecialidad;

                    cmd.Parameters.Add("@HorasCapacitacionSegEspecialidad", SqlDbType.Int);
                    cmd.Parameters["@HorasCapacitacionSegEspecialidad"].Value = segEspecialidadPersonalSupSubDTO.HorasCapacitacionSegEspecialidad;

                    cmd.Parameters.Add("@CalificacionSegEspecialidad", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CalificacionSegEspecialidad"].Value = segEspecialidadPersonalSupSubDTO.CalificacionSegEspecialidad;

                    cmd.Parameters.Add("@CodigoMotivoTerminoCurso", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoMotivoTerminoCurso"].Value = segEspecialidadPersonalSupSubDTO.CodigoMotivoTerminoCurso;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = segEspecialidadPersonalSupSubDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = segEspecialidadPersonalSupSubDTO.UsuarioIngresoRegistro;

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

        public SegEspecialidadPersonalSupSubDTO BuscarFormato(int Codigo)
        {
            SegEspecialidadPersonalSupSubDTO segEspecialidadPersonalSupSubDTO = new SegEspecialidadPersonalSupSubDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_SegEspecialidadPersonalSupSubEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SegEspecialidadPersonalSupSubId", SqlDbType.Int);
                    cmd.Parameters["@SegEspecialidadPersonalSupSubId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        segEspecialidadPersonalSupSubDTO.SegEspecialidadPersonalSupSubId = Convert.ToInt32(dr["SegEspecialidadPersonalSupSubId"]);
                        segEspecialidadPersonalSupSubDTO.CIPSegEspecialidad = dr["CIPSegEspecialidad"].ToString();
                        segEspecialidadPersonalSupSubDTO.DNISegEspecialidad = dr["DNISegEspecialidad"].ToString();
                        segEspecialidadPersonalSupSubDTO.NombreSegEspecialidad = dr["NombreSegEspecialidad"].ToString();
                        segEspecialidadPersonalSupSubDTO.FechaNacimientoSegEspecialidad = Convert.ToDateTime(dr["FechaNacimientoSegEspecialidad"]).ToString("yyy-MM-dd");
                        segEspecialidadPersonalSupSubDTO.SexoSegEspecialidad = Regex.Replace(dr["SexoSegEspecialidad"].ToString(), @"\s", "");
                        segEspecialidadPersonalSupSubDTO.CodigoDependencia = dr["CodigoDependencia"].ToString();
                        segEspecialidadPersonalSupSubDTO.CodigoTipoPersonalMilitar = dr["CodigoTipoPersonalMilitar"].ToString();
                        segEspecialidadPersonalSupSubDTO.CodigoGradoPersonalMilitar = dr["CodigoGradoPersonalMilitar"].ToString();
                        segEspecialidadPersonalSupSubDTO.CodigoEspecialidadGenericaPersonal = dr["CodigoEspecialidadGenericaPersonal"].ToString();
                        segEspecialidadPersonalSupSubDTO.TipoProgramaCapSegEspecialidad = Regex.Replace(dr["TipoProgramaCapSegEspecialidad"].ToString(), @"\s", "");
                        segEspecialidadPersonalSupSubDTO.NumericoPais = dr["NumericoPais"].ToString();
                        segEspecialidadPersonalSupSubDTO.CodigoEntidadMilitar = dr["CodigoEntidadMilitar"].ToString();
                        segEspecialidadPersonalSupSubDTO.CodigoEscuela = dr["CodigoEscuela"].ToString();
                        segEspecialidadPersonalSupSubDTO.MencionCursoSegEspecialidad = dr["MencionCursoSegEspecialidad"].ToString();
                        segEspecialidadPersonalSupSubDTO.FinanciamientoSegEspecialidad = dr["FinanciamientoSegEspecialidad"].ToString();
                        segEspecialidadPersonalSupSubDTO.FechaInicioSegEspecialidad = Convert.ToDateTime(dr["FechaInicioSegEspecialidad"]).ToString("yyy-MM-dd");
                        segEspecialidadPersonalSupSubDTO.FechaTerminoSegEspecialidad = Convert.ToDateTime(dr["FechaTerminoSegEspecialidad"]).ToString("yyy-MM-dd");
                        segEspecialidadPersonalSupSubDTO.FechaRegistroSegEspecialidad = Convert.ToDateTime(dr["FechaRegistroSegEspecialidad"]).ToString("yyy-MM-dd");
                        segEspecialidadPersonalSupSubDTO.HorasCapacitacionSegEspecialidad = Convert.ToInt32(dr["HorasCapacitacionSegEspecialidad"]);
                        segEspecialidadPersonalSupSubDTO.CalificacionSegEspecialidad = dr["CalificacionSegEspecialidad"].ToString();
                        segEspecialidadPersonalSupSubDTO.CodigoMotivoTerminoCurso = dr["CodigoMotivoTerminoCurso"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return segEspecialidadPersonalSupSubDTO;
        }

        public string ActualizaFormato(SegEspecialidadPersonalSupSubDTO segEspecialidadPersonalSupSubDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_SegEspecialidadPersonalSupSubActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SegEspecialidadPersonalSupSubId", SqlDbType.Int);
                    cmd.Parameters["@SegEspecialidadPersonalSupSubId"].Value = segEspecialidadPersonalSupSubDTO.SegEspecialidadPersonalSupSubId;

                    cmd.Parameters.Add("@CIPSegEspecialidad", SqlDbType.VarChar, 8);
                    cmd.Parameters["@CIPSegEspecialidad"].Value = segEspecialidadPersonalSupSubDTO.CIPSegEspecialidad;

                    cmd.Parameters.Add("@DNISegEspecialidad", SqlDbType.VarChar, 8);
                    cmd.Parameters["@DNISegEspecialidad"].Value = segEspecialidadPersonalSupSubDTO.DNISegEspecialidad;

                    cmd.Parameters.Add("@NombreSegEspecialidad", SqlDbType.VarChar, 256);
                    cmd.Parameters["@NombreSegEspecialidad"].Value = segEspecialidadPersonalSupSubDTO.NombreSegEspecialidad;

                    cmd.Parameters.Add("@FechaNacimientoSegEspecialidad", SqlDbType.Date);
                    cmd.Parameters["@FechaNacimientoSegEspecialidad"].Value = segEspecialidadPersonalSupSubDTO.FechaNacimientoSegEspecialidad;

                    cmd.Parameters.Add("@SexoSegEspecialidad", SqlDbType.VarChar, 10);
                    cmd.Parameters["@SexoSegEspecialidad"].Value = segEspecialidadPersonalSupSubDTO.SexoSegEspecialidad;

                    cmd.Parameters.Add("@CodigoDependencia", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDependencia"].Value = segEspecialidadPersonalSupSubDTO.CodigoDependencia;

                    cmd.Parameters.Add("@CodigoTipoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoPersonalMilitar"].Value = segEspecialidadPersonalSupSubDTO.CodigoTipoPersonalMilitar;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitar"].Value = segEspecialidadPersonalSupSubDTO.CodigoGradoPersonalMilitar;

                    cmd.Parameters.Add("@CodigoEspecialidadGenericaPersonal", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEspecialidadGenericaPersonal"].Value = segEspecialidadPersonalSupSubDTO.CodigoEspecialidadGenericaPersonal;

                    cmd.Parameters.Add("@TipoProgramaCapSegEspecialidad", SqlDbType.VarChar, 256);
                    cmd.Parameters["@TipoProgramaCapSegEspecialidad"].Value = segEspecialidadPersonalSupSubDTO.TipoProgramaCapSegEspecialidad;

                    cmd.Parameters.Add("@NumericoPais ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@NumericoPais "].Value = segEspecialidadPersonalSupSubDTO.NumericoPais;

                    cmd.Parameters.Add("@CodigoEntidadMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEntidadMilitar"].Value = segEspecialidadPersonalSupSubDTO.CodigoEntidadMilitar;

                    cmd.Parameters.Add("@CodigoCodigoEscuela", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCodigoEscuela"].Value = segEspecialidadPersonalSupSubDTO.CodigoEscuela;

                    cmd.Parameters.Add("@MencionCursoSegEspecialidad", SqlDbType.VarChar, 200);
                    cmd.Parameters["@MencionCursoSegEspecialidad"].Value = segEspecialidadPersonalSupSubDTO.MencionCursoSegEspecialidad;

                    cmd.Parameters.Add("@FinanciamientoSegEspecialidad", SqlDbType.VarChar, 20);
                    cmd.Parameters["@FinanciamientoSegEspecialidad"].Value = segEspecialidadPersonalSupSubDTO.FinanciamientoSegEspecialidad;

                    cmd.Parameters.Add("@FechaInicioSegEspecialidad", SqlDbType.Date);
                    cmd.Parameters["@FechaInicioSegEspecialidad"].Value = segEspecialidadPersonalSupSubDTO.FechaInicioSegEspecialidad;

                    cmd.Parameters.Add("@FechaTerminoSegEspecialidad", SqlDbType.Date);
                    cmd.Parameters["@FechaTerminoSegEspecialidad"].Value = segEspecialidadPersonalSupSubDTO.FechaTerminoSegEspecialidad;

                    cmd.Parameters.Add("@FechaRegistroSegEspecialidad", SqlDbType.Date);
                    cmd.Parameters["@FechaRegistroSegEspecialidad"].Value = segEspecialidadPersonalSupSubDTO.FechaRegistroSegEspecialidad;

                    cmd.Parameters.Add("@HorasCapacitacionSegEspecialidad", SqlDbType.Int);
                    cmd.Parameters["@HorasCapacitacionSegEspecialidad"].Value = segEspecialidadPersonalSupSubDTO.HorasCapacitacionSegEspecialidad;

                    cmd.Parameters.Add("@CalificacionSegEspecialidad", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CalificacionSegEspecialidad"].Value = segEspecialidadPersonalSupSubDTO.CalificacionSegEspecialidad;

                    cmd.Parameters.Add("@CodigoMotivoTerminoCurso", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoMotivoTerminoCurso"].Value = segEspecialidadPersonalSupSubDTO.CodigoMotivoTerminoCurso;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = segEspecialidadPersonalSupSubDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(SegEspecialidadPersonalSupSubDTO segEspecialidadPersonalSupSubDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_SegEspecialidadPersonalSupSubEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SegEspecialidadPersonalSupSubId", SqlDbType.Int);
                    cmd.Parameters["@SegEspecialidadPersonalSupSubId"].Value = segEspecialidadPersonalSupSubDTO.SegEspecialidadPersonalSupSubId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = segEspecialidadPersonalSupSubDTO.UsuarioIngresoRegistro;

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


        public bool EliminarCarga(SegEspecialidadPersonalSupSubDTO segEspecialidadPersonalSupSubDTO)
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
                    cmd.Parameters["@Formato"].Value = "SegEspecialidadPersonalSupSub";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = segEspecialidadPersonalSupSubDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = segEspecialidadPersonalSupSubDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_SegEspecialidadPersonalSupSubRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SegEspecialidadPersonalSupSub", SqlDbType.Structured);
                    cmd.Parameters["@SegEspecialidadPersonalSupSub"].TypeName = "Formato.SegEspecialidadPersonalSupSub";
                    cmd.Parameters["@SegEspecialidadPersonalSupSub"].Value = datos;

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
