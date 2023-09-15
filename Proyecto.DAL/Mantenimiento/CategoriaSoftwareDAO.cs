using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class CategoriaSoftwareDAO
    {

        SqlCommand cmd = new();

        public List<CategoriaSoftwareDTO> ObtenerCategoriaSoftwares()
        {
            List<CategoriaSoftwareDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_CategoriaSoftwareListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new CategoriaSoftwareDTO()
                        {
                            CategoriaSoftwareId = Convert.ToInt32(dr["CategoriaSoftwareId"]),
                            DescCategoriaSoftware = dr["DescCategoriaSoftware"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarCategoriaSoftware(CategoriaSoftwareDTO CategoriaSoftwareDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CategoriaSoftwareRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescCategoriaSoftware", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescCategoriaSoftware"].Value = CategoriaSoftwareDTO.DescCategoriaSoftware;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = CategoriaSoftwareDTO.UsuarioIngresoRegistro;

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

        public CategoriaSoftwareDTO BuscarCategoriaSoftwareID(int Codigo)
        {
            CategoriaSoftwareDTO CategoriaSoftwareDTO = new CategoriaSoftwareDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CategoriaSoftwareEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CategoriaSoftwareId", SqlDbType.Int);
                    cmd.Parameters["@CategoriaSoftwareId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        CategoriaSoftwareDTO.CategoriaSoftwareId = Convert.ToInt32(dr["CategoriaSoftwareId"]);
                        CategoriaSoftwareDTO.DescCategoriaSoftware = dr["DescCategoriaSoftware"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return CategoriaSoftwareDTO;
        }

        public string ActualizarCategoriaSoftware(CategoriaSoftwareDTO CategoriaSoftwareDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CategoriaSoftwareActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CategoriaSoftwareId", SqlDbType.Int);
                    cmd.Parameters["@CategoriaSoftwareId"].Value = CategoriaSoftwareDTO.CategoriaSoftwareId;

                    cmd.Parameters.Add("@DescCategoriaSoftware", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescCategoriaSoftware"].Value = CategoriaSoftwareDTO.DescCategoriaSoftware;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = CategoriaSoftwareDTO.UsuarioIngresoRegistro;

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

        public string EliminarCategoriaSoftware(CategoriaSoftwareDTO CategoriaSoftwareDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CategoriaSoftwareEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CategoriaSoftwareId", SqlDbType.Int);
                    cmd.Parameters["@CategoriaSoftwareId"].Value = CategoriaSoftwareDTO.CategoriaSoftwareId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = CategoriaSoftwareDTO.UsuarioIngresoRegistro;

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
