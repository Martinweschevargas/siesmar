using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comfasub;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comfasub
{
    public class EvaluacionAlistamientoPersonalComfasubDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<EvaluacionAlistamientoPersonalComfasubDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<EvaluacionAlistamientoPersonalComfasubDTO> lista = new List<EvaluacionAlistamientoPersonalComfasubDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoPersonalComfasubListar", conexion);
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
                        lista.Add(new EvaluacionAlistamientoPersonalComfasubDTO()
                        {
                            EvaluacionAlistamientoPersonalId = Convert.ToInt32(dr["EvaluacionAlistamientoPersonalId"]),
                            DescUnidadNaval = dr["DescUnidadNaval"].ToString(),
                            FechaEvaluacion = dr["FechaEvaluacion"].ToString().Split(" ", StringSplitOptions.None)[0],
                            NombresPersonal = dr["NombresPersonal"].ToString(),
                            DNIPersonal = dr["DNIPersonal"].ToString(),
                            CIPPersonal = dr["CIPPersonal"].ToString(),
                            DescCargo = dr["DescCargo"].ToString(),
                            DescGrado = dr["gradoEsperado"].ToString(),
                            DescEspecialidad = dr["EspecialidadEsperado"].ToString(),
                            DescGradoPersonalMilitarActual = dr["GradoActual"].ToString(),
                            DescEspecialidadGenericaPersonalActual = dr["EspecialidadActual"].ToString(),
                            GradoJerarquico = Convert.ToDecimal(dr["GradoJerarquico"]),
                            ServicioExperiencia = Convert.ToDecimal(dr["ServicioExperiencia"]),
                            EspecializacionProfesional = Convert.ToDecimal(dr["EspecializacionProfesional"]),
                            CursoProfesionalRequerido = Convert.ToDecimal(dr["CursoProfesionalRequerido"]),
                            DestaqueDependencia = dr["DestaqueDependencia"].ToString(),
                            FechaInicioDestaque = (dr["FechaInicioDestaque"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            FechaFinDestaque = (dr["FechaFinDestaque"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            TiempoEmbarque = dr["TiempoEmbarque"].ToString(),
                            DespliegeComisionExtranjero = dr["DespliegeComisionExtranjero"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"])
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(EvaluacionAlistamientoPersonalComfasubDTO evaluacionAlistamientoPersonalComfasubDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoPersonalComfasubRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoUnidadNaval", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoUnidadNaval"].Value = evaluacionAlistamientoPersonalComfasubDTO.CodigoUnidadNaval;

                    cmd.Parameters.Add("@FechaEvaluacion", SqlDbType.Date);
                    cmd.Parameters["@FechaEvaluacion"].Value = evaluacionAlistamientoPersonalComfasubDTO.FechaEvaluacion;

                    cmd.Parameters.Add("@NombresPersonal", SqlDbType.VarChar, 50);
                    cmd.Parameters["@NombresPersonal"].Value = evaluacionAlistamientoPersonalComfasubDTO.NombresPersonal;

                    cmd.Parameters.Add("@DNIPersonal", SqlDbType.VarChar, 8);
                    cmd.Parameters["@DNIPersonal"].Value = evaluacionAlistamientoPersonalComfasubDTO.DNIPersonal;

                    cmd.Parameters.Add("@CIPPersonal", SqlDbType.VarChar, 8);
                    cmd.Parameters["@CIPPersonal"].Value = evaluacionAlistamientoPersonalComfasubDTO.CIPPersonal;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCargo"].Value = evaluacionAlistamientoPersonalComfasubDTO.CodigoCargo;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitarEsperado", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitarEsperado"].Value = evaluacionAlistamientoPersonalComfasubDTO.CodigoGradoPersonalMilitarEsperado;

                    cmd.Parameters.Add("@CodigoEspecialidadGenericaPersonalEsperado", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEspecialidadGenericaPersonalEsperado"].Value = evaluacionAlistamientoPersonalComfasubDTO.CodigoEspecialidadGenericaPersonalEsperado;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitarActual", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitarActual"].Value = evaluacionAlistamientoPersonalComfasubDTO.CodigoGradoPersonalMilitarActual;

                    cmd.Parameters.Add("@CodigoEspecialidadGenericaActual", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEspecialidadGenericaActual"].Value = evaluacionAlistamientoPersonalComfasubDTO.CodigoEspecialidadGenericaActual;

                    cmd.Parameters.Add("@GradoJerarquico", SqlDbType.Decimal);
                    cmd.Parameters["@GradoJerarquico"].Value = evaluacionAlistamientoPersonalComfasubDTO.GradoJerarquico;

                    cmd.Parameters.Add("@ServicioExperiencia", SqlDbType.Decimal);
                    cmd.Parameters["@ServicioExperiencia"].Value = evaluacionAlistamientoPersonalComfasubDTO.ServicioExperiencia;

                    cmd.Parameters.Add("@EspecializacionProfesional", SqlDbType.Decimal);
                    cmd.Parameters["@EspecializacionProfesional"].Value = evaluacionAlistamientoPersonalComfasubDTO.EspecializacionProfesional;

                    cmd.Parameters.Add("@CursoProfesionalRequerido", SqlDbType.Decimal);
                    cmd.Parameters["@CursoProfesionalRequerido"].Value = evaluacionAlistamientoPersonalComfasubDTO.CursoProfesionalRequerido;

                    cmd.Parameters.Add("@DestaqueDependencia", SqlDbType.VarChar, 100);
                    cmd.Parameters["@DestaqueDependencia"].Value = evaluacionAlistamientoPersonalComfasubDTO.DestaqueDependencia;

                    cmd.Parameters.Add("@FechaInicioDestaque", SqlDbType.Date);
                    cmd.Parameters["@FechaInicioDestaque"].Value = evaluacionAlistamientoPersonalComfasubDTO.FechaInicioDestaque;

                    cmd.Parameters.Add("@FechaFinDestaque", SqlDbType.Date);
                    cmd.Parameters["@FechaFinDestaque"].Value = evaluacionAlistamientoPersonalComfasubDTO.FechaFinDestaque;

                    cmd.Parameters.Add("@TiempoEmbarque", SqlDbType.VarChar, 10);
                    cmd.Parameters["@TiempoEmbarque"].Value = evaluacionAlistamientoPersonalComfasubDTO.TiempoEmbarque;

                    cmd.Parameters.Add("@DespliegeComisionExtranjero", SqlDbType.VarChar, 20);
                    cmd.Parameters["@DespliegeComisionExtranjero"].Value = evaluacionAlistamientoPersonalComfasubDTO.DespliegeComisionExtranjero;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = evaluacionAlistamientoPersonalComfasubDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = evaluacionAlistamientoPersonalComfasubDTO.UsuarioIngresoRegistro;

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

        public EvaluacionAlistamientoPersonalComfasubDTO BuscarFormato(int Codigo)
        {
            EvaluacionAlistamientoPersonalComfasubDTO evaluacionAlistamientoPersonalComfasubDTO = new EvaluacionAlistamientoPersonalComfasubDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoPersonalComfasubEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EvaluacionAlistamientoPersonalId", SqlDbType.Int);
                    cmd.Parameters["@EvaluacionAlistamientoPersonalId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        evaluacionAlistamientoPersonalComfasubDTO.EvaluacionAlistamientoPersonalId = Convert.ToInt32(dr["EvaluacionAlistamientoPersonalId"]);
                        evaluacionAlistamientoPersonalComfasubDTO.CodigoUnidadNaval = dr["CodigoUnidadNaval"].ToString();
                        evaluacionAlistamientoPersonalComfasubDTO.FechaEvaluacion = Convert.ToDateTime(dr["FechaEvaluacion"]).ToString("yyy-MM-dd");
                        evaluacionAlistamientoPersonalComfasubDTO.NombresPersonal = dr["NombresPersonal"].ToString();
                        evaluacionAlistamientoPersonalComfasubDTO.DNIPersonal = dr["DNIPersonal"].ToString();
                        evaluacionAlistamientoPersonalComfasubDTO.CIPPersonal = dr["CIPPersonal"].ToString(); 
                        evaluacionAlistamientoPersonalComfasubDTO.CodigoCargo = dr["CodigoCargo"].ToString();
                        evaluacionAlistamientoPersonalComfasubDTO.CodigoGradoPersonalMilitarEsperado = dr["CodigoGradoPersonalMilitarEsperado"].ToString();
                        evaluacionAlistamientoPersonalComfasubDTO.CodigoEspecialidadGenericaPersonalEsperado = dr["CodigoEspecialidadGenericaPersonalEsperado"].ToString();
                        evaluacionAlistamientoPersonalComfasubDTO.CodigoGradoPersonalMilitarActual = dr["CodigoGradoPersonalMilitarActual"].ToString();
                        evaluacionAlistamientoPersonalComfasubDTO.CodigoEspecialidadGenericaActual = dr["CodigoEspecialidadGenericaActual"].ToString();
                        evaluacionAlistamientoPersonalComfasubDTO.GradoJerarquico = Convert.ToDecimal(dr["GradoJerarquico"]);
                        evaluacionAlistamientoPersonalComfasubDTO.ServicioExperiencia = Convert.ToDecimal(dr["ServicioExperiencia"]);
                        evaluacionAlistamientoPersonalComfasubDTO.EspecializacionProfesional = Convert.ToDecimal(dr["EspecializacionProfesional"]);
                        evaluacionAlistamientoPersonalComfasubDTO.CursoProfesionalRequerido = Convert.ToDecimal(dr["CursoProfesionalRequerido"]);
                        evaluacionAlistamientoPersonalComfasubDTO.DestaqueDependencia = dr["DestaqueDependencia"].ToString();
                        evaluacionAlistamientoPersonalComfasubDTO.FechaInicioDestaque = Convert.ToDateTime(dr["FechaInicioDestaque"]).ToString("yyy-MM-dd");
                        evaluacionAlistamientoPersonalComfasubDTO.FechaFinDestaque = Convert.ToDateTime(dr["FechaFinDestaque"]).ToString("yyy-MM-dd");
                        evaluacionAlistamientoPersonalComfasubDTO.TiempoEmbarque = dr["TiempoEmbarque"].ToString();
                        evaluacionAlistamientoPersonalComfasubDTO.DespliegeComisionExtranjero = dr["DespliegeComisionExtranjero"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return evaluacionAlistamientoPersonalComfasubDTO;
        }

        public string ActualizaFormato(EvaluacionAlistamientoPersonalComfasubDTO evaluacionAlistamientoPersonalComfasubDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoPersonalComfasubActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@EvaluacionAlistamientoPersonalId", SqlDbType.Int);
                    cmd.Parameters["@EvaluacionAlistamientoPersonalId"].Value = evaluacionAlistamientoPersonalComfasubDTO.EvaluacionAlistamientoPersonalId;

                    cmd.Parameters.Add("@CodigoUnidadNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUnidadNaval"].Value = evaluacionAlistamientoPersonalComfasubDTO.CodigoUnidadNaval;

                    cmd.Parameters.Add("@FechaEvaluacion", SqlDbType.Date);
                    cmd.Parameters["@FechaEvaluacion"].Value = evaluacionAlistamientoPersonalComfasubDTO.FechaEvaluacion;

                    cmd.Parameters.Add("@NombresPersonal", SqlDbType.VarChar, 50);
                    cmd.Parameters["@NombresPersonal"].Value = evaluacionAlistamientoPersonalComfasubDTO.NombresPersonal;

                    cmd.Parameters.Add("@DNIPersonal", SqlDbType.VarChar, 8);
                    cmd.Parameters["@DNIPersonal"].Value = evaluacionAlistamientoPersonalComfasubDTO.DNIPersonal;

                    cmd.Parameters.Add("@CIPPersonal", SqlDbType.VarChar, 8);
                    cmd.Parameters["@CIPPersonal"].Value = evaluacionAlistamientoPersonalComfasubDTO.CIPPersonal;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCargo"].Value = evaluacionAlistamientoPersonalComfasubDTO.CodigoCargo;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitarEsperado", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitarEsperado"].Value = evaluacionAlistamientoPersonalComfasubDTO.CodigoGradoPersonalMilitarEsperado;

                    cmd.Parameters.Add("@CodigoEspecialidadGenericaPersonalEsperado", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEspecialidadGenericaPersonalEsperado"].Value = evaluacionAlistamientoPersonalComfasubDTO.CodigoEspecialidadGenericaPersonalEsperado;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitarActual", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitarActual"].Value = evaluacionAlistamientoPersonalComfasubDTO.CodigoGradoPersonalMilitarActual;

                    cmd.Parameters.Add("@CodigoEspecialidadGenericaActual", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEspecialidadGenericaActual"].Value = evaluacionAlistamientoPersonalComfasubDTO.CodigoEspecialidadGenericaActual;

                    cmd.Parameters.Add("@GradoJerarquico", SqlDbType.Decimal);
                    cmd.Parameters["@GradoJerarquico"].Value = evaluacionAlistamientoPersonalComfasubDTO.GradoJerarquico;

                    cmd.Parameters.Add("@ServicioExperiencia", SqlDbType.Decimal);
                    cmd.Parameters["@ServicioExperiencia"].Value = evaluacionAlistamientoPersonalComfasubDTO.ServicioExperiencia;

                    cmd.Parameters.Add("@EspecializacionProfesional", SqlDbType.Decimal);
                    cmd.Parameters["@EspecializacionProfesional"].Value = evaluacionAlistamientoPersonalComfasubDTO.EspecializacionProfesional;

                    cmd.Parameters.Add("@CursoProfesionalRequerido", SqlDbType.Decimal);
                    cmd.Parameters["@CursoProfesionalRequerido"].Value = evaluacionAlistamientoPersonalComfasubDTO.CursoProfesionalRequerido;

                    cmd.Parameters.Add("@DestaqueDependencia", SqlDbType.VarChar, 100);
                    cmd.Parameters["@DestaqueDependencia"].Value = evaluacionAlistamientoPersonalComfasubDTO.DestaqueDependencia;

                    cmd.Parameters.Add("@FechaInicioDestaque", SqlDbType.Date);
                    cmd.Parameters["@FechaInicioDestaque"].Value = evaluacionAlistamientoPersonalComfasubDTO.FechaInicioDestaque;

                    cmd.Parameters.Add("@FechaFinDestaque", SqlDbType.Date);
                    cmd.Parameters["@FechaFinDestaque"].Value = evaluacionAlistamientoPersonalComfasubDTO.FechaFinDestaque;

                    cmd.Parameters.Add("@TiempoEmbarque", SqlDbType.VarChar, 10);
                    cmd.Parameters["@TiempoEmbarque"].Value = evaluacionAlistamientoPersonalComfasubDTO.TiempoEmbarque;

                    cmd.Parameters.Add("@DespliegeComisionExtranjero", SqlDbType.VarChar, 20);
                    cmd.Parameters["@DespliegeComisionExtranjero"].Value = evaluacionAlistamientoPersonalComfasubDTO.DespliegeComisionExtranjero;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = evaluacionAlistamientoPersonalComfasubDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(EvaluacionAlistamientoPersonalComfasubDTO evaluacionAlistamientoPersonalComfasubDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoPersonalComfasubEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EvaluacionAlistamientoPersonalId", SqlDbType.Int);
                    cmd.Parameters["@EvaluacionAlistamientoPersonalId"].Value = evaluacionAlistamientoPersonalComfasubDTO.EvaluacionAlistamientoPersonalId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = evaluacionAlistamientoPersonalComfasubDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(EvaluacionAlistamientoPersonalComfasubDTO evaluacionAlistamientoPersonalComfasubDTO)
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
                    cmd.Parameters["@Formato"].Value = "EvaluacionAlistamientoPersonalComfasub";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = evaluacionAlistamientoPersonalComfasubDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = evaluacionAlistamientoPersonalComfasubDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoPersonalComfasubRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EvaluacionAlistamientoPersonalComfasub", SqlDbType.Structured);
                    cmd.Parameters["@EvaluacionAlistamientoPersonalComfasub"].TypeName = "Formato.EvaluacionAlistamientoPersonalComfasub";
                    cmd.Parameters["@EvaluacionAlistamientoPersonalComfasub"].Value = datos;

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
