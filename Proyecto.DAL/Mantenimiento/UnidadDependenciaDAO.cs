using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class UnidadDependenciaDAO
    {

        SqlCommand cmd = new();

        public List<UnidadDependenciaDTO> ObtenerUnidadDependencias()
        {
            List<UnidadDependenciaDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_UnidadDependenciaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new UnidadDependenciaDTO()
                        {
                            UnidadDependenciaId = Convert.ToInt32(dr["UnidadDependenciaId"]),
                            DescUnidadDependencia = dr["DescUnidadDependencia"].ToString(),
                            CodigoUnidadDependencia = dr["CodigoUnidadDependencia"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarUnidadDependencia(UnidadDependenciaDTO unidadDependenciaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_UnidadDependenciaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescUnidadDependencia", SqlDbType.VarChar, 80);
                    cmd.Parameters["@DescUnidadDependencia"].Value = unidadDependenciaDTO.DescUnidadDependencia;

                    cmd.Parameters.Add("@CodigoUnidadDependencia", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoUnidadDependencia"].Value = unidadDependenciaDTO.CodigoUnidadDependencia;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = unidadDependenciaDTO.UsuarioIngresoRegistro;

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

        public UnidadDependenciaDTO BuscarUnidadDependenciaID(int Codigo)
        {
            UnidadDependenciaDTO unidadDependenciaDTO = new UnidadDependenciaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_UnidadDependenciaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UnidadDependenciaId", SqlDbType.Int);
                    cmd.Parameters["@UnidadDependenciaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        unidadDependenciaDTO.UnidadDependenciaId = Convert.ToInt32(dr["UnidadDependenciaId"]);
                        unidadDependenciaDTO.DescUnidadDependencia = dr["DescUnidadDependencia"].ToString();
                        unidadDependenciaDTO.CodigoUnidadDependencia = dr["CodigoUnidadDependencia"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return unidadDependenciaDTO;
        }

        public string ActualizarUnidadDependencia(UnidadDependenciaDTO unidadDependenciaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_UnidadDependenciaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UnidadDependenciaId", SqlDbType.Int);
                    cmd.Parameters["@UnidadDependenciaId"].Value = unidadDependenciaDTO.UnidadDependenciaId;

                    cmd.Parameters.Add("@DescUnidadDependencia", SqlDbType.VarChar, 80);
                    cmd.Parameters["@DescUnidadDependencia"].Value = unidadDependenciaDTO.DescUnidadDependencia;

                    cmd.Parameters.Add("@CodigoUnidadDependencia", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoUnidadDependencia"].Value = unidadDependenciaDTO.CodigoUnidadDependencia;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = unidadDependenciaDTO.UsuarioIngresoRegistro;

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

        public string EliminarUnidadDependencia(UnidadDependenciaDTO unidadDependenciaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_UnidadDependenciaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UnidadDependenciaId", SqlDbType.Int);
                    cmd.Parameters["@UnidadDependenciaId"].Value = unidadDependenciaDTO.UnidadDependenciaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = unidadDependenciaDTO.UsuarioIngresoRegistro;

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
