using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class CicloDesarrolloSoftwareDAO
    {

        SqlCommand cmd = new();

        public List<CicloDesarrolloSoftwareDTO> ObtenerCicloDesarrolloSoftwares()
        {
            List<CicloDesarrolloSoftwareDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_CicloDesarrolloSoftwareListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new CicloDesarrolloSoftwareDTO()
                        {
                            CicloDesarrolloSoftwareId = Convert.ToInt32(dr["CicloDesarrolloSoftwareId"]),
                            DescCicloDesarrolloSoftware = dr["DescCicloDesarrolloSoftware"].ToString(),
                            CodigoCicloDesarrolloSoftware = dr["CodigoCicloDesarrolloSoftware"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarCicloDesarrolloSoftware(CicloDesarrolloSoftwareDTO cicloDesarrolloSoftwareDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CicloDesarrolloSoftwareRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescCicloDesarrolloSoftware", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescCicloDesarrolloSoftware"].Value = cicloDesarrolloSoftwareDTO.DescCicloDesarrolloSoftware;

                    cmd.Parameters.Add("@CodigoCicloDesarrolloSoftware", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoCicloDesarrolloSoftware"].Value = cicloDesarrolloSoftwareDTO.CodigoCicloDesarrolloSoftware;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = cicloDesarrolloSoftwareDTO.UsuarioIngresoRegistro;

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

        public CicloDesarrolloSoftwareDTO BuscarCicloDesarrolloSoftwareID(int Codigo)
        {
            CicloDesarrolloSoftwareDTO cicloDesarrolloSoftwareDTO = new CicloDesarrolloSoftwareDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CicloDesarrolloSoftwareEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CicloDesarrolloSoftwareId", SqlDbType.Int);
                    cmd.Parameters["@CicloDesarrolloSoftwareId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        cicloDesarrolloSoftwareDTO.CicloDesarrolloSoftwareId = Convert.ToInt32(dr["cicloDesarrolloSoftwareId"]);
                        cicloDesarrolloSoftwareDTO.DescCicloDesarrolloSoftware = dr["DescCicloDesarrolloSoftware"].ToString();
                        cicloDesarrolloSoftwareDTO.CodigoCicloDesarrolloSoftware = dr["CodigoCicloDesarrolloSoftware"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return cicloDesarrolloSoftwareDTO;
        }

        public string ActualizarCicloDesarrolloSoftware(CicloDesarrolloSoftwareDTO cicloDesarrolloSoftwareDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CicloDesarrolloSoftwareActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CicloDesarrolloSoftwareId", SqlDbType.Int);
                    cmd.Parameters["@CicloDesarrolloSoftwareId"].Value = cicloDesarrolloSoftwareDTO.CicloDesarrolloSoftwareId;

                    cmd.Parameters.Add("@DescCicloDesarrolloSoftware", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescCicloDesarrolloSoftware"].Value = cicloDesarrolloSoftwareDTO.DescCicloDesarrolloSoftware;

                    cmd.Parameters.Add("@CodigoCicloDesarrolloSoftware", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoCicloDesarrolloSoftware"].Value = cicloDesarrolloSoftwareDTO.CodigoCicloDesarrolloSoftware;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = cicloDesarrolloSoftwareDTO.UsuarioIngresoRegistro;

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

        public string EliminarCicloDesarrolloSoftware(CicloDesarrolloSoftwareDTO cicloDesarrolloSoftwareDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CicloDesarrolloSoftwareEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CicloDesarrolloSoftwareId", SqlDbType.Int);
                    cmd.Parameters["@CicloDesarrolloSoftwareId"].Value = cicloDesarrolloSoftwareDTO.CicloDesarrolloSoftwareId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = cicloDesarrolloSoftwareDTO.UsuarioIngresoRegistro;

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
