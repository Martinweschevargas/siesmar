using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comfoe;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comfoe
{
    public class AlistamientoCombustibleLubricanteComfoeDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<AlistamientoCombustibleLubricanteComfoeDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<AlistamientoCombustibleLubricanteComfoeDTO> lista = new List<AlistamientoCombustibleLubricanteComfoeDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_AlistamientoCombustibleLubricanteComfoeListar", conexion);
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
                        lista.Add(new AlistamientoCombustibleLubricanteComfoeDTO()
                        {
                            AlistamientoCombustibleLubricanteComfoeId = Convert.ToInt32(dr["AlistamientoCombustibleLubricanteComfoeId"]),
                            DescUnidadNaval = dr["DescUnidadNaval"].ToString(),
                            CodigoAlistamientoCombustibleLubricante = dr["CodigoAlistamientoCombustibleLubricante"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"])

                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(AlistamientoCombustibleLubricanteComfoeDTO alistamientoCombustibleLubricanteComfoeDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AlistamientoCombustibleLubricanteComfoeRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoUnidadNaval", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoUnidadNaval"].Value = alistamientoCombustibleLubricanteComfoeDTO.CodigoUnidadNaval;

                    cmd.Parameters.Add("@CodigoAlistamientoCombustibleLubricante", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoAlistamientoCombustibleLubricante"].Value = alistamientoCombustibleLubricanteComfoeDTO.CodigoAlistamientoCombustibleLubricante;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = alistamientoCombustibleLubricanteComfoeDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alistamientoCombustibleLubricanteComfoeDTO.UsuarioIngresoRegistro;

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

        public AlistamientoCombustibleLubricanteComfoeDTO BuscarFormato(int Codigo)
        {
            AlistamientoCombustibleLubricanteComfoeDTO alistamientoCombustibleLubricanteComfoeDTO = new AlistamientoCombustibleLubricanteComfoeDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AlistamientoCombustibleLubricanteComfoeEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistamientoCombustibleLubricanteComfoeId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoCombustibleLubricanteComfoeId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        alistamientoCombustibleLubricanteComfoeDTO.AlistamientoCombustibleLubricanteComfoeId = Convert.ToInt32(dr["AlistamientoCombustibleLubricanteComfoeId"]);
                        alistamientoCombustibleLubricanteComfoeDTO.CodigoUnidadNaval = dr["CodigoUnidadNaval"].ToString();
                        alistamientoCombustibleLubricanteComfoeDTO.CodigoAlistamientoCombustibleLubricante = dr["CodigoAlistamientoCombustibleLubricante"].ToString();

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return alistamientoCombustibleLubricanteComfoeDTO;
        }

        public string ActualizaFormato(AlistamientoCombustibleLubricanteComfoeDTO alistamientoCombustibleLubricanteComfoeDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_AlistamientoCombustibleLubricanteComfoeActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@AlistamientoCombustibleLubricanteComfoeId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoCombustibleLubricanteComfoeId"].Value = alistamientoCombustibleLubricanteComfoeDTO.AlistamientoCombustibleLubricanteComfoeId;

                    cmd.Parameters.Add("@CodigoUnidadNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUnidadNaval"].Value = alistamientoCombustibleLubricanteComfoeDTO.CodigoUnidadNaval;

                    cmd.Parameters.Add("@CodigoAlistamientoCombustibleLubricante", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoAlistamientoCombustibleLubricante"].Value = alistamientoCombustibleLubricanteComfoeDTO.CodigoAlistamientoCombustibleLubricante;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alistamientoCombustibleLubricanteComfoeDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(AlistamientoCombustibleLubricanteComfoeDTO alistamientoCombustibleLubricanteComfoeDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AlistamientoCombustibleLubricanteComfoeEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistamientoCombustibleLubricanteComfoeId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoCombustibleLubricanteComfoeId"].Value = alistamientoCombustibleLubricanteComfoeDTO.AlistamientoCombustibleLubricanteComfoeId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alistamientoCombustibleLubricanteComfoeDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(AlistamientoCombustibleLubricanteComfoeDTO alistamientoCombustibleLubricanteComfoeDTO)
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
                    cmd.Parameters["@Formato"].Value = "AlistamientoCombustibleLubricanteComfoe";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = alistamientoCombustibleLubricanteComfoeDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alistamientoCombustibleLubricanteComfoeDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_AlistamientoCombustibleLubricanteComfoeRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistamientoCombustibleLubricanteComfoe", SqlDbType.Structured);
                    cmd.Parameters["@AlistamientoCombustibleLubricanteComfoe"].TypeName = "Formato.AlistamientoCombustibleLubricanteComfoe";
                    cmd.Parameters["@AlistamientoCombustibleLubricanteComfoe"].Value = datos;

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
