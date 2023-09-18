using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Diresprom;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Diresprom
{
    public class PostulanteAsimiladoOficialServicioDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<PostulanteAsimiladoOficialServicioDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<PostulanteAsimiladoOficialServicioDTO> lista = new List<PostulanteAsimiladoOficialServicioDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_PostulanteAsimiladoOficialServicioListar", conexion);
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
                        lista.Add(new PostulanteAsimiladoOficialServicioDTO()
                        {
                            PostulanteAsimiladoOficialServicioId = Convert.ToInt32(dr["PostulanteAsimiladoOficialServicioId"]),
                            DNIPostulanteAsimilado = Convert.ToInt32(dr["DNIPostulanteAsimilado"]),
                            SexoPostulanteAsimilado = dr["SexoPostulanteAsimilado"].ToString(),
                            FechaNacimiento = (dr["FechaNacimiento"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            DistritoNacimiento = dr["DistritoNacimiento"].ToString(),
                            DescInstitucionEducativaSuperior = dr["DescInstitucionEducativaSuperior"].ToString(),
                            DescCarreraUniversitariaEspecialidad = dr["DescCarreraUniversitariaEspecialidad"].ToString(),
                            DescEspecialidadPostulacionI = dr["DescEspecialidadPostulacion"].ToString(),
                            DescZonaNaval = dr["DescZonaNaval"].ToString(),
                            SituacionIngreso = dr["SituacionIngreso"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"])
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(PostulanteAsimiladoOficialServicioDTO postulanteAsimiladoOficialServicioDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_PostulanteAsimiladoOficialServicioRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@DNIPostulanteAsimilado", SqlDbType.Int);
                    cmd.Parameters["@DNIPostulanteAsimilado"].Value = postulanteAsimiladoOficialServicioDTO.DNIPostulanteAsimilado;

                    cmd.Parameters.Add("@SexoPostulanteAsimilado", SqlDbType.VarChar,10);
                    cmd.Parameters["@SexoPostulanteAsimilado"].Value = postulanteAsimiladoOficialServicioDTO.SexoPostulanteAsimilado;

                    cmd.Parameters.Add("@FechaNacimiento", SqlDbType.Date);
                    cmd.Parameters["@FechaNacimiento"].Value = postulanteAsimiladoOficialServicioDTO.FechaNacimiento;

                    cmd.Parameters.Add("@DistritoNacimiento", SqlDbType.VarChar,20);
                    cmd.Parameters["@DistritoNacimiento"].Value = postulanteAsimiladoOficialServicioDTO.DistritoNacimiento;

                    cmd.Parameters.Add("@CodigoInstitucionEducativaSuperior", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoInstitucionEducativaSuperior"].Value = postulanteAsimiladoOficialServicioDTO.CodigoInstitucionEducativaSuperior;

                    cmd.Parameters.Add("@CodigoCarreraUniversitariaEspecialidad", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCarreraUniversitariaEspecialidad"].Value = postulanteAsimiladoOficialServicioDTO.CodigoCarreraUniversitariaEspecialidad;

                    cmd.Parameters.Add("@CodigoEspecialidadPostulacion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEspecialidadPostulacion"].Value = postulanteAsimiladoOficialServicioDTO.CodigoEspecialidadPostulacion;

                    cmd.Parameters.Add("@CodigoZonaNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoZonaNaval"].Value = postulanteAsimiladoOficialServicioDTO.CodigoZonaNaval;

                    cmd.Parameters.Add("@SituacionIngreso", SqlDbType.VarChar,10);
                    cmd.Parameters["@SituacionIngreso"].Value = postulanteAsimiladoOficialServicioDTO.SituacionIngreso;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = postulanteAsimiladoOficialServicioDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = postulanteAsimiladoOficialServicioDTO.UsuarioIngresoRegistro;

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

        public PostulanteAsimiladoOficialServicioDTO BuscarFormato(int Codigo)
        {
            PostulanteAsimiladoOficialServicioDTO postulanteAsimiladoOficialServicioDTO = new PostulanteAsimiladoOficialServicioDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_PostulanteAsimiladoOficialServicioEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PostulanteAsimiladoOficialServicioId", SqlDbType.Int);
                    cmd.Parameters["@PostulanteAsimiladoOficialServicioId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        postulanteAsimiladoOficialServicioDTO.PostulanteAsimiladoOficialServicioId = Convert.ToInt32(dr["PostulanteAsimiladoOficialServicioId"]);
                        postulanteAsimiladoOficialServicioDTO.DNIPostulanteAsimilado = Convert.ToInt32(dr["DNIPostulanteAsimilado"]);
                        postulanteAsimiladoOficialServicioDTO.SexoPostulanteAsimilado = dr["SexoPostulanteAsimilado"].ToString();
                        postulanteAsimiladoOficialServicioDTO.FechaNacimiento = Convert.ToDateTime(dr["FechaNacimiento"]).ToString("yyy-MM-dd");
                        postulanteAsimiladoOficialServicioDTO.DistritoNacimiento = dr["DistritoNacimiento"].ToString();
                        postulanteAsimiladoOficialServicioDTO.CodigoInstitucionEducativaSuperior = dr["CodigoInstitucionEducativaSuperior"].ToString();
                        postulanteAsimiladoOficialServicioDTO.CodigoCarreraUniversitariaEspecialidad = dr["CodigoCarreraUniversitariaEspecialidad"].ToString();
                        postulanteAsimiladoOficialServicioDTO.CodigoEspecialidadPostulacion = dr["CodigoEspecialidadPostulacion"].ToString();
                        postulanteAsimiladoOficialServicioDTO.CodigoZonaNaval = dr["CodigoZonaNaval"].ToString();
                        postulanteAsimiladoOficialServicioDTO.SituacionIngreso = dr["SituacionIngreso"].ToString(); 
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return postulanteAsimiladoOficialServicioDTO;
        }

        public string ActualizaFormato(PostulanteAsimiladoOficialServicioDTO postulanteAsimiladoOficialServicioDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_PostulanteAsimiladoOficialServicioActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@PostulanteAsimiladoOficialServicioId", SqlDbType.Int);
                    cmd.Parameters["@PostulanteAsimiladoOficialServicioId"].Value = postulanteAsimiladoOficialServicioDTO.PostulanteAsimiladoOficialServicioId;

                    cmd.Parameters.Add("@DNIPostulanteAsimilado", SqlDbType.Int);
                    cmd.Parameters["@DNIPostulanteAsimilado"].Value = postulanteAsimiladoOficialServicioDTO.DNIPostulanteAsimilado;

                    cmd.Parameters.Add("@SexoPostulanteAsimilado", SqlDbType.VarChar,10);
                    cmd.Parameters["@SexoPostulanteAsimilado"].Value = postulanteAsimiladoOficialServicioDTO.SexoPostulanteAsimilado;

                    cmd.Parameters.Add("@FechaNacimiento", SqlDbType.Date);
                    cmd.Parameters["@FechaNacimiento"].Value = postulanteAsimiladoOficialServicioDTO.FechaNacimiento;

                    cmd.Parameters.Add("@DistritoNacimiento", SqlDbType.VarChar,20);
                    cmd.Parameters["@DistritoNacimiento"].Value = postulanteAsimiladoOficialServicioDTO.DistritoNacimiento;

                    cmd.Parameters.Add("@CodigoInstitucionEducativaSuperior", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoInstitucionEducativaSuperior"].Value = postulanteAsimiladoOficialServicioDTO.CodigoInstitucionEducativaSuperior;

                    cmd.Parameters.Add("@CodigoCarreraUniversitariaEspecialidad", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCarreraUniversitariaEspecialidad"].Value = postulanteAsimiladoOficialServicioDTO.CodigoCarreraUniversitariaEspecialidad;

                    cmd.Parameters.Add("@CodigoEspecialidadPostulacion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEspecialidadPostulacion"].Value = postulanteAsimiladoOficialServicioDTO.CodigoEspecialidadPostulacion;

                    cmd.Parameters.Add("@CodigoZonaNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoZonaNaval"].Value = postulanteAsimiladoOficialServicioDTO.CodigoZonaNaval;

                    cmd.Parameters.Add("@SituacionIngreso", SqlDbType.VarChar,10);
                    cmd.Parameters["@SituacionIngreso"].Value = postulanteAsimiladoOficialServicioDTO.SituacionIngreso;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = postulanteAsimiladoOficialServicioDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(PostulanteAsimiladoOficialServicioDTO postulanteAsimiladoOficialServicioDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_PostulanteAsimiladoOficialServicioEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PostulanteAsimiladoOficialServicioId", SqlDbType.Int);
                    cmd.Parameters["@PostulanteAsimiladoOficialServicioId"].Value = postulanteAsimiladoOficialServicioDTO.PostulanteAsimiladoOficialServicioId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = postulanteAsimiladoOficialServicioDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(PostulanteAsimiladoOficialServicioDTO postulanteAsimiladoOficialServicioDTO)
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
                    cmd.Parameters["@Formato"].Value = "PostulanteAsimiladoOficialServicio";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = postulanteAsimiladoOficialServicioDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = postulanteAsimiladoOficialServicioDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_PostulanteAsimiladoOficialServicioRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PostulanteAsimiladoOficialServicio", SqlDbType.Structured);
                    cmd.Parameters["@PostulanteAsimiladoOficialServicio"].TypeName = "Formato.PostulanteAsimiladoOficialServicio";
                    cmd.Parameters["@PostulanteAsimiladoOficialServicio"].Value = datos;

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
