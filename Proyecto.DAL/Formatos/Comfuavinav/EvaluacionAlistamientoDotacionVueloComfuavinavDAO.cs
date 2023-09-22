using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comfuavinav;
using Marina.Siesmar.Entidades.Formatos.Dipermar;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comfuavinav
{
    public class EvaluacionAlistamientoDotacionVueloComfuavinavDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<EvaluacionAlistamientoDotacionVueloComfuavinavDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<EvaluacionAlistamientoDotacionVueloComfuavinavDTO> lista = new List<EvaluacionAlistamientoDotacionVueloComfuavinavDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoDotacionVueloComfuavinavListar", conexion);
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
                        lista.Add(new EvaluacionAlistamientoDotacionVueloComfuavinavDTO()
                        {
                            EvaluacionAlistamientoDotacionVueloId = Convert.ToInt32(dr["EvaluacionAlistamientoDotacionVueloId"]),
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

        public string AgregarRegistro(EvaluacionAlistamientoDotacionVueloComfuavinavDTO evaluacionAlistDotacionVueloComfuavinavDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoDotacionVueloComfuavinavRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@CodigoUnidadNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUnidadNaval"].Value = evaluacionAlistDotacionVueloComfuavinavDTO.CodigoUnidadNaval;

                    cmd.Parameters.Add("@FechaEvaluacion", SqlDbType.Date);
                    cmd.Parameters["@FechaEvaluacion"].Value = evaluacionAlistDotacionVueloComfuavinavDTO.FechaEvaluacion;

                    cmd.Parameters.Add("@DNIPersonal", SqlDbType.VarChar,8);
                    cmd.Parameters["@DNIPersonal"].Value = evaluacionAlistDotacionVueloComfuavinavDTO.DNIPersonal;

                    cmd.Parameters.Add("@CIPPersonal", SqlDbType.VarChar,8);
                    cmd.Parameters["@CIPPersonal"].Value = evaluacionAlistDotacionVueloComfuavinavDTO.CIPPersonal;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoCargo"].Value = evaluacionAlistDotacionVueloComfuavinavDTO.CodigoCargo;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitarEsperado", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitarEsperado"].Value = evaluacionAlistDotacionVueloComfuavinavDTO.CodigoGradoPersonalMilitarEsperado;

                    cmd.Parameters.Add("@CodigoEspecialidadGenericaEsperado", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEspecialidadGenericaEsperado"].Value = evaluacionAlistDotacionVueloComfuavinavDTO.CodigoEspecialidadGenericaEsperado;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitarActual", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitarActual"].Value = evaluacionAlistDotacionVueloComfuavinavDTO.CodigoGradoPersonalMilitarActual;

                    cmd.Parameters.Add("@CodigoEspecialidadGenericaActual", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEspecialidadGenericaActual"].Value = evaluacionAlistDotacionVueloComfuavinavDTO.CodigoEspecialidadGenericaActual;

                    cmd.Parameters.Add("@GradoJerarquico", SqlDbType.Decimal);
                    cmd.Parameters["@GradoJerarquico"].Value = evaluacionAlistDotacionVueloComfuavinavDTO.GradoJerarquico;

                    cmd.Parameters.Add("@ServicioExperiencia", SqlDbType.Decimal);
                    cmd.Parameters["@ServicioExperiencia"].Value = evaluacionAlistDotacionVueloComfuavinavDTO.ServicioExperiencia;

                    cmd.Parameters.Add("@EspecializacionProfesional", SqlDbType.Decimal);
                    cmd.Parameters["@EspecializacionProfesional"].Value = evaluacionAlistDotacionVueloComfuavinavDTO.EspecializacionProfesional;

                    cmd.Parameters.Add("@CursoProfesionalRequerido", SqlDbType.Decimal);
                    cmd.Parameters["@CursoProfesionalRequerido"].Value = evaluacionAlistDotacionVueloComfuavinavDTO.CursoProfesionalRequerido;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = evaluacionAlistDotacionVueloComfuavinavDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = evaluacionAlistDotacionVueloComfuavinavDTO.UsuarioIngresoRegistro;

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

        public EvaluacionAlistamientoDotacionVueloComfuavinavDTO BuscarFormato(int Codigo)
        {
            EvaluacionAlistamientoDotacionVueloComfuavinavDTO evaluacionAlistDotacionVueloComfuavinavDTO = new EvaluacionAlistamientoDotacionVueloComfuavinavDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoDotacionVueloComfuavinavEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EvaluacionAlistamientoDotacionVueloId", SqlDbType.Int);
                    cmd.Parameters["@EvaluacionAlistamientoDotacionVueloId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        evaluacionAlistDotacionVueloComfuavinavDTO.EvaluacionAlistamientoDotacionVueloId = Convert.ToInt32(dr["EvaluacionAlistamientoDotacionVueloId"]);
                        evaluacionAlistDotacionVueloComfuavinavDTO.CodigoUnidadNaval = dr["CodigoUnidadNaval"].ToString();
                        evaluacionAlistDotacionVueloComfuavinavDTO.FechaEvaluacion = Convert.ToDateTime(dr["FechaEvaluacion"]).ToString("yyy-MM-dd");
                        evaluacionAlistDotacionVueloComfuavinavDTO.DNIPersonal = dr["DNIPersonal"].ToString();
                        evaluacionAlistDotacionVueloComfuavinavDTO.CIPPersonal = dr["CIPPersonal"].ToString();
                        evaluacionAlistDotacionVueloComfuavinavDTO.CodigoCargo = dr["CodigoCargo"].ToString();
                        evaluacionAlistDotacionVueloComfuavinavDTO.CodigoGradoPersonalMilitarEsperado = dr["CodigoGradoPersonalMilitarEsperado"].ToString();
                        evaluacionAlistDotacionVueloComfuavinavDTO.CodigoEspecialidadGenericaEsperado = dr["CodigoEspecialidadGenericaEsperado"].ToString();
                        evaluacionAlistDotacionVueloComfuavinavDTO.CodigoGradoPersonalMilitarActual = dr["CodigoGradoPersonalMilitarActual"].ToString();
                        evaluacionAlistDotacionVueloComfuavinavDTO.CodigoEspecialidadGenericaActual = dr["CodigoEspecialidadGenericaActual"].ToString();
                        evaluacionAlistDotacionVueloComfuavinavDTO.GradoJerarquico = Convert.ToDecimal(dr["GradoJerarquico"]);
                        evaluacionAlistDotacionVueloComfuavinavDTO.ServicioExperiencia = Convert.ToDecimal(dr["ServicioExperiencia"]);
                        evaluacionAlistDotacionVueloComfuavinavDTO.EspecializacionProfesional = Convert.ToDecimal(dr["EspecializacionProfesional"]);
                        evaluacionAlistDotacionVueloComfuavinavDTO.CursoProfesionalRequerido = Convert.ToDecimal(dr["CursoProfesionalRequerido"]);

 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return evaluacionAlistDotacionVueloComfuavinavDTO;
        }

        public string ActualizaFormato(EvaluacionAlistamientoDotacionVueloComfuavinavDTO evaluacionAlistDotacionVueloComfuavinavDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoDotacionVueloComfuavinavActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@EvaluacionAlistamientoDotacionVueloId", SqlDbType.Int);
                    cmd.Parameters["@EvaluacionAlistamientoDotacionVueloId"].Value = evaluacionAlistDotacionVueloComfuavinavDTO.EvaluacionAlistamientoDotacionVueloId;

                    cmd.Parameters.Add("@CodigoUnidadNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUnidadNaval"].Value = evaluacionAlistDotacionVueloComfuavinavDTO.CodigoUnidadNaval;

                    cmd.Parameters.Add("@FechaEvaluacion", SqlDbType.Date);
                    cmd.Parameters["@FechaEvaluacion"].Value = evaluacionAlistDotacionVueloComfuavinavDTO.FechaEvaluacion;

                    cmd.Parameters.Add("@DNIPersonal", SqlDbType.VarChar, 8);
                    cmd.Parameters["@DNIPersonal"].Value = evaluacionAlistDotacionVueloComfuavinavDTO.DNIPersonal;

                    cmd.Parameters.Add("@CIPPersonal", SqlDbType.VarChar, 8);
                    cmd.Parameters["@CIPPersonal"].Value = evaluacionAlistDotacionVueloComfuavinavDTO.CIPPersonal;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoCargo"].Value = evaluacionAlistDotacionVueloComfuavinavDTO.CodigoCargo;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitarEsperado", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitarEsperado"].Value = evaluacionAlistDotacionVueloComfuavinavDTO.CodigoGradoPersonalMilitarEsperado;

                    cmd.Parameters.Add("@CodigoEspecialidadGenericaEsperado", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEspecialidadGenericaEsperado"].Value = evaluacionAlistDotacionVueloComfuavinavDTO.CodigoEspecialidadGenericaEsperado;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitarActual", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitarActual"].Value = evaluacionAlistDotacionVueloComfuavinavDTO.CodigoGradoPersonalMilitarActual;

                    cmd.Parameters.Add("@CodigoEspecialidadGenericaActual", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEspecialidadGenericaActual"].Value = evaluacionAlistDotacionVueloComfuavinavDTO.CodigoEspecialidadGenericaActual;

                    cmd.Parameters.Add("@GradoJerarquico", SqlDbType.Decimal);
                    cmd.Parameters["@GradoJerarquico"].Value = evaluacionAlistDotacionVueloComfuavinavDTO.GradoJerarquico;

                    cmd.Parameters.Add("@ServicioExperiencia", SqlDbType.Decimal);
                    cmd.Parameters["@ServicioExperiencia"].Value = evaluacionAlistDotacionVueloComfuavinavDTO.ServicioExperiencia;

                    cmd.Parameters.Add("@EspecializacionProfesional", SqlDbType.Decimal);
                    cmd.Parameters["@EspecializacionProfesional"].Value = evaluacionAlistDotacionVueloComfuavinavDTO.EspecializacionProfesional;

                    cmd.Parameters.Add("@CursoProfesionalRequerido", SqlDbType.Decimal);
                    cmd.Parameters["@CursoProfesionalRequerido"].Value = evaluacionAlistDotacionVueloComfuavinavDTO.CursoProfesionalRequerido;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = evaluacionAlistDotacionVueloComfuavinavDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(EvaluacionAlistamientoDotacionVueloComfuavinavDTO evaluacionAlistDotacionVueloComfuavinavDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoDotacionVueloComfuavinavEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EvaluacionAlistamientoDotacionVueloId", SqlDbType.Int);
                    cmd.Parameters["@EvaluacionAlistamientoDotacionVueloId"].Value = evaluacionAlistDotacionVueloComfuavinavDTO.EvaluacionAlistamientoDotacionVueloId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = evaluacionAlistDotacionVueloComfuavinavDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(EvaluacionAlistamientoDotacionVueloComfuavinavDTO evaluacionAlistDotacionVueloComfuavinavDTO)
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
                    cmd.Parameters["@Formato"].Value = "EvaluacionAlistamientoDotacionVueloComfuavinav";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = evaluacionAlistDotacionVueloComfuavinavDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = evaluacionAlistDotacionVueloComfuavinavDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoDotacionVueloComfuavinavRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EvaluacionAlistamientoDotacionVueloComfuavinav", SqlDbType.Structured);
                    cmd.Parameters["@EvaluacionAlistamientoDotacionVueloComfuavinav"].TypeName = "Formato.EvaluacionAlistamientoDotacionVueloComfuavinav";
                    cmd.Parameters["@EvaluacionAlistamientoDotacionVueloComfuavinav"].Value = datos;

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
