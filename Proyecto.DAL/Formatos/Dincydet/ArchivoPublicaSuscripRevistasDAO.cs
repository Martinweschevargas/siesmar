using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Dincydet;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dincydet
{
    public class ArchivoPublicaSuscripRevistasDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<ArchivoPublicaSuscripRevistasDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<ArchivoPublicaSuscripRevistasDTO> lista = new List<ArchivoPublicaSuscripRevistasDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_ArchivoPublicaSuscripRevistasListar", conexion);
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
                        lista.Add(new ArchivoPublicaSuscripRevistasDTO()
                        {
                            ArchivoPublicaSuscripRevistaId = Convert.ToInt32(dr["ArchivoPublicaSuscripRevistaId"]),
                            NombreArticuloRevista = dr["NombreArticuloRevista"].ToString(),
                            TipoArticuloRevista = dr["TipoArticuloRevista"].ToString(),
                            DescAreaCT = dr["DescAreaCT"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"])

                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(ArchivoPublicaSuscripRevistasDTO archivoPublicaSuscripRevistasDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_ArchivoPublicaSuscripRevistasRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@NombreArticuloRevista", SqlDbType.VarChar,200);
                    cmd.Parameters["@NombreArticuloRevista"].Value = archivoPublicaSuscripRevistasDTO.NombreArticuloRevista;

                    cmd.Parameters.Add("@TipoArticuloRevista", SqlDbType.VarChar, 15);
                    cmd.Parameters["@TipoArticuloRevista"].Value = archivoPublicaSuscripRevistasDTO.TipoArticuloRevista;

                    cmd.Parameters.Add("@CodigoAreaCT", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoAreaCT"].Value = archivoPublicaSuscripRevistasDTO.CodigoAreaCT;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = archivoPublicaSuscripRevistasDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = archivoPublicaSuscripRevistasDTO.UsuarioIngresoRegistro;

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

        public ArchivoPublicaSuscripRevistasDTO BuscarFormato(int Codigo)
        {
            ArchivoPublicaSuscripRevistasDTO archivoPublicaSuscripRevistasDTO = new ArchivoPublicaSuscripRevistasDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ArchivoPublicaSuscripRevistasEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ArchivoPublicaSuscripRevistaId", SqlDbType.Int);
                    cmd.Parameters["@ArchivoPublicaSuscripRevistaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        archivoPublicaSuscripRevistasDTO.ArchivoPublicaSuscripRevistaId = Convert.ToInt32(dr["ArchivoPublicaSuscripRevistaId"]);
                        archivoPublicaSuscripRevistasDTO.NombreArticuloRevista = dr["NombreArticuloRevista"].ToString();
                        archivoPublicaSuscripRevistasDTO.TipoArticuloRevista = Regex.Replace(dr["TipoArticuloRevista"].ToString(), @"\s", "");
                        archivoPublicaSuscripRevistasDTO.CodigoAreaCT = dr["CodigoAreaCT"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return archivoPublicaSuscripRevistasDTO;
        }

        public string ActualizaFormato(ArchivoPublicaSuscripRevistasDTO archivoPublicaSuscripRevistasDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_ArchivoPublicaSuscripRevistasActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ArchivoPublicaSuscripRevistaId", SqlDbType.Int);
                    cmd.Parameters["@ArchivoPublicaSuscripRevistaId"].Value = archivoPublicaSuscripRevistasDTO.ArchivoPublicaSuscripRevistaId;

                    cmd.Parameters.Add("@NombreArticuloRevista", SqlDbType.VarChar, 200);
                    cmd.Parameters["@NombreArticuloRevista"].Value = archivoPublicaSuscripRevistasDTO.NombreArticuloRevista;

                    cmd.Parameters.Add("@TipoArticuloRevista", SqlDbType.VarChar, 15);
                    cmd.Parameters["@TipoArticuloRevista"].Value = archivoPublicaSuscripRevistasDTO.TipoArticuloRevista;

                    cmd.Parameters.Add("@CodigoAreaCT", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoAreaCT"].Value = archivoPublicaSuscripRevistasDTO.CodigoAreaCT;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = archivoPublicaSuscripRevistasDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(ArchivoPublicaSuscripRevistasDTO archivoPublicaSuscripRevistasDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ArchivoPublicaSuscripRevistasEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ArchivoPublicaSuscripRevistaId", SqlDbType.Int);
                    cmd.Parameters["@ArchivoPublicaSuscripRevistaId"].Value= archivoPublicaSuscripRevistasDTO.ArchivoPublicaSuscripRevistaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = archivoPublicaSuscripRevistasDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(ArchivoPublicaSuscripRevistasDTO archivoPublicaSuscripRevistasDTO)
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
                    cmd.Parameters["@Formato"].Value = "ArchivoPublicaSuscripRevista";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = archivoPublicaSuscripRevistasDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = archivoPublicaSuscripRevistasDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_ArchivoPublicaSuscripRevistasRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ArchivoPublicaSuscripRevista", SqlDbType.Structured);
                    cmd.Parameters["@ArchivoPublicaSuscripRevista"].TypeName = "Formato.ArchivoPublicaSuscripRevista";
                    cmd.Parameters["@ArchivoPublicaSuscripRevista"].Value = datos;

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
