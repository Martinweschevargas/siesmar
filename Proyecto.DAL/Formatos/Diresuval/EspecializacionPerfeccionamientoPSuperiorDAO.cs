using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Diresuval;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Diresuval
{
    public class EspecializacionPerfeccionamientoPSuperiorDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<EspecializacionPerfeccionamientoPSuperiorDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<EspecializacionPerfeccionamientoPSuperiorDTO> lista = new List<EspecializacionPerfeccionamientoPSuperiorDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_EspecializacionPerfeccionamientoPSuperiorListar", conexion);
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
                        lista.Add(new EspecializacionPerfeccionamientoPSuperiorDTO()
                        {
                            EspecializacionPerfeccionamientoId = Convert.ToInt32(dr["EspecializacionPerfeccionamientoId"]),
                            DNIPersonalSuperior = dr["DNIPersonalSuperior"].ToString(),
                            EdadAnios = Convert.ToInt32(dr["EdadAnios"]),
                            Sexo = dr["Sexo"].ToString(),
                            Condicion = dr["Condicion"].ToString(),
                            DescEntidadMilitar = dr["DescEntidadMilitar"].ToString(),
                            DescGradoPersonalMilitar = dr["DescGrado"].ToString(),
                            DescEspecialidad = dr["DescEspecialidad"].ToString(),
                            Procedencia = dr["Procedencia"].ToString(),
                            AnioPromocion = Convert.ToInt32(dr["AnioPromocion"]),
                            DescDependencia = dr["DescDependencia"].ToString(),
                            DescZonaNaval = dr["DescZonaNaval"].ToString(),
                            DescProgramaEspecializacionGrupo = dr["DescProgramaEspecializacionGrupo"].ToString(),
                            DescProgramaEspecializacionEspecifico = dr["DescProgramaEspecializacionEspecifico"].ToString(),
                            FechaInicio = (dr["FechaInicio"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            FechaTermino = (dr["FechaTermino"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            FechaRegistro = (dr["FechaRegistro"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            ModalidadEspecializacion = dr["ModalidadEspecializacion"].ToString(),
                            ConcluyoPrograma = dr["ConcluyoPrograma"].ToString(),
                            MotivoNoConcluir = dr["MotivoNoConcluir"].ToString(),
                            CalificacionObtenida = Convert.ToDecimal(dr["CalificacionObtenida"]),
                            CertificacionObtenido = dr["CertificacionObtenido"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"]),

                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(EspecializacionPerfeccionamientoPSuperiorDTO especializacionPerfecPSuperiorDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EspecializacionPerfeccionamientoPSuperiorRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DNIPersonalSuperior", SqlDbType.VarChar, 8);
                    cmd.Parameters["@DNIPersonalSuperior"].Value = especializacionPerfecPSuperiorDTO.DNIPersonalSuperior;

                    cmd.Parameters.Add("@EdadAnios", SqlDbType.Int);
                    cmd.Parameters["@EdadAnios"].Value = especializacionPerfecPSuperiorDTO.EdadAnios;

                    cmd.Parameters.Add("@Sexo", SqlDbType.VarChar,10);
                    cmd.Parameters["@Sexo"].Value = especializacionPerfecPSuperiorDTO.Sexo;

                    cmd.Parameters.Add("@Condicion", SqlDbType.VarChar,15);
                    cmd.Parameters["@Condicion"].Value = especializacionPerfecPSuperiorDTO.Condicion;

                    cmd.Parameters.Add("@CodigoEntidadMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEntidadMilitar"].Value = especializacionPerfecPSuperiorDTO.CodigoEntidadMilitar;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitar"].Value = especializacionPerfecPSuperiorDTO.CodigoGradoPersonalMilitar;

                    cmd.Parameters.Add("@CodigoEspecialidadGenericaPersonal", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEspecialidadGenericaPersonal"].Value = especializacionPerfecPSuperiorDTO.CodigoEspecialidadGenericaPersonal;

                    cmd.Parameters.Add("@Procedencia", SqlDbType.VarChar,20);
                    cmd.Parameters["@Procedencia"].Value = especializacionPerfecPSuperiorDTO.Procedencia;

                    cmd.Parameters.Add("@AnioPromocion", SqlDbType.Int);
                    cmd.Parameters["@AnioPromocion"].Value = especializacionPerfecPSuperiorDTO.AnioPromocion;

                    cmd.Parameters.Add("@CodigoDependencia", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDependencia"].Value = especializacionPerfecPSuperiorDTO.CodigoDependencia;

                    cmd.Parameters.Add("@CodigoZonaNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoZonaNaval"].Value = especializacionPerfecPSuperiorDTO.CodigoZonaNaval;

                    cmd.Parameters.Add("@CodigoProgramaEspecializacionGrupo", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoProgramaEspecializacionGrupo"].Value = especializacionPerfecPSuperiorDTO.CodigoProgramaEspecializacionGrupo;

                    cmd.Parameters.Add("@CodigoProgramaEspecializacionEspecifico", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoProgramaEspecializacionEspecifico"].Value = especializacionPerfecPSuperiorDTO.CodigoProgramaEspecializacionEspecifico;

                    cmd.Parameters.Add("@FechaInicio", SqlDbType.Date);
                    cmd.Parameters["@FechaInicio"].Value = especializacionPerfecPSuperiorDTO.FechaInicio;

                    cmd.Parameters.Add("@FechaTermino", SqlDbType.Date);
                    cmd.Parameters["@FechaTermino"].Value = especializacionPerfecPSuperiorDTO.FechaTermino;

                    cmd.Parameters.Add("@FechaRegistro", SqlDbType.Date);
                    cmd.Parameters["@FechaRegistro"].Value = especializacionPerfecPSuperiorDTO.FechaRegistro;

                    cmd.Parameters.Add("@ModalidadEspecializacion", SqlDbType.VarChar,50);
                    cmd.Parameters["@ModalidadEspecializacion"].Value = especializacionPerfecPSuperiorDTO.ModalidadEspecializacion;

                    cmd.Parameters.Add("@ConcluyoPrograma", SqlDbType.NChar,2);
                    cmd.Parameters["@ConcluyoPrograma"].Value = especializacionPerfecPSuperiorDTO.ConcluyoPrograma;

                    cmd.Parameters.Add("@MotivoNoConcluir", SqlDbType.VarChar,100);
                    cmd.Parameters["@MotivoNoConcluir"].Value = especializacionPerfecPSuperiorDTO.MotivoNoConcluir;

                    cmd.Parameters.Add("@CalificacionObtenida", SqlDbType.Decimal);
                    cmd.Parameters["@CalificacionObtenida"].Value = especializacionPerfecPSuperiorDTO.CalificacionObtenida;

                    cmd.Parameters.Add("@CertificacionObtenido", SqlDbType.VarChar,100);
                    cmd.Parameters["@CertificacionObtenido"].Value = especializacionPerfecPSuperiorDTO.CertificacionObtenido;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = especializacionPerfecPSuperiorDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = especializacionPerfecPSuperiorDTO.UsuarioIngresoRegistro;

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

        public EspecializacionPerfeccionamientoPSuperiorDTO BuscarFormato(int Codigo)
        {
            EspecializacionPerfeccionamientoPSuperiorDTO especializacionPerfecPSuperiorDTO = new EspecializacionPerfeccionamientoPSuperiorDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EspecializacionPerfeccionamientoPSuperiorEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EspecializacionPerfeccionamientoId", SqlDbType.Int);
                    cmd.Parameters["@EspecializacionPerfeccionamientoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        especializacionPerfecPSuperiorDTO.EspecializacionPerfeccionamientoId = Convert.ToInt32(dr["EspecializacionPerfeccionamientoId"]);
                        especializacionPerfecPSuperiorDTO.DNIPersonalSuperior = dr["DNIPersonalSuperior"].ToString();
                        especializacionPerfecPSuperiorDTO.EdadAnios = Convert.ToInt32(dr["EdadAnios"]);
                        especializacionPerfecPSuperiorDTO.Sexo = dr["Sexo"].ToString();
                        especializacionPerfecPSuperiorDTO.Condicion = dr["Condicion"].ToString();
                        especializacionPerfecPSuperiorDTO.CodigoEntidadMilitar = dr["CodigoEntidadMilitar"].ToString();
                        especializacionPerfecPSuperiorDTO.CodigoGradoPersonalMilitar = dr["CodigoGradoPersonalMilitar"].ToString();
                        especializacionPerfecPSuperiorDTO.CodigoEspecialidadGenericaPersonal = dr["CodigoEspecialidadGenericaPersonal"].ToString();
                        especializacionPerfecPSuperiorDTO.Procedencia = dr["Procedencia"].ToString();
                        especializacionPerfecPSuperiorDTO.AnioPromocion = Convert.ToInt32(dr["AnioPromocion"]);
                        especializacionPerfecPSuperiorDTO.CodigoDependencia = dr["CodigoDependencia"].ToString();
                        especializacionPerfecPSuperiorDTO.CodigoZonaNaval = dr["CodigoZonaNaval"].ToString();
                        especializacionPerfecPSuperiorDTO.CodigoProgramaEspecializacionGrupo = dr["CodigoProgramaEspecializacionGrupo"].ToString();
                        especializacionPerfecPSuperiorDTO.CodigoProgramaEspecializacionEspecifico = dr["CodigoProgramaEspecializacionEspecifico"].ToString();
                        especializacionPerfecPSuperiorDTO.FechaInicio = Convert.ToDateTime(dr["FechaInicio"]).ToString("yyy-MM-dd");
                        especializacionPerfecPSuperiorDTO.FechaTermino = Convert.ToDateTime(dr["FechaTermino"]).ToString("yyy-MM-dd");
                        especializacionPerfecPSuperiorDTO.FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]).ToString("yyy-MM-dd");
                        especializacionPerfecPSuperiorDTO.ModalidadEspecializacion = dr["ModalidadEspecializacion"].ToString();
                        especializacionPerfecPSuperiorDTO.ConcluyoPrograma = dr["ConcluyoPrograma"].ToString();
                        especializacionPerfecPSuperiorDTO.MotivoNoConcluir = dr["MotivoNoConcluir"].ToString();
                        especializacionPerfecPSuperiorDTO.CalificacionObtenida = Convert.ToDecimal(dr["CalificacionObtenida"]);
                        especializacionPerfecPSuperiorDTO.CertificacionObtenido = dr["CertificacionObtenido"].ToString();
 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return especializacionPerfecPSuperiorDTO;
        }

        public string ActualizaFormato(EspecializacionPerfeccionamientoPSuperiorDTO especializacionPerfecPSuperiorDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_EspecializacionPerfeccionamientoPSuperiorActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@EspecializacionPerfeccionamientoId", SqlDbType.Int);
                    cmd.Parameters["@EspecializacionPerfeccionamientoId"].Value = especializacionPerfecPSuperiorDTO.EspecializacionPerfeccionamientoId;

                    cmd.Parameters.Add("@DNIPersonalSuperior", SqlDbType.Int);
                    cmd.Parameters["@DNIPersonalSuperior"].Value = especializacionPerfecPSuperiorDTO.DNIPersonalSuperior;

                    cmd.Parameters.Add("@EdadAnios", SqlDbType.Int);
                    cmd.Parameters["@EdadAnios"].Value = especializacionPerfecPSuperiorDTO.EdadAnios;

                    cmd.Parameters.Add("@Sexo", SqlDbType.VarChar, 10);
                    cmd.Parameters["@Sexo"].Value = especializacionPerfecPSuperiorDTO.Sexo;

                    cmd.Parameters.Add("@Condicion", SqlDbType.VarChar, 15);
                    cmd.Parameters["@Condicion"].Value = especializacionPerfecPSuperiorDTO.Condicion;

                    cmd.Parameters.Add("@CodigoEntidadMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEntidadMilitar"].Value = especializacionPerfecPSuperiorDTO.CodigoEntidadMilitar;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitar"].Value = especializacionPerfecPSuperiorDTO.CodigoGradoPersonalMilitar;

                    cmd.Parameters.Add("@CodigoEspecialidadGenericaPersonal", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEspecialidadGenericaPersonal"].Value = especializacionPerfecPSuperiorDTO.CodigoEspecialidadGenericaPersonal;

                    cmd.Parameters.Add("@Procedencia", SqlDbType.VarChar, 20);
                    cmd.Parameters["@Procedencia"].Value = especializacionPerfecPSuperiorDTO.Procedencia;

                    cmd.Parameters.Add("@AnioPromocion", SqlDbType.Int);
                    cmd.Parameters["@AnioPromocion"].Value = especializacionPerfecPSuperiorDTO.AnioPromocion;

                    cmd.Parameters.Add("@CodigoDependencia", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDependencia"].Value = especializacionPerfecPSuperiorDTO.CodigoDependencia;

                    cmd.Parameters.Add("@CodigoZonaNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoZonaNaval"].Value = especializacionPerfecPSuperiorDTO.CodigoZonaNaval;

                    cmd.Parameters.Add("@CodigoProgramaEspecializacionGrupo", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoProgramaEspecializacionGrupo"].Value = especializacionPerfecPSuperiorDTO.CodigoProgramaEspecializacionGrupo;

                    cmd.Parameters.Add("@CodigoProgramaEspecializacionEspecifico", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoProgramaEspecializacionEspecifico"].Value = especializacionPerfecPSuperiorDTO.CodigoProgramaEspecializacionEspecifico;

                    cmd.Parameters.Add("@FechaInicio", SqlDbType.Date);
                    cmd.Parameters["@FechaInicio"].Value = especializacionPerfecPSuperiorDTO.FechaInicio;

                    cmd.Parameters.Add("@FechaTermino", SqlDbType.Date);
                    cmd.Parameters["@FechaTermino"].Value = especializacionPerfecPSuperiorDTO.FechaTermino;

                    cmd.Parameters.Add("@FechaRegistro", SqlDbType.Date);
                    cmd.Parameters["@FechaRegistro"].Value = especializacionPerfecPSuperiorDTO.FechaRegistro;

                    cmd.Parameters.Add("@ModalidadEspecializacion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@ModalidadEspecializacion"].Value = especializacionPerfecPSuperiorDTO.ModalidadEspecializacion;

                    cmd.Parameters.Add("@ConcluyoPrograma", SqlDbType.NChar, 2);
                    cmd.Parameters["@ConcluyoPrograma"].Value = especializacionPerfecPSuperiorDTO.ConcluyoPrograma;

                    cmd.Parameters.Add("@MotivoNoConcluir", SqlDbType.VarChar, 100);
                    cmd.Parameters["@MotivoNoConcluir"].Value = especializacionPerfecPSuperiorDTO.MotivoNoConcluir;

                    cmd.Parameters.Add("@CalificacionObtenida", SqlDbType.Decimal);
                    cmd.Parameters["@CalificacionObtenida"].Value = especializacionPerfecPSuperiorDTO.CalificacionObtenida;

                    cmd.Parameters.Add("@CertificacionObtenido", SqlDbType.VarChar, 100);
                    cmd.Parameters["@CertificacionObtenido"].Value = especializacionPerfecPSuperiorDTO.CertificacionObtenido;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = especializacionPerfecPSuperiorDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(EspecializacionPerfeccionamientoPSuperiorDTO especializacionPerfecPSuperiorDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EspecializacionPerfeccionamientoPSuperiorEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EspecializacionPerfeccionamientoId", SqlDbType.Int);
                    cmd.Parameters["@EspecializacionPerfeccionamientoId"].Value = especializacionPerfecPSuperiorDTO.EspecializacionPerfeccionamientoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = especializacionPerfecPSuperiorDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(EspecializacionPerfeccionamientoPSuperiorDTO especializacionPerfecPSuperiorDTO)
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
                    cmd.Parameters["@Formato"].Value = "EspecializacionPerfeccionamientoPSuperior";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = especializacionPerfecPSuperiorDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = especializacionPerfecPSuperiorDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_EspecializacionPerfeccionamientoPSuperiorRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EspecializacionPerfeccionamientoPSuperior", SqlDbType.Structured);
                    cmd.Parameters["@EspecializacionPerfeccionamientoPSuperior"].TypeName = "Formato.EspecializacionPerfeccionamientoPSuperior";
                    cmd.Parameters["@EspecializacionPerfeccionamientoPSuperior"].Value = datos;

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
