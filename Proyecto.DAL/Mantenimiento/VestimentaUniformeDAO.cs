using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class VestimentaUniformeDAO
    {

        SqlCommand cmd = new();

        public List<VestimentaUniformeDTO> ObtenerVestimentaUniformes()
        {
            List<VestimentaUniformeDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_VestimentaUniformeListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new VestimentaUniformeDTO()
                        {
                            VestimentaUniformeId = Convert.ToInt32(dr["VestimentaUniformeId"]),
                            DescVestimentaUniforme = dr["DescVestimentaUniforme"].ToString(),
                            CodigoVestimentaUniforme = dr["CodigoVestimentaUniforme"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarVestimentaUniforme(VestimentaUniformeDTO vestimentaUniformeDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_VestimentaUniformeRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescVestimentaUniforme", SqlDbType.VarChar, 200);
                    cmd.Parameters["@DescVestimentaUniforme"].Value = vestimentaUniformeDTO.DescVestimentaUniforme;

                    cmd.Parameters.Add("@CodigoVestimentaUniforme", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoVestimentaUniforme"].Value = vestimentaUniformeDTO.CodigoVestimentaUniforme;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = vestimentaUniformeDTO.UsuarioIngresoRegistro;

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

        public VestimentaUniformeDTO BuscarVestimentaUniformeID(int Codigo)
        {
            VestimentaUniformeDTO vestimentaUniformeDTO = new VestimentaUniformeDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_VestimentaUniformeEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@VestimentaUniformeId", SqlDbType.Int);
                    cmd.Parameters["@VestimentaUniformeId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        vestimentaUniformeDTO.VestimentaUniformeId = Convert.ToInt32(dr["VestimentaUniformeId"]);
                        vestimentaUniformeDTO.DescVestimentaUniforme = dr["DescVestimentaUniforme"].ToString();
                        vestimentaUniformeDTO.CodigoVestimentaUniforme = dr["CodigoVestimentaUniforme"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return vestimentaUniformeDTO;
        }

        public string ActualizarVestimentaUniforme(VestimentaUniformeDTO vestimentaUniformeDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_VestimentaUniformeActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@VestimentaUniformeId", SqlDbType.Int);
                    cmd.Parameters["@VestimentaUniformeId"].Value = vestimentaUniformeDTO.VestimentaUniformeId;

                    cmd.Parameters.Add("@DescVestimentaUniforme", SqlDbType.VarChar, 200);
                    cmd.Parameters["@DescVestimentaUniforme"].Value = vestimentaUniformeDTO.DescVestimentaUniforme;

                    cmd.Parameters.Add("@CodigoVestimentaUniforme", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoVestimentaUniforme"].Value = vestimentaUniformeDTO.CodigoVestimentaUniforme;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = vestimentaUniformeDTO.UsuarioIngresoRegistro;

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

        public string EliminarVestimentaUniforme(VestimentaUniformeDTO vestimentaUniformeDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_VestimentaUniformeEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@VestimentaUniformeId", SqlDbType.Int);
                    cmd.Parameters["@VestimentaUniformeId"].Value = vestimentaUniformeDTO.VestimentaUniformeId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = vestimentaUniformeDTO.UsuarioIngresoRegistro;

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
