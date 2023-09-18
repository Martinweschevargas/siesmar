using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class ClaseFlotaDAO
    {

        SqlCommand cmd = new();

        public List<ClaseFlotaDTO> ObtenerClaseFlotas()
        {
            List<ClaseFlotaDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_ClaseFlotaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ClaseFlotaDTO()
                        {
                            ClaseFlotaId = Convert.ToInt32(dr["ClaseFlotaId"]),
                            DescClaseFlota = dr["DescClaseFlota"].ToString(),
                            CodigoClaseFlota = dr["CodigoClaseFlota"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarClaseFlota(ClaseFlotaDTO claseFlotaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ClaseFlotaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescClaseFlota", SqlDbType.VarChar, 100);
                    cmd.Parameters["@DescClaseFlota"].Value = claseFlotaDTO.DescClaseFlota;

                    cmd.Parameters.Add("@CodigoClaseFlota", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoClaseFlota"].Value = claseFlotaDTO.CodigoClaseFlota;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = claseFlotaDTO.UsuarioIngresoRegistro;

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

        public ClaseFlotaDTO BuscarClaseFlotaID(int Codigo)
        {
            ClaseFlotaDTO claseFlotaDTO = new ClaseFlotaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ClaseFlotaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ClaseFlotaId", SqlDbType.Int);
                    cmd.Parameters["@ClaseFlotaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        claseFlotaDTO.ClaseFlotaId = Convert.ToInt32(dr["ClaseFlotaId"]);
                        claseFlotaDTO.DescClaseFlota = dr["DescClaseFlota"].ToString();
                        claseFlotaDTO.CodigoClaseFlota = dr["CodigoClaseFlota"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return claseFlotaDTO;
        }

        public string ActualizarClaseFlota(ClaseFlotaDTO claseFlotaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ClaseFlotaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ClaseFlotaId", SqlDbType.Int);
                    cmd.Parameters["@ClaseFlotaId"].Value = claseFlotaDTO.ClaseFlotaId;

                    cmd.Parameters.Add("@DescClaseFlota", SqlDbType.VarChar, 100);
                    cmd.Parameters["@DescClaseFlota"].Value = claseFlotaDTO.DescClaseFlota;

                    cmd.Parameters.Add("@CodigoClaseFlota", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoClaseFlota"].Value = claseFlotaDTO.CodigoClaseFlota;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = claseFlotaDTO.UsuarioIngresoRegistro;

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

        public string EliminarClaseFlota(ClaseFlotaDTO claseFlotaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ClaseFlotaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ClaseFlotaId", SqlDbType.Int);
                    cmd.Parameters["@ClaseFlotaId"].Value = claseFlotaDTO.ClaseFlotaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = claseFlotaDTO.UsuarioIngresoRegistro;

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
