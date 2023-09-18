using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class DenominacionSoftwareDAO
    {

        SqlCommand cmd = new();

        public List<DenominacionSoftwareDTO> ObtenerDenominacionSoftwares()
        {
            List<DenominacionSoftwareDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_DenominacionSoftwareListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new DenominacionSoftwareDTO()
                        {
                            DenominacionSoftwareId = Convert.ToInt32(dr["DenominacionSoftwareId"]),
                            DescDenominacionSoftware = dr["DescDenominacionSoftware"].ToString(),
                            CodigoDenominacionSoftware = dr["CodigoDenominacionSoftware"].ToString(),
                            DenominacionSoftware = dr["DenominacionSoftware"].ToString(),
                            DescCategoriaSoftware = dr["DescCategoriaSoftware"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarDenominacionSoftware(DenominacionSoftwareDTO puertoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_DenominacionSoftwareRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescDenominacionSoftware", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescDenominacionSoftware"].Value = puertoDTO.DescDenominacionSoftware;

                    cmd.Parameters.Add("@CodigoDenominacionSoftware", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDenominacionSoftware"].Value = puertoDTO.CodigoDenominacionSoftware;

                    cmd.Parameters.Add("@DenominacionSoftware", SqlDbType.VarChar, 20);
                    cmd.Parameters["@DenominacionSoftware"].Value = puertoDTO.DenominacionSoftware;

                    cmd.Parameters.Add("@CategoriaSoftwareId", SqlDbType.Int);
                    cmd.Parameters["@CategoriaSoftwareId"].Value = puertoDTO.CategoriaSoftwareId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = puertoDTO.UsuarioIngresoRegistro;

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

        public DenominacionSoftwareDTO BuscarDenominacionSoftwareID(int Codigo)
        {
            DenominacionSoftwareDTO puertoDTO = new DenominacionSoftwareDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_DenominacionSoftwareEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DenominacionSoftwareId", SqlDbType.Int);
                    cmd.Parameters["@DenominacionSoftwareId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        puertoDTO.DenominacionSoftwareId = Convert.ToInt32(dr["DenominacionSoftwareId"]);
                        puertoDTO.DescDenominacionSoftware = dr["DescDenominacionSoftware"].ToString();
                        puertoDTO.CodigoDenominacionSoftware = dr["CodigoDenominacionSoftware"].ToString();
                        puertoDTO.DenominacionSoftware = dr["DenominacionSoftware"].ToString();
                        puertoDTO.CategoriaSoftwareId = Convert.ToInt32(dr["CategoriaSoftwareId"]);
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return puertoDTO;
        }

        public string ActualizarDenominacionSoftware(DenominacionSoftwareDTO puertoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_DenominacionSoftwareActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DenominacionSoftwareId", SqlDbType.Int);
                    cmd.Parameters["@DenominacionSoftwareId"].Value = puertoDTO.DenominacionSoftwareId;

                    cmd.Parameters.Add("@DescDenominacionSoftware", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescDenominacionSoftware"].Value = puertoDTO.DescDenominacionSoftware;

                    cmd.Parameters.Add("@CodigoDenominacionSoftware", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDenominacionSoftware"].Value = puertoDTO.CodigoDenominacionSoftware;

                    cmd.Parameters.Add("@DenominacionSoftware", SqlDbType.VarChar, 20);
                    cmd.Parameters["@DenominacionSoftware"].Value = puertoDTO.DenominacionSoftware;

                    cmd.Parameters.Add("@CategoriaSoftwareId", SqlDbType.Int);
                    cmd.Parameters["@CategoriaSoftwareId"].Value = puertoDTO.CategoriaSoftwareId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = puertoDTO.UsuarioIngresoRegistro;

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

        public string EliminarDenominacionSoftware(DenominacionSoftwareDTO puertoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_DenominacionSoftwareEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DenominacionSoftwareId", SqlDbType.Int);
                    cmd.Parameters["@DenominacionSoftwareId"].Value = puertoDTO.DenominacionSoftwareId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = puertoDTO.UsuarioIngresoRegistro;

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
