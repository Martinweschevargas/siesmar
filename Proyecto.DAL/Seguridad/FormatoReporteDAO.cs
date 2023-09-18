using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Marina.Siesmar.AccesoDatos.Seguridad
{
    public class FormatoReporteDAO
    {
        SqlCommand cmd = new SqlCommand();

        public List<FormatoReporteDTO> ObtenerFormatoReportes()
        {
            List<FormatoReporteDTO> lista = new List<FormatoReporteDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Seguridad.usp_FormatoReportesListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {

                        lista.Add(new FormatoReporteDTO()
                        {
                            FormatoReporteId = Convert.ToInt32(dr["FormatoReporteId"]),
                            ControladorFormatoReporte = dr["ControladorFormatoReporte"].ToString(),
                            NombreFormatoReporte = dr["NombreFormatoReporte"].ToString(),
                            PeriodoId = Convert.ToInt32(dr["PeriodoId"]),
                            DescDependencia = dr["DescDependencia"].ToString(),
                            DescDependenciaSubordinada = dr["DescDependenciaSubordinada"].ToString(),
                            Periodo = dr["NombrePeriodo"].ToString(),
                            Activo = Convert.ToChar(dr["Activo"]),
                            Flag = dr["Flag"].ToString(),
                            DependenciaId = dr["DependenciaId"].ToString(),
                            DependenciaSubordinadaId = dr["DependenciaSubordinadoId"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarFormatoReporte(FormatoReporteDTO formatoReporteDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Seguridad.usp_FormatoReportesRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 500);
                    cmd.Parameters["@Nombre"].Value = formatoReporteDTO.NombreFormatoReporte;

                    cmd.Parameters.Add("@Controlador", SqlDbType.VarChar, 500);
                    cmd.Parameters["@Controlador"].Value = formatoReporteDTO.ControladorFormatoReporte;

                    cmd.Parameters.Add("@PeriodoId", SqlDbType.Int);
                    cmd.Parameters["@PeriodoId"].Value = formatoReporteDTO.PeriodoId;

                    cmd.Parameters.Add("@Flag", SqlDbType.Char, 1);
                    cmd.Parameters["@Flag"].Value = formatoReporteDTO.Flag;

                    cmd.Parameters.Add("@Dependencia", SqlDbType.Int);
                    cmd.Parameters["@Dependencia"].Value = formatoReporteDTO.DependenciaId;

                    cmd.Parameters.Add("@DependenciaSubordinada", SqlDbType.Int);
                    cmd.Parameters["@DependenciaSubordinada"].Value = formatoReporteDTO.DependenciaSubordinadaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = formatoReporteDTO.UsuarioIngresoRegistro;

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

        public FormatoReporteDTO BuscarFormatoReporteID(int FormatoReporteId)
        {
            FormatoReporteDTO FormatoReporteDTO = new FormatoReporteDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Seguridad.usp_FormatoReportesEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter pIDFormatoReporte = new SqlParameter();
                    pIDFormatoReporte.ParameterName = "@FormatoReportesId";
                    pIDFormatoReporte.SqlDbType = SqlDbType.Int;
                    pIDFormatoReporte.Value = FormatoReporteId;

                    cmd.Parameters.Add(pIDFormatoReporte);

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        FormatoReporteDTO.FormatoReporteId = Convert.ToInt32(dr["FormatoReporteId"]);
                        FormatoReporteDTO.NombreFormatoReporte = dr["NombreFormatoReporte"].ToString();
                        FormatoReporteDTO.ControladorFormatoReporte = dr["ControladorFormatoReporte"].ToString();
                        FormatoReporteDTO.PeriodoId = Convert.ToInt32(dr["PeriodoId"]);
                        FormatoReporteDTO.DependenciaId = dr["DependenciaId"].ToString();
                        FormatoReporteDTO.DependenciaSubordinadaId = dr["SubordinadoDependenciaId"].ToString();
                        //FormatoReporteDTO.Activo = Convert.ToChar(dr["Activo"]);
                        FormatoReporteDTO.Flag = dr["Flag"].ToString();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return FormatoReporteDTO;
        }

        public string ActualizarFormatoReporte(FormatoReporteDTO formatoReporteDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Seguridad.usp_FormatoReportesActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FormatoReporteId", SqlDbType.Int);
                    cmd.Parameters["@FormatoReporteId"].Value = formatoReporteDTO.FormatoReporteId;

                    cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 500);
                    cmd.Parameters["@Nombre"].Value = formatoReporteDTO.NombreFormatoReporte;

                    cmd.Parameters.Add("@Controlador", SqlDbType.VarChar, 500);
                    cmd.Parameters["@Controlador"].Value = formatoReporteDTO.ControladorFormatoReporte;

                    cmd.Parameters.Add("@PeriodoId", SqlDbType.Int);
                    cmd.Parameters["@PeriodoId"].Value = formatoReporteDTO.PeriodoId;

                    cmd.Parameters.Add("@Flag", SqlDbType.Char, 1);
                    cmd.Parameters["@Flag"].Value = formatoReporteDTO.Flag;

                    cmd.Parameters.Add("@Dependencia", SqlDbType.Int);
                    cmd.Parameters["@Dependencia"].Value = formatoReporteDTO.DependenciaId;

                    cmd.Parameters.Add("@DependenciaSubordinada", SqlDbType.Int);
                    cmd.Parameters["@DependenciaSubordinada"].Value = formatoReporteDTO.DependenciaSubordinadaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = formatoReporteDTO.UsuarioIngresoRegistro;

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

        public string EliminarFormatoReporte(FormatoReporteDTO formatoReporteDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Seguridad.usp_FormatoReportesEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FormatoReporteId", SqlDbType.Int);
                    cmd.Parameters["@FormatoReporteId"].Value = formatoReporteDTO.FormatoReporteId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = formatoReporteDTO.UsuarioIngresoRegistro;

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
    }

}
