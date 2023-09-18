using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class IndiceValoracionDAO
    {
        SqlCommand cmd = new SqlCommand();

        public List<IndiceValoracionDTO> ObtenerIndiceValoracions()
        {
            List<IndiceValoracionDTO> lista = new List<IndiceValoracionDTO>();
            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_IndiceValoracionListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new IndiceValoracionDTO()
                        {
                            IndiceValoracionId = Convert.ToInt32(dr["IndiceValoracionId"]),
                            DescIndiceValoracion = dr["DescIndiceValoracion"].ToString(),
                            Criterio = dr["Criterio"].ToString(),
                            CodigoDependencia = Convert.ToInt32(dr["CodigoDependencia"]),
                            SI = Convert.ToChar(dr["SI"]),
                            NO = Convert.ToChar(dr["NO"]),
                        });
                    }
                }
            }

            return lista;
        }

        public string AgregarIndiceValoracion(IndiceValoracionDTO indiceValoracionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_IndiceValoracionRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescIndiceValoracion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescIndiceValoracion"].Value = indiceValoracionDTO.DescIndiceValoracion;

                    cmd.Parameters.Add("@Criterio", SqlDbType.VarChar, 20);
                    cmd.Parameters["@Criterio"].Value = indiceValoracionDTO.Criterio;

                    cmd.Parameters.Add("@CodigoDependencia", SqlDbType.Int);
                    cmd.Parameters["@CodigoDependencia"].Value = indiceValoracionDTO.CodigoDependencia;

                    cmd.Parameters.Add("@SI", SqlDbType.Char, 1);
                    cmd.Parameters["@SI"].Value = indiceValoracionDTO.SI;

                    cmd.Parameters.Add("@NO", SqlDbType.Char, 1);
                    cmd.Parameters["@NO"].Value = indiceValoracionDTO.NO;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = indiceValoracionDTO.UsuarioIngresoRegistro;

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

        public IndiceValoracionDTO BuscarIndiceValoracionID(int indiceValoracionId)
        {
            IndiceValoracionDTO indiceValoracionDTO = new IndiceValoracionDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_IndiceValoracionEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@IndiceValoracionId", SqlDbType.Int);
                    cmd.Parameters["@IndiceValoracionId"].Value = indiceValoracionId;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        indiceValoracionDTO.IndiceValoracionId = Convert.ToInt32(dr["IndiceValoracionId"]);
                        indiceValoracionDTO.DescIndiceValoracion = dr["DescIndiceValoracion"].ToString();
                        indiceValoracionDTO.Criterio = dr["Criterio"].ToString();
                        indiceValoracionDTO.CodigoDependencia = Convert.ToInt32(dr["CodigoDependencia"]);
                        indiceValoracionDTO.SI = Convert.ToChar(dr["SI"]);
                        indiceValoracionDTO.NO = Convert.ToChar(dr["NO"]);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return indiceValoracionDTO;
        }

        public string ActualizarIndiceValoracion(IndiceValoracionDTO indiceValoracionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_IndiceValoracionActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@IndiceValoracionId", SqlDbType.Int);
                    cmd.Parameters["@IndiceValoracionId"].Value = indiceValoracionDTO.IndiceValoracionId;

                    cmd.Parameters.Add("@DescIndiceValoracion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescIndiceValoracion"].Value = indiceValoracionDTO.DescIndiceValoracion;

                    cmd.Parameters.Add("@Criterio", SqlDbType.VarChar, 20);
                    cmd.Parameters["@Criterio"].Value = indiceValoracionDTO.Criterio;

                    cmd.Parameters.Add("@CodigoDependencia", SqlDbType.Int);
                    cmd.Parameters["@CodigoDependencia"].Value = indiceValoracionDTO.CodigoDependencia;

                    cmd.Parameters.Add("@SI", SqlDbType.Char, 1);
                    cmd.Parameters["@SI"].Value = indiceValoracionDTO.SI;

                    cmd.Parameters.Add("@NO", SqlDbType.Char, 1);
                    cmd.Parameters["@NO"].Value = indiceValoracionDTO.NO;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = indiceValoracionDTO.UsuarioIngresoRegistro;

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

        public string EliminarIndiceValoracion(IndiceValoracionDTO indiceValoracionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_IndiceValoracionEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@IndiceValoracionId", SqlDbType.Int);
                    cmd.Parameters["@IndiceValoracionId"].Value = indiceValoracionDTO.IndiceValoracionId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = indiceValoracionDTO.UsuarioIngresoRegistro;

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
