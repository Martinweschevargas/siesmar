using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.AccesoDatos.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Comfuavinav;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comfuavinav
{
    public class EvaluacionAlistamientoPersonalComfuavinavDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<EvaluacionAlistamientoPersonalComfuavinavDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<EvaluacionAlistamientoPersonalComfuavinavDTO> lista = new List<EvaluacionAlistamientoPersonalComfuavinavDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoPersonalComfuavinavListar", conexion);
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
                        lista.Add(new EvaluacionAlistamientoPersonalComfuavinavDTO()
                        {
                            EvaluacionAlistamientoPersonalId = Convert.ToInt32(dr["EvaluacionAlistamientoPersonalId"]),
                            DescUnidadNaval = dr["DescUnidadNaval"].ToString(),
                            FechaEvaluacion = (dr["FechaEvaluacion"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            DNIPersonal = dr["DNIPersonal"].ToString(),
                            CIPPersonal = dr["CIPPersonal"].ToString(),
                            DescCargo = dr["DescCargo"].ToString(),
                            DescGrado = dr["GradoEsperado"].ToString(),
                            DescEspecialidad = dr["EspecialidadEsperado"].ToString(),
                            DescGradoPersonalMilitarActual = dr["GradoActual"].ToString(),
                            DescEspecialidadGenericaPersonalActual = dr["EspecialdadActual"].ToString(),
                            GradoJerarquico = Convert.ToDecimal(dr["GradoJerarquico"]),
                            ServicioExperiencia = Convert.ToDecimal(dr["ServicioExperiencia"]),
                            EspecializacionProfesional = Convert.ToDecimal(dr["EspecializacionProfesional"]),
                            CursoProfesionalRequerido = Convert.ToDecimal(dr["CursoProfesionalRequerido"]),
                            CargaId = Convert.ToInt32(dr["CargaId"])
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(EvaluacionAlistamientoPersonalComfuavinavDTO evaluacionAlistPersonalComfuavinavDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoPersonalComfuavinavRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoUnidadNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUnidadNaval"].Value = evaluacionAlistPersonalComfuavinavDTO.CodigoUnidadNaval;

                    cmd.Parameters.Add("@FechaEvaluacion", SqlDbType.Date);
                    cmd.Parameters["@FechaEvaluacion"].Value = evaluacionAlistPersonalComfuavinavDTO.FechaEvaluacion;

                    cmd.Parameters.Add("@DNIPersonal", SqlDbType.VarChar, 20);
                    cmd.Parameters["@DNIPersonal"].Value = evaluacionAlistPersonalComfuavinavDTO.DNIPersonal;

                    cmd.Parameters.Add("@CIPPersonal", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CIPPersonal"].Value = evaluacionAlistPersonalComfuavinavDTO.CIPPersonal;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCargo"].Value = evaluacionAlistPersonalComfuavinavDTO.CodigoCargo;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitarEsperado", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitarEsperado"].Value = evaluacionAlistPersonalComfuavinavDTO.CodigoGradoPersonalMilitarEsperado;

                    cmd.Parameters.Add("@CodigoEspecialidadGenericaEsperado", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEspecialidadGenericaEsperado"].Value = evaluacionAlistPersonalComfuavinavDTO.CodigoEspecialidadGenericaEsperado;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitarActual", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitarActual"].Value = evaluacionAlistPersonalComfuavinavDTO.CodigoGradoPersonalMilitarActual;

                    cmd.Parameters.Add("@CodigoEspecialidadGenericaActual", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEspecialidadGenericaActual"].Value = evaluacionAlistPersonalComfuavinavDTO.CodigoEspecialidadGenericaActual;

                    cmd.Parameters.Add("@GradoJerarquico", SqlDbType.Decimal);
                    cmd.Parameters["@GradoJerarquico"].Value = evaluacionAlistPersonalComfuavinavDTO.GradoJerarquico;

                    cmd.Parameters.Add("@ServicioExperiencia", SqlDbType.Decimal);
                    cmd.Parameters["@ServicioExperiencia"].Value = evaluacionAlistPersonalComfuavinavDTO.ServicioExperiencia;

                    cmd.Parameters.Add("@EspecializacionProfesional", SqlDbType.Decimal);
                    cmd.Parameters["@EspecializacionProfesional"].Value = evaluacionAlistPersonalComfuavinavDTO.EspecializacionProfesional;

                    cmd.Parameters.Add("@CursoProfesionalRequerido", SqlDbType.Decimal);
                    cmd.Parameters["@CursoProfesionalRequerido"].Value = evaluacionAlistPersonalComfuavinavDTO.CursoProfesionalRequerido;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = evaluacionAlistPersonalComfuavinavDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = evaluacionAlistPersonalComfuavinavDTO.UsuarioIngresoRegistro;

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

        public EvaluacionAlistamientoPersonalComfuavinavDTO BuscarFormato(int Codigo)
        {
            EvaluacionAlistamientoPersonalComfuavinavDTO evaluacionAlistPersonalComfuavinavDTO = new EvaluacionAlistamientoPersonalComfuavinavDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoPersonalComfuavinavEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EvaluacionAlistamientoPersonalId", SqlDbType.Int);
                    cmd.Parameters["@EvaluacionAlistamientoPersonalId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        evaluacionAlistPersonalComfuavinavDTO.EvaluacionAlistamientoPersonalId = Convert.ToInt32(dr["EvaluacionAlistamientoPersonalId"]);
                        evaluacionAlistPersonalComfuavinavDTO.CodigoUnidadNaval = dr["CodigoUnidadNaval"].ToString();
                        evaluacionAlistPersonalComfuavinavDTO.FechaEvaluacion = Convert.ToDateTime(dr["FechaEvaluacion"]).ToString("yyy-MM-dd");
                        evaluacionAlistPersonalComfuavinavDTO.DNIPersonal = dr["DNIPersonal"].ToString();
                        evaluacionAlistPersonalComfuavinavDTO.CIPPersonal = dr["CIPPersonal"].ToString();
                        evaluacionAlistPersonalComfuavinavDTO.CodigoCargo = dr["CodigoCargo"].ToString();
                        evaluacionAlistPersonalComfuavinavDTO.CodigoGradoPersonalMilitarEsperado = dr["CodigoGradoPersonalMilitarEsperado"].ToString();
                        evaluacionAlistPersonalComfuavinavDTO.CodigoEspecialidadGenericaEsperado = dr["CodigoEspecialidadGenericaEsperado"].ToString();
                        evaluacionAlistPersonalComfuavinavDTO.CodigoGradoPersonalMilitarActual = dr["CodigoGradoPersonalMilitarActual"].ToString();
                        evaluacionAlistPersonalComfuavinavDTO.CodigoEspecialidadGenericaActual = dr["CodigoEspecialidadGenericaActual"].ToString();
                        evaluacionAlistPersonalComfuavinavDTO.GradoJerarquico = Convert.ToDecimal(dr["GradoJerarquico"]);
                        evaluacionAlistPersonalComfuavinavDTO.ServicioExperiencia = Convert.ToDecimal(dr["ServicioExperiencia"]);
                        evaluacionAlistPersonalComfuavinavDTO.EspecializacionProfesional = Convert.ToDecimal(dr["EspecializacionProfesional"]);
                        evaluacionAlistPersonalComfuavinavDTO.CursoProfesionalRequerido = Convert.ToDecimal(dr["CursoProfesionalRequerido"]);
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return evaluacionAlistPersonalComfuavinavDTO;
        }

        public string ActualizaFormato(EvaluacionAlistamientoPersonalComfuavinavDTO evaluacionAlistPersonalComfuavinavDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoPersonalComfuavinavActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@EvaluacionAlistamientoPersonalId", SqlDbType.Int);
                    cmd.Parameters["@EvaluacionAlistamientoPersonalId"].Value = evaluacionAlistPersonalComfuavinavDTO.EvaluacionAlistamientoPersonalId;

                    cmd.Parameters.Add("@CodigoUnidadNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUnidadNaval"].Value = evaluacionAlistPersonalComfuavinavDTO.CodigoUnidadNaval;

                    cmd.Parameters.Add("@FechaEvaluacion", SqlDbType.Date);
                    cmd.Parameters["@FechaEvaluacion"].Value = evaluacionAlistPersonalComfuavinavDTO.FechaEvaluacion;

                    cmd.Parameters.Add("@DNIPersonal", SqlDbType.VarChar, 20);
                    cmd.Parameters["@DNIPersonal"].Value = evaluacionAlistPersonalComfuavinavDTO.DNIPersonal;

                    cmd.Parameters.Add("@CIPPersonal", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CIPPersonal"].Value = evaluacionAlistPersonalComfuavinavDTO.CIPPersonal;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCargo"].Value = evaluacionAlistPersonalComfuavinavDTO.CodigoCargo;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitarEsperado", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitarEsperado"].Value = evaluacionAlistPersonalComfuavinavDTO.CodigoGradoPersonalMilitarEsperado;

                    cmd.Parameters.Add("@CodigoEspecialidadGenericaEsperado", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEspecialidadGenericaEsperado"].Value = evaluacionAlistPersonalComfuavinavDTO.CodigoEspecialidadGenericaEsperado;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitarActual", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitarActual"].Value = evaluacionAlistPersonalComfuavinavDTO.CodigoGradoPersonalMilitarActual;

                    cmd.Parameters.Add("@CodigoEspecialidadGenericaActual", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEspecialidadGenericaActual"].Value = evaluacionAlistPersonalComfuavinavDTO.CodigoEspecialidadGenericaActual;

                    cmd.Parameters.Add("@GradoJerarquico", SqlDbType.Decimal);
                    cmd.Parameters["@GradoJerarquico"].Value = evaluacionAlistPersonalComfuavinavDTO.GradoJerarquico;

                    cmd.Parameters.Add("@ServicioExperiencia", SqlDbType.Decimal);
                    cmd.Parameters["@ServicioExperiencia"].Value = evaluacionAlistPersonalComfuavinavDTO.ServicioExperiencia;

                    cmd.Parameters.Add("@EspecializacionProfesional", SqlDbType.Decimal);
                    cmd.Parameters["@EspecializacionProfesional"].Value = evaluacionAlistPersonalComfuavinavDTO.EspecializacionProfesional;

                    cmd.Parameters.Add("@CursoProfesionalRequerido", SqlDbType.Decimal);
                    cmd.Parameters["@CursoProfesionalRequerido"].Value = evaluacionAlistPersonalComfuavinavDTO.CursoProfesionalRequerido;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = evaluacionAlistPersonalComfuavinavDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(EvaluacionAlistamientoPersonalComfuavinavDTO evaluacionAlistPersonalComfuavinavDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoPersonalComfuavinavEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EvaluacionAlistamientoPersonalId", SqlDbType.Int);
                    cmd.Parameters["@EvaluacionAlistamientoPersonalId"].Value = evaluacionAlistPersonalComfuavinavDTO.EvaluacionAlistamientoPersonalId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = evaluacionAlistPersonalComfuavinavDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(EvaluacionAlistamientoPersonalComfuavinavDTO evaluacionAlistPersonalComfuavinavDTO)
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
                    cmd.Parameters["@Formato"].Value = "EvaluacionAlistamientoPersonalComfuavinav";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = evaluacionAlistPersonalComfuavinavDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = evaluacionAlistPersonalComfuavinavDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoPersonalComfuavinavRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EvaluacionAlistamientoPersonalComfuavinav", SqlDbType.Structured);
                    cmd.Parameters["@EvaluacionAlistamientoPersonalComfuavinav"].TypeName = "Formato.EvaluacionAlistamientoPersonalComfuavinav";
                    cmd.Parameters["@EvaluacionAlistamientoPersonalComfuavinav"].Value = datos;

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