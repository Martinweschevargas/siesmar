using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class ClasificacionFlotaDAO
    {

        SqlCommand cmd = new();

        public List<ClasificacionFlotaDTO> ObtenerClasificacionFlotas()
        {
            List<ClasificacionFlotaDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_ClasificacionFlotaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ClasificacionFlotaDTO()
                        {
                            ClasificacionFlotaId = Convert.ToInt32(dr["ClasificacionFlotaId"]),
                            DescClasificacionFlota = dr["DescClasificacionFlota"].ToString(),
                            CodigoClasificacionFlota = dr["CodigoClasificacionFlota"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarClasificacionFlota(ClasificacionFlotaDTO clasificacionFlotaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ClasificacionFlotaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescClasificacionFlota", SqlDbType.VarChar, 200);
                    cmd.Parameters["@DescClasificacionFlota"].Value = clasificacionFlotaDTO.DescClasificacionFlota;

                    cmd.Parameters.Add("@CodigoClasificacionFlota", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoClasificacionFlota"].Value = clasificacionFlotaDTO.CodigoClasificacionFlota;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = clasificacionFlotaDTO.UsuarioIngresoRegistro;

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

        public ClasificacionFlotaDTO BuscarClasificacionFlotaID(int Codigo)
        {
            ClasificacionFlotaDTO clasificacionFlotaDTO = new ClasificacionFlotaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ClasificacionFlotaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ClasificacionFlotaId", SqlDbType.Int);
                    cmd.Parameters["@ClasificacionFlotaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        clasificacionFlotaDTO.ClasificacionFlotaId = Convert.ToInt32(dr["ClasificacionFlotaId"]);
                        clasificacionFlotaDTO.DescClasificacionFlota = dr["DescClasificacionFlota"].ToString();
                        clasificacionFlotaDTO.CodigoClasificacionFlota = dr["CodigoClasificacionFlota"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return clasificacionFlotaDTO;
        }

        public string ActualizarClasificacionFlota(ClasificacionFlotaDTO clasificacionFlotaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ClasificacionFlotaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ClasificacionFlotaId", SqlDbType.Int);
                    cmd.Parameters["@ClasificacionFlotaId"].Value = clasificacionFlotaDTO.ClasificacionFlotaId;

                    cmd.Parameters.Add("@DescClasificacionFlota", SqlDbType.VarChar, 200);
                    cmd.Parameters["@DescClasificacionFlota"].Value = clasificacionFlotaDTO.DescClasificacionFlota;

                    cmd.Parameters.Add("@CodigoClasificacionFlota", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoClasificacionFlota"].Value = clasificacionFlotaDTO.CodigoClasificacionFlota;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = clasificacionFlotaDTO.UsuarioIngresoRegistro;

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

        public string EliminarClasificacionFlota(ClasificacionFlotaDTO clasificacionFlotaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ClasificacionFlotaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ClasificacionFlotaId", SqlDbType.Int);
                    cmd.Parameters["@ClasificacionFlotaId"].Value = clasificacionFlotaDTO.ClasificacionFlotaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = clasificacionFlotaDTO.UsuarioIngresoRegistro;

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
