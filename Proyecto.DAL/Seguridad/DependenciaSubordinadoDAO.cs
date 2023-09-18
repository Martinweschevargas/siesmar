using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Seguridad
{
    public class DependenciaSubordinadoDAO
    {
        SqlCommand cmd = new SqlCommand();

        public List<DependenciaSubordinadoDTO> ObtenerDependenciaSubordinados()
        {
            List<DependenciaSubordinadoDTO> lista = new List<DependenciaSubordinadoDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Seguridad.usp_DependenciaSubordinadoTercerNivelListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new DependenciaSubordinadoDTO()
                        {
                            DependenciaSubordinadoId = Convert.ToInt32(dr["DependenciaSubordinadoId"]),
                            Nombre = dr["Nombre"].ToString(),
                            DependenciaId = Convert.ToInt32(dr["DependenciaId"]),
                            DescNivelDependencia = dr["DescNivelDependencia"].ToString(),
                            NombreDependencia = dr["NombreDependencia"].ToString(),
                            DescDependencia = dr["DescDependencia"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarDependenciaSubordinado(DependenciaSubordinadoDTO dependenciasubordinadoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Seguridad.usp_DependenciaSubordinadoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 80);
                    cmd.Parameters["@Nombre"].Value = dependenciasubordinadoDTO.Nombre;

                    cmd.Parameters.Add("@DependenciaId", SqlDbType.Int);
                    cmd.Parameters["@DependenciaId"].Value = dependenciasubordinadoDTO.DependenciaId;

                    cmd.Parameters.Add("@NivelDependenciaId", SqlDbType.Int);
                    cmd.Parameters["@NivelDependenciaId"].Value = dependenciasubordinadoDTO.NivelDependenciaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = dependenciasubordinadoDTO.UsuarioIngresoRegistro;

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

        public DependenciaSubordinadoDTO BuscarDependenciaSubordinadoID(int dependenciaSubordinadoId)
        {
            DependenciaSubordinadoDTO DependenciaSubordinadoDTO = new DependenciaSubordinadoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Seguridad.usp_DependenciaSubordinadoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DependenciaSubordinadoId", SqlDbType.Int);
                    cmd.Parameters["@DependenciaSubordinadoId"].Value = dependenciaSubordinadoId;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        DependenciaSubordinadoDTO.DependenciaSubordinadoId = Convert.ToInt32(dr["DependenciaSubordinadoId"]);
                        DependenciaSubordinadoDTO.Nombre = dr["Nombre"].ToString();
                        DependenciaSubordinadoDTO.NivelDependenciaId = Convert.ToInt32(dr["NivelDependenciaId"]);
                        DependenciaSubordinadoDTO.DependenciaId = Convert.ToInt32(dr["DependenciaId"]);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return DependenciaSubordinadoDTO;
        }

        public string ActualizarDependenciaSubordinado(DependenciaSubordinadoDTO dependenciaSubordinadoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Seguridad.usp_DependenciaSubordinadoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DependenciaSubordinadoId", SqlDbType.Int);
                    cmd.Parameters["@DependenciaSubordinadoId"].Value = dependenciaSubordinadoDTO.DependenciaSubordinadoId;

                    cmd.Parameters.Add("@NivelDependenciaId", SqlDbType.Int);
                    cmd.Parameters["@NivelDependenciaId"].Value = dependenciaSubordinadoDTO.NivelDependenciaId;

                    cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 80);
                    cmd.Parameters["@Nombre"].Value = dependenciaSubordinadoDTO.Nombre;

                    cmd.Parameters.Add("@DependenciaId", SqlDbType.Int);
                    cmd.Parameters["@DependenciaId"].Value = dependenciaSubordinadoDTO.DependenciaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = dependenciaSubordinadoDTO.UsuarioIngresoRegistro;

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

        public string EliminarDependenciaSubordinado(DependenciaSubordinadoDTO dependenciaSubordinadoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Seguridad.usp_DependenciaSubordinadoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DependenciaSubordinadoId", SqlDbType.Int);
                    cmd.Parameters["@DependenciaSubordinadoId"].Value = dependenciaSubordinadoDTO.DependenciaSubordinadoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = dependenciaSubordinadoDTO.UsuarioIngresoRegistro;

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
