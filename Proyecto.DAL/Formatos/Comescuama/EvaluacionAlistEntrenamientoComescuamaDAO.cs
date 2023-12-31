﻿using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comescuama;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comescuama
{
    public class EvaluacionAlistEntrenamientoComescuamaDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<EvaluacionAlistEntrenamientoComescuamaDTO> ObtenerLista(int? CargaId = null)
        {
            List<EvaluacionAlistEntrenamientoComescuamaDTO> lista = new List<EvaluacionAlistEntrenamientoComescuamaDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoEntrenamientoComescuamaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new EvaluacionAlistEntrenamientoComescuamaDTO()
                        {
                            EvaluacionAlistamientoEntrenamientoId = Convert.ToInt32(dr["EvaluacionAlistamientoEntrenamientoId"]),
                            DescUnidadNaval = dr["DescUnidadNaval"].ToString(),
                            NivelEntrenamiento = dr["NivelEntrenamiento"].ToString(),
                            DescCapacidadOperativa = dr["DescCapacidadOperativa"].ToString(),
                            TipoCapacidadOperativo = dr["TipoCapacidadOperativo"].ToString(),
                            CodigoEjercicioEntrenamiento = dr["CodigoEjercicioEntrenamiento"].ToString(),
                            DescEjercicioEntrenamiento = dr["DescEjercicioEntrenamiento"].ToString(),
                            AspectoEvaluacion = dr["AspectoEvaluacion"].ToString(),
                            Peso = dr["Peso"].ToString(),
                            DescCalificativoAsignadoEjercicio = dr["DescCalificativoAsignadoEjercicio"].ToString(),
                            PuntajeObtenido = Convert.ToInt32(dr["PuntajeObtenido"]),
                            FechaPeriodoEvaluar = (dr["FechaPeriodoEvaluar"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            FechaRealizacionEjercicio = (dr["FechaRealizacionEjercicio"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            TiempoVigencia = Convert.ToInt32(dr["TiempoVigencia"]),
                            FechaCaducidadEjercicio = (dr["FechaCaducidadEjercicio"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            CargaId = Convert.ToInt32(dr["CargaId"]),

                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(EvaluacionAlistEntrenamientoComescuamaDTO evaluacionAlistEntrenamientoComescuamaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoEntrenamientoComescuamaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@CodigoUnidadNaval ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUnidadNaval "].Value = evaluacionAlistEntrenamientoComescuamaDTO.CodigoUnidadNaval;

                    cmd.Parameters.Add("@NivelEntrenamiento", SqlDbType.VarChar,1);
                    cmd.Parameters["@NivelEntrenamiento"].Value = evaluacionAlistEntrenamientoComescuamaDTO.NivelEntrenamiento;

                    cmd.Parameters.Add("@CodigoCapacidadOperativa ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCapacidadOperativa "].Value = evaluacionAlistEntrenamientoComescuamaDTO.CodigoCapacidadOperativa;

                    cmd.Parameters.Add("@TipoCapacidadOperativo", SqlDbType.VarChar,15);
                    cmd.Parameters["@TipoCapacidadOperativo"].Value = evaluacionAlistEntrenamientoComescuamaDTO.TipoCapacidadOperativo;

                    cmd.Parameters.Add("@CodigoEjercicioEntrenamiento ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEjercicioEntrenamiento "].Value = evaluacionAlistEntrenamientoComescuamaDTO.CodigoEjercicioEntrenamiento;

                    cmd.Parameters.Add("@CodigoEjercicioEntrenamientoAspecto  ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEjercicioEntrenamientoAspecto  "].Value = evaluacionAlistEntrenamientoComescuamaDTO.CodigoEjercicioEntrenamientoAspecto;

                    cmd.Parameters.Add("@PuntajeObtenido", SqlDbType.Int);
                    cmd.Parameters["@PuntajeObtenido"].Value = evaluacionAlistEntrenamientoComescuamaDTO.PuntajeObtenido;

                    cmd.Parameters.Add("@FechaPeriodoEvaluar", SqlDbType.Date);
                    cmd.Parameters["@FechaPeriodoEvaluar"].Value = evaluacionAlistEntrenamientoComescuamaDTO.FechaPeriodoEvaluar;

                    cmd.Parameters.Add("@FechaRealizacionEjercicio", SqlDbType.Date);
                    cmd.Parameters["@FechaRealizacionEjercicio"].Value = evaluacionAlistEntrenamientoComescuamaDTO.FechaRealizacionEjercicio;

                    cmd.Parameters.Add("@TiempoVigencia", SqlDbType.Int);
                    cmd.Parameters["@TiempoVigencia"].Value = evaluacionAlistEntrenamientoComescuamaDTO.TiempoVigencia;

                    cmd.Parameters.Add("@FechaCaducidadEjercicio", SqlDbType.Date);
                    cmd.Parameters["@FechaCaducidadEjercicio"].Value = evaluacionAlistEntrenamientoComescuamaDTO.FechaCaducidadEjercicio;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = evaluacionAlistEntrenamientoComescuamaDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = evaluacionAlistEntrenamientoComescuamaDTO.UsuarioIngresoRegistro;

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

        public EvaluacionAlistEntrenamientoComescuamaDTO BuscarFormato(int Codigo)
        {
            EvaluacionAlistEntrenamientoComescuamaDTO evaluacionAlistEntrenamientoComescuamaDTO = new EvaluacionAlistEntrenamientoComescuamaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoEntrenamientoComescuamaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EvaluacionAlistamientoEntrenamientoId", SqlDbType.Int);
                    cmd.Parameters["@EvaluacionAlistamientoEntrenamientoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        evaluacionAlistEntrenamientoComescuamaDTO.EvaluacionAlistamientoEntrenamientoId = Convert.ToInt32(dr["EvaluacionAlistamientoEntrenamientoId"]);
                        evaluacionAlistEntrenamientoComescuamaDTO.CodigoUnidadNaval = dr["CodigoUnidadNaval "].ToString();
                        evaluacionAlistEntrenamientoComescuamaDTO.NivelEntrenamiento = dr["NivelEntrenamiento"].ToString();
                        evaluacionAlistEntrenamientoComescuamaDTO.CodigoCapacidadOperativa = dr["CodigoCapacidadOperativa "].ToString();
                        evaluacionAlistEntrenamientoComescuamaDTO.TipoCapacidadOperativo = dr["TipoCapacidadOperativo"].ToString();
                        evaluacionAlistEntrenamientoComescuamaDTO.CodigoEjercicioEntrenamiento = dr["CodigoEjercicioEntrenamiento "].ToString();
                        evaluacionAlistEntrenamientoComescuamaDTO.DescEjercicioEntrenamiento = dr["DescEjercicioEntrenamiento"].ToString();
                        evaluacionAlistEntrenamientoComescuamaDTO.AspectoEvaluacion = dr["AspectoEvaluacion"].ToString();
                        evaluacionAlistEntrenamientoComescuamaDTO.Peso = dr["Peso"].ToString();
                        evaluacionAlistEntrenamientoComescuamaDTO.CodigoCalificativoAsignadoEjercicio = dr["CodigoCalificativoAsignadoEjercicio "].ToString();
                        evaluacionAlistEntrenamientoComescuamaDTO.PuntajeObtenido = Convert.ToInt32(dr["PuntajeObtenido"]);
                        evaluacionAlistEntrenamientoComescuamaDTO.FechaPeriodoEvaluar = Convert.ToDateTime(dr["FechaPeriodoEvaluar"]).ToString("yyy-MM-dd");
                        evaluacionAlistEntrenamientoComescuamaDTO.FechaRealizacionEjercicio = Convert.ToDateTime(dr["FechaRealizacionEjercicio"]).ToString("yyy-MM-dd");
                        evaluacionAlistEntrenamientoComescuamaDTO.TiempoVigencia = Convert.ToInt32(dr["TiempoVigencia"]);
                        evaluacionAlistEntrenamientoComescuamaDTO.FechaCaducidadEjercicio = Convert.ToDateTime(dr["FechaCaducidadEjercicio"]).ToString("yyy-MM-dd"); 


                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return evaluacionAlistEntrenamientoComescuamaDTO;
        }

        public string ActualizaFormato(EvaluacionAlistEntrenamientoComescuamaDTO evaluacionAlistEntrenamientoComescuamaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoEntrenamientoComescuamaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@EvaluacionAlistamientoEntrenamientoId", SqlDbType.Int);
                    cmd.Parameters["@EvaluacionAlistamientoEntrenamientoId"].Value = evaluacionAlistEntrenamientoComescuamaDTO.EvaluacionAlistamientoEntrenamientoId;

                    cmd.Parameters.Add("@CodigoUnidadNaval ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUnidadNaval "].Value = evaluacionAlistEntrenamientoComescuamaDTO.CodigoUnidadNaval;

                    cmd.Parameters.Add("@NivelEntrenamiento", SqlDbType.VarChar, 1);
                    cmd.Parameters["@NivelEntrenamiento"].Value = evaluacionAlistEntrenamientoComescuamaDTO.NivelEntrenamiento;

                    cmd.Parameters.Add("@CodigoCapacidadOperativa ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCapacidadOperativa "].Value = evaluacionAlistEntrenamientoComescuamaDTO.CodigoCapacidadOperativa;

                    cmd.Parameters.Add("@TipoCapacidadOperativo", SqlDbType.VarChar, 15);
                    cmd.Parameters["@TipoCapacidadOperativo"].Value = evaluacionAlistEntrenamientoComescuamaDTO.TipoCapacidadOperativo;

                    cmd.Parameters.Add("@CodigoEjercicioEntrenamiento ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEjercicioEntrenamiento "].Value = evaluacionAlistEntrenamientoComescuamaDTO.CodigoEjercicioEntrenamiento;

                    cmd.Parameters.Add("@CodigoEjercicioEntrenamientoAspecto  ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEjercicioEntrenamientoAspecto  "].Value = evaluacionAlistEntrenamientoComescuamaDTO.CodigoEjercicioEntrenamientoAspecto;

                    cmd.Parameters.Add("@PuntajeObtenido", SqlDbType.Int);
                    cmd.Parameters["@PuntajeObtenido"].Value = evaluacionAlistEntrenamientoComescuamaDTO.PuntajeObtenido;

                    cmd.Parameters.Add("@FechaPeriodoEvaluar", SqlDbType.Date);
                    cmd.Parameters["@FechaPeriodoEvaluar"].Value = evaluacionAlistEntrenamientoComescuamaDTO.FechaPeriodoEvaluar;

                    cmd.Parameters.Add("@FechaRealizacionEjercicio", SqlDbType.Date);
                    cmd.Parameters["@FechaRealizacionEjercicio"].Value = evaluacionAlistEntrenamientoComescuamaDTO.FechaRealizacionEjercicio;

                    cmd.Parameters.Add("@TiempoVigencia", SqlDbType.Int);
                    cmd.Parameters["@TiempoVigencia"].Value = evaluacionAlistEntrenamientoComescuamaDTO.TiempoVigencia;

                    cmd.Parameters.Add("@FechaCaducidadEjercicio", SqlDbType.Date);
                    cmd.Parameters["@FechaCaducidadEjercicio"].Value = evaluacionAlistEntrenamientoComescuamaDTO.FechaCaducidadEjercicio;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = evaluacionAlistEntrenamientoComescuamaDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(EvaluacionAlistEntrenamientoComescuamaDTO evaluacionAlistEntrenamientoComescuamaDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoEntrenamientoComescuamaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EvaluacionAlistamientoEntrenamientoId", SqlDbType.Int);
                    cmd.Parameters["@EvaluacionAlistamientoEntrenamientoId"].Value = evaluacionAlistEntrenamientoComescuamaDTO.EvaluacionAlistamientoEntrenamientoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = evaluacionAlistEntrenamientoComescuamaDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoEntrenamientoComescuamaRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EvaluacionAlistamientoEntrenamientoComescuama", SqlDbType.Structured);
                    cmd.Parameters["@EvaluacionAlistamientoEntrenamientoComescuama"].TypeName = "Formato.EvaluacionAlistamientoEntrenamientoComescuama";
                    cmd.Parameters["@EvaluacionAlistamientoEntrenamientoComescuama"].Value = datos;

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
