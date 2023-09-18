using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Ipecamar;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Ipecamar
{
    public class ReporteAcademiaServMilitarDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<ReporteAcademiaServMilitarDTO> ObtenerLista(int? CargaId = null)
        {
            List<ReporteAcademiaServMilitarDTO> lista = new List<ReporteAcademiaServMilitarDTO>();

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
                        lista.Add(new ReporteAcademiaServMilitarDTO()
                        {
                            ReporteAcademiaServMilitarId = Convert.ToInt32(dr["EstudioContrainteligenciaPersonaNavalId"]),
                            FechaRegistroReporteAcad = (dr["FechaRegistroReporteAcad"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            DescDependencia = dr["NombreDependencia"].ToString(),
                            DescComandanciaDependencia = dr["DescComandanciaDependencia"].ToString(),
                            DescZonaNaval = dr["DescZonaNaval"].ToString(),
                            DescTemasAcademicos = dr["DescTemasAcademicos"].ToString(),
                            EfectivoActualPerMarReporteAcad = Convert.ToInt32(dr["EfectivoActualPerMarReporteAcad"]),
                            ParticipantesReporteAcad = Convert.ToInt32(dr["ParticipantesReporteAcad"]),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(ReporteAcademiaServMilitarDTO reporteAcademiaServMilitarDTO)
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

                    cmd.Parameters.Add("@FechaRegistroReporteAcad", SqlDbType.Date);
                    cmd.Parameters["@FechaRegistroReporteAcad"].Value = reporteAcademiaServMilitarDTO.FechaRegistroReporteAcad;

                    cmd.Parameters.Add("@CodigoDependencia", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoDependencia"].Value = reporteAcademiaServMilitarDTO.CodigoDependencia;

                    cmd.Parameters.Add("@CodigoComandanciaDependencia", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoComandanciaDependencia"].Value = reporteAcademiaServMilitarDTO.CodigoComandanciaDependencia;

                    cmd.Parameters.Add("@CodigoZonaNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoZonaNaval"].Value = reporteAcademiaServMilitarDTO.CodigoZonaNaval;

                    cmd.Parameters.Add("@CodigoTemasAcademicos", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTemasAcademicos"].Value = reporteAcademiaServMilitarDTO.CodigoTemasAcademicos;

                    cmd.Parameters.Add("@EfectivoActualPerMarReporteAcad", SqlDbType.Int);
                    cmd.Parameters["@EfectivoActualPerMarReporteAcad"].Value = reporteAcademiaServMilitarDTO.EfectivoActualPerMarReporteAcad;

                    cmd.Parameters.Add("@ParticipantesReporteAcad", SqlDbType.Int);
                    cmd.Parameters["@ParticipantesReporteAcad"].Value = reporteAcademiaServMilitarDTO.ParticipantesReporteAcad;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = reporteAcademiaServMilitarDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = reporteAcademiaServMilitarDTO.UsuarioIngresoRegistro;

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

        public ReporteAcademiaServMilitarDTO BuscarFormato(int Codigo)
        {
            ReporteAcademiaServMilitarDTO reporteAcademiaServMilitarDTO = new ReporteAcademiaServMilitarDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ReporteAcademiaServMilitarEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ReporteAcademiaServMilitarId", SqlDbType.Int);
                    cmd.Parameters["@ReporteAcademiaServMilitarId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        reporteAcademiaServMilitarDTO.ReporteAcademiaServMilitarId = Convert.ToInt32(dr["ReporteAcademiaServMilitarId"]);
                        reporteAcademiaServMilitarDTO.FechaRegistroReporteAcad = Convert.ToDateTime(dr["FechaRegistroReporteAcad"]).ToString("yyy-MM-dd");
                        reporteAcademiaServMilitarDTO.CodigoDependencia = dr["CodigoDependencia"].ToString();
                        reporteAcademiaServMilitarDTO.CodigoComandanciaDependencia = dr["CodigoComandanciaDependencia"].ToString();
                        reporteAcademiaServMilitarDTO.CodigoZonaNaval = dr["CodigoZonaNaval"].ToString();
                        reporteAcademiaServMilitarDTO.CodigoTemasAcademicos = dr["CodigoTemasAcademicos"].ToString();
                        reporteAcademiaServMilitarDTO.EfectivoActualPerMarReporteAcad = Convert.ToInt32(dr["EfectivoActualPerMarReporteAcad"]);
                        reporteAcademiaServMilitarDTO.ParticipantesReporteAcad = Convert.ToInt32(dr["ParticipantesReporteAcad"]);
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return reporteAcademiaServMilitarDTO;
        }

        public string ActualizaFormato(ReporteAcademiaServMilitarDTO reporteAcademiaServMilitarDTO)
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

                    cmd.Parameters.Add("@ReporteAcademiaServMilitarId", SqlDbType.Int);
                    cmd.Parameters["@ReporteAcademiaServMilitarId"].Value = reporteAcademiaServMilitarDTO.ReporteAcademiaServMilitarId;

                    cmd.Parameters.Add("@FechaRegistroReporteAcad", SqlDbType.Date);
                    cmd.Parameters["@FechaRegistroReporteAcad"].Value = reporteAcademiaServMilitarDTO.FechaRegistroReporteAcad;

                    cmd.Parameters.Add("@CodigoDependencia", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDependencia"].Value = reporteAcademiaServMilitarDTO.CodigoDependencia;

                    cmd.Parameters.Add("@CodigoComandanciaDependencia", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoComandanciaDependencia"].Value = reporteAcademiaServMilitarDTO.CodigoComandanciaDependencia;

                    cmd.Parameters.Add("@CodigoZonaNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoZonaNaval"].Value = reporteAcademiaServMilitarDTO.CodigoZonaNaval;

                    cmd.Parameters.Add("@CodigoTemasAcademicos", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTemasAcademicos"].Value = reporteAcademiaServMilitarDTO.CodigoTemasAcademicos;

                    cmd.Parameters.Add("@EfectivoActualPerMarReporteAcad", SqlDbType.Int);
                    cmd.Parameters["@EfectivoActualPerMarReporteAcad"].Value = reporteAcademiaServMilitarDTO.EfectivoActualPerMarReporteAcad;

                    cmd.Parameters.Add("@ParticipantesReporteAcad", SqlDbType.Int);
                    cmd.Parameters["@ParticipantesReporteAcad"].Value = reporteAcademiaServMilitarDTO.ParticipantesReporteAcad;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = reporteAcademiaServMilitarDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(ReporteAcademiaServMilitarDTO reporteAcademiaServMilitarDTO)
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

                    cmd.Parameters.Add("@ReporteAcademiaServMilitarId", SqlDbType.Int);
                    cmd.Parameters["@ReporteAcademiaServMilitarId"].Value = reporteAcademiaServMilitarDTO.ReporteAcademiaServMilitarId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = reporteAcademiaServMilitarDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_ReporteAcademiaServMilitarRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ReporteAcademiaServMilitar", SqlDbType.Structured);
                    cmd.Parameters["@ReporteAcademiaServMilitar"].TypeName = "Formato.ReporteAcademiaServMilitar";
                    cmd.Parameters["@ReporteAcademiaServMilitar"].Value = datos;

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
