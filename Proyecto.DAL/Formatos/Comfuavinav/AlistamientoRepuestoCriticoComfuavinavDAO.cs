﻿using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comfuavinav;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comfuavinav
{
    public class AlistamientoRepuestoCriticoComfuavinavDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<AlistamientoRepuestoCriticoComfuavinavDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<AlistamientoRepuestoCriticoComfuavinavDTO> lista = new List<AlistamientoRepuestoCriticoComfuavinavDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_AlistamientoRepuestoCriticoComfuavinavListar", conexion);
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
                        lista.Add(new AlistamientoRepuestoCriticoComfuavinavDTO()
                        {
                            AlistamientoRepuestoCriticoComfuavinavId = Convert.ToInt32(dr["AlistamientoRepuestoCriticoId"]),
                            DescUnidadNaval = dr["DescUnidadNaval"].ToString(),
                            DescSistemaRespuestoCritico = dr["DescSistemaRespuestoCritico"].ToString(),
                            DescSubsistemaRepuestoCritico = dr["DescSubsistemaRepuestoCritico"].ToString(),
                            Equipo = dr["Equipo"].ToString(),
                            Repuesto = dr["Repuesto"].ToString(),
                            Existente = dr["Existente"].ToString(),
                            Necesario = dr["Necesario"].ToString(),
                            CoeficientePonderacion = dr["CoeficientePonderacion"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(AlistamientoRepuestoCriticoComfuavinavDTO alistamientoRepuestoCriticoComfuavinavDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AlistamientoRepuestoCriticoComfuavinavRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoUnidadNaval", SqlDbType.Int);
                    cmd.Parameters["@CodigoUnidadNaval"].Value = alistamientoRepuestoCriticoComfuavinavDTO.CodigoUnidadNaval;

                    cmd.Parameters.Add("@CodigoAlistamientoRepuestoCritico", SqlDbType.Int);
                    cmd.Parameters["@CodigoAlistamientoRepuestoCritico"].Value = alistamientoRepuestoCriticoComfuavinavDTO.CodigoAlistamientoRepuestoCritico;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alistamientoRepuestoCriticoComfuavinavDTO.UsuarioIngresoRegistro;

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
#pragma warning disable CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
                            IND_OPERACION = dr["IND_OPERACION"].ToString();
#pragma warning restore CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
                        }
                    }
                }
                catch (Exception ex)
                {
                    IND_OPERACION = ex.Message;
                }
            }
#pragma warning disable CS8603 // Posible tipo de valor devuelto de referencia nulo
            return IND_OPERACION;
#pragma warning restore CS8603 // Posible tipo de valor devuelto de referencia nulo
        }

        public AlistamientoRepuestoCriticoComfuavinavDTO BuscarFormato(int Codigo)
        {
            AlistamientoRepuestoCriticoComfuavinavDTO alistamientoRepuestoCriticoComfuavinavDTO = new AlistamientoRepuestoCriticoComfuavinavDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AlistamientoRepuestoCriticoComfuavinavEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistamientoRepuestoCriticoId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoRepuestoCriticoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        alistamientoRepuestoCriticoComfuavinavDTO.AlistamientoRepuestoCriticoComfuavinavId = Convert.ToInt32(dr["AlistamientoRepuestoCriticoId"]);
                        alistamientoRepuestoCriticoComfuavinavDTO.CodigoUnidadNaval = dr["CodigoUnidadNaval"].ToString();
                        alistamientoRepuestoCriticoComfuavinavDTO.CodigoAlistamientoRepuestoCritico = dr["CodigoAlistamientoRepuestoCritico"].ToString();
                        alistamientoRepuestoCriticoComfuavinavDTO.DescSistemaRespuestoCritico = dr["DescSistemaRespuestoCritico"].ToString();
                        alistamientoRepuestoCriticoComfuavinavDTO.DescSubsistemaRepuestoCritico = dr["DescSubsistemaRepuestoCritico"].ToString();
                        alistamientoRepuestoCriticoComfuavinavDTO.Equipo = dr["Equipo"].ToString();
                        alistamientoRepuestoCriticoComfuavinavDTO.Repuesto = dr["Repuesto"].ToString();
                        alistamientoRepuestoCriticoComfuavinavDTO.Existente = dr["Existente"].ToString();
                        alistamientoRepuestoCriticoComfuavinavDTO.Necesario = dr["Necesario"].ToString();
                        alistamientoRepuestoCriticoComfuavinavDTO.CoeficientePonderacion = dr["CoeficientePonderacion"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return alistamientoRepuestoCriticoComfuavinavDTO;
        }

        public string ActualizaFormato(AlistamientoRepuestoCriticoComfuavinavDTO alistamientoRepuestoCriticoComfuavinavDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_AlistamientoRepuestoCriticoComfuavinavActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@AlistamientoRepuestoCriticoId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoRepuestoCriticoId"].Value = alistamientoRepuestoCriticoComfuavinavDTO.AlistamientoRepuestoCriticoComfuavinavId;

                    cmd.Parameters.Add("@CodigoUnidadNaval", SqlDbType.Int);
                    cmd.Parameters["@CodigoUnidadNaval"].Value = alistamientoRepuestoCriticoComfuavinavDTO.CodigoUnidadNaval;

                    cmd.Parameters.Add("@CodigoAlistamientoRepuestoCritico", SqlDbType.Int);
                    cmd.Parameters["@CodigoAlistamientoRepuestoCritico"].Value = alistamientoRepuestoCriticoComfuavinavDTO.CodigoAlistamientoRepuestoCritico;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alistamientoRepuestoCriticoComfuavinavDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(AlistamientoRepuestoCriticoComfuavinavDTO alistamientoRepuestoCriticoComfuavinavDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AlistamientoRepuestoCriticoComfuavinavEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistamientoRepuestoCriticoId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoRepuestoCriticoId"].Value = alistamientoRepuestoCriticoComfuavinavDTO.AlistamientoRepuestoCriticoComfuavinavId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alistamientoRepuestoCriticoComfuavinavDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(AlistamientoRepuestoCriticoComfuavinavDTO alistamientoRepuestoCriticoComfuavinavDTO)
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
                    cmd.Parameters["@Formato"].Value = "AlistamientoRepuestoCriticoComfuavinav";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = alistamientoRepuestoCriticoComfuavinavDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alistamientoRepuestoCriticoComfuavinavDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_AlistamientoRepuestoCriticoComfuavinavRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistamientoRepuestoCriticoComfuavinav", SqlDbType.Structured);
                    cmd.Parameters["@AlistamientoRepuestoCriticoComfuavinav"].TypeName = "Formato.AlistamientoRepuestoCriticoComfuavinav";
                    cmd.Parameters["@AlistamientoRepuestoCriticoComfuavinav"].Value = datos;

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
