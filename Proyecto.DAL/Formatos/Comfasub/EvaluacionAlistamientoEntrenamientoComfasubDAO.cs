using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comfasub;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comfasub
{
    public class EvaluacionAlistamientoEntrenamientoComfasubDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<EvaluacionAlistamientoEntrenamientoComfasubDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<EvaluacionAlistamientoEntrenamientoComfasubDTO> lista = new List<EvaluacionAlistamientoEntrenamientoComfasubDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoEntrenamientoComfasubListar", conexion);
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
                        lista.Add(new EvaluacionAlistamientoEntrenamientoComfasubDTO()
                        {
                            EvaluacionAlistamientoEntrenamientoId = Convert.ToInt32(dr["EvaluacionAlistamientoEntrenamientoId"]),
                            DescUnidadNaval = dr["DescUnidadNaval"].ToString(),
                            DescNivelEntrenamiento = dr["DescNivelEntrenamiento"].ToString(),
                            DescCapacidadOperativa = dr["DescCapacidadOperativa"].ToString(),
                            TipoCapacidadOperativa = dr["TipoCapacidadOperativa"].ToString(),
                            CodigoEjercicioEntrenamientoComfasub = dr["CodigoEjercicioEntrenamiento"].ToString(),
                            DescEjercicioEntrenamiento = dr["DescEjercicioEntrenamiento"].ToString(),
                            EjercicioEntrenamientoAspectos = dr["EjercicioEntrenamientoAspectos"].ToString(),
                            PesoAspectosEjercicio = dr["PesoAspectosEjercicio"].ToString(),
                            Descripcion = dr["Descripcion"].ToString(),
                            FechaPeriodoEvaluar = (dr["FechaPeriodoEvaluar"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            FechaRealizacionEjercicio = (dr["FechaRealizacionEjercicio"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            TiempoVigencia = Convert.ToInt32(dr["TiempoVigencia"]),
                            HoraNavegacionUnidad = Convert.ToInt32(dr["HoraNavegacionUnidad"]),
                            OperativoDespliegueRealizado = Convert.ToInt32(dr["OperativoDespliegueRealizado"]),
                            CargaId = Convert.ToInt32(dr["CargaId"])
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(EvaluacionAlistamientoEntrenamientoComfasubDTO evaluacionAlistamientoEntrenamientoComfasubDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoEntrenamientoComfasubRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoUnidadNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUnidadNaval"].Value = evaluacionAlistamientoEntrenamientoComfasubDTO.CodigoUnidadNaval;

                    cmd.Parameters.Add("@CodigoNivelEntrenamiento", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoNivelEntrenamiento"].Value = evaluacionAlistamientoEntrenamientoComfasubDTO.CodigoNivelEntrenamiento;

                    cmd.Parameters.Add("@CodigoCapacidadOperativa", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCapacidadOperativa"].Value = evaluacionAlistamientoEntrenamientoComfasubDTO.CodigoCapacidadOperativa;

                    cmd.Parameters.Add("@TipoCapacidadOperativa", SqlDbType.NChar, 2);
                    cmd.Parameters["@TipoCapacidadOperativa"].Value = evaluacionAlistamientoEntrenamientoComfasubDTO.TipoCapacidadOperativa;

                    cmd.Parameters.Add("@CodigoEjercicioEntrenamientoComfasub", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEjercicioEntrenamientoComfasub"].Value = evaluacionAlistamientoEntrenamientoComfasubDTO.CodigoEjercicioEntrenamientoComfasub;

                    cmd.Parameters.Add("@EjercicioEntrenamientoAspectos", SqlDbType.VarChar, 100);
                    cmd.Parameters["@EjercicioEntrenamientoAspectos"].Value = evaluacionAlistamientoEntrenamientoComfasubDTO.EjercicioEntrenamientoAspectos;

                    cmd.Parameters.Add("@PesoAspectosEjercicio", SqlDbType.VarChar, 10);
                    cmd.Parameters["@PesoAspectosEjercicio"].Value = evaluacionAlistamientoEntrenamientoComfasubDTO.PesoAspectosEjercicio;

                    cmd.Parameters.Add("@CodigoCalificativoAsignadoEjercicio", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCalificativoAsignadoEjercicio"].Value = evaluacionAlistamientoEntrenamientoComfasubDTO.CodigoCalificativoAsignadoEjercicio;

                    cmd.Parameters.Add("@FechaPeriodoEvaluar", SqlDbType.Date);
                    cmd.Parameters["@FechaPeriodoEvaluar"].Value = evaluacionAlistamientoEntrenamientoComfasubDTO.FechaPeriodoEvaluar;

                    cmd.Parameters.Add("@FechaRealizacionEjercicio", SqlDbType.Date);
                    cmd.Parameters["@FechaRealizacionEjercicio"].Value = evaluacionAlistamientoEntrenamientoComfasubDTO.FechaRealizacionEjercicio;

                    cmd.Parameters.Add("@TiempoVigencia", SqlDbType.Int);
                    cmd.Parameters["@TiempoVigencia"].Value = evaluacionAlistamientoEntrenamientoComfasubDTO.TiempoVigencia;

                    cmd.Parameters.Add("@HoraNavegacionUnidad", SqlDbType.Int);
                    cmd.Parameters["@HoraNavegacionUnidad"].Value = evaluacionAlistamientoEntrenamientoComfasubDTO.HoraNavegacionUnidad;

                    cmd.Parameters.Add("@OperativoDespliegueRealizado", SqlDbType.Int);
                    cmd.Parameters["@OperativoDespliegueRealizado"].Value = evaluacionAlistamientoEntrenamientoComfasubDTO.OperativoDespliegueRealizado;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = evaluacionAlistamientoEntrenamientoComfasubDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = evaluacionAlistamientoEntrenamientoComfasubDTO.UsuarioIngresoRegistro;

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

        public EvaluacionAlistamientoEntrenamientoComfasubDTO BuscarFormato(int Codigo)
        {
            EvaluacionAlistamientoEntrenamientoComfasubDTO evaluacionAlistamientoEntrenamientoComfasubDTO = new EvaluacionAlistamientoEntrenamientoComfasubDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoEntrenamientoComfasubEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EvaluacionAlistamientoEntrenamientoId", SqlDbType.Int);
                    cmd.Parameters["@EvaluacionAlistamientoEntrenamientoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        evaluacionAlistamientoEntrenamientoComfasubDTO.EvaluacionAlistamientoEntrenamientoId = Convert.ToInt32(dr["EvaluacionAlistamientoEntrenamientoId"]);
                        evaluacionAlistamientoEntrenamientoComfasubDTO.CodigoUnidadNaval = dr["CodigoUnidadNaval"].ToString();
                        evaluacionAlistamientoEntrenamientoComfasubDTO.CodigoNivelEntrenamiento = dr["CodigoNivelEntrenamiento"].ToString();
                        evaluacionAlistamientoEntrenamientoComfasubDTO.CodigoCapacidadOperativa = dr["CodigoCapacidadOperativa"].ToString();
                        evaluacionAlistamientoEntrenamientoComfasubDTO.TipoCapacidadOperativa = dr["TipoCapacidadOperativa"].ToString();
                        evaluacionAlistamientoEntrenamientoComfasubDTO.CodigoEjercicioEntrenamientoComfasub = dr["CodigoEjercicioEntrenamientoComfasub"].ToString();
                        evaluacionAlistamientoEntrenamientoComfasubDTO.EjercicioEntrenamientoAspectos = dr["EjercicioEntrenamientoAspectos"].ToString();
                        evaluacionAlistamientoEntrenamientoComfasubDTO.PesoAspectosEjercicio = dr["PesoAspectosEjercicio"].ToString();
                        evaluacionAlistamientoEntrenamientoComfasubDTO.CodigoCalificativoAsignadoEjercicio = dr["CodigoCalificativoAsignadoEjercicio"].ToString();
                        evaluacionAlistamientoEntrenamientoComfasubDTO.FechaPeriodoEvaluar = Convert.ToDateTime(dr["FechaPeriodoEvaluar"]).ToString("yyy-MM-dd");
                        evaluacionAlistamientoEntrenamientoComfasubDTO.FechaRealizacionEjercicio = Convert.ToDateTime(dr["FechaRealizacionEjercicio"]).ToString("yyy-MM-dd");
                        evaluacionAlistamientoEntrenamientoComfasubDTO.TiempoVigencia = Convert.ToInt32(dr["TiempoVigencia"]);
                        evaluacionAlistamientoEntrenamientoComfasubDTO.HoraNavegacionUnidad = Convert.ToInt32(dr["HoraNavegacionUnidad"]);
                        evaluacionAlistamientoEntrenamientoComfasubDTO.OperativoDespliegueRealizado = Convert.ToInt32(dr["OperativoDespliegueRealizado"]);
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return evaluacionAlistamientoEntrenamientoComfasubDTO;
        }

        public string ActualizaFormato(EvaluacionAlistamientoEntrenamientoComfasubDTO evaluacionAlistamientoEntrenamientoComfasubDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoEntrenamientoComfasubActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EvaluacionAlistamientoEntrenamientoId", SqlDbType.Int);
                    cmd.Parameters["@EvaluacionAlistamientoEntrenamientoId"].Value = evaluacionAlistamientoEntrenamientoComfasubDTO.EvaluacionAlistamientoEntrenamientoId;

                    cmd.Parameters.Add("@CodigoUnidadNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUnidadNaval"].Value = evaluacionAlistamientoEntrenamientoComfasubDTO.CodigoUnidadNaval;

                    cmd.Parameters.Add("@CodigoNivelEntrenamiento", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoNivelEntrenamiento"].Value = evaluacionAlistamientoEntrenamientoComfasubDTO.CodigoNivelEntrenamiento;

                    cmd.Parameters.Add("@CodigoCapacidadOperativa", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCapacidadOperativa"].Value = evaluacionAlistamientoEntrenamientoComfasubDTO.CodigoCapacidadOperativa;

                    cmd.Parameters.Add("@TipoCapacidadOperativa", SqlDbType.NChar, 2);
                    cmd.Parameters["@TipoCapacidadOperativa"].Value = evaluacionAlistamientoEntrenamientoComfasubDTO.TipoCapacidadOperativa;

                    cmd.Parameters.Add("@CodigoEjercicioEntrenamientoComfasub", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEjercicioEntrenamientoComfasub"].Value = evaluacionAlistamientoEntrenamientoComfasubDTO.CodigoEjercicioEntrenamientoComfasub;

                    cmd.Parameters.Add("@EjercicioEntrenamientoAspectos", SqlDbType.VarChar, 100);
                    cmd.Parameters["@EjercicioEntrenamientoAspectos"].Value = evaluacionAlistamientoEntrenamientoComfasubDTO.EjercicioEntrenamientoAspectos;

                    cmd.Parameters.Add("@PesoAspectosEjercicio", SqlDbType.VarChar, 10);
                    cmd.Parameters["@PesoAspectosEjercicio"].Value = evaluacionAlistamientoEntrenamientoComfasubDTO.PesoAspectosEjercicio;

                    cmd.Parameters.Add("@CodigoCalificativoAsignadoEjercicio", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCalificativoAsignadoEjercicio"].Value = evaluacionAlistamientoEntrenamientoComfasubDTO.CodigoCalificativoAsignadoEjercicio;

                    cmd.Parameters.Add("@FechaPeriodoEvaluar", SqlDbType.Date);
                    cmd.Parameters["@FechaPeriodoEvaluar"].Value = evaluacionAlistamientoEntrenamientoComfasubDTO.FechaPeriodoEvaluar;

                    cmd.Parameters.Add("@FechaRealizacionEjercicio", SqlDbType.Date);
                    cmd.Parameters["@FechaRealizacionEjercicio"].Value = evaluacionAlistamientoEntrenamientoComfasubDTO.FechaRealizacionEjercicio;

                    cmd.Parameters.Add("@TiempoVigencia", SqlDbType.Int);
                    cmd.Parameters["@TiempoVigencia"].Value = evaluacionAlistamientoEntrenamientoComfasubDTO.TiempoVigencia;

                    cmd.Parameters.Add("@HoraNavegacionUnidad", SqlDbType.Int);
                    cmd.Parameters["@HoraNavegacionUnidad"].Value = evaluacionAlistamientoEntrenamientoComfasubDTO.HoraNavegacionUnidad;

                    cmd.Parameters.Add("@OperativoDespliegueRealizado", SqlDbType.Int);
                    cmd.Parameters["@OperativoDespliegueRealizado"].Value = evaluacionAlistamientoEntrenamientoComfasubDTO.OperativoDespliegueRealizado;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = evaluacionAlistamientoEntrenamientoComfasubDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(EvaluacionAlistamientoEntrenamientoComfasubDTO evaluacionAlistamientoEntrenamientoComfasubDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoEntrenamientoComfasubEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EvaluacionAlistamientoEntrenamientoId", SqlDbType.Int);
                    cmd.Parameters["@EvaluacionAlistamientoEntrenamientoId"].Value = evaluacionAlistamientoEntrenamientoComfasubDTO.EvaluacionAlistamientoEntrenamientoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = evaluacionAlistamientoEntrenamientoComfasubDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(EvaluacionAlistamientoEntrenamientoComfasubDTO evaluacionAlistamientoEntrenamientoComfasubDTO)
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
                    cmd.Parameters["@Formato"].Value = "EvaluacionAlistamientoEntrenamientoComfasub";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = evaluacionAlistamientoEntrenamientoComfasubDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = evaluacionAlistamientoEntrenamientoComfasubDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoEntrenamientoComfasubRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EvaluacionAlistamientoEntrenamientoComfasub", SqlDbType.Structured);
                    cmd.Parameters["@EvaluacionAlistamientoEntrenamientoComfasub"].TypeName = "Formato.EvaluacionAlistamientoEntrenamientoComfasub";
                    cmd.Parameters["@EvaluacionAlistamientoEntrenamientoComfasub"].Value = datos;

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
