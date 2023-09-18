using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comzocuatro;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comzocuatro
{
    public class EvaluacionAlistEntrenamientoComzocuatroDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<EvaluacionAlistEntrenamientoComzocuatroDTO> ObtenerLista(int? CargaId = null)
        {
            List<EvaluacionAlistEntrenamientoComzocuatroDTO> lista = new List<EvaluacionAlistEntrenamientoComzocuatroDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoEntrenamientoComzocuatroListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new EvaluacionAlistEntrenamientoComzocuatroDTO()
                        {
                            EvaluacionAlistamientoEntrenamientoId = Convert.ToInt32(dr["EvaluacionAlistamientoEntrenamientoId"]),
                            DescUnidadNaval = dr["DescUnidadNaval"].ToString(),
                            CodigoNivelEntrenamiento = dr["CodigoNivelEntrenamiento"].ToString(),
                            DescCapacidadOperativa = dr["DescCapacidadOperativa"].ToString(),
                            TipoCapacidadOperativo = dr["TipoCapacidadOperativo"].ToString(),
                            Codigo = dr["Codigo"].ToString(),
                            DescEjercicioEntrenamiento = dr["DescEjercicioEntrenamiento"].ToString(),
                            AspectoEvaluacion = dr["AspectoEvaluacion"].ToString(),
                            Peso = dr["Peso"].ToString(),
                            DescCalificativoAsignadoEjercicio = dr["DescCalificativoAsignadoEjercicio"].ToString(),
                            PuntajeObtenido = Convert.ToInt32(dr["PuntajeObtenido"]),
                            FechaPeriodoEvaluar = (dr["FechaPeriodoEvaluar"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            FechaRealizacionEjercicio = (dr["FechaRealizacionEjercicio"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            TiempoVigencia = Convert.ToInt32(dr["TiempoVigencia"]),
                            FechaCaducidadEjercicio = (dr["FechaCaducidadEjercicio"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            CargaId = Convert.ToInt32(dr["CargaId"])


                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(EvaluacionAlistEntrenamientoComzocuatroDTO evaluacionAlistEntrenamientoComzocuatroDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoEntrenamientoComzocuatroRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@CodigoUnidadNaval", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoUnidadNaval"].Value = evaluacionAlistEntrenamientoComzocuatroDTO.CodigoUnidadNaval;

                    cmd.Parameters.Add("@CodigoNivelEntrenamiento", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoNivelEntrenamiento"].Value = evaluacionAlistEntrenamientoComzocuatroDTO.CodigoNivelEntrenamiento;

                    cmd.Parameters.Add("@CodigoCapacidadOperativa", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCapacidadOperativa"].Value = evaluacionAlistEntrenamientoComzocuatroDTO.CodigoCapacidadOperativa;

                    cmd.Parameters.Add("@TipoCapacidadOperativo", SqlDbType.VarChar,15);
                    cmd.Parameters["@TipoCapacidadOperativo"].Value = evaluacionAlistEntrenamientoComzocuatroDTO.TipoCapacidadOperativo;

                    cmd.Parameters.Add("@CodigoEjercicioEntrenamientoAspecto", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEjercicioEntrenamientoAspecto"].Value = evaluacionAlistEntrenamientoComzocuatroDTO.CodigoEjercicioEntrenamientoAspecto;

                    cmd.Parameters.Add("@CodigoCalificativoAsignadoEjercicio", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCalificativoAsignadoEjercicio"].Value = evaluacionAlistEntrenamientoComzocuatroDTO.CodigoCalificativoAsignadoEjercicio;

                    cmd.Parameters.Add("@PuntajeObtenido", SqlDbType.Int);
                    cmd.Parameters["@PuntajeObtenido"].Value = evaluacionAlistEntrenamientoComzocuatroDTO.PuntajeObtenido;

                    cmd.Parameters.Add("@FechaPeriodoEvaluar", SqlDbType.Date);
                    cmd.Parameters["@FechaPeriodoEvaluar"].Value = evaluacionAlistEntrenamientoComzocuatroDTO.FechaPeriodoEvaluar;

                    cmd.Parameters.Add("@FechaRealizacionEjercicio", SqlDbType.Date);
                    cmd.Parameters["@FechaRealizacionEjercicio"].Value = evaluacionAlistEntrenamientoComzocuatroDTO.FechaRealizacionEjercicio;

                    cmd.Parameters.Add("@TiempoVigencia", SqlDbType.Int);
                    cmd.Parameters["@TiempoVigencia"].Value = evaluacionAlistEntrenamientoComzocuatroDTO.TiempoVigencia;

                    cmd.Parameters.Add("@FechaCaducidadEjercicio", SqlDbType.Date);
                    cmd.Parameters["@FechaCaducidadEjercicio"].Value = evaluacionAlistEntrenamientoComzocuatroDTO.FechaCaducidadEjercicio;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = evaluacionAlistEntrenamientoComzocuatroDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = evaluacionAlistEntrenamientoComzocuatroDTO.UsuarioIngresoRegistro;

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
                catch (Exception ex)
                {
                    IND_OPERACION = ex.Message;
                }
            }
            return IND_OPERACION;
        }

        public EvaluacionAlistEntrenamientoComzocuatroDTO BuscarFormato(int Codigo)
        {
            EvaluacionAlistEntrenamientoComzocuatroDTO evaluacionAlistEntrenamientoComzocuatroDTO = new EvaluacionAlistEntrenamientoComzocuatroDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoEntrenamientoComzocuatroEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EvaluacionAlistamientoEntrenamientoId", SqlDbType.Int);
                    cmd.Parameters["@EvaluacionAlistamientoEntrenamientoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        evaluacionAlistEntrenamientoComzocuatroDTO.EvaluacionAlistamientoEntrenamientoId = Convert.ToInt32(dr["EvaluacionAlistamientoEntrenamientoId"]);
                        evaluacionAlistEntrenamientoComzocuatroDTO.CodigoUnidadNaval = dr["CodigoUnidadNaval"].ToString();
                        evaluacionAlistEntrenamientoComzocuatroDTO.CodigoNivelEntrenamiento = dr["CodigoNivelEntrenamiento"].ToString();
                        evaluacionAlistEntrenamientoComzocuatroDTO.CodigoCapacidadOperativa = dr["CodigoCapacidadOperativa"].ToString();
                        evaluacionAlistEntrenamientoComzocuatroDTO.TipoCapacidadOperativo = dr["TipoCapacidadOperativo"].ToString();
                        evaluacionAlistEntrenamientoComzocuatroDTO.CodigoEjercicioEntrenamientoAspecto = dr["CodigoEjercicioEntrenamientoAspecto"].ToString();
                        evaluacionAlistEntrenamientoComzocuatroDTO.DescEjercicioEntrenamiento = dr["DescEjercicioEntrenamiento"].ToString();
                        evaluacionAlistEntrenamientoComzocuatroDTO.AspectoEvaluacion = dr["AspectoEvaluacion"].ToString();
                        evaluacionAlistEntrenamientoComzocuatroDTO.Peso = dr["Peso"].ToString();
                        evaluacionAlistEntrenamientoComzocuatroDTO.CodigoCalificativoAsignadoEjercicio = dr["CodigoCalificativoAsignadoEjercicio"].ToString();
                        evaluacionAlistEntrenamientoComzocuatroDTO.PuntajeObtenido = Convert.ToInt32(dr["PuntajeObtenido"]);
                        evaluacionAlistEntrenamientoComzocuatroDTO.FechaPeriodoEvaluar = Convert.ToDateTime(dr["FechaPeriodoEvaluar"]).ToString("yyy-MM-dd");
                        evaluacionAlistEntrenamientoComzocuatroDTO.FechaRealizacionEjercicio = Convert.ToDateTime(dr["FechaRealizacionEjercicio"]).ToString("yyy-MM-dd");
                        evaluacionAlistEntrenamientoComzocuatroDTO.TiempoVigencia = Convert.ToInt32(dr["TiempoVigencia"]);
                        evaluacionAlistEntrenamientoComzocuatroDTO.FechaCaducidadEjercicio = Convert.ToDateTime(dr["FechaCaducidadEjercicio"]).ToString("yyy-MM-dd"); 


                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return evaluacionAlistEntrenamientoComzocuatroDTO;
        }

        public string ActualizaFormato(EvaluacionAlistEntrenamientoComzocuatroDTO evaluacionAlistEntrenamientoComzocuatroDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoEntrenamientoComzocuatroActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@EvaluacionAlistamientoEntrenamientoId", SqlDbType.Int);
                    cmd.Parameters["@EvaluacionAlistamientoEntrenamientoId"].Value = evaluacionAlistEntrenamientoComzocuatroDTO.EvaluacionAlistamientoEntrenamientoId;

                    cmd.Parameters.Add("@CodigoUnidadNaval", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoUnidadNaval"].Value = evaluacionAlistEntrenamientoComzocuatroDTO.CodigoUnidadNaval;

                    cmd.Parameters.Add("@CodigoNivelEntrenamiento", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoNivelEntrenamiento"].Value = evaluacionAlistEntrenamientoComzocuatroDTO.CodigoNivelEntrenamiento;

                    cmd.Parameters.Add("@CodigoCapacidadOperativa", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCapacidadOperativa"].Value = evaluacionAlistEntrenamientoComzocuatroDTO.CodigoCapacidadOperativa;

                    cmd.Parameters.Add("@TipoCapacidadOperativo", SqlDbType.VarChar,15);
                    cmd.Parameters["@TipoCapacidadOperativo"].Value = evaluacionAlistEntrenamientoComzocuatroDTO.TipoCapacidadOperativo;

                    cmd.Parameters.Add("@CodigoEjercicioEntrenamientoAspecto", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEjercicioEntrenamientoAspecto"].Value = evaluacionAlistEntrenamientoComzocuatroDTO.CodigoEjercicioEntrenamientoAspecto;

                    cmd.Parameters.Add("@CodigoCalificativoAsignadoEjercicio", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCalificativoAsignadoEjercicio"].Value = evaluacionAlistEntrenamientoComzocuatroDTO.CodigoCalificativoAsignadoEjercicio;

                    cmd.Parameters.Add("@PuntajeObtenido", SqlDbType.Int);
                    cmd.Parameters["@PuntajeObtenido"].Value = evaluacionAlistEntrenamientoComzocuatroDTO.PuntajeObtenido;

                    cmd.Parameters.Add("@FechaPeriodoEvaluar", SqlDbType.Date);
                    cmd.Parameters["@FechaPeriodoEvaluar"].Value = evaluacionAlistEntrenamientoComzocuatroDTO.FechaPeriodoEvaluar;

                    cmd.Parameters.Add("@FechaRealizacionEjercicio", SqlDbType.Date);
                    cmd.Parameters["@FechaRealizacionEjercicio"].Value = evaluacionAlistEntrenamientoComzocuatroDTO.FechaRealizacionEjercicio;

                    cmd.Parameters.Add("@TiempoVigencia", SqlDbType.Int);
                    cmd.Parameters["@TiempoVigencia"].Value = evaluacionAlistEntrenamientoComzocuatroDTO.TiempoVigencia;

                    cmd.Parameters.Add("@FechaCaducidadEjercicio", SqlDbType.Date);
                    cmd.Parameters["@FechaCaducidadEjercicio"].Value = evaluacionAlistEntrenamientoComzocuatroDTO.FechaCaducidadEjercicio;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = evaluacionAlistEntrenamientoComzocuatroDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(EvaluacionAlistEntrenamientoComzocuatroDTO evaluacionAlistEntrenamientoComzocuatroDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoEntrenamientoComzocuatroEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EvaluacionAlistamientoEntrenamientoId", SqlDbType.Int);
                    cmd.Parameters["@EvaluacionAlistamientoEntrenamientoId"].Value = evaluacionAlistEntrenamientoComzocuatroDTO.EvaluacionAlistamientoEntrenamientoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = evaluacionAlistEntrenamientoComzocuatroDTO.UsuarioIngresoRegistro;

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
        public string InsertarDatos(DataTable datos)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoEntrenamientoComzocuatroRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EvaluacionAlistamientoEntrenamientoComzocuatro", SqlDbType.Structured);
                    cmd.Parameters["@EvaluacionAlistamientoEntrenamientoComzocuatro"].TypeName = "Formato.EvaluacionAlistamientoEntrenamientoComzocuatro";
                    cmd.Parameters["@EvaluacionAlistamientoEntrenamientoComzocuatro"].Value = datos;

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
    }
}
