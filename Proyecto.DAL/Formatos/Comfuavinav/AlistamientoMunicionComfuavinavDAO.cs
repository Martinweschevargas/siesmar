using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comfuavinav;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comfuavinav
{
    public class AlistamientoMunicionComfuavinavDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<AlistamientoMunicionComfuavinavDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<AlistamientoMunicionComfuavinavDTO> lista = new List<AlistamientoMunicionComfuavinavDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_AlistamientoMunicionComfuavinavListar", conexion);
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
                        lista.Add(new AlistamientoMunicionComfuavinavDTO()
                        {
                            AlistamientoMunicionComfuavinavId = Convert.ToInt32(dr["AlistamientoMunicionComfuavinavId"]),
                            DescUnidadNaval = dr["DescUnidadNaval"].ToString(),
                            DescSistemaMunicion = dr["DescSistemaMunicion"].ToString(),
                            DescSubsistemaMunicion = dr["DescSubsistemaMunicion"].ToString(),
                            Equipo = dr["Equipo"].ToString(),
                            Municion = dr["Municion"].ToString(),
                            Existente = dr["Existente"].ToString(),
                            Necesaria = Convert.ToInt32(dr["Necesaria"]),
                            CoeficientePonderacion = Convert.ToInt32(dr["CoeficientePonderacion"]),
                            CargaId = Convert.ToInt32(dr["CargaId"])
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(AlistamientoMunicionComfuavinavDTO alistamientoMunicionComfuavinavDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AlistamientoMunicionComfuavinavRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoUnidadNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUnidadNaval"].Value = alistamientoMunicionComfuavinavDTO.CodigoUnidadNaval;

                    cmd.Parameters.Add("@CodigoAlistamientoMunicion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoAlistamientoMunicion"].Value = alistamientoMunicionComfuavinavDTO.CodigoAlistamientoMunicion;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = alistamientoMunicionComfuavinavDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alistamientoMunicionComfuavinavDTO.UsuarioIngresoRegistro;

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

        public AlistamientoMunicionComfuavinavDTO BuscarFormato(int Codigo)
        {
            AlistamientoMunicionComfuavinavDTO alistamientoMunicionComfuavinavDTO = new AlistamientoMunicionComfuavinavDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AlistamientoMunicionComfuavinavEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistamientoMunicionComfuavinavId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoMunicionComfuavinavId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        alistamientoMunicionComfuavinavDTO.AlistamientoMunicionComfuavinavId = Convert.ToInt32(dr["AlistamientoMunicionComfuavinavId"]);
                        alistamientoMunicionComfuavinavDTO.CodigoUnidadNaval = dr["CodigoUnidadNaval"].ToString();
                        alistamientoMunicionComfuavinavDTO.CodigoAlistamientoMunicion = dr["CodigoAlistamientoMunicion"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return alistamientoMunicionComfuavinavDTO;
        }

        public string ActualizaFormato(AlistamientoMunicionComfuavinavDTO alistamientoMunicionComfuavinavDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_AlistamientoMunicionComfuavinavActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistamientoMunicionComfuavinavId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoMunicionComfuavinavId"].Value = alistamientoMunicionComfuavinavDTO.AlistamientoMunicionComfuavinavId;

                    cmd.Parameters.Add("@CodigoUnidadNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUnidadNaval"].Value = alistamientoMunicionComfuavinavDTO.CodigoUnidadNaval;

                    cmd.Parameters.Add("@CodigoAlistamientoMunicion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoAlistamientoMunicion"].Value = alistamientoMunicionComfuavinavDTO.CodigoAlistamientoMunicion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alistamientoMunicionComfuavinavDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(AlistamientoMunicionComfuavinavDTO alistamientoMunicionComfuavinavDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AlistamientoMunicionComfuavinavEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistamientoMunicionComfuavinavId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoMunicionComfuavinavId"].Value = alistamientoMunicionComfuavinavDTO.AlistamientoMunicionComfuavinavId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alistamientoMunicionComfuavinavDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(AlistamientoMunicionComfuavinavDTO alistamientoMunicionComfuavinavDTO)
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
                    cmd.Parameters["@Formato"].Value = "AlistamientoMunicionComfuavinav";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = alistamientoMunicionComfuavinavDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alistamientoMunicionComfuavinavDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_AlistamientoMunicionComfuavinavRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistamientoMunicionComfuavinav", SqlDbType.Structured);
                    cmd.Parameters["@AlistamientoMunicionComfuavinav"].TypeName = "Formato.AlistamientoMunicionComfuavinav";
                    cmd.Parameters["@AlistamientoMunicionComfuavinav"].Value = datos;

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

