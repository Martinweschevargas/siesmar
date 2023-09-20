using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comfasub;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comfasub
{
    public class AlistamientoMunicionComfasubDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<AlistamientoMunicionComfasubDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<AlistamientoMunicionComfasubDTO> lista = new List<AlistamientoMunicionComfasubDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_AlistamientoMunicionComfasubListar", conexion);
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
                        lista.Add(new AlistamientoMunicionComfasubDTO()
                        {
                            AlistamientoMunicionComfasubId = Convert.ToInt32(dr["AlistamientoMunicionComfasubId"]),
                            DescUnidadNaval = dr["DescUnidadNaval"].ToString(),
                            DescSistemaMunicion = dr["DescSistemaMunicion"].ToString(),
                            DescSubsistemaMunicion = dr["DescSubsistemaMunicion"].ToString(),
                            Equipo = dr["Equipo"].ToString(),
                            Municion = dr["Municion"].ToString(),
                            Existente = dr["Existente"].ToString(),
                            Necesaria = dr["Necesaria"].ToString(),
                            CoeficientePonderacion = dr["CoeficientePonderacion"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"])

                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(AlistamientoMunicionComfasubDTO alistamientoMunicionComfasubDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AlistamientoMunicionComfasubRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoUnidadNaval", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoUnidadNaval"].Value = alistamientoMunicionComfasubDTO.CodigoUnidadNaval;

                    cmd.Parameters.Add("@CodigoAlistamientoMunicion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoAlistamientoMunicion"].Value = alistamientoMunicionComfasubDTO.CodigoAlistamientoMunicion;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = alistamientoMunicionComfasubDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alistamientoMunicionComfasubDTO.UsuarioIngresoRegistro;

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

        public AlistamientoMunicionComfasubDTO BuscarFormato(int Codigo)
        {
            AlistamientoMunicionComfasubDTO alistamientoMunicionComfasubDTO = new AlistamientoMunicionComfasubDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AlistamientoMunicionComfasubEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistamientoMunicionComfasubId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoMunicionComfasubId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        alistamientoMunicionComfasubDTO.AlistamientoMunicionComfasubId = Convert.ToInt32(dr["AlistamientoMunicionComfasubId"]);
                        alistamientoMunicionComfasubDTO.CodigoUnidadNaval = dr["CodigoUnidadNaval"].ToString();
                        alistamientoMunicionComfasubDTO.CodigoAlistamientoMunicion = dr["CodigoAlistamientoMunicion"].ToString();

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return alistamientoMunicionComfasubDTO;
        }

        public string ActualizaFormato(AlistamientoMunicionComfasubDTO alistamientoMunicionComfasubDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_AlistamientoMunicionComfasubActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistamientoMunicionComfasubId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoMunicionComfasubId"].Value = alistamientoMunicionComfasubDTO.AlistamientoMunicionComfasubId;

                    cmd.Parameters.Add("@CodigoUnidadNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUnidadNaval"].Value = alistamientoMunicionComfasubDTO.CodigoUnidadNaval;

                    cmd.Parameters.Add("@CodigoAlistamientoMunicion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoAlistamientoMunicion"].Value = alistamientoMunicionComfasubDTO.CodigoAlistamientoMunicion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alistamientoMunicionComfasubDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(AlistamientoMunicionComfasubDTO alistamientoMunicionComfasubDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AlistamientoMunicionComfasubEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistamientoMunicionComfasubId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoMunicionComfasubId"].Value = alistamientoMunicionComfasubDTO.AlistamientoMunicionComfasubId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alistamientoMunicionComfasubDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(AlistamientoMunicionComfasubDTO alistamientoMunicionComfasubDTO)
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
                    cmd.Parameters["@Formato"].Value = "AlistamientoMunicionComfasub";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = alistamientoMunicionComfasubDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alistamientoMunicionComfasubDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_AlistamientoMunicionComfasubRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistamientoMunicionComfasub", SqlDbType.Structured);
                    cmd.Parameters["@AlistamientoMunicionComfasub"].TypeName = "Formato.AlistamientoMunicionComfasub";
                    cmd.Parameters["@AlistamientoMunicionComfasub"].Value = datos;

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
