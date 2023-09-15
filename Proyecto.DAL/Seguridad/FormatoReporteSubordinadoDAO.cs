using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Seguridad
{
    public class FormatoReporteSubordinadoDAO
    {
        SqlCommand cmd = new SqlCommand();

        public List<FormatoReporteSubordinadoDTO> ObtenerFormatoReporteSubordinados()
        {
            List<FormatoReporteSubordinadoDTO> lista = new List<FormatoReporteSubordinadoDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Seguridad.usp_FormatoReporteSubordinadosListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new FormatoReporteSubordinadoDTO()
                        {
                            FormatoReporteSubordinadoId = Convert.ToInt32(dr["FormatoReporteSubordinadoId"]),
                            FormatoReporteId = Convert.ToInt32(dr["FormatoReporteId"]),
                            DependenciaSubordinadoId = Convert.ToInt32(dr["DependenciaSubordinadoId"]),
                            NombreFormatoReporte = dr["NombreFormatoReporte"].ToString(),
                            DescDependencia = dr["DescDependencia"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public bool AgregarFormatoReporteSubordinado(FormatoReporteSubordinadoDTO FormatoReporteSubordinadoDTO)
        {
            bool respuesta = false;
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Seguridad.usp_FormatoReporteSubordinadosRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FormatoReporteId", SqlDbType.Int);
                    cmd.Parameters["@FormatoReporteId"].Value = FormatoReporteSubordinadoDTO.FormatoReporteId;

                    cmd.Parameters.Add("@DependenciaSubordinadoId", SqlDbType.Int);
                    cmd.Parameters["@DependenciaSubordinadoId"].Value = FormatoReporteSubordinadoDTO.DependenciaSubordinadoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = FormatoReporteSubordinadoDTO.UsuarioIngresoRegistro;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Mac"].Value = UtilitariosGlobales.obtenerDireccionMac();

                    cmd.ExecuteNonQuery();
                    respuesta = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return respuesta;
        }

        public FormatoReporteSubordinadoDTO BuscarFormatoReporteSubordinadoID(int FormatoReporteSubordinadoId)
        {
            FormatoReporteSubordinadoDTO FormatoReporteSubordinadoDTO = new FormatoReporteSubordinadoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Seguridad.usp_FormatoReporteSubordinadosEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter pIDFormatoReporteSubordinado = new SqlParameter();
                    pIDFormatoReporteSubordinado.ParameterName = "@FormatoReporteSubordinadoId";
                    pIDFormatoReporteSubordinado.SqlDbType = SqlDbType.Int;
                    pIDFormatoReporteSubordinado.Value = FormatoReporteSubordinadoId;

                    cmd.Parameters.Add(pIDFormatoReporteSubordinado);

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        FormatoReporteSubordinadoDTO.FormatoReporteSubordinadoId = Convert.ToInt32(dr["FormatoReporteSubordinadoId"]);
                        FormatoReporteSubordinadoDTO.FormatoReporteId = Convert.ToInt32(dr["FormatoReporteId"]);
                        FormatoReporteSubordinadoDTO.DependenciaSubordinadoId = Convert.ToInt32(dr["DependenciaSubordinadoId"]);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return FormatoReporteSubordinadoDTO;
        }

        public bool ActualizarFormatoReporteSubordinado(FormatoReporteSubordinadoDTO FormatoReporteSubordinadoDTO)
        {
            bool respuesta = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Seguridad.usp_FormatoReporteSubordinadosActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter pFormatoReporteSubordinadoId = new SqlParameter();
                    pFormatoReporteSubordinadoId.ParameterName = "@FormatoReporteSubordinadoId";
                    pFormatoReporteSubordinadoId.SqlDbType = SqlDbType.Int;
                    pFormatoReporteSubordinadoId.Value = FormatoReporteSubordinadoDTO.FormatoReporteSubordinadoId;

                    SqlParameter pFormatoReporteId = new SqlParameter();
                    pFormatoReporteId.ParameterName = "@FormatoReporteId";
                    pFormatoReporteId.SqlDbType = SqlDbType.Int;
                    pFormatoReporteId.Value = FormatoReporteSubordinadoDTO.FormatoReporteId;

                    SqlParameter pDependenciaSubordinadoId = new SqlParameter();
                    pDependenciaSubordinadoId.ParameterName = "@DependenciaSubordinadoId";
                    pDependenciaSubordinadoId.SqlDbType = SqlDbType.Int;
                    pDependenciaSubordinadoId.Value = FormatoReporteSubordinadoDTO.DependenciaSubordinadoId;

                    SqlParameter pIP = new SqlParameter();
                    pIP.ParameterName = "@Usuario";
                    pIP.SqlDbType = SqlDbType.VarChar;
                    pIP.Size = 80;
                    pIP.Value = "192.168.1.24";

                    cmd.Parameters.Add(pFormatoReporteSubordinadoId);
                    cmd.Parameters.Add(pFormatoReporteId);
                    cmd.Parameters.Add(pDependenciaSubordinadoId);
                    cmd.Parameters.Add(pIP);

                    cmd.ExecuteNonQuery();
                    respuesta = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return respuesta;
        }

        public bool EliminarFormatoReporteSubordinado(int FormatoReporteSubordinadoId)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Seguridad.usp_FormatoReporteSubordinadosEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter pFormatoReporteSubordinadoId = new SqlParameter();
                    pFormatoReporteSubordinadoId.ParameterName = "@FormatoReporteSubordinadoId";
                    pFormatoReporteSubordinadoId.SqlDbType = SqlDbType.Int;
                    pFormatoReporteSubordinadoId.Value = FormatoReporteSubordinadoId;

                    cmd.Parameters.Add(pFormatoReporteSubordinadoId);
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
    }

}
