using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comfasub;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comfasub
{
    public class AlistamientoCombustibleLubricanteComfasubDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<AlistamientoCombustibleLubricanteComfasubDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<AlistamientoCombustibleLubricanteComfasubDTO> lista = new List<AlistamientoCombustibleLubricanteComfasubDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_AlistamientoCombustibleLubricanteComfasubListar", conexion);
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
                        lista.Add(new AlistamientoCombustibleLubricanteComfasubDTO()
                        {
                            AlistamientoCombustibleLubricanteComfasubId = Convert.ToInt32(dr["AlistamientoCombustibleLubricanteComfasubId"]),
                            DescUnidadNaval = dr["DescUnidadNaval"].ToString(),
                            CodigoAlistamientoCombustibleLubricante = dr["CodigoAlistamientoCombustibleLubricante"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"])
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(AlistamientoCombustibleLubricanteComfasubDTO alistamientoCombustibleLubricanteComfasubDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AlistamientoCombustibleLubricanteComfasubRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoUnidadNaval", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoUnidadNaval"].Value = alistamientoCombustibleLubricanteComfasubDTO.CodigoUnidadNaval;

                    cmd.Parameters.Add("@CodigoAlistamientoCombustibleLubricante", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoAlistamientoCombustibleLubricante"].Value = alistamientoCombustibleLubricanteComfasubDTO.CodigoAlistamientoCombustibleLubricante;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = alistamientoCombustibleLubricanteComfasubDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alistamientoCombustibleLubricanteComfasubDTO.UsuarioIngresoRegistro;

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

        public AlistamientoCombustibleLubricanteComfasubDTO BuscarFormato(int Codigo)
        {
            AlistamientoCombustibleLubricanteComfasubDTO alistamientoCombustibleLubricanteComfasubDTO = new AlistamientoCombustibleLubricanteComfasubDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AlistamientoCombustibleLubricanteComfasubEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistamientoCombustibleLubricanteComfasubId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoCombustibleLubricanteComfasubId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        alistamientoCombustibleLubricanteComfasubDTO.AlistamientoCombustibleLubricanteComfasubId = Convert.ToInt32(dr["AlistamientoCombustibleLubricanteComfasubId"]);
                        alistamientoCombustibleLubricanteComfasubDTO.CodigoUnidadNaval = dr["CodigoUnidadNaval"].ToString();
                        alistamientoCombustibleLubricanteComfasubDTO.CodigoAlistamientoCombustibleLubricante = dr["CodigoAlistamientoCombustibleLubricante"].ToString();

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return alistamientoCombustibleLubricanteComfasubDTO;
        }

        public string ActualizaFormato(AlistamientoCombustibleLubricanteComfasubDTO alistamientoCombustibleLubricanteComfasubDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_AlistamientoCombustibleLubricanteComfasubActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@AlistamientoCombustibleLubricanteComfasubId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoCombustibleLubricanteComfasubId"].Value = alistamientoCombustibleLubricanteComfasubDTO.AlistamientoCombustibleLubricanteComfasubId;

                    cmd.Parameters.Add("@CodigoUnidadNaval", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoUnidadNaval"].Value = alistamientoCombustibleLubricanteComfasubDTO.CodigoUnidadNaval;

                    cmd.Parameters.Add("@CodigoAlistamientoCombustibleLubricante", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoAlistamientoCombustibleLubricante"].Value = alistamientoCombustibleLubricanteComfasubDTO.CodigoAlistamientoCombustibleLubricante;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alistamientoCombustibleLubricanteComfasubDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(AlistamientoCombustibleLubricanteComfasubDTO alistamientoCombustibleLubricanteComfasubDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AlistamientoCombustibleLubricanteComfasubEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistamientoCombustibleLubricanteComfasubId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoCombustibleLubricanteComfasubId"].Value = alistamientoCombustibleLubricanteComfasubDTO.AlistamientoCombustibleLubricanteComfasubId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alistamientoCombustibleLubricanteComfasubDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(AlistamientoCombustibleLubricanteComfasubDTO alistamientoCombustibleLubricanteComfasubDTO)
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
                    cmd.Parameters["@Formato"].Value = "AlistamientoCombustibleLubricanteComfasub";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = alistamientoCombustibleLubricanteComfasubDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alistamientoCombustibleLubricanteComfasubDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_AlistamientoCombustibleLubricanteComfasubRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistamientoCombustibleLubricanteComfasub", SqlDbType.Structured);
                    cmd.Parameters["@AlistamientoCombustibleLubricanteComfasub"].TypeName = "Formato.AlistamientoCombustibleLubricanteComfasub";
                    cmd.Parameters["@AlistamientoCombustibleLubricanteComfasub"].Value = datos;

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
