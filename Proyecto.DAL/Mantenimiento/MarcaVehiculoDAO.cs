using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class MarcaVehiculoDAO
    {

        SqlCommand cmd = new();

        public List<MarcaVehiculoDTO> ObtenerMarcaVehiculos()
        {
            List<MarcaVehiculoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_MarcaVehiculosListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new MarcaVehiculoDTO()
                        {
                            MarcaVehiculoId = Convert.ToInt32(dr["MarcaVehiculoId"]),
                            ClasificacionVehiculo = dr["ClasificacionVehiculo"].ToString(),
                            CodigoMarcaVehiculo = dr["CodigoMarcaVehiculo"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarMarcaVehiculo(MarcaVehiculoDTO marcaVehiculoDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_MarcaVehiculosRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ClasificacionVehiculo", SqlDbType.VarChar, 50);                    
                    cmd.Parameters["@ClasificacionVehiculo"].Value = marcaVehiculoDTO.ClasificacionVehiculo;

                    cmd.Parameters.Add("@CodigoMarcaVehiculo", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoMarcaVehiculo"].Value = marcaVehiculoDTO.CodigoMarcaVehiculo;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = marcaVehiculoDTO.UsuarioIngresoRegistro;

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

        public MarcaVehiculoDTO BuscarMarcaVehiculoID(int Codigo)
        {
            MarcaVehiculoDTO marcaVehiculoDTO = new MarcaVehiculoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_MarcaVehiculosEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MarcaVehiculoId", SqlDbType.Int);
                    cmd.Parameters["@MarcaVehiculoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        marcaVehiculoDTO.MarcaVehiculoId = Convert.ToInt32(dr["MarcaVehiculoId"]);
                        marcaVehiculoDTO.ClasificacionVehiculo = dr["ClasificacionVehiculo"].ToString();
                        marcaVehiculoDTO.CodigoMarcaVehiculo = dr["CodigoMarcaVehiculo"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return marcaVehiculoDTO;
        }

        public string ActualizarMarcaVehiculo(MarcaVehiculoDTO marcaVehiculoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_MarcaVehiculosActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MarcaVehiculoId", SqlDbType.Int);
                    cmd.Parameters["@MarcaVehiculoId"].Value = marcaVehiculoDTO.MarcaVehiculoId;

                    cmd.Parameters.Add("@ClasificacionVehiculo", SqlDbType.VarChar, 50);
                    cmd.Parameters["@ClasificacionVehiculo"].Value = marcaVehiculoDTO.ClasificacionVehiculo;

                    cmd.Parameters.Add("@CodigoMarcaVehiculo", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoMarcaVehiculo"].Value = marcaVehiculoDTO.CodigoMarcaVehiculo;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = marcaVehiculoDTO.UsuarioIngresoRegistro;

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

        public string EliminarMarcaVehiculo(MarcaVehiculoDTO MarcaVehiculoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_MarcaVehiculosEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MarcaVehiculoId", SqlDbType.Int);
                    cmd.Parameters["@MarcaVehiculoId"].Value = MarcaVehiculoDTO.MarcaVehiculoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = MarcaVehiculoDTO.UsuarioIngresoRegistro;

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
