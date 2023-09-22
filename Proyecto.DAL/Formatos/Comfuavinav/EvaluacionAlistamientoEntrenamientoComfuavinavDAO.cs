using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comfuavinav;
using Marina.Siesmar.Entidades.Formatos.Comzouno;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comfuavinav
{
    public class EvaluacionAlistamientoEntrenamientoComfuavinavDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<EvaluacionAlistamientoEntrenamientoComfuavinavDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<EvaluacionAlistamientoEntrenamientoComfuavinavDTO> lista = new List<EvaluacionAlistamientoEntrenamientoComfuavinavDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_EjercicioAlistamientoEntrenamientoComfuavinavListar", conexion);
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
                        lista.Add(new EvaluacionAlistamientoEntrenamientoComfuavinavDTO()
                        {
                            EvaluacionAlistamientoEntrenamientoId = Convert.ToInt32(dr["EvaluacionAlistamientoEntrenamientoId"]),
                            DescUnidadNaval = dr["DescUnidadNaval"].ToString(),
                            DescNivelEntrenamiento = dr["DescNivelEntrenamiento"].ToString(),
                            DescCapacidadOperativa = dr["DescCapacidadOperativa"].ToString(),
                            TipoCapacidadOperativa = dr["TipoCapacidadOperativa"].ToString(),
                            CodigoEjercicioEntrenamiento = dr["CodigoEjercicioEntrenamiento"].ToString(),
                            DescEjercicioEntrenamiento = dr["DescEjercicioEntrenamiento"].ToString(),
                            FechaPeriodoEvaluar = (dr["FechaPeriodoEvaluar"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            FechaRealizacionEjercicio = (dr["FechaRealizacionEjercicio"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            TiempoVigencia = Convert.ToInt32(dr["TiempoVigencia"]),
                            CargaId = Convert.ToInt32(dr["CargaId"])
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(EvaluacionAlistamientoEntrenamientoComfuavinavDTO evaluacionAlistamientoEntrenamientoComfuavinavDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EjercicioAlistamientoEntrenamientoComfuavinavRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoUnidadNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUnidadNaval"].Value = evaluacionAlistamientoEntrenamientoComfuavinavDTO.CodigoUnidadNaval;

                    cmd.Parameters.Add("@CodigoNivelEntrenamiento", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoNivelEntrenamiento"].Value = evaluacionAlistamientoEntrenamientoComfuavinavDTO.CodigoNivelEntrenamiento;

                    cmd.Parameters.Add("@CodigoCapacidadOperativa", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCapacidadOperativa"].Value = evaluacionAlistamientoEntrenamientoComfuavinavDTO.CodigoCapacidadOperativa;

                    cmd.Parameters.Add("@TipoCapacidadOperativa", SqlDbType.VarChar, 15);
                    cmd.Parameters["@TipoCapacidadOperativa"].Value = evaluacionAlistamientoEntrenamientoComfuavinavDTO.TipoCapacidadOperativa;

                    cmd.Parameters.Add("@CodigoEjercicioEntrenamiento", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEjercicioEntrenamiento"].Value = evaluacionAlistamientoEntrenamientoComfuavinavDTO.CodigoEjercicioEntrenamiento;

                    cmd.Parameters.Add("@FechaPeriodoEvaluar", SqlDbType.Date);
                    cmd.Parameters["@FechaPeriodoEvaluar"].Value = evaluacionAlistamientoEntrenamientoComfuavinavDTO.FechaPeriodoEvaluar;

                    cmd.Parameters.Add("@FechaRealizacionEjercicio", SqlDbType.Date);
                    cmd.Parameters["@FechaRealizacionEjercicio"].Value = evaluacionAlistamientoEntrenamientoComfuavinavDTO.FechaRealizacionEjercicio;

                    cmd.Parameters.Add("@TiempoVigencia", SqlDbType.Int);
                    cmd.Parameters["@TiempoVigencia"].Value = evaluacionAlistamientoEntrenamientoComfuavinavDTO.TiempoVigencia;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = evaluacionAlistamientoEntrenamientoComfuavinavDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = evaluacionAlistamientoEntrenamientoComfuavinavDTO.UsuarioIngresoRegistro;

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

        public EvaluacionAlistamientoEntrenamientoComfuavinavDTO BuscarFormato(int Codigo)
        {
            EvaluacionAlistamientoEntrenamientoComfuavinavDTO evaluacionAlistamientoEntrenamientoComfuavinavDTO = new EvaluacionAlistamientoEntrenamientoComfuavinavDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EjercicioAlistamientoEntrenamientoComfuavinavEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EvaluacionAlistamientoEntrenamientoId", SqlDbType.Int);
                    cmd.Parameters["@EvaluacionAlistamientoEntrenamientoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        evaluacionAlistamientoEntrenamientoComfuavinavDTO.EvaluacionAlistamientoEntrenamientoId = Convert.ToInt32(dr["EvaluacionAlistamientoEntrenamientoId"]);
                        evaluacionAlistamientoEntrenamientoComfuavinavDTO.CodigoUnidadNaval = dr["CodigoUnidadNaval"].ToString();
                        evaluacionAlistamientoEntrenamientoComfuavinavDTO.CodigoNivelEntrenamiento = dr["CodigoNivelEntrenamiento"].ToString();
                        evaluacionAlistamientoEntrenamientoComfuavinavDTO.CodigoCapacidadOperativa = dr["CodigoCapacidadOperativa"].ToString();
                        evaluacionAlistamientoEntrenamientoComfuavinavDTO.TipoCapacidadOperativa = dr["TipoCapacidadOperativa"].ToString();
                        evaluacionAlistamientoEntrenamientoComfuavinavDTO.CodigoEjercicioEntrenamiento = dr["CodigoEjercicioEntrenamiento"].ToString();
                        evaluacionAlistamientoEntrenamientoComfuavinavDTO.FechaPeriodoEvaluar = Convert.ToDateTime(dr["FechaPeriodoEvaluar"]).ToString("yyy-MM-dd");
                        evaluacionAlistamientoEntrenamientoComfuavinavDTO.FechaRealizacionEjercicio = Convert.ToDateTime(dr["FechaRealizacionEjercicio"]).ToString("yyy-MM-dd");
                        evaluacionAlistamientoEntrenamientoComfuavinavDTO.TiempoVigencia = Convert.ToInt32(dr["TiempoVigencia"]);
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return evaluacionAlistamientoEntrenamientoComfuavinavDTO;
        }

        public string ActualizaFormato(EvaluacionAlistamientoEntrenamientoComfuavinavDTO evaluacionAlistamientoEntrenamientoComfuavinavDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_EjercicioAlistamientoEntrenamientoComfuavinavActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EvaluacionAlistamientoEntrenamientoId", SqlDbType.Int);
                    cmd.Parameters["@EvaluacionAlistamientoEntrenamientoId"].Value = evaluacionAlistamientoEntrenamientoComfuavinavDTO.EvaluacionAlistamientoEntrenamientoId;

                    cmd.Parameters.Add("@CodigoUnidadNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUnidadNaval"].Value = evaluacionAlistamientoEntrenamientoComfuavinavDTO.CodigoUnidadNaval;

                    cmd.Parameters.Add("@CodigoNivelEntrenamiento", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoNivelEntrenamiento"].Value = evaluacionAlistamientoEntrenamientoComfuavinavDTO.CodigoNivelEntrenamiento;

                    cmd.Parameters.Add("@CodigoCapacidadOperativa", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCapacidadOperativa"].Value = evaluacionAlistamientoEntrenamientoComfuavinavDTO.CodigoCapacidadOperativa;

                    cmd.Parameters.Add("@TipoCapacidadOperativa", SqlDbType.VarChar, 15);
                    cmd.Parameters["@TipoCapacidadOperativa"].Value = evaluacionAlistamientoEntrenamientoComfuavinavDTO.TipoCapacidadOperativa;

                    cmd.Parameters.Add("@CodigoEjercicioEntrenamiento", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEjercicioEntrenamiento"].Value = evaluacionAlistamientoEntrenamientoComfuavinavDTO.CodigoEjercicioEntrenamiento;

                    cmd.Parameters.Add("@FechaPeriodoEvaluar", SqlDbType.Date);
                    cmd.Parameters["@FechaPeriodoEvaluar"].Value = evaluacionAlistamientoEntrenamientoComfuavinavDTO.FechaPeriodoEvaluar;

                    cmd.Parameters.Add("@FechaRealizacionEjercicio", SqlDbType.Date);
                    cmd.Parameters["@FechaRealizacionEjercicio"].Value = evaluacionAlistamientoEntrenamientoComfuavinavDTO.FechaRealizacionEjercicio;

                    cmd.Parameters.Add("@TiempoVigencia", SqlDbType.Int);
                    cmd.Parameters["@TiempoVigencia"].Value = evaluacionAlistamientoEntrenamientoComfuavinavDTO.TiempoVigencia;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = evaluacionAlistamientoEntrenamientoComfuavinavDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(EvaluacionAlistamientoEntrenamientoComfuavinavDTO evaluacionAlistamientoEntrenamientoComfuavinavDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EjercicioAlistamientoEntrenamientoComfuavinavEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EvaluacionAlistamientoEntrenamientoId", SqlDbType.Int);
                    cmd.Parameters["@EvaluacionAlistamientoEntrenamientoId"].Value = evaluacionAlistamientoEntrenamientoComfuavinavDTO.EvaluacionAlistamientoEntrenamientoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = evaluacionAlistamientoEntrenamientoComfuavinavDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(EvaluacionAlistamientoEntrenamientoComfuavinavDTO evaluacionAlistamientoEntrenamientoComfuavinavDTO)
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

                    cmd.Parameters.Add("@Formato", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Formato"].Value = "EjercicioAlistamientoEntrenamientoComfuavinav";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = evaluacionAlistamientoEntrenamientoComfuavinavDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = evaluacionAlistamientoEntrenamientoComfuavinavDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_EjercicioAlistamientoEntrenamientoComfuavinavRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EjercicioAlistamientoEntrenamientoComfuavinav", SqlDbType.Structured);
                    cmd.Parameters["@EjercicioAlistamientoEntrenamientoComfuavinav"].TypeName = "Formato.EjercicioAlistamientoEntrenamientoComfuavinav";
                    cmd.Parameters["@EjercicioAlistamientoEntrenamientoComfuavinav"].Value = datos;

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