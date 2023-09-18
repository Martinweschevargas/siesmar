using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class GradoEstudioAlcanzadoDAO
    {

        SqlCommand cmd = new();

        public List<GradoEstudioAlcanzadoDTO> ObtenerGradoEstudioAlcanzados()
        {
            List<GradoEstudioAlcanzadoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_GradoEstudioAlcanzadoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new GradoEstudioAlcanzadoDTO()
                        {
                            GradoEstudioAlcanzadoId = Convert.ToInt32(dr["GradoEstudioAlcanzadoId"]),
                            DescGradoEstudioAlcanzado = dr["DescGradoEstudioAlcanzado"].ToString(),
                            CodigoGradoEstudioAlcanzado = dr["CodigoGradoEstudioAlcanzado"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarGradoEstudioAlcanzado(GradoEstudioAlcanzadoDTO gradoEstudioAlcanzadoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_GradoEstudioAlcanzadoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescGradoEstudioAlcanzado", SqlDbType.VarChar, 80);
                    cmd.Parameters["@DescGradoEstudioAlcanzado"].Value = gradoEstudioAlcanzadoDTO.DescGradoEstudioAlcanzado;

                    cmd.Parameters.Add("@CodigoGradoEstudioAlcanzado", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoGradoEstudioAlcanzado"].Value = gradoEstudioAlcanzadoDTO.CodigoGradoEstudioAlcanzado;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = gradoEstudioAlcanzadoDTO.UsuarioIngresoRegistro;

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

        public GradoEstudioAlcanzadoDTO BuscarGradoEstudioAlcanzadoID(int Codigo)
        {
            GradoEstudioAlcanzadoDTO gradoEstudioAlcanzadoDTO = new GradoEstudioAlcanzadoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_GradoEstudioAlcanzadoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@GradoEstudioAlcanzadoId", SqlDbType.Int);
                    cmd.Parameters["@GradoEstudioAlcanzadoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        gradoEstudioAlcanzadoDTO.GradoEstudioAlcanzadoId = Convert.ToInt32(dr["GradoEstudioAlcanzadoId"]);
                        gradoEstudioAlcanzadoDTO.DescGradoEstudioAlcanzado = dr["DescGradoEstudioAlcanzado"].ToString();
                        gradoEstudioAlcanzadoDTO.CodigoGradoEstudioAlcanzado = dr["CodigoGradoEstudioAlcanzado"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return gradoEstudioAlcanzadoDTO;
        }

        public string ActualizarGradoEstudioAlcanzado(GradoEstudioAlcanzadoDTO gradoEstudioAlcanzadoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_GradoEstudioAlcanzadoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@GradoEstudioAlcanzadoId", SqlDbType.Int);
                    cmd.Parameters["@GradoEstudioAlcanzadoId"].Value = gradoEstudioAlcanzadoDTO.GradoEstudioAlcanzadoId;

                    cmd.Parameters.Add("@DescGradoEstudioAlcanzado", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescGradoEstudioAlcanzado"].Value = gradoEstudioAlcanzadoDTO.DescGradoEstudioAlcanzado;

                    cmd.Parameters.Add("@CodigoGradoEstudioAlcanzado", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoGradoEstudioAlcanzado"].Value = gradoEstudioAlcanzadoDTO.CodigoGradoEstudioAlcanzado;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = gradoEstudioAlcanzadoDTO.UsuarioIngresoRegistro;

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

        public string EliminarGradoEstudioAlcanzado(GradoEstudioAlcanzadoDTO gradoEstudioAlcanzadoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_GradoEstudioAlcanzadoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@GradoEstudioAlcanzadoId", SqlDbType.Int);
                    cmd.Parameters["@GradoEstudioAlcanzadoId"].Value = gradoEstudioAlcanzadoDTO.GradoEstudioAlcanzadoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = gradoEstudioAlcanzadoDTO.UsuarioIngresoRegistro;

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
