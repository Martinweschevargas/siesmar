using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class UnidadComescuamaDAO
    {
        SqlCommand cmd = new();

        public List<UnidadComescuamaDTO> ObtenerUnidadComescuamas()
        {
            List<UnidadComescuamaDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_UnidadComescuamaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new UnidadComescuamaDTO()
                        {
                            UnidadComescuamaId = Convert.ToInt32(dr["UnidadComescuamaId"]),
                            CodigoUnidadComescuama = dr["CodigoUnidadComescuama"].ToString(),
                            DescUnidadComescuama = dr["DescUnidadComescuama"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarUnidadComescuama(UnidadComescuamaDTO unidadComescuamaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_UnidadComescuamaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoUnidadComescuama", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUnidadComescuama"].Value = unidadComescuamaDTO.CodigoUnidadComescuama;

                    cmd.Parameters.Add("@DescUnidadComescuama", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescUnidadComescuama"].Value = unidadComescuamaDTO.DescUnidadComescuama;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = unidadComescuamaDTO.UsuarioIngresoRegistro;

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

        public UnidadComescuamaDTO BuscarUnidadComescuama(int Codigo)
        {
            UnidadComescuamaDTO unidadComescuamaDTO = new UnidadComescuamaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_UnidadComescuamaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UnidadComescuamaId", SqlDbType.Int);
                    cmd.Parameters["@UnidadComescuamaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        unidadComescuamaDTO.UnidadComescuamaId = Convert.ToInt32(dr["UnidadComescuamaId"]);
                        unidadComescuamaDTO.DescUnidadComescuama = dr["DescUnidadComescuama"].ToString();
                        unidadComescuamaDTO.CodigoUnidadComescuama = dr["CodigoUnidadComescuama"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return unidadComescuamaDTO;
        }

        public string ActualizarUnidadComescuama(UnidadComescuamaDTO unidadComescuamaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_UnidadComescuamaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UnidadComescuamaId", SqlDbType.Int);
                    cmd.Parameters["@UnidadComescuamaId"].Value = unidadComescuamaDTO.UnidadComescuamaId;

                    cmd.Parameters.Add("@CodigoUnidadComescuama", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUnidadComescuama"].Value = unidadComescuamaDTO.CodigoUnidadComescuama;

                    cmd.Parameters.Add("@DescUnidadComescuama", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescUnidadComescuama"].Value = unidadComescuamaDTO.DescUnidadComescuama;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = unidadComescuamaDTO.UsuarioIngresoRegistro;

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

        public string EliminarUnidadComescuama(UnidadComescuamaDTO unidadComescuamaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_UnidadComescuamaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UnidadComescuamaId", SqlDbType.Int);
                    cmd.Parameters["@UnidadComescuamaId"].Value = unidadComescuamaDTO.UnidadComescuamaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = unidadComescuamaDTO.UsuarioIngresoRegistro;

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


