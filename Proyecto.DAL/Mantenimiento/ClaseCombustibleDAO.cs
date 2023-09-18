using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class ClaseCombustibleDAO
    {

        SqlCommand cmd = new();

        public List<ClaseCombustibleDTO> ObtenerClaseCombustibles()
        {
            List<ClaseCombustibleDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_ClaseCombustibleListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ClaseCombustibleDTO()
                        {
                            ClaseCombustibleId = Convert.ToInt32(dr["ClaseCombustibleId"]),
                            DescClaseCombustible = dr["DescClaseCombustible"].ToString(),
                            CodigoClaseCombustible = dr["CodigoClaseCombustible"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarClaseCombustible(ClaseCombustibleDTO ClaseCombustibleDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ClaseCombustibleRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescClaseCombustible", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescClaseCombustible"].Value = ClaseCombustibleDTO.DescClaseCombustible;

                    cmd.Parameters.Add("@CodigoClaseCombustible", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoClaseCombustible"].Value = ClaseCombustibleDTO.CodigoClaseCombustible;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ClaseCombustibleDTO.UsuarioIngresoRegistro;

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

        public ClaseCombustibleDTO BuscarClaseCombustibleID(int Codigo)
        {
            ClaseCombustibleDTO ClaseCombustibleDTO = new ClaseCombustibleDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ClaseCombustibleEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ClaseCombustibleId", SqlDbType.Int);
                    cmd.Parameters["@ClaseCombustibleId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        ClaseCombustibleDTO.ClaseCombustibleId = Convert.ToInt32(dr["ClaseCombustibleId"]);
                        ClaseCombustibleDTO.DescClaseCombustible = dr["DescClaseCombustible"].ToString();
                        ClaseCombustibleDTO.CodigoClaseCombustible = dr["CodigoClaseCombustible"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return ClaseCombustibleDTO;
        }

        public string ActualizarClaseCombustible(ClaseCombustibleDTO ClaseCombustibleDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ClaseCombustibleActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ClaseCombustibleId", SqlDbType.Int);
                    cmd.Parameters["@ClaseCombustibleId"].Value = ClaseCombustibleDTO.ClaseCombustibleId;

                    cmd.Parameters.Add("@DescClaseCombustible", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescClaseCombustible"].Value = ClaseCombustibleDTO.DescClaseCombustible;

                    cmd.Parameters.Add("@CodigoClaseCombustible", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoClaseCombustible"].Value = ClaseCombustibleDTO.CodigoClaseCombustible;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ClaseCombustibleDTO.UsuarioIngresoRegistro;

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

        public string EliminarClaseCombustible(ClaseCombustibleDTO ClaseCombustibleDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ClaseCombustibleEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ClaseCombustibleId", SqlDbType.Int);
                    cmd.Parameters["@ClaseCombustibleId"].Value = ClaseCombustibleDTO.ClaseCombustibleId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ClaseCombustibleDTO.UsuarioIngresoRegistro;

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
