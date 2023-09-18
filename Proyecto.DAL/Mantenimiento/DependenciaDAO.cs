using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class DependenciaDAO
    {

        SqlCommand cmd = new();

        public List<DependenciaDTO> ObtenerDependencias()
        {
            List<DependenciaDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_DependenciaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new DependenciaDTO()
                        {
                            DependenciaId = Convert.ToInt32(dr["DependenciaId"]),
                            NombreDependencia = dr["NombreDependencia"].ToString(),
                            DescDependencia = dr["DescDependencia"].ToString(),
                            DescNivelDependencia = dr["DescNivelDependencia"].ToString(),
                            CodigoDependencia = dr["CodigoDependencia"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public List<DependenciaDTO> ObtenerDependenciasSegundoNivel()
        {
            List<DependenciaDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Seguridad.usp_DependenciaListarSegundoNivel", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new DependenciaDTO()
                        {
                            DependenciaId = Convert.ToInt32(dr["DependenciaId"]),
                            NombreDependencia = dr["NombreDependencia"].ToString(),
                            DescDependencia = dr["DescDependencia"].ToString(),
                            DescNivelDependencia = dr["DescNivelDependencia"].ToString(),
                            CodigoDependencia = dr["CodigoDependencia"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarDependencia(DependenciaDTO dependenciaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_DependenciaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@NombreDependencia", SqlDbType.VarChar, 80);
                    cmd.Parameters["@NombreDependencia"].Value = dependenciaDTO.NombreDependencia;

                    cmd.Parameters.Add("@DescDependencia", SqlDbType.VarChar, 80);
                    cmd.Parameters["@DescDependencia"].Value = dependenciaDTO.DescDependencia;

                    cmd.Parameters.Add("@CodigoDependencia", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDependencia"].Value = dependenciaDTO.CodigoDependencia;

                    cmd.Parameters.Add("@NivelDependenciaId", SqlDbType.Int);
                    cmd.Parameters["@NivelDependenciaId"].Value = dependenciaDTO.NivelDependenciaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = dependenciaDTO.UsuarioIngresoRegistro;

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

        public DependenciaDTO BuscarDependenciaID(int Codigo)
        {
            DependenciaDTO dependenciaDTO = new DependenciaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_DependenciaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DependenciaId", SqlDbType.Int);
                    cmd.Parameters["@DependenciaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        dependenciaDTO.DependenciaId = Convert.ToInt32(dr["DependenciaId"]);
                        dependenciaDTO.NombreDependencia = dr["NombreDependencia"].ToString();
                        dependenciaDTO.DescDependencia = dr["DescDependencia"].ToString();
                        dependenciaDTO.CodigoDependencia = dr["CodigoDependencia"].ToString();
                        dependenciaDTO.NivelDependenciaId = Convert.ToInt32(dr["NivelDependenciaId"]);
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return dependenciaDTO;
        }

        public string ActualizarDependencia(DependenciaDTO dependenciaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_DependenciaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DependenciaId", SqlDbType.Int);
                    cmd.Parameters["@DependenciaId"].Value = dependenciaDTO.DependenciaId;

                    cmd.Parameters.Add("@NombreDependencia", SqlDbType.VarChar, 50);
                    cmd.Parameters["@NombreDependencia"].Value = dependenciaDTO.NombreDependencia;

                    cmd.Parameters.Add("@DescDependencia", SqlDbType.VarChar, 10);
                    cmd.Parameters["@DescDependencia"].Value = dependenciaDTO.DescDependencia;

                    cmd.Parameters.Add("@CodigoDependencia", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDependencia"].Value = dependenciaDTO.CodigoDependencia;

                    cmd.Parameters.Add("@NivelDependenciaId", SqlDbType.Int);
                    cmd.Parameters["@NivelDependenciaId"].Value = dependenciaDTO.NivelDependenciaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = dependenciaDTO.UsuarioIngresoRegistro;

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

        public string EliminarDependencia(DependenciaDTO dependenciaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_DependenciaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DependenciaId", SqlDbType.Int);
                    cmd.Parameters["@DependenciaId"].Value = dependenciaDTO.DependenciaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = dependenciaDTO.UsuarioIngresoRegistro;

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
