using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Bienestar;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Bienestar
{
    public class DocenteInstitucioesEducativasDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<DocenteInstitucioesEducativasDTO> ObtenerLista(int? CargaId = null, string? fechaInicio = null, string? fechaFin = null)
        {
            List<DocenteInstitucioesEducativasDTO> lista = new List<DocenteInstitucioesEducativasDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_DocenteInstitucionEducativaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                cmd.Parameters.Add("@FechaInicio", SqlDbType.Date);
                cmd.Parameters["@FechaInicio"].Value = fechaInicio;

                cmd.Parameters.Add("@FechaFin", SqlDbType.Date);
                cmd.Parameters["@FechaFin"].Value = fechaFin;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new DocenteInstitucioesEducativasDTO()
                        {
                            DocenteInstitucionEducativaId = Convert.ToInt32(dr["DocenteInstitucionEducativaId"]),
                            DNIDocente = dr["DNIDocente"].ToString(),
                            SexoDocente = dr["SexoDocente"].ToString(),
                            JornadaLaboral = dr["JornadaLaboral"].ToString(),
                            DescCondicionLaboralDocente = dr["DescCondicionLaboralDocente"].ToString(),
                            DescDocenteCategoria = dr["DescDocenteCategoria"].ToString(),
                            DescGradoEstudioAlcanzado = dr["DescGradoEstudioAlcanzado"].ToString(),
                            DescInstitucionEducativa = dr["DescInstitucionEducativa"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"]),
                        });
                    }
                }
            }
            return lista;
        }

        public List<DocenteInstitucioesEducativasDTO> BienestarVisualizacionDocenteInstitucionEducativa(int? CargaId=null, string? fechaInicio=null, string? fechaFin=null)
        {
            List<DocenteInstitucioesEducativasDTO> lista = new List<DocenteInstitucioesEducativasDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Reporte.usp_BienestarVisualizacionDocenteInstitucionEducativa", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                cmd.Parameters.Add("@FechaInicio", SqlDbType.Date);
                cmd.Parameters["@FechaInicio"].Value = fechaInicio;

                cmd.Parameters.Add("@FechaFin", SqlDbType.Date);
                cmd.Parameters["@FechaFin"].Value = fechaFin;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new DocenteInstitucioesEducativasDTO()
                        {
                            DNIDocente = dr["DNIDocente"].ToString(),
                            SexoDocente = dr["SexoDocente"].ToString(),
                            JornadaLaboral = dr["JornadaLaboral"].ToString(),
                            DescCondicionLaboralDocente = dr["DescCondicionLaboralDocente"].ToString(),
                            DescDocenteCategoria = dr["DescDocenteCategoria"].ToString(),
                            DescGradoEstudioAlcanzado = dr["DescGradoEstudioAlcanzado"].ToString(),
                            DescInstitucionEducativa = dr["DescInstitucionEducativa"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"])
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(DocenteInstitucioesEducativasDTO docenteInstitucioesEducativasDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_DocenteInstitucionEducativaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DNIDocente", SqlDbType.VarChar, 8);
                    cmd.Parameters["@DNIDocente"].Value = docenteInstitucioesEducativasDTO.DNIDocente;

                    cmd.Parameters.Add("@SexoDocente", SqlDbType.VarChar,10);
                    cmd.Parameters["@SexoDocente"].Value = docenteInstitucioesEducativasDTO.SexoDocente;

                    cmd.Parameters.Add("@JornadaLaboral", SqlDbType.VarChar,20);
                    cmd.Parameters["@JornadaLaboral"].Value = docenteInstitucioesEducativasDTO.JornadaLaboral;

                    cmd.Parameters.Add("@CodigoCondicionLaboralDocente", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCondicionLaboralDocente"].Value = docenteInstitucioesEducativasDTO.CodigoCondicionLaboralDocente;

                    cmd.Parameters.Add("@CodigoDocenteCategoria", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDocenteCategoria"].Value = docenteInstitucioesEducativasDTO.CodigoDocenteCategoria;

                    cmd.Parameters.Add("@CodigoGradoEstudioAlcanzado", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoEstudioAlcanzado"].Value = docenteInstitucioesEducativasDTO.CodigoGradoEstudioAlcanzado;

                    cmd.Parameters.Add("@CodigoInstitucionEducativa", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoInstitucionEducativa"].Value = docenteInstitucioesEducativasDTO.CodigoInstitucionEducativa;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = docenteInstitucioesEducativasDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = docenteInstitucioesEducativasDTO.UsuarioIngresoRegistro;

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

        public DocenteInstitucioesEducativasDTO BuscarFormato(int Codigo)
        {
            DocenteInstitucioesEducativasDTO docenteInstitucioesEducativasDTO = new DocenteInstitucioesEducativasDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_DocenteInstitucionEducativaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DocenteInstitucionEducativaId", SqlDbType.Int);
                    cmd.Parameters["@DocenteInstitucionEducativaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        docenteInstitucioesEducativasDTO.DocenteInstitucionEducativaId = Convert.ToInt32(dr["DocenteInstitucionEducativaId"]);
                        docenteInstitucioesEducativasDTO.DNIDocente = dr["DNIDocente"].ToString();
                        docenteInstitucioesEducativasDTO.SexoDocente = dr["SexoDocente"].ToString();
                        docenteInstitucioesEducativasDTO.JornadaLaboral = dr["JornadaLaboral"].ToString();
                        docenteInstitucioesEducativasDTO.CodigoCondicionLaboralDocente = dr["CodigoCondicionLaboralDocente"].ToString();
                        docenteInstitucioesEducativasDTO.CodigoDocenteCategoria = dr["CodigoDocenteCategoria"].ToString();
                        docenteInstitucioesEducativasDTO.CodigoGradoEstudioAlcanzado = dr["CodigoGradoEstudioAlcanzado"].ToString();
                        docenteInstitucioesEducativasDTO.CodigoInstitucionEducativa = dr["CodigoInstitucionEducativa"].ToString();


                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return docenteInstitucioesEducativasDTO;
        }

        public string ActualizaFormato(DocenteInstitucioesEducativasDTO docenteInstitucioesEducativasDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_DocenteInstitucionEducativaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@DocenteInstitucionEducativaId", SqlDbType.Int);
                    cmd.Parameters["@DocenteInstitucionEducativaId"].Value = docenteInstitucioesEducativasDTO.DocenteInstitucionEducativaId;

                    cmd.Parameters.Add("@DNIDocente", SqlDbType.VarChar, 8);
                    cmd.Parameters["@DNIDocente"].Value = docenteInstitucioesEducativasDTO.DNIDocente;

                    cmd.Parameters.Add("@SexoDocente", SqlDbType.VarChar,10);
                    cmd.Parameters["@SexoDocente"].Value = docenteInstitucioesEducativasDTO.SexoDocente;

                    cmd.Parameters.Add("@JornadaLaboral", SqlDbType.VarChar,20);
                    cmd.Parameters["@JornadaLaboral"].Value = docenteInstitucioesEducativasDTO.JornadaLaboral;

                    cmd.Parameters.Add("@CodigoCondicionLaboralDocente", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCondicionLaboralDocente"].Value = docenteInstitucioesEducativasDTO.CodigoCondicionLaboralDocente;

                    cmd.Parameters.Add("@CodigoDocenteCategoria", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDocenteCategoria"].Value = docenteInstitucioesEducativasDTO.CodigoDocenteCategoria;

                    cmd.Parameters.Add("@CodigoGradoEstudioAlcanzado", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoEstudioAlcanzado"].Value = docenteInstitucioesEducativasDTO.CodigoGradoEstudioAlcanzado;

                    cmd.Parameters.Add("@CodigoInstitucionEducativa", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoInstitucionEducativa"].Value = docenteInstitucioesEducativasDTO.CodigoInstitucionEducativa;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = docenteInstitucioesEducativasDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(DocenteInstitucioesEducativasDTO docenteInstitucioesEducativasDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_DocenteInstitucionEducativaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DocenteInstitucionEducativaId", SqlDbType.Int);
                    cmd.Parameters["@DocenteInstitucionEducativaId"].Value = docenteInstitucioesEducativasDTO.DocenteInstitucionEducativaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = docenteInstitucioesEducativasDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(DocenteInstitucioesEducativasDTO docenteInstitucioesEducativasDTO)
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
                    cmd.Parameters["@Formato"].Value = "DocenteInstitucionEducativa";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = docenteInstitucioesEducativasDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = docenteInstitucioesEducativasDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_DocenteInstitucionEducativaRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DocenteInstitucionEducativa", SqlDbType.Structured);
                    cmd.Parameters["@DocenteInstitucionEducativa"].TypeName = "Formato.DocenteInstitucionEducativa";
                    cmd.Parameters["@DocenteInstitucionEducativa"].Value = datos;

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
