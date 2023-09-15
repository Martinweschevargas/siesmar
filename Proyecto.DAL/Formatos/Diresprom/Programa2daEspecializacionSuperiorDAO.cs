using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Diresprom;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Diresprom
{
    public class Programa2daEspecializacionSuperiorDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<Programa2daEspecializacionSuperiorDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<Programa2daEspecializacionSuperiorDTO> lista = new List<Programa2daEspecializacionSuperiorDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_Programa2daEspecializacionSuperiorListar", conexion);
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
                        lista.Add(new Programa2daEspecializacionSuperiorDTO()
                        {
                            Programa2daEspecializacionSuperiorId = Convert.ToInt32(dr["Programa2daEspecializacionSuperiorId"]),
                            DNIPersonalSuperior = dr["DNIPersonalSuperior"].ToString(),
                            EdadPersonalSuperior = Convert.ToInt32(dr["EdadPersonalSuperior"]),
                            SexoPersonalSuperior = dr["SexoPersonalSuperior"].ToString(),
                            CondicionPersonalSuperior = dr["CondicionPersonalSuperior"].ToString(),
                            DescEntidadMilitar = dr["DescEntidadMilitar"].ToString(),
                            DescGrado = dr["DescGrado"].ToString(),
                            DescEspecialidad = dr["DescEspecialidad"].ToString(),
                            ProcedenciaPersonalSuperior = dr["ProcedenciaPersonalSuperior"].ToString(),
                            AnioPromocionPersonalSuperior = Convert.ToInt32(dr["AnioPromocionPersonalSuperior"]),
                            NombreDependencia = dr["NombreDependencia"].ToString(),
                            DescZonaNaval = dr["DescZonaNaval"].ToString(),
                            DescProgramaEspecializacionGrupo = dr["DescProgramaEspecializacionGrupo"].ToString(),
                            DescProgramaEspecializacionEspecifico = dr["DescProgramaEspecializacionEspecifico"].ToString(),
                            FechaInicio = (dr["FechaInicio"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            FechaTermino = (dr["FechaTermino"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            FechaRegistro = (dr["FechaRegistro"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            DescModalidadPrograma = dr["DescModalidadPrograma"].ToString(),
                            ConcluyoProgramaEstudios = dr["ConcluyoProgramaEstudios"].ToString(),
                            MotivosNoConcluir = dr["MotivosNoConcluir"].ToString(),
                            CalificacionFinalObtenida = Convert.ToDecimal(dr["CalificacionFinalObtenida"]),
                            CertificacionTituloObtenido = dr["CertificacionTituloObtenido"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"]),

                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(Programa2daEspecializacionSuperiorDTO programa2daEspecializacionSuperiorDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_Programa2daEspecializacionSuperiorRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DNIPersonalSuperior", SqlDbType.VarChar, 8);
                    cmd.Parameters["@DNIPersonalSuperior"].Value = programa2daEspecializacionSuperiorDTO.DNIPersonalSuperior;

                    cmd.Parameters.Add("@EdadPersonalSuperior", SqlDbType.Int);
                    cmd.Parameters["@EdadPersonalSuperior"].Value = programa2daEspecializacionSuperiorDTO.EdadPersonalSuperior;

                    cmd.Parameters.Add("@SexoPersonalSuperior", SqlDbType.VarChar,10);
                    cmd.Parameters["@SexoPersonalSuperior"].Value = programa2daEspecializacionSuperiorDTO.SexoPersonalSuperior;

                    cmd.Parameters.Add("@CondicionPersonalSuperior", SqlDbType.VarChar,10);
                    cmd.Parameters["@CondicionPersonalSuperior"].Value = programa2daEspecializacionSuperiorDTO.CondicionPersonalSuperior;

                    cmd.Parameters.Add("@CodigoEntidadMilitar", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoEntidadMilitar"].Value = programa2daEspecializacionSuperiorDTO.CodigoEntidadMilitar;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitar"].Value = programa2daEspecializacionSuperiorDTO.CodigoGradoPersonalMilitar;

                    cmd.Parameters.Add("@CodigoEspecialidadGenericaPersonal", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEspecialidadGenericaPersonal"].Value = programa2daEspecializacionSuperiorDTO.CodigoEspecialidadGenericaPersonal;

                    cmd.Parameters.Add("@ProcedenciaPersonalSuperior", SqlDbType.VarChar,50);
                    cmd.Parameters["@ProcedenciaPersonalSuperior"].Value = programa2daEspecializacionSuperiorDTO.ProcedenciaPersonalSuperior;

                    cmd.Parameters.Add("@AnioPromocionPersonalSuperior", SqlDbType.Int);
                    cmd.Parameters["@AnioPromocionPersonalSuperior"].Value = programa2daEspecializacionSuperiorDTO.AnioPromocionPersonalSuperior;

                    cmd.Parameters.Add("@CodigoDependencia", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDependencia"].Value = programa2daEspecializacionSuperiorDTO.CodigoDependencia;

                    cmd.Parameters.Add("@CodigoZonaNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoZonaNaval"].Value = programa2daEspecializacionSuperiorDTO.CodigoZonaNaval;

                    cmd.Parameters.Add("@CodigoProgramaEspecializacionGrupo", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoProgramaEspecializacionGrupo"].Value = programa2daEspecializacionSuperiorDTO.CodigoProgramaEspecializacionGrupo;

                    cmd.Parameters.Add("@CodigoProgramaEspecializacionEspecifico", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoProgramaEspecializacionEspecifico"].Value = programa2daEspecializacionSuperiorDTO.CodigoProgramaEspecializacionEspecifico;

                    cmd.Parameters.Add("@FechaInicio", SqlDbType.Date);
                    cmd.Parameters["@FechaInicio"].Value = programa2daEspecializacionSuperiorDTO.FechaInicio;

                    cmd.Parameters.Add("@FechaTermino", SqlDbType.Date);
                    cmd.Parameters["@FechaTermino"].Value = programa2daEspecializacionSuperiorDTO.FechaTermino;

                    cmd.Parameters.Add("@FechaRegistro", SqlDbType.Date);
                    cmd.Parameters["@FechaRegistro"].Value = programa2daEspecializacionSuperiorDTO.FechaRegistro;

                    cmd.Parameters.Add("@CodigoModalidadPrograma", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoModalidadPrograma"].Value = programa2daEspecializacionSuperiorDTO.CodigoModalidadPrograma;

                    cmd.Parameters.Add("@ConcluyoProgramaEstudios", SqlDbType.NChar,1);
                    cmd.Parameters["@ConcluyoProgramaEstudios"].Value = programa2daEspecializacionSuperiorDTO.ConcluyoProgramaEstudios;

                    cmd.Parameters.Add("@MotivosNoConcluir", SqlDbType.VarChar,300);
                    cmd.Parameters["@MotivosNoConcluir"].Value = programa2daEspecializacionSuperiorDTO.MotivosNoConcluir;

                    cmd.Parameters.Add("@CalificacionFinalObtenida", SqlDbType.Decimal);
                    cmd.Parameters["@CalificacionFinalObtenida"].Value = programa2daEspecializacionSuperiorDTO.CalificacionFinalObtenida;

                    cmd.Parameters.Add("@CertificacionTituloObtenido", SqlDbType.VarChar,100);
                    cmd.Parameters["@CertificacionTituloObtenido"].Value = programa2daEspecializacionSuperiorDTO.CertificacionTituloObtenido;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = programa2daEspecializacionSuperiorDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = programa2daEspecializacionSuperiorDTO.UsuarioIngresoRegistro;

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

        public Programa2daEspecializacionSuperiorDTO BuscarFormato(int Codigo)
        {
            Programa2daEspecializacionSuperiorDTO programa2daEspecializacionSuperiorDTO = new Programa2daEspecializacionSuperiorDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_Programa2daEspecializacionSuperiorEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Programa2daEspecializacionSuperiorId", SqlDbType.Int);
                    cmd.Parameters["@Programa2daEspecializacionSuperiorId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        programa2daEspecializacionSuperiorDTO.Programa2daEspecializacionSuperiorId = Convert.ToInt32(dr["Programa2daEspecializacionSuperiorId"]);
                        programa2daEspecializacionSuperiorDTO.DNIPersonalSuperior = dr["DNIPersonalSuperior"].ToString();
                        programa2daEspecializacionSuperiorDTO.EdadPersonalSuperior = Convert.ToInt32(dr["EdadPersonalSuperior"]);
                        programa2daEspecializacionSuperiorDTO.SexoPersonalSuperior = dr["SexoPersonalSuperior"].ToString();
                        programa2daEspecializacionSuperiorDTO.CondicionPersonalSuperior = dr["CondicionPersonalSuperior"].ToString();
                        programa2daEspecializacionSuperiorDTO.CodigoEntidadMilitar = dr["CodigoEntidadMilitar"].ToString();
                        programa2daEspecializacionSuperiorDTO.CodigoGradoPersonalMilitar = dr["CodigoGradoPersonalMilitar"].ToString();
                        programa2daEspecializacionSuperiorDTO.CodigoEspecialidadGenericaPersonal = dr["CodigoEspecialidadGenericaPersonal"].ToString();
                        programa2daEspecializacionSuperiorDTO.ProcedenciaPersonalSuperior = dr["ProcedenciaPersonalSuperior"].ToString();
                        programa2daEspecializacionSuperiorDTO.AnioPromocionPersonalSuperior = Convert.ToInt32(dr["AnioPromocionPersonalSuperior"]);
                        programa2daEspecializacionSuperiorDTO.CodigoDependencia = dr["CodigoDependencia"].ToString();
                        programa2daEspecializacionSuperiorDTO.CodigoZonaNaval = dr["CodigoZonaNaval"].ToString();
                        programa2daEspecializacionSuperiorDTO.CodigoProgramaEspecializacionGrupo = dr["CodigoProgramaEspecializacionGrupo"].ToString();
                        programa2daEspecializacionSuperiorDTO.CodigoProgramaEspecializacionEspecifico = dr["CodigoProgramaEspecializacionEspecifico"].ToString();
                        programa2daEspecializacionSuperiorDTO.FechaInicio = Convert.ToDateTime(dr["FechaInicio"]).ToString("yyy-MM-dd");
                        programa2daEspecializacionSuperiorDTO.FechaTermino = Convert.ToDateTime(dr["FechaTermino"]).ToString("yyy-MM-dd");
                        programa2daEspecializacionSuperiorDTO.FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]).ToString("yyy-MM-dd");
                        programa2daEspecializacionSuperiorDTO.CodigoModalidadPrograma = dr["CodigoModalidadPrograma"].ToString();
                        programa2daEspecializacionSuperiorDTO.ConcluyoProgramaEstudios = dr["ConcluyoProgramaEstudios"].ToString();
                        programa2daEspecializacionSuperiorDTO.MotivosNoConcluir = dr["MotivosNoConcluir"].ToString();
                        programa2daEspecializacionSuperiorDTO.CalificacionFinalObtenida = Convert.ToDecimal(dr["CalificacionFinalObtenida"]);
                        programa2daEspecializacionSuperiorDTO.CertificacionTituloObtenido = dr["CertificacionTituloObtenido"].ToString(); 
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return programa2daEspecializacionSuperiorDTO;
        }

        public string ActualizaFormato(Programa2daEspecializacionSuperiorDTO programa2daEspecializacionSuperiorDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_Programa2daEspecializacionSuperiorActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@Programa2daEspecializacionSuperiorId", SqlDbType.Int);
                    cmd.Parameters["@Programa2daEspecializacionSuperiorId"].Value = programa2daEspecializacionSuperiorDTO.Programa2daEspecializacionSuperiorId;

                    cmd.Parameters.Add("@DNIPersonalSuperior", SqlDbType.VarChar, 8);
                    cmd.Parameters["@DNIPersonalSuperior"].Value = programa2daEspecializacionSuperiorDTO.DNIPersonalSuperior;

                    cmd.Parameters.Add("@EdadPersonalSuperior", SqlDbType.Int);
                    cmd.Parameters["@EdadPersonalSuperior"].Value = programa2daEspecializacionSuperiorDTO.EdadPersonalSuperior;

                    cmd.Parameters.Add("@SexoPersonalSuperior", SqlDbType.VarChar, 10);
                    cmd.Parameters["@SexoPersonalSuperior"].Value = programa2daEspecializacionSuperiorDTO.SexoPersonalSuperior;

                    cmd.Parameters.Add("@CondicionPersonalSuperior", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CondicionPersonalSuperior"].Value = programa2daEspecializacionSuperiorDTO.CondicionPersonalSuperior;

                    cmd.Parameters.Add("@CodigoEntidadMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEntidadMilitar"].Value = programa2daEspecializacionSuperiorDTO.CodigoEntidadMilitar;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitar"].Value = programa2daEspecializacionSuperiorDTO.CodigoGradoPersonalMilitar;

                    cmd.Parameters.Add("@CodigoEspecialidadGenericaPersonal", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEspecialidadGenericaPersonal"].Value = programa2daEspecializacionSuperiorDTO.CodigoEspecialidadGenericaPersonal;

                    cmd.Parameters.Add("@ProcedenciaPersonalSuperior", SqlDbType.VarChar, 50);
                    cmd.Parameters["@ProcedenciaPersonalSuperior"].Value = programa2daEspecializacionSuperiorDTO.ProcedenciaPersonalSuperior;

                    cmd.Parameters.Add("@AnioPromocionPersonalSuperior", SqlDbType.Int);
                    cmd.Parameters["@AnioPromocionPersonalSuperior"].Value = programa2daEspecializacionSuperiorDTO.AnioPromocionPersonalSuperior;

                    cmd.Parameters.Add("@CodigoDependencia", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDependencia"].Value = programa2daEspecializacionSuperiorDTO.CodigoDependencia;

                    cmd.Parameters.Add("@CodigoZonaNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoZonaNaval"].Value = programa2daEspecializacionSuperiorDTO.CodigoZonaNaval;

                    cmd.Parameters.Add("@CodigoProgramaEspecializacionGrupo", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoProgramaEspecializacionGrupo"].Value = programa2daEspecializacionSuperiorDTO.CodigoProgramaEspecializacionGrupo;

                    cmd.Parameters.Add("@CodigoProgramaEspecializacionEspecifico", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoProgramaEspecializacionEspecifico"].Value = programa2daEspecializacionSuperiorDTO.CodigoProgramaEspecializacionEspecifico;

                    cmd.Parameters.Add("@FechaInicio", SqlDbType.Date);
                    cmd.Parameters["@FechaInicio"].Value = programa2daEspecializacionSuperiorDTO.FechaInicio;

                    cmd.Parameters.Add("@FechaTermino", SqlDbType.Date);
                    cmd.Parameters["@FechaTermino"].Value = programa2daEspecializacionSuperiorDTO.FechaTermino;

                    cmd.Parameters.Add("@FechaRegistro", SqlDbType.Date);
                    cmd.Parameters["@FechaRegistro"].Value = programa2daEspecializacionSuperiorDTO.FechaRegistro;

                    cmd.Parameters.Add("@CodigoModalidadPrograma", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoModalidadPrograma"].Value = programa2daEspecializacionSuperiorDTO.CodigoModalidadPrograma;

                    cmd.Parameters.Add("@ConcluyoProgramaEstudios", SqlDbType.NChar, 1);
                    cmd.Parameters["@ConcluyoProgramaEstudios"].Value = programa2daEspecializacionSuperiorDTO.ConcluyoProgramaEstudios;

                    cmd.Parameters.Add("@MotivosNoConcluir", SqlDbType.VarChar, 300);
                    cmd.Parameters["@MotivosNoConcluir"].Value = programa2daEspecializacionSuperiorDTO.MotivosNoConcluir;

                    cmd.Parameters.Add("@CalificacionFinalObtenida", SqlDbType.Decimal);
                    cmd.Parameters["@CalificacionFinalObtenida"].Value = programa2daEspecializacionSuperiorDTO.CalificacionFinalObtenida;

                    cmd.Parameters.Add("@CertificacionTituloObtenido", SqlDbType.VarChar, 100);
                    cmd.Parameters["@CertificacionTituloObtenido"].Value = programa2daEspecializacionSuperiorDTO.CertificacionTituloObtenido;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = programa2daEspecializacionSuperiorDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(Programa2daEspecializacionSuperiorDTO programa2daEspecializacionSuperiorDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_Programa2daEspecializacionSuperiorEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Programa2daEspecializacionSuperiorId", SqlDbType.Int);
                    cmd.Parameters["@Programa2daEspecializacionSuperiorId"].Value = programa2daEspecializacionSuperiorDTO.Programa2daEspecializacionSuperiorId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = programa2daEspecializacionSuperiorDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(Programa2daEspecializacionSuperiorDTO programa2daEspecializacionSuperiorDTO)
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
                    cmd.Parameters["@Formato"].Value = "Programa2daEspecializacionSuperior";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = programa2daEspecializacionSuperiorDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = programa2daEspecializacionSuperiorDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_Programa2daEspecializacionSuperiorRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Programa2daEspecializacionSuperior", SqlDbType.Structured);
                    cmd.Parameters["@Programa2daEspecializacionSuperior"].TypeName = "Formato.Programa2daEspecializacionSuperior";
                    cmd.Parameters["@Programa2daEspecializacionSuperior"].Value = datos;

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

