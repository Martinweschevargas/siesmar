using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Dincydet;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata;
using System.Security.Cryptography;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dincydet
{
    public class ArchivoPersonalCTDocenteDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<ArchivoPersonalCTDocenteDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<ArchivoPersonalCTDocenteDTO> lista = new List<ArchivoPersonalCTDocenteDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_ArchivoPersonalCTDocenteListar", conexion);
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
                        lista.Add(new ArchivoPersonalCTDocenteDTO()
                        {
                            ArchivoPersonalCTDocenteId = Convert.ToInt32(dr["ArchivoPersonalCTDocenteId"]),
                            DNIPersonalCTDocente = dr["DNIPersonalCTDocente"].ToString(),
                            InstitucionEjercePersonalCTDocente = dr["InstitucionEjercePersonalCTDocente"].ToString(),
                            DescAreaCT = dr["DescAreaCT"].ToString(),
                            AniosDocenciaPersonalCTDocente = Convert.ToInt32(dr["AniosDocenciaPersonalCTDocente"]),
                            CargaId = Convert.ToInt32(dr["CargaId"]),

                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(ArchivoPersonalCTDocenteDTO archivoPersonalCTDocenteDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_ArchivoPersonalCTDocenteRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DNIPersonalCTDocente", SqlDbType.VarChar,8);
                    cmd.Parameters["@DNIPersonalCTDocente"].Value = archivoPersonalCTDocenteDTO.DNIPersonalCTDocente;

                    cmd.Parameters.Add("@InstitucionEjercePersonalCTDocente", SqlDbType.VarChar,20);
                    cmd.Parameters["@InstitucionEjercePersonalCTDocente"].Value = archivoPersonalCTDocenteDTO.CodigoInstitucionEjerce;

                    cmd.Parameters.Add("@CodigoAreaCT", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoAreaCT"].Value = archivoPersonalCTDocenteDTO.CodigoAreaCT;

                    cmd.Parameters.Add("@AniosDocenciaPersonalCTDocente", SqlDbType.Int);
                    cmd.Parameters["@AniosDocenciaPersonalCTDocente"].Value = archivoPersonalCTDocenteDTO.AniosDocenciaPersonalCTDocente;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = archivoPersonalCTDocenteDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = archivoPersonalCTDocenteDTO.UsuarioIngresoRegistro;

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

        public ArchivoPersonalCTDocenteDTO BuscarFormato(int Codigo)
        {
            ArchivoPersonalCTDocenteDTO archivoPersonalCTDocenteDTO = new ArchivoPersonalCTDocenteDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ArchivoPersonalCTDocenteEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ArchivoPersonalCTDocenteId", SqlDbType.Int);
                    cmd.Parameters["@ArchivoPersonalCTDocenteId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        archivoPersonalCTDocenteDTO.ArchivoPersonalCTDocenteId = Convert.ToInt32(dr["ArchivoPersonalCTDocenteId"]);
                        archivoPersonalCTDocenteDTO.DNIPersonalCTDocente = dr["DNIPersonalCTDocente"].ToString();
                        archivoPersonalCTDocenteDTO.CodigoInstitucionEjerce = dr["InstitucionEjercePersonalCTDocente"].ToString();
                        archivoPersonalCTDocenteDTO.CodigoAreaCT = dr["CodigoAreaCT"].ToString();
                        archivoPersonalCTDocenteDTO.AniosDocenciaPersonalCTDocente = Convert.ToInt32(dr["AniosDocenciaPersonalCTDocente"]);
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return archivoPersonalCTDocenteDTO;
        }

        public string ActualizaFormato(ArchivoPersonalCTDocenteDTO archivoPersonalCTDocenteDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_ArchivoPersonalCTDocenteActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ArchivoPersonalCTDocenteId", SqlDbType.Int);
                    cmd.Parameters["@ArchivoPersonalCTDocenteId"].Value = archivoPersonalCTDocenteDTO.ArchivoPersonalCTDocenteId;

                    cmd.Parameters.Add("@DNIPersonalCTDocente", SqlDbType.VarChar, 8);
                    cmd.Parameters["@DNIPersonalCTDocente"].Value = archivoPersonalCTDocenteDTO.DNIPersonalCTDocente;

                    cmd.Parameters.Add("@InstitucionEjercePersonalCTDocente", SqlDbType.VarChar,20);
                    cmd.Parameters["@InstitucionEjercePersonalCTDocente"].Value = archivoPersonalCTDocenteDTO.CodigoInstitucionEjerce;

                    cmd.Parameters.Add("@CodigoAreaCT", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoAreaCT"].Value = archivoPersonalCTDocenteDTO.CodigoAreaCT;

                    cmd.Parameters.Add("@AniosDocenciaPersonalCTDocente", SqlDbType.Int);
                    cmd.Parameters["@AniosDocenciaPersonalCTDocente"].Value = archivoPersonalCTDocenteDTO.AniosDocenciaPersonalCTDocente;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = archivoPersonalCTDocenteDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(ArchivoPersonalCTDocenteDTO archivoPersonalCTDocenteDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ArchivoPersonalCTDocenteEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ArchivoPersonalCTDocenteId", SqlDbType.Int);
                    cmd.Parameters["@ArchivoPersonalCTDocenteId"].Value= archivoPersonalCTDocenteDTO.ArchivoPersonalCTDocenteId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = archivoPersonalCTDocenteDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(ArchivoPersonalCTDocenteDTO archivoPersonalCTDocenteDTO)
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
                    cmd.Parameters["@Formato"].Value = "ArchivoPersonalCTDocente";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = archivoPersonalCTDocenteDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = archivoPersonalCTDocenteDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_ArchivoPersonalCTDocenteRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ArchivoPersonalCTDocente", SqlDbType.Structured);
                    cmd.Parameters["@ArchivoPersonalCTDocente"].TypeName = "Formato.ArchivoPersonalCTDocente";
                    cmd.Parameters["@ArchivoPersonalCTDocente"].Value = datos;

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
