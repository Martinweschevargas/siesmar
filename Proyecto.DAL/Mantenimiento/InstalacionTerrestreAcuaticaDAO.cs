using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class InstalacionTerrestreAcuaticaDAO
    {

        SqlCommand cmd = new();

        public List<InstalacionTerrestreAcuaticaDTO> ObtenerInstalacionTerrestreAcuaticas()
        {
            List<InstalacionTerrestreAcuaticaDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_InstalacionTerrestreAcuaticaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new InstalacionTerrestreAcuaticaDTO()
                        {
                            InstalacionTerrestreAcuaticaId = Convert.ToInt32(dr["InstalacionTerrestreAcuaticaId"]),
                            DescInstalacionTerrestreAcuatica = dr["DescInstalacionTerrestreAcuatica"].ToString(),
                            CodigoInstalacionTerrestreAcuatica = dr["CodigoInstalacionTerrestreAcuatica"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarInstalacionTerrestreAcuatica(InstalacionTerrestreAcuaticaDTO instalacionTerrestreAcuaticaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_InstalacionTerrestreAcuaticaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescInstalacionTerrestreAcuatica", SqlDbType.VarChar, 80);
                    cmd.Parameters["@DescInstalacionTerrestreAcuatica"].Value = instalacionTerrestreAcuaticaDTO.DescInstalacionTerrestreAcuatica;

                    cmd.Parameters.Add("@CodigoInstalacionTerrestreAcuatica", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoInstalacionTerrestreAcuatica"].Value = instalacionTerrestreAcuaticaDTO.CodigoInstalacionTerrestreAcuatica;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = instalacionTerrestreAcuaticaDTO.UsuarioIngresoRegistro;

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

        public InstalacionTerrestreAcuaticaDTO BuscarInstalacionTerrestreAcuaticaID(int Codigo)
        {
            InstalacionTerrestreAcuaticaDTO instalacionTerrestreAcuaticaDTO = new InstalacionTerrestreAcuaticaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_InstalacionTerrestreAcuaticaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@InstalacionTerrestreAcuaticaId", SqlDbType.Int);
                    cmd.Parameters["@InstalacionTerrestreAcuaticaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        instalacionTerrestreAcuaticaDTO.InstalacionTerrestreAcuaticaId = Convert.ToInt32(dr["InstalacionTerrestreAcuaticaId"]);
                        instalacionTerrestreAcuaticaDTO.DescInstalacionTerrestreAcuatica = dr["DescInstalacionTerrestreAcuatica"].ToString();
                        instalacionTerrestreAcuaticaDTO.CodigoInstalacionTerrestreAcuatica = dr["CodigoInstalacionTerrestreAcuatica"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return instalacionTerrestreAcuaticaDTO;
        }

        public string ActualizarInstalacionTerrestreAcuatica(InstalacionTerrestreAcuaticaDTO instalacionTerrestreAcuaticaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_InstalacionTerrestreAcuaticaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@InstalacionTerrestreAcuaticaId", SqlDbType.Int);
                    cmd.Parameters["@InstalacionTerrestreAcuaticaId"].Value = instalacionTerrestreAcuaticaDTO.InstalacionTerrestreAcuaticaId;

                    cmd.Parameters.Add("@DescInstalacionTerrestreAcuatica", SqlDbType.VarChar, 80);
                    cmd.Parameters["@DescInstalacionTerrestreAcuatica"].Value = instalacionTerrestreAcuaticaDTO.DescInstalacionTerrestreAcuatica;

                    cmd.Parameters.Add("@CodigoInstalacionTerrestreAcuatica", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoInstalacionTerrestreAcuatica"].Value = instalacionTerrestreAcuaticaDTO.CodigoInstalacionTerrestreAcuatica;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = instalacionTerrestreAcuaticaDTO.UsuarioIngresoRegistro;

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

        public string EliminarInstalacionTerrestreAcuatica(InstalacionTerrestreAcuaticaDTO instalacionTerrestreAcuaticaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_InstalacionTerrestreAcuaticaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@InstalacionTerrestreAcuaticaId", SqlDbType.Int);
                    cmd.Parameters["@InstalacionTerrestreAcuaticaId"].Value = instalacionTerrestreAcuaticaDTO.InstalacionTerrestreAcuaticaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = instalacionTerrestreAcuaticaDTO.UsuarioIngresoRegistro;

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
