using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class ColorVehiculoDAO
    {

        SqlCommand cmd = new();

        public List<ColorVehiculoDTO> ObtenerColorVehiculos()
        {
            List<ColorVehiculoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_ColorVehiculoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ColorVehiculoDTO()
                        {
                            ColorVehiculoId = Convert.ToInt32(dr["ColorVehiculoId"]),
                            DescColorVehiculo = dr["DescColorVehiculo"].ToString(),
                            CodigoColorVehiculo = dr["CodigoColorVehiculo"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarColorVehiculo(ColorVehiculoDTO ColorVehiculoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ColorVehiculoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescColorVehiculo", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescColorVehiculo"].Value = ColorVehiculoDTO.DescColorVehiculo;

                    cmd.Parameters.Add("@CodigoColorVehiculo", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoColorVehiculo"].Value = ColorVehiculoDTO.CodigoColorVehiculo;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ColorVehiculoDTO.UsuarioIngresoRegistro;

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

        public ColorVehiculoDTO BuscarColorVehiculoID(int Codigo)
        {
            ColorVehiculoDTO ColorVehiculoDTO = new ColorVehiculoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ColorVehiculoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ColorVehiculoId", SqlDbType.Int);
                    cmd.Parameters["@ColorVehiculoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        ColorVehiculoDTO.ColorVehiculoId = Convert.ToInt32(dr["ColorVehiculoId"]);
                        ColorVehiculoDTO.DescColorVehiculo = dr["DescColorVehiculo"].ToString();
                        ColorVehiculoDTO.CodigoColorVehiculo = dr["CodigoColorVehiculo"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return ColorVehiculoDTO;
        }

        public string ActualizarColorVehiculo(ColorVehiculoDTO ColorVehiculoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ColorVehiculoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ColorVehiculoId", SqlDbType.Int);
                    cmd.Parameters["@ColorVehiculoId"].Value = ColorVehiculoDTO.ColorVehiculoId;

                    cmd.Parameters.Add("@DescColorVehiculo", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescColorVehiculo"].Value = ColorVehiculoDTO.DescColorVehiculo;

                    cmd.Parameters.Add("@CodigoColorVehiculo", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoColorVehiculo"].Value = ColorVehiculoDTO.CodigoColorVehiculo;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ColorVehiculoDTO.UsuarioIngresoRegistro;

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

        public string EliminarColorVehiculo(ColorVehiculoDTO ColorVehiculoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ColorVehiculoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ColorVehiculoId", SqlDbType.Int);
                    cmd.Parameters["@ColorVehiculoId"].Value = ColorVehiculoDTO.ColorVehiculoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ColorVehiculoDTO.UsuarioIngresoRegistro;

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
