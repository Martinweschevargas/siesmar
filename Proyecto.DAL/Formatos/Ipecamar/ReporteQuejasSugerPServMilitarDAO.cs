using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Ipecamar;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Ipecamar
{
    public class ReporteQuejasSugerPServMilitarDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<ReporteQuejasSugerPServMilitarDTO> ObtenerLista(int? CargaId = null)
        {
            List<ReporteQuejasSugerPServMilitarDTO> lista = new List<ReporteQuejasSugerPServMilitarDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_ReporteAcademiaServMilitarListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ReporteQuejasSugerPServMilitarDTO()
                        {
                            ReporteQuejaSugerPServMilitarId = Convert.ToInt32(dr["ReporteQuejaSugerPServMilitarId"]),
                            FechaRegistroQuejaSuger = (dr["FechaRegistroQuejaSuger"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            DescDependencia = dr["NombreDependencia"].ToString(),
                            DescComandanciaDependencia = dr["DescComandanciaDependencia"].ToString(),
                            DescZonaNaval = dr["DescZonaNaval"].ToString(),
                            DescTipoNovedad = dr["DescTipoNovedad"].ToString(),
                            SituacionPersonalQuejasSuger = dr["SituacionPersonalQuejasSuger"].ToString(),
                            CategoriaQuejasSuger = dr["CategoriaQuejasSuger"].ToString(),
                            AccionTomadaQuejasSuger = dr["AccionTomadaQuejasSuger"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"]),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(ReporteQuejasSugerPServMilitarDTO reporteQuejasSugerPServMilitarDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ReporteAcademiaServMilitarRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FechaRegistroQuejaSuger", SqlDbType.Date);
                    cmd.Parameters["@FechaRegistroQuejaSuger"].Value = reporteQuejasSugerPServMilitarDTO.FechaRegistroQuejaSuger;

                    cmd.Parameters.Add("@CodigoDependencia", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoDependencia"].Value = reporteQuejasSugerPServMilitarDTO.CodigoDependencia;

                    cmd.Parameters.Add("@CodigoComandanciaDependencia", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoComandanciaDependencia"].Value = reporteQuejasSugerPServMilitarDTO.CodigoComandanciaDependencia;

                    cmd.Parameters.Add("@CodigoZonaNaval", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoZonaNaval"].Value = reporteQuejasSugerPServMilitarDTO.CodigoZonaNaval;

                    cmd.Parameters.Add("@CodigoTipoNovedad", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoTipoNovedad"].Value = reporteQuejasSugerPServMilitarDTO.CodigoTipoNovedad;

                    cmd.Parameters.Add("@SituacionPersonalQuejasSuger", SqlDbType.VarChar,20);
                    cmd.Parameters["@SituacionPersonalQuejasSuger"].Value = reporteQuejasSugerPServMilitarDTO.SituacionPersonalQuejasSuger;

                    cmd.Parameters.Add("@CategoriaQuejasSuger", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CategoriaQuejasSuger"].Value = reporteQuejasSugerPServMilitarDTO.CategoriaQuejasSuger;

                    cmd.Parameters.Add("@AccionTomadaQuejasSuger", SqlDbType.VarChar, 20);
                    cmd.Parameters["@AccionTomadaQuejasSuger"].Value = reporteQuejasSugerPServMilitarDTO.AccionTomadaQuejasSuger;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = reporteQuejasSugerPServMilitarDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = reporteQuejasSugerPServMilitarDTO.UsuarioIngresoRegistro;

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

        public ReporteQuejasSugerPServMilitarDTO BuscarFormato(int Codigo)
        {
            ReporteQuejasSugerPServMilitarDTO reporteQuejasSugerPServMilitarDTO = new ReporteQuejasSugerPServMilitarDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ReporteAcademiaServMilitarEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ReporteQuejaSugerPServMilitarId", SqlDbType.Int);
                    cmd.Parameters["@ReporteQuejaSugerPServMilitarId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        reporteQuejasSugerPServMilitarDTO.ReporteQuejaSugerPServMilitarId = Convert.ToInt32(dr["ReporteQuejaSugerPServMilitarId"]);
                        reporteQuejasSugerPServMilitarDTO.FechaRegistroQuejaSuger = Convert.ToDateTime(dr["FechaRegistroQuejaSuger"]).ToString("yyy-MM-dd");
                        reporteQuejasSugerPServMilitarDTO.CodigoDependencia = dr["CodigoDependencia"].ToString();
                        reporteQuejasSugerPServMilitarDTO.CodigoComandanciaDependencia = dr["CodigoComandanciaDependencia"].ToString();
                        reporteQuejasSugerPServMilitarDTO.CodigoZonaNaval = dr["CodigoZonaNaval"].ToString();
                        reporteQuejasSugerPServMilitarDTO.CodigoTipoNovedad = dr["TemasAcademicosId"].ToString();
                        reporteQuejasSugerPServMilitarDTO.SituacionPersonalQuejasSuger = dr["SituacionPersonalQuejasSuger"].ToString();
                        reporteQuejasSugerPServMilitarDTO.CategoriaQuejasSuger = dr["CategoriaQuejasSuger"].ToString();
                        reporteQuejasSugerPServMilitarDTO.AccionTomadaQuejasSuger = dr["AccionTomadaQuejasSuger"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return reporteQuejasSugerPServMilitarDTO;
        }

        public string ActualizaFormato(ReporteQuejasSugerPServMilitarDTO reporteQuejasSugerPServMilitarDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_ReporteAcademiaServMilitarActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ReporteQuejaSugerPServMilitarId", SqlDbType.Int);
                    cmd.Parameters["@ReporteQuejaSugerPServMilitarId"].Value = reporteQuejasSugerPServMilitarDTO.ReporteQuejaSugerPServMilitarId;

                    cmd.Parameters.Add("@FechaRegistroQuejaSuger", SqlDbType.Date);
                    cmd.Parameters["@FechaRegistroQuejaSuger"].Value = reporteQuejasSugerPServMilitarDTO.FechaRegistroQuejaSuger;

                    cmd.Parameters.Add("@CodigoDependencia", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDependencia"].Value = reporteQuejasSugerPServMilitarDTO.CodigoDependencia;

                    cmd.Parameters.Add("@CodigoComandanciaDependencia", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoComandanciaDependencia"].Value = reporteQuejasSugerPServMilitarDTO.CodigoComandanciaDependencia;

                    cmd.Parameters.Add("@CodigoZonaNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoZonaNaval"].Value = reporteQuejasSugerPServMilitarDTO.CodigoZonaNaval;

                    cmd.Parameters.Add("@CodigoTipoNovedad", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoNovedad"].Value = reporteQuejasSugerPServMilitarDTO.CodigoTipoNovedad;


                    cmd.Parameters.Add("@SituacionPersonalQuejasSuger", SqlDbType.VarChar, 20);
                    cmd.Parameters["@SituacionPersonalQuejasSuger"].Value = reporteQuejasSugerPServMilitarDTO.SituacionPersonalQuejasSuger;

                    cmd.Parameters.Add("@CategoriaQuejasSuger", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CategoriaQuejasSuger"].Value = reporteQuejasSugerPServMilitarDTO.CategoriaQuejasSuger;

                    cmd.Parameters.Add("@AccionTomadaQuejasSuger", SqlDbType.VarChar, 20);
                    cmd.Parameters["@AccionTomadaQuejasSuger"].Value = reporteQuejasSugerPServMilitarDTO.AccionTomadaQuejasSuger;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = reporteQuejasSugerPServMilitarDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(ReporteQuejasSugerPServMilitarDTO reporteQuejasSugerPServMilitarDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ReporteAcademiaServMilitarEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ReporteQuejaSugerPServMilitarId", SqlDbType.Int);
                    cmd.Parameters["@ReporteQuejaSugerPServMilitarId"].Value = reporteQuejasSugerPServMilitarDTO.ReporteQuejaSugerPServMilitarId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = reporteQuejasSugerPServMilitarDTO.UsuarioIngresoRegistro;

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

        public string InsertarDatos(DataTable datos)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("Formato.usp_ReporteQuejasSugerPServMilitarRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ReporteQuejasSugerPServMilitar", SqlDbType.Structured);
                    cmd.Parameters["@ReporteQuejasSugerPServMilitar"].TypeName = "Formato.ReporteQuejasSugerPServMilitar";
                    cmd.Parameters["@ReporteQuejasSugerPServMilitar"].Value = datos;

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
