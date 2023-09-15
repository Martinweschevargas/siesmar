using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class ClaseNaveDAO
    {

        SqlCommand cmd = new();

        public List<ClaseNaveDTO> ObtenerClaseNaves()
        {
            List<ClaseNaveDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_ClaseNaveListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ClaseNaveDTO()
                        {
                            ClaseNaveId = Convert.ToInt32(dr["ClaseNaveId"]),
                            DescClaseNave = dr["DescClaseNave"].ToString(),
                            CodigoClaseNave = dr["CodigoClaseNave"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarClaseNave(ClaseNaveDTO claseNaveDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ClaseNaveRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescClaseNave", SqlDbType.VarChar, 80);
                    cmd.Parameters["@DescClaseNave"].Value = claseNaveDTO.DescClaseNave;

                    cmd.Parameters.Add("@CodigoClaseNave", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoClaseNave"].Value = claseNaveDTO.CodigoClaseNave;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = claseNaveDTO.UsuarioIngresoRegistro;

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

        public ClaseNaveDTO BuscarClaseNaveID(int Codigo)
        {
            ClaseNaveDTO claseNaveDTO = new ClaseNaveDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ClaseNaveEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ClaseNaveId", SqlDbType.Int);
                    cmd.Parameters["@ClaseNaveId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        claseNaveDTO.ClaseNaveId = Convert.ToInt32(dr["ClaseNaveId"]);
                        claseNaveDTO.DescClaseNave = dr["DescClaseNave"].ToString();
                        claseNaveDTO.CodigoClaseNave = dr["CodigoClaseNave"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return claseNaveDTO;
        }

        public string ActualizarClaseNave(ClaseNaveDTO claseNaveDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ClaseNaveActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ClaseNaveId", SqlDbType.Int);
                    cmd.Parameters["@ClaseNaveId"].Value = claseNaveDTO.ClaseNaveId;

                    cmd.Parameters.Add("@DescClaseNave", SqlDbType.VarChar, 80);
                    cmd.Parameters["@DescClaseNave"].Value = claseNaveDTO.DescClaseNave;

                    cmd.Parameters.Add("@CodigoClaseNave", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoClaseNave"].Value = claseNaveDTO.CodigoClaseNave;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = claseNaveDTO.UsuarioIngresoRegistro;

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

        public string EliminarClaseNave(ClaseNaveDTO claseNaveDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ClaseNaveEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ClaseNaveId", SqlDbType.Int);
                    cmd.Parameters["@ClaseNaveId"].Value = claseNaveDTO.ClaseNaveId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = claseNaveDTO.UsuarioIngresoRegistro;

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
